using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 6-Dic/2019
    /// Descripción            : Representa un detalle de la entrega del pedido.
    /// </summary>  

    [Table("DetalleEntregas")]
    [Description("Representa un detalle de la entrega del pedido")]
    public class EFDetalleEntrega
    {
        [Key, DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del detalle de la entrega del pedido")]
        public int DetalleEntregaId { get; set; }

        [Description("Define la clave foránea a Entregas")]
        [Required]
        public int EntregaId { get; set; }   
        
        /// <summary>
        /// Define la propiedad de navegación de entrega
        /// </summary>
        [ForeignKey("EntregaId")]
        public EFEntrega Entrega { get; set; }

        [Description("Define la clave foránea a DetallePedidos")]
        [Required]
        public int DetallePedidoId { get; set; }
        
        /// <summary>
        /// Define la propiedad de navegación detalle pedido
        /// </summary>
        [ForeignKey("DetallePedidoId")]
        public EFDetallePedido DetallePedido { get; set; }

        [Description("Define la cantidad a entregar")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a PesajesArticulo
        /// </summary>     

        public EFPesajeArticulo PesajeArticulo { get; set; }

    }
}
