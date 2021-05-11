namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 2-Mar/2020
    /// Descripción     : Clase que representa el artículo en alistamiento
    /// </summary>
    public class ArticuloPesajeRespuesta
    {
        /// <summary>
        /// Id del detalle de entrega
        /// </summary>
        /// <value>C5</value>       
        public int DetalleEntregaId { get; set; }

        /// <summary>
        /// Código de el artículo
        /// </summary>
        /// <value>Código de el artículo</value>       
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Nombre de el producto
        /// </summary>
        /// <value>Nombre de el producto</value>       
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Estado del artículo</value>       
        public string Estado { get; set; }

        /// <summary>
        /// Cantidad de entrega del artículo
        /// </summary>
        /// <value>Cantidad de entrega del artículo</value>      
        public decimal CantidadEntrega { get; set; }

        /// <summary>
        /// Cantidad aprobada en comercial
        /// </summary>
        /// <value>345</value>      
        public decimal CantidadAprobada { get; set; }

        /// <summary>
        /// Cantidad solicitada en el pedido
        /// </summary>
        /// <value>345</value>      
        public decimal CantidadSolicitada { get; set; }

        /// <summary>
        /// Cantidad recibida
        /// </summary>
        /// <value>345</value>      
        public decimal CantidadRecibida { get; set; }

        /// <summary>
        /// Cantidad enviada del artículo
        /// </summary>
        /// <value>345</value>      
        public decimal CantidadEnviada{ get; set; }

        /// <summary>
        /// Cantidad de pendiente del artículo
        /// </summary>
        /// <value>Cantidad de pendiente del artículo</value>      
        public decimal CantidadPendiente { get; set; }

        /// <summary>
        /// Unidad de medida del artículo
        /// </summary>
        /// <value>Unidad de medida del artículo</value>        
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Pesaje finalizo
        /// </summary>
        /// <value>True</value>        
        public bool PesajeFinalizado { get; set; }
    }
}
