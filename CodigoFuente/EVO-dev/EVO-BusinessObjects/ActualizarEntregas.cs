using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 7-Dic/2019
    /// Descripción     : Clase que representa un objeto de actualización de entrega del pedido
    /// </summary>
    public class ActualizarEntrega
    {
        /// <summary>
        /// Id de la entrega
        /// </summary>
        /// <value>Id de la entrega</value>

        public int EntregaId { get; set; }

        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>     
        public int PedidoId { get; set; }

        /// <summary>
        /// Fecha Entrega
        /// </summary>
        /// <value>FechaEntrega</value>

        public string FechaEntrega { get; set; }

        /// <summary>
        /// Hora entrega
        /// </summary>
        /// <value>Hora entrega</value>
        public string HoraEntrega { get; set; }

        /// <summary>
        /// identificador o PK del tipo de vehiculo -[TiposVehiculo]
        /// </summary>
        /// <value>id del tipo de vehiculo</value>       
        public int TipoVehiculoId { get; set; }

        /// <summary>
        /// Fecha de actualización de la entrega
        /// </summary>
        /// <value>Fecha de actualización de la entrega</value>
        public DateTime FechaActualizo { get; set; }

        /// <summary>
        /// Id de usuario que actualizó la entrega
        /// </summary>
        /// <value>Id de usuario que actualizó la entrega</value>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Fecha Hora Entrega
        /// </summary>
        /// <value>Fecha Hora Entrega</value>
        public DateTime FechaHoraEntrega { get; set; }    


        /// <summary>
        /// Fecha Registro
        /// </summary>
        /// <value>Fecha Registro</value>
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Estado Entrega Id
        /// </summary>
        /// <value>EstadoEntregaId</value>       
        public int? EstadoEntregaId { get; set; }

        /// <summary>
        /// Motivo Edicion Id
        /// </summary>
        /// <value>MotivoEdicionId</value>      
        public int? MotivoEdicionId { get; set; }

        /// <summary>
        /// Lista de detalles de la entrega
        /// </summary>
        /// <value>Lista de detalles de la entrega</value>
        public List<ActualizarEntregaDetalle> Detalles { get; set; }
      
    }
}
