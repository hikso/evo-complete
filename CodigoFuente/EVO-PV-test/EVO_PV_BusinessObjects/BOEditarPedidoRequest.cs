
using System.Collections.Generic;

namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 28-jul/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo EditarPedidoRequest
    /// </summary>

    public class BOEditarPedidoRequest
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>      
        public int PedidoId { get; set; }

        /// <summary>
        /// Artículos del pedido
        /// </summary>
        /// <value>Artículos del pedido</value>

        public List<BOEditarPedidoRequestArticulos> Articulos { get; set; }


    }
}
