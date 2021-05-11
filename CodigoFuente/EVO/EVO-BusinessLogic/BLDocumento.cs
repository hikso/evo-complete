using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
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
    /// Fecha de Creación: 2-Abr/2020
    /// Descripción      : Implementa la lógica de negocio de documento
    /// </summary>
    public class BLDocumento
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos
        /// <summary>
        /// Obtiene un documento por nombre
        /// </summary>
        /// <param name="documentosEnum">Indica el nombre del documento</param>
        /// <returns>BODocumento</returns>
        public BODocumento ObtenerDocumentoxNombre(DocumentosEnum documentosEnum)
        {
            logger.Info($"Entró al método ObtenerDocumentoxNombre en BLDocumento con el parámetro documento = {documentosEnum}");            

            DADocumento dADocumento = new DADocumento();

            BODocumento bODocumento = null;

            try
            {
                bODocumento = dADocumento.ObtenerDocumentoxNombre(documentosEnum);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (bODocumento == null)
            {
                EVOException e = new EVOException(errores.errDocumentoNoExiste);

                logger.Error(e);

                throw e;
            }

            return bODocumento;
        }

        /// <summary>
        /// Obtiene los documentos
        /// </summary>      
        /// <returns>List<BODocumento></returns>
        public List<BODocumento> ObtenerDocumentos()
        {
            logger.Info($"Entró al método ObtenerDocumentos en BLDocumento sin parámetros");

            DADocumento dADocumento = new DADocumento();

            List<BODocumento> bODocumentos = null;

            try
            {
                bODocumentos = dADocumento.ObtenerDocumentos();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (bODocumentos == null)
            {
                EVOException e = new EVOException(errores.errDocumentoNoExiste);

                logger.Error(e);

                throw e;
            }

            return bODocumentos;
        }
        #endregion
    }
}
