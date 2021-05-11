using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 10-Jul/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo ObtenerTipoBodegaAResponse
    /// </summary>
    public class BOObtenerTipoBodegaAResponse
    {
        /// <summary>
        /// Indica el prefijo de la bodega
        /// </summary>
        /// <value>Indica el prefijo de la bodega</value>      
        public string PrefijoBodega { get; set; }

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
