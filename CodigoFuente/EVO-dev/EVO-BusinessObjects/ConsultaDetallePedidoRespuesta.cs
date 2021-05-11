using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 10-Oct/2019
    /// Descripción     : Clase que representa un objeto de negocio de una ConsultaDetallePedidoRespuesta
    /// </summary>
    public class ConsultaDetallePedidoRespuesta
    {        
        /// <summary>
        /// Indica el código del artículo
        /// </summary>
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Indica el nombre del artículo
        /// </summary>
        public string NombreArticulo { get; set; }     

        /// <summary>
        /// Indica el estado del artículo
        /// </summary>
        public string EstadoArticulo { get; set; }     

        /// <summary>
        /// Indica la cantidad solicitada
        /// </summary>
        public string CantidadSolicitada { get; set; }      

        /// <summary>
        /// Indica la unidad de medida del artículo
        /// </summary>
        public string UnidadMedida { get; set; }   
        
        /// <summary>
        /// Indica la cantidad aprobada para el pedido
        /// </summary>
        public string CantidadAprobada { get; set; }      
        
        /// <summary>
        /// Indica la fecha entrega del pedido
        /// </summary>
        public string FechaEntrega { get; set; }

        /// <summary>
        /// Indica el costo translado del pedido
        /// </summary>
        public string CostoTraslado { get; set; }

        /// <summary>
        /// Indica el costo transporte del pedido
        /// </summary>
        public string CostoTransporte { get; set; }

        /// <summary>
        /// Observación
        /// </summary>
        /// <value></value>     
        public string Observacion { get; set; }
    }
}
