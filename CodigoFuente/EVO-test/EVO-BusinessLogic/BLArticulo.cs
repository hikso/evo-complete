using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using EVO_Proxy;
using EVO_PV_BusinessObjects.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 21-Sep/2019
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio del Artículo
    /// </summary>
    public class BLArticulo
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos Públicos  

        /// <summary>
        /// Obtiene las ordenes de compra generadas en SAP
        /// </summary>      
        /// <response>bool</response>
        public async Task<bool> ObtenerOrdenesCompraSAP()
        {
            logger.Info($"Entró al método ObtenerOrdenesCompraSAP en EVO - BLPedidos sin parámetros");

            ArticuloProxy articuloProxy = new ArticuloProxy();                       

            List<BOGestionCompra> gestionesCompras = null;

            BLPedido bLPedido = new BLPedido();

            List<string> documentos = null;

            try
            {
                documentos = await bLPedido.ObtenerDocumentosPendientesOrdenesSAP();

                logger.Info($"Salió del método ObtenerArticuloxBodegaSAP en EVO - BLPedidos con respuesta {JsonConvert.SerializeObject(gestionesCompras)}");

                foreach (var documento in documentos)
                {
                    gestionesCompras = await articuloProxy.ObtenerOrdenesCompraSAP(documento);

                    if (gestionesCompras!=null && gestionesCompras.Count()>0)
                    {
                        await bLPedido.AsignarOrdenesCompraxDocumento(documento, gestionesCompras);
                    }

                }
                
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;
        }

        /// <summary>
        /// Obtiene los artículos de SAP
        /// </summary>
        /// <param name="codigoArticulo">Código del artículo</param>
        /// <param name="codigoBodega">Código de la bodega</param>
        /// <response>BOArticuloBodegaSAP</response>
        public BOArticuloBodegaSAP ObtenerArticuloxBodegaSAP(string codigoArticulo, string codigoBodega)
        {
            logger.Info($"Entró al método ObtenerArticuloxBodegaSAP en EVO-WebApi - BLPedidos con los parámetros codigoArticulo = {codigoArticulo}, codigoBodega = {codigoBodega}");

            ArticuloProxy articuloProxy = new ArticuloProxy();           

            if (string.IsNullOrEmpty(codigoArticulo))
            {
                EVOException e = new EVOException(errores.errCodigoArticuloNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(codigoBodega))
            {
                EVOException e = new EVOException(errores.errCodigoNoInformado);

                logger.Error(e);

                throw e;
            }

            BOArticuloBodegaSAP bOArticuloBodegaSAP = null;

            try
            {              

                bOArticuloBodegaSAP = articuloProxy.ObtenerArticuloxBodegaSAP(codigoArticulo, codigoBodega);

                logger.Info($"Salió del método ObtenerArticuloxBodegaSAP en EVO-WebApi - BLPedidos con respuesta bOArticuloBodegaSAP = {JsonConvert.SerializeObject(bOArticuloBodegaSAP)}");
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return bOArticuloBodegaSAP;
        }

       

        /// <summary>
        /// Gestiona la finalización de la compra de los artículos
        /// </summary>
        /// <param name="body">Solicitud para la actualización compra de los artículos</param>
        /// <response>bool</response>
        public bool FinalizarCompra(BOActualizarCompraRequest actualizarCompraRequest)
        {
            if (actualizarCompraRequest == null)
            {
                EVOException e = new EVOException(errores.errActualizarCompraRequestNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método FinalizarCompra en EVO-WebApi con los parámetros {0}",
                JsonConvert.SerializeObject(actualizarCompraRequest)));

            if (actualizarCompraRequest.PedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BLPedido bLPedido = new BLPedido();

            BOPedidoCompraGestionResponse pedido = bLPedido.ObtenerPedidoCompraGestion(actualizarCompraRequest.PedidoId);

            if (actualizarCompraRequest.ArticulosActualizarCompra == null || actualizarCompraRequest.ArticulosActualizarCompra.Count == 0)
            {
                EVOException e = new EVOException(errores.errArticulosNoInformados);

                logger.Error(e);

                throw e;
            }

            List<BOGestionCompra> compras = new List<BOGestionCompra>();

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            bool conOrdenes = bool.Parse(bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.GUARDAR_GESTION_COMPRA_CON_ORDENES));

            foreach (var articulo in actualizarCompraRequest.ArticulosActualizarCompra)
            {
                if (articulo.AccionId <= 0)
                {
                    EVOException e = new EVOException(errores.errAccionIdNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (articulo.DetallePedidoId < 0)
                {
                    EVOException e = new EVOException(errores.errDetallePedidoIdNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (string.IsNullOrEmpty(articulo.CantidadGestionar))
                {
                    EVOException e = new EVOException(errores.errCantidadGestionarNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (actualizarCompraRequest.ArticulosActualizarCompra
                    .Where(a => a.DetallePedidoId == articulo.DetallePedidoId && a.AccionId == articulo.AccionId).Count() >= 2)
                {
                    EVOException e = new EVOException(errores.errArticulosMasVecesEnAccion);

                    logger.Error(e);

                    throw e;
                }

                BOGestionCompra bOGestionCompra = bLPedido.ObtenerGestionCompra(articulo.DetallePedidoId, articulo.AccionId, false);

                if (bOGestionCompra != null)
                {
                    bOGestionCompra.Cantidad = decimal.Parse(articulo.CantidadGestionar);
                    bOGestionCompra.Actualizar = true;
                }
                else
                {
                    bOGestionCompra = new BOGestionCompra()
                    {
                        Cantidad = decimal.Parse(articulo.CantidadGestionar),
                        AccionId = articulo.AccionId,
                        DetallePedidoId = articulo.DetallePedidoId,
                        Nuevo = true
                    };
                }

                if (conOrdenes && bOGestionCompra.Nuevo)
                {
                    EVOException e = new EVOException(errores.errDebeGuardarPedido);

                    logger.Error(e);

                    throw e;
                }

                bOGestionCompra.Cantidad = decimal.Parse(articulo.CantidadGestionar);

                compras.Add(bOGestionCompra);

            }

            foreach (var DetallePedidoId in compras.Select(c => c.DetallePedidoId).Distinct())
            {
                decimal cantidadGestionada = compras.Where(c => c.DetallePedidoId == DetallePedidoId).Select(a => a.Cantidad).Sum();
                decimal cantidadSolicitada = decimal.Parse(pedido.Articulos.FirstOrDefault(a => a.DetallePedidoId == DetallePedidoId).CantidadSolicitada);

                if (cantidadGestionada < cantidadSolicitada)
                {
                    EVOException e = new EVOException(errores.errArticuloNoGestionadoCompletamente);

                    logger.Error(e);

                    throw e;
                }

                if (cantidadGestionada > cantidadSolicitada)
                {
                    EVOException e = new EVOException(errores.errGestionadaExcedeSolicitada);

                    logger.Error(e);

                    throw e;
                }
            }

            BLArticulo bLArticulos = new BLArticulo();

            Accion accion = bLArticulos.ObtenerAcciones().FirstOrDefault(a => a.Nombre == AccionesCompraEnum.Solicitud_de_traslado.ToString().Replace("_", " "));

            if (accion == null)
            {
                logger.Error(errores.errAccionNoRegistrada);

                Exception e = new Exception();

                throw e;
            }

            EstadoPedido estadoPedido = null;


            if (compras.Count == compras.Where(c => c.AccionId == accion.AccionId).Count())
            {
                estadoPedido = bLPedido.ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.Gestión_Traslado);
            }
            else
            {
                estadoPedido = bLPedido.ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.Gestión_de_Compra);
            }

            actualizarCompraRequest.EstadoPedidoId = estadoPedido.EstadoPedidoId;

            DAArticulo dAArticulo = new DAArticulo();

            try
            {
                dAArticulo.FinalizarCompra(compras, actualizarCompraRequest.PedidoId, actualizarCompraRequest.EstadoPedidoId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;

        }

        /// <summary>
        /// Obtiene los artículos pendientes de gestionar en una gestión de compra
        /// </summary>
        /// <param name="pedidoId">Indica el id del pedido</param>
        /// <param name="accionId">Indica el id de la acción</param>
        /// <response>List<BOArticuloPendienteCompraResponse></response>
        public List<BOArticuloPendienteCompraResponse> ObtenerArticulosCompraPendientes(int pedidoId, int accionId)
        {
            logger.Info($"Entró al método ObtenerArticulosCompraPendientes en BLArticulo - EVO-WebApi con los parámetros pedidoId =  {pedidoId} , accionId = {accionId}");

            if (accionId <= 0)
            {
                EVOException e = new EVOException(errores.errAccionIdNoInformado);

                logger.Error(e);

                throw e;
            }

            List<Accion> acciones = ObtenerAcciones();

            Accion boAccion = acciones.FirstOrDefault(a => a.AccionId == accionId);

            if (acciones != null && boAccion == null)
            {
                EVOException e = new EVOException(errores.errAccionNoRegistrada);

                logger.Error(e);

                throw e;
            }

            if (pedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BLPedido bLPedido = new BLPedido();

            BOPedidoCompraGestionResponse pedidoCompra = bLPedido.ObtenerPedidoCompraGestion(pedidoId);

            BOAccionCompraResponse accion = pedidoCompra.Acciones.FirstOrDefault(a => a.AccionId == accionId);

            List<int> accionDetallesPedidoIds = null;

            accionDetallesPedidoIds = accion.Articulos.Select(a => a.DetallePedidoId).ToList();

            List<BOArticuloCompraResponse> articulosPendientes = pedidoCompra.Articulos
                .Where(a => !accionDetallesPedidoIds.Contains(a.DetallePedidoId)
                && decimal.Parse(a.CantidadFaltanteGestionar) > 0).ToList();

            List<BOArticuloPendienteCompraResponse> pendientesGestionarAccion =
                new List<BOArticuloPendienteCompraResponse>();

            foreach (var a in articulosPendientes)
            {
                BOArticuloPendienteCompraResponse pendienteGestionarAccion = new BOArticuloPendienteCompraResponse()
                {
                    DetallePedidoId = a.DetallePedidoId,
                    CodigoArticulo = a.CodigoArticulo,
                    Nombre = a.NombreArticulo,
                    UnidadMedida = a.UnidadMedida,
                    StockAlmacen = a.StockAlmacen,
                    Observaciones = a.Observaciones,
                    OrdenCompra = string.Empty,
                    CantidadSolicitada = a.CantidadSolicitada,
                    CantidadFaltanteGestionar = a.CantidadFaltanteGestionar,
                    Incluir = true
                };

                if (a.CantidadSolicitada == a.CantidadFaltanteGestionar)
                {
                    pendienteGestionarAccion.CantidadGestionar = a.CantidadSolicitada;
                }

                pendientesGestionarAccion.Add(pendienteGestionarAccion);

            }

            accionDetallesPedidoIds = null;

            if (accion.NombreAccion == AccionesCompraEnum.Traslado_con_Gestión_de_Compra.ToString().Replace("_", " "))
            {
                boAccion = acciones.FirstOrDefault(a => a.Nombre == AccionesCompraEnum.Gestionar_Compra_con_Envío_a_PV.ToString().Replace("_", " "));
                accion = pedidoCompra.Acciones.FirstOrDefault(a => a.AccionId == boAccion.AccionId);
                accionDetallesPedidoIds = accion.Articulos.Select(a => a.DetallePedidoId).ToList();
            }
            else if (accion.NombreAccion == AccionesCompraEnum.Gestionar_Compra_con_Envío_a_PV.ToString().Replace("_", " "))
            {
                boAccion = acciones.FirstOrDefault(a => a.Nombre == AccionesCompraEnum.Traslado_con_Gestión_de_Compra.ToString().Replace("_", " "));
                accion = pedidoCompra.Acciones.FirstOrDefault(a => a.AccionId == boAccion.AccionId);
                accionDetallesPedidoIds = accion.Articulos.Select(a => a.DetallePedidoId).ToList();
            }

            if (accionDetallesPedidoIds != null && accionDetallesPedidoIds.Count > 0)
            {
                foreach (var pendiente in pendientesGestionarAccion)
                {
                    if (accionDetallesPedidoIds.Contains(pendiente.DetallePedidoId))
                    {
                        pendiente.Incluir = false;
                    }
                }
            }

            return pendientesGestionarAccion.Where(p => p.Incluir).ToList();
        }

        ///// <summary>
        ///// Gestiona la actualización de la compra de los artículos
        ///// </summary>
        ///// <param name="body">Solicitud para la actualización compra de los artículos</param>
        ///// <response>bool</response>
        //public bool ActualizarCompra(BOActualizarCompraRequest actualizarCompraRequest)
        //{
        //    if (actualizarCompraRequest == null)
        //    {
        //        EVOException e = new EVOException(errores.errActualizarCompraRequestNoInformado);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    logger.Info(string.Format("Entró al método ActualizarCompra en EVO-WebApi con los parámetros {0}",
        //        JsonConvert.SerializeObject(actualizarCompraRequest)));

        //    if (actualizarCompraRequest.PedidoId <= 0)
        //    {
        //        EVOException e = new EVOException(errores.errPedidoIdNoInformado);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    BLPedido bLPedido = new BLPedido();

        //    BOPedidoCompraGestionResponse pedido =
        //        bLPedido.ObtenerPedidoCompraGestion(actualizarCompraRequest.PedidoId);

        //    if (actualizarCompraRequest.ArticulosActualizarCompra == null || actualizarCompraRequest.ArticulosActualizarCompra.Count == 0)
        //    {
        //        EVOException e = new EVOException(errores.errArticulosNoInformados);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    List<BOGestionCompra> compras = new List<BOGestionCompra>();

        //    foreach (var articulo in actualizarCompraRequest.ArticulosActualizarCompra)
        //    {
        //        if (articulo.AccionId <= 0)
        //        {
        //            EVOException e = new EVOException(errores.errAccionIdNoInformado);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        if (articulo.DetallePedidoId <= 0)
        //        {
        //            EVOException e = new EVOException(errores.errDetallePedidoIdNoInformado);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        if (string.IsNullOrEmpty(articulo.CantidadGestionar))
        //        {
        //            EVOException e = new EVOException(errores.errCantidadGestionarNoInformado);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        try
        //        {
        //            decimal.Parse(articulo.CantidadGestionar);
        //        }
        //        catch
        //        {
        //            EVOException e = new EVOException(errores.errCantidadGestionarFormato);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        if (actualizarCompraRequest.ArticulosActualizarCompra
        //            .Where(a => a.DetallePedidoId == articulo.DetallePedidoId && a.AccionId == articulo.AccionId).Count() >= 2)
        //        {
        //            EVOException e = new EVOException(errores.errArticulosMasVecesEnAccion);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        BOGestionCompra bOGestionCompra = bLPedido.ObtenerGestionCompra(articulo.DetallePedidoId, articulo.AccionId, true);

        //        bOGestionCompra.Cantidad = decimal.Parse(articulo.CantidadGestionar);

        //        compras.Add(bOGestionCompra);

        //    }

        //    foreach (var DetallePedidoId in compras.Select(c => c.DetallePedidoId).Distinct())
        //    {
        //        decimal cantidadGestionada = compras.Where(c => c.DetallePedidoId == DetallePedidoId).Select(a => a.Cantidad).Sum();

        //        decimal cantidadSolicitada = decimal.Parse(pedido.Articulos.FirstOrDefault(a => a.DetallePedidoId == DetallePedidoId).CantidadSolicitada);

        //        if (cantidadGestionada > cantidadSolicitada)
        //        {
        //            EVOException e = new EVOException(errores.errGestionadaExcedeSolicitada);

        //            logger.Error(e);

        //            throw e;
        //        }
        //    }

        //    DAArticulo dAArticulo = new DAArticulo();

        //    try
        //    {
        //        dAArticulo.ActualizarCompra(compras, actualizarCompraRequest.PedidoId);
        //    }
        //    catch (Exception e)
        //    {
        //        logger.Error(e);

        //        throw e;
        //    }

        //    return true;

        //}

        /// <summary>
        /// Gestiona la eliminación de la compra/traslado de un artículo en una acción
        /// </summary>
        /// <param name="detallePedidoId">Indica el id del detalle del pedido</param>
        /// <param name="accionId">Indica el id de la acción</param>
        /// <response >bool</response>
        public bool EliminarCompra(int detallePedidoId, int accionId)
        {
            logger.Info($"Entró al método EliminarCompra en BLArticulo - EVO-WebApi con los parámetros detallePedidoId = {detallePedidoId} , accionId={accionId}");

            if (accionId <= 0)
            {
                EVOException e = new EVOException(errores.errAccionIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (detallePedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errDetallePedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            DAArticulo dAArticulo = new DAArticulo();

            BLPedido bLPedido = new BLPedido();

            bLPedido.ObtenerGestionCompra(detallePedidoId, accionId, true);

            try
            {
                dAArticulo.EliminarCompra(detallePedidoId, accionId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;

        }

        ///// <summary>
        ///// Gestiona la finalización de la compra de los artículos
        ///// </summary>
        ///// <param name="body">Solicitud para la actualización compra de los artículos</param>
        ///// <response>bool</response>
        //public bool FinalizarCompra(BOActualizarCompraRequest actualizarCompraRequest)
        //{
        //    if (actualizarCompraRequest == null)
        //    {
        //        EVOException e = new EVOException(errores.errActualizarCompraRequestNoInformado);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    logger.Info(string.Format("Entró al método FinalizarCompra en EVO-WebApi con los parámetros {0}",
        //        JsonConvert.SerializeObject(actualizarCompraRequest)));

        //    if (actualizarCompraRequest.PedidoId <= 0)
        //    {
        //        EVOException e = new EVOException(errores.errPedidoIdNoInformado);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    BLPedido bLPedido = new BLPedido();

        //    BOPedidoCompraGestionResponse pedido = bLPedido.ObtenerPedidoCompraGestion(actualizarCompraRequest.PedidoId);

        //    if (actualizarCompraRequest.ArticulosActualizarCompra == null || actualizarCompraRequest.ArticulosActualizarCompra.Count == 0)
        //    {
        //        EVOException e = new EVOException(errores.errArticulosNoInformados);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    List<BOGestionCompra> compras = new List<BOGestionCompra>();

        //    foreach (var articulo in actualizarCompraRequest.ArticulosActualizarCompra)
        //    {
        //        if (articulo.AccionId <= 0)
        //        {
        //            EVOException e = new EVOException(errores.errAccionIdNoInformado);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        if (articulo.DetallePedidoId < 0)
        //        {
        //            EVOException e = new EVOException(errores.errDetallePedidoIdNoInformado);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        if (string.IsNullOrEmpty(articulo.CantidadGestionar))
        //        {
        //            EVOException e = new EVOException(errores.errCantidadGestionarNoInformado);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        if (actualizarCompraRequest.ArticulosActualizarCompra
        //            .Where(a => a.DetallePedidoId == articulo.DetallePedidoId && a.AccionId == articulo.AccionId).Count() >= 2)
        //        {
        //            EVOException e = new EVOException(errores.errArticulosMasVecesEnAccion);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        BOGestionCompra bOGestionCompra = bLPedido.ObtenerGestionCompra(articulo.DetallePedidoId, articulo.AccionId, true);

        //        bOGestionCompra.Cantidad = decimal.Parse(articulo.CantidadGestionar);

        //        compras.Add(bOGestionCompra);

        //    }

        //    foreach (var DetallePedidoId in compras.Select(c => c.DetallePedidoId).Distinct())
        //    {
        //        decimal cantidadGestionada = compras.Where(c => c.DetallePedidoId == DetallePedidoId).Select(a => a.Cantidad).Sum();
        //        decimal cantidadSolicitada = decimal.Parse(pedido.Articulos.FirstOrDefault(a => a.DetallePedidoId == DetallePedidoId).CantidadSolicitada);

        //        if (cantidadGestionada < cantidadSolicitada)
        //        {
        //            EVOException e = new EVOException(errores.errArticuloNoGestionadoCompletamente);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        if (cantidadGestionada > cantidadSolicitada)
        //        {
        //            EVOException e = new EVOException(errores.errGestionadaExcedeSolicitada);

        //            logger.Error(e);

        //            throw e;
        //        }
        //    }

        //    BLArticulo bLArticulos = new BLArticulo();

        //    Accion accion = bLArticulos.ObtenerAcciones().FirstOrDefault(a => a.Nombre == AccionesCompraEnum.Solicitud_de_traslado.ToString().Replace("_", " "));

        //    if (accion == null)
        //    {
        //        logger.Error(errores.errAccionNoRegistrada);

        //        Exception e = new Exception();

        //        throw e;
        //    }

        //    EstadoPedido estadoPedido = null;


        //    if (compras.Count == compras.Where(c => c.AccionId == accion.AccionId).Count())
        //    {
        //        estadoPedido = bLPedido.ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.Gestión_Traslado);
        //    }
        //    else
        //    {
        //        estadoPedido = bLPedido.ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.Gestión_de_Compra);
        //    }

        //    actualizarCompraRequest.EstadoPedidoId = estadoPedido.EstadoPedidoId;

        //    DAArticulo dAArticulo = new DAArticulo();

        //    try
        //    {
        //        dAArticulo.FinalizarCompra(compras, actualizarCompraRequest.PedidoId, actualizarCompraRequest.EstadoPedidoId);
        //    }
        //    catch (Exception e)
        //    {
        //        logger.Error(e);

        //        throw e;
        //    }

        //    return true;

        //}

        /// <summary>
        /// Gestiona la eliminación de todas las ordenes de compras de todos los artículos
        /// </summary>
        /// <param name="pedidoId">Indica el id del pedido</param>
        /// <response >bool</response>
        public bool LimpiarCompras(int pedidoId)
        {
            logger.Info($"Entró al método LimpiarCompras en ArticulosApi - EVO-WebApi con el parámetro pedidoId = {pedidoId}");

            if (pedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BLPedido bLPedido = new BLPedido();

            BOPedidoCompraGestionResponse pedido =
                 bLPedido.ObtenerPedidoCompraGestion(pedidoId);

            if (pedido.Articulos != null && pedido.Articulos.Count == 0)
            {
                EVOException e = new EVOException(errores.errPedidoSinArticulos);

                logger.Error(e);

                throw e;
            }

            DAArticulo dAArticulo = new DAArticulo();

            try
            {
                dAArticulo.LimpiarCompras(pedido.Articulos.Select(a => a.DetallePedidoId).ToList());
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            return true;

        }

        /// <summary>
        /// Gestiona la actualización de la compra de los artículos
        /// </summary>
        /// <param name="body">Solicitud para la actualización compra de los artículos</param>
        /// <response>bool</response>
        public bool ActualizarCompra(BOActualizarCompraRequest actualizarCompraRequest)
        {
            if (actualizarCompraRequest == null)
            {
                EVOException e = new EVOException(errores.errActualizarCompraRequestNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ActualizarCompra en EVO-WebApi con los parámetros {0}",
                JsonConvert.SerializeObject(actualizarCompraRequest)));

            if (actualizarCompraRequest.PedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BLPedido bLPedido = new BLPedido();

            BOPedidoCompraGestionResponse pedido =
                bLPedido.ObtenerPedidoCompraGestion(actualizarCompraRequest.PedidoId);

            if (actualizarCompraRequest.ArticulosActualizarCompra == null || actualizarCompraRequest.ArticulosActualizarCompra.Count == 0)
            {
                EVOException e = new EVOException(errores.errArticulosNoInformados);

                logger.Error(e);

                throw e;
            }

            List<BOGestionCompra> compras = new List<BOGestionCompra>();

            foreach (var articulo in actualizarCompraRequest.ArticulosActualizarCompra)
            {
                if (articulo.AccionId <= 0)
                {
                    EVOException e = new EVOException(errores.errAccionIdNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (articulo.DetallePedidoId <= 0)
                {
                    EVOException e = new EVOException(errores.errDetallePedidoIdNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (string.IsNullOrEmpty(articulo.CantidadGestionar))
                {
                    EVOException e = new EVOException(errores.errCantidadGestionarNoInformado);

                    logger.Error(e);

                    throw e;
                }

                try
                {
                    decimal.Parse(articulo.CantidadGestionar);
                }
                catch
                {
                    EVOException e = new EVOException(errores.errCantidadGestionarFormato);

                    logger.Error(e);

                    throw e;
                }

                if (actualizarCompraRequest.ArticulosActualizarCompra
                    .Where(a => a.DetallePedidoId == articulo.DetallePedidoId && a.AccionId == articulo.AccionId).Count() >= 2)
                {
                    EVOException e = new EVOException(errores.errArticulosMasVecesEnAccion);

                    logger.Error(e);

                    throw e;
                }

                BOGestionCompra bOGestionCompra = bLPedido.ObtenerGestionCompra(articulo.DetallePedidoId, articulo.AccionId, false);

                if (bOGestionCompra != null)
                {
                    bOGestionCompra.Cantidad = decimal.Parse(articulo.CantidadGestionar);
                    bOGestionCompra.Actualizar = true;
                }
                else
                {
                    bOGestionCompra = new BOGestionCompra()
                    {
                        Cantidad = decimal.Parse(articulo.CantidadGestionar),
                        AccionId = articulo.AccionId,
                        DetallePedidoId = articulo.DetallePedidoId,
                        Nuevo = true
                    };
                }

                compras.Add(bOGestionCompra);

            }

            foreach (var DetallePedidoId in compras.Select(c => c.DetallePedidoId).Distinct())
            {
                decimal cantidadGestionada = compras.Where(c => c.DetallePedidoId == DetallePedidoId).Select(a => a.Cantidad).Sum();

                decimal cantidadSolicitada = decimal.Parse(pedido.Articulos.FirstOrDefault(a => a.DetallePedidoId == DetallePedidoId).CantidadSolicitada);

                if (cantidadGestionada > cantidadSolicitada)
                {
                    EVOException e = new EVOException(errores.errGestionadaExcedeSolicitada);

                    logger.Error(e);

                    throw e;
                }
            }

            DAArticulo dAArticulo = new DAArticulo();

            try
            {
                dAArticulo.ActualizarCompra(compras, actualizarCompraRequest.PedidoId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;

        }

        /// <summary>
        /// Obtiene artículo por código
        /// </summary>
        /// <param name="codigo">Indica el código del artículo</param>
        /// <returns>Articulo</returns>
        public BOArticulo ObtenerArticuloxCodigo(string codigo)
        {
            logger.Info($"Entró al método ObtenerArticuloxCodigo en BLArticulos con parámetro codigo = {codigo}");

            if (string.IsNullOrEmpty(codigo))
            {
                EVOException e = new EVOException(errores.errCodigoArticuloNoInformado);

                logger.Error(e);

                throw e;

            }

            DAArticulo dAArticulos = new DAArticulo();

            BOArticulo articulo = new BOArticulo();

            try
            {
                articulo = dAArticulos.obtenerArticuloxCodigo(codigo);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (articulo == null)
            {
                EVOException e = new EVOException(errores.errArticuloNoExiste);

                logger.Error(e);

                throw e;
            }

            return articulo;
        }

        /// <summary>
        /// Gestiona la compra de los artículos
        /// </summary>
        /// <param name="body">Solicitud para la compra de los artículos</param>
        /// <response>bool</response>
        public bool AsignarCompra(BOCompraRequest compraRequest)
        {
            if (compraRequest == null)
            {
                EVOException e = new EVOException(errores.errCompraRequestNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método AsignarCompra en EVO-WebApi con los parámetros {0}",
                JsonConvert.SerializeObject(compraRequest)));

            if (compraRequest.AccionId < 0)
            {
                EVOException e = new EVOException(errores.errSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            BLPedido bLPedido = new BLPedido();

            BOPedidoCompraGestionResponse pedido =
                bLPedido.ObtenerPedidoCompraGestion(compraRequest.PedidoId);

            if (compraRequest.ArticulosCompra.Count == 0)
            {
                EVOException e = new EVOException(errores.errArticulosNoInformados);

                logger.Error(e);

                throw e;
            }

            foreach (var articulo in compraRequest.ArticulosCompra)
            {
                if (string.IsNullOrEmpty(articulo.CodigoArticulo))
                {
                    EVOException e = new EVOException(errores.codigoArticuloNoInformado);

                    logger.Error(e);

                    throw e;
                }

                BOGestionCompra bOGestionCompra = bLPedido.ObtenerGestionCompra(articulo.DetallePedidoId, compraRequest.AccionId, false);

                if (string.IsNullOrEmpty(articulo.CantidadGestionar))
                {
                    EVOException e = new EVOException(errores.errCantidadGestionarNoInformado);

                    logger.Error(e);

                    throw e;
                }
                
                
                decimal cantidadGestionar = 0;

                try
                {
                    if (bOGestionCompra != null)
                    {
                        cantidadGestionar += bOGestionCompra.Cantidad + decimal.Parse(articulo.CantidadGestionar);
                    } else
                    {
                        cantidadGestionar = decimal.Parse(articulo.CantidadGestionar);
                    }
                    articulo.CantidadGestionar = cantidadGestionar.ToString();
                }
                catch
                {
                    EVOException e = new EVOException(errores.errCantidadGestionarFormato);

                    logger.Error(e);

                    throw e;
                }

                decimal cantidadSolicitada = decimal.Parse(pedido.Articulos
                    .FirstOrDefault(a => a.DetallePedidoId == articulo.DetallePedidoId)
                    .CantidadSolicitada);

                if (cantidadGestionar > cantidadSolicitada)
                {
                    EVOException e = new EVOException(errores.errCantidadExcedeSolicitada);

                    logger.Error(e);

                    throw e;
                }

            }

            DAArticulo dAArticulo = new DAArticulo();

            try
            {
                dAArticulo.AsignarCompra(compraRequest);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;

        }

        ///// <summary>
        ///// Gestiona la compra de los artículos
        ///// </summary>
        ///// <param name="body">Solicitud para la compra de los artículos</param>
        ///// <response>bool</response>
        //public bool AsignarCompra(BOCompraRequest compraRequest)
        //{
        //    if (compraRequest == null)
        //    {
        //        EVOException e = new EVOException(errores.errCompraRequestNoInformado);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    logger.Info(string.Format("Entró al método AsignarCompra en EVO-WebApi con los parámetros {0}",
        //        JsonConvert.SerializeObject(compraRequest)));

        //    if (compraRequest.AccionId < 0)
        //    {
        //        EVOException e = new EVOException(errores.errSolicitudNoInformado);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    BLPedido bLPedido = new BLPedido();

        //    BOPedidoCompraGestionResponse pedido =
        //        bLPedido.ObtenerPedidoCompraGestion(compraRequest.PedidoId);

        //    if (compraRequest.ArticulosCompra.Count == 0)
        //    {
        //        EVOException e = new EVOException(errores.errArticulosNoInformados);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    Accion accion = ObtenerAcciones().FirstOrDefault(a => a.AccionId == compraRequest.AccionId);

        //    if (accion == null)
        //    {
        //        EVOException e = new EVOException(errores.errAccionNoRegistrada);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    foreach (var articulo in compraRequest.ArticulosCompra)
        //    {
        //        if (string.IsNullOrEmpty(articulo.CodigoArticulo))
        //        {
        //            EVOException e = new EVOException(errores.codigoArticuloNoInformado);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        if (articulo.DetallePedidoId < 0)
        //        {
        //            EVOException e = new EVOException(errores.errDetallePedidoIdNoInformado);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        //BOGestionCompra bOGestionCompra = bLPedido.ObtenerGestionCompra(articulo.DetallePedidoId, compraRequest.AccionId, false);

        //        //if (bOGestionCompra != null)
        //        //{
        //        //    EVOException e = new EVOException(errores.errArticuloCompraExisteAccion);

        //        //    logger.Error(e);

        //        //    throw e;
        //        //}

        //        BOAccionCompraResponse accionCompra = null;

        //        if (accion.Nombre == AccionesCompraEnum.Solicitud_de_traslado.ToString().Replace("_", " "))
        //        {
        //            accionCompra = pedido.Acciones.FirstOrDefault(a=>a.AccionId==accion.AccionId);

        //            if (accionCompra!=null && accionCompra.Articulos.FirstOrDefault(a=>a.DetallePedidoId== articulo.DetallePedidoId)!=null)
        //            {
        //                EVOException e = new EVOException(errores.errArticuloCompraExisteAccion);

        //                logger.Error(e);

        //                throw e;
        //            }
        //        }
        //        else if (accion.Nombre == AccionesCompraEnum.Traslado_con_Gestión_de_Compra.ToString().Replace("_", " "))
        //        {
        //            accionCompra = pedido.Acciones.FirstOrDefault(a => a.AccionId == accion.AccionId);

        //            if (accionCompra != null && accionCompra.Articulos.FirstOrDefault(a => a.DetallePedidoId == articulo.DetallePedidoId) != null)
        //            {
        //                EVOException e = new EVOException(errores.errArticuloCompraExisteAccion);

        //                logger.Error(e);

        //                throw e;
        //            }

        //            accion = ObtenerAcciones().FirstOrDefault(a => a.Nombre == AccionesCompraEnum.Gestionar_Compra_con_Envío_a_PV.ToString().Replace("_", " "));
        //            accionCompra = pedido.Acciones.FirstOrDefault(a => a.AccionId == accion.AccionId);

        //            if (accionCompra != null && accionCompra.Articulos.FirstOrDefault(a => a.DetallePedidoId == articulo.DetallePedidoId) != null)
        //            {
        //                EVOException e = new EVOException(errores.errArticuloCompraExisteAccionEnvioPV);

        //                logger.Error(e);

        //                throw e;
        //            }
        //        }
        //        else if (accion.Nombre == AccionesCompraEnum.Gestionar_Compra_con_Envío_a_PV.ToString().Replace("_", " "))
        //        {
        //            accionCompra = pedido.Acciones.FirstOrDefault(a => a.AccionId == accion.AccionId);

        //            if (accionCompra != null && accionCompra.Articulos.FirstOrDefault(a => a.DetallePedidoId == articulo.DetallePedidoId) != null)
        //            {
        //                EVOException e = new EVOException(errores.errArticuloCompraExisteAccion);

        //                logger.Error(e);

        //                throw e;
        //            }

        //            accion = ObtenerAcciones().FirstOrDefault(a => a.Nombre == AccionesCompraEnum.Traslado_con_Gestión_de_Compra.ToString().Replace("_", " "));
        //            accionCompra = pedido.Acciones.FirstOrDefault(a => a.AccionId == accion.AccionId);

        //            if (accionCompra != null && accionCompra.Articulos.FirstOrDefault(a => a.DetallePedidoId == articulo.DetallePedidoId) != null)
        //            {
        //                EVOException e = new EVOException(errores.errArticuloCompraExisteAccionGestionCompra);

        //                logger.Error(e);

        //                throw e;
        //            }
        //        }

        //        if (string.IsNullOrEmpty(articulo.CantidadGestionar))
        //        {
        //            EVOException e = new EVOException(errores.errCantidadGestionarNoInformado);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        decimal cantidadGestionar = 0;

        //        try
        //        {
        //            cantidadGestionar = decimal.Parse(articulo.CantidadGestionar);
        //        }
        //        catch
        //        {
        //            EVOException e = new EVOException(errores.errCantidadGestionarFormato);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        decimal cantidadFaltanteGestionar = decimal.Parse(pedido.Articulos
        //            .FirstOrDefault(a => a.DetallePedidoId == articulo.DetallePedidoId)
        //            .CantidadFaltanteGestionar);

        //        if (cantidadGestionar > cantidadFaltanteGestionar)
        //        {
        //            EVOException e = new EVOException(errores.errCantidadExcedeFaltante);

        //            logger.Error(e);

        //            throw e;
        //        }

        //    }

        //    DAArticulo dAArticulo = new DAArticulo();

        //    try
        //    {
        //        dAArticulo.AsignarCompra(compraRequest);
        //    }
        //    catch (Exception e)
        //    {
        //        logger.Error(e);

        //        throw e;
        //    }

        //    return true;

        //}

        /// <summary>
        /// Este método obtiene todos los artículos de las bodegas por el filtro
        /// </summary>
        /// <param name="filtro">Indica el valor del filtro realizado</param>
        /// <returns>Lista de todos los artículos realizado el filtro</returns>
        public List<ArticuloBodega> ObtenerTodosArticulosBodegaxFiltro(FiltroArticulo filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosArticulosxFiltro con los parámetros {0}",
                JsonConvert.SerializeObject(filtro)));

            if (string.IsNullOrEmpty(filtro.WhsCode))
            {
                EVOException e = new EVOException(errores.errSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            int nBackSlash = filtro.WhsCode.IndexOf(@"-");

            if (nBackSlash > 0)
            {
                filtro.WhsCode = filtro.WhsCode.Substring(nBackSlash + 1, filtro.WhsCode.Length - nBackSlash - 1);
            }
            else
            {
                EVOException e = new EVOException(errores.errCodigoArticuloFormatoIncorrecto);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrWhiteSpace(filtro.CodigoArticulo) &&
               string.IsNullOrWhiteSpace(filtro.NombreArticulo) &&
               string.IsNullOrWhiteSpace(filtro.Stock) &&
               string.IsNullOrWhiteSpace(filtro.Minimo) &&
               string.IsNullOrWhiteSpace(filtro.Maximo))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            List<ArticuloBodega> articulosBodega = new List<ArticuloBodega>();

            DAArticulo dAArticulos = new DAArticulo();

            try
            {
                articulosBodega = dAArticulos.ObtenerTodosArticulosxFiltro(filtro);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return articulosBodega;

        }

        /// <summary>
        /// Obtiene todas las tranformaciones
        /// </summary>       
        /// <responses>List<BOTransformacion></response>
        public List<BOTransformacion> ObtenerTodasTransformaciones()
        {
            logger.Info("Entró al método ObtenerTodasTransformaciones en BLArticulo - EVO-WebApi");

            DAArticulo dAArticulo = new DAArticulo();

            List<BOTransformacion> bOTransformaciones = null;

            try
            {
                bOTransformaciones = dAArticulo.ObtenerTodasTransformaciones();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            return bOTransformaciones;
        }

        /// <summary>
        /// Obtiene los artículos en el punto de venta filtrado por código y/o nombre
        /// </summary>
        /// <param name="body">Solicitud de filtro de artículos facturación. Se debe ingresar al menos uno de los criterios del filtro</param>
        /// <response>List<BOArticuloPuntoVentaResponse></response>
        public List<BOArticuloPuntoVentaResponse> ObtenerArticulosFacturacionxFiltro(BOFiltrarArticulosFacturacionRequest bOBody)
        {
            if (bOBody == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerArticulosFacturacionxFiltro en BLArticulo - EVO-WebApi con los parámetros {JsonConvert.SerializeObject(bOBody)}");

            if (string.IsNullOrEmpty(bOBody.CodigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();

            BOBodega bOBodega = bLBodega.ObtenerBodegaPorCodigo(bOBody.CodigoPuntoVenta);

            if (string.IsNullOrEmpty(bOBody.IdentificacionSocio))
            {
                EVOException e = new EVOException(errores.errIdentificacionNoInformada);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(bOBody.CodigoArticulo) && string.IsNullOrEmpty(bOBody.NombreArticulo))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            List<BOArticuloPuntoVentaResponse> bOArticulosPuntoVentaResponse =
                ObtenerArticulosFacturacion(bOBody.CodigoPuntoVenta, bOBody.IdentificacionSocio);

            if (!string.IsNullOrEmpty(bOBody.CodigoArticulo) && !string.IsNullOrEmpty(bOBody.NombreArticulo))
            {
                return bOArticulosPuntoVentaResponse
                    .Where(a => EF.Functions
                    .Like(a.CodigoArticulo, bOBody.CodigoArticulo + "%") && EF.Functions
                    .Like(a.NombreArticulo, bOBody.NombreArticulo + "%"))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(bOBody.CodigoArticulo) && string.IsNullOrEmpty(bOBody.NombreArticulo))
            {
                return bOArticulosPuntoVentaResponse
                    .Where(a => EF.Functions
                    .Like(a.CodigoArticulo, bOBody.CodigoArticulo + "%"))
                    .ToList();
            }

            return bOArticulosPuntoVentaResponse
                .Where(a => EF.Functions
                .Like(a.NombreArticulo, bOBody.NombreArticulo + "%"))
                .ToList();
        }

        /// <summary>
        /// Obtiene los artículos para el proceso de facturación
        /// </summary>
        /// <param name="codigoPuntoVenta">Indica el código del punto de venta</param>
        /// <param name="identificacionSocio">Indica la identificación del socio de negocio</param>
        /// <responses>List<BOArticuloPuntoVentaResponse></response>
        public List<BOArticuloPuntoVentaResponse> ObtenerArticulosFacturacion(string codigoPuntoVenta, string identificacionSocio)
        {
            logger.Info($"Entró al método ObtenerArticulosFacturacion en BLArticulo - EVO-WebApi con los parámetros codigoPuntoVenta = {codigoPuntoVenta} , identificacionSocio = {identificacionSocio}");

            if (string.IsNullOrEmpty(codigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();

            BOBodega bOBodega = bLBodega.ObtenerBodegaPorCodigo(codigoPuntoVenta);

            if (string.IsNullOrEmpty(identificacionSocio))
            {
                EVOException e = new EVOException(errores.errIdentificacionNoInformada);

                logger.Error(e);

                throw e;
            }

            BLSocioNegocio bLSocioNegocio = new BLSocioNegocio();

            BOSocioNegocio bOSocioNegocio = bLSocioNegocio.ObtenerSocioNegocio(identificacionSocio);

            List<BOArticulo> bOArticulos = ObtenerTodosArticulosxPuntoVenta(codigoPuntoVenta);

            List<BOArticuloPuntoVentaResponse> bOArticulosPuntoVentaResponse = new List<BOArticuloPuntoVentaResponse>();

            foreach (BOArticulo bOArticulo in bOArticulos.Where(a =>
                        a.ItemCode.Substring(0, a.ItemCode.IndexOf("-")) == TiposPrefijoEnum.PT.ToString() ||
                        a.ItemCode.Substring(0, a.ItemCode.IndexOf("-")) == TiposPrefijoEnum.PTD.ToString()
                ).ToList())
            {

                BOArticuloPuntoVentaResponse bOArticuloPuntoVentaResponse = new BOArticuloPuntoVentaResponse()
                {
                    CodigoArticulo = bOArticulo.ItemCode,
                    NombreArticulo = bOArticulo.ItemName,
                    Lote = string.Empty,
                    PrecioUnitario = decimal.ToInt32(bOArticulo.Price.Value),
                    UnidadMedida = bOArticulo.SalUnitMsr
                };

                ArticuloBodega articuloBodega = ObtenerArticuloxCodigoBodegaCodigoArticulo(codigoPuntoVenta, bOArticulo.ItemCode);

                bOArticuloPuntoVentaResponse.Stock = articuloBodega.Stock;

                if (bOArticulo.ImpuestosArticulos.Count() > 0)
                {
                    BOImpuestoArticulo BOImpuestoArticulo = bOArticulo.ImpuestosArticulos
                        .OrderByDescending(o => o.ImpuestoArticuloId)
                        .FirstOrDefault(i => i.Impuesto.Codigo == ImpuestosEnum.IVAGEXE.ToString() && i.Impuesto.Activo);

                    if (BOImpuestoArticulo != null)
                    {
                        bOArticuloPuntoVentaResponse.ValorIVA = BOImpuestoArticulo.Impuesto.Valor;
                        bOArticuloPuntoVentaResponse.CodigoIVA = BOImpuestoArticulo.Impuesto.Codigo;
                    }

                }

                if (bOArticulo.ImpuestosSociosArticulos.Count() > 0)
                {
                    BOImpuestoSocioArticulo bOImpuestoSocioArticulo = bOArticulo.ImpuestosSociosArticulos
                        .FirstOrDefault(i => i.Impuesto.Codigo == ImpuestosEnum.NI.ToString() && i.Impuesto.Activo
                        && i.Identificacion == identificacionSocio && i.CodigoArticulo == bOArticulo.ItemCode);

                    if (bOImpuestoSocioArticulo != null)
                    {
                        bOArticuloPuntoVentaResponse.ValorRetencion = bOImpuestoSocioArticulo.Impuesto.Valor;
                        bOArticuloPuntoVentaResponse.CodigoRetencion = bOImpuestoSocioArticulo.Impuesto.Codigo;
                    }

                }

                if (bOArticulo.ListasPrecios.Count() > 0)
                {
                    BOListaPrecio bOListaPrecioItem = bOArticulo.ListasPrecios
                        .FirstOrDefault(l =>
                        l.TipoListaPrecio.Nombre == TiposListaPrecioEnum.PorMayor.ToString() &&
                        l.Identificacion == identificacionSocio &&
                        l.CodigoArticulo == bOArticulo.ItemCode &&
                        (DateTime.Now >= l.FechaInicio && DateTime.Now <= l.FechaFin)
                        );

                    if (bOListaPrecioItem != null)
                    {
                        bOArticuloPuntoVentaResponse.PrecioUnitarioPorMayor = bOListaPrecioItem.PrecioUnitario;
                        bOArticuloPuntoVentaResponse.CantidadMinimaPrecioPorMayor = bOListaPrecioItem.CantidadMinima;
                    }

                }

                bOArticulosPuntoVentaResponse.Add(bOArticuloPuntoVentaResponse);

            }

            List<BOTransformacion> bOTransformaciones = ObtenerTodasTransformaciones();

            foreach (string codigoArticuloTransformado in bOTransformaciones.Select(t => t.CodigoArticuloTransformado).Distinct())
            {
                BOArticuloPuntoVentaResponse bOArticuloPuntoVentaResponse = new BOArticuloPuntoVentaResponse()
                {
                    CodigoArticulo = codigoArticuloTransformado,
                    NombreArticulo = bOTransformaciones
                    .FirstOrDefault(t => t.CodigoArticuloTransformado == codigoArticuloTransformado).NombreArticuloTransformado,
                    Lote = string.Empty,
                    PrecioUnitario = bOTransformaciones
                    .Where(t => t.CodigoArticuloTransformado == codigoArticuloTransformado)
                    .Select(t => t.Articulo.Price.Value)
                    .Sum(),
                    UnidadMedida = string.Empty
                };

                bOArticuloPuntoVentaResponse.ArticulosTransformacionResponse = new List<BOArticuloTransformacionResponse>();

                ArticuloBodega articuloBodega = null;

                foreach (BOTransformacion bOTransformacion in bOTransformaciones.Where(t => t.CodigoArticuloTransformado == codigoArticuloTransformado))
                {

                    try
                    {
                        articuloBodega = ObtenerArticuloxCodigoBodegaCodigoArticulo(codigoPuntoVenta, bOTransformacion.CodigoArticulo);
                    }
                    catch (EVOException e)
                    {
                        if (e.Message == errores.errArticuloBodegaNoRegistrado)
                        {
                            articuloBodega = null;
                        }
                    }

                    BOArticuloTransformacionResponse bOArticuloTransformacionResponse = new BOArticuloTransformacionResponse()
                    {
                        CodigoArticulo = bOTransformacion.CodigoArticulo,
                        NombreArticulo = bOTransformacion.Articulo.ItemName,
                        Stock = articuloBodega != null ? articuloBodega.Stock.Value : 0,
                        CantidadMinima = bOTransformacion.CantidadMinima
                    };

                    bOArticuloPuntoVentaResponse.ArticulosTransformacionResponse.Add(bOArticuloTransformacionResponse);
                }


                bOArticulosPuntoVentaResponse.Add(bOArticuloPuntoVentaResponse);
            }

            return bOArticulosPuntoVentaResponse;

        }

        /// <summary>
        /// Obtiene los artículos en recepción
        /// </summary>
        /// <param name="entregaId">Indica el id de la entrega</param>
        /// <response>List<ArticuloRecepcionRespuesta></response>
        public List<ArticuloRecepcionRespuesta> ObtenerArticulosRecepcion(int entregaId)
        {
            if (entregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerArticulosRecepcion con el parámetro entregaId = {entregaId}");

            BLEntrega bLEntregas = new BLEntrega();

            BOEntrega bOEntrega = null;

            try
            {
                bOEntrega = bLEntregas.ObtenerEntregaxEntregaId(entregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            List<ArticuloRecepcionRespuesta> articulosRecepcionRespuesta = new List<ArticuloRecepcionRespuesta>();

            articulosRecepcionRespuesta.AddRange(
                   bOEntrega.Detalles.Select(d => new ArticuloRecepcionRespuesta()
                   {
                       DetalleEntregaId = d.DetalleEntregaId,
                       CodigoArticulo = d.DetallePedido.ItemCode,
                       EstadoArticulo = d.DetallePedido.EstadoArticulo.Nombre,
                       CantidadSolicitada = d.DetallePedido.Cantidad,
                       CantidadAprobada = d.DetallePedido.CantidadAprobada.Value,
                       CantidadEnviada = d.DetallePedido.CantidadAprobada.Value, //Por el momento será la aprobada mientras se define el nuevo proceso de la planta de beneficio
                       CantidadRecibida = 0
                   })
                );

            BLArticulo bLArticulos = new BLArticulo();
            BOArticulo boArticulo = null;

            foreach (ArticuloRecepcionRespuesta articuloRecepcionRespuesta in articulosRecepcionRespuesta)
            {
                try
                {
                    boArticulo = bLArticulos.ObtenerArticuloxCodigo(articuloRecepcionRespuesta.CodigoArticulo);
                }
                catch (EVOException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }

                articuloRecepcionRespuesta.NombreArticulo = boArticulo.ItemName;
                articuloRecepcionRespuesta.UnidadMedida = boArticulo.SalUnitMsr;
            }

            BOEstadoEntrega bOEstadoEntrega = null;

            try
            {
                bOEstadoEntrega = bLEntregas.ObtenerEstadoEntregaxNombre(EstadosEntregasEnum.En_Tránsito);
                //Al ser pesados en recepción están en estado "En Tránsito"
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BLPesaje bLPesaje = new BLPesaje();
            BOPesajeEntrega bOPesajeEntrega = null;

            try
            {
                bOPesajeEntrega = bLPesaje.ObtenerPesajeEntrega(entregaId, bOEstadoEntrega.EstadoEntregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOPesajeEntrega != null)
            {
                foreach (ArticuloRecepcionRespuesta articuloRecepcionRespuesta in articulosRecepcionRespuesta)
                {
                    BOPesajeArticulo bOPesajeArticulo =
                        bOPesajeEntrega.PesajesArticulo.FirstOrDefault(pa => pa.DetalleEntregaId == articuloRecepcionRespuesta.DetalleEntregaId);

                    if (bOPesajeArticulo != null)
                    {
                        articuloRecepcionRespuesta.CantidadRecibida = bOPesajeArticulo.Pesajes
                            .Count() > 0 ? bOPesajeArticulo.Pesajes
                            .Select(p => p.PesoBasculaArticulos)
                            .Sum() : bOPesajeEntrega.PesajesArticulo
                            .FirstOrDefault(pa => pa.DetalleEntregaId == articuloRecepcionRespuesta.DetalleEntregaId).CantidadRecibida.Value;

                        articuloRecepcionRespuesta.PesajeArticuloId = bOPesajeArticulo.PesajeArticuloId;

                    }
                }
            }

            return articulosRecepcionRespuesta;
        }



        /// <summary>
        /// Obtiene los artículos y encazado de una entrega en estado alistamiento
        /// </summary>
        /// <param name="id">Indica el id de la entrega</param>
        /// <response>DetalleEntregaRespuesta</response>
        public DetalleEntregaRespuesta ObtenerAriticulosAlistamiento(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerAritculosAlistamiento con el parámetro id = {id}");

            BLEntrega bLEntregas = new BLEntrega();

            EntregaBO entregaBO = null;

            try
            {
                entregaBO = bLEntregas.ObtenerEntregaxId(id);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            DAArticulo dAArticulos = new DAArticulo();

            DetalleEntregaRespuesta detalleEntregaRespuesta = null;

            try
            {
                detalleEntregaRespuesta = dAArticulos.ObtenerArticulosPesaje(id);
            }
            catch (Exception e)
            {
                throw e;
            }

            return detalleEntregaRespuesta;

        }

        /// <summary>
        /// Este método obtiene el estado del artículo por el id
        /// </summary>
        /// <param name="estadoArticuloId">Indica el id del estado</param>
        /// <returns>Instancia de tipo EstadoArticulo</returns>
        public BOEstadoArticulo ObtenerEstadoArticuloxId(int estadoArticuloId)
        {
            if (estadoArticuloId <= 0)
            {
                EVOException e = new EVOException(errores.errEstadoArticuloNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerEstadoArticuloxId con el parámetro estadoArticuloId = {estadoArticuloId}");

            DAArticulo dAArticulos = new DAArticulo();

            BOEstadoArticulo estadoArticulo = null;

            try
            {
                estadoArticulo = dAArticulos.ObtenerEstadoArticuloxId(estadoArticuloId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (estadoArticulo == null)
            {
                EVOException e = new EVOException(errores.errEstadoPedidoNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return estadoArticulo;

        }

        /// <summary>
        /// Este método obtiene el conteo de todos los registros del fittro
        /// </summary>
        /// <param name="filtro">Indica el valor del filtro realizado</param>
        /// <returns>Número de todos los registros realizado el filtro</returns>
        public int ObtenerConteoTodosRegistrosxFiltro(FiltroArticulo filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerConteoTodosRegistrosxFiltro con los parámetros; {0}",
                JsonConvert.SerializeObject(filtro)));

            if (string.IsNullOrEmpty(filtro.WhsCode))
            {
                EVOException e = new EVOException(errores.errSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            DAArticulo dAArticulos = new DAArticulo();

            if (string.IsNullOrWhiteSpace(filtro.CodigoArticulo) &&
                string.IsNullOrWhiteSpace(filtro.NombreArticulo) &&
                string.IsNullOrWhiteSpace(filtro.Stock) &&
                string.IsNullOrWhiteSpace(filtro.Minimo) &&
                string.IsNullOrWhiteSpace(filtro.Maximo))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            int nRegistros = 0;

            try
            {
                object result = dAArticulos.ObtenerConteoTodosRegistrosxFiltro(filtro);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene todos los artículos por la bodega
        /// </summary>
        /// <param name="desde">Indica el valor del parametro desde ejemplo: desde 1</param>
        /// <param name="hasta">Indica el valor del parametro hasta ejemplo: hasta 10</param>
        /// <param name="whsCodePuntoVenta">Indica el código del punto de venta</param>
        /// <param name="whsCodePlanta">Indica el código de la planta</param>
        /// <returns>Todos los artículos por bodega</returns>
        public List<ArticuloBodega> ObtenerTodosArticulosxBodega(int desde, int hasta, string whsCodePuntoVenta, string whsCodePlanta, string tipoSolicitud)
        {

            if (desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (hasta < desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(whsCodePlanta))
            {
                EVOException e = new EVOException(errores.errSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(whsCodePuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(tipoSolicitud))
            {
                EVOException e = new EVOException(errores.errTipoSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosArticulosxBodega de BLArticulos con los parámetros: desde: {0}, hasta: {1} ,whsCodePuntoVenta: {2},whsCodePuntoVenta: {3},tipoSolicitud: {4}", desde, hasta, whsCodePuntoVenta, whsCodePlanta, tipoSolicitud));

            DAArticulo dAArticulos = new DAArticulo();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception)
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI.ToString()));

                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((hasta - desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            List<ArticuloBodega> articulosBodega = null;

            try
            {

                string prefijo = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PREFIJO_BODEGAS_PUNTO_VENTA);
                string prefijoPV = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PREFIJO_ARTICULO_PUNTOVENTA);
                string tipoSolicitudId = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PURCHASE_ORDER_TYPE_ID);

                if (prefijo == whsCodePlanta.Split("-")[0] && tipoSolicitud != tipoSolicitudId)//Si es punto de venta se retornan todos los artículos pt-ptd
                {
                    articulosBodega = dAArticulos.ObtenerTodosArticulosxBodegaPlantas(whsCodePuntoVenta);
                }
                else
                {
                    //Se debe validar el prefijo PV para que entre acá también
                    articulosBodega = dAArticulos.ObtenerTodosArticulosxBodega(desde, hasta, whsCodePuntoVenta, whsCodePlanta, tipoSolicitud, tipoSolicitudId);
                }

                if (articulosBodega == null)
                {
                    EVOException e = new EVOException(errores.errArticuloBodegaNoRegistrado);

                    logger.Error(e);

                    throw e;
                }

                foreach (ArticuloBodega articulo in articulosBodega)
                {
                    if (articulo.Maximo != null && articulo.Stock != null)
                    {
                        articulo.PedidoSugerido = articulo.Minimo - articulo.Stock;
                        articulo.PedidoSugerido = articulo.PedidoSugerido <= 0 ? 0 : articulo.PedidoSugerido;
                    }
                }

            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return articulosBodega;
        }

        /// <summary>
        /// Este método obtiene el conteo de todos los registros 
        /// </summary>
        /// <param name="whsCode">Indica el valor del código de la bodega</param>
        /// <returns>Número de todos los registros</returns>
        public int ObtenerConteoTodosRegistros(string whsCode, string whsCodePlanta, string tipoSolicitud)
        {

            if (string.IsNullOrEmpty(whsCode))
            {
                EVOException e = new EVOException(errores.errSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(whsCodePlanta))
            {
                EVOException e = new EVOException(errores.errSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(tipoSolicitud))
            {
                EVOException e = new EVOException(errores.errTipoSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerConteoTodosRegistros de BLArticulos con el parámetro whsCode = {whsCode}");

            DAArticulo dAArticulos = new DAArticulo();

            int nRegistros = 0;

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            try
            {
                string prefijo = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PREFIJO_BODEGAS_PUNTO_VENTA);

                if (tipoSolicitud.Equals("1"))
                {
                    if (prefijo == whsCodePlanta.Split("-")[0])//Si es punto de venta se retornan todos los artículos pt-ptd
                    {
                        object result = dAArticulos.ObtenerConteoTodosRegistrosPlantas(whsCode, tipoSolicitud);

                        if (result != null)
                        {
                            nRegistros = int.Parse(result.ToString());
                        }
                    }
                    else
                    {
                        object result = dAArticulos.ObtenerConteoTodosRegistros(whsCode, whsCodePlanta); //Si es punto de venta se retornan todos los artículos pt o PTD

                        if (result != null)
                        {
                            nRegistros = int.Parse(result.ToString());
                        }
                    }
                }
                else
                {
                    object result = dAArticulos.ObtenerConteoTodosRegistrosCompras(whsCode);

                    if (result != null)
                    {
                        nRegistros = int.Parse(result.ToString());
                    }
                }


            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene todos los estados de los artículos
        /// </summary>
        /// <returns>Lista de todos los estados del artículo</returns>
        public List<BOEstadoArticulo> ObtenerTodosEstados()
        {
            logger.Info("Entró al método ObtenerTodosEstados en BLArticulo sin parámetros");

            DAArticulo dAArticulos = new DAArticulo();

            List<BOEstadoArticulo> estadosArticulo = new List<BOEstadoArticulo>();

            try
            {
                estadosArticulo = dAArticulos.ObtenerTodosEstados();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return estadosArticulo;
        }

        /// <summary>
        /// Obtiene las acciones de un artículo
        /// </summary>        
        public List<Accion> ObtenerAcciones()
        {
            logger.Info("Entró al método ObtenerAcciones en BLArticulo sin parámetros");

            DAArticulo dAArticulos = new DAArticulo();

            List<Accion> accionArticulo = new List<Accion>();

            try
            {
                accionArticulo = dAArticulos.ObtenerAcciones();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return accionArticulo;
        }

        ///// <summary>
        ///// Obtiene las acciones de un artículo
        ///// </summary>        
        //public List<Accion> ObtenerAcciones()
        //{
        //    logger.Info("Entró al método ObtenerAcciones en BLArticulo sin parámetros");

        //    DAArticulo dAArticulos = new DAArticulo();

        //    List<Accion> accionArticulo = new List<Accion>();

        //    try
        //    {
        //        accionArticulo = dAArticulos.ObtenerAcciones();
        //    }
        //    catch (Exception e)
        //    {
        //        logger.Error(e);

        //        throw e;
        //    }

        //    return accionArticulo;
        //}

        /// <summary>
        /// Este método obtiene todo los artículos
        /// </summary>
        /// <returns>Lista de todos los artículos</returns>
        public List<BOArticulo> ObtenerTodosArticulos()
        {
            logger.Info("Entró al método ObtenerTodosArticulos en BLArticulo sin parámetros");

            DAArticulo dAArticulos = new DAArticulo();

            List<BOArticulo> articulos = new List<BOArticulo>();

            try
            {
                articulos = dAArticulos.ObtenerTodosArticulos();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (articulos == null)
            {
                EVOException e = new EVOException(errores.errArticuloNoExiste);

                logger.Error(e);

                throw e;
            }

            return articulos;
        }

        /// <summary>
        /// Este método obtiene todo los artículos del punto de venta
        /// </summary>
        /// <param name="codigoPuntoVenta">Indica el valor del código del punto de venta</param>
        /// <returns>Lista de todos los artículos del punto de venta</returns>
        public List<BOArticulo> ObtenerTodosArticulosxPuntoVenta(string codigoPuntoVenta)
        {
            logger.Info($"Entró al método ObtenerTodosArticulosxPuntoVenta en BLArticulo con el parámetro codigoPuntoVenta = {codigoPuntoVenta}");

            if (string.IsNullOrEmpty(codigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();

            BOBodega bOBodega = bLBodega.ObtenerBodegaPorCodigo(codigoPuntoVenta);

            DAArticulo dAArticulos = new DAArticulo();

            List<BOArticulo> articulos = new List<BOArticulo>();

            try
            {
                articulos = dAArticulos.ObtenerTodosArticulosxPuntoVenta(codigoPuntoVenta);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return articulos;
        }

        /// <summary>
        /// Este método actualiza el artículo en la bodega
        /// </summary>
        /// <param name="articuloBodega">Objeto de negocio de tipo ArticuloBodega</param>      
        /// <returns>bool</returns>
        public bool ActualizarArticuloBodega(ArticuloBodega articuloBodega)
        {
            if (articuloBodega == null)
            {
                EVOException e = new EVOException(errores.errArticuloBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ActualizarArticuloBodega en BLArticulo con el parámetro articuloBodega = {JsonConvert.SerializeObject(articuloBodega)}");

            if (string.IsNullOrEmpty(articuloBodega.CodigoArticulo))
            {
                EVOException e = new EVOException(errores.errArticuloBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(articuloBodega.WhsCode))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            if (articuloBodega.Stock == null)
            {
                EVOException e = new EVOException(errores.errArticuloBodegaStockNoInformado);

                logger.Error(e);

                throw e;
            }


            DAArticulo dAArticulo = new DAArticulo();

            try
            {
                dAArticulo.ActualizarArticuloBodega(articuloBodega);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;
        }

        /// <summary>
        /// Este método obtiene los artículos por el código de la bodega y por el código del artículo
        /// </summary>
        /// <param name="codigoBodega">Indica el valor del parametro del código de la bodega</param>
        /// <param name="codigoArticulo">Indica el valor del parametro del artículo</param>
        /// <returns>El artículo por el código de la bodega y el código del artículo</returns>
        public ArticuloBodega ObtenerArticuloxCodigoBodegaCodigoArticulo(string codigoBodega, string codigoArticulo)
        {
            if (string.IsNullOrEmpty(codigoBodega))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(codigoArticulo))
            {
                EVOException e = new EVOException(errores.errCodigoArticuloNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerArticuloxCodigoBodegaCodigoArticulo con los parámetros codigoBodega = {codigoBodega} , codigoArticulo = {codigoArticulo}");

            DAArticulo dAArticulos = new DAArticulo();

            ArticuloBodega articuloBodega = null;

            try
            {
                articuloBodega = dAArticulos.ObtenerArticuloxCodigoBodegaCodigoArticulo(codigoBodega, codigoArticulo);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (articuloBodega == null)
            {
                EVOException e = new EVOException(errores.errArticuloBodegaNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return articuloBodega;

        }

        /// <summary>
        /// Este método obtiene los artículo por la bodega
        /// </summary>
        /// <param name="buscarArticulo">Indica el valor del parametro por el cual se va a realizar la busqueda</param>
        /// <returns>El artículo de la bodega</returns>
        public List<ArticuloBodega> ObtenerArticulosBodega(BuscarArticuloBodegaSolicitud buscarArticulo)
        {
            if (buscarArticulo == null)
            {
                EVOException e = new EVOException(errores.errBuscarArticuloNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosArticulosxFiltro con los parámetros; {0}",
                JsonConvert.SerializeObject(buscarArticulo)));

            if (string.IsNullOrEmpty(buscarArticulo.CodigoBodega))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            if (buscarArticulo.TipoSolicitud == 0)
            {
                EVOException e = new EVOException(errores.tipoSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            if (buscarArticulo.TipoSolicitud == 0)
            {
                EVOException e = new EVOException(errores.tipoSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            BLParametroGeneral bLParametroGenerales = new BLParametroGeneral();

            if (string.IsNullOrEmpty(buscarArticulo.PrefijoCodigoArticulo))
            {
                buscarArticulo.PrefijoCodigoArticulo = bLParametroGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PREFIJO_ARTICULO_PLANTAS);
                buscarArticulo.PrefijoArticuloPV = bLParametroGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PREFIJO_ARTICULO_PUNTOVENTA);
            }
            else
            {
                string prefijos = bLParametroGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PREFIJOS_ARTICULO_PLANTAS);

                if (prefijos.Split(",").ToList().FirstOrDefault(p => p == buscarArticulo.PrefijoCodigoArticulo) == null)
                {
                    EVOException e = new EVOException(errores.errPrefijoArticuloPlantaNoRegistrado);

                    logger.Error(e);

                    throw e;
                }
            }


            DAArticulo dAArticulos = new DAArticulo();

            List<ArticuloBodega> articuloBodega = null;

            try
            {

                string prefijosArticulosComprasList = bLParametroGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PREFIJOS_ARTICULOS_COMPRAS);
                buscarArticulo.PrefijosArticulosCompras = prefijosArticulosComprasList.Split(",").ToList();


                articuloBodega = dAArticulos.ObtenerArticulosBodegaxCodigoNombreArticulo(buscarArticulo);

                foreach (ArticuloBodega articulo in articuloBodega)
                {
                    if (articulo.Maximo != null && articulo.Stock != null)
                    {
                        articulo.PedidoSugerido = articulo.Minimo - articulo.Stock;
                        articulo.PedidoSugerido = articulo.PedidoSugerido <= 0 ? 0 : articulo.PedidoSugerido;
                    }
                }
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

            return articuloBodega;
        }


        /// <summary>
        /// Este método retorna los empaques
        /// </summary>       
        /// <returns>List<BOEmpaque></returns>
        public List<BOEmpaque> ObtenerEmpaques()
        {
            logger.Info("Entró al método ObtenerEmpaques en EVO_WebApi - BLArticulo sin parámetros");

            DAArticulo dAArticulos = new DAArticulo();

            List<BOEmpaque> empaques = null;

            try
            {
                empaques = dAArticulos.ObtenerEmpaques();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (empaques==null)
            {
                EVOException e = new EVOException(errores.errEmpaquesNoInformados);

                logger.Error(e);

                throw e;
            }

            return empaques;
        }
        #endregion
    }
}