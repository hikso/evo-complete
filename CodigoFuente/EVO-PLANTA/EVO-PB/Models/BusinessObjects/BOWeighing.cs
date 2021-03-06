using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVO_PB.Utilities;

namespace EVO_PB.Models.BusinessObjects
{
    public class BOWeighing : NotifyPropertyChanged
    {
        /// <summary>
        /// Tipo de báscula, ID
        /// </summary>
        public string DeliveryDetailId { get; set; }

        /// <summary>
        /// Tipo de báscula, ID
        /// </summary>
        public int TypeBasculeId { get; set; }

        /// <summary>
        /// Código del artículo a ser pesado
        /// </summary>
        public string CodeArticle { get; set; }

        /// <summary>
        /// Peso indicado por el usuario cuando se realiza el pesaje
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// Peso indicado por el usuario cuando se realiza el pesaje
        /// </summary>
        public double TotalArticleWeight { get; set; }

        /// <summary>
        /// Código de bodega de la cual se obtiene el artículo
        /// </summary>
        public string WhsCode { get; set; }

        /// <summary>
        /// Peso total contenedores
        /// </summary>
        public double ContainersTotalWeight { get; set; }

        /// <summary>
        /// Contenedores que se van a usar en el pesaje
        /// </summary>
        public List<BOContainers> Containers { get; set; }

        public void CalculateContainersWeight()
        {
            ContainersTotalWeight = 0;
            foreach (var item in Containers)
            {
                if (item.ContainerQuantity != 0 )
                {
                    this.ContainersTotalWeight += item.ContainerQuantity * item.ContainerWeight;
                }
            }
        }

    }
}
