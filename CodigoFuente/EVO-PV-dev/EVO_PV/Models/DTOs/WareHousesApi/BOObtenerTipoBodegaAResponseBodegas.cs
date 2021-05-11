using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.DTOs.WareHousesApi
{
    public class BOObtenerTipoBodegaAResponseBodegas
    {
        /// <summary>
        /// Código de la bodega
        /// </summary>
        /// <value>Código de la bodega</value>       
        public string Codigo { get; set; }

        /// <summary>
        /// Nombre de la bodega
        /// </summary>
        /// <value>Nombre de la bodega</value>      
        public string Nombre { get; set; }
    }
}
