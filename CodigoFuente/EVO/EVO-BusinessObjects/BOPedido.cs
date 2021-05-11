using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 20-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de Pedido
    /// </summary>
    public class BOPedido
    {
        public int PedidoId { get; set; }

        /// <summary>
        /// Define la clave foránea de quien hizo el pedido
        /// </summary>       
        public string WhsCode { get; set; }

        /// <summary>
        /// Define la clave foránea para quien va el pedido
        /// </summary>        
        public string SolicitudPara { get; set; }

        /// <summary>
        /// Define la clave foránea a Usuario
        /// </summary>      
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define la fecha del pedido
        /// </summary>

        public DateTime FechaPedido { get; set; }

        /// <summary>
        /// Define la fecha de entrega del pedido
        /// </summary>       
        public DateTime? FechaEntrega { get; set; }

        /// <summary>
        /// Define la fecha de aprobación del pedido por parte de la planta
        /// </summary>      
        public DateTime? FechaAprobacionPlanta { get; set; }

        /// <summary>
        /// Define el número del pedido
        /// </summary>
        public int? NumeroPedido { get; set; }

        /// <summary>
        /// Define la clave foránea a EstadosPedido
        /// </summary>      
        public int EstadoPedidoId { get; set; }

    }
}
