namespace EVO_PV.Models.BusinessObjects
{
    public class BOArticleReceive
    {
        /// <summary>
        /// Id del Detalle de la entre
        /// </summary>
        /// <value>UnitMeasure</value>       
        public string DeliveryDetailId { get; set; }

        /// <summary>
        /// ID del pesaje realizado al articulo
        /// </summary>
        /// <value>UnitMeasure</value>       
        public string ArticleWeighingId { get; set; }

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
        /// Cantidad solicitada
        /// </summary>
        /// <value>Cantidad solicitada</value>
        public decimal QuantityRequested { get; set; }

        /// <summary>
        /// Cantidad aprobada
        /// </summary>
        /// <value>Cantidad aprobada</value>
        public decimal QuantityAprobed { get; set; }

        /// <summary>
        /// Cantidad enviada
        /// </summary>
        /// <value>Cantidad enviada</value>
        public decimal QuantitySended { get; set; }

        /// <summary>
        /// Cantidad recibida
        /// </summary>
        /// <value>Cantidad recibida</value>
        public decimal QuantityReceive { get; set; }

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
