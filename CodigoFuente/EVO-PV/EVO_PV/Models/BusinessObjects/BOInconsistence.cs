namespace EVO_PV.Models.BusinessObjects
{
    /// <summary>
    /// Autor            : Gabriel Alfonso
    /// Fecha de Creación: 01-04-2020
    /// Descripción      : Esta clase representa un Registro de Inconsistencias en EVO
    /// </summary>
    public class BOInconsistence
    {
        /// <summary>
        /// Id de el registro
        /// </summary>
        public int InconsistenceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SalePoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RequestNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DeliveryNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EvidenceDate { get; set; }

    }
}