using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 27-Feb/2020   
    /// </summary>   

    [Table("TiposBascula")]
    [Description("Representa una bascula")]
    public class EFTipoBascula
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),
        Description("Define la clave primaria")]
        public int TipoBasculaId { get; set; }

        [Required]
        [Description("Define el nombre")]     
        public string Nombre { get; set; }

        [Required]
        [Description("Define el estado")]
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación a Pesajes
        /// </summary>
        public ICollection<EFPesaje> Pesajes { get; set; }
    }
}
