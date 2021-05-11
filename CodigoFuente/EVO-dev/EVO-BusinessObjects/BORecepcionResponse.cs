using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 9-Abr/2020
    /// Descripción     : Clase que representa un objeto de actualización de tipo RecepcionResponse
    /// </summary>
    public class BORecepcionResponse
    {
        /// <summary>
        /// Indica si existe alguna inconsistencia entre pesaje de código de barras y báscula
        /// </summary>
        /// <value>Indica si existe alguna inconsistencia entre pesaje de código de barras y báscula</value>
        
        public bool? InconsistenciaCodigoBarras { get; set; }

        /// <summary>
        /// Gets or Sets Documentos
        /// </summary>
       
        public List<BOArticuloDocumentoResponse> Documentos { get; set; }
    }
}
