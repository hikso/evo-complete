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
    [Table("EstadosArticulo")]
    [Description("Representa un estado del artículo")]
    public class EFEstadoArticulo
    {      
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),Description("Define la clave primaria del estado del artículo")]
        public int EstadoArticuloId { get; set; } 
        
        [Required]
        [Description("Define el nombre del estado de articulo")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Nombre { get; set; }
       
        [Required]
        [Description("Define si el estado de artículo está activo")]
        public bool Activo { get; set; } = true;      

        /// <summary>
        ///  Define la propiedad de navegación que representa los detalles del pedido
        /// </summary>
        public ICollection<EFDetallePedido> DetallesPedido { get; set; }
    }
}