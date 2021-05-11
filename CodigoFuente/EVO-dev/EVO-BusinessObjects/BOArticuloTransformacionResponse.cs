namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 29-Abr/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo ArticuloTransformacionResponse
    /// </summary>
    public class BOArticuloTransformacionResponse
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>      
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>       
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Stock
        /// </summary>
        /// <value>Stock</value>       
        public decimal Stock { get; set; }

        /// <summary>
        /// CantidadMinima
        /// </summary>
        /// <value>CantidadMinima</value>       
        public decimal CantidadMinima { get; set; }
    }
}
