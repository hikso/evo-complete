using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 6-Dic/2019
    /// Descripción            : Representa una entrega del pedido.
    /// </summary>  

    [Table("Entregas")]
    [Description("Representa una entrega del pedido")]
    public class EFEntrega
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria de la entrega")]
        public int EntregaId { get; set; }

        [Description("Define la clave foránea a Usuario")]
        [Required]
        public int UsuarioId { get; set; }

        [Description("Define la clave foránea a TipoVehiculo")]
        [Required]
        public int TipoVehiculoId { get; set; }

        [Description("Define la clave foránea a Pedido")]
        [Required]
        public int PedidoId { get; set; }

        [Description("Define la clave foránea a EstadosEntrega")]
        public int? EstadoEntregaId { get; set; }

        [Description("Define la fecha de registro")]
        [Required]
        public DateTime FechaRegistro { get; set; }

        [Description("Define la fecha de entrega")]
        [Required]
        public DateTime FechaEntrega { get; set; }

        [Description("Define la fecha de entrega")]
        public DateTime? FechaActualizo { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a pedido
        /// </summary>  
        [ForeignKey("PedidoId")]
        public EFPedido Pedido { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Usuario 
        /// </summary>
        [ForeignKey("UsuarioId")]
        public EFUsuario Usuario { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Estados Entrega(Pedido) 
        /// </summary>

        [ForeignKey("EstadoEntregaId")]
        public EFEstadoEntrega EstadoEntrega { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a TipoVehiculo
        /// </summary>  
        [ForeignKey("TipoVehiculoId")]
        public EFTipoVehiculo TipoVehiculo { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a los detalles de entrega
        /// </summary>      
        public ICollection<EFDetalleEntrega> Detalles { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a PesajesEntrega
        /// </summary>      
        public ICollection<EFPesajeEntrega> PesajesEntrega { get; set; }

    }
}
