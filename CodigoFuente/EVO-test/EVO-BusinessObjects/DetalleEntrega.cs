namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 10-Mar/2020
    /// Descripción     : Clase que representa un objeto de actualización de DetalleEntrega
    /// </summary>
    public class DetalleEntrega
    {
        /// <summary>
        /// Código del cliente
        /// </summary>
        public string ClienteCode { get; set; }

        /// <summary>
        /// Código del artículo
        /// </summary>
        public string ItemCode { get; set; }
        /// <summary>
        /// Id del detalleEntrega
        /// </summary>
        public int DetalleEntregaId { get; set; }
        /// <summary>
        /// Clave foránea de entrega
        /// </summary>
        public int EntregaId { get; set; }
        /// <summary>
        /// Clave foránea de detallePedido 
        /// </summary>
        public int DetallePedidoId { get; set; }
        /// <summary>
        /// Cantidad a entregar del artículo
        /// </summary>
        public decimal Cantidad { get; set; }

        public DetallePedido DetallePedido { get; set; }
        
    }
}
