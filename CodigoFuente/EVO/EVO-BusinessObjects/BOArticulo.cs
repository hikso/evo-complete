using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 02-Sep/2019
    /// Descripción     : Clase que representa un objeto de negocio de un Artículo
    /// </summary>
    public class BOArticulo
    {
        /// <summary>
        /// Indica el código del artículo
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// Indica el nombre del artículo
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Unidad de medida del artículo
        /// </summary>
        public string SalUnitMsr { get; set; }

        /// <summary>
        /// Define el precio del artículo
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a ImpuestosArticulos
        /// </summary>
        public ICollection<BOImpuestoArticulo> ImpuestosArticulos { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a ImpuestosSociosArticulos
        /// </summary>
        public ICollection<BOImpuestoSocioArticulo> ImpuestosSociosArticulos { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a ListasPrecios
        /// </summary>
        public ICollection<BOListaPrecio> ListasPrecios { get; set; }
    }
}