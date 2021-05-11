namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 18-Sep/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo ArticuloTrasladoRequest
    /// </summary>
    public class BOArticuloTrasladoRequest
    {
        /// <summary>
        /// Id del detalle del pedido
        /// </summary>
        /// <value>Id del detalle del pedido</value>
       
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Id del estado del artículo
        /// </summary>
        /// <value>Id del estado del artículo</value>
       
        public int EstadoArticuloId { get; set; }

        /// <summary>
        /// Id del tipo de empaque
        /// </summary>
        /// <value>Id del tipo de empaque</value>
       
        public int EmpaqueId { get; set; }

        /// <summary>
        /// Cantidad del artículo aprobada
        /// </summary>
        /// <value>Cantidad del artículo aprobada</value>
       
        public string CantidadAprobada { get; set; }
    }
}
