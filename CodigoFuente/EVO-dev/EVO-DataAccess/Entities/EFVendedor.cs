using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 28-Abr/2020 
    /// </summary>    
    [Table("Vendedores")]
    [Description("Representa una vendedor")]
    public class EFVendedor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int VendedorId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(255)")]
        [Description("Define los nombres del vendedor")]
        public string Nombres { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(255)")]
        [Description("Define los apellidos del vendedor")]
        public string Apellidos { get; set; }

        [Required]
        [Description("Define el estado del vendedor")]
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación a VendedoresPuntoVenta
        /// </summary>
        public ICollection<EFVendedorPuntoVenta> VendedoresPuntoVenta { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a Facturas
        /// </summary>
        public ICollection<EFFactura> Facturas { get; set; }

    }
}
