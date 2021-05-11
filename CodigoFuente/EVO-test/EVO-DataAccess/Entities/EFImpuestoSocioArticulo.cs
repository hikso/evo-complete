using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 26-Abr/2020 
    /// </summary>    
    [Table("ImpuestosSocioArticulo")]
    [Description("Representa un impuesto aplicado a un socio y un artículo")]
    public class EFImpuestoSocioArticulo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int ImpuestoSocioArticuloId { get; set; }

        /// <summary>
        /// Define la clave foránea de SocioNegocio
        /// </summary>       
        [Required]
        public string Identificacion { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a SocioNegocio
        /// </summary>       
        [ForeignKey("Identificacion")]
        public EFSocioNegocio SocioNegocio { get; set; }

        /// <summary>
        /// Define la clave foránea de Articulo
        /// </summary>       
        [Required]       
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Articulo
        /// </summary>       
        [ForeignKey("CodigoArticulo")]        
        public EFArticulo Articulo { get; set; }        

        [Required]
        [Description("Define el id del impuesto")]
        public int ImpuestoId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Impuestos
        /// </summary>       
        [ForeignKey("ImpuestoId")]
        public EFImpuesto Impuesto { get; set; }
      
    }
}
