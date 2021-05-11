namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 17-Dic/2019
    /// Descripción     : Clase que representa una entrega de pedido en distribución
    /// </summary>
    public class EntregaEnrutamientoRespuesta
    {
        /// <summary>
        /// Id de entrega
        /// </summary>
        /// <value>Id de entrega</value>     
        public int EntregaId { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>      
        public string Cliente { get; set; }

        /// <summary>
        /// Código del pedido
        /// </summary>
        /// <value>Código del pedido</value>      
        public string CodigoPedido { get; set; }

        /// <summary>
        /// Número de la entrega
        /// </summary>
        /// <value>Número de la entrega</value>        
        public string NumeroEntrega { get; set; }

        /// <summary>
        /// Fecha de laentrega
        /// </summary>
        /// <value>Fecha de laentrega</value>       
        public string FechaEntrega { get; set; }

        /// <summary>
        /// Horaentrega
        /// </summary>
        /// <value>Horaentrega</value>       
        public string HoraEntrega { get; set; }

        /// <summary>
        /// Peso de la entrega
        /// </summary>
        /// <value>Peso de la entrega</value>        
        public decimal Peso { get; set; }

        /// <summary>
        /// Indica la zona del punto de venta o cliente externo
        /// </summary>
        /// <value>Indica la zona del punto de venta o cliente externo</value>       
        public string Zona { get; set; }
    }
}
