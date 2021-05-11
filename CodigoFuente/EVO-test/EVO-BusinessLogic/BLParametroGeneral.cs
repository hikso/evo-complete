using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Kevin Restrepo Giraldo
    /// Fecha de Creación: 02-Ago/2019
    /// Descripción      : Esta clase contiene los métodos de Lógica de Negocios de los Parámetros Generales del sistema
    /// </summary>
    public class BLParametroGeneral
    {

        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion
        /// <summary>
        /// Este método crea un nuevo parametro General
        /// </summary>
        /// <param name="nuevoParametroGeneral">Nombre del nuevo parametro</param>
        /// <returns>El nuevo nombre del parametro</returns>
        public bool CrearParametroGeneral(ParametroGeneral nuevoParametroGeneral)
        {
            if (nuevoParametroGeneral == null)
            {
                EVOException e = new EVOException(errores.errParametroGeneralVacio);

                logger.Error(e);

                throw e;
            }
           
            logger.Info($"Entró al método CrearParametroGeneral con los parámetros : {JsonConvert.SerializeObject(nuevoParametroGeneral)}");

            if (string.IsNullOrEmpty(nuevoParametroGeneral.Nombre))
            {
                EVOException e = new EVOException(errores.errNombreParametroGeneral);

                logger.Error(e);

                throw e;
            }

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            int caracterMaximo = int.Parse(blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.MAXIMO_CARACTERES_NOMBRE_PARAMETRO_GENERAL));

            if (nuevoParametroGeneral.Nombre.Length > caracterMaximo)
            {
                EVOException e = new EVOException(errores.errCaracteresExcedidos);
            }

            nuevoParametroGeneral.Nombre = nuevoParametroGeneral.Nombre.ToUpper().Replace(' ', '_');

            if (string.IsNullOrEmpty(nuevoParametroGeneral.Valor))
            {
                EVOException e = new EVOException(errores.errValorParametroGeneral);
            }

            caracterMaximo = int.Parse(blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.MAXIMO_CARACTERES_VALOR_PARAMETRO_GENERAL));

            if (nuevoParametroGeneral.Valor.Length > caracterMaximo)
            {
                EVOException e = new EVOException(errores.errCaracteresExcedidos);
            }

            DAParametroGeneral daParametrosGenerales = new DAParametroGeneral();

            ParametroGeneral obtenerParametroGeneral = daParametrosGenerales.ObtenerParametroGeneralxNombre(nuevoParametroGeneral.Nombre);

            if (obtenerParametroGeneral != null)
            {
                EVOException e = new EVOException(errores.errNombreParametroGeneralYaExiste);
            }

            daParametrosGenerales.CrearParametroGeneral(nuevoParametroGeneral);

            return true;
        }

        /// <summary>
        /// Este método obtiene el valor de un parámetro general del sistema, dado su nombre
        /// </summary>
        /// <param name="nombre">Nombre del parámetro general</param>
        /// <returns>Valor solicitado</returns>
        public async Task<string> ObtenerValorPorNombreAsincrono(NombresParametrosGeneralesEnum nombre)
        {
            logger.Info($"Entró al método ObtenerValorPorNombreAsincrono con los parámetros: nombre : {nombre}");

            var daParametrosGenerales = new DAParametroGeneral();

            string valor = null;

            try
            {
                valor = await daParametrosGenerales.ObtenerValorPorNombreAsincrono(nombre);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrWhiteSpace(valor))
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralVacio, nombre));

                logger.Error(e);

                throw e;
            }

            return valor;
        }

        /// <summary>
        /// Este método obtiene el valor de un parámetro general del sistema, dado su nombre
        /// </summary>
        /// <param name="nombre">Nombre del parámetro general</param>
        /// <returns>Valor solicitado</returns>
        public string ObtenerValorPorNombre(NombresParametrosGeneralesEnum nombre)
        {
            logger.Info($"Entró al método ObtenerValorPorNombre con los parámetros: nombre : {nombre}");

            var daParametrosGenerales = new DAParametroGeneral();

            string valor = null;

            try
            {
                valor =  daParametrosGenerales.ObtenerValorPorNombre(nombre);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrWhiteSpace(valor))
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralVacio, nombre));

                logger.Error(e);

                throw e;
            }

            return valor;
        }

        /// <summary>
        /// Este método actualiza los parametros Generales
        /// </summary>
        /// <param name="actualizarParametroGeneral">Parametro a Actualizar</param>
        /// <returns>El parametro actualizado</returns>
        public bool ActualizarParametroGeneral(ParametroGeneral actualizarParametroGeneral)
        {
            if (actualizarParametroGeneral == null)
            {
                EVOException e = new EVOException(errores.errParametroGeneralVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ActualizarParametroGeneral con los parámetros: {JsonConvert.SerializeObject(actualizarParametroGeneral)}");

            if (string.IsNullOrEmpty(actualizarParametroGeneral.Nombre))
            {
                EVOException e = new EVOException(errores.errNombreParametroGeneral);
                logger.Error(e);
                throw e;
            }

            if (string.IsNullOrEmpty(actualizarParametroGeneral.Valor))
            {
                EVOException e = new EVOException(errores.errValorParametroGeneral);
                logger.Error(e);
                throw e;
            }

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            int caracterMaximo = int.Parse(blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.MAXIMO_CARACTERES_NOMBRE_PARAMETRO_GENERAL));

            if (actualizarParametroGeneral.Nombre.Length > caracterMaximo)
            {
                EVOException e = new EVOException(errores.errCaracteresExcedidos);
                logger.Error(e);
                throw e;
            }

            actualizarParametroGeneral.Nombre = actualizarParametroGeneral.Nombre.ToUpper().Replace(' ', '_');

            caracterMaximo = int.Parse(blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.MAXIMO_CARACTERES_VALOR_PARAMETRO_GENERAL));

            if (actualizarParametroGeneral.Valor.Length > caracterMaximo)
            {
                EVOException e = new EVOException(errores.errCaracteresExcedidos);
                logger.Error(e);
                throw e;
            }

            DAParametroGeneral daParametrosGenerales = new DAParametroGeneral();

            ParametroGeneral obtenerParametroGeneral = daParametrosGenerales.ObtenerParametroGeneralxId(actualizarParametroGeneral.ParametroGeneralId);

            if (obtenerParametroGeneral == null)
            {
                EVOException e = new EVOException(errores.errParametroGeneralNoExiste);

                logger.Error(e);

                throw e;
            }

            //Se debe válidar si se está intentando actualizar al nombre de otro parámetro general que ya existe en el sistema
                                  
            obtenerParametroGeneral = daParametrosGenerales.ObtenerParametroGeneralxNombre(actualizarParametroGeneral.Nombre);

            if (obtenerParametroGeneral != null)
            {
                if (obtenerParametroGeneral.ParametroGeneralId != actualizarParametroGeneral.ParametroGeneralId)
                {
                    EVOException e = new EVOException(errores.errNombreParametroGeneralYaExiste);

                    logger.Error(e);

                    throw e;
                }
            }

            daParametrosGenerales.ActualizarParametroGeneral(actualizarParametroGeneral);

            return true;
        }

        /// <summary>
        /// Este método activa el parametro
        /// </summary>
        /// <param name="parametroGeneralAActivar">Activa el parametro</param>
        /// <returns>El parametro activado</returns>
        public bool ActivarParametroGeneral(ParametroGeneral parametroGeneralAActivar)
        {
            if (parametroGeneralAActivar == null)
            {
                EVOException e = new EVOException(errores.errParametroGeneralVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ActivarParametroGeneral con los parámetros: {JsonConvert.SerializeObject(parametroGeneralAActivar)}");

            if (parametroGeneralAActivar.ParametroGeneralId <= 0)
            {
                EVOException e = new EVOException(errores.errParametroGeneralIdVacio);

                logger.Error(e);

                throw e;
            }

            DAParametroGeneral daParametrosGenerales = new DAParametroGeneral();

            var parametroGeneralEncontrado = daParametrosGenerales.ObtenerParametroGeneralxId(parametroGeneralAActivar.ParametroGeneralId);

            if (parametroGeneralEncontrado == null)
            {
                Exception e = new Exception(errores.errParametroGeneralNoExiste);

                logger.Error(e);

                throw e;
            }            

            return daParametrosGenerales.ActivarParametroGeneral(parametroGeneralAActivar);
        }

        /// <summary>
        /// Este método obtiene todos los parametros por el Id
        /// </summary>
        /// <param name="ParametroGeneralId">Parametro del Id</param>
        /// <returns>Id del parametro</returns>
        public ParametroGeneral ObtenerParametroGeneralxId(int ParametroGeneralId)
        {
            if (ParametroGeneralId <= 0)
            {
                EVOException e = new EVOException(errores.errIdNegativo);
                throw e;
            }

            logger.Info($"Entró al método ObtenerParametroGeneralxId con los parámetros: ParametroGeneralId : {ParametroGeneralId}");

            DAParametroGeneral daParametrosGenerales = new DAParametroGeneral();

            var parametroGeneralObtenido = daParametrosGenerales.ObtenerParametroGeneralxId(ParametroGeneralId);

            if (parametroGeneralObtenido == null)
            {
                EVOException e = new EVOException(errores.errParametroGeneralNoExiste);

                logger.Error(e);

                throw e;
            }

            ParametroGeneral parametroGeneral = daParametrosGenerales.ObtenerParametroGeneralxId(ParametroGeneralId);

            return parametroGeneral;
        }

        /// <summary>
        /// Este método obtiene los parametros por el nombre
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <returns>obtiene el nombre</returns>
        public ParametroGeneral ObtenerParametroGeneralxNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                EVOException e = new EVOException(errores.errNombreParametroGeneral);
                throw e;
            }

            logger.Info($"Entró al método ObtenerParametroGeneralxNombre con el parámetro: nombre : {nombre}");

            DAParametroGeneral daParametrosGenerales = new DAParametroGeneral();

            ParametroGeneral parametroGeneral = daParametrosGenerales.ObtenerParametroGeneralxNombre(nombre);

            if (parametroGeneral == null)
            {
                EVOException e = new EVOException(errores.errParametroGeneralNoExiste);

                logger.Error(e);

                throw e;
            }

            if (nombre.Equals("EXPRESION_REGULAR_ENTERO_DECIMAL"))
            {
                ParametroGeneral maximoDecimales = daParametrosGenerales.ObtenerParametroGeneralxNombre("MAXIMO_DECIMALES");

                if (maximoDecimales == null)
                {
                    EVOException e = new EVOException(errores.errParametroGeneralNoExiste);

                    logger.Error(e);

                    throw e;
                }

                parametroGeneral.Valor = parametroGeneral.Valor.Replace("?", maximoDecimales.Valor);

                ParametroGeneral minimoDecimales = daParametrosGenerales.ObtenerParametroGeneralxNombre("MINIMO_DECIMALES");

                if (minimoDecimales == null)
                {
                    EVOException e = new EVOException(errores.errParametroGeneralNoExiste);

                    logger.Error(e);

                    throw e;
                }

                parametroGeneral.Valor = parametroGeneral.Valor.Replace("#", minimoDecimales.Valor);

            }

            return parametroGeneral;
        }

        /// <summary>
        /// Este método obtiene el número total de registros
        /// </summary>
        /// <returns>El número total de registros</returns>
        public int ObtenerNumeroTotalRegistros()
        {
            logger.Info($"Entró al método ObtenerNumeroTotalRegistros de BLParámetrosGenerales sin parámetros");

            var daParametrosGenerales = new DAParametroGeneral();

            int numeroTotalRegistros = 0;

            try
            {
                numeroTotalRegistros = daParametrosGenerales.ObtenerNumeroTotalRegistros();
            }
            catch
            {
                Exception e = new Exception(errores.errObtenerTotalRegistros);

                throw e;
            }
            return numeroTotalRegistros;
        }

        /// <summary>
        /// Este método obtiene los valores ingresados desde n hasta n registros
        /// </summary>
        /// <param name="desde">Valor desde</param>
        /// <param name="hasta">Valor hasta</param>
        /// <returns>Los registros ingresados desde n hasta n solicitados</returns>
        public List<ParametroGeneral> ObtenerTodosParametrosGenerales(int desde, int hasta)
        {
            if (desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);
                throw e;
            }

            if (hasta < desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);
                throw e;
            }

            logger.Info($"Entró al método ObtenerTodosParametrosGenerales con los parámetros : desde = {desde} , hasta = {hasta}");

            DAParametroGeneral daParametrosGenerales = new DAParametroGeneral();

            //Se valida que no se estén pidiendo más registros que los que se encuentren actualmente configurados en la tabla de parámetros generales
            string valorPaginacion = null;

            try
            {
                valorPaginacion = ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch
            {
                Exception e = new Exception(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI.ToString()));
                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((hasta - desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));
                throw e;
            }

            List<ParametroGeneral> parametrosGenerales = null;

            try
            {
                parametrosGenerales = daParametrosGenerales.ObtenerTodosParametrosGenerales(desde, hasta);
            }
            catch (Exception e)
            {
                throw e;
            }
            return parametrosGenerales;
        }
    }
}