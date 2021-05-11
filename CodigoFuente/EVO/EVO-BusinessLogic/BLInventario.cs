using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 15-May/2020
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de Inventario
    /// </summary>
    public class BLInventario
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos
        /// <summary>
        /// Asigna la entrada de los artículos en recepción al inventario del punto de venta
        /// </summary>
        /// <param name="pesajesArticulosIds">Ids de los artículos ya pesado en recepción</param>       
        /// <response>bool</response>
        public bool AsignarEntradaRecepcion(List<int> pesajesArticulosIds)
        {
            if (pesajesArticulosIds == null)
            {
                EVOException e = new EVOException(errores.errPesajeArticuloIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método EntradaRecepcion en BLInventario - EVO_WebApi con el parametro pesajesArticulosIds = {JsonConvert.SerializeObject(pesajesArticulosIds)}");

            if (pesajesArticulosIds.Count == 0)
            {
                EVOException e = new EVOException(errores.errPesajesArticulosIdsSinIds);

                logger.Error(e);

                throw e;
            }

            if (pesajesArticulosIds.Where(x => x <= 0).Count() > 0)
            {
                EVOException e = new EVOException(errores.errPesajesArticulosIdsNoInformados);

                logger.Error(e);

                throw e;
            }

            TipoInventarioBO tipoInventarioBO = ObtenerTipoInventarioxNombre(TiposInventarioEnum.Entrada);

            DAProcesos dAProcesos = new DAProcesos();

            ProcesoBO procesoBO = dAProcesos.ObtenerProcesoxNombre(ProcesosEnum.Recepción);

            List<InventarioBO> inventarios = pesajesArticulosIds.Select(paId=>new InventarioBO()
            {
                 TipoInventarioId= tipoInventarioBO.TipoInventarioId,
                 ProcesoId=procesoBO.ProcesoId,
                 PesajeArticuloId=paId,
                 FechaRegistro=DateTime.Now
            }).ToList();

            DAInventario dAInventario = new DAInventario();

            try
            {
                dAInventario.Asignar(inventarios);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }           

            return true;

        }

        /// <summary>
        /// Asigna la salida de cantidad de los artículos en facturación en el inventario del punto de venta
        /// </summary>
        /// <param name="detallesFacturaIds">Ids de los detalles de factura</param>       
        /// <response>bool</response>
        public bool AsignarSalidaFacturacion(List<int> detallesFacturaIds)
        {
            if (detallesFacturaIds == null)
            {
                EVOException e = new EVOException(errores.errDetallesFacturaIdsNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método AsignarSalidaFacturacion en BLInventario - EVO_WebApi con el parametro detallesFacturaIds = {JsonConvert.SerializeObject(detallesFacturaIds)}");

            if (detallesFacturaIds.Count == 0)
            {
                EVOException e = new EVOException(errores.errPesajesArticulosIdsSinIds);

                logger.Error(e);

                throw e;
            }

            if (detallesFacturaIds.Where(x => x <= 0).Count() > 0)
            {
                EVOException e = new EVOException(errores.errPesajesArticulosIdsNoInformados);

                logger.Error(e);

                throw e;
            }

            TipoInventarioBO tipoInventarioBO = ObtenerTipoInventarioxNombre(TiposInventarioEnum.Salida);

            DAProcesos dAProcesos = new DAProcesos();

            ProcesoBO procesoBO = dAProcesos.ObtenerProcesoxNombre(ProcesosEnum.Facturación);

            List<InventarioBO> inventarios = detallesFacturaIds.Select(dfId => new InventarioBO()
            {
                TipoInventarioId = tipoInventarioBO.TipoInventarioId,
                ProcesoId = procesoBO.ProcesoId,
                PesajeArticuloId = dfId,
                FechaRegistro = DateTime.Now
            }).ToList();

            DAInventario dAInventario = new DAInventario();

            try
            {
                dAInventario.Asignar(inventarios);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            return true;

        }

        /// <summary>
        /// Obtiene el tipo de inventario por nombre
        /// </summary>
        /// <param name="tipoInventarioEnum">Enumerador del tipo de inventario</param>       
        /// <response>TipoInventarioBO</response>
        public TipoInventarioBO ObtenerTipoInventarioxNombre(TiposInventarioEnum tipoInventarioEnum)
        {
            logger.Info($"Entró al método ObtenerTipoInventarioxNombre en BLInventario - EVO_WebApi con el parametro tipoInventarioEnum = {tipoInventarioEnum.ToString()}");

            DAInventario dAInventario = new DAInventario();

            TipoInventarioBO tipoInventarioBO = null;

            try
            {
                tipoInventarioBO = dAInventario.ObtenerTipoInventarioxNombre(tipoInventarioEnum);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (tipoInventarioBO == null)
            {
                EVOException e = new EVOException(errores.errTipoInventarioNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return tipoInventarioBO;

        }
        #endregion
    }
}
