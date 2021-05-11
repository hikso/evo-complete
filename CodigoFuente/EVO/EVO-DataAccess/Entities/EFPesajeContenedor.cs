using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 19-Mar/2020   
    /// </summary> 

    [Table("PesajesContenedor")]
    [Description("Representa un contenedor asociado a un pesaje")]
    public class EFPesajeContenedor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),
          Description("Define la clave primaria")]
        public int PesajeContenedorId { get; set; }

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

        /// <summary>
        /// Define la clave foránea a TipoContenedor
        /// </summary>       
        [Required]
        public int TipoContenedorId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a TipoContenedor
        /// </summary>      
        [ForeignKey("TipoContenedorId")]
        public EFTipoContenedor TipoContenedor { get; set; }

        /// <summary>
        /// Define la cantidad de este tipo de contenedores
        /// </summary>       
        [Required]
        public int Cantidad { get; set; }

    }
}
