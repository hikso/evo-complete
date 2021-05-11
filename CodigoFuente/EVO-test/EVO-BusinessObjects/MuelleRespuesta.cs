using System;
using System.Collections.Generic;
using System.Text;


namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Andrés Holguín
    /// Fecha de Creacón: 17-Feb/2020
    /// Descripción     : Clase que representa un muelle 
    /// </summary>
    public class MuelleRespuesta
    {
        /// <summary>
        /// Id del muelle
        /// </summary>
        /// <value>Id del muelle</value>        
        public int MuelleId { get; set; }

        /// <summary>
        /// Valor del muelle
        /// </summary>
        /// <value>Valor del muelle</value>   
        public string Muelle { get; set; }

    }
}
