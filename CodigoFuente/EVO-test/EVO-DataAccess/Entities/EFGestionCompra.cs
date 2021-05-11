using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 27-Ago/2020 
    /// </summary>    
    [Table("GestionCompras")]
    [Description("Representa la gestión de compra de un artículo")]
    public class EFGestionCompra
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int GestionCompraId { get; set; }

        /// <summary>
        /// Define la clave foránea a DetallesPedido
        /// </summary>
        [Required]
        public int DetallePedidoId { get; set; }


        /// <summary>
        /// Define la propiedad de navegación a DetallesPedido 
        /// </summary>       
        [ForeignKey("DetallePedidoId")]
        public EFDetallePedido DetallePedido { get; set; }

        /// <summary>
        /// Define la clave foránea a Acciones
        /// </summary>  
        public int AccionId { get; set; }
        
        /// <summary>
        /// Define la propiedad de navegación a Acciones 
        /// </summary>       
        [ForeignKey("AccionId")]
        public EFAccion Accion { get; set; }

        [Description("Cantidad")]        
        [Required]
        public decimal Cantidad { get; set; }

        [Description("Orden de compra")]
        [Column(TypeName = "NVARCHAR(255)")]
        [Required]
        public string OrdenCompra { get; set; }       

       
    }
}
