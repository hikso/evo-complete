using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV_BusinessObjects
{
    public class BOParametroGeneral
    {

        /// <summary>
        /// id del parámetro general
        /// </summary>
        /// <value>id del parámetro general</value>
    
        public int ParametroGeneralId { get; set; }

        /// <summary>
        /// nombre del parámetro general
        /// </summary>
        /// <value>nombre del parámetro general</value>
   
        public string Nombre { get; set; }

        /// <summary>
        /// valor de parámetro general
        /// </summary>
        /// <value>valor de parámetro general</value>
    
        public string Valor { get; set; }

        /// <summary>
        /// Indica si el Parámetro General se encuentra activo / inactivo
        /// </summary>
        /// <value>Indica si el Parámetro General se encuentra activo / inactivo</value>
  
        public bool Activo { get; set; }

    }
}
