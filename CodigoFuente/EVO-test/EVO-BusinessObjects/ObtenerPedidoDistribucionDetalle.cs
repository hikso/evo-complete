using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    public class ObtenerPedidoDistribucionDetalle
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>      
        public string Codigo { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>     
        public string Nombre { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Estado del artículo</value>       
        public string Estado { get; set; }

        /// <summary>
        /// Cantidad solicitada del articulo
        /// </summary>
        /// <value>Cantidad solicitada del articulo</value>      
        public string CantidadSolicitada { get; set; }

        /// <summary>
        /// Unidad de medida del artículo
        /// </summary>
        /// <value>Unidad de medida del artículo</value>      
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Cantidad aprobada del artículo
        /// </summary>
        /// <value>Cantidad aprobada del artículo</value>      
        public string CantidadAprobada { get; set; }

        /// <summary>
        /// Stock disponible
        /// </summary>
        /// <value>Stock disponible</value>      
        public string StockDisponible { get; set; }
    }
}
