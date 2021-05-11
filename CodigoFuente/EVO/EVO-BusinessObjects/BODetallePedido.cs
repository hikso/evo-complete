namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 20-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de Detalle Pedido
    /// </summary>
    public class BODetallePedido
    {
        /// <summary>
        /// Define la clave primaria del detalle de pedido
        /// </summary>        
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Define la clave foránea de Pedido
        /// </summary>        
        public int PedidoId { get; set; }

        /// <summary>
        /// Define el código del artículo
        /// </summary>        
        public string ItemCode { get; set; }

        /// <summary>
        /// Define la clave foránea del estado del artículo
        /// </summary>     
        public int EstadoArticuloId { get; set; }

        /// <summary>
        /// Define la cantidad a solicitar
        /// </summary>     
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Define la cantidad aprobada
        /// </summary>      
        public decimal? CantidadAprobada { get; set; }

        public BOEstadoArticulo EstadoArticulo { get; set; }

    }
}
