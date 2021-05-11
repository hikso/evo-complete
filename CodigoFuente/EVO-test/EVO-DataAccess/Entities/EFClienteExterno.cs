using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 21-Oct/2019
    /// Descripción            : Representa un rol del usuario.
    /// </summary>    
    [Table("ClientesExternos")]
    [Description("Representa un Cliente Externo")]
    public class EFClienteExterno
    {       
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]       
        [Column(TypeName = "NVARCHAR(255)")]
        public string CodigoCliente { get; set; }
      
        [Required]
        [Description("Define el nombre del cliente")]
        [Column(TypeName = "NVARCHAR(255)")]
        public string Nombre { get; set; }
        
        [Description("Define la zona de la bodega")]
        [Column(TypeName = "NVARCHAR(8)")]
        public string Zona { get; set; }
    }
}