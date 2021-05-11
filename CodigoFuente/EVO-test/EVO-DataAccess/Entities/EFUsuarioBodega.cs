using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 09-Jul/2020 
    /// </summary>    
    [Table("UsuariosBodega")]
    [Description("Representa el acceso de un usuario a una bodega")]
    public class EFUsuarioBodega
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del proceso")]
        public int UsuarioBodegaId { get; set; }

        /// <summary>
        /// Define la clave foránea del usuario de la sesión
        /// </summary>       
        [Required]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación al usuario de la sesión
        /// </summary>

        [ForeignKey("UsuarioId")]
        public EFUsuario Usuario { get; set; }

        /// <summary>
        /// Define la clave foránea de la bodega
        /// </summary>       
        [Required]
        public string CodigoBodega { get; set; }

        /// <summary>
        /// Define la propiedad de navegación Bodega
        /// </summary>

        [ForeignKey("CodigoBodega")]
        public EFBodega Bodega { get; set; }

    }
}
