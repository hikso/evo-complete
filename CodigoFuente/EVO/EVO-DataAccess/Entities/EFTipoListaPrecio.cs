using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 26-Abr/2020 
    /// </summary>    
    [Table("TiposListaPrecio")]
    [Description("Representa un tipo de lista de precio")]
    public class EFTipoListaPrecio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int TipoListaPrecioId { get; set; }

        [Description("Define el nombre")]
        [Column(TypeName = "NVARCHAR(255)")]
        [Required]
        public string Nombre { get; set; }        

        [Description("Define si se encuentra activo")]
        [Required]
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación a ListasPrecio
        /// </summary>
        public ICollection<EFListaPrecio> ListasPrecio { get; set; }
       
    }
}
