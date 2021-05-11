using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVO_PB.Utilities;

namespace EVO_PB.Models.BusinessObjects
{
    public class BOWeighingDetail : NotifyPropertyChanged
    {
        /// <summary>
        /// Código del artículo a ser pesado
        /// </summary>
        public string ArticleCode { get; set; }


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
        public List<BOContainers> Containers { get; set; }

    }
}
