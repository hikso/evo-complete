using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 26-Abr/2020 
    /// </summary>    
    [Table("ListasPrecio")]
    [Description("Representa un item de una lista de precios")]
    public class EFListaPrecio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int ListaPrecioId { get; set; }

        /// <summary>
        /// Define la clave foránea de SocioNegocio
        /// </summary>       
        [Required]
        public string Identificacion { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a SocioNegocio
        /// </summary>       
        [ForeignKey("Identificacion")]
        public EFSocioNegocio SocioNegocio { get; set; }

        /// <summary>
        /// Define la clave foránea de Articulo
        /// </summary>       
        [Required]
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Articulo
        /// </summary>       
        [ForeignKey("CodigoArticulo")]
        [Column(TypeName = "NVARCHAR(50)")]
        public EFArticulo Articulo { get; set; }

        /// <summary>
        /// Define la clave foránea de TiposListaPrecio
        /// </summary>           
        [Required]
        public int TipoListaPrecioId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a TiposListaPrecio
        /// </summary>       
        [ForeignKey("TipoListaPrecioId")]
        public EFTipoListaPrecio TipoListaPrecio { get; set; }
        
        [Required]
        [Description("Define la fecha de inicio del descuento")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Description("Define la fecha de fin del descuento")]
        public DateTime FechaFin { get; set; }

        [Required]
        [Description("Define el precio unitario")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal PrecioUnitario { get; set; }

        [Required]
        [Description("Define la cantidad mínima")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal CantidadMinima { get; set; }
        
    }
}
