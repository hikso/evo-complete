namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 18-Nov/2019
    /// Descripción      : Clase que representa un objeto de negocio de PedidoDespachoRespuesta
    /// </summary>
    public class PedidoDistribucionRespuesta
    {
        /// <summary>
        /// Indica el id del pedido
        /// </summary>
        public int PedidoId { get; set; }

        /// <summary>
        /// Indica el código de la bodega
        /// </summary>
        public string WhsCode { get; set; }

        /// <summary>
        /// Indica el código del pedido
        /// </summary>
        public string CodigoPedido { get; set; }

        /// <summary>
        /// Indica la fecha en la cual se realizo el pedido
        /// </summary>
        public string FechaSolicitud { get; set; }       

        /// <summary>
        /// Indica el estado del pedido
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Indica el cliente hacia quien va dirigido el pedido
        /// </summary>
        public string Cliente { get; set; }       

        /// <summary>
        /// Indica el número del pedido
        /// </summary>
        public int NumeroPedido { get; set; }

        /// <summary>
        /// Indica la cantidad de entregas del pedido
        /// </summary>
        public string Entregas { get; set; }

        /// <summary>
        /// Indica la orden de compra (solo para clientes externos)
        /// </summary>
        public string OrdenCompra { get; set; }

        /// <summary>
        /// Indica la zona del punto de venta o cliente externo
        /// </summary>
        public string Zona { get; set; }

    }

}
