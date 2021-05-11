using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 28-Ago/2020
    /// Descripción     : Clase que representa un objeto de CompraRequest
    /// </summary>
    public class BOCompraRequest
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>      
        public int PedidoId { get; set; }

        /// <summary>
        /// Id de la acción
        /// </summary>
        /// <value>Id de la acción</value>        
        public int AccionId { get; set; }

        /// <summary>
        /// Gets or Sets ArticulosCompra
        /// </summary>    
        public List<BOArticuloCompraRequest> ArticulosCompra { get; set; }

    }
}
