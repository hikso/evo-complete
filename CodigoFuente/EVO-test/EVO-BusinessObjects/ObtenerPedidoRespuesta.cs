using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Duban Cardona
    /// Fecha de Creación: 10-Oct/2019
    /// Descripción      : Clase que representa un objeto de negocio de ObtenerPedidoRespuesta
    /// </summary>
    public class ObtenerPedidoRespuesta
    {      
        /// <summary>
        /// Indica la fecha del pedido
        /// </summary>
        public DateTime FechaPedido { get; set; }
      
        /// <summary>
        /// Indica el código del pedido
        /// </summary>
        public string CodigoPedido { get; set; }       

        /// <summary>
        /// Indica la solicitud para donde se realizara el pedido
        /// </summary>
        public string SolicitudPara { get; set; }

        /// <summary>
        /// Indica la solicitud para donde se hizo el pedido
        /// </summary>
        public string SolicitudDe { get; set; }

        /// <summary>
        /// Indica la fecha de entrega del pedido
        /// </summary>
        public DateTime? FechaEntrega { get; set; }

        /// <summary>
        /// Indica el id del estado del pedido
        /// </summary>
        public int EstadoPedidoId { get; set; }

        /// <summary>
        /// Número pedido
        /// </summary>
        public string NumeroPedido { get; set; }

        /// <summary>
        /// TipoSolicitudId
        /// </summary>
        /// <value>1</value>      
        public int TipoSolicitudId { get; set; }

        /// <summary>
        /// Indica la lista que obtiene la lista de los detalles del pedido
        /// </summary>
        public List<ObtenerPedidoRespuestaDetalles> Detalles { get; set; }
    
    
    }
}
