using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 12-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo PesajeBasculaRespuesta
    /// </summary>
    public class PesajeBasculaRespuesta
    {
        /// <summary>
        /// Pesaje de la báscula
        /// </summary>
        /// <value>Pesaje de la báscula</value>
       
        public decimal PesoBascula { get; set; }

        /// <summary>
        /// Peso del artículo(peso báscula menos los pesos de los contenedores usados en el pesaje)
        /// </summary>
        /// <value>Peso del artículo(peso báscula menos los pesos de los contenedores usados en el pesaje)</value>
       
        public decimal PesoArticulo { get; set; }

        /// <summary>
        /// Representa el nombre de la bodega donde fueron sacados los artículos del mismo tipo
        /// </summary>
        /// <value>Representa el nombre de la bodega donde fueron sacados los artículos del mismo tipo</value>
        
        public string Bodega { get; set; }

        /// <summary>
        /// Gets or Sets ContenedoresRequest
        /// </summary>
       
        public List<PesajeContenedor> ContenedoresRequest { get; set; }
    }
}
