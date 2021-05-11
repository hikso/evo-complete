namespace EVO_PV.Models.BusinessObjects
{
    public class BOBarCodeWeighing
    {
        /// <summary>
        /// Código de barras
        /// </summary>
        public string BarCode { get; set; }


        /// <summary>
        /// Código de barras
        /// </summary>
        public string ArticleState { get; set; }

        /// <summary>
        /// Código de barras
        /// </summary>
        public string ArticleName { get; set; }

        /// <summary>
        /// Código de barras
        /// </summary>
        public string ArticleCode { get; set; }

        /// <summary>
        /// Lote del articulo
        /// </summary>
        /// <value>UnitMeasure</value>       
        public float Lot { get; set; }

        /// <summary>
        /// Fecha de expiración o vencimiento
        /// </summary>
        public string ExpirationDate { get; set; }

        /// <summary>
        /// Cantidad de articulos
        /// </summary>
        public string ArticleQuantity { get; set; }

        /// <summary>
        /// Peso indicado por el usuario cuando se realiza el pesaje
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// Peso indicado por el usuario cuando se realiza el pesaje
        /// </summary>
        public string MeasureUnit { get; set; }
    }
}
