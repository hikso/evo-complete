using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 02-Ago/2019
    /// Descripción            : Representa la relación de muchos a muchos entre Usuario y Rol.
    /// </summary>
    [Table("UsuariosxRol")]
    [Description("Representa la relación de muchos a muchos entre Usuario y Rol")]
    public class EFUsuariosxRol
    {
        /// <summary>
        /// Define la clave primaria 
        /// </summary>
        [Key]
        [Description("Define la clave primaria")]
        public int UsuariosxRolId { get; set; }

        /// <summary>
        /// Define la clave foranea a Rol
        /// </summary>      
        [Required]
        public int RolId { get; set; }

        /// <summary>
        /// Define la clave foranea a Usuario
        /// </summary>      
        [Required]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación Rol
        /// </summary>
        [ForeignKey("RolId")]
        public virtual EFRol Rol { get; set; }

        /// <summary>
        /// Define la propiedad de navegación usuario
        /// </summary>
        [ForeignKey("UsuarioId")]
        public virtual EFUsuario Usuario { get; set; }        
    }
}