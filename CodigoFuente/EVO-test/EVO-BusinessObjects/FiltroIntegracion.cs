using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Duban Cardona
    /// Fecha de Creación: 20-Ago/2019
    /// Descripción      : Esta clase contiene las propiedades del FiltroIntegracion
    /// </summary>
    public class FiltroIntegracion
    {
        /// <summary>
        /// Indica del id del job.
        /// </summary>

        public string jobId;

        /// <summary>
        /// Indica desde que registro se debe cargar la consulta
        /// </summary>
        public int Desde { get; set; }

        /// <summary>
        /// Indica hasta que registro se debe cargar la consulta
        /// </summary>
        public int Hasta { get; set; }


        /// <summary>
        /// Estado de la integración
        /// </summary>      
        public bool? Estado { get; set; }

        /// <summary>
        /// Indica la fecha de inicio de la integración de artículos
        /// </summary>
       
        public string FechaInicio { get; set; }

        /// <summary>
        /// Indica la fecha de finalización de la integración de artículos
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
