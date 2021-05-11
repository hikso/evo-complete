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
    [Table("Inconsistencias")]
    [Description("Representa un inconsistencia")]
    public class EFInconsistencia
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int InconsistenciaId { get; set; }
         
        [Required]
        [Column(TypeName = "NVARCHAR(MAX)")]
        [Description("Define el nombre de la inconsistencia")]
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
