using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 12-Abr/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo AperturaCajaRequest
    /// </summary>
    public class BOAperturaCajaRequest
    {
        /// <summary>
        /// Indica el código del punto de venta
        /// </summary>
        /// <value>Indica el código del punto de venta</value>     
        public string CodigoPuntoVenta { get; set; }

        /// <summary>
        /// Indica el valor de apertura de la caja
        /// </summary>
        /// <value>Indica el valor de apertura de la caja</value>     
        public decimal? ValorApertura { get; set; }

        /// <summary>
        /// Indica el usuario que realizó la apertura de caja
        /// </summary>
        /// <value>Indica el usuario que realizó la apertura de caja</value>     
        public string Usuario { get; set; }

        /// <summary>
        /// Indica la IP del equipo que realizó la apertura de caja
        /// </summary>
        /// <value>Indica la IP del equipo que realizó la apertura de caja</value>     
        public string IP { get; set; }

        /// <summary>
        /// Indica el id del usuario que realizó la apertura de caja
        /// </summary>
        /// <value>Indica el id del usuario que realizó la apertura de caja</value>     
        public int UsuarioId { get; set; }       

        /// <summary>
        ///  Indica el valor asignado a esa caja
        /// </summary>
        public decimal? ValorAsignado { get; set; }

        /// <summary>
        ///  Indica la fecha de cuadre
        /// </summary>
        public DateTime FechaCuadre { get; set; }

        /// <summary>
        /// Indica el id de la caja
        /// </summary>
        public int CajaId { get; set; }

        /// <summary>
        /// Indica el valor faltante o sobrante
        /// </summary>
        public decimal? ValorFaltanteSobrante { get; set; }

        /// <summary>
        /// Indica el id del estado de cuadre de caja
        /// </summary>
        public int EstadoCuadreCajaId { get; set; }

        /// <summary>
        /// Indica la inconsistencia generada en esta apertura
        /// </summary>
        public int? InconsistenciaId { get; set; }

        /// <summary>
        /// Indica el consecutivo por caja
        /// </summary>
        public int Consecutivo { get; set; }
    }
}
