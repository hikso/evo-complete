using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 02-Ago/2019
    /// Descripción            : Representa un rol del usuario.
    /// </summary>    
    [Table("Roles")]
    [Description("Representa un rol del usuario")]
    public class EFRol
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),Description("Se obtiene la clave primaria")]
        public int RolId { get; set; }

        /// <summary>
        /// Define el nombre del rol.
        /// </summary>
        [Required]
        [Description("Define el nombre del rol")]
        [Column(TypeName = "NVARCHAR(255)")]       
        public string Nombre { get; set; }

        /// <summary>
        ///  Define si el registro se encuentra activo o inactivo
        /// </summary>
        [Required]
        [Description("Define si el rol tendra acceso al sistema de Planta de Beneficio")]
        public bool PlantaBeneficio { get; set; } = true;

        /// <summary>
        ///  Define si el registro se encuentra activo o inactivo
        /// </summary>
        [Required]
        [Description("Define si el rol tendra acceso al sistema de Planta de Derivados Carnicos")]
        public bool PlantaDerivadosCarnicos { get; set; } = true;

        /// <summary>
        ///  Define si el registro se encuentra activo o inactivo
        /// </summary>
        [Required]
        [Description("Define si el rol tendra acceso al sistema de Puntos de Venta")]
        public bool PuntosVenta { get; set; } = true;

        /// <summary>
        ///  Define si el registro se encuentra activo o inactivo
        /// </summary>
        [Required]
        [Description("Define si el rol tendra acceso al sistema de Administracion")]
        public bool Administracion { get; set; } = true;

        /// <summary>
        ///  Define si el registro se encuentra activo o inactivo
        /// </summary>
        [Required]
        [Description("Define si el registro se encuentra activo o inactivo")]
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación que representa los usuarios de un rol
        /// </summary>
        public ICollection<EFUsuariosxRol> UsuariosxRol { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación que representa las funcionalidades de un rol
        /// </summary>
        public ICollection<EFFuncionalidadesxRol> FuncionalidadesxRol { get; set; }
    }
}