using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 02-Abr/2020
    /// Descripción     : Clase que representa que documento se generó por un artículo en recepción
    public class BOArticuloDocumentoResponse
    {
        /// <summary>
        /// Id del documento
        /// </summary>
        public int documentoId { get; set; }

        /// <summary>
        /// Nombre del documento
        /// </summary>
        public string nombreDocumento { get; set; }
    }

    /// <summary>
    /// .Distinct(new BOArticuloDocumentoResponseEqualityComparer()).ToList();
    /// Sirver para hacer distinct de lista de objetos complejos del tipo BOArticuloDocumentoResponse por el id.
    /// </summary>
    public class BOArticuloDocumentoResponseEqualityComparer : IEqualityComparer<BOArticuloDocumentoResponse>
    {
        public bool Equals(BOArticuloDocumentoResponse x, BOArticuloDocumentoResponse y)
        {
            // Two items are equal if their keys are equal.
            return x.documentoId == y.documentoId;
        }

        public int GetHashCode(BOArticuloDocumentoResponse obj)
        {
            return obj.documentoId.GetHashCode();
        }
    }

}
