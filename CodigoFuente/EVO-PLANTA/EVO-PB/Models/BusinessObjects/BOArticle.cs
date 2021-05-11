﻿namespace EVO_PB.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 30-Dic/2019
    /// Descripción     : Clase que representa un objeto de negocio de artículo
    /// </summary>
    public class BOArticle
    {
        /// <summary>
        /// Codigo del artículo
        /// </summary>
        /// <value>CodeArticle</value>      
        public string CodeArticle { get; set; }

        /// <summary>
        /// Nombre de el artículo
        /// </summary>
        /// <value>NameArticle</value>      
        public string NameArticle { get; set; }

        /// <summary>
        /// Pedido sugerido
        /// </summary>
        /// <value>SuggestedOrder</value>      
        public string SuggestedOrder { get; set; }

        /// <summary>
        /// Nombre de la unidad de medida
        /// </summary>
        /// <value>UnitMeasure</value>       
        public string UnitMeasure { get; set; }

        /// <summary>
        /// Stock de el producto en bodega
        /// </summary>
        /// <value>Stock de el producto en bodega</value>      
        public string Stock { get; set; }

        /// <summary>
        /// Stock mínimo que se debe tener de el producto en bodega
        /// </summary>
        /// <value>Minimum</value>     
        public string Minimum { get; set; }

        /// <summary>
        /// Stock máximo que se debe tener de el producto en bodega
        /// </summary>
        /// <value>Maximum</value>      
        public string Maximum { get; set; }

    }
}
