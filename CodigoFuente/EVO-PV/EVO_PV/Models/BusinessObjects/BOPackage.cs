using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{

    public class BOPackage
    {

        /// <summary>
        /// Id del empaque
        /// </summary>
        /// <value>Id del empaque</value>
        public int? PackageId { get; set; }

        /// <summary>
        /// Nombre del empaque
        /// </summary>
        /// <value>Nombre del empaque</value>
        public string PackageName{ get; set; }
    }
}
