using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 4-Sep/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo ActualizarCompraRequest
    /// </summary>
    public class BOActualizarCompraRequest
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>       
        public int PedidoId { get; set; }

        /// <summary>
        /// Estado pedido id
        /// </summary>
        /// <value>Id del estado pedido</value>
        public int EstadoPedidoId { get; set; }

        /// <summary>
        /// Fecha de la gestión de compra
        /// </summary>
        /// <value>Id del estado pedido</value>
        public DateTime FechaGestionCompra { get; set; }

        /// <summary>
        /// Gets or Sets ArticulosActualizarCompra
        /// </summary>

        public List<BOArticuloActualizarCompraRequest> ArticulosActualizarCompra { get; set; }
    }
}
