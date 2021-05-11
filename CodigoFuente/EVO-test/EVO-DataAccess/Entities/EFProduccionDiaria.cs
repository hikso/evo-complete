using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EVO_DataAccess.Entities
{

    /// <summary>
    /// Autor                  : Andrés Holguín Osorio
    /// Fecha de creación      : 25-Sep/2020
    /// </summary>    
    [Table("ProduccionDiaria")]
    [Description("Representa la tabla donde se cargan los archivos planos de la producción diaria")]
    public class EFProduccionDiaria
    {
   
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del archivo")]
        public int ProduccionDiariaId { get; set; }   

        [Required]
        [Description("Define la fecha de carga")]
        public DateTime FechaProduccion { get; set; }     

        [Required]
        [Description("Define el número de canales")]
        public int NumeroCanales { get; set; }

        [Description("Define el peso caliente del canal")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal PesoCaliente { get; set; }

        [Description("Define el peso promedio del día canal")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal PesoPromedioDia { get; set; }
      
    }
}
