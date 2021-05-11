using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 23-Abr/2020 
    /// </summary>    
    [Table("Inventarios")]
    [Description("Representa un inventario")]
    public class EFInventario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int InventarioId { get; set; }       

        /// <summary>
        /// Define la clave foránea a TipoInventario
        /// </summary>
        [Required]
        public int TipoInventarioId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación de TipoInventario
        /// </summary>
        [ForeignKey("TipoInventarioId")]
        [Required]
        public EFTipoInventario TipoInventario { get; set; }

        /// <summary>
        /// Define la clave foránea a Procesos
        /// </summary>
        [Required]
        public int ProcesoId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación de Procesos
        /// </summary>
        [ForeignKey("ProcesoId")]
        [Required]
        public EFProceso Proceso { get; set; }

        /// <summary>
        /// Define la clave foránea a PesajesArticulo
        /// </summary>
        [Required]
        public int? PesajeArticuloId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación de PesajesArticulo
        /// </summary>
        [ForeignKey("PesajeArticuloId")]
        [Required]
        public EFPesajeArticulo PesajeArticulo { get; set; }

        /// <summary>
        /// Define la clave foránea a DetalleFactura
        /// </summary>
        [Required]
        public int? DetalleFacturaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación de DetalleFactura
        /// </summary>
        [ForeignKey("DetalleFacturaId")]
        [Required]
        public EFDetalleFactura DetalleFactura { get; set; }

        [Description("Define la fecha de registro")]
        [Required]
        public DateTime FechaRegistro { get; set; }

    }
}
