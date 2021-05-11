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

    [Table("PesajesArticulo")]
    [Description("Representa el pesaje de un artículo")]
    public class EFPesajeArticulo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),
            Description("Define la clave primaria")]
        public int PesajeArticuloId { get; set; }

        /// <summary>
        /// Define la clave foránea de PesajesEntrega
        /// </summary>       
        [Required]
        public int PesajeEntregaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a PesajesEntrega
        /// </summary>       
        [ForeignKey("PesajeEntregaId")]
        public EFPesajeEntrega PesajeEntrega { get; set; }
        
        /// <summary>
        /// Define la clave foránea de DetalleEntrega
        /// </summary>       
        [Required]
        public int DetalleEntregaId { get; set; }
        
        /// <summary>
        /// Define la propiedad de navegación a DetalleEntrega
        /// </summary>     
        [ForeignKey("DetalleEntregaId")]
        public EFDetalleEntrega DetalleEntrega { get; set; }

        /// <summary>
        /// Define la clave foránea del usuario
        /// </summary>     
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación al Usuario
        /// </summary>      
        [ForeignKey("UsuarioId")]
        public EFUsuario Usuario { get; set; }

        /// <summary>
        /// Define la clave foránea de Documentos
        /// </summary>       
      
        public int? DocumentoId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Documentos
        /// </summary>       
        [ForeignKey("DocumentoId")]
        public EFDocumento Documento { get; set; }

        [Description("Define la cantidad recibida")]
        public decimal? CantidadRecibida { get; set; }       

        [Description("Define si el artículo de la entrega fue pesado en su totalidad")]       
        public bool? PesajeFinalizado { get; set; }

        [Description("Define si existe alguna inconsistencia entre pesaje de código de barras y báscula")]
        public bool? InconsistenciaCodigoBarras { get; set; }        

        /// <summary>
        ///  Define la propiedad de navegación a Pesajes
        /// </summary>
        public ICollection<EFPesaje> Pesajes { get; set; }

    }
}
