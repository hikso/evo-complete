using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 12-Feb/2020 
    /// </summary>    
    [Table("Procesos")]
    [Description("Representa un proceso")]
    public class EFProceso
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del proceso")]
        public int ProcesoId { get; set; }

        [Required]
        [Description("Define nombre del proceso")]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Proceso { get; set; }

        [Description("Define el estado del proceso")]
        [Required]
        public bool Activo { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación que representa los motivos del proceso
        /// </summary>
        public ICollection<EFMotivo> Motivos { get; set; }

    }
}
