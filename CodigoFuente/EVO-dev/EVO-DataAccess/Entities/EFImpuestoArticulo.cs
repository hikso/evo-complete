using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 29-Abr/2020 
    /// </summary>    
    [Table("ImpuestosArticulo")]
    [Description("Representa un impuesto aplicado a un artículo")]
    public class EFImpuestoArticulo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int ImpuestoArticuloId { get; set; }

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

        [Required]
        [Description("Define el id del impuesto")]
        public int ImpuestoId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Impuestos
        /// </summary>       
        [ForeignKey("ImpuestoId")]
        public EFImpuesto Impuesto { get; set; }
        
    }
}
