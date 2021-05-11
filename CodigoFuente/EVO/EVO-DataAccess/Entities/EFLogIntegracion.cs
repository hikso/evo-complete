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
    /// Fecha de creación      : 23-Sep/2019
    /// Descripción            : Representa un log de integración.
    /// </summary>   
    [Table("LogIntegraciones")]
    [Description("Representa un log de integración")]
    public class EFLogIntegracion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del log de integración")]       
        public int LogIntegracionId { get; set; }

        /// <summary>
        /// Define la clave foránea la ejecucion de la ejecución del job
        /// </summary>  
        [Description("Define el id de la ejecución del job")]
        [Required]
        public int InstanceId { get; set; }

        [Description("Define el id de la ejecución de la integración")]
        [Required]
        [Column(TypeName = "NVARCHAR(255)")]
        public string ExecutionId { get; set; }

        [Description("Define el id del job")]
        [Required]
        [Column(TypeName = "NVARCHAR(255)")]
        public string JobId { get; set; }

        

    }
}
