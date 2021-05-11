using EFCoreExtensions.ExtensionMethods;
using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Kevin Restrepo Giraldo
    /// Fecha de Creación: 02-Ago/2019
    /// Descripción      : Se crea la clase que almacenara todo el registro de auditoria
    /// </summary>
    public class DAAuditoria : DABase
    {
        #region Métodos Públicos
        /// <summary>
        /// Este mètodo crea un registro en la tabla de auditoria
        /// </summary>
        /// <param name="nuevoRegistro">Registro de auditoria de tipo RegistroAuditoria</param>
        /// <returns>Verdadero si el registro se puede insertar, falso de lo contrario</returns>
        public bool CrearRegistro(RegistroAuditoria nuevoRegistro)
        {
            using (var contexto = new Contexto())
            {
                EFRegistroAuditoria nuevoEFRegistro = this.mapper.Map<RegistroAuditoria, EFRegistroAuditoria>(nuevoRegistro);

                //Se debe eliminar la instancia de usuario, para que no intente insertar / actualizar un registro de usuario
                nuevoEFRegistro.Usuario = null;

                contexto.Add(nuevoEFRegistro);
                
                contexto.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// Este método permite saber cuántos registros se generan de la consulta
        /// </summary>
        /// <returns>Número de registros</returns>
        public int ObtenerConteoTodosRegistros()
        {
            int nRegistros = 0;

            using (var contexto = new Contexto())
            {
                object result = contexto.LoadSPScalar("ObtenerConteoTodosRegistrosAuditoria");

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método permite saber cuántos registros se generan a partir de los filtros generados para la consulta
        /// </summary>
        /// <param name="filtro">Criterios de filtro para la consulta</param>
        /// <returns>Número de registros</returns>
        public int ObtenerConteoTodosRegistrosxFiltro(FiltroAuditoria filtro)
        {
            int nRegistros = 0;

            using (var contexto = new Contexto())
            {
                // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                if (!string.IsNullOrWhiteSpace(filtro.Usuario))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroUsuario",
                        Value = filtro.Usuario
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Accion))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroAccion",
                        Value = filtro.Accion
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Parametros))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroParametros",
                        Value = filtro.Parametros
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Fecha))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroFecha",
                        Value = filtro.Fecha
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.IP))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroIP",
                        Value = filtro.IP
                    });
                }

                object result = contexto.LoadSPScalar("ObtenerConteoTodosRegistrosAuditoriaxFiltro", dbParameters);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        /// <summary>
        /// Este metodo obtiene todos los registros de auditoria
        /// </summary>
        /// <param name="desde">Indica el nùmero de registro desde el cuàl se quiere obtener los registros de auditoria</param>
        /// <param name="hasta">Indica el nùmero de registro hasta el cuàl se quiere obtener los registros de auditoria</param>
        /// <returns>Si esta dentro de el numero de registros permitidos, devuelve una lista de RegistroAuditoria.</returns>
        public List<RegistroAuditoria> ObtenerTodosRegistros(int desde, int hasta)
        {
            using (var contexto = new Contexto())
            {
                // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Desde",
                    Value = desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Hasta",
                    Value = hasta
                });

                List<RegistroAuditoria> listaRegistrosAuditoria = contexto.LoadSPCustomMapper<RegistroAuditoria>("ObtenerTodosRegistrosAuditoria", dbParameters, mapeadorRegistroAuditoria);

                return listaRegistrosAuditoria;
            }
        }

        /// <summary>
        /// Este método obtiene todos los registros de Auditoria aplicando un filtro de búsqueda sobre las acciones
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda a aplicar sobre las acciones de auditoria</param>
        /// <returns>Lista de Registros de Auditoria</returns>
        public List<RegistroAuditoria> ObtenerTodosRegistrosxFiltro(FiltroAuditoria filtro)
        {
            using (var contexto = new Contexto())
            {
                // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@desde",
                    Value = filtro.Desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@hasta",
                    Value = filtro.Hasta
                });

                if (!string.IsNullOrWhiteSpace(filtro.Usuario))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroUsuario",
                        Value = filtro.Usuario
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Accion))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroAccion",
                        Value = filtro.Accion
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Parametros))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroParametros",
                        Value = filtro.Parametros
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Fecha))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroFecha",
                        Value = filtro.Fecha
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.IP))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroIP",
                        Value = filtro.IP
                    });
                }

                List<RegistroAuditoria> listaRegistrosAuditoria = contexto.LoadSPCustomMapper<RegistroAuditoria>("ObtenerTodosRegistrosAuditoriaxFiltro", dbParameters, mapeadorRegistroAuditoria);

                return listaRegistrosAuditoria;
            }
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Mapea un objeto DbDataReader a un objeto de tipo RegistroAuditoria
        /// </summary>
        /// <param name="reader">DbDataReader</param>
        /// <returns>Instancia de objeto de tipo RegistroAuditoria</returns>
        private RegistroAuditoria mapeadorRegistroAuditoria(DbDataReader reader)
        {
            RegistroAuditoria r = null;

            if (reader != null)
            {
                r = new RegistroAuditoria()
                {
                    RegistroAuditoriaId = int.Parse(reader["RegistroAuditoriaId"].ToString()),
                    Fecha = DateTime.Parse(reader["fecha"].ToString()),
                    UsuarioId = int.Parse(reader["UsuarioId"].ToString()),
                    Usuario = reader["Usuario"].ToString(),
                    Accion = reader["Accion"].ToString(),
                    IP = reader["IP"].ToString()
                };

                if (reader["Parametros"] != null)
                {
                    r.Parametros = reader["Parametros"].ToString();
                }
            }

            return r;
        }
        #endregion
    }
}