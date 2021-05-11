using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 25-Feb/2020
    /// Descripción            : Representa un tipo de contenedor
    /// </summary> 
    
    [Table("TiposContenedor")]
    [Description("Representa un tipo de contenedor")]
    public class EFTipoContenedor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),
         Description("Define la clave primaria")]
        public int TipoContenedorId { get; set; }
       
        [Required]
        [Description("Define el nombre")]
        public string Nombre { get; set; }

        [Required]
        [Description("Define el peso")]
        public decimal Peso { get; set; }

        [Required]
        [Description("Define si tiene código de barras")]
        public bool CodigoBarras { get; set; }

        [Required]
        [Description("Define el estado")]
        public bool Activo { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a PesajeContenedor
        /// </summary>
        public ICollection<EFPesajeContenedor> PesajeContenedor { get; set; }

    }
}
