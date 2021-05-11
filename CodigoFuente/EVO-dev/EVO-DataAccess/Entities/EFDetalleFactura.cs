using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 25-Abr/2020 
    /// </summary>    
    [Table("DetallesFactura")]
    [Description("Representa un detalle de factura")]
    public class EFDetalleFactura
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int DetalleFacturaId { get; set; }

        /// <summary>
        /// Define la clave foránea a Factura
        /// </summary>
        [Required]
        public int FacturaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación de Factura
        /// </summary>
        [ForeignKey("FacturaId")]      
        public EFFactura Factura { get; set; }

        /// <summary>
        /// Define la clave foránea de Articulo
        /// </summary> 
        [Column(TypeName = "NVARCHAR(50)")]
        [Required]
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Articulo
        /// </summary>       
        [ForeignKey("CodigoArticulo")]        
        public EFArticulo Articulo { get; set; }

        /// <summary>
        /// Define la clave foránea de Bodegas
        /// </summary> 
        [Column(TypeName = "NVARCHAR(8)")]
        [Required]
        public string CodigoBodega { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Bodegas
        /// </summary>       
        [ForeignKey("CodigoBodega")]
        public EFBodega Bodega { get; set; }

        [Required]
        [Description("Define la cantidad")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal Cantidad { get; set; }

        //[Required]
        //[Description("Define el stock")]
        //[Column(TypeName = "NUMERIC(19,6)")]
        //public decimal Stock { get; set; }

        [Required]
        [Description("Define el precio unitario")]       
        public int PrecioUnitario { get; set; }
      
        [Description("Define el precio unitario más IVA")]
        public int PrecioUnitarioMasIVA { get; set; }

        [Required]
        [Description("Define el IVA")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal PorcentajeIVA { get; set; }

        /// <summary>
        /// Define la clave foránea a Impuestos
        /// </summary>
        [Required]
        public int IVAId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación de Impuestos
        /// </summary>
        [ForeignKey("IVAId")]
        public EFImpuesto Impuesto { get; set; }       

        [Required]
        [Description("Define el precio total")]
        public int Total { get; set; }

        //[Required]
        //[Description("Define si se ha aplicado el precio al por mayor")]
        //public bool PorMayor { get; set; }      

        [Required]
        [Description("Define si se ha eliminado el detalle")]       
        public bool Eliminado { get; set; } = false;
       
      
    }
}
