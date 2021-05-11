using EVO_BusinessObjects;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using NLog;
using System;
using System.Collections.Generic;

namespace EVO_BusinessLogic
{
    public class BLSocioNegocio
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos
        /// <summary>
        /// Obtiene los socios de negocio 
        /// </summary>      
        /// <response>List<BOSocioNegocioResponse></response>
        public List<BOSocioNegocioResponse> ObtenerSociosNegocio()
        {
            logger.Info("Entró al método ObtenerSociosNegocio en BLSocioNegocio sin parámetros");           

            DASocioNegocio dASocioNegocio = new DASocioNegocio();

            List<BOSocioNegocioResponse> bOSociosNegocioResponse = null;

            try
            {
                bOSociosNegocioResponse = dASocioNegocio.ObtenerSociosNegocio();
            }
            catch (Exception e)
            {
                throw e;
            }

            return bOSociosNegocioResponse;
        }

        /// <summary>
        /// Obtiene los socios de negocio por identificacion o nombre
        /// </summary>
        /// <param name="identificacion">Indica la identificación</param>
        /// <param name="nombre">Indica el nombre</param>
        /// <response>List<BOSocioNegocioResponse></response>
        public List<BOSocioNegocioResponse> ObtenerSociosNegocioxFiltro(string identificacion, string nombre)
        {
            logger.Info($"Entró al método ObtenerSociosNegocioxFiltro en BLSocioNegocio con los parámetros identificacion = {identificacion},nombre = {nombre}");

            if (string.IsNullOrEmpty(identificacion) && string.IsNullOrEmpty(nombre))
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            DASocioNegocio dASocioNegocio = new DASocioNegocio();

            List<BOSocioNegocioResponse> bOSociosNegocioResponse = null;

            try
            {
                bOSociosNegocioResponse = dASocioNegocio.ObtenerSociosNegocioxFiltro(identificacion,nombre);
            }
            catch (Exception e)
            {
                throw e;
            }

            return bOSociosNegocioResponse;

        }

        /// <summary>
        /// Obtiene socio de negocio por identificación
        /// </summary>    
        /// <param name="identificacion">Indica la identificación</param>
        /// <response>BOSocioNegocio</response>
        public BOSocioNegocio ObtenerSocioNegocio(string identificacion)
        {
            logger.Info($"Entró al método ObtenerSocioNegocio en BLSocioNegocio - EVO-WebApi con el parámetro identificacion = {identificacion}");

            if (string.IsNullOrEmpty(identificacion))
            {
                EVOException e = new EVOException(errores.errIdentificacionNoInformada);

                logger.Error(e);

                throw e;
            }

            DASocioNegocio dASocioNegocio = new DASocioNegocio();

            BOSocioNegocio bOSocioNegocio = null;

            try
            {
                bOSocioNegocio = dASocioNegocio.ObtenerSocioNegocio(identificacion);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOSocioNegocio==null)
            {
                EVOException e = new EVOException(errores.errSocioNegocioNoRegistrado);

                logger.Error(e);

                throw e;
            }

            if (!bOSocioNegocio.Activo)
            {
                EVOException e = new EVOException(errores.errSocioNegocioInactivo);

                logger.Error(e);

                throw e;
            }

            return bOSocioNegocio;
        }
        #endregion
    }
}
