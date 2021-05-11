namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 7-Feb/2020
    /// Descripción     : Clase que representa un objeto de negocio de un artículo pendiente en una entrega
    /// </summary>
    public class ArticuloPendienteRespuesta
    {

        /// <summary>
        /// ID del estado del Artículo
        /// </summary>
        /// <value>ID del estado del Artículo</value>      
        public int IdEstadoArticulo { get; set; }

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
        /// Cantidad aprobada
        /// </summary>
        /// <value>Cantidad aprobada</value>       
        public string CantidadAprobada { get; set; }

        /// <summary>
        /// Cantidad pendiente
        /// </summary>
        /// <value>Cantidad pendiente</value>
       
        public string CantidadPendiente { get; set; }
       
    }
}
