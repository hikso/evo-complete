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
    /// </summary>  
    [Table("DetallePedidos")]
    [Description("Representa un detalle de pedido")]
    public class EFDetallePedido
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del detalle de pedido")]
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Define la clave foránea de Pedido
        /// </summary>      
        [Required]
        public int PedidoId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Pedido 
        /// </summary>      
        [ForeignKey("PedidoId")]
        public EFPedido Pedido { get; set; }
        
        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        [Description("Define el código del artículo")]
        public string ItemCode { get; set; }       
       
        /// <summary>
        /// Define la clave foránea del estado del artículo
        /// </summary>      
        [Required]
        public int EstadoArticuloId { get; set; }      

        /// <summary>
        /// Define la propiedad de navegación a EstadosArticulo 
        /// </summary>      
        [ForeignKey("EstadoArticuloId")]
        public EFEstadoArticulo EstadoArticulo { get; set; }        

        [Required]
        [Description("Define la cantidad a solicitar")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal Cantidad { get; set; }
       
        [Description("Define la cantidad aprobada")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal? CantidadAprobada { get; set; }
       
        [Column(TypeName = "NVARCHAR(MAX)")]
        [Description("Define la observación")]
        public string Observacion { get; set; }

        /// <summary>
        /// Define la clave foránea a Empaques
        /// </summary>      
        [Required]
        public int EmpaqueId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Empaque 
        /// </summary>       
        [ForeignKey("EmpaqueId")]
        public EFEmpaque Empaque { get; set; }

    }
}