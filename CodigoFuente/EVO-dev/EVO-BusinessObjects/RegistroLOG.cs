using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Kevin Restrepo
    /// Fecha de Creación: 09-Sep/2019
    /// Descripción      : Esta clase representa un Registro de Log
    /// </summary>
    public class RegistroLOG
    {

        /// <summary>
        /// Mensaje del log
        /// </summary>
        /// <value>Mensaje del log</value>
        public string Message { get; set; }

        /// <summary>
        /// Lista descripciónes de errores
        /// </summary>
        /// <value>Lista adicciones</value>
        public List<string> Additional { get; set; }

        /// <summary>
        /// Nivel del log
        /// </summary>
        /// <value>Nivel del log</value>
        public int Level { get; set; }

        /// <summary>
        /// Indica la fecha del log
        /// </summary>
        /// <value>Indica la fecha del log</value>
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Nombre del archivo
        /// </summary>
        /// <value>Nombre del archivo</value>
        public string FileName { get; set; }

        /// <summary>
        /// Linea del archivo
        /// </summary>
        /// <value>Linea del archivo</value>
        public string LineNumber { get; set; }
    }
}