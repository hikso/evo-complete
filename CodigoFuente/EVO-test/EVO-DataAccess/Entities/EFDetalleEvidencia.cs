using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 26-Mar/2020 
    /// </summary>    
    [Table("DetallesEvidencia")]
    [Description("Representa una detalle de evidencia")]
    public class EFDetalleEvidencia
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int DetalleEvidenciaId { get; set; }

        /// <summary>
        /// Define la clave foránea de Evidencias
        /// </summary>       
        [Required]
        public int EvidenciaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Evidencias
        /// </summary>       
        [ForeignKey("EvidenciaId")]
        public EFEvidencia Evidencia { get; set; }       

        /// <summary>
        /// Define nombre del archivo
        /// </summary>       
        [Required]
        public string NombreArchivo { get; set; }

        /// <summary>
        /// Extension del archivo
        /// </summary>       
        [Required]
        public string ExtensionArchivo { get; set; }

    }

}
