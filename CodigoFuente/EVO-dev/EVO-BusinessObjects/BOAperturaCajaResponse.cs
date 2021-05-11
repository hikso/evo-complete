namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 12-Abr/2020
    /// Descripción      : Clase que representa un objeto de negocio de tipo AperturaCajaResponse
    /// </summary>
    public class BOAperturaCajaResponse
    {
        /// <summary>
        /// Indica la fecha de apertura de caja
        /// </summary>
        /// <value>Indica la fecha de apertura de caja</value>      
        public string FechaApertura { get; set; }

        /// <summary>
        /// Indica la fecha de cierre de caja
        /// </summary>
        /// <value>Indica la fecha de cierre de caja</value>       
        public string FechaCierre { get; set; }

        /// <summary>
        /// Indica el valor asignado a la caja
        /// </summary>
        /// <value>Indica el valor asignado a la caja</value>       
        public decimal ValorAsignado { get; set; }
    }
}
