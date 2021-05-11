using EFCoreExtensions.ExtensionMethods;
using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.DataAccess;
using EVO_DataAccess.Entities;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace EVO_DataAccess
{
    /// <summary>
    /// Autor            : Duban Cardona
    /// Fecha de Creación: 26-Ago/2019
    /// Descripción      : Acceso a datos de las sesiones
    /// </summary>
    public class DAAuntenticacion : DABase
    {
        #region Método Públicos
        /// <summary>
        /// Este método registra una session
        /// </summary>
        /// <param name="autenticarSolicitud">autenticarSolicitud</param>
        /// <returns>Retorna true si todo salio correcto, sino false</returns>
        public bool InsertarSesion(AutenticarSolicitud autenticarSolicitud)
        {
            EFSesion eFSesion = new EFSesion();

            if (autenticarSolicitud != null)
            {
                eFSesion = this.mapper.Map<AutenticarSolicitud, EFSesion>(autenticarSolicitud);
            }

            using (Contexto contexto = new Contexto())
            {
                contexto.Add(eFSesion);

                contexto.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// Este método obtiene un objeto de tipo sesion por su token de forma asíncrona.
        /// </summary>
        /// <param name="validarSesionSolicitud">Contiene el token y la ip</param>
        /// <returns>Retorna un objeto de tipo SesionSolicitud</returns>
        public SesionSolicitud ObtenerSesionPorToken(ValidarSesionSolicitud validarSesionSolicitud)
        {
            EFSesion eFSesion = null;

            SesionSolicitud sesionSolicitud = null;

            using (Contexto contexto = new Contexto())
            {
                eFSesion = contexto.Sesiones.FirstOrDefault(x => x.Token == validarSesionSolicitud.Token);
            }

            if (eFSesion != null)
            {
                sesionSolicitud = this.mapper.Map<EFSesion, SesionSolicitud>(eFSesion);
            }

            return sesionSolicitud;
        }

        /// <summary>
        /// Este método actualiza la sesion 
        /// </summary>
        /// <param name="sesion">Objeto de negocio de sesión</param>
        /// <returns>Retorna un true si todo es exitoso, de lo contrario false</returns>
        public bool ActualizarSesion(SesionSolicitud sesion)
        {
            EFSesion eFSesion = null;

            bool respuesta = false;

            using (Contexto contexto = new Contexto())
            {
                eFSesion = contexto.Sesiones.FirstOrDefault(e => e.SesionId == sesion.SesionId);

                if (eFSesion != null)
                {
                    eFSesion = this.mapper.Map<SesionSolicitud, EFSesion>(sesion);

                    contexto.Update(eFSesion);
                    
                    contexto.SaveChanges();
                    
                    respuesta = true;
                }
            }

            return respuesta;
        }

        /// <summary>
        /// Este método obtiene todos los registros de sesiones
        /// </summary>
        /// <param name="desde">Indica el nùmero de registro desde el cuàl se quiere obtener los registros de las sesiones</param>
        /// <param name="hasta">Indica el nùmero de registro hasta el cuàl se quiere obtener los registros de las sesiones</param>
        /// <returns>Retorna una Lista objetos de negocio de sesiones registradas</returns>
        public List<SesionRespuesta> ObtenerTodosRegistros(int desde, int hasta)
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

                List<SesionRespuesta> listaRegistrosSesiones = contexto.LoadSPCustomMapper<SesionRespuesta>("ObtenerTodosSesiones", dbParameters, mapeadorRegistrosSesiones);

                return listaRegistrosSesiones;
            }
        }

        /// <summary>
        /// Este método permite saber cuántos registros se generan de la consulta
        /// </summary>
        /// <returns>Número de registros</returns>
        public object ObtenerConteoTodosRegistros()
        {
            int nRegistros = 0;

            using (var contexto = new Contexto())
            {
                object result = contexto.LoadSPScalar("ObtenerConteoTodosSesiones");

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
        /// <returns>Número de registros por filtro</returns>
        public object ObtenerConteoTodosRegistrosxFiltro(FiltroSesion filtro)
        {
            int nRegistros = 0;

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

                if (!string.IsNullOrWhiteSpace(filtro.SesionId))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroSesionId",
                        Value = filtro.SesionId
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Usuario))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroUsuario",
                        Value = filtro.Usuario
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.ÏP))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroIP",
                        Value = filtro.ÏP
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Token))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroToken",
                        Value = filtro.Token
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.FechaInicio))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroFechaInicio",
                        Value = filtro.FechaInicio
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.FechaExpiracion))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroFechaExpiracion",
                        Value = filtro.FechaExpiracion
                    });
                }

                object result = contexto.LoadSPScalar("ObtenerConteoTodosRegistrosSesionesxFiltro", dbParameters);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene todos los registros de sesiones aplicando un filtro de búsqueda sobre las acciones
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda a aplicar sobre las acciones de la sesiones</param>
        /// <returns>Lista de objetos de negocio de SesionRespuesta</returns>
        public List<SesionRespuesta> ObtenerTodosRegistrosxFiltro(FiltroSesion filtro)
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

                if (!string.IsNullOrWhiteSpace(filtro.SesionId))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroSesionId",
                        Value = filtro.SesionId
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Usuario))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroUsuario",
                        Value = filtro.Usuario
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.ÏP))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroIP",
                        Value = filtro.ÏP
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Token))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroToken",
                        Value = filtro.Token
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.FechaInicio))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroFechaInicio",
                        Value = filtro.FechaInicio
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.FechaExpiracion))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroFechaExpiracion",
                        Value = filtro.FechaExpiracion
                    });
                }

                List<SesionRespuesta> sesionesRespuestas = contexto.LoadSPCustomMapper<SesionRespuesta>("ObtenerTodosSesionesxFiltro", dbParameters, mapeadorRegistrosSesiones);

                return sesionesRespuestas;
            }
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Mapea un objeto DbDataReader a un objeto de tipo RegistroAuditoria
        /// </summary>
        /// <param name="reader">DbDataReader</param>
        /// <returns>Instancia de objeto de tipo RegistroAuditoria</returns>
        private SesionRespuesta mapeadorRegistrosSesiones(DbDataReader reader)
        {
            SesionRespuesta s = null;

            if (reader != null)
            {
                s = new SesionRespuesta()
                {
                    SesionId = reader["SesionId"].ToString(),
                    FechaExpiracion = reader["FechaExpiracion"].ToString(),
                    FechaInicio = reader["FechaInicio"].ToString(),
                    IP = reader["IP"].ToString(),
                    Token = reader["Token"].ToString(),
                    Usuario = reader["Usuario"].ToString()
                };
            }

            return s;
        }

        #endregion
    }
}