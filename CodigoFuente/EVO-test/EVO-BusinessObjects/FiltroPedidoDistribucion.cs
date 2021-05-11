using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 18-Nov/2019
    /// Descripción      : Esta clase contiene las propiedades del FiltroPedidoDespacho
    /// </summary>
    public class FiltroPedidoDistribucion
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
        /// Código del pedido
        /// </summary>
        /// <value>Código del pedido</value>       
        public string CodigoPedido { get; set; }

        /// <summary>
        /// Orden de compra (para clientes externos)
        /// </summary>
        /// <value>Orden de compra (para clientes externos)</value>      
        public string OrdenCompra { get; set; }

        /// <summary>
        /// Fecha en la que se registra el pedido
        /// </summary>
        /// <value>Fecha en la que se registra el pedido</value>       
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Estado el pedido
        /// </summary>
        /// <value>Estado el pedido</value>      
        public string Estado { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>      
        public string Cliente { get; set; }

        /// <summary>
        /// Cantidad máxima de entregas
        /// </summary>
        /// <value>Cantidad máxima de entregas</value>      
        public string Entregas { get; set; }

        /// <summary>
        /// Indica la zona del punto de venta o cliente externo
        /// </summary>
        /// <value>Indica la zona del punto de venta o cliente externo</value>       
        public string Zona { get; set; }

        /// <summary>
        /// Indica el peso de los artículos que tiene el vehiculo cargado 
        /// </summary>
        /// <value>Peso</value> 
        public string Peso { get; set; }

        /// <summary>
        /// Indica la hora de entrega
        /// </summary>
        /// <value>HoraEntrega</value> 
        public string HoraEntrega { get; set; }

        /// <summary>
        /// Indica la fecha de entrega
        /// </summary>
        /// <value>FechaEntrega</value> 
        public string FechaEntrega { get; set; }

        /// <summary>
        /// Indica el número de la entrega 
        /// </summary>
        /// <value>NumeroEntrega</value> 
        public string NumeroEntrega { get; set; }
    }
}
