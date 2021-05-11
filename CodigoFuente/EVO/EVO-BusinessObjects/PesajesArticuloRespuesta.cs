using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 12-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo PesajesArticuloRespuesta
    /// </summary>
    public class PesajesArticuloRespuesta
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>
        
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Nombre del articulo
        /// </summary>
        /// <value>Nombre del articulo</value>
       
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Unidad de medida del articulo
        /// </summary>
        /// <value>Unidad de medida del articulo</value>
       
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Estado del artículo</value>
       
        public string EstadoArticulo { get; set; }

        /// <summary>
        /// Representa el pesaje total por báscula
        /// </summary>
        /// <value>Representa el pesaje total por báscula</value>
        
        public decimal TotalPesoBascula { get; set; }

        /// <summary>
        /// Gets or Sets PesajesBascula
        /// </summary>
       
        public List<PesajeBasculaRespuesta> PesajesBascula { get; set; }


    }
}
