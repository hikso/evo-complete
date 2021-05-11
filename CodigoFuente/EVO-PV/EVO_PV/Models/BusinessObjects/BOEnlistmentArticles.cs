namespace EVO_PV.Models.BusinessObjects
{
    public class BOEnlistmentArticles
    {
        /// <summary>
        /// Id del Detalle de la entre
        /// </summary>
        /// <value>UnitMeasure</value>       
        public string DeliveryDetailId { get; set; }

        /// <summary>
        /// Nombre de la unidad de medida
        /// </summary>
        /// <value>UnitMeasure</value>       
        public string ArticleCode { get; set; }

        /// <summary>
        /// Pedido sugerido
        /// </summary>
        /// <value>SuggestedOrder</value>      
        public string ArticleName { get; set; }

        /// <summary>
        /// Stock de el producto en bodega
        /// </summary>
        /// <value>Stock de el producto en bodega</value>      
        public string State { get; set; }

        /// <summary>
        /// Stock mínimo que se debe tener de el producto en bodega
        /// </summary>
        /// <value>Minimum</value>     
        public decimal DeliveryQuantity { get; set; }

        /// <summary>
        /// Stock máximo que se debe tener de el producto en bodega
        /// </summary>
        /// <value>Maximum</value>      
        public decimal PendingQuantity { get; set; }

        /// <summary>
        /// Stock máximo que se debe tener de el producto en bodega
        /// </summary>
        /// <value>Maximum</value>
        public string MeasureUnit { get; set; }

    }
}
