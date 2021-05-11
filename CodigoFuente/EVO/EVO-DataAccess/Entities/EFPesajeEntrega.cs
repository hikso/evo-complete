using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 19-Mar/2020    
    /// </summary>   

    [Table("PesajesEntrega")]
    [Description("Representa el pesaje de una entrega")]
    public class EFPesajeEntrega
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),
           Description("Define la clave primaria")]
        public int PesajeEntregaId { get; set; }        

        [Description("Define el consecutivo")]
        [Required]
        public int Consecutivo { get; set; }

        /// <summary>
        /// Define la clave foránea de EstadoEntrega
        /// </summary>       
        [Required]
        public int EstadoEntregaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a EstadosEntrega
        /// </summary>       
        [ForeignKey("EstadoEntregaId")]
        public EFEstadoEntrega EstadoEntrega { get; set; }

        /// <summary>
        /// Define la clave foránea de Entrega
        /// </summary>       
        [Required]
        public int EntregaId { get; set; }       

        [Description("Define si ya finalizó el proceso")]
        public bool? Finalizado { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Entrega
        /// </summary>       
        [ForeignKey("EntregaId")]
        public EFEntrega Entrega { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a PesajesArticulo
        /// </summary>
        public ICollection<EFPesajeArticulo> PesajesArticulo { get; set; }
    }
}