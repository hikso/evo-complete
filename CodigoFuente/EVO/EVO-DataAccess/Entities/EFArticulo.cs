using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 17-Sep/2019 
    /// </summary>    
    [Table("Articulos")]
    [Description("Representa un artículo")]
    public class EFArticulo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria de artículo")]
        [Column(TypeName = "NVARCHAR(50)")]
        public string ItemCode { get; set; }

        [Required]
        [Description("Define nombre del artículo")]
        [Column(TypeName = "NVARCHAR(100)")]
        public string ItemName { get; set; }

        [Required]
        [Description("Define la unidad de medida del articulo")]
        [Column(TypeName = "NVARCHAR(100)")]
        public string SalUnitMsr { get; set; }

        [Required]
        [Description("Define el precio del artículo")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Define la clave foránea de EstadosPedido
        /// </summary>      
        [Required]
        public int? EstadoId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a EstadosPedido 
        /// </summary>      
        [ForeignKey("EstadoId")]
        public EFEstadoPedido EstadoPedido { get; set; }

        /// <summary>
        /// Define la clave foránea de EstadosPedido
        /// </summary>      
        [Required]
        public int? EmpaqueId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a EstadosPedido 
        /// </summary>      
        [ForeignKey("EmpaqueId")]
        public EFEmpaque Empaques { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a ImpuestosArticulos
        /// </summary>
        public ICollection<EFImpuestoArticulo> ImpuestosArticulos { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a ImpuestosSociosArticulos
        /// </summary>
        public ICollection<EFImpuestoSocioArticulo> ImpuestosSociosArticulos { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a ListasPrecios
        /// </summary>
        public ICollection<EFListaPrecio> ListasPrecios { get; set; }

    }
}