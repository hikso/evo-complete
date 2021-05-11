using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    public class BORespuestaCodigoBarrasResponse
    {
        /// <summary>
        /// Válida si el código de barras es coherente con el artículo
        /// </summary>
        /// <value>Válida si el código de barras es coherente con el artículo</value>       
        public bool Respuesta { get; set; }

        /// <summary>
        /// Gets or Sets codigoBarrasResponse
        /// </summary>      
        public BOCodigoBarras CodigoBarrasResponse { get; set; }
    }
}
