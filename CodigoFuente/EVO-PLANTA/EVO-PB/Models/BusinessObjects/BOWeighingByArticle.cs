using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVO_PB.Utilities;

namespace EVO_PB.Models.BusinessObjects
{
    public class BOWeighingByArticle : NotifyPropertyChanged
    {
        /// <summary>
        /// Tipo de báscula, ID
        /// </summary>
        public string ArticleCode { get; set; }

        /// <summary>
        /// Tipo de báscula, ID
        /// </summary>
        public string NameArticle { get; set; }

        /// <summary>
        /// Código del artículo a ser pesado
        /// </summary>
        public string MeasureUnit { get; set; }

        /// <summary>
        /// Peso indicado por el usuario cuando se realiza el pesaje
        /// </summary>
        public string ArticleState { get; set; }

        /// <summary>
        /// Peso indicado por el usuario cuando se realiza el pesaje
        /// </summary>
        public decimal TotalBasculeWeight { get; set; }

        /// <summary>
        /// Código de bodega de la cual se obtiene el artículo
        /// </summary>
        public List<BOBasculeWeighings> BasculeWeighings { get; set; }

    }
}
