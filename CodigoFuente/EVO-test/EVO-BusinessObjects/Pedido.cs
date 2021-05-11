using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 20-Sep/2019
    /// Descripción      : Esta clase representa un Pedido
    /// </summary>
    public class Pedido
    {       
        /// <summary>
        /// Indica el id del pedido
        /// </summary>
        public int PedidoId { get; set; }

        /// <summary>
        /// Indica el código de la bodega del pedido
        /// </summary>
        public string WhsCode { get; set; }

        /// <summary>
        /// Indica para que bodega esta solicitado el pedido
        /// </summary>
        public string SolicitudPara { get; set; }

        /// <summary>
        /// Indica el usuario quien realizo el pedido
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Indica el id del usuario quien realizo el pedido
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Indica la fecha en la cual se realizo el pedido
        /// </summary>
        public DateTime FechaPedido { get; set; }

        /// <summary>
        /// Indica en la fecha en la cual se debe entregar el pedido
        /// </summary>
        public DateTime? FechaEntrega { get; set; }       

        /// <summary>
        /// Indica el número del pedido
        /// </summary>
        public int NumeroPedido { get; set; }

        /// <summary>
        /// Indica el id del estado del pedido
        /// </summary>
        public int EstadoPedidoId { get; set; }

        /// <summary>
        /// Indica el nombre del estado del pedido
        /// </summary>
        public string EstadoPedido { get; set; }

        /// <summary>
        /// Indica el detalle del pedido
        /// </summary>
        public List<DetallePedido> Detalles { get; set; }

        /// <summary>
        /// Indica los detalles del pedido serializados
        /// </summary>
        public string DetallesSerializados { get; set; }

        /// <summary>
        /// Id del tipo de solicitud
        /// </summary>
        /// <value>1</value>       
        public int TipoSolicitudId { get; set; }

        /// <summary>
        /// Indica la serie del número del documento
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Indica el Nombre del usuario
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Indica el Email
        /// </summary>
        public string EmailBodega { get; set; }

        /// <summary>
        /// Indica el Numero de Documento
        /// </summary>
        public string NumeroDocumento { get; set; }
    }
}