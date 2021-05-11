namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 20-Mar/2020
    /// Descripción     : Clase que representa un objeto de artículo recepción respuesta
    /// </summary>
    public class ArticuloRecepcionRespuesta
    {
        /// <summary>
        /// Id del Artículo Pesaje
        /// </summary>
        /// <value>1</value>      
        public int PesajeArticuloId { get; set; }

        /// <summary>
        /// Id del detalle de la entrega
        /// </summary>
        /// <value>Id del detalle de la entrega</value>        
        public int DetalleEntregaId { get; set; }

        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>        
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>       
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Estado del artículo</value>     
        public string EstadoArticulo { get; set; }

        /// <summary>
        /// Cantidad solicitada
        /// </summary>
        /// <value>Cantidad solicitada</value>      
        public decimal CantidadSolicitada { get; set; }

        /// <summary>
        /// Cantidad aprobada
        /// </summary>
        /// <value>Cantidad aprobada</value>       
        public decimal CantidadAprobada { get; set; }

        /// <summary>
        /// Cantidad enviada
        /// </summary>
        /// <value>Cantidad enviada</value>       
        public decimal CantidadEnviada { get; set; }

        /// <summary>
        /// Cantidad recibida
        /// </summary>
        /// <value>Cantidad recibida</value>       
        public decimal CantidadRecibida { get; set; }

        /// <summary>
        /// Unidad de medida
        /// </summary>
        /// <value>Unidad de medida</value>        
        public string UnidadMedida { get; set; }       

    }
}
