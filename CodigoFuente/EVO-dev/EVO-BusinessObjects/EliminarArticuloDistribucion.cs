using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{

    /// <summary>
    /// Autor           : Andrés Holguín
    /// Fecha de Creacón: 12-Feb/2020
    /// Descripción     : Clase que representa un objeto de Eliminación de articulo en el modulo de distribución
    /// </summary>
    public class EliminarArticuloDistribucion
    {

        /// <summary>
        /// Id del motivo entrega
        /// </summary>
        /// <value>Id del motivo entrega</value>   
        public int MotivoId { get; set; }

        /// <summary>
        /// Id del detalle de la entrega
        /// </summary>
        /// <value>Id del detalle de la entrega</value>

        public int DetalleEntregaId { get; set; }

    }


}

