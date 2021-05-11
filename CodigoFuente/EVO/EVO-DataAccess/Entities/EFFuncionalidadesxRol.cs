using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 02-Ago/2019
    /// Descripción            : Representa la relación muchos a muchos entre rol y funcionalidad.
    /// </summary>
    
    [Table("FuncionalidadesxRol")]
    [Description("Represental la relación de muchos a muchos entre rol y funcionalidad")]
    public class EFFuncionalidadesxRol
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        [Key]
        [Description("Id de la funcionalidad por Rol")]
        public int FuncionalidadesxRolId { get; set; }

        /// <summary>
        /// Define la clave foranea a rol
        /// </summary>
        [Required]
        public int RolId { get; set; }

        /// <summary>
        /// Define la clave foranea a funcionlidad
        /// </summary>
        [Required]
        public int FuncionalidadId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación de rol
        /// </summary>
        [ForeignKey("RolId")]
        public EFRol Rol { get; set; }
      
        /// <summary>
        /// Define la propiedad de navegación de funcionalidad
        /// </summary>
        [ForeignKey("FuncionalidadId")]       
        public EFFuncionalidad Funcionalidad { get; set; }
    }
}