using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Duban Cardona
    /// Fecha de Creación: 20-Ago/2019
    /// Descripción      : Esta clase contiene las propiedades del FiltroPedidoBeneficio
    /// </summary>
    public class FiltroPedidoBeneficio
    {
        /// <summary>
        /// Indica el número de registro desde el cuál se deben obtener los registros
        /// </summary>
        /// <value>Indica el número de registro desde el cuál se deben obtener los registros</value>       
        public int Desde { get; set; }

        /// <summary>
        /// Indica el número de registro hasta el cuál se deben obtener los registros
        /// </summary>
        /// <value>Indica el número de registro hasta el cuál se deben obtener los registros</value>       
        public int Hasta { get; set; }

        /// <summary>
        /// Código de la solicitud del pedido
        /// </summary>
        /// <value>Código de la solicitud del pedido</value>       
        public string CodigoPedido { get; set; }

        /// <summary>
        /// Fecha de solicitud del pedido
        /// </summary>
        /// <value>Fecha de solicitud del pedido</value>      
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Fecha de solicitud del pedido
        /// </summary>
        /// <value>Fecha de solicitud del pedido</value>      
        public string FechaEntrega { get; set; }

        /// <summary>
        /// Estado de la solicitud pedido
        /// </summary>
        /// <value>Estado de la solicitud pedido</value>      
        public string Estado { get; set; }

        /// <summary>
        /// Nombre del cliente externo o punto de venta
        /// </summary>
        /// <value>Nombre del cliente externo o punto de venta</value>       
        public string Cliente { get; set; }

        /// <summary>
        /// Diás para la entrega del pedido
        /// </summary>
        /// <value>Diás para la entrega del pedido</value>       
        public string DiasEntrega { get; set; }

        /// <summary>
        /// Indica la zona del punto de venta o cliente externo
        /// </summary>
        /// <value>Indica la zona del punto de venta o cliente externo</value>
       
        public string Zona { get; set; }
    }
}
