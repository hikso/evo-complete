namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 7-Dic/2019
    /// Descripción     : Clase que representa un objeto de detalle de entrega del pedido
    /// </summary>
    public class DetalleEntregaPedido
    {
        /// <summary>
        /// Id del detalle de la entrega
        /// </summary>
        /// <value>Id del detalle de la entrega</value>
        public int DetalleEntregaId { get; set; } 
        
        /// <summary>
        /// Id del detale el pedido
        /// </summary>
        /// <value>Id del detale el pedido</value>
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Cantidad a enviar
        /// </summary>
        /// <value>Cantidad a enviar</value>      
        public decimal Cantidad { get; set; }
        
    }
}
