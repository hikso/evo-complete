using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    /// <summary>
    /// Autor            : Gabriel Alfonso
    /// Fecha de Creación: 01-04-2020
    /// Descripción      : Esta clase representa un Registro de InconsistenciaDetalle en EVO
    /// </summary>
    public class BOInconsistenceDetail
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
        public string User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EvidenceDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EmailFrom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EmailTo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GUID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<BOInconsistenceFile> Files { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<BOArticuloDocumento> DocumentArticles { get; set; }

    }
}