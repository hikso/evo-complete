using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 15-Abr/2020 
    /// </summary>    

    [Table("SociosNegocio")]
    [Description("Representa una socio de negocio")]
    public class EFSocioNegocio
    {
        [Key, Description("Define la clave primaria")]
        [Column(TypeName = "NVARCHAR(15)")]
        public string Identificacion { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        [Description("Define el nombre")]
        public string Nombre { get; set; }

        [Description("Define el estado")]
        [Required]
        public bool Activo { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a ImpuestosSociosArticulos
        /// </summary>
        public ICollection<EFImpuestoSocioArticulo> ImpuestosSociosArticulos { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a ListasPrecios
        /// </summary>
        public ICollection<EFListaPrecio> ListasPrecios { get; set; }
    }
}
