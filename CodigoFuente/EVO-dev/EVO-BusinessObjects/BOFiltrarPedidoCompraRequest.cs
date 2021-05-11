namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 26-Ago/2020
    /// Descripción     : Clase que representa un objeto de negocio de FiltrarPedidoCompraRequest
    /// </summary>
    public class BOFiltrarPedidoCompraRequest
    {
        /// <summary>
        /// Indica el número de registro desde el cuál se deben obtener los registros
        /// </summary>
        /// <value>Indica el número de registro desde el cuál se deben obtener los registros</value>       
        public int Desde { get; set; }

        /// <summary>
        /// Indica el número de registro hasta el cuál se deben obtener los registros
        /// </summary>
        /// <value>Indica el número de registro hasta el cuál se deben obtener los registros</value>      
        public int Hasta { get; set; }

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
        public string EstadoPedido { get; set; }

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
    }
}
