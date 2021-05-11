using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 10-Sep/2019
    /// Descripción      : Esta clase representa los parámetros de un Job de SqlServer 
    /// </summary>
    public class JobParametros
    {
        /// <summary>   
        /// Nombre del Job
        /// </summary>
        public string NombreJob { get; set; }

        /// <summary>   
        /// Nombre de la programación del Job que ejecuta la integración de 
        /// </summary>
        public string NombreProgramacionJob { get; set; }

        /// <summary>   
        /// Nombre de la tarea del Job que ejecuta la integración de 
        /// </summary>
        public string NombreTareaJob { get; set; }

    }
}