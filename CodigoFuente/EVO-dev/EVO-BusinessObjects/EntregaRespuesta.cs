using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 7-Dic/2019
    /// Descripción     : Clase que representa un objeto de respuesta de entrega del pedido
    /// </summary>
    public class EntregaRespuesta
    {
        /// <summary>
        /// Id de la entrega
        /// </summary>
        /// <value>Id de la entrega</value>       
        public int EntregaId { get; set; }

        /// <summary>
        /// Número de la entrega
        /// </summary>
        /// <value>Número de la entrega</value>        
        public string NumeroEntrega { get; set; }

        /// <summary>
        /// Código del pedido
        /// </summary>
        /// <value>Código del pedido</value>

        public string NumeroPedido { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>

        public string Cliente { get; set; }

        /// <summary>
        /// Zona del cliente
        /// </summary>
        /// <value>Zona del cliente</value>

        public string Zona { get; set; }

        /// <summary>
        /// Número de entregas
        /// </summary>
        /// <value>Número de entregas</value>

        public string NumeroEntregas { get; set; }

        /// <summary>
        /// Estado del pedido
        /// </summary>
        /// <value>Estado del pedido</value>

        public string Estado { get; set; }

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
        /// Fecha y hora de la entrega
        /// </summary>
        /// <value>Fecha y hora de la entrega</value>       
        public string FechaHoraEntrega { get; set; }

        /// <summary>
        /// Finalizado recepción
        /// </summary>
        /// <value>Finalizado recepción</value>     
        public bool FinalizadoRecepcion { get; set; }

        /// <summary>
        /// Detalle del pedido
        /// </summary>
        /// <value>Detalle del pedido</value>
        public List<EntregaArticulo> Articulos { get; set; }

        /// <summary>
        /// Lista de entregas
        /// </summary>
        /// <value>Lista de entregas</value>
        public List<Entrega> Entregas { get; set; }
    }
}
