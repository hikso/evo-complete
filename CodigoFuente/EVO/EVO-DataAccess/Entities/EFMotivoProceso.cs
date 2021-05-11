using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 12-Feb/2020
    /// Descripción            : Representa un motivo asociado a un proceso.
    /// </summary>   
    /// 
    [Table("MotivosProcesos")]
    [Description("Representa los motivos de un proceso")]
    public class EFMotivoProceso
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria de la bodega")]       
        public int MotivoProcesoId { get; set; }

        [Required]
        [Description("Define la clave primaria del registro al cual se le aplicará un motivo")]
        public int TablaId { get; set; }

        [Required]
        //Clave Foránea del motivo
        public int MotivoId { get; set; }

        [ForeignKey("MotivoId")]
        public EFMotivo Motivo { get; set; }

        [Required]
        [Description("Define el nombre de la tabla a la cual se le está aplicando un motivo a un registro")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string NombreTabla { get; set; }

        [Required]
        [Description("Define la fecha de registro")]
        public DateTime FechaRegistro { get; set; }
    }
}
