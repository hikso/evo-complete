namespace EVO_BusinessObjects
{
    public class EntregaDetalleBO
    {

        /// <summary>
        /// Detalle Entrega Id
        /// </summary>
        /// <value>1</value>       
        public int DetalleEntregaId { get; set; }

        /// <summary>
        /// Id Estado ArtÍculo
        /// </summary>
        /// <value>2</value>       
        public int? IdEstadoArticulo { get; set; }

        /// <summary>
        /// Codigo
        /// </summary>
        /// <value>PT-1405</value>       
        public string Codigo { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        /// <value>Pierna</value>       
        public string Nombre { get; set; }

        /// <summary>
        /// Cantidad Aprobada
        /// </summary>
        /// <value>123</value>       
        public string CantidadAprobada { get; set; }

        /// <summary>
        /// Cantidad Entrega
        /// </summary>
        /// <value>123</value>       
        public string CantidadEntrega { get; set; }

        /// <summary>
        /// Cantidad Pendiente
        /// </summary>
        /// <value>345</value>       

        public string CantidadPendiente { get; set; }

        /// <summary>
        /// Cantidad Pendiente Pesaje
        /// </summary>
        /// <value>345</value>       

        public double CantidadPendientePesaje { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Refigerado</value>            

        public string EstadoArticulo { get; set; }

        /// <summary>
        /// Unidad Medida
        /// </summary>
        /// <value>Kg</value>            

        public string UnidadMedida { get; set; }

        /// <summary>
        /// Pesaje finalizado
        /// </summary>
        /// <value>True</value>          
        public bool PesajeFinalizado { get; set; }

        /// <summary>
        /// Observación
        /// </summary>      
        public string Observacion { get; set; }


    }
}
