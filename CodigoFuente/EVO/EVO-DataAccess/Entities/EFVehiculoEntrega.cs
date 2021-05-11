using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 19-Dic/2019  
    /// </summary>  

    [Table("VehiculoEntregas")]
    [Description("Representa el encabezado del viaje del vehiculo que entrega los pedidos")]
    public class EFVehiculoEntrega
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del empleado")]
        public int VehiculoEntregaId { get; set; }

        [Required]
        public int MuelleId { get; set; }

        [Required]
        public int UsuarioId { get; set; }
       
        [Required]
        public int VehiculoId { get; set; }

        [Required]
        public int ConductorId { get; set; }

        [Required]
        public int AuxiliarId { get; set; }

        [Description("Define la fecha de registro de la programación de las entregas de envío")]
        [Required]
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Usuario
        /// </summary>  
        [ForeignKey("UsuarioId")]
        public EFUsuario Usuario { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a vehiculo
        /// </summary>  
        [ForeignKey("VehiculoId")]
        public EFVehiculo Vehiculo { get; set; }
        
        /// <summary>
        /// Define la propiedad de navegación a Empleado
        /// </summary>  
        [ForeignKey("ConductorId")]
        public EFEmpleado Conductor { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Empleado
        /// </summary>  
        [ForeignKey("MuelleId")]
        public EFMuelle Muelle { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Empleado
        /// </summary>  
        [ForeignKey("AuxiliarId")]
        public EFEmpleado Auxiliar { get; set; }
     

        /// <summary>
        /// Define la propiedad de navegación a los detalles VehiculoEntregasDetalles
        /// </summary>      
        public ICollection<EFVehiculoEntregaDetalle> VehiculoEntregasDetalles { get; set; }
    }
}
