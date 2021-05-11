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
    [Table("DetalleProduccionDiaria")]
    [Description("Representa la tabla donde se cargan la producción Diaria")]
    public class EFDetalleProduccionDiaria
    {
   
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del archivo")]
        public int DetalleProduccionDiariaId { get; set; }

        [Required]
        [Description("Define el código del artículo")]
        [Column(TypeName = "NVARCHAR(50)")]
        public string CodigoArticulo { get; set; }      


        [Description("Define el dia 1 de la semana")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal ProduccionDiaria { get; set; }     
               
        [Description("Define  el id de la producción Diaria")]
        [Required]
        public int ProduccionDiariaId { get; set; }

        [Description("Define  el id de la producción semanal")]
        [Required]
        public int ProduccionSemanalId { get; set; }
       
    }
}
