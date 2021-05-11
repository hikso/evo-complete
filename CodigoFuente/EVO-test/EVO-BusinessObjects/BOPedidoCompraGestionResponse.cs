using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 27-Ago/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo PedidoCompraGestionResponse
    /// </summary>
    public class BOPedidoCompraGestionResponse
    {
        /// <summary>
        /// Número pedido
        /// </summary>
        /// <value>Número pedido</value>
       
        public string NumeroPedido { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>
       
        public string Cliente { get; set; }

        /// <summary>
        /// Fecha limite sugerida
        /// </summary>
        /// <value>Fecha limite sugerida</value>
      
        public string FechaLimiteSugerida { get; set; }

        /// <summary>
        /// Fecha de solicitud
        /// </summary>
        /// <value>Fecha de solicitud</value>
       
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Fecha de la gestión de compra
        /// </summary>
        /// <value>Fecha de la gestión de compra</value>
       
        public string FechaGestionCompra { get; set; }

        /// <summary>
        /// Nombre del usuario que realizó el pedido
        /// </summary>
        /// <value>Nombre del usuario que realizó el pedido</value>
        
        public string UsuarioPedido { get; set; }

        /// <summary>
        /// Nombre del estado del pedido
        /// </summary>
        /// <value>Abierto</value>      
        public string NombreEstadoPedido { get; set; }

        /// <summary>
        /// Artículos del pedido
        /// </summary>
        /// <value>Artículos del pedido</value>      
        public List<BOArticuloCompraResponse> Articulos { get; set; }

        /// <summary>
        /// Acciones de compras asociadas a los artículos del pedido
        /// </summary>
        /// <value>Acciones de compras asociadas a los artículos del pedido</value>
       
        public List<BOAccionCompraResponse> Acciones { get; set; }
    }
}
