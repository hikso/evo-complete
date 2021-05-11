using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 23-Jul/2020    
    /// </summary> 

    [Table("TiposBodegasParametrizacion")]
    [Description("Representa parametrizaciones por tipo de bodega")]
    public class EFTipoBodegaParametrizacion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),
         Description("Define la clave primaria")]
        public int TipoBodegaParametrizacionId { get; set; }

        [Required]
        [Description("Define el prefijo de la bodega")]
        public string PrefijoBodega { get; set; }        

        [Required]
        [Description("Define el código de la bodega")]
        public string CodigoBodega { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Bodegas 
        /// </summary>       
        [ForeignKey("CodigoBodega")]
        public EFBodega Bodega { get; set; }

        [Description("Define la cantidad de pedidos en estado \"Borrador\" permitidos simultaneamente")]
        public int CantidadPedidosBorrador { get; set; }
    }
}
