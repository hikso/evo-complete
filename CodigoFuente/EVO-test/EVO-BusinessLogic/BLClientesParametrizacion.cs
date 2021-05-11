using EVO_BusinessObjects;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using NLog;
using System;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 11-Abr/2020
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de Parametrización de clientes
    /// </summary>
    public class BLClientesParametrizacion
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Obtiene las parametrizaciones del cliente
        /// </summary>
        /// <param name="codigoCliente">Indica el código del cliente</param>
        /// <response>BOParametrizacionResponse</response>
        public BOParametrizacionResponse ObtenerPatrametrizacionesxCliente(string codigoCliente)
        {
            logger.Info($"Entró al método ObtenerEncabezadoRecepcion en BLClientesParametrizacion con el parámetro codigoCliente = {codigoCliente}");

            if (string.IsNullOrEmpty(codigoCliente))
            {
                EVOException e = new EVOException(errores.errCodigoClienteNoInformado);

                logger.Error(e);

                throw e;
            }

            DAClientesParametrizacion dAClientesParametrizacion = new DAClientesParametrizacion();

            BOParametrizacionResponse bOParametrizacionResponse = null;

            try
            {
                bOParametrizacionResponse = dAClientesParametrizacion.ObtenerPatrametrizacionesxCliente(codigoCliente);
            }
            catch (Exception e)
            {
                throw e;
            }

            //if (bOParametrizacionResponse==null)
            //{
            //    EVOException e = new EVOException(errores.errClientesParametrizacionNoRegistrado);

            //    logger.Error(e);

            //    throw e;
            //}

            return bOParametrizacionResponse;

        }
    }
}
