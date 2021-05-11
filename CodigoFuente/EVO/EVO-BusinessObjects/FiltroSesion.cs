namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 28-Ago/2019
    /// Descripción      : Esta clase contiene las propiedades de los filtros de sesión
    /// </summary>
    public class FiltroSesion
    {
        /// <summary>
        /// Indica desde que registro se debe cargar la consulta
        /// </summary>
        public int Desde { get; set; }

        /// <summary>
        /// Indica hasta que registro se debe cargar la consulta
        /// </summary>
        public int Hasta { get; set; }

        /// <summary>
        /// Indica el id la sesión
        /// </summary>
        public string SesionId { get; set; }

        /// <summary>
        /// Indica el filtro por usuario
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Indica el filtro por IP
        /// </summary>
        public string ÏP { get; set; }

        /// <summary>
        /// Indica el filtro por Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Indica el filtro de Fecha Inicio
        /// </summary>
        public string FechaInicio { get; set; }

        /// <summary>
        /// Indica el filtro por Fecha Expiracion
        /// </summary>
        public string FechaExpiracion { get; set; }
    }
}