namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 28-Ago/2020
    /// Descripción     : Clase que representa un objeto de ArticuloCompraRequest
    /// </summary>
    public class BOArticuloCompraRequest
    {
        /// <summary>
        /// Id del detalle de pedido
        /// </summary>
        /// <value>Id del detalle de pedido</value>      
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>

        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Cantidad a gestionar
        /// </summary>
        /// <value>Cantidad a gestionar</value>

        public string CantidadGestionar { get; set; }

        /// <summary>
        /// Stock actual del almacen
        /// </summary>
        /// <value>Stock actual del almacen</value>

        public string StockActual { get; set; }
    }
}
