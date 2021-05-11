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
    [Table("ProduccionSemanal")]
    [Description("Representa la tabla donde se cargan los archivos con su producción semanal")]
    public class EFProduccionSemanal
    {
   
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria de la produccion semanal")]
        public int ProduccionSemanalId { get; set; }

                     
        [Required]
        [Description("Define el código del artículo")]
        [Column(TypeName = "NVARCHAR(50)")]
        public string CodigoArticulo { get; set; }

        [Required]
        [Description("Define el año de canales")]
        public int Ano { get; set; }

        [Required]
        [Description("Define el mes de canales")]
        public int Mes { get; set; }

        [Required]
        [Description("Define la semana de canales")]
        public int Semana { get; set; }
      

        [Description("Define el peso total del canal")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal PesoTotal { get; set; }

        [Description("Define el peso deshuesado total del canal")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal PesoDeshuesadoTotal { get; set; }

        [Description("Define el peso porcentaje del articulo del  total del canal")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal PorcentajeArticulo { get; set; }

        [Required]
        [Description("Define la fecha de carga")]
        public DateTime FechaCarga { get; set; }

        [Description("Define el nombre del archivo")]
        [Column(TypeName = "NVARCHAR(50)")]
        public string NombreArchivo { get; set; }


    }
}
