namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 11-Oct/2019
    /// Descripción     : Clase que representa un objeto de negocio de un ArtículoBodega
    /// </summary>
    public class ArticuloBodega
    {
        /// <summary>
        /// Indica el código del articulo
        /// </summary>
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Indica el nombre del artículo
        /// </summary>
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Indica la unidad de medida del artículo
        /// </summary>
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Indica el Código de la bodega
        /// </summary>
        public string WhsCode { get; set; }

        /// <summary>
        /// Indica la cantidad stock del artículo
        /// </summary>
        public decimal? Stock { get; set; }

        /// <summary>
        /// Indica la cantidad mínima del artículo
        /// </summary>
        public decimal? Minimo { get; set; }

        /// <summary>
        /// Indica la cantidad maxima del artículo
        /// </summary>
        public decimal? Maximo { get; set; }

        /// <summary>
        /// Indica la cantidad del pedido sugerido del artículo
        /// </summary>
        public decimal? PedidoSugerido { get; set; }

        /// <summary>
        /// Indica el di del estado del artículo
        /// </summary>
        public int? EstadoId { get; set; }

        /// <summary>
        /// Indica id del empaque
        /// </summary>
        public int? EmpaqueId { get; set; }

    }
}
