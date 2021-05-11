namespace EVO_PV_BusinessObjects
{
    public class ObtenerPedidosRegistros
    {

        public int PedidoId { get; set; }

        public string CodigoPedido { get; set; }

        public string FechaSolicitud { get; set; }

        public string FechaEntrega { get; set; }

        public string Estado { get; set; }

        public string Planta { get; set; }

        public string DiasEntrega { get; set; }
      
        public bool Duplicar { get; set; }      
        public string CodigoSolicitudA { get; set; }        
        public bool Editar { get; set; }

        /// <summary>
        /// tipo solicitud
        /// </summary>
        /// <value>Tipo Solicitud</value> 
        public string TipoSolicitud { get; set; }

    }
}
