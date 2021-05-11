using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    public class RecepcionEncabezadoRespuesta
    {
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>      
        public string NombreCliente { get; set; }

        /// <summary>
        /// Consecutivo del pesaje por entrega
        /// </summary>
        /// <value>Consecutivo del pesaje por entrega</value>      
        public int Consecutivo { get; set; }

        /// <summary>
        /// Fecha entrega
        /// </summary>
        /// <value>Fecha entrega</value>       
        public string FechaEntrega { get; set; }

        /// <summary>
        /// Fecha actual
        /// </summary>
        /// <value>Fecha actual</value>      
        public string FechaActual { get; set; }       

        /// <summary>
        /// Define si ya finalizó el proceso
        /// </summary>       
        public bool? Finalizado { get; set; }

        /// <summary>
        /// Id del pesaje de la entrega
        /// </summary>
        /// <value></value>      
        public int? PesajeEntregaId { get; set; }

        /// <summary>
        /// Indica si existe alguna inconsistencia entre pesaje de código de barras y báscula
        /// </summary>
        /// <value>Indica si existe alguna inconsistencia entre pesaje de código de barras y báscula</value>      
        public bool? InconsistenciaCodigoBarras { get; set; }

        /// <summary>
        /// Gets or Sets Documentos
        /// </summary>      
        public List<BOArticuloDocumentoResponse> Documentos { get; set; }
        public bool? RealizarPesajeCodigoBarras { get; set; }
    }
}
