using System;
using System.Collections.Generic;


namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 20-Sep/2019
    /// Descripción      : Esta clase representa un Pedido
    /// </summary>
    public class Pedido
    {
        public string WhsCode { get; set; }
        public string SolicitudPara { get; set; }
        public string Usuario { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string NumeroPedido { get; set; }
        public int EstadoPedidoId { get; set; }
        public int PedidoId { get; set; }
        public string EstadoPedido { get; set; }
        public int TipoSolicitudId { get; set; }
        public List<DetallePedido> Detalles { get; set; }
    }
}