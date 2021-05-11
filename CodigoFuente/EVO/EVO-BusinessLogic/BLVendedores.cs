using EVO_BusinessObjects;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessLogic
{
    public class BLVendedores
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos
        /// <summary>
        /// Obtiene vendedor por id
        /// </summary>    
        /// <param name="id">Indica el id del vendedor</param>
        /// <response>BOVendedorResponse</response>
        public BOVendedorResponse ObtenerVendedor(int id)
        {
            logger.Info($"Entró al método ObtenerVendedor en BLVendedores - EVO-WebApi con el parámetro id = {id}");

            if (id<=0)
            {
                EVOException e = new EVOException(errores.errVendedorIdNoInformado);

                logger.Error(e);

                throw e;
            }

            DAVendedores dAVendedores = new DAVendedores();

            BOVendedorResponse bOVendedorResponse = null;

            try
            {
                bOVendedorResponse = dAVendedores.ObtenerVendedor(id);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOVendedorResponse == null)
            {
                EVOException e = new EVOException(errores.errVendedorNoRegistrado);

                logger.Error(e);

                throw e;
            }

            if (!bOVendedorResponse.Activo)
            {
                EVOException e = new EVOException(errores.errVendedorNoActivo);

                logger.Error(e);

                throw e;
            }

            return bOVendedorResponse;
        }


        /// <summary>
        /// Obtiene los vendedores por punto de venta
        /// </summary>
        /// <response>List<BOVendedorResponse></response>
        public List<BOVendedorResponse> ObtenerVendedoresxPuntoVenta(string codigoPuntoVenta)
        {
            logger.Info($"Entró al método ObtenerVendedoresxPuntoVenta en BLVendedores - EVO_WebApi con el parámetro codigoPuntoVenta = {codigoPuntoVenta}");

            if (string.IsNullOrEmpty(codigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();

            BOBodega puntaVenta = null;

            try
            {
                puntaVenta = bLBodega.ObtenerBodegaPorCodigo(codigoPuntoVenta);
            }
            catch (EVOException e)
            {
                logger.Error(e);
                throw e;
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            DAVendedores dAVendedores = new DAVendedores();

            List<BOVendedorResponse> bOVendedoresResponse = null;

            try
            {
                bOVendedoresResponse = dAVendedores.ObtenerVendedoresxPuntoVenta(codigoPuntoVenta);
            }           
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            return bOVendedoresResponse;

        }
        #endregion
    }
}
