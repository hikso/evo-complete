using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 26-Mar/2020 
    /// </summary>    
    [Table("Evidencias")]
    [Description("Representa una evidencia")]
    public class EFEvidencia
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int EvidenciaId { get; set; }

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
        /// Define la clave foránea del usuario
        /// </summary>     
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación al Usuario
        /// </summary>      
        [ForeignKey("UsuarioId")]
        public EFUsuario Usuario { get; set; }

        /// <summary>
        /// Define el GUID que sera el nombre del directorio de las evidencias
        /// </summary>       
        [Required]
        //Unique
        public string GUID { get; set; }

        /// <summary>
        /// Define las observaciones de la evidencia
        /// </summary>       
        [Required]
        public string Observaciones { get; set; }

        /// <summary>
        /// Define la fecha de la evidencia
        /// </summary>       
        [Required]
        public DateTime FechaEvidencia { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a DetallesEvidencia
        /// </summary>
        public ICollection<EFDetalleEvidencia> DetallesEvidencia { get; set; }

    }
}
