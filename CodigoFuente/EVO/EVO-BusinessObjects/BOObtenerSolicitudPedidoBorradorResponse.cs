namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 07-Jul/2020
    /// Descripción      : Clase que representa un objeto de negocio de tipo ObtenerSolicitudPedidoBorradorResponse
    /// </summary>
    public class BOObtenerSolicitudPedidoBorradorResponse
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>       
        public int? PedidoId { get; set; }

        /// <summary>
        /// Fecha de la solicitud
        /// </summary>
        /// <value>Fecha de la solicitud</value>
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Fecha limite de la solicitud
        /// </summary>
        /// <value>Fecha limite de la solicitud</value>      
        public string FechaLimiteSolicitud { get; set; }

        /// <summary>
        /// Estado de la solicitud
        /// </summary>
        /// <value>Estado de la solicitud</value>      
        public string EstadoPedido { get; set; }

        /// <summary>
        /// Fecha de la solicitud
        /// </summary>
        /// <value>Fecha de la solicitud</value>      
        public string SolicitudA { get; set; }

        /// <summary>
        /// Días para la entrega
        /// </summary>
        /// <value>Días para la entrega</value>       
        public string DiasEntrega { get; set; }
    }
}
