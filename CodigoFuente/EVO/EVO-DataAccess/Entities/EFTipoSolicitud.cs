using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 09-Jul/2019
    /// </summary>    
    [Table("TiposSolicitud")]
    [Description("Representa un tipo de solicitud de un pedido")]
    public class EFTipoSolicitud
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del estado del pedido")]
        public int TipoSolicitudId { get; set; }

        [Required]
        [Description("Define el nombre del tipo de solicitud")]
        [Column(TypeName = "NVARCHAR(100)")]
        public string TipoSolicitudNombre { get; set; }

        [Required]
        [Description("Define si el estado está activo")]
        public bool Activo { get; set; } = true;
        
    }
}
