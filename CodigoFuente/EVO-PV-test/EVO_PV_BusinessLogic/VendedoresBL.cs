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
    /// Fecha de Creación: 28-Abr/2020
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de Vendedores
    /// </summary>
    public class VendedoresBL
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos
        /// <summary>
        /// Obtiene los vendedores por punto de venta
        /// </summary>
        /// <response >List<VendedorResponseBO></response>
        public List<VendedorResponseBO> ObtenerVendedoresxPuntoVenta(string codigoPuntoVenta)
        {
            logger.Info($"Entró al método ObtenerVendedoresxPuntoVenta en VendedoresBL - EVO_PV_WebApi con el parámetro codigoPuntoVenta = {codigoPuntoVenta}");

            if (string.IsNullOrEmpty(codigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BodegaBL bodegaBL = new BodegaBL();

            Bodega puntaVenta = null;

            try
            {
                puntaVenta = bodegaBL.ObtenerBodegaPorCodigo(codigoPuntoVenta);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            VendedoresProxy vendedoresProxy = new VendedoresProxy();

            List<VendedorResponseBO> vendedoresBO = null;

            try
            {
                vendedoresBO = vendedoresProxy.ObtenerVendedoresxPuntoVenta(codigoPuntoVenta);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            return vendedoresBO;

        } 
        #endregion
    }
}
