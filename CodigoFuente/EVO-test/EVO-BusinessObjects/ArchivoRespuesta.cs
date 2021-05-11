using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Aholguin
    /// Fecha de Creación: 01-0ctb/2020
    /// Descripción      : Clase que representa un objeto de negocio de ArchivoRespuesta
    /// </summary>
    public class ArchivoRespuesta
    {

        /// <summary>
        /// Id del archivo
        /// </summary>
        /// <value>Id del archivo</value>    
        public int ArchivoId { get; set; }

        /// <summary>
        /// nombre del archivo cargado
        /// </summary>
        /// <value>nombre del archivo cargado</value>      
        public string NombreArchivo { get; set; }

        /// <summary>
        /// Fecha en la que se carrga el archivo
        /// </summary>
        /// <value>Fecha en la que se carrga el archivo</value> 
        public string FechaCarga { get; set; }

        /// <summary>
        /// Fecha inicial en la que se carga el archivo
        /// </summary>
        /// <value>Fecha inicial en la que se carga el archivo</value>    
        public string FechaInicial { get; set; }

        /// <summary>
        /// Fecha final en la que se carga el archivo
        /// </summary>
        /// <value>Fecha final en la que se carga el archivo</value>   
        public string FechaFinal { get; set; }

    }
}
