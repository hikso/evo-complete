using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 19-Dic/2019  
    /// </summary>  

    [Table("Empleados")]
    [Description("Representa un empleado")]
    public class EFEmpleado
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del empleado")]
        public int EmpleadoId { get; set; }

        [Description("Define los nombres del empleado")]
        [Required]
        public string Nombres { get; set; }

        [Description("Define los apellidos del empleado")]
        [Required]
        public string Apellidos { get; set; }

        [Description("Define la cédula del empleado")]
        [Required]
        public string Cedula { get; set; }

        [Description("Define el cargo del empleado")]
        [Required]
        public string Cargo { get; set; }

        [Description("Define el estado del empleado")]
        [Required]
        public bool Activo { get; set; }

    }
}
