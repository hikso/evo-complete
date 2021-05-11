namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 8-Dic/2019
    /// Descripción     : Clase que representa un objeto de respuesta de un detalle de entrega de un pedido
    /// </summary>
    public class EntregaDetalle
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
        /// Código Artículo
        /// </summary>
        /// <value>Código Artículo</value>
       
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Nombre Artículo
        /// </summary>
        /// <value>Nombre Artículo</value>
       
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Cantidad a enviar
        /// </summary>
        /// <value>Cantidad a enviar</value>
      
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Observación
        /// </summary>
        /// <value></value>       
        public string Observacion { get; set; }
    }
}
