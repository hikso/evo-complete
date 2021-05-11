using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOReceiveFinalizedDocuments
    {
        /// <summary>
        /// Inconsistencias código de barras
        /// </summary>
        /// <value>Inconsistencias código de barras</value>
        public string BarCodeInconsistences { get; set; }


        /// <summary>
        /// Documentos basados en las inconsistencias generadas
        /// </summary>
        public List<BOArticuloDocumento> Documents { get; set; }
    }
}
