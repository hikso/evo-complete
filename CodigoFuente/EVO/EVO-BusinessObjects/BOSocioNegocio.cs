using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 1-May/2020
    /// Descripción      : Clase que representa un objeto de negocio de tipo SocioNegocio
    /// </summary>
    public class BOSocioNegocio
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public string Identificacion { get; set; }

        /// <summary>
        /// Define el nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Define el estado
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a ImpuestosSociosArticulos
        /// </summary>
        public ICollection<BOImpuestoSocioArticulo> ImpuestosSociosArticulos { get; set; }
    }
}
