using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 12-Abr/2020
    /// Descripción      : Clase que representa un objeto de negocio de tipo caja
    /// </summary>
    public class BOCaja
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public int CajaId { get; set; }

        /// <summary>
        /// Define el código del punto de venta
        /// </summary>
        public string CodigoPuntoVenta { get; set; }

        /// <summary>
        /// Define la IP del equipo para identificar la Caja
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Define el valor asignado
        /// </summary>
        public decimal ValorAsignado { get; set; }       

        public List<BOCuadreCaja> CuadresCaja { get; set; }

    }
}
