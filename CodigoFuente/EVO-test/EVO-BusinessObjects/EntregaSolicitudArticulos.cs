namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 6-Feb/2020
    /// Descripción     : Clase que representa un objeto de negocio de solicitud para actualizar un artículo de la entrega
    /// </summary>
    public class EntregaSolicitudArticulos
    {
        /// <summary>
        /// Id del detalle de la entrega
        /// </summary>
        /// <value>Id del detalle de la entrega</value>
        public int DetalleEntregaId { get; set; }

        ///TODO: Agregar atributo código de artículo al yaml.
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>PT-1485</value>
        public string Codigo { get; set; }

        ///TODO: Agregar atributo código de artículo al yaml.
        /// <summary>
        /// Id estado artículo
        /// </summary>
        /// <value>1</value>
        public int IdEstadoArticulo { get; set; }

        /// <summary>
        /// Cantidad del artículo solicitada
        /// </summary>
        /// <value>Cantidad del artículo solicitada</value>    
        public decimal CantidadEntrega { get; set; }

        /// <summary>
        /// Cantidad aprobada
        /// </summary>
        /// <value>450000</value>    
        public decimal CantidadAprobada { get; set; }

        /// <summary>
        /// Cantidad pendiente
        /// </summary>
        /// <value>3426</value>    
        public decimal CantidadPendiente { get; set; }
    }
}
