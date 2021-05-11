using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 01-Abr/2020
    /// Descripción     : Clase que representa un objeto de negocio de TipoListaPrecio
    /// </summary>
    public class BOTipoListaPrecio
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public int TipoListaPrecioId { get; set; }

        /// <summary>
        /// Define el nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Define si se encuentra activo
        /// </summary>
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación a ListasPrecio
        /// </summary>
        public ICollection<BOListaPrecio> ListasPrecio { get; set; }
    }
}
