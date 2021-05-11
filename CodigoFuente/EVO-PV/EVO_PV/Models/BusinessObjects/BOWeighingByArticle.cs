using EVO_PV.Utilities;
using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOWeighingByArticle : NotifyPropertyChanged
    {
        /// <summary>
        /// Tipo de báscula, ID
        /// </summary>
        public string ArticleCode { get; set; }

        /// <summary>
        /// ID del pesaje realizado al articulo
        /// </summary>
        /// <value>UnitMeasure</value>       
        public string ArticleWeighingId { get; set; }


        /// <summary>
        /// Peso del artículo
        /// </summary>
        /// <value>UnitMeasure</value>       
        public float ArticleWeight { get; set; }

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
