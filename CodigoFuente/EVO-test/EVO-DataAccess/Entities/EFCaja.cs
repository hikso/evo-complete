using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 11-Abr/2020 
    /// </summary>    
    [Table("Cajas")]
    [Description("Representa una caja")]
    public class EFCaja
    {      
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int CajaId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(8)")]
        [Description("Define el código del punto de venta")]
        public string CodigoPuntoVenta { get; set; }
     
        [Required]
        [Column(TypeName = "NVARCHAR(39)")]
        [Description("Define la IP del equipo para identificar la Caja")]
        public string IP { get; set; }

        [Required]
        [Description("Define el valor asignado")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal ValorAsignado { get; set; }

        [Required]
        [Description("Define si se encuentra activo o inactivo")]
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación a CuadresCaja
        /// </summary>
        public ICollection<EFCuadreCaja> CuadresCaja { get; set; }

    }
}
