namespace EVO_BusinessObjects
{

    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 25-Sep/2019
    /// Descripción     : Clase que representa un objeto de negocio de  BuscarArticuloBodegaSolicitud
    /// </summary>
    public class BuscarArticuloBodegaSolicitud
    {
        /// <summary>
        /// Indica el nombre del artículo
        /// </summary>
        public string Nombre { get; set; }       

        /// <summary>
        /// Indica el código del artículo
        /// </summary>
        public string Codigo { get; set; }      

        /// <summary>
        /// Indica el código de la bodega
        /// </summary>
        public string CodigoBodega { get; set; }

        /// <summary>
        /// Prefijo de los artículos , la planta tiene por ejemplo PB-PT y los artículos tienen PT-2456
        /// </summary>
        /// <value>PT-</value>       
        public string PrefijoCodigoArticulo { get; set; }
    }
}
