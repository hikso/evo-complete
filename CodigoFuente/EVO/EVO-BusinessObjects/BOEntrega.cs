using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 19-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio BOEntrega
    /// </summary>
    public class BOEntrega
    {
        /// <summary>
        /// Define la clave primaria de la entrega
        /// </summary>      
        public int EntregaId { get; set; }

        /// <summary>
        /// Define la clave foránea a Usuario
        /// </summary>      
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define la clave foránea a TipoVehiculo
        /// </summary>      
        public int TipoVehiculoId { get; set; }

        /// <summary>
        /// Define la clave foránea a Pedido
        /// </summary>     
        public int PedidoId { get; set; }

        /// <summary>
        /// Define la clave foránea a EstadosEntrega
        /// </summary>
        public int? EstadoEntregaId { get; set; }

        /// <summary>
        /// Define la fecha de registro
        /// </summary>      
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Define la fecha de entrega
        /// </summary>
        public DateTime FechaEntrega { get; set; }

        /// <summary>
        /// Define la fecha de entrega
        /// </summary>     
        public DateTime? FechaActualizo { get; set; }
       
        public BOPedido Pedido { get; set; }   
        
        public List<BODetalleEntrega> Detalles { get; set; }

    }
}
