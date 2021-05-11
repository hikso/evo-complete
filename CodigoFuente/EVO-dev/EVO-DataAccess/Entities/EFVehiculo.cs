using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 18-Dic/2019 
    /// </summary>    
    [Table("Vehiculos")]
    [Description("Representa un vehiculo")]
    public class EFVehiculo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria de vehiculo")]
        public int VehiculoId { get; set; }

        [Required]
        [Description("Define el tipo de vehiculo")]
        [Column(TypeName = "NVARCHAR(10)")]
        public string Placa { get; set; }        

        [Required]
        [Description("Define la capacidad en peso en kg que soporta el vehiculo")]
        public decimal Capacidad { get; set; }

        [Required]
        [Description("Define el estado del vehiculo")]
        public bool Activo { get; set; }

        /// <summary>
        /// Representa id que es clave foránea de tipo vehiculo
        /// </summary>
        [Required]
        public int TipoVehiculoId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a TiposVehiculo 
        /// </summary>      
        [ForeignKey("TipoVehiculoId")]
        public EFTipoVehiculo TipoVehiculo { get; set; }

    }
}
