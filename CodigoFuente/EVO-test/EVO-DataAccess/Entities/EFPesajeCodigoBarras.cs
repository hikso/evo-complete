using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 19-Mar/2020
    /// </summary> 

    [Table("PesajesCodigoBarras")]
    [Description("Representa el pesaje de un contenedor por código de barras")]
    public class EFPesajeCodigoBarras
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),
           Description("Define la clave primaria")]
        public int PesajeCodigoBarrasId { get; set; }

        /// <summary>
        /// Define la clave foránea a Pesajes
        /// </summary>       
        [Required]
        public int PesajeId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Pesajes
        /// </summary>      
        [ForeignKey("PesajeId")]
        public EFPesaje Pesaje { get; set; }

        [Required]
        [Description("Define el código de barras del contenedor")]
        public string CodigoBarras { get; set; }

        [Required]
        [Description("Define el lote de donde fué sacado el contenedor")]
        public string Lote { get; set; }

        [Required]
        [Description("Define la fecha de vencimiento de los artículos del contenedor")]
        public DateTime FechaVencimiento { get; set; }

        [Required]
        [Description("Define la unidades del artículo del contenedor")]
        public int Unidades { get; set; }

        [Required]
        [Description("Define el peso que suman los artículos del contenedor")]
        public decimal Peso { get; set; }

        /// <summary>
        /// Define la clave foránea del usuario
        /// </summary>       
        [Required]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación al Usuario
        /// </summary>      
        [ForeignKey("UsuarioId")]
        public EFUsuario Usuario { get; set; }

    }
}
