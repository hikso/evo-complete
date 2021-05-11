using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 02-Ago/2019
    /// Descripción            :Funcionalidadesde del sistema
    /// </summary>
    [Table("Funcionalidades")]
    [Description("Funcionalidades del sistema")]
    public class EFFuncionalidad
    {
        /// <summary>
        /// Id de la Funcionalidad
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Id de la funcionalidad")]
        public int FuncionalidadId { get; set; }

        /// <summary>
        /// Id del Módulo
        /// </summary>
        [Required]
        [Description("Id del Módulo")]
        public int ModuloId { get; set; }

        /// <summary>
        /// Define el nombre de la funcionalidad
        /// </summary>
        [Required]
        [Description("Nombre de la funcionalidad")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Nombre { get; set; }

        /// <summary>
        ///  Define si el registro se encuentra activo o inactivo
        /// </summary>
        [Required]
        [Description("Define si el registro se encuentra activo o inactivo")]
        public bool Activo { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación al módulo
        /// </summary>
        [ForeignKey("ModuloId")]
        public EFModulo Modulo { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación de las funcionalidades de un rol
        /// </summary>
        public ICollection<EFFuncionalidadesxRol> FuncionalidadesxRol { get; set; }
    }
}
