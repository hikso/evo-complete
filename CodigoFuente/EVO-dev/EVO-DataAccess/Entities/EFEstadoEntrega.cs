using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 19-Mar/2020
    /// </summary>    
    [Table("EstadosEntrega")]
    [Description("Representa un estado de la entrega")]
    public class EFEstadoEntrega
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del estado del pedido")]
        public int EstadoEntregaId { get; set; }

        [Required]
        [Description("Define el nombre del estado de la entrega")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Nombre { get; set; }

        [Required]
        [Description("Define si el estado está activo")]
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación a PesajesEntrega
        /// </summary>
        public ICollection<EFPesajeEntrega> PesajesEntrega { get; set; }
    }
}