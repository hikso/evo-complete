using EFCoreExtensions.ExtensionMethods;
using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Kevin Restrepo Giraldo
    /// Fecha de Creación: 02-Ago/2019
    /// Descripción      : Clase de acceso a datos para los parámetros generales del sistema
    /// </summary>
    public class DAParametroGeneral : DABase
    {
        #region Métodos Públicos
        /// <summary>
        /// Este metodo crea un parametro general 
        /// </summary>
        /// <param name="nuevoParametroGeneral">Parametro general a crear</param>
        /// <returns>Verdadero si se pudo crear</returns>
        public bool CrearParametroGeneral(ParametroGeneral nuevoParametroGeneral)
        {
            using (var contexto = new Contexto())
            {
                EFParametroGeneral nuevoEFParametroGeneral = this.mapper.Map<ParametroGeneral, EFParametroGeneral>(nuevoParametroGeneral);

                contexto.Add(nuevoEFParametroGeneral);

                contexto.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// Este método obtiene el valor de un parámetro general del sistema dado su nombre
        /// </summary>
        /// <param name="nombre">Nombre del parámetro general a buscar</param>
        /// <returns>Valor del parámetro general</returns>
        public string ObtenerValorPorNombre(NombresParametrosGeneralesEnum nombre)
        {
            using (var contexto = new Contexto())
            {
                var parametroGeneral = contexto.ParametrosGenerales.FirstOrDefault(x => x.Nombre == nombre.ToString());

                if (parametroGeneral == null)
                {
                    return null;
                }

                return parametroGeneral.Valor;
            }
        }

        /// <summary>
        /// Este metodo actualiza el parametro general
        /// </summary>
        /// <param name="actualizarParametroGeneral">Parametro general a actualizar</param>
        /// <returns>Verdadero si se pudo actualizar</returns>
        public bool ActualizarParametroGeneral(ParametroGeneral actualizarParametroGeneral)
        {
            using (var contexto = new Contexto())
            {
                var obtenerParametroGeneral = contexto.ParametrosGenerales.
                    FirstOrDefault(x => x.ParametroGeneralId == actualizarParametroGeneral.ParametroGeneralId);

                obtenerParametroGeneral.Nombre = actualizarParametroGeneral.Nombre;
                obtenerParametroGeneral.Valor = actualizarParametroGeneral.Valor;

                contexto.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// Este metodo busca un parametro general por su Id
        /// </summary>
        /// <param name="parametroGeneralId">Id del parametro general</param>
        /// <returns>ParametroId, Nombre, valor y inactivo si el parametro se encuentra creado</returns>
        public ParametroGeneral ObtenerParametroGeneralxId(int parametroGeneralId)
        {
            ParametroGeneral parametroGeneral = null;

            using (var contexto = new Contexto())
            {
                EFParametroGeneral efParametroGeneral = (from p in contexto.ParametrosGenerales
                                                         where (p.ParametroGeneralId == parametroGeneralId)
                                                         select p).FirstOrDefault();

                parametroGeneral = this.mapper.Map<EFParametroGeneral, ParametroGeneral>(efParametroGeneral);
            }

            return parametroGeneral;
        }

        /// <summary>
        /// Este metodo busca un parametro geneal por su nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns>ParametroId, Nombre, valor y inactivo si el parametro se encuentra creado</returns>
        public ParametroGeneral ObtenerParametroGeneralxNombre(string nombre)
        {
            ParametroGeneral parametroGeneral = null;

            using (var contexto = new Contexto())
            {
                var efParametroGeneral = (from p in contexto.ParametrosGenerales
                                          where (p.Nombre == nombre)
                                          select p).FirstOrDefault();

                parametroGeneral = this.mapper.Map<EFParametroGeneral, ParametroGeneral>(efParametroGeneral);
            }

            return parametroGeneral;
        }

        /// <summary>
        /// Este método obtiene el número total de registros de la tabla de Parámetros Generales
        /// </summary>
        /// <returns>Número total de registros</returns>
        public int ObtenerNumeroTotalRegistros()
        {
            int numeroTotalRegistros = 0;

            using (var contexto = new Contexto())
            {
                numeroTotalRegistros = (from a in contexto.ParametrosGenerales
                                        select a).Count();
            }

            return numeroTotalRegistros;
        }

        /// <summary>
        /// Este método obtiene los prametros generales creados en el sistema
        /// </summary>
        /// <param name="desde">Indica el número de registro desde el cuál se deben cargar los registros</param>
        /// <param name="hasta">Indica el número de registro hasta el cuál se deben cargar los registros</param>
        /// <returns>Lista de parametros generales de tipo ParametroGeneral</returns>
        public List<ParametroGeneral> ObtenerTodosParametrosGenerales(int desde, int hasta)
        {
            List<ParametroGeneral> listaParametros = null;

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

                listaParametros = contexto.LoadSPAutoMapper<ParametroGeneral>("ObtenerTodosParametrosGenerales", parametros);
            }

            return listaParametros;
        }

        /// <summary>
        /// Este metodo activa / inactiva un parametro general
        /// </summary>
        /// <param name="parametroGeneralInactivar">Parametro a inactivar</param>
        /// <returns>Verdadero si se pudo activar / inactivar</returns>
        public bool ActivarParametroGeneral(ParametroGeneral parametroGeneralInactivar)
        {
            using (var contexto = new Contexto())
            {
                var EFParametroGeneralInactivar = (from p in contexto.ParametrosGenerales
                                                   where (p.ParametroGeneralId == parametroGeneralInactivar.ParametroGeneralId)
                                                   select p).FirstOrDefault();

                //Se debe asignar el valor del objeto de negocio inactivo, ya que desde la vista, se puede solicitar inactivar / reactivar el rol
                EFParametroGeneralInactivar.Activo = parametroGeneralInactivar.Activo;

                contexto.SaveChanges();

                return true;
            }
        }
        #endregion
    }
}