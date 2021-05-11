using System;
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
    [Table("Facturas")]
    [Description("Representa una factura")]
    public class EFFactura
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int FacturaId { get; set; }

        /// <summary>
        /// Define la clave foránea a TipoFactura
        /// </summary>
        [Required]
        public int TipoFacturaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación de TipoFactura
        /// </summary>
        [ForeignKey("TipoFacturaId")]
        [Required]
        public EFTipoFactura TipoFactura { get; set; }

        /// <summary>
        /// Define la clave foránea a CuadreCaja
        /// </summary>
        [Required]
        public int CuadreCajaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación de CuadreCaja
        /// </summary>
        [ForeignKey("CuadreCajaId")]
        [Required]
        public EFCuadreCaja CuadreCaja { get; set; }

        /// <summary>
        /// Define la clave foránea de Usuarios
        /// </summary>       
        [Required]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Usuarios
        /// </summary>       
        [ForeignKey("UsuarioId")]
        public EFUsuario Usuario { get; set; }

        /// <summary>
        /// Define la clave foránea de Vendedores
        /// </summary>       
        [Required]
        public int VendedorId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Vendedores
        /// </summary>       
        [ForeignKey("VendedorId")]
        public EFVendedor Vendedor { get; set; }

        /// <summary>
        /// Define la clave foránea de SocioNegocio
        /// </summary>       
        [Required]
        [Column(TypeName = "NVARCHAR(15)")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a SocioNegocio
        /// </summary>       
        [ForeignKey("Identificacion")]
        public EFSocioNegocio SocioNegocio { get; set; }

        /// <summary>
        /// Define la clave foránea de TiposBascula
        /// </summary>       
        [Required]
        public int TipoBasculaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a TiposBascula
        /// </summary>       
        [ForeignKey("TipoBasculaId")]
        public EFTipoBascula TipoBascula { get; set; }

        [Required]
        [Description("Define el total sin descuento")]        
        public int TotalSinDescuento { get; set; }

        [Description("Define el valor de descuento")]       
        public int? TotalConDescuento { get; set; }

        [Description("Define la cantidad de bolsas")]
        public int CantidadBolsas { get; set; }

        [Description("Define el porcentaje de descuento de la bolsa")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal? PorcentajeCobroBolsa { get; set; }

        [Description("Define el valor de la bolsa")]      
        public int? ValorBolsa { get; set; }

        [Description("Define el valor real de la bolsa por la cantidad de bolsas")]       
        public int? ImpuestoBolsas { get; set; }

        [Required]
        [Description("Define el valor total de los impuestos menos el de las bolsas")]       
        public int TotalImpuestos { get; set; }

        [Required]
        [Description("Define el total de la factura (Total Antes de Descuento - Descuento + Impuesto Bolsas + Impuesto - Retención - Retención ICA)")]
        public int TotalDocumento { get; set; }

        [Description("Define el valor devuelto")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public int? Devuelta { get; set; }

        [Required]
        [Description("Define el consecutivo")]
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Consecutivo { get; set; }

        [Required]
        [Description("Define la fecha de creación")]
        public DateTime FechaFactura { get; set; }

        [Description("Define las observaciones")]
        [Required]
        public string Observaciones { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a DetallesFactura
        /// </summary>
        public ICollection<EFDetalleFactura> DetallesFactura { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a DetallesFacturaFormaPago
        /// </summary>
        public ICollection<EFDetalleFacturaFormaPago> DetallesFacturaFormaPago { get; set; }

    }
}
