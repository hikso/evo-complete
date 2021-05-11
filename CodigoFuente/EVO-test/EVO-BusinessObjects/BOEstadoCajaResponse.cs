namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 12-Abr/2020
    /// Descripción      : Clase que representa un objeto de negocio de tipo EstadoCajaResponse
    /// </summary>
    public class BOEstadoCajaResponse
    {
        /// <summary>
        /// Indica el estado del cierre de caja del día anterior
        /// </summary>
        /// <value>Indica el estado del cierre de caja del día anterior</value>      
        public bool CierreCajaAnterior { get; set; }

        /// <summary>
        /// Indica el estado del apertura de caja del día de hoy
        /// </summary>
        /// <value>Indica el estado del apertura de caja del día de hoy</value>      
        public bool AperturaCajaActual { get; set; }

        /// <summary>
        /// Indica el cuadre de caja de apertura
        /// </summary>
        /// <value>12</value>      
        public int CuadreCajaId { get; set; }
    }
}
