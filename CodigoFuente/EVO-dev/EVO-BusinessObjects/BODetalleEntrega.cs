namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 20-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de Detalle Entrega
    /// </summary>
    public class BODetalleEntrega
    {
        /// <summary>
        /// Define la clave primaria del detalle de la entrega del pedido
        /// </summary>     
        public int DetalleEntregaId { get; set; }
        /// <summary>
        /// Define la clave foránea a Entregas
        /// </summary>      
        public int EntregaId { get; set; }

        /// <summary>
        /// Define la clave foránea a DetallePedidos
        /// </summary>       
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Define la cantidad a entregar
        /// </summary>       
        public decimal Cantidad { get; set; }

        public BODetallePedido DetallePedido { get; set; }

    }
}
