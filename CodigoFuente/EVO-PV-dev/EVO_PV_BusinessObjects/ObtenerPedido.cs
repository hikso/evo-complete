using System;
using System.Collections.Generic;

namespace EVO_PV_BusinessObjects
{
    public class ObtenerPedido
    {
        public DateTime FechaPedido { get; set; }
        public string CodigoPedido { get; set; }
        public string SolicitudPara { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int EstadoPedidoId { get; set; }
        public List<ObtenerDetallesPedido> Detalles { get; set; }
    }
}
