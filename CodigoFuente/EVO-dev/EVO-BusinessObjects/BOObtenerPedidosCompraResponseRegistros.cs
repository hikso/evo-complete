namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 26-Ago/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo ObtenerPedidosCompraResponseRegistros
    /// </summary>
    public class BOObtenerPedidosCompraResponseRegistros
    {
        /// <summary>
        /// Indica el id del pedido
        /// </summary>
        /// <value>Indica el id del pedido</value>       
        public int PedidoId { get; set; }

        /// <summary>
        /// Indica el número del pedido
        /// </summary>
        /// <value>Indica el número del pedido</value>       
        public string NumeroPedido { get; set; }

        /// <summary>
        /// Fecha solicitud del pedido
        /// </summary>
        /// <value>Fecha solicitud del pedido</value>      
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Fecha limite sugerida del pedido
        /// </summary>
        /// <value>Fecha limite sugerida del pedido</value>       
        public string FechaLimiteSugerida { get; set; }

        /// <summary>
        /// Indica el estado del pedido
        /// </summary>
        /// <value>Indica el estado del pedido</value>       
        public string Estado { get; set; }

        /// <summary>
        /// Nombre del cliente que solicitó el pedido
        /// </summary>
        /// <value>Nombre del cliente que solicitó el pedido</value>      
        public string Cliente { get; set; }

        /// <summary>
        /// Días que faltan para la entrega del pedido
        /// </summary>
        /// <value>Días que faltan para la entrega del pedido</value>       
        public string DiasEntrega { get; set; }

        public bool EditarPedido { get; set; }
        
    }
}
