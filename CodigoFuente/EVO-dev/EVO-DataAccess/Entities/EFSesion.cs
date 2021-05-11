using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 25-Ago/2019
    /// Descripción            : Representa la sesión del usuario.
    /// </summary>   
    [Table("Sesiones")]
    [Description("Representa una sesión del usuario")]
    public class EFSesion
    {
        /// <summary>
        /// Define la clave primaria de la sesión
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),
            Description("Define la clave primaria de la sesión")]
        public int SesionId { get; set; }

        /// <summary>
        /// Define la clave foránea del usuario de la sesión
        /// </summary>       
        [Required]
        public int UsuarioId { get; set; }

        /// <summary>
        ///  Define el token de la sesión
        /// </summary>
        [Required]
        [Description("Define el token de la sesión")]
        public string Token { get; set; }

        /// <summary>
        ///  Define la IP del equipo que generó el inicio de la sesión
        /// </summary>
        [Required]
        [Description("Define la IP del equipo que generó el inicio de la sesión")]
        public string IP { get; set; }

        /// <summary>
        /// Define la fecha de inicio de sesión
        /// </summary>
        [Required]
        [Description("Define la fecha del inicio de la sesión")]
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Define la fecha de expiración de sesión
        /// </summary>
        [Required]
        [Description("Define la fecha de expiración de sesión")]
        public DateTime FechaExpiracion { get; set; }

        /// <summary>
        /// Define la propiedad de navegación al usuario de la sesión
        /// </summary>
       
        [ForeignKey("UsuarioId")]
        public EFUsuario Usuario { get; set; }
    }
}