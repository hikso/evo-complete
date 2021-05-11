using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOPedidoRespuesta
    {
        /// <summary>
        /// Define el estado de la respuesta
        /// </summary>       
        public bool Estado { get; set; }

        /// <summary>
        /// Define el código del pedido
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Define un mensaje de respuesta SAP
        /// </summary>
        public string RespuestaSAP { get; set; }
    }
}
