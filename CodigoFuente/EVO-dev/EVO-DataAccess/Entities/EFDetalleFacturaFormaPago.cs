using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 23-May/2020 
    /// </summary>    
    [Table("DetallesFacturaFormaPago")]
    [Description("Representa una DetalleFacturaFormaPago")]
    public class EFDetalleFacturaFormaPago
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int DetalleFacturaFormaPagoId { get; set; }

        /// <summary>
        /// Define la clave foránea a Facturas
        /// </summary>
        [Required]
        public int FacturaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación de Facturas
        /// </summary>
        [ForeignKey("FacturaId")]
        [Required]
        public EFFactura Factura { get; set; }

        /// <summary>
        /// Define la clave foránea a FormaPago
        /// </summary>
        [Required]
        public int FormaPagoId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación de FormaPago
        /// </summary>
        [ForeignKey("FormaPagoId")]
        [Required]
        public EFFormaPago FormaPago { get; set; }

        /// <summary>
        /// Define la clave foránea a Bancos
        /// </summary>      
        public int? BancoId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación de Bancos
        /// </summary>
        [ForeignKey("BancoId")]
        public EFBanco Banco { get; set; }

        [Required]
        [Description("Define el valor de pago")]      
        public int ValorPago { get; set; }

        [Description("Define el consecutivo del bono porcicarnes")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string ConsecutivoBono { get; set; }

        [Description("Define el empleado del bono porcicarnes / Todo usuario EVO es empleado pero no todo empleado está en EVO")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string EmpleadoBono { get; set; }
    }
}
