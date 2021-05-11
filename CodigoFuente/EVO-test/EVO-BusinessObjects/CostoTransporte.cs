using System;

namespace EVO_BusinessObjects
{  
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 20-Oct/2019
    /// Descripción     : Clase que representa un objeto de negocio de un CostoTransporte
    /// </summary>
    public class CostoTransporte
    {     
        /// <summary>
        /// Indica la bodega del pedido
        /// </summary>
        public string bodega { get; set; }

        /// <summary>
        /// Indica el código del artículo
        /// </summary>
        public string codigoArticulo { get; set; }

        /// <summary>
        /// Indica el nombre del artículo
        /// </summary>
        public string nombreArticulo { get; set; }

        /// <summary>
        /// Indica el costo del envio
        /// </summary>
        private string costo { get; set; }

        /// <summary>
        /// Indica la fecha de registro
        /// </summary>
        public DateTime FechaRegistro { get; set; }
    }
}
