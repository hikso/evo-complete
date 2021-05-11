using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Andrés Holguín Osorio
    /// Fecha de creación      : 21-Agosto/2020
    /// </summary>    
    [Table("Series")]
    [Description("Representa la serie de un pedido")]
    public class EFSerie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria de la serie")]
        public int SerieID { get; set; }

        [Required]
        [Description("Define el código de la serie")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Series { get; set; }

        [Required]
        [Description("Define el nombre de la serie")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string SeriesName { get; set; }

        [Required]
        [Description("Define el número de documento inicial")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string InitialNum { get; set; }

        [Required]
        [Description("Define el próximo número de documento")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string NextNumber { get; set; }

        [Required]
        [Description("Define el último número de documento")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string LastNum { get; set; }

        [Required]
        [Description("Define si la serie se encuentra activa o inactiva")]
        public bool Activo { get; set; } = true;
    }
}
