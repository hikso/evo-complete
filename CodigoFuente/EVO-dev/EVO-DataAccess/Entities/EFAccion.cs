using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{

    /// <summary>
    /// Autor                  : Andrés Holguín Osorio
    /// Fecha de creación      : 12-Agosto/2020
    /// </summary>    
    [Table("Acciones")]
    [Description("Representa la acción de gestión de compras")]
    public class EFAccion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria de la acción")]
        public int AccionId { get; set; }

        [Required]
        [Description("Define el nombre de la acción")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Nombre { get; set; }

    }
}
