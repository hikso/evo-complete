using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 28-Abr/2020 
    /// </summary>    
    [Table("VendedoresPuntoVenta")]
    [Description("Representa la asociación de un vendedor a un puntos de ventas")]
    public class EFVendedorPuntoVenta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int VendedorPuntoVentaId { get; set; }

        /// <summary>
        /// Define la clave foránea a Vendedores
        /// </summary>      
        [Required]
        public int VendedorId { get; set; }

        /// <summary>
        /// Define la propiedad de Vendedores
        /// </summary>
        [ForeignKey("VendedorId")]
        public virtual EFVendedor Vendedor { get; set; }

        /// <summary>
        /// Define la clave foránea a Bodegas
        /// </summary>      
        [Required]
        public string CodigoPuntoVenta { get; set; }

        /// <summary>
        /// Define la propiedad de Vendedores
        /// </summary>
        [ForeignKey("CodigoPuntoVenta")]
        public virtual EFBodega Bodega { get; set; }

    }
}
