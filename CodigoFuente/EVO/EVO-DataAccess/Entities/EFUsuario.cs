using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 02-Ago/2019
    /// Descripción            : Representa a un usuario del sistema.
    /// </summary>
    [Table("Usuarios")]
    [Description("Representa a un usuario del sistema")]
    public class EFUsuario
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define el usuario
        /// </summary>
        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        [Description("Se define el Usuario")]       
        public string Usuario { get; set; }

        /// <summary>
        /// Define el nombre del usuario
        /// </summary>
        [Required]
        [Description("Define el nombre del usuario")]
        [Column(TypeName = "VARCHAR(255)")]       
        public string Nombre { get; set; }

        /// <summary>
        /// Define el nombre del usuario
        /// </summary>
        [Required]
        [Description("Define la identificación del usuario")]
        [Column(TypeName = "VARCHAR(255)")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Define si el registro se encuentra activo o inactivo
        /// </summary>
        [Required]
        [Description("Define si el registro se encuentra activo o inactivo")]
        public bool Activo { get; set; } = false;

        /// <summary>
        ///  Define la propiedad de navegación de los roles de un usuario
        /// </summary>
        public ICollection<EFUsuariosxRol> UsuariosxRol { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a CuadresCaja
        /// </summary>
        public ICollection<EFCuadreCaja> CuadresCaja { get; set; }
    }
}