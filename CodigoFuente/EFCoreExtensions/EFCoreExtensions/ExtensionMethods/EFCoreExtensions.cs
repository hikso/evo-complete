using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace EFCoreExtensions.ExtensionMethods
{
    /***************************************************************************************************************************************************************************
     * Autor            : Andrés Giraldo
     * Fecha de Creación: 27-Jul/2019
     * Descripción      : Esta clase contiene métodos de extensión para la clase DbContext, con el objetivo de proveer métodos que permitan ejecutar procedimiento almacenados
     *                    y que su resultado pueda ser mapeado a listas genéricas. Se hace uso de ADO.NET para proveer un WorkAround al Issue 245.
     *                    Actualmente esto no viene implementado de forma nativa en Entity Framework Core https://github.com/aspnet/EntityFrameworkCore/issues/245
     * Requisitos:        Microsoft.NETCore.App 2.1
     *                    Microsoft.EntityFrameworkCore.SqlServer 2.2.6
     ***************************************************************************************************************************************************************************/
    public static class EFCoreExtensions
    {
        #region Métodos Privados
        /// <summary>
        /// Este método permite generar un DbCommand a partir de un procedimiento almacenado.
        /// </summary>
        /// <param name="context">DbContext de Entity Framwork Core</param>
        /// <param name="storedProcedureName">Nombre del Procedimiento Almacenado</param>
        /// <returns>DbCommand</returns>
        private static DbCommand CreateCommandFromSP(this DbContext context, string storedProcedureName)
        {
            var cmd = context.Database.GetDbConnection().CreateCommand();

            cmd.CommandText = storedProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }

        /// <summary>
        /// Este método permite generar un DbCommand a partir de un procedimiento almacenado y una lista de parámetros (EFCoreExtensionParameters).
        /// </summary>
        /// <param name="context">DbContext de Entity Framwork Core</param>
        /// <param name="storedProcedureName">Nombre del Procedimiento Almacenado</param>
        /// <param name="parameters">Lista de parámetros (EFCoreExtensionParameter)</param>
        /// <returns>DbCommand</returns>
        private static DbCommand CreateCommandFromSP(this DbContext context, string storedProcedureName, List<EFCoreExtensionParameter> parameters)
        {
            var cmd = context.CreateCommandFromSP(storedProcedureName);

            foreach (EFCoreExtensionParameter p in parameters)
            {
                DbParameter param = cmd.CreateParameter();

                param.ParameterName = p.ParameterName;
                param.DbType = p.DbType;
                param.Value = (p.Value != null ? p.Value : DBNull.Value);

                cmd.Parameters.Add(param);
            }

            return cmd;
        }

        /// <summary>
        /// Este método se encarga de ejecutar un procedimiento almacenado a partir de un comando y cargar automáticamente los resultados en una lista de tipo T
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a cargar</typeparam>
        /// <param name="cmd">Comando de tipo DbCommand</param>
        /// <returns>Lista de objetos de tipo T</returns>
        private static List<T> loadSPAutoMapper<T>(DbCommand cmd)
        {
            List<T> resultList = null;

            //Si la conexión no está abierta se generará una excepción al momento de ejecutar el reader
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    resultList = new List<T>();

                    T obj;

                    //Obtener lista de las propiedades del tipo T
                    var objectProperties = typeof(T).GetRuntimeProperties().ToList();

                    //Obtener lista de columnas en el DbDataReader
                    var readerColumns = reader.GetColumnSchema()
                        .Where(x => objectProperties.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                        .ToDictionary(key => key.ColumnName.ToLower());

                    //Por cada registro del DbDataReader llenar la lista T
                    while (reader.Read())
                    {
                        //Se crea una instancia de tipo T
                        obj = Activator.CreateInstance<T>();

                        //Se llena una a una las propiedades del objeto T
                        foreach (var p in objectProperties)
                        {
                            if (readerColumns.ContainsKey(p.Name.ToLower()))
                            {
                                var column = readerColumns[p.Name.ToLower()];

                                if (column?.ColumnOrdinal != null)
                                {
                                    var val = reader.GetValue(column.ColumnOrdinal.Value);

                                    p.SetValue(obj, val == DBNull.Value ? null : val);
                                }
                            }
                        }

                        resultList.Add(obj);
                    }
                }
            }

            return resultList;
        }

        /// <summary>
        /// Este método se encarga de ejecutar un procedimiento almacenado a partir de un comando y cargar los resultados en una lista de tipo T.
        /// Para ello, se requiere implementar un delegado CustomMapper<T> que indique como se debe mapear un DbDataReader
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a cargar</typeparam>
        /// <param name="cmd">Comando de tipo DbCommand</param>
        /// <param name="mapper">Delegado para mapear de forma personalizada el DbDataReader</param>
        /// <returns></returns>
        private static List<T> loadSPCustomMapper<T>(DbCommand cmd, CustomMapper<T> mapper)
        {
            List<T> resultList = null;

            //Si la conexión no está abierta se generará una excepción al momento de ejecutar el reader
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    resultList = new List<T>();

                    T obj;

                    //Por cada registro del DbDataReader llenar la lista T
                    while (reader.Read())
                    {
                        //Se mapea el DbDataReader en un objeto de tipo T al invocar el delegado del mapeador personalizado
                        obj = mapper(reader);

                        resultList.Add(obj);
                    }
                }
            }

            return resultList;
        }

        /// <summary>
        /// Este método se encarga de ejecutar un procedimiento almacenado a partir de un comando y retornar el valor escalar del procedimiento
        /// </summary>
        /// <param name="cmd">Comando de tipo DbCommand</param>
        /// <returns>Objeto escalar</returns>
        private static object loadSPScalar(DbCommand cmd)
        {
            //Si la conexión no está abierta se generará una excepción al momento de ejecutar el reader
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }

            //Ejecutar el procedimiento almacenado y leer el objeto
            object result = cmd.ExecuteScalar();

            return result;
        }
        #endregion

        #region Delegates
        /// <summary>
        /// Este delegado es necesario para mapear de forma personalizada un DbDatareader en un objeto de tipo T
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a mapear</typeparam>
        /// <param name="reader">DbDataReader</param>
        /// <returns>Instancia de objeto de tipo T</returns>
        public delegate T CustomMapper<T>(DbDataReader reader);
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Este método ejecuta un procedimiento almacenado y lo mapea a una lista de objetos cuyas propiedades se llamen igual a las columnas del procedimiento
        /// </summary>
        /// <typeparam name="T">Tipo Genérico de Objeto</typeparam>
        /// <param name="context">DbContext de Entity Framwork Core</param>
        /// <param name="storedProcedureName">Nombre del Procedimiento Almacenado</param>
        /// <returns>Lista de objetos de tipo T</returns>
        public static List<T> LoadSPAutoMapper<T>(this DbContext context, string storedProcedureName)
        {
            List<T> resultList = null;

            var cmd = context.CreateCommandFromSP(storedProcedureName);

            using (cmd)
            {
                resultList = loadSPAutoMapper<T>(cmd);
            }

            return resultList;
        }

        /// <summary>
        /// Este método ejecuta un procedimiento almacenado y lo mapea a una lista de objetos cuyas propiedades se llamen igual a las columnas del procedimiento
        /// </summary>
        /// <typeparam name="T">Tipo Genérico de Objeto</typeparam>
        /// <param name="context">DbContext de Entity Framwork Core</param>
        /// <param name="storedProcedureName">Nombre del Procedimiento Almacenado</param>
        /// <param name="parameters">Lista de parámetros (EFCoreExtensionParameters)</param>
        /// <returns>Lista de objetos de tipo T</returns>
        public static List<T> LoadSPAutoMapper<T>(this DbContext context, string storedProcedureName, List<EFCoreExtensionParameter> parameters)
        {
            List<T> resultList = null;

            var cmd = context.CreateCommandFromSP(storedProcedureName, parameters);

            using (cmd)
            {
                resultList = loadSPAutoMapper<T>(cmd);
            }

            return resultList;
        }

        /// <summary>
        /// Este método ejecuta un procedimiento almacenado y lo mapea a una lista de objetos con un mapeador personalizado
        /// </summary>
        /// <typeparam name="T">Tipo Genérico de Objeto</typeparam>
        /// <param name="context">DbContext de Entity Framwork Core</param>
        /// <param name="storedProcedureName">Nombre del Procedimiento Almacenado</param>
        /// <param name="mapper">Mapeador personalizado</param>
        /// <returns>Lista de objetos de tipo T</returns>
        public static List<T> LoadSPCustomMapper<T>(this DbContext context, string storedProcedureName, CustomMapper<T> mapper)
        {
            List<T> resultList = null;

            var cmd = context.CreateCommandFromSP(storedProcedureName);

            using (cmd)
            {
                resultList = loadSPCustomMapper<T>(cmd, mapper);
            }

            return resultList;
        }

        /// <summary>
        /// Este método ejecuta un procedimiento almacenado y lo mapea a una lista de objetos con un mapeador personalizado
        /// </summary>
        /// <typeparam name="T">Tipo Genérico de Objeto</typeparam>
        /// <param name="context">DbContext de Entity Framwork Core</param>
        /// <param name="storedProcedureName">Nombre del Procedimiento Almacenado</param>
        /// <param name="parameters">Lista de parámetros (EFCoreExtensionParameters)</param>
        /// <param name="mapper">Mapeador personalizado</param>
        /// <returns>Lista de objetos de tipo T</returns>
        public static List<T> LoadSPCustomMapper<T>(this DbContext context, string storedProcedureName, List<EFCoreExtensionParameter> parameters, CustomMapper<T> mapper)
        {
            List<T> resultList = null;

            var cmd = context.CreateCommandFromSP(storedProcedureName, parameters);

            using (cmd)
            {
                resultList = loadSPCustomMapper<T>(cmd, mapper);
            }

            return resultList;
        }

        /// <summary>
        /// Este procedimiento almacenado retorna un valor escalar desde un procedimiento almacenado
        /// </summary>
        /// <param name="context">DbContext de Entity Framwork Core</param>
        /// <param name="storedProcedureName">Nombre del Procedimiento Almacenado</param>
        /// <returns>Objeto escalar</returns>
        public static object LoadSPScalar(this DbContext context, string storedProcedureName)
        {
            object result = null;

            var cmd = context.CreateCommandFromSP(storedProcedureName);

            using (cmd)
            {
                result = loadSPScalar(cmd);
            }

            return result;
        }

        /// <summary>
        /// Este procedimiento almacenado retorna un valor escalar desde un procedimiento almacenado
        /// </summary>
        /// <param name="context">DbContext de Entity Framwork Core</param>
        /// <param name="storedProcedureName">Nombre del Procedimiento Almacenado</param>
        /// <param name="parameters">Lista de parámetros (EFCoreExtensionParameters)</param>
        /// <returns>Objeto escalar</returns>
        public static object LoadSPScalar(this DbContext context, string storedProcedureName, List<EFCoreExtensionParameter> parameters)
        {
            object result = null;

            var cmd = context.CreateCommandFromSP(storedProcedureName, parameters);

            using (cmd)
            {
                result = loadSPScalar(cmd);
            }

            return result;
        }
        #endregion
    }
}