using System.Collections.Generic;

namespace EVO_PV_BusinessObjects
{
    public class ObtenerPedidos
    {
        public int NumeroTotalRegistros { get; set; }
        public int TamanhoPaginacion { get; set; }
        public List<ObtenerPedidosRegistros> Registros { get; set; }
    }
}
