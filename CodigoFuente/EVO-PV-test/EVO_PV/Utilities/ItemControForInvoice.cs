using EVO_PV.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Utilities
{
    public class ItemControForInvoice
    {
        /// <summary>
        /// Id del detalle de la entrega
        /// </summary>
        /// <value>Id del detalle de la entrega</value>
        public string Title { get; set; }

        /// <summary>
        /// Id del tipo de la báscula
        /// </summary>
        /// <value>Id del tipo de la báscula</value>
        public UCGenerateInvoice UCGenerateInvoice { get; set; }
    }
}
