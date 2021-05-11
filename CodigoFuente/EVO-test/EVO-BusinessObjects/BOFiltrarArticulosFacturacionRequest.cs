namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 02-May/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo FiltrarArticulosFacturacionRequest
    /// </summary>
    public class BOFiltrarArticulosFacturacionRequest
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
        /// Identificación
        /// </summary>
        /// <value>Identificación</value>      
        public string IdentificacionSocio { get; set; }

        /// <summary>
        /// Código punto de venta
        /// </summary>
        /// <value>Código punto de venta</value>    
        public string CodigoPuntoVenta { get; set; }
    }
}
