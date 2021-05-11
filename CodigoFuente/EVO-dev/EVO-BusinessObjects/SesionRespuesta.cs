namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 27-Ago/2019
    /// Descripción      : Esta clase representa una Sesión de solicitud del usuario para la vista general
    /// </summary>
    public class SesionRespuesta
    {
        /// <summary>
        /// SesionId de la sesión
        /// </summary>
        public string SesionId { get; set; }
        /// <summary>
        /// IP de la sesión
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// Token de la sesión
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Usuario de la sesión
        /// </summary>
        public string Usuario { get; set; }
        /// <summary>
        /// FechaInicio de la sesión
        /// </summary>
        public string FechaInicio { get; set; }
        /// <summary>
        /// FechaExpiracion de la sesión
        /// </summary>
        public string FechaExpiracion { get; set; }
        /// <summary>
        /// Estado de la sesión
        /// </summary>
        public bool Activa { get; set; }
    }
}
