using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 17-Sep/2019   
    /// </summary>    
    [Table("ArticulosXBodega")]
    [Description("Representa un artículo de una bodega")]
    public class EFArticuloBodega
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria compuesta de artículo bodega 1")]
        [Column(TypeName = "NVARCHAR(50)")]
        public string ItemCode { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria compuesta de artículo bodega 2")]
        [Column(TypeName = "NVARCHAR(8)")]
        public string WhsCode { get; set; }

        [Required]
        [Description("Define el stock del artículo")]
        [Column(TypeName = "NUMERIC(19,6)")]

        public decimal? OnHand { get; set; }

        [Required]
        [Description("Define el minimo stock del artículo")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal? MinStock { get; set; }

        [Required]
        [Description("Define el máximo stock del artículo")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal? MaxStock { get; set; }




    }
}