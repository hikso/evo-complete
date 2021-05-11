using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVO_DataAccess.Entities
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 11-Abr/2020 
    /// </summary>    
    [Table("CuadresCaja")]
    [Description("Representa un cuadre de caja")]
    public class EFCuadreCaja
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Description("Define la clave primaria")]
        public int CuadreCajaId { get; set; }

        /// <summary>
        /// Define la clave foránea de Caja
        /// </summary>       
        [Required]
        public int CajaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Evidencias
        /// </summary>       
        [ForeignKey("CajaId")]
        public EFCaja Caja { get; set; }

        /// <summary>
        /// Define la clave foránea de EstadosCuadreCaja
        /// </summary>       
        [Required]
        public int EstadoCuadreCajaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a CuadreCaja
        /// </summary>       
        [ForeignKey("EstadoCuadreCajaId")]
        public EFEstadoCuadreCaja EstadoCuadreCaja { get; set; }

        /// <summary>
        /// Define la clave foránea de Usuarios
        /// </summary>       
        [Required]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Usuarios
        /// </summary>       
        [ForeignKey("UsuarioId")]
        public EFUsuario Usuario { get; set; }

        /// <summary>
        /// Define la clave foránea de Inconsistencias
        /// </summary>       
        public int? InconsistenciaId { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Inconsistencias
        /// </summary>       
        [ForeignKey("InconsistenciaId")]
        public EFInconsistencia Inconsistencia { get; set; }

        [Required]
        [Description("Define el consecutivo por caja")]       
        public int Consecutivo { get; set; }

        /// <summary>
        /// Define la fecha del cuadre de caja
        /// </summary>       
        [Required]
        public DateTime FechaCuadre { get; set; }
              
        [Description("Define el valor asignado")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal? ValorAsignado { get; set; }
               
        [Description("Define el valor apertura")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal? ValorApertura { get; set; }

        [Description("Define el valor cierre")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal? ValorCierre { get; set; }

        [Description("Define el valor faltante o sobrante")]
        [Column(TypeName = "NUMERIC(19,6)")]
        public decimal? ValorFaltanteSobrante { get; set; }

        /// <summary>
        ///  Define la propiedad de navegación a Facturas
        /// </summary>
        public ICollection<EFFactura> Facturas { get; set; }

    }
}
