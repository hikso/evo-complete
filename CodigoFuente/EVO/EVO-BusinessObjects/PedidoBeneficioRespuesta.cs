using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 19-Nov/2019
    /// Descripción      : Clase que representa un objeto de negocio de PedidoBeneficioRespuesta
    /// </summary>
    ///
    public class PedidoBeneficioRespuesta
    {
        /// <summary>
        /// Indica el id del pedido
        /// </summary>
        public int PedidoId { get; set; }

        /// <summary>
        /// Indica el código del pedido
        /// </summary>
        public string CodigoPedido { get; set; }

        /// <summary>
        /// Indica la fecha en la cual se realizo el pedido
        /// </summary>
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Indica el fecha en la cual se debe entregar el pedido
        /// </summary>
        public string FechaEntrega { get; set; }

        /// <summary>
        /// Indica el estado del pedido
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Indica el nombre del cliente
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Indica los días para entregar el pedido al punto de venta o cliente externo.
        /// </summary>
        public string DiasEntrega { get; set; }

        /// <summary>
        /// Indica la zona del cliente externo o punto de venta
        /// </summary>
        public string Zona { get; set; }

        /// <summary>
        /// Indica Fecha de entrega en formato fecha
        /// </summary>
        public DateTime FE { get; set; }

    }    
      
}
