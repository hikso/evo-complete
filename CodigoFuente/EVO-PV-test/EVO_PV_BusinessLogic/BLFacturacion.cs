using System;
using System.Collections.Generic;
using System.Text;
using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Exceptions;
using EVO_PV_Proxy;
using NLog;

namespace EVO_PV_BusinessLogic
{
    public class BLFacturacion
    {
        #region Campos Privados

        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Métodos
        public List<OtraFormaPagoBO> ObtenerOtrasFormasPago()
        {
            logger.Info($"Entró al método ObtenerOtrasFormasPago en BLFacturacion - EVO_WebApi");

            FacturacionProxy facturacionProxy = new FacturacionProxy();

            List<OtraFormaPagoBO> otrasFormasPago = null;

            try
            {
                otrasFormasPago = facturacionProxy.ObtenerOtrasFormasPago();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return otrasFormasPago;
            
        }
        #endregion
    }
}
