namespace EVO_BusinessObjects
{

    /// <summary>
    /// Autor            : Duban Cardona
    /// Fecha de Creación: 30-Sep/2019
    /// Descripción      : Clase que representa un objeto de negocio de PedidoRespuesta
    /// </summary>
    public class PedidoRespuesta
    {
        /// <summary>
        /// Indica el id del pedido
        /// </summary>
        public int PedidoId { get; set; }

        /// <summary>
        /// Indica el código del pedido
        /// </summary>
        public string CodigoPedido { get; set; }

        /// <summary>
        /// Indica la fecha en la que se realizo la fecha de solicitud del pedido
        /// </summary>
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Indica la fecha de entrega del pedido
        /// </summary>
        public string FechaEntrega { get; set; }

        /// <summary>
        /// Indica el estado del pedido
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Indica la plantas existentes para el pedido
        /// </summary>
        public string Planta { get; set; }

        /// <summary>
        /// Indica los días de entrega del pedido
        /// </summary>
        public string DiasEntrega { get; set; }

        /// <summary>
        /// Indica el número del pedido
        /// </summary>
        public int? NumeroPedido { get; set; }

        /// <summary>
        /// Indica el código de la planta
        /// </summary>
        public string WhsCode { get; set; }
    }
}
