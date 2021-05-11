using System.Collections.Generic;

namespace EVO_PB.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 30-Dic/2019
    /// Descripción     : Clase que representa un objeto de negocio de tipo paginación de artículos
    /// </summary>
    public class BOPaginationArticle
    {
        /// <summary>
        /// Número total de registros que posee la consulta
        /// </summary>
        /// <value>Número total de registros que posee la consulta</value>     
        public int TotalNumberRecords { get; set; }

        /// <summary>
        /// Número de registros a mostrar por página
        /// </summary>
        /// <value>Número de registros a mostrar por página</value>
        public int PaginationSize { get; set; }

        /// <summary>
        /// Lista de registros de Artículos
        /// </summary>
        /// <value>Lista de objetos de negocio tipo artículos</value>       
        public List<BOArticle> Articles { get; set; }
    }
}
