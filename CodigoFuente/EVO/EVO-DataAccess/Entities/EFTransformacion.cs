using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 26-Abr/2020 
    /// </summary>    
    [Table("Transformaciones")]
    [Description("Representa un artículo que es parte de otro artículo")]
    public class EFTransformacion    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int TransformacionId { get; set; }
       
        [Description("Define el código del artículo transformado")]
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string CodigoArticuloTransformado { get; set; }

        [Description("Define el nombre del artículo transformado")]
        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string NombreArticuloTransformado { get; set; }

        /// <summary>
        /// Define la clave foránea de Articulo
        /// </summary>       
        [Required]
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Artículo
        /// </summary>       
        [ForeignKey("CodigoArticulo")]
        [Column(TypeName = "NVARCHAR(50)")]
        public EFArticulo Articulo { get; set; }

        [Description("Define la cantidad minima en stock para poder ser transformado")]
        [Column(TypeName = "NUMERIC(19,6)")]
        [Required]
        public decimal CantidadMinima { get; set; }

        [Description("Define si el artículo puede ser eliminado")]
        [Required]
        public bool Eliminar { get; set; } = false;

    }
}
