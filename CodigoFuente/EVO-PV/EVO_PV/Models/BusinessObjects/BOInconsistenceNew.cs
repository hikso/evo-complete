using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOInconsistenceNew
    {
        /// <summary>
        /// Id del pesaje entrega
        /// </summary>
        /// <value>Id del pesaje entrega</value>
        public int ArticleWeighingId { get; set; }

        /// <summary>
        /// Observaciones de la evidencia
        /// </summary>
        /// <value>Observaciones de la evidencia</value>
        public string Observation { get; set; }

        /// <summary>
        /// Gets or Sets Detalles
        /// </summary>
        public List<BOInconsistenceFile> Details { get; set; }
    }
}
