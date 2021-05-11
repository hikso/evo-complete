using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 21-Sep/2019
    /// Descripción     : Clase que representa un objeto de negocio de un EstadoPedido
    /// </summary>
    public class EstadoPedido
    {
        /// <summary>
        /// Indica el id del estado del pedido
        /// </summary>
        public int EstadoPedidoId { get; set; }    
        
        /// <summary>
        /// Indica el nombre del estado
        /// </summary>
        public string Nombre { get; set; }    

        /// <summary>
        /// Indica si el estado del pedido se encuentra activo
        /// </summary>
        public bool Activo { get; set; } = true;

    }
}
