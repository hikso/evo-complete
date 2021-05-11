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
    [Table("ArchivosPlano")]
    [Description("Representa la tabla donde se cargan los archivos planos")]
    public class EFArchivosPlano
    {
   
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria del archivo")]
        public int ArchivoId { get; set; }

        [Required]
        [Description("Define el código del artículo")]
        [Column(TypeName = "NVARCHAR(50)")]
        public string CodigoArticulo { get; set; }

        [Required]
        [Description("Define el nombre del artículo")]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Nombre { get; set; }


        [Required]
        [Description("Define la fecha de carga")]
        public DateTime FechaCarga { get; set; }

        [Required]
        [Description("Define la fecha inicial")]
        public DateTime FechaInicial { get; set; }

        [Required]
        [Description("Define la fecha final")]
        public DateTime FechaFinal { get; set; }

        [Required]
        [Description("Define el número de canales")]
        public int NumeroCanales { get; set; }


        [Description("Define el dia 1 de la semana")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal DiaUno { get; set; }

        [Description("Define el dia 2 de la semana")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal DiaDos { get; set; }

        [Description("Define el dia 3 de la semana")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal DiaTres { get; set; }

        [Description("Define el dia 4 de la semana")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal DiaCuatro { get; set; }

        [Description("Define el dia 5 de la semana")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal DiaCinco { get; set; }

        [Description("Define el dia 6 de la semana")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal DiaSeis { get; set; }

        [Description("Define el dia 7 de la semana")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal DiaSiete { get; set; }

        [Description("Define el peso caliente del canal")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal PesoCaliente { get; set; }

        [Description("Define el peso promedio del día canal")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal PesoPromedioDia { get; set; }

        [Description("Define el peso total del canal")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal PesoTotal { get; set; }

        [Description("Define el peso deshuesado total del canal")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal PesoDeshuesadoTotal { get; set; }

        [Description("Define el peso priomedio del canal")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal PesoPromedio { get; set; }

        [Description("Define el porcentaje artículo")]
        [Column(TypeName = "NVARCHAR(10)")]
        public string PorcentajeArticulo { get; set; }
               
        [Description("Define  artículo")]        
        public int SemanaCarga { get; set; }

        [Description("Define el porcentaje artículo")]
        [Column(TypeName = "NVARCHAR(200)")]
        public string NombreArchivo { get; set; }

        [Description("Define el  control si se cargó o no el artículo")]
        public bool ControlCarga { get; set; }

    }
}
