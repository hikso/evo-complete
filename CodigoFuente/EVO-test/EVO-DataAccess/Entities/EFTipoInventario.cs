using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 24-Abr/2020 
    /// </summary>    
    [Table("TiposInventario")]
    [Description("Representa un tipo de inventario")]
    public class EFTipoInventario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int TipoInventarioId { get; set; }

        [Description("Define el nombre")]
        [Column(TypeName = "NVARCHAR(255)")]
        [Required]
        public string Nombre { get; set; }

        [Description("Define si se encuentra activo")]
        [Required]
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación a Inventarios
        /// </summary>
        public ICollection<EFInventario> Inventarios { get; set; }
    }
}
