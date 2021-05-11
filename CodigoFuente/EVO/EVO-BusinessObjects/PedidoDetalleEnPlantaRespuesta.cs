using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 5-Nov/2019
    /// Descripción      : Esta clase representa un detalle del pedido visto desde la planta beneficio
    /// </summary>
    public class PedidoDetalleEnPlantaRespuesta
    {

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
        /// Cantidad solicitada del articulo
        /// </summary>
        /// <value>Cantidad solicitada del articulo</value>       
        public decimal? CantidadSolicitada { get; set; }

        /// <summary>
        /// Unidad de medida del artículo
        /// </summary>
        /// <value>Unidad de medida del artículo</value>      
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Cantidad aprobada del artículo
        /// </summary>
        /// <value>Cantidad aprobada del artículo</value>        
        public decimal? CantidadAprobada { get; set; }

        /// <summary>
        /// Stock disponible
        /// </summary>
        /// <value>Stock disponible</value>      
        public decimal? StockDisponible { get; set; }

        /// <summary>
        /// Observación
        /// </summary>
        /// <value></value>      
      
        public string Observacion { get; set; }
    }
}
