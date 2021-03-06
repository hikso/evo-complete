namespace EVO_PV_BusinessObjects
{
    public class BuscarArticuloSolicitud
    {
        public string Nombre { get; set; }

        public string Codigo { get; set; }

        public string CodigoBodega { get; set; }

        /// <summary>
        /// Prefijo de los artículos , la planta tiene por ejemplo PB-PT y los artículos tienen PT-2456
        /// </summary>
        /// <value>PT-</value>        
        public string PrefijoCodigoArticulo { get; set; }

        /// <summary>
        /// Tipo de Solicitud para definir si es compra o traslado
        /// </summary>
        /// <value>Tipo de Solicitud</value>       
        public int TipoSolicitud { get; set; }
    }
}
