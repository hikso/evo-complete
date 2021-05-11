namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 8-Dic/2019
    /// Descripción     : Clase que representa un objeto de respuesta de un detalle del pedido para la entrega
    /// </summary>
    public class EntregaArticulo
    {

        /// <summary>
        /// ID del estado del Artículo
        /// </summary>
        /// <value>ID del estado del Artículo</value>        
        public int IdEstadoArticulo { get; set; }

        /// <summary>
        /// Id del detalle del pedido
        /// </summary>
        /// <value>Id del detalle del pedido</value>

        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>
       
        public string Codigo { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>
      
        public string Nombre { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Estado del artículo</value>
      
        public string Estado { get; set; }

        /// <summary>
        /// Unidad de medida
        /// </summary>
        /// <value>Unidad de medida</value>
      
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Cantidad Aprobada
        /// </summary>
        /// <value>Cantidad Aprobada</value>
     
        public decimal CantidadAprobada { get; set; }

        /// <summary>
        /// Observación
        /// </summary>
        /// <value></value>        
        public string Observacion { get; set; }
    }
}
