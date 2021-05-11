namespace EVO_PV.Models.BusinessObjects
{
    /// <summary>
    /// Autor            : Gabriel Alfonso
    /// Fecha de Creación: 03-04-2020
    /// Descripción      : Esta clase representa un Documento adjunto de la inconsistencia
    /// </summary>
    public class BOInconsistenceFile
    {
        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FileExtension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Base64Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DocumentId { get; set; }
    }
}