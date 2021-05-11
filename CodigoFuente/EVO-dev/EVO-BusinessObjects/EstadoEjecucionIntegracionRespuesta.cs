using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 11-Sep/2019
    /// Descripción      : Esta clase representa el estado de la integración 
    /// </summary>
    public class EstadoEjecucionIntegracionRespuesta
    {
        /// <summary>
        /// Estado de la integración
        /// </summary>
        public bool IntegracionHabilitada { get; set; }

        /// </summary>
        /// Hora del día en que se ejecuta la integración
        /// </summary>
        public string HoraEjecucion { get; set; }

        /// <summary>
        /// Indica la fecha de deshabilitación de la integración de artículos
        /// </summary>       
       
        public DateTime FechaDeshabilitado { get; set; }

        /// <summary>
        /// Indica la frecuencia de la integración de artículos
        /// </summary>
        public int frecuencia { get; set; }

        /// <summary>
        /// Indica el tipo de programación de la integración de artículos
        /// </summary>
        public int TipoProgamacion { get; set; }

        /// <summary>
        /// Indica la hora de inicio de la integración de artículos
        /// </summary>
        public string HoraInicio { get; set; }

        /// <summary>
        /// Indica la hora de finalización de la integración de artículos
        /// </summary>
        public string HoraFin { get; set; }


    }
}
