using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 7-Dic/2019
    /// Descripción     : Clase que representa un objeto de entrega del pedido
    /// </summary>
    public class EntregaPedido
    {
        /// <summary>
        /// Id del tipo de vehiculo
        /// </summary>
        /// <value>3</value>      
        public int TipoVehiculoId { get; set; }

        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>

        public int PedidoId { get; set; }

        /// <summary>
        /// Número de entrega
        /// </summary>
        /// <value>NumeroEntrega</value>

        public int NumeroEntrega { get; set; }

        /// <summary>
        /// Id del usaurio
        /// </summary>
        /// <value>Id del usuario</value>

        public int UsuarioId { get; set; }

        /// <summary>
        /// Fecha entrega
        /// </summary>
        /// <value>Fecha entrega</value>

        public string FechaEntrega { get; set; }

        /// <summary>
        /// Fecha registro
        /// </summary>
        /// <value>Fecha registro</value>

        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Hora entrega
        /// </summary>
        /// <value>Hora entrega</value>

        public string HoraEntrega { get; set; }

        /// <summary>
        /// FechaHoraEntrega
        /// </summary>
        /// <value>FechaHoraEntrega</value>

        public DateTime FechaHoraEntrega { get; set; }

        /// <summary>
        /// Id del motivo de la edición
        /// </summary>
        /// <value>MotivoEdicionId</value>

        public int? MotivoEdicionId { get; set; }

        /// <summary>
        /// Estado de la entrega
        /// </summary>
        /// <value>EstadoEntregaId</value>

        public int? EstadoEntregaId { get; set; }
        /// <summary>
        /// Lista de detalles de la entrega
        /// </summary>
        /// <value>Lista de detalles de la entrega</value>
       
        public string EstadoEntrega { get; set; }
        /// <summary>
        /// Nombre de estado de la entrega
        /// </summary>
        /// <value>EstadoEntrega</value>

        public List<DetalleEntregaPedido> Detalles { get; set; }
    }
}
