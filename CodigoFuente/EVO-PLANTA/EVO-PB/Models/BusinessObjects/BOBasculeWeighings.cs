using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PB.Models.BusinessObjects
{
    public class BOBasculeWeighings
    {
        /// <summary>
        /// Pesaje de la báscula
        /// </summary>
        /// <value>Pesaje de la báscula</value>
        public decimal BasculeWeight { get; set; }

        /// <summary>
        /// Peso del artículo(peso báscula menos los pesos de los contenedores usados en el pesaje)
        /// </summary>
        /// <value>Peso del artículo(peso báscula menos los pesos de los contenedores usados en el pesaje)</value>
        public decimal ArticleWeight { get; set; }

        /// <summary>
        /// Representa el nombre de la bodega donde fueron sacados los artículos del mismo tipo
        /// </summary>
        /// <value>Representa el nombre de la bodega donde fueron sacados los artículos del mismo tipo</value>
        public string WareHouse { get; set; }

        /// <summary>
        /// Gets or Sets ContenedoresRequest
        /// </summary>
        public List<BOContainers> Containers { get; set; }
    }
}
