using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    public class BODetalleEvidenciaResponse
    {
        /// <summary>
        /// Nombre de punto de venta
        /// </summary>
        /// <value>Nombre de punto de venta</value>       
        public string PuntoVenta { get; set; }

        /// <summary>
        /// Número del pedido
        /// </summary>
        /// <value>Número del pedido</value>      
        public string NumeroPedido { get; set; }

        /// <summary>
        /// Usuario que generó la evidencia
        /// </summary>
        /// <value>Usuario que generó la evidencia</value>      
        public string Usuario { get; set; }

        /// <summary>
        /// Fecha de la evidencia
        /// </summary>
        /// <value>Fecha de la evidencia</value>        
        public string FechaEvidencia { get; set; }

        /// <summary>
        /// Email de origen
        /// </summary>
        /// <value>Email de origen</value>       
        public string CorreoOrigen { get; set; }

        /// <summary>
        /// Email de destino
        /// </summary>
        /// <value>Email de destino</value>      
        public string CorreoDestino { get; set; }

        /// <summary>
        /// Observaciones de la evidencia
        /// </summary>
        /// <value>Observaciones de la evidencia</value>       
        public string Observaciones { get; set; }

        /// <summary>
        /// Número de la entrega
        /// </summary>
        /// <value>Número de la entrega</value>       
        public string NumeroEntrega { get; set; }

        /// <summary>
        /// Identificador del directorio donde están ubicados los archivos
        /// </summary>
        /// <value>Identificador del directorio donde están ubicados los archivos</value>    
        public string GUID { get; set; }

        /// <summary>
        /// Gets or Sets Archivos
        /// </summary>      
        public List<BOArchivoResponse> Archivos { get; set; }

        /// <summary>
        /// Gets or Sets DocumentosArticulos
        /// </summary>       
        public List<BODocumentoArticuloResponse> DocumentosArticulos { get; set; }
    }
}
