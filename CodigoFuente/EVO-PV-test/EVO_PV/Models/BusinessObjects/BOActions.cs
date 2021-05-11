using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOActions
    {

        /// <summary>
        /// Id de la acción del artículo
        /// </summary>
        /// <value>Id de la acción del artículo</value>
        public int? ActionId { get; set; }

        /// <summary>
        /// Acción del artículo
        /// </summary>
        /// <value>Acción del artículo</value>
        public string Name { get; set; }
    }
}
