using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EVO_BusinessLogic
{
    public class BLAutenticacion
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public object HttpContext { get; private set; }
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Este método auténtica un usuario
        /// </summary>
        /// <param name="autenticarSolicitud">Indica la petición de solicitud que contiene el usuario y el dominio</param>       
        /// <returns>Una instancia de AutenticarRespuesta</returns>
        public AutenticarRespuesta Autenticar(AutenticarSolicitud autenticarSolicitud)
        {
            if (autenticarSolicitud == null)
            {
                EVOException e = new EVOException(errores.errAutenticacionSolicitudVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método Autenticar con los parámetros: {0}",
               JsonConvert.SerializeObject(autenticarSolicitud)));

            if (string.IsNullOrEmpty(autenticarSolicitud.Usuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            int nBackSlash = autenticarSolicitud.Usuario.IndexOf(@"\");

            if (nBackSlash == -1)
            {
                EVOException e = new EVOException(errores.errDominioNoInformado);

                logger.Error(e);

                throw e;
            }

            autenticarSolicitud.Dominio = autenticarSolicitud.Usuario.Substring(0, autenticarSolicitud.Usuario.IndexOf(@"\")).ToUpper();
            autenticarSolicitud.Usuario = autenticarSolicitud.Usuario.Substring(nBackSlash + 1, autenticarSolicitud.Usuario.Length - nBackSlash - 1);

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string nombreDominio = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.NOMBRE_DOMINIO);

            if (string.IsNullOrWhiteSpace(nombreDominio))
            {
                EVOException e = new EVOException(errores.errDominioNoInformado);

                logger.Error(e);

                throw e;
            }

            AutenticarRespuesta autenticarRespuesta = new AutenticarRespuesta();

            if (nombreDominio != autenticarSolicitud.Dominio)
            {
                autenticarRespuesta.estaAutenticado = false;

                return autenticarRespuesta;
            }

            BLUsuario bLUsuarios = new BLUsuario();
            Usuario usuarioEncontrar = bLUsuarios.ObtenerUsuarioPorUsuario(autenticarSolicitud.Usuario);

            if (usuarioEncontrar == null)
            {
                EVOException e = new EVOException(errores.errUsuarioNoExiste);
                logger.Error(e);
                throw e;
            }

            autenticarSolicitud.UsuarioId = usuarioEncontrar.UsuarioId;

            bool estaAutenticado =
                autenticarSolicitud.Dominio == nombreDominio &&
                autenticarSolicitud.Usuario == usuarioEncontrar.NombreUsuario;

            autenticarRespuesta.estaAutenticado = estaAutenticado;

            if (!estaAutenticado)
            {
                return autenticarRespuesta;
            }

            autenticarSolicitud.Token = Guid.NewGuid().ToString();
            autenticarSolicitud.FechaInicio = DateTime.Now;

            int minutosExpiracion = 0;

            try
            {
                minutosExpiracion = int.Parse(blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TIEMPO_EXPIRACION_SESION));
            }
            catch (EVOException e)
            {
                logger.Error(e);

                throw e;
            }

            autenticarSolicitud.FechaExpiracion = autenticarSolicitud.FechaInicio.AddMinutes(minutosExpiracion);

            DAAuntenticacion daAuntenticacion = new DAAuntenticacion();

            daAuntenticacion.InsertarSesion(autenticarSolicitud);

            autenticarRespuesta.Token = autenticarSolicitud.Token;
            autenticarRespuesta.FechaExpiracion = autenticarSolicitud.FechaExpiracion;

            return autenticarRespuesta;

        }

        /// <summary>
        /// Este método válida la sesión 
        /// </summary>
        /// <param name="validarSesionSolicitud">Contiene el token y la IP</param>       
        /// <returns>Una instancia de ValidarSesionRespuesta</returns>
        public ValidarSesionRespuesta ValidarSesion(ValidarSesionSolicitud validarSesionSolicitud)
        {
            if (validarSesionSolicitud == null)
            {
                EVOException e = new EVOException(errores.errValidarSolicitudVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ValidarSesion con los parámetros: {0}",
              JsonConvert.SerializeObject(validarSesionSolicitud)));

            if (string.IsNullOrEmpty(validarSesionSolicitud.Token))
            {
                EVOException e = new EVOException(errores.errTokenNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(validarSesionSolicitud.IP))
            {
                EVOException e = new EVOException(errores.errIPNoInformada);

                logger.Error(e);

                throw e;
            }

            //Se valida que la IP sea válida
            string IPPattern = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";

            Match regIPMatch = Regex.Match(validarSesionSolicitud.IP, IPPattern);

            if (!regIPMatch.Success)
            {
                EVOException e = new EVOException(errores.errIPFormatoIncorrecto);

                logger.Error(e);

                throw e;
            }

            DAAuntenticacion dAAuntenticacion = new DAAuntenticacion();

            SesionSolicitud sesionEncontrada = dAAuntenticacion.ObtenerSesionPorToken(validarSesionSolicitud);

            if (sesionEncontrada == null)
            {
                EVOException e = new EVOException(errores.errSesionNoExiste);

                logger.Error(e);

                throw e;
            }

            bool esValida = validarSesionSolicitud.IP == sesionEncontrada.IP &&
                 sesionEncontrada.FechaExpiracion > DateTime.Now;

            ValidarSesionRespuesta validarSesionRespuesta = new ValidarSesionRespuesta()
            {
                sesionValida = esValida
            };

            if (!esValida)
            {
                return validarSesionRespuesta;
            }

            int minutosActualizarExpiracion = 0;

            BLParametroGeneral bLParametrosGenerales = new BLParametroGeneral();

            try
            {
                minutosActualizarExpiracion = int.Parse(bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.VENTANA_ACTUALIZACION_SESION));
            }
            catch (EVOException e)
            {
                logger.Error(e);

                throw e;
            }

            validarSesionRespuesta.FechaExpiracion = DateTime.Now.AddMinutes(minutosActualizarExpiracion);

            sesionEncontrada.FechaExpiracion = validarSesionRespuesta.FechaExpiracion;

            dAAuntenticacion.ActualizarSesion(sesionEncontrada);

            return validarSesionRespuesta;

        }

        /// <summary>
        /// Este método permite saber cuántos registros se generan a partir de los filtros generados para la consulta
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda a aplicar sobre las acciones de sesiones</param>
        /// <returns>Entero - representa total de registros con base al filtro</returns>
        public int ObtenerConteoTodosRegistrosxFiltro(FiltroSesion filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerConteoTodosRegistrosxFiltro con los parámetros: {0}",
             JsonConvert.SerializeObject(filtro)));

            DAAuntenticacion dAAuntenticacion = new DAAuntenticacion();

            if (string.IsNullOrWhiteSpace(filtro.Usuario) &&
               string.IsNullOrWhiteSpace(filtro.FechaExpiracion) &&
               string.IsNullOrWhiteSpace(filtro.FechaInicio) &&
               string.IsNullOrWhiteSpace(filtro.Token) &&
               string.IsNullOrWhiteSpace(filtro.SesionId) &&
               string.IsNullOrWhiteSpace(filtro.ÏP))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            int nRegistros = 0;

            try
            {
                object result = dAAuntenticacion.ObtenerConteoTodosRegistrosxFiltro(filtro);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene todos las sesiones aplicando un filtro de búsqueda sobre las acciones
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda a aplicar sobre las acciones de sesiones</param>
        /// <returns>Lista de objetos de negocio de sesiones</returns>
        public List<SesionRespuesta> ObtenerTodosRegistrosxFiltro(FiltroSesion filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosRegistrosxFiltro con los parámetros: {0}",
              JsonConvert.SerializeObject(filtro)));

            if (filtro.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtro.Hasta < filtro.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            DAAuntenticacion dAAuntenticacion = new DAAuntenticacion();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            //Se valida que no se estén pidiendo más registros que los que se encuentren actualmente configurados en la tabla de parámetros generales
            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((filtro.Hasta - filtro.Desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrWhiteSpace(filtro.Usuario) &&
                string.IsNullOrWhiteSpace(filtro.SesionId) &&
                string.IsNullOrWhiteSpace(filtro.FechaExpiracion) &&
                string.IsNullOrWhiteSpace(filtro.FechaInicio) &&
                string.IsNullOrWhiteSpace(filtro.Token) &&
                string.IsNullOrWhiteSpace(filtro.ÏP))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            string FechaPattern = @"^([0]?[0-9]|[1][0-2])[.\/-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[.\/-]([0-9]{4}|[0-9]{2})$";

            if (!string.IsNullOrEmpty(filtro.FechaInicio))
            {

                Match regFechaMatch = Regex.Match(filtro.FechaInicio, FechaPattern);

                if (!regFechaMatch.Success)
                {
                    filtro.FechaInicio = filtro.FechaInicio.Replace("-", "/");
                }
            }

            if (!string.IsNullOrEmpty(filtro.FechaExpiracion))
            {
                Match regFechaMatch = Regex.Match(filtro.FechaExpiracion, FechaPattern);

                if (!regFechaMatch.Success)
                {
                    filtro.FechaExpiracion = filtro.FechaExpiracion.Replace("-", "/");
                }
            }

            List<SesionRespuesta> sesionesRespuestas = null;

            try
            {
                sesionesRespuestas = dAAuntenticacion.ObtenerTodosRegistrosxFiltro(filtro);

                if (sesionesRespuestas == null)
                {
                    sesionesRespuestas = new List<SesionRespuesta>();
                }

                foreach (SesionRespuesta sesionRespuesta in sesionesRespuestas)
                {
                    DateTime fechaExpiracion = DateTime.Parse(sesionRespuesta.FechaExpiracion);

                    if (fechaExpiracion > DateTime.Now)
                    {
                        sesionRespuesta.Activa = true;
                    }
                }

            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return sesionesRespuestas;
        }

        /// <summary>
        /// Este método permite saber cuántos registros se generan a partir de la consulta
        /// </summary>
        /// <returns>Registros de Sesiones</returns>
        public int ObtenerConteoTodosRegistros()
        {
            logger.Info(string.Format("Entró al método ObtenerConteoTodosRegistros de BLAutenticación"));

            DAAuntenticacion dAAuntenticacion = new DAAuntenticacion();

            int nRegistros = 0;

            try
            {
                object result = dAAuntenticacion.ObtenerConteoTodosRegistros();

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene todos los registros de las sesiones
        /// </summary>
        /// <param name="desde">Indica el número de registro desde el cuál se desea cargar los registros de las sesiones</param>
        /// <param name="hasta">Indica el número de registro hasta el cuál se desea cargar los registros de las sesiones</param>
        /// <returns>Lista de Registros de Sesiones</returns>
        public List<SesionRespuesta> ObtenerTodosRegistros(int desde, int hasta)
        {
            if (desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (hasta < desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosRegistros de BLAutenticación con los parámetros: desde: {0}, hasta: {1}", desde, hasta));

            DAAuntenticacion dAAuntenticacion = new DAAuntenticacion();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            //Se valida que no se estén pidiendo más registros que los que se encuentren actualmente configurados en la tabla de parámetros generales
            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception)
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, "TAMANHO_PAGINACION_WEBAPI"));

                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((hasta - desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            List<SesionRespuesta> registrosSesiones = null;

            try
            {
                registrosSesiones = dAAuntenticacion.ObtenerTodosRegistros(desde, hasta);

                if (registrosSesiones == null)
                {
                    registrosSesiones = new List<SesionRespuesta>();
                }

                foreach (SesionRespuesta registroSesione in registrosSesiones)
                {
                    DateTime fechaExpiracion = DateTime.Parse(registroSesione.FechaExpiracion);

                    if (fechaExpiracion > DateTime.Now)
                    {
                        registroSesione.Activa = true;
                    }
                }
            }

            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return registrosSesiones;
        }

        #endregion
    }
}
