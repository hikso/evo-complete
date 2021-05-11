using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOReason
    {
        /// <summary>
        /// Id del motivo
        /// </summary>
        /// <value>Id del motivo</value>
        public int ReasonId { get; set; }

        /// <summary>
        /// Valor del motivo
        /// </summary>
        /// <value>Valor del motivo</value>
        public string ReasonName { get; set; }
    }
}
