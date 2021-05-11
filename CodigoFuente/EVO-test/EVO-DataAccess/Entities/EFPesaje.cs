using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 19-Mar/2020   
    /// </summary>   

    [Table("Pesajes")]
    [Description("Representa un pesaje de un artículo")]
    public class EFPesaje
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),
           Description("Define la clave primaria")]
        public int PesajeId { get; set; }

        [Description("Define la fecha del pesaje")]
        [Required]
        public DateTime FechaPesaje { get; set; }

        /// <summary>
        /// Define la clave foránea a PesajesArticulo
        /// </summary>       
        [Required]
        public int PesajeArticuloId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a PesajesArticulo
        /// </summary>      
        [ForeignKey("PesajeArticuloId")]
        public EFPesajeArticulo PesajeArticulo { get; set; }

        /// <summary>
        /// Define la clave foránea del usuario
        /// </summary>       
        [Required]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación al Usuario
        /// </summary>      
        [ForeignKey("UsuarioId")]
        public EFUsuario Usuario { get; set; }

        /// <summary>
        /// Define la clave foránea de TiposBascula
        /// </summary>       
        [Required]
        public int TipoBasculaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a TiposBascula
        /// </summary>      
        [ForeignKey("TipoBasculaId")]
        public EFTipoBascula TipoBascula { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a PesajesCodigoBarras
        /// </summary>
        public ICollection<EFPesajeCodigoBarras> PesajesCodigoBarras { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a PesajesContenedor
        /// </summary>
        public ICollection<EFPesajeContenedor> PesajeContenedor { get; set; }
      
        [Description("Define el código de la bodega donde está almacenado el artículo a pesar")]
        public string CodigoBodega { get; set; }

        [Required]
        [Description("Define el peso de la báscula kg")]
        public decimal PesoBascula { get; set; }

        [Required]
        [Description("Define el peso báscula menos peso de los contenedores en kg")]
        public decimal PesoBasculaArticulos { get; set; }

        [Description("Define el peso de todos los códigos de barras asociados a este pesaje kg")]
        public decimal? PesoCodigosBarras { get; set; }
       
        [Description("Define la cantidad máxima de contenedores no base")]
        public string PesajeAl { get; set; }

    }
}
