namespace EVO_BusinessObjects
{
    public class BOCodigoBarrasResponse
    {
        /// <summary>
        /// Código de barras (01485&#x3D;código artículo | 00123&#x3D;lote | 220120&#x3D;fecha vencimiento | 00006 &#x3D; cantidad artículo | 00101&#x3D;peso)
        /// </summary>
        /// <value>Código de barras (01485&#x3D;código artículo | 00123&#x3D;lote | 220120&#x3D;fecha vencimiento | 00006 &#x3D; cantidad artículo | 00101&#x3D;peso)</value>      
        public string CodigoBarras { get; set; }

        /// <summary>
        /// Lote de la bodega
        /// </summary>
        /// <value>Lote de la bodega</value>     
        public string Lote { get; set; }

        /// <summary>
        /// Fecha de vencimiento de los artículos del contenedor
        /// </summary>
        /// <value>Fecha de vencimiento de los artículos del contenedor</value>     
        public string FechaVencimiento { get; set; }

        /// <summary>
        /// Unidades del artículo del contenedor
        /// </summary>
        /// <value>Unidades del artículo del contenedor</value>      
        public int Unidades { get; set; }

        /// <summary>
        /// Peso del contenedor con los articulos
        /// </summary>
        /// <value>Peso del contenedor con los articulos</value>      
        public decimal Peso { get; set; }
    }
}
