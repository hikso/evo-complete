using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Andrés Holguín
    /// Fecha de creación      : 17-Feb/2020
    /// Descripción            : Representa un muelle asociado a un vehículo en el modulo de enrutamiento.
    /// </summary> 
    [Table("Muelles")]
    [Description("Representa un muelle de un vehículo asociado")]
    public class EFMuelle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Se define la clave primaria")]
        public int MuelleId { get; set; }
      
        [Required]
        [Description("Se define un muelle")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Muelle { get; set; }

        [Required]
        [Description("Define si el muelle se encuentra activo o inactivo")]
        public bool Activo { get; set; } = true;
       
        //Propiedad de navegación a vehiculo Entregas
        public ICollection<EFVehiculoEntrega> VehiculoEntrega { get; set; }

    }
}
