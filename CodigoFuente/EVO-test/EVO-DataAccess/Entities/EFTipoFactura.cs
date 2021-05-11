using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 24-Abr/2020 
    /// </summary>    
    [Table("TiposFactura")]
    [Description("Representa un tipo de factura")]
    public class EFTipoFactura
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int TipoFacturaId { get; set; }

        [Description("Define el nombre")]
        [Column(TypeName = "NVARCHAR(255)")]
        [Required]
        public string Nombre { get; set; }

        [Description("Define si se encuentra activo")]
        [Required]
        public bool Activo { get; set; } = true;
    }
}
