

using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 11-Dec/2019
    /// Descripción     : Clase que representa una entrega de pedido por el id de la entrega
    /// </summary>
    public class EntregaxIdRespuesta
    {
        /// <summary>
        /// Id de pedido
        /// </summary>
        /// <value>Id de pedido</value>       
        public int PedidoId { get; set; }

        /// <summary>
        /// Fecha entrega
        /// </summary>
        /// <value>Fecha entrega</value>      
        public string FechaEntrega { get; set; }

        /// <summary>
        /// Hora entrega
        /// </summary>
        /// <value>Hora entrega</value>      
        public string HoraEntrega { get; set; }

        /// <summary>
        /// Estado entrega
        /// </summary>
        /// <value>Estado entrega</value>     
        public string EstadoEntrega { get; set; }

        /// <summary>
        /// Lista de detalles de la entrega
        /// </summary>
        /// <value>Lista de detalles de la entrega</value>      
        public List<DetalleEntregaPedido> Detalles { get; set; }
    }
}