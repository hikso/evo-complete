
using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 5-Nov/2019
    /// Descripción      : Esta clase representa un pedido visto desde planta beneficio
    /// </summary>
    public class PedidoEnPlantaRespuesta
    {
        /// <summary>
        /// Fecha solicitud del pedido
        /// </summary>
        /// <value>Fecha solicitud del pedido</value>      
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Fecha entraega del pedido desde la planta
        /// </summary>
        /// <value>Fecha entraega del pedido desde la planta</value>  
        public string FechaEntrega { get; set; }

        /// <summary>
        /// Fecha aporbación del pedido
        /// </summary>
        /// <value>Fecha aporbación del pedido</value>        
        public string FechaAprobacion { get; set; }
      
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>      
        public string Cliente { get; set; }

        /// <summary>
        /// Nombre del usuario que registró la solicitud
        /// </summary>
        /// <value>Nombre del usuario que registró la solicitud</value>     
        public string Usuario { get; set; }

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
       /// Indica la solicitud de donde se realizo el pedido
       /// </summary>
        public string SolicitudDe { get; set; }

        /// <summary>
        /// Indica la solicitud para donde se realizo el pedido
        /// </summary>
        public string SolicitudPara { get; set; }
        
        /// <summary>
        /// Indica la fecha entrega de aprobación de la planta
        /// </summary>
        public string FechaAprobacionPlanta { get; set; }

        /// <summary>
        /// Indica la zona del punto de venta o cliete externo
        /// </summary>
        public string Zona { get; set; }

        /// <summary>
        /// Indica la lista de los detalles del pedido
        /// </summary>
        public List<PedidoDetalleEnPlantaRespuesta> PedidoDetallesRespuesta { get; set; }
    }
}
