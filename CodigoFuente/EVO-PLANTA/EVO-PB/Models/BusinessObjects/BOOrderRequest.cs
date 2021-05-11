using System;
using System.Collections.Generic;

namespace EVO_PB.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 17-Ene/2019
    /// Descripción     : Clase que representa el encabezado de la solicitud del pedido
    /// </summary>
    public class BOOrderRequest
    {
        /// <summary>
        /// Código de la bodega que genera el pedido
        /// </summary>
        /// <value>PV-PRA</value>     
        public int PedidoId { get; set; }

        /// <summary>
        /// Código de la bodega para donde va el pedido
        /// </summary>
        /// <value>PB-PT</value>       
        public string Codigo { get; set; }
    }
}
