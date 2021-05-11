namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 02-Abr/2020
    /// Descripción     : Clase que representa un objeto de negocio de un Documento
    /// </summary>
    public class BODocumento
    {
        /// <summary>
        /// Se define la clave primaria
        /// </summary>
        public int DocumentoId { get; set; }

        /// <summary>
        /// Se define el nombre de un documento
        /// </summary>
        public string Documento { get; set; }     

       
    }
}
