using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 02-Ago/2019
    /// Descripción            : Representa un registro de audítoria.
    /// </summary>   
    [Table("RegistrosAuditoria")]
    [Description("Representa un registro de Audítoria")]
    public class EFRegistroAuditoria
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),Description("Define la clave primaria")]
        public int RegistroAuditoriaId { get; set; }

        /// <summary>
        /// Define la clave foreanea a Usuario
        /// </summary>
        /// 
        [Required]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define la fecha de registro del registro de audítoria
        /// </summary>
        [Required]
        [Description("Define la fecha del registro de audítoria")]
        public DateTime Fecha { get; set; }

        /// <summary>
        ///  Define la Acción del registro de audítoria
        /// </summary>
        [Required]
        [Description("Define la Acción del registro de audítoria")]
        public string Accion { get; set; }

        /// <summary>
        ///  Parámetros de la acción
        /// </summary>
        [Description("Se establece los parametros de la acción")]
        public string Parametros { get; set; }

        /// <summary>
        /// Define la IP del cliente el cual generó el registro de audítoria
        /// </summary>
        [Required]
        [Description("Define la IP del cliente el cual generó el registro de audítoria")]
        public string IP { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Usuario 
        /// </summary>
       
        [ForeignKey("UsuarioId")]
        public EFUsuario Usuario { get; set; }
    }
}