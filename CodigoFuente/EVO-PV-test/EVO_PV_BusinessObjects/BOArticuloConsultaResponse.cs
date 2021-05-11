namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 26-jul/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo BOArticuloConsultaResponse
    /// </summary>
    public class BOArticuloConsultaResponse
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>

        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>

        public string NombreArticulo { get; set; }

        /// <summary>
        /// Cantidad solicitada
        /// </summary>
        /// <value>Cantidad solicitada</value>

        public string CantidadSolicitada { get; set; }

        /// <summary>
        /// Cantidad aprobada
        /// </summary>
        /// <value>Cantidad aprobada</value>

        public string CantidadAprobada { get; set; }

        /// <summary>
        /// Cantidades por entrega programada
        /// </summary>
        /// <value>Cantidades por entrega programada</value>

        public string CantidadProgramada { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Estado del artículo</value>

        public string Estado { get; set; }

        /// <summary>
        /// Empaque del artículo
        /// </summary>
        /// <value>Empaque del artículo</value>

        public string Empaque { get; set; }

        /// <summary>
        /// Unidad de medida del artículo
        /// </summary>
        /// <value>Unidad de medida del artículo</value>

        public string UnidadMedida { get; set; }

        /// <summary>
        /// Observaciones del artículo
        /// </summary>
        /// <value>Observaciones del artículo</value>

        public string Observaciones { get; set; }

        /// <summary>
        /// accionID del artículo
        /// </summary>
        /// <value>accionID del artículo</value>        
        public int? AccionId { get; set; }
    }
}
