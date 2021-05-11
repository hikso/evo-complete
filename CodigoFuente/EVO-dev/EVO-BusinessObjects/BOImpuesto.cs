using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 1-May/2020
    /// Descripción      : Clase que representa un objeto de negocio de tipo Impuesto
    /// </summary>
    public class BOImpuesto
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>       
        public int ImpuestoId { get; set; }

        /// <summary>
        /// Define el código del impuesto
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Define el valor
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Define si se encuentra activo
        /// </summary>
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación a Articulos
        /// </summary>
        public ICollection<BOArticulo> Articulos { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a ImpuestosSociosArticulos
        /// </summary>
        public ICollection<BOImpuestoSocioArticulo> ImpuestosSociosArticulos { get; set; }
    }
}
