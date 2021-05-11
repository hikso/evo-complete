using EVO_BusinessLogic;
using EVO_BusinessObjects.Exceptions;
using EVO_PV_BusinessObjects;
using EVO_PV_Proxy;
using NLog;
using System;
using System.Collections.Generic;

namespace EVO_PV_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 11-Feb/2020
    /// Descripción      : Esta clase implementa un motivo de alguna acción
    public class BLMotivo
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Obtiene una lista de motivos por un tipo de motivo
        /// </summary>        
        /// <param name="procesoId">Indica el id del proceso</param>   
        /// <returns>Lista de tipo MotivoRespuesta</returns>
        public List<MotivoRespuesta> ObtenerMotivos(int procesoId)
        {
            logger.Info($"Entró al método ObtenerMotivos en EVO_PV_WebApi - BLMotivo con el parámetro procesoId = {procesoId}");

            if (procesoId <= 0)
            {
                EVOException e = new EVOException(errores.errProcesoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerMotivos en blMotivos con el parámetro procesoId = {procesoId}");

            MotivosProxy motivosProxy = new MotivosProxy();

            List<MotivoRespuesta> motivos = new List<MotivoRespuesta>();

            try
            {
                motivos = motivosProxy.ObtenerMotivos(procesoId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return motivos;
        }       

    }
}
