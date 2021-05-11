using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.DTOs.WareHousesApi
{
    public class BOObtenerTipoBodegaAResponse
    {
        /// <summary>
        /// Indica el nombre del tipo de bodega
        /// </summary>
        /// <value>Indica el nombre del tipo de bodega</value>      
        public string TipoBodega { get; set; }

        /// <summary>
        /// Indica la lista de bodegas del tipo de bodega
        /// </summary>
        /// <value>Indica la lista de bodegas del tipo de bodega</value>     
        public List<BOObtenerTipoBodegaAResponseBodegas> Bodegas { get; set; }
    }
}
