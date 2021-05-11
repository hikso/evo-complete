using System;
using System.Collections.Generic;


namespace EVO_BusinessObjects
{ 
    /// <summary>
    /// Representa archivo enviado
    /// </summary>   
    public  class BOCargarArchivoRequest
    { 
        /// <summary>
        /// Fecha inicial carga
        /// </summary>
        /// <value>Fecha inicial carga</value>      
        public string FechaInicial { get; set; }

        /// <summary>
        /// Fecha final carga
        /// </summary>
        /// <value>Fecha final carga</value>     
        public string FechaFinal { get; set; }

        /// <summary>
        /// Archivo en base64
        /// </summary>
        /// <value>Archivo en base64</value>       
        public string Base64 { get; set; }

        /// <summary>
        /// Nombre del archivo
        /// </summary>
        /// <value>Nombre del archivo</value>       
        public string NombreArchivo { get; set; }

        /// <summary>
        /// separador decimal del archivo
        /// </summary>
        /// <value>separador decimal</value>       
        public string Separador { get; set; }

    }
}
