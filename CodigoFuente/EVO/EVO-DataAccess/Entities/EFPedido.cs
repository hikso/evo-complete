using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 17-Sep/2019
    /// Descripción            : Representa un pedido.
    /// </summary>    
    [Table("Pedidos")]
    [Description("Representa un pedido")]
    public class EFPedido
    {        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),Description("Define la clave primaria del pedido")]
        public int PedidoId { get; set; }

        /// <summary>
        /// Define la clave foránea de quien hizo el pedido
        /// </summary>       
        [Required]
        [Column(TypeName = "NVARCHAR(8)")]
        public string WhsCode { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación de quien hizo el pedido
        /// </summary>    
        [ForeignKey("WhsCode")]
        public EFBodega BodegaDe { get; set; }

        /// <summary>
        /// Define la clave foránea para quien va el pedido
        /// </summary>       
        [Required]
        [Column(TypeName = "NVARCHAR(8)")]
        public string SolicitudPara { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación de quien hizo el pedido
        /// </summary>    
        [ForeignKey("SolicitudPara")]
        public EFBodega BodegaPara { get; set; }

        /// <summary>
        /// Define la clave foránea a Usuario
        /// </summary>      
        [Required]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Usuario 
        /// </summary>
        [ForeignKey("UsuarioId")]
        public EFUsuario Usuario { get; set; }

        [Description("Define la fecha del pedido")]
        [Required]
        public DateTime FechaPedido { get; set; }

        [Description("Define la fecha de entrega del pedido")]
        public DateTime? FechaEntrega { get; set; }       

        [Description("Define la fecha de aprobación del pedido por parte de la planta")]
        public DateTime? FechaAprobacionPlanta { get; set; }

        [Description("Define el número del pedido")]
    
        public int? NumeroPedido { get; set; }     

        /// <summary>
        /// Define la clave foránea a EstadosPedido
        /// </summary>      
        [Required]       
        public int EstadoPedidoId { get; set; }        


        /// <summary>
        /// Define la propiedad de navegación a EstadosPedido 
        /// </summary>       
        [ForeignKey("EstadoPedidoId")]
        public EFEstadoPedido EstadoPedido { get; set; }

        /// <summary>
        /// Define la clave foránea a TiposSolicitud
        /// </summary>      
        [Required]
        public int TipoSolicitudId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a TiposSolicitud 
        /// </summary>       
        [ForeignKey("TipoSolicitudId")]
        public EFTipoSolicitud TipoSolicitud { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a los detalles de pedido
        /// </summary>      
        public ICollection<EFDetallePedido> DetallesXPedido { get; set; }
        
        /// <summary>
        /// Define la propiedad de navegación a los detalles de entregas
        /// </summary>      
        public ICollection<EFEntrega> EntregasXPedido { get; set; }
    }
}