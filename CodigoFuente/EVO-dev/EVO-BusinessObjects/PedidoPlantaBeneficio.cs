using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    public class PedidoPlantaBeneficio
    {
        public int PedidoId { get; set; }
        public string Usuario { get; set; }
        public int EstadoPedidoId { get; set; }
        public string Estado { get; set; }
        public DateTime?  FechaAprobacionPlanta { get; set; }
        public List<PedidoPlantaBeneficioDetalle> Detalles { get; set; }
    }
}
