using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 18-Dic/2019 
    /// </summary>    
    [Table("TiposVehiculo")]
    [Description("Representa un tipo de vehiculo")]
    public class EFTipoVehiculo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria de TipoVehiculo")]       
        public int TipoVehiculoId { get; set; }

        [Required]
        [Description("Define el tipo de vehiculo")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string TipoVehiculo { get; set; }

        [Required]
        [Description("Define la capacidad de carga")]        
        public decimal Capacidad { get; set; }

        [Required]
        [Description("Define el peso de las canastas")]
        public decimal Canastas { get; set; }

        [Required]
        [Description("Define el peso del tipo de vehiculo(sin cargas)")]
        public decimal Peso { get; set; }

        [Required]
        [Description("Define el estado del tipo del tipo de vehiculo")]       
        public bool Activo { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a los Vehiculos
        /// </summary>      
        public ICollection<EFVehiculo> Vehiculos { get; set; }
    }
}
