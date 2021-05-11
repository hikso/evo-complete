using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 10-Oct/2019
    /// Descripción     : Clase que representa un objeto de negocio de una ConfiguracionNotificacion
    /// </summary>
    public class ConfiguracionNotificacion
    {
        /// <summary>
        /// Indica el nombre del usuario quien lo envio
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Indica el correo de donde se envio
        /// </summary>
        public string EmailDe { get; set; }

        /// <summary>
        /// Indica el correo hacia donde va dirigido
        /// </summary>
        public string EmailPara { get; set; }

        /// <summary>
        /// Indica el estado del pedido anterior
        /// </summary>
        public string EstadoPedidoAnterior { get; set; }

        /// <summary>
        /// Indica el estado del pedido nuevo
        /// </summary>
        public string EstadoPedidoNuevo { get; set; }

        /// <summary>
        /// Indica el punto de Venta
        /// </summary>
        public string PuntoDeVenta { get; set; }

        /// <summary>
        /// Indica el número del pedido
        /// </summary>
        public string NumeroPedido { get; set; }
    }
}
