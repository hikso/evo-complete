using EVO_BusinessObjects.Enum;
using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 11-Sep/2019
    /// Descripción      : Esta clase representa la programación de la integración 
    /// </summary>
    public class ProgramarEjecucionIntegracionSolicitud
    {
        /// <summary>
        /// 0 una vez a día , 1 frecuencia al día
        /// </summary>   
       
        public TiposProgramacionIntegracionEnum TipoProgramacion { get; set; }

        /// <summary>   
        /// Hora con minutos del día en que se ejecuta integración
        /// </summary>
        public string HoraEjecucionIntegracion { get; set; }

        /// <summary>   
        /// Hora del tipo de programación de Una vez al día
        /// </summary>
        public int Hora { get; set; }

        /// <summary>   
        /// Minuto del tipo de programación de Una vez al día
        /// </summary>
        public int Minuto { get; set; }       

        /// <summary>
        /// Minutos de frecuencia de la ejecución de la integración del tipo programación Frecuencia al día
        /// </summary>       

        public int Frecuencia { get; set; }

        /// <summary>
        /// Hora del día en que se empieza la integración del tipo programación Frecuencia al día
        /// </summary>     

        public string HoraInicio { get; set; }

        /// <summary>
        /// Hora del día en que empieza la integración del tipo programación Frecuencia al día
        /// </summary>

        public string HoraFin { get; set; }

        /// <summary>   
        /// Hora del día que finaliza la integración del tipo programación Frecuencia al día
        /// </summary>
        public int FechaInicioHora { get; set; }

        /// <summary>   
        /// Minuto del día que empieza la frecuencia de la ejecución de la integración del tipo de programación de Frecuencia al día
        /// </summary>
        public int FechaIncioMinuto { get; set; }

        /// <summary>   
        /// Hora del día que empieza la frecuencia de la ejecución de la integración del tipo de programación de Frecuencia al día
        /// </summary>
        public int FechaFinHora { get; set; }

        /// <summary>   
        /// Minuto del día que empieza la frecuencia de la ejecución de la integración del tipo de programación de Frecuencia al día
        /// </summary>
        public int FechaFinMinuto { get; set; }

        /// <summary>   
        /// Representa los parámetros del Job
        /// </summary>
        public JobParametros JobParametros { get; set; }
    }
}