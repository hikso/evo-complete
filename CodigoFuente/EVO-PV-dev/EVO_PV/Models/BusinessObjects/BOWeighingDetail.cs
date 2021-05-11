using EVO_PV.Utilities;
using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOWeighingDetail : NotifyPropertyChanged
    {
        //#region Constructor
        //public BOWeighingDetail(
        //    string _ArticleCode, 
        //    string _ArticleWeighingId, 
        //    string _ArticleName, 
        //    float _BasculeWeight, 
        //    double _ArticleWeight, 
        //    string _MeasureUnit,
        //    List<BOContainers> _Containers)
        //{
        //    this.ArticleCode = _ArticleCode;
        //    this.ArticleWeighingId = _ArticleWeighingId;
        //    this.ArticleName = _ArticleName;
        //    this.BasculeWeight = _BasculeWeight;
        //    this.ArticleWeight = _ArticleWeight;
        //    this.MeasureUnit = _MeasureUnit;
        //    this.Containers = _Containers;
        //}
        //#endregion
        /// <summary>
        /// Código del artículo a ser pesado
        /// </summary>
        public string ArticleCode { get; set; }

        /// <summary>
        /// Articulo pesaje id
        /// </summary>
        public string ArticleWeighingId { get; set; }
        /// <summary>
        /// Código del artículo a ser pesado
        /// </summary>
        public string ArticleName { get; set; }

        /// <summary>
        /// Peso generado por la báscula
        /// </summary>
        public float basculeWeight { get; set; }
        public float BasculeWeight
        {
            get { return basculeWeight; }
            set
            {
                this.basculeWeight = value;
                this.OnPropertyChanged("BasculeWeight");
            }
        }

        /// <summary>
        /// Código del artículo a ser pesado
        /// </summary>
        public double articleWeight { get; set; }
        public double ArticleWeight
        {
            get { return articleWeight; }
            set
            {
                this.articleWeight = value;
                this.OnPropertyChanged("ArticleWeight");
            }
        }
        /// <summary>
        /// Código del artículo a ser pesado
        /// </summary>
        public string MeasureUnit { get; set; }

        /// <summary>
        /// Gets or Sets ContenedoresRequest
        /// </summary>
        public List<BOContainers> containers { get; set; }
        public List<BOContainers> Containers
        {
            get { return containers; }
            set
            {
                this.containers = value;
                this.OnPropertyChanged("Containers");
            }
        }

        /// <summary>
        /// Peso total contenedores
        /// </summary>
        public double containersTotalWeight { get; set; }
        public double ContainersTotalWeight
        {
            get { return containersTotalWeight; }
            set
            {
                this.containersTotalWeight = value;
                this.OnPropertyChanged("ContainersTotalWeight");
            }
        }

        public void CalculateContainersWeight()
        {
            ContainersTotalWeight = 0;
            foreach (var item in Containers)
            {
                if (item.ContainerQuantity != 0)
                {
                    this.ContainersTotalWeight += item.ContainerQuantity * item.ContainerWeight;
                }
            }
        }
    }
}
