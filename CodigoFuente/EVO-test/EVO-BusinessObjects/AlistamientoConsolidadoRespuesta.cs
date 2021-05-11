namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 13-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de Alistamiento Consolidado 
    /// </summary>
    public class AlistamientoConsolidadoRespuesta
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>     
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Nombre del articulo
        /// </summary>
        /// <value>Nombre del articulo</value>       
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Cantidad de entrega
        /// </summary>
        /// <value>Cantidad de entrega</value>       
        public decimal CantidadEntrega { get; set; }

        /// <summary>
        /// Cantidad bases
        /// </summary>
        /// <value>Cantidad bases</value>      
        public int CantidadBases { get; set; }

        /// <summary>
        /// Cantidad canastas
        /// </summary>
        /// <value>Cantidad canastas</value>      
        public int CantidadCanastas { get; set; }

        /// <summary>
        /// Cantidad cartónes
        /// </summary>
        /// <value>Cantidad cartónes</value>       
        public int CantidadCartones { get; set; }

        /// <summary>
        /// Cantidad beams
        /// </summary>
        /// <value>Cantidad beams</value>      
        public int CantidadBeams { get; set; }

        /// <summary>
        /// Cantidad pesos contenedores
        /// </summary>
        /// <value>Cantidad pesos contenedores</value>       
        public decimal CantidadPesosContenedores { get; set; }

        /// <summary>
        /// Cantidad pesos contenedores con articulo
        /// </summary>
        /// <value>Cantidad pesos contenedores con articulo</value>       
        public decimal CantidadPesosContenedoresArticulo { get; set; }

        /// <summary>
        /// Cantidad pesos artículo
        /// </summary>
        /// <value>Cantidad pesos artículo</value>      
        public decimal CantidadPesosArticulo { get; set; }

        /// <summary>
        /// Unidad de medida del artículo
        /// </summary>
        /// <value>Unidad de medida del artículo</value>       
        public string UnidadMedida { get; set; }
    }
}
