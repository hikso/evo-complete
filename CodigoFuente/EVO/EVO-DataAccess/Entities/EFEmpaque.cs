using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 13-Jul/2020   
    /// </summary>    
    [Table("Empaques")]
    [Description("Representa un empaque")]
    public class EFEmpaque
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Se obtiene la clave primaria")]
        public int EmpaqueId { get; set; }

        /// <summary>
        /// Define el nombre del empaque.
        /// </summary>
        [Required]
        [Description("Define el nombre del rol")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string EmpaqueNombre { get; set; }

        /// <summary>
        ///  Define si el registro se encuentra activo o inactivo
        /// </summary>
        [Required]
        [Description("Define si el registro se encuentra activo o inactivo")]
        public bool EmpaqueActivo { get; set; } = true;

    }
}
