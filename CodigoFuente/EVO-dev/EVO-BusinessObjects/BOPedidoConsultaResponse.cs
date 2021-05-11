using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 26-jul/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo BOPedidoConsultaResponse
    /// </summary>
    public class BOPedidoConsultaResponse
    {        

        /// <summary>
        /// Código de la bodega que hace el pedido
        /// </summary>
        /// <value>PV-PRA</value>
        public string WhsCode { get; set; }      

        /// <summary>
        /// Tipo de solicitud
        /// </summary>
        /// <value>Tipo de solicitud</value>

        public string TipoSolicitud { get; set; }

        /// <summary>
        /// Número pedido
        /// </summary>
        /// <value>Número pedido</value>
      
        public string NumeroPedido { get; set; }

        /// <summary>
        /// Estado pedido
        /// </summary>
        /// <value>Estado pedido</value>
       
        public string EstadoPedido { get; set; }

        /// <summary>
        /// Fecha Cargue Vehiculo
        /// </summary>
        /// <value>Fecha Cargue Vehiculo</value>
        
        public string FechaCargueVehiculo { get; set; }

        /// <summary>
        /// Nombre del conductor
        /// </summary>
        /// <value>Nombre del conductor</value>
        
        public string NombreConductor { get; set; }

        /// <summary>
        /// Fecha de solicitud
        /// </summary>
        /// <value>Fecha de solicitud</value>
        
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Hora estimada entrega
        /// </summary>
        /// <value>Hora estimada entrega</value>
       
        public string HoraEstimadaEntrega { get; set; }

        /// <summary>
        /// Placa del vehiculo
        /// </summary>
        /// <value>Placa del vehiculo</value>
        
        public string Vehiculo { get; set; }

        /// <summary>
        /// nombre del auxiliar
        /// </summary>
        /// <value>nombre del auxiliar</value>
        
        public string Auxiliar { get; set; }

        /// <summary>
        /// Fecha limite sugerida
        /// </summary>
        /// <value>Fecha limite sugerida</value>
        
        public string FechaLimiteSugerida { get; set; }

        /// <summary>
        /// Planeación de entregas
        /// </summary>
        /// <value>Planeación de entregas</value>
        
        public string PlaneacionEntrega { get; set; }

        /// <summary>
        /// Fecha entrega
        /// </summary>
        /// <value>Fecha entrega</value>
        public DateTime? FechaEntrega { get; set; }
        //public string FechaEntrega { get; set; }

        /// <summary>
        /// Solicitud A
        /// </summary>
        /// <value>Solicitud A</value>

        public string SolicitudA { get; set; }

        /// <summary>
        /// Cancelar el pedido
        /// </summary>
        /// <value>true</value>
        public bool CancelarPedido { get; set; }

        /// <summary>
        /// Lista de registros de Pedidos
        /// </summary>
        /// <value>Lista de registros de Pedidos</value>

        public List<BOArticuloConsultaResponse> Articulos { get; set; }

        /// <summary>
        /// Acciones de compras asociadas a los artículos del pedido
        /// </summary>
        /// <value>Acciones de compras asociadas a los artículos del pedido</value>

        public List<BOAccionCompraResponse> Acciones { get; set; }
    }
}
