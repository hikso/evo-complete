using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Indica una acción por artículo
    /// </summary>
    public class Accion
    {

        /// <summary>
        /// Id de la acción
        /// </summary>
        /// <value>Id de la acción</value>     
        public int? AccionId { get; set; }

        /// <summary>
        /// Descripción de la acción
        /// </summary>
        /// <value>Descripción de la acción</value>        
        public string Nombre { get; set; }

    }
}
