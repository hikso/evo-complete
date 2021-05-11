using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 02-Ago/2019
    /// Descripción            : Representa un parametro del sistema.
    /// </summary>  
    [Table("ParametrosGenerales")]
    [Description("Representa un parametro del sistema")]
    public class EFParametroGeneral
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Se define la clave primaria")]
        public int ParametroGeneralId { get; set; }
 
        /// <summary>
        /// Define el nombre de parametro
        /// </summary>
        [Required]
        [Description("Se define el nombre del parametro")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Nombre { get; set; }

        /// <summary>
        /// Define el valor del parametro
        /// </summary>
        [Required]
        [Description("Se define el valor del parametro")]
        [Column(TypeName = "NVARCHAR(MAX)")]
        public string Valor { get; set; }

        /// <summary>
        ///  Define si el registro se encuentra activo o inactivo
        /// </summary>
        [Required]
        [Description("Define si el registro se encuentra activo o inactivo")]
        public bool Activo { get; set; } = false;
    }
}