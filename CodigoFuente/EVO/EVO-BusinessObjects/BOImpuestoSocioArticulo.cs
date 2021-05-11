namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 1-May/2020
    /// Descripción      : Clase que representa un objeto de negocio de tipo ImpuestoSocioArticulo
    /// </summary>
    public class BOImpuestoSocioArticulo
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public int ImpuestoSocioArticuloId { get; set; }

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
        /// Define el id del impuesto
        /// </summary>
        public int ImpuestoId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Impuestos
        /// </summary>       
        public BOImpuesto Impuesto { get; set; }
    }
}
