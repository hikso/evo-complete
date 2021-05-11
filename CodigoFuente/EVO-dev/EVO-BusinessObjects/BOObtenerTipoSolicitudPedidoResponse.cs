namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creacón: 09-Jul/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo ObtenerTipoSolicitudPedidoResponse
    /// </summary>
    public class BOObtenerTipoSolicitudPedidoResponse
    {
        /// <summary>
        /// Id del tipo de solicitud
        /// </summary>
        /// <value>Id del tipo de solicitud</value>      
        public int? TipoSolicitudId { get; set; }

        /// <summary>
        /// Nombre del tipo de solicitud
        /// </summary>
        /// <value>Nombre del tipo de solicitud</value>      
        public string TipoSolicitudNombre { get; set; }
    }
}
