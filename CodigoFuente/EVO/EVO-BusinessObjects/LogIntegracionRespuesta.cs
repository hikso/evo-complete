namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 12-Sep/2019
    /// Descripción      : Esta clase representa un log de respuesta de la integración
    /// </summary>
    public class LogIntegracionRespuesta
    {
        /// <summary>
        /// Estado de la integración
        /// </summary>       
        public bool Estado { get; set; }

        /// <summary>
        /// Indica la fecha de inicio de la integración 
        /// </summary>       
        public string FechaInicio { get; set; }

        /// <summary>
        /// Indica la fecha de finalización de la integración
        /// </summary>       
    
        public string FechaFin { get; set; }

        /// <summary>
        /// Indica el log del Job
        /// </summary>
       
        public string LogJob { get; set; }

        /// <summary>
        /// Indica el log de la integración
        /// </summary>
       
        public string LogIntegracion { get; set; }      

    }
}
