using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 01-Abr/2020
    /// Descripción     : Clase que representa un objeto de negocio de ListaPrecio
    /// </summary>
    public class BOListaPrecio
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public int ListaPrecioId { get; set; }

        /// <summary>
        /// Define la clave foránea de SocioNegocio
        /// </summary>     
        public string Identificacion { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a SocioNegocio
        /// </summary>       
        public BOSocioNegocio SocioNegocio { get; set; }

        /// <summary>
        /// Define la clave foránea de Articulo
        /// </summary>     
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Articulo
        /// </summary>     
        public BOArticulo Articulo { get; set; }

        /// <summary>
        /// Define la clave foránea de TiposListaPrecio
        /// </summary>      
        public int TipoListaPrecioId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a TiposListaPrecio
        /// </summary>      
        public BOTipoListaPrecio TipoListaPrecio { get; set; }

        /// <summary>
        /// Define la fecha de inicio del descuento
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Define la fecha de fin del descuento
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Define el precio unitario
        /// </summary>
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Define la cantidad mínima
        /// </summary>
        public decimal CantidadMinima { get; set; }
    }
}
