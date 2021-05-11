using System.Collections.Generic;

namespace EVO_PV_BusinessObjects
{
    public class ObtenerArticulos
    {
        public int NumeroTotalRegistros { get; set; }
        public int TamanhoPaginacion { get; set; }
        public List<ObtenerTodosArticulos> Registros { get; set; }

    }
}
