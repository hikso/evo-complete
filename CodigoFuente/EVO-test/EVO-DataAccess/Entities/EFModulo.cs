using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 02-Ago/2019
    /// Descripción            : Representa un módulo asociado a la funcionalidad
    /// </summary>    
    [Table("Modulos")]
    [Description("Representa un módulo asociado a la funcionalidad")]
    public class EFModulo
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Funcionalidades del sistema")]
        public int ModuloID { get; set; }

        /// <summary>
        /// Define el nombre del módulo
        /// </summary>
        ///     
        [Required]      
        [Description("Nombre de la funcionalidad")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Nombre { get; set; }

        /// <summary>
        ///  Define si el registro se encuentra activo o inactivo
        /// </summary>
        [Required]
        [Description("Define si el registro se encuentra activo o inactivo")]
        public bool Activo { get; set; } = false;

        /// <summary>
        ///  Define la propiedad de navegación de las funcionalidades de este módulo
        /// </summary>         
        public ICollection<EFFuncionalidad> Funcionalidades { get; set; }
    }
}