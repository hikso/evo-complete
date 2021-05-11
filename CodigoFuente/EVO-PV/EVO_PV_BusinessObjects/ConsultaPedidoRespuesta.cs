using System.Collections.Generic;

namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 10-Oct/2019
    /// Descripción     : Clase que representa un objeto de negocio de una ConsultaPedidoRespuesta
    /// </summary>
    public class ConsultaPedidoRespuesta
    {
        /// <summary>
        /// Indica el número del pedido
        /// </summary>
        public string NumeroPedido { get; set; }

        /// <summary>
        /// Indica el estado del pedido
        /// </summary>
        public string EstadoPedido { get; set; }

        /// <summary>
        /// Indica la fecha la solicitud del pedido
        /// </summary>
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Indica la fecha de envio del pedido
        /// </summary>
        public string FechaEnvio { get; set; }

        /// <summary>
        /// Indica la fecha en la que fué recibido
        /// </summary>
        public string FechaRecibido { get; set; }

        /// <summary>
        /// Indica la fecha de cargue en vehiculo del pedido
        /// </summary>
        public string FechaCargueEnVehiculo { get; set; }

        /// <summary>
        /// Indica el nombre del conductor
        /// </summary>
        public string NombreConductor { get; set; }

        /// <summary>
        /// Indica la placa del vehiculo
        /// </summary>
        public string PlacaVehiculo { get; set; }

        /// <summary>
        /// Indica el nombre del auxiliar
        /// </summary>
        public string NombreAuxiliar { get; set; }

        /// <summary>
        /// Indica la planta de donde se hace el envio
        /// </summary>
        public string Planta { get; set; }

        /// <summary>
        /// Indica la lista de los detalles del pedido
        /// </summary>
        public List<ConsultaDetallePedidoRespuesta> Detalles { get; set; }
    }
}
