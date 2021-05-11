using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 2-Abr/2020
    /// Descripción            : Representa un documento.
    /// </summary> 

    [Table("Documentos")]
    [Description("Representa un documento")]
    public class EFDocumento
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Se define la clave primaria")]
        public int DocumentoId { get; set; }

        [Required]
        [Description("Se define el nombre de un documento")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Documento { get; set; }

        [Required]
        [Description("Define si el documento se encuentra activo o inactivo")]
        public bool Activo { get; set; } = true;

        /// <summary>
        ///  Define la propiedad de navegación que representa los articulos a pesar
        /// </summary>
        public ICollection<EFPesajeArticulo> PesajesArticulo { get; set; }

    }
}
