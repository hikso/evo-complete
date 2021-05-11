using EFCoreExtensions.ExtensionMethods;
using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Kevin Restrepo Giraldo
    /// Fecha de Creación: 12-Ago/2019
    /// Descripción      : Acceso a datos de modulos
    /// </summary>
    public class DAModulo : DABase
    {
        #region Métodos Públicos
        /// <summary>
        /// Este método obtiene los modulos creados en el sistema
        /// </summary>
        /// <param name="desde">Indica el número de registro desde el cuál se deben cargar los registros</param>
        /// <param name="hasta">Indica el número de registro hasta el cuál se deben cargar los registros</param>
        /// <returns>Lista de modulos de tipo modulo</returns>
        public List<Modulo> obtenerTodosModulos(int desde, int hasta)
        {
            List<Modulo> listaModulos = null;

            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> parametros = new List<EFCoreExtensionParameter>();

                parametros.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@desde",
                    Value = desde
                });

                parametros.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@hasta",
                    Value = hasta
                });

                listaModulos = contexto.LoadSPAutoMapper<Modulo>("ObtenerTodosModulos", parametros);
            }

            return listaModulos;
        }

        /// <summary>
        /// Obtiene un módulo especifico por el nombre
        /// </summary>
        /// <param name="nombre">Indica el nombre por el cual se va a filtrar</param>
        /// <returns>Instancia de tipo Modulo por nombre</returns>
        public Modulo ObtenerModuloxNombre(string nombre)
        {
            Modulo modulo = null;

            using (var contexto = new Contexto())
            {
                EFModulo efModulo = (from m in contexto.Modulos
                                     where (m.Nombre.ToLower().Trim() == nombre.ToLower().Trim())
                                     select m).FirstOrDefault();

                modulo = this.mapper.Map<EFModulo, Modulo>(efModulo);

                if (modulo != null)
                {
                    int moduloId = modulo.ModuloId;

                    // Cargar las funcionalidades asociadas al módulo
                    var funcionalidades = contexto.Funcionalidades.
                        Where(x => x.ModuloId == moduloId && x.Activo).ToList();

                    if (funcionalidades != null)
                    {
                        modulo.Funcionalidades = this.mapper.Map<List<EFFuncionalidad>, List<Funcionalidad>>(funcionalidades);
                    }
                }
            }

            return modulo;
        }

        /// <summary>
        /// Obtiene un módulo especifico por el nombre
        /// </summary>
        /// <param name="moduloid">Indica el Id por el cual se va a filtrar</param>
        /// <returns>Instancia de tipo Modulo por id</returns>
        public Modulo ObtenerModuloxId(int moduloid)
        {
            Modulo modulo = null;

            using (var contexto = new Contexto())
            {
                EFModulo efModulo = (from m in contexto.Modulos
                                     where (m.ModuloID == moduloid)
                                     select m).FirstOrDefault();

                modulo = this.mapper.Map<EFModulo, Modulo>(efModulo);

                if (modulo != null)
                {
                    int moduloId = modulo.ModuloId;

                    // Cargar las funcionalidades asociadas al módulo
                    var funcionalidades = contexto.Funcionalidades.
                        Where(x => x.ModuloId == moduloId && x.Activo).ToList();

                    if (funcionalidades != null)
                    {
                        modulo.Funcionalidades = this.mapper.Map<List<EFFuncionalidad>, List<Funcionalidad>>(funcionalidades);
                    }
                }
            }

            return modulo;
        }
        #endregion
    }
}