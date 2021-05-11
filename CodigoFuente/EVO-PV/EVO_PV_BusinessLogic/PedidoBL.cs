using EVO_PV_BusinessObjects;
using EVO_PV_Proxy;
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
        #endregion

        #region Métodos Públicos
        public async Task<bool> ActualizaPedido(Pedido pedido)
        {
            return pedidoProxy.ActualizarPedido(pedido);
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

        public ConsultaPedidoRespuesta ObtenerConsultaPedidoxId(int id)
        {
            throw new NotImplementedException();
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
        public bool CrearPedido(Pedido pedido)
        {
            //TODO: logger.info("Ingresó al método CrearPedido con los parámetros json(pedido)
            var respuestaEVO = this.pedidoProxy.CrearPedido(pedido);

            return respuestaEVO;
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