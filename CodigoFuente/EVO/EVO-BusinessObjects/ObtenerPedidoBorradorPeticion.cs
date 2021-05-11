using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Duban Cardona
    /// Fecha de Creación: 14-Oct/2019
    /// Descripción      : Clase que representa un objeto de negocio de ObtenerPedidoBorradorPeticion
    /// </summary>
    public class ObtenerPedidoBorradorPeticion
    {    
        /// <summary>
        /// Indica el código de la bodega
        /// </summary>
        public string WhsCode { get; set; }
        
        /// <summary>
        /// Indica la solicitud para donde se realizara el pedido
        /// </summary>
        public string SolicitudPara { get; set; }

        /// <summary>
        /// Indicara el id del estado del pedido
        /// </summary>
        public int EstadoPedidoId { get; set; }
    }
}
