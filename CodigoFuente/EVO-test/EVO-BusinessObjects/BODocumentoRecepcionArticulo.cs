namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 02-Abr/2020
    /// Descripción     : Clase que representa un objeto de negocio de un Documento Recepción Artículo
    /// </summary>
    public class BODocumentoRecepcionArticulo
    {
        /// <summary>
        ///  Id de DetalleEntrega
        /// </summary>
        public int DetalleEntregaId { get; set; }

        /// <summary>
        /// Id del documento
        /// </summary>
        public int? DocumentoId { get; set; }       

    }
}
