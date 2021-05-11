using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    public class ObtenerPedidoDistribucion
    {
        /// <summary>
        /// Fecha solicitud del pedido
        /// </summary>
        /// <value>Fecha solicitud del pedido</value>      
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>      
        public string Cliente { get; set; }

        /// <summary>
        /// Código del pedido
        /// </summary>
        /// <value>Código del pedido</value>       
        public string Codigo { get; set; }

        /// <summary>
        /// Nombre del estado del pedido
        /// </summary>
        /// <value>Nombre del estado del pedido</value>       
        public string Estado { get; set; }

        /// <summary>
        /// Indica la zona del punto de venta o cliente externo
        /// </summary>
        /// <value>Indica la zona del punto de venta o cliente externo</value>       
        public string Zona { get; set; }

        /// <summary>
        /// Indica los detalles del pedido
        /// </summary>
        /// <value>Indica los detalles del pedido</value>  
        public List<ObtenerPedidoDistribucionDetalle> Detalles { get; set; }
        
    }
}
