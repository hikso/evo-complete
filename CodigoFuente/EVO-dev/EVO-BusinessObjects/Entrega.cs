using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 8-Dic/2019
    /// Descripción     : Clase que representa un objeto de respuesta de un encabezado de entrega de un pedido
    /// </summary>
    public class Entrega
    {
        /// <summary>
        /// Cantidad total
        /// </summary>
        /// <value>234.45</value>
        public decimal CantidadTotal { get; set; }

        /// <summary>
        /// Id de entrega
        /// </summary>
        /// <value>Id de entrega</value>
        public int EntregaId { get; set; }

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
        /// Nombre del tipo de vehiculo
        /// </summary>
        /// <value>Nombre del tipo de vehiculo</value>       
        public string NombreTipoVehiculo { get; set; }

        /// <summary>
        /// Capacidad del tipo de vehiculo
        /// </summary>
        /// <value>Capacidad del tipo de vehiculo</value>       
        public string CapacidadTipoVehiculo { get; set; }

        /// <summary>
        /// Cantidad total de la entrega en kg
        /// </summary>
        /// <value>456</value>      
        public decimal CantidadEntrega { get; set; }

        /// <summary>
        /// Finalizado recepción
        /// </summary>
        /// <value>Finalizado recepción</value>     
        public bool FinalizadoRecepcion { get; set; }

        /// <summary>
        /// Fecha y hora de la  entrega
        /// </summary>
        /// <value>Fecha y hora de la  entrega</value>
        public DateTime FechaHoraEntrega { get; set; }

        /// <summary>
        /// Lista de detalles de la entrega
        /// </summary>
        /// <value>Lista de detalles de la entrega</value>
        public List<EntregaDetalle> Detalles { get; set; }
    }
}
