using EVO_DataAccess.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 12-Abr/2020 
    /// </summary>    
    [Table("EstadosCuadreCaja")]
    [Description("Representa un estado cuadre de caja")]
    public class EFEstadoCuadreCaja
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int EstadoCuadreCajaId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(MAX)")]
        [Description("Define el nombre del estado de cuadre de caja")]
        public string Nombre { get; set; }

        [Required]
        [Description("Define si se encuentra activo o inactivo")]
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación a CuadresCaja
        /// </summary>
        public ICollection<EFCuadreCaja> CuadresCaja { get; set; }

    }
}
