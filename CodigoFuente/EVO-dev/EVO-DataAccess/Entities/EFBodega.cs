using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 17-Sep/2019
    /// Descripción            : Representa una bodega.
    /// </summary>    
    [Table("Bodegas")]
    [Description("Representa una bodega")]
    public class EFBodega
    {       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),Description("Define la clave primaria de la bodega")]      
        [Column(TypeName = "NVARCHAR(8)")]
        public string WhsCode { get; set; }
     
        [Required]
        [Description("Define el nombre de la bodega")]
        [Column(TypeName = "NVARCHAR(100)")]
        public string WhsName { get; set; }
     
        [Description("Define el email de la bodega")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Email { get; set; }
      
        [Description("Define la zona de la bodega")]
        [Column(TypeName = "NVARCHAR(8)")]
        public string Zona { get; set; }

        [Description("Define la cantidad de pedidos en estado borrador solicitados por bodega")]       
        public int? CantidadPedidosBorradorxBodega { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a VendedoresPuntoVenta
        /// </summary>
        public ICollection<EFVendedorPuntoVenta> VendedoresPuntoVenta { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a DetallesFactura
        /// </summary>
        public ICollection<EFDetalleFactura> DetallesFactura { get; set; }
    }
}