using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 19-Mar/2020    
    /// </summary> 

    [Table("ClientesParametrizacion")]
    [Description("Representa parametrizaciones por cliente")]
    public class EFClienteParametrizacion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),
          Description("Define la clave primaria")]
        public int ClienteParametrizacionId { get; set; }

        [Required]
        [Description("Define el código del cliente ya sea interno o externo")]
        public string CodigoCliente { get; set; }
      
        [Description("Define la tolerancia inferior en recepción")]
        public decimal? RecepcionToleranciaInferior { get; set; }
                
        [Description("Define la tolerancia superior en recepción")]
        public decimal? RecepcionToleranciaSuperior { get; set; }

        [Description("Define si se hace pesaje por código de barras en recepción")]
        public bool? RecepcionPesajeCodigoBarras { get; set; }

        [Description("Define el porcentaje de descuento para facturación")]  
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal? FacturacionPorcentajeDescuento { get; set; }

        [Description("Define si se puede duplicar pedidos")]
        public bool? DuplicarPedido { get; set; }
    }
}
