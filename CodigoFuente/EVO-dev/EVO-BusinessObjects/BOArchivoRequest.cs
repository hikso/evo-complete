namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 22-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de ArchivoRequest
    /// </summary>
    public class BOArchivoRequest
    {
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
        /// Extensión del archivo
        /// </summary>
        /// <value>Extensión del archivo</value>       
        public string ExtensionArchivo { get; set; }
    }
}
