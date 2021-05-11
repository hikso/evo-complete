using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 11-Sep/2019
    /// Descripción      : Esta clase representa la habilitación de la integración 
    /// </summary>
    public class HabilitarEjecucionIntegracionSolicitud
    {
        /// <summary>   
        /// Fecha del día en que se ejecuta integración
        /// </summary>
        public bool Habilitado { get; set; }

        /// <summary>   
        /// Representa los parámetros del Job
        /// </summary>
        public JobParametros JobParametros { get; set; }
    }
}