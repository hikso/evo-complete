
using System.Collections.Generic;

namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Resultado general de consulta
    /// </summary>   
    public partial class ObtenerTodosPedidosDistribucion
    {
        /// <summary>
        /// Número total de registros que posee la consulta
        /// </summary>
        /// <value>Número total de registros que posee la consulta</value>

        public int NumeroTotalRegistros { get; set; }

        /// <summary>
        /// Número de registros a mostrar por página
        /// </summary>
        /// <value>Número de registros a mostrar por página</value>

        public int TamanhoPaginacion { get; set; }

        /// <summary>
        /// Lista de registros de Pedidos
        /// </summary>
        /// <value>Lista de registros de Pedidos</value>

        public List<ObtenerTodosPedidosDistribucionRegistros> Registros { get; set; }


    }
}
