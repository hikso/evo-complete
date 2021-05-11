namespace EVO_BusinessObjects
{
    public class BODetalleEvidencia
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>      
        public int DetalleEvidenciaId { get; set; }

        /// <summary>
        /// Define la clave foránea de Evidencias
        /// </summary>    
        public int EvidenciaId { get; set; }       

        /// <summary>
        /// Define nombre del archivo
        /// </summary>     
        public string NombreArchivo { get; set; }

        /// <summary>
        /// Extension del archivo
        /// </summary>      
        public string ExtensionArchivo { get; set; }
    }
}
