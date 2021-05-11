using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 18-Dic/2019
    /// Descripción     : Clase que representa una entrega en estado
    /// </summary>
    public class EntregaBO
    {
        /// <summary>
        /// Código del cliente
        /// </summary>
        /// <value>PV-PRA</value>      
        public string CodigoCliente { get; set; }

        /// <summary>
        /// Id de pedido
        /// </summary>
        /// <value>Id de pedido</value>      
        public int PedidoId { get; set; }

        /// <summary>
        /// Código Pedido
        /// </summary>
        /// <value>CodigoPedido</value>       
        public string CodigoPedido { get; set; }

        /// <summary>
        /// Usuario entrega
        /// </summary>
        /// <value>Usuario</value>       
        public string Usuario { get; set; }

        /// <summary>
        /// Nombres Apellidos
        /// </summary>
        /// <value>NombresApellidos</value>      
        public string NombresApellidos { get; set; }        

        /// <summary>
        /// Cliente
        /// </summary>
        /// <value>Cliente</value>     
        public string Cliente { get; set; }

        /// <summary>
        /// Zona
        /// </summary>
        /// <value>Zona</value>       
        public string Zona { get; set; }

        /// <summary>
        /// Orden de compra
        /// </summary>
        /// <value>OrdenCompra</value>       
        public string OrdenCompra { get; set; }

        /// <summary>
        /// Fecha Entrega
        /// </summary>
        /// <value>FechaEntrega</value>       
        public string FechaEntrega { get; set; }

        /// <summary>
        /// Hora Entrega
        /// </summary>
        /// <value>HoraEntrega</value>       
        public string HoraEntrega { get; set; }

        /// <summary>
        /// Estado Entrega
        /// </summary>
        /// <value>Estado</value>       
        public string Estado { get; set; }

        /// <summary>
        /// Placa
        /// </summary>
        /// <value>Placa</value>       
        public string Placa { get; set; }

        /// <summary>
        /// Id del tipo de vehiculo
        /// </summary>
        /// <value>4</value>       
        public int TipoVehiculoId { get; set; }

        /// <summary>
        /// Nombre del tipo de vehiculo
        /// </summary>
        /// <value>Nombre del tipo de vehiculo</value>        
        public string TipoVehiculo { get; set; }

        /// <summary>
        /// Capacidad del tipo de vehiculo
        /// </summary>
        /// <value>Capacidad del tipo de vehiculo</value>        
        public string CapacidadTipoVehiculo { get; set; }

        public string CantidadTotal { get; set; }       

        /// <summary>
        /// Código de la planta
        /// </summary>
        /// <value>PB-PT</value>        
        public string WhsPlanta { get; set; }

        /// <summary>
        /// Nombre del muelle
        /// </summary>
        /// <value>Muelle 1</value>        
        public string Muelle { get; set; }

        /// <summary>
        /// FechaEntregaDT
        /// </summary>
        /// <value></value>        
        public DateTime FechaEntregaDT { get; set; }

        /// <summary>
        /// Propiedad de navegación a detalles entrega
        /// </summary>
        public List<EntregaDetalleBO> Detalles { get; set; }
    }
}
