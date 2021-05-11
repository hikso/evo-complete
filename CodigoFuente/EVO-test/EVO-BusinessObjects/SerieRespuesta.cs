using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    public class SerieRespuesta
    {
        /// <summary>
        /// Define la clave primaria de la serie
        /// </summary>
        public int SerieID { get; set; }

        /// <summary>
        /// Define el código de la serie
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Define el nombre de la serie
        /// </summary>
        public string SeriesName { get; set; }

        /// <summary>
        /// Define el número de documento inicial
        /// </summary>
        public string InitialNum { get; set; }

        /// <summary>
        /// Define el próximo número de documento
        /// </summary>
        public string NextNumber { get; set; }

        /// <summary>
        /// Define el último número de documento
        /// </summary>
        public string LastNum { get; set; }

        /// <summary>
        /// Define si la serie se encuentra activa o inactiva
        /// </summary>
        public bool Activo { get; set; }

    }
}
