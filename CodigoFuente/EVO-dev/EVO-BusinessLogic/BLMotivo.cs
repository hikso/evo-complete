using EVO_BusinessObjects;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;

namespace EVO_BusinessLogic
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
            if (procesoId<=0)
            {
                EVOException e = new EVOException(errores.errProcesoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerMotivos en blMotivos con el parámetro procesoId = {procesoId}");

            DAMotivo daMotivos = new DAMotivo();

            List<MotivoRespuesta> motivos = new List<MotivoRespuesta>();

            try
            {
                motivos = daMotivos.ObtenerMotivos(procesoId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return motivos;
        }

        /// <summary>
        /// Valida el motivo por ID si existe o no 
        /// </summary>      
        /// <returns> Motivoespuesta</returns>
        public  MotivoRespuesta ObtenerMotivoxId(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errMotivoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerMotivoxId con el parámetro: id: {id}");

            
            DAMotivo dAMotivos = new DAMotivo();

            MotivoRespuesta motivo;

            try
            {
                motivo = dAMotivos.ObtenerMotivoxId(id);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (motivo == null)
            {
                EVOException e = new EVOException(errores.errMotivoNoExiste);

                logger.Error(e);

                throw e;
            }

            return motivo;
        }

    }
}
