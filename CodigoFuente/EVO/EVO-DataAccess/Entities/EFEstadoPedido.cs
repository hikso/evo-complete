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
    [Table("EstadosPedido")]
    [Description("Representa un estado del pedido")]
    public class EFEstadoPedido
    {      
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),Description("Define la clave primaria del estado del pedido")]
        public int EstadoPedidoId { get; set; } 
        
        [Required]
        [Description("Define el nombre del estado del pedido")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Nombre { get; set; }
       
        [Required]
        [Description("Define si el estado está activo")]
        public bool Activo { get; set; } = true;      

        /// <summary>
        ///  Define la propiedad de navegación que representa los pedidos con este estado
        /// </summary>
        public ICollection<EFPedido> Pedidos { get; set; }
    }
}