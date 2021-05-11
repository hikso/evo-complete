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
    [Table("Impuestos")]
    [Description("Representa un impuesto")]
    public class EFImpuesto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int ImpuestoId { get; set; }

        [Description("Define el código")]
        [Column(TypeName = "NVARCHAR(50)")]
        [Required]
        public string Codigo { get; set; }

        [Description("Define el valor")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal Valor { get; set; }

        [Description("Define si se encuentra activo")]
        [Required]
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación a ImpuestosArticulo
        /// </summary>
        public ICollection<EFImpuestoArticulo> ImpuestosArticulo { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a ImpuestosSociosArticulos
        /// </summary>
        public ICollection<EFImpuestoSocioArticulo> ImpuestosSociosArticulos { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a DetallesFactura
        /// </summary>
        public ICollection<EFDetalleFactura> DetallesFactura { get; set; }
    }
}
