using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 12-Abr/2020
    /// Descripción      : Clase que representa un objeto de negocio de tipo CuadreCaja
    /// </summary>
    public class BOCuadreCaja
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public int CuadreCajaId { get; set; }

        /// <summary>
        /// Define la clave foránea de Caja
        /// </summary>      
        public int CajaId { get; set; }        

        /// <summary>
        /// Define la clave foránea de EstadosCuadreCaja
        /// </summary>     
        public int EstadoCuadreCajaId { get; set; }       

        /// <summary>
        /// Define la clave foránea de Usuarios
        /// </summary>       
        public int UsuarioId { get; set; }     

        /// <summary>
        /// Define la clave foránea de Inconsistencias
        /// </summary>       
        public int InconsistenciaId { get; set; }
       
        public int Consecutivo { get; set; }

        /// <summary>
        /// Define la fecha del cuadre de caja
        /// </summary>       
        public DateTime FechaCuadre { get; set; }

        /// <summary>
        /// Define el valor asignado
        /// </summary>
        public decimal? ValorAsignado { get; set; }

        /// <summary>
        /// Define el valor apertura
        /// </summary>
        public decimal? ValorApertura { get; set; }

        /// <summary>
        /// Define el valor cierre
        /// </summary>
        public decimal? ValorCierre { get; set; }

        /// <summary>
        /// Define el valor faltante o sobrante
        /// </summary>
        public decimal? ValorFaltanteSobrante { get; set; }
    }
}
