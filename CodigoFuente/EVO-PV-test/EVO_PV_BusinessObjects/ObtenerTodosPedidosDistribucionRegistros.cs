
namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>

    public partial class ObtenerTodosPedidosDistribucionRegistros
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>

        public int PedidoId { get; set; }

        /// <summary>
        /// Código del pedido
        /// </summary>
        /// <value>Código del pedido</value>

        public string CodigoPedido { get; set; }

        /// <summary>
        /// Orden de compra (para clientes externos)
        /// </summary>
        /// <value>Orden de compra (para clientes externos)</value>

        public string OrdenCompra { get; set; }

        /// <summary>
        /// Fecha en la que se registra el pedido
        /// </summary>
        /// <value>Fecha en la que se registra el pedido</value>

        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Estado el pedido
        /// </summary>
        /// <value>Estado el pedido</value>

        public string Estado { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>

        public string Cliente { get; set; }

        /// <summary>
        /// Cantidad máxima de entregas
        /// </summary>
        /// <value>Cantidad máxima de entregas</value>

        public string Entregas { get; set; }

    }
}
