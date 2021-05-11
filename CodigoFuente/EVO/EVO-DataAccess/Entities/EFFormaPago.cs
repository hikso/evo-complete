using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 20-May/2020 
    /// </summary>    
    [Table("FormasPago")]
    [Description("Representa otra forma de pago")]
    public class EFFormaPago
    {      
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(255)")]
        [Description("Define el nombre")]
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
