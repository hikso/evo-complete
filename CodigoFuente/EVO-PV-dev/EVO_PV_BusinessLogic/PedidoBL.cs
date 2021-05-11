using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Enum;
using EVO_PV_BusinessObjects.Exceptions;
using EVO_PV_Proxy;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVO_PV_BusinessLogic
{
    /// <summary>
    /// 
    /// </summary>
    public class PedidoBL
    {
        #region Campos Privados
        PedidoProxy pedidoProxy = new PedidoProxy();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos Públicos
        public async Task<string> ActualizarPedido(Pedido pedido)
        {
            try
            {
                var respuestaEVO = pedidoProxy.ActualizarPedido(pedido);
                if (respuestaEVO != string.Empty)
                {

                    BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

                    ParametroGeneral bOParametroGeneral = await bLParametroGeneral.ObtenerParametroGeneralXNombre(NombresParametrosGeneralesEnum.PURCHASE_ORDER_TYPE_ID.ToString());

                    //AHolguin-13Agosto2020: Se invoca SAP y valida TipoSolicitud que sea compra
                    //if (pedido.TipoSolicitudId == int.Parse(bOParametroGeneral.Valor) && pedido.EstadoPedido == "Abierto")
                    //{
                    //    BOSerieResponse series = this.pedidoProxy.ObtenerSerie(pedido.WhsCode);
                    //    if (series != null)
                    //    {
                    //        pedido.FechaPedido = DateTime.Now;
                    //        pedido.Series = series.Series;
                    //        PedidosProxy pedidoProxy = new PedidosProxy();
                    //        logger.Info($"Antes de enviar SAP con parámetros  { JsonConvert.SerializeObject(pedido)}");
                    //        string respuestaSAP = await pedidoProxy.EnviarPedido(pedido);
                    //        logger.Info($"Respuesta de SAP - CrearPedido = {respuestaSAP}");
                    //    }

                    //}

                }
                return respuestaEVO;
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroPedido"></param>
        /// <returns></returns>
        public string ObtenerNumeroPedido(NumeroPedido numeroPedidos)
        {
            return pedidoProxy.ObtenerNumeroPedido(numeroPedidos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <param name="whscode"></param>
        /// <returns></returns>
        public ObtenerPedidos ObtenerTodosPedidos(int desde, int hasta, string whscode)
        {
            return pedidoProxy.ObtenerTodosPedidos(desde, hasta, whscode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<EstadoPedido> ObtenerTodosEstadosPedido()
        {
            return pedidoProxy.ObtenerTodosEstadosPedido();
        }

        /// <summary>
        /// Cancelar un pedido
        /// </summary>
        /// <param name="body">Solicitud de cancelación de pedido</param>
        /// <response>bool</response>
        public bool CancelarPedido(BOCancelarPedidoRequest cancelar)
        {
            logger.Info($"Entró al método CancelarPedido en EVO_PV_WebApi - PedidoBL con los parametros cancelar = {JsonConvert.SerializeObject(cancelar)}");

            return pedidoProxy.CancelarPedido(cancelar);
        }

        /// <summary>
        /// Editar un pedido
        /// </summary>
        /// <param name="boPedido">Solicitud de edición de pedido</param>
        /// <response>Boolean</response>
        public bool EditarPedido(BOEditarPedidoRequest boPedido)
        {
            logger.Info($"Entró al método EditarPedido en EVO_PV_WebApi - PedidoBL con los parametros body = {JsonConvert.SerializeObject(boPedido)}");

            return pedidoProxy.EditarPedido(boPedido);
        }

        /// <summary>
        /// Retorna el detalle del pedido
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <response>BOPedidoConsultaResponse</response>
        public BOPedidoConsultaResponse ObtenerConsultaPedido(int pedidoId)
        {
            logger.Info($"Entró el método ObtenerConsultaPedido en EVO_PV_WebApi - PedidoBL con el parametro pedidoId = {pedidoId}");

            return pedidoProxy.ObtenerConsultaPedido(pedidoId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HabilitarSolicitudPedido(string codigoCliente)
        {
            return pedidoProxy.HabilitarSolicitudPedido(codigoCliente);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<EstadoPedido> ObtenerCantidadxEstadosPedido()
        {
            return pedidoProxy.ObtenerCantidadxEstadosPedido();
        }

        public ObtenerTodosPedidosDistribucion ObtenerTodosPedidosADistribucion(int desde, int hasta)
        {
            return pedidoProxy.ObtenerTodosPedidosADistribucion(desde, hasta);
        }

        public bool ObtenerPedidoBorradorRequest(ObtenerPedidoBorrador obtenerPedidoBorrador)
        {
            return pedidoProxy.ObtenerPedidoBorradorRequest(obtenerPedidoBorrador);
        }


        public Pedido ObtenerPedidoPorId(int id)
        {
            return pedidoProxy.ObtenerPedidoPorId(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        public async Task<string> CrearPedido(Pedido pedido)
        {
            try
            {
                //TODO: logger.info("Ingresó al método CrearPedido con los parámetros json(pedido)
                var respuestaEVO = this.pedidoProxy.CrearPedido(pedido);

                //bool respuesta = String.IsNullOrEmpty(respuestaEVO);

                if (respuestaEVO != string.Empty)
                {

                    BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

                    ParametroGeneral bOParametroGeneral = await bLParametroGeneral.ObtenerParametroGeneralXNombre(NombresParametrosGeneralesEnum.PURCHASE_ORDER_TYPE_ID.ToString());

                    //AHolguin-13Agosto2020: Se invoca SAP y valida TipoSolicitud que sea compra             


                    //if (pedido.TipoSolicitudId == int.Parse(bOParametroGeneral.Valor) && pedido.EstadoPedido == "Abierto")
                    //{
                    //    BOSerieResponse series = this.pedidoProxy.ObtenerSerie(pedido.WhsCode);
                    //    if (series != null)
                    //    {
                    //        pedido.FechaPedido = DateTime.Now;
                    //        pedido.Series = series.Series;
                    //        PedidosProxy pedidoProxy = new PedidosProxy();
                    //        logger.Info($"Antes de enviar SAP con parámetros  { JsonConvert.SerializeObject(pedido)}");
                    //        string respuestaSAP = await pedidoProxy.EnviarPedido(pedido);
                    //        logger.Info($"Respuesta de SAP - CrearPedido = {respuestaSAP}");
                    //    }

                    //}

                }
                return respuestaEVO;
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param id="id"></param>
        /// <returns></returns>
        public async Task<ConsultaPedidoRespuesta> ObtenerConsultaPedidoId(int id)
        {
            //TODO: logger.info("Ingresó al método CrearPedido con los parámetros json(pedido)
            var respuestaEVO = await this.pedidoProxy.ObtenerConsultaPedidoId(id);

            return respuestaEVO;
        }

        /// <summary>
        /// Verifica que actualmente existan solicitudes en estado borrador en cada planta
        /// </summary>
        /// <param name="desde"></param>       
        /// <returns>Booleano/returns>
        public bool ExisteSolicitudPlantasBorrador(string codigoPuntoVenta)
        {
            return this.pedidoProxy.ExisteSolicitudPlantasBorrador(codigoPuntoVenta);
        }
        #endregion
    }
}