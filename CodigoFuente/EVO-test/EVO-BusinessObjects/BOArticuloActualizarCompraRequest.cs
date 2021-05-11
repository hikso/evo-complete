namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 4-Sep/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo ArticuloActualizarCompraRequest
    /// </summary>
    public class BOArticuloActualizarCompraRequest
    {
        /// <summary>
        /// Id del detalle de pedido
        /// </summary>
        /// <value>Id del detalle de pedido</value>        
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Cantidad a gestionar
        /// </summary>
        /// <value>Cantidad a gestionar</value>
       
        public string CantidadGestionar { get; set; }

        /// <summary>
        /// Id de la acción
        /// </summary>
        /// <value>Id de la acción</value>       
        public int AccionId { get; set; }
    }
}
