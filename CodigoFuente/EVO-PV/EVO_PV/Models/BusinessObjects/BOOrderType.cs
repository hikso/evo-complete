using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOOrderType
    {
        /// <summary>
        /// Id del tipo de solicitud
        /// </summary>
        /// <value>Id del tipo de solicitud</value>
        public int? OrderTypeId { get; set; }

        /// <summary>
        /// Nombre del tipo de solicitud
        /// </summary>
        /// <value>Nombre del tipo de solicitud</value>
        public string OrderTypeName { get; set; }
    }
}
