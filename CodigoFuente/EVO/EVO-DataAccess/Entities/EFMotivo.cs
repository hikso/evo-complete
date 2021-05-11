using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 10-Dic/2019
    /// Descripción            : Representa un motivo de edición de una entrega.
    /// </summary> 

    [Table("Motivos")]
    [Description("Representa un motivo de un proceso")]
    public class EFMotivo
    {       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Se define la clave primaria")]
        public int MotivoId { get; set; }

        [Required]
       // Este atributo representa la clave foránea al proceso
        public int ProcesoId { get; set; }

        [Required]
        [Description("Se define un motivo")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Motivo { get; set; }

        [Required]
        [Description("Define si el motivo se encuentra activo o inactivo")]
        public bool Activo { get; set; } = true;

        [ForeignKey("ProcesoId")]
        //Propiedad de navegación a Proceso
        public EFProceso Proceso { get; set; }      
    }
}
