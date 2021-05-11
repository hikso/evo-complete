namespace EVO_PV.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 23-Ene/2020
    /// Descripción     : Clase que representa un objeto de negocio de búsqueda para encontrar artículos
    /// </summary>
    public class BOSearchArticleRequest
    {
        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Pierna</value>      
        public string Name { get; set; }

        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>PT-</value>      
        public string Code { get; set; }

        /// <summary>
        /// Código de la bodega(punto de venta)
        /// </summary>
        /// <value>PV-PRA</value>      
        public string WhsCode { get; set; }

        /// <summary>
        /// Prefijo de los artículos , la planta tiene por ejemplo PB-PT y los artículos tienen PT-2456
        /// </summary>
        /// <value>PT-</value>      
        public string PrefixCodeArticle { get; set; }
    }
}
