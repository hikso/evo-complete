using System.Collections.Generic;

namespace EVO_PB.Models.BusinessObjects
{
    public class BOOrderList
    {

        /// <summary>
        /// Número total de registros que posee la consulta
        /// </summary>
        /// <value>Número total de registros que posee la consulta</value>
        public int? TotalNumberRecords { get; set; }

        /// <summary>
        /// Número de registros a mostrar por página
        /// </summary>
        /// <value>Número de registros a mostrar por página</value>
        public int? PaginationSize { get; set; }

        /// <summary>
        /// Lista de registros de Pedidos
        /// </summary>
        /// <value>Lista de registros de Pedidos</value>
        public List<BORegisterorderlist> Registers { get; set; }

    }
}
