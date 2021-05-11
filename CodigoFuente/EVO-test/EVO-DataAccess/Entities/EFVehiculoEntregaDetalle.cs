using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 19-Dic/2019   
    /// </summary>  
    /// 
    [Table("VehiculoEntregasDetalles")]
    [Description("Representa el detalle del viaje del vehiculo que entrega los pedidos")]
    public class EFVehiculoEntregaDetalle
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del empleado")]
        public int VehiculoEntregaDetalleId { get; set; }

        [Required]
        public int VehiculoEntregaId { get; set; }

        [Required]
        public int EntregaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Usuario
        /// </summary>  
        [ForeignKey("VehiculoEntregaId")]
        public EFVehiculoEntrega VehiculoEntrega { get; set; }
        
        /// <summary>
        /// Define la propiedad de navegación a Entregas
        /// </summary>  
        [ForeignKey("EntregaId")]
        public EFEntrega Entrega { get; set; }
        
    }
}
