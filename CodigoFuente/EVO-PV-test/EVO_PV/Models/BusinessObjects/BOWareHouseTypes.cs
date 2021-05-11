using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOWareHouseTypes
    {
        /// <summary>
        /// Indica el prefijo de la bodega
        /// </summary>
        /// <value>Indica el prefijo de la bodega</value>      
        public string WhsPrefix { get; set; }

        /// <summary>
        /// Indica el nombre del tipo de bodega
        /// </summary>
        /// <value>Indica el nombre del tipo de bodega</value>      
        public string WhsTypeName { get; set; }

        /// <summary>
        /// Indica la lista de bodegas del tipo de bodega
        /// </summary>
        /// <value>Indica la lista de bodegas del tipo de bodega</value>     
        public List<BOWareHouse> WareHouses { get; set; }
    }
}
