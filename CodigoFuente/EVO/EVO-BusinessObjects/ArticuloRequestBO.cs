namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 24-May/2020
    /// Descripción     : Clase que representa un objeto de negocio de ArticuloRequest
    /// </summary>
    public class ArticuloRequestBO
    {
        /// <summary>
        /// Indica el código del artículo
        /// </summary>
        /// <value>Indica el código del artículo</value>
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Indica la cantidad a comprar
        /// </summary>
        /// <value>Indica la cantidad a comprar</value>
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Indica el valor unitario
        /// </summary>
        /// <value>Indica el valor unitario</value>
        public int ValorUnitario { get; set; }

        /// <summary>
        /// Indica el valor unitario más IVA
        /// </summary>
        /// <value>Indica el valor unitario más IVA</value>
        public int ValorUnitarioMasIVA { get; set; }

        /// <summary>
        /// Indica el porcentaje del IVA
        /// </summary>
        /// <value>Indica el porcentaje del IVA</value>
        public decimal PorcentajeIVA { get; set; }

        /// <summary>
        /// Indica el total por artículo
        /// </summary>
        /// <value>Indica el total por artículo</value>
       public int Total { get; set; }

        /// <summary>
        /// Indica el código de la bodega del punto de venta
        /// </summary>
        /// <value>Indica el código de la bodega del punto de venta</value>
        public string CodigoBodega { get; set; }

        /// <summary>
        /// Indica el código del IVA
        /// </summary>
        /// <value>Indica el código del IVA</value>
        public string CodigoIVA { get; set; }

        /// <summary>
        /// Indica el id del tipo del impuesto del IVA
        /// </summary>
        /// <value>5</value>
        public int IVAId { get; set; }

        /// <summary>
        /// Indica si el artículo fue eliminado
        /// </summary>
        /// <value>True</value>      
        public bool Eliminado { get; set; }
    }
}
