using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 23-May/2020 
    /// </summary>    
    [Table("Bancos")]
    [Description("Representa una banco")]
    public class EFBanco
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int BancoId { get; set; }
  
        [Description("Define el NIT")]
        [Column(TypeName = "NVARCHAR(255)")]
        [Required]
        public string NIT { get; set; }

        [Description("Define el Nombre")]
        [Column(TypeName = "NVARCHAR(255)")]
        [Required]
        public string Nombre { get; set; }

        [Required]
        [Description("Define el estado")]
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación a DetallesFacturaFormaPago
        /// </summary>
        public ICollection<EFDetalleFacturaFormaPago> DetallesFacturaFormaPago { get; set; }

    }
}
