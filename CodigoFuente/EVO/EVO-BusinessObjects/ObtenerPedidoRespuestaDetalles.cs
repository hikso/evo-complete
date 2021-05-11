using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Duban Cardona
    /// Fecha de Creación: 10-Oct/2019
    /// Descripción      : Clase que representa un objeto de negocio de ObtenerPedidoRespuestaDetalles
    /// </summary>
    public class ObtenerPedidoRespuestaDetalles
    {

        /// <summary>
        /// Indica el id del detalle del pedido
        /// </summary>
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Indica el código del artículo
        /// </summary>
        public string CodigoArticulo { get; set; }      

        /// <summary>
        /// Indica el nombre del artículo del pedido
        /// </summary>
        public string NombreArticulo { get; set; }      

        /// <summary>
        /// Indica el estado del artículo
        /// </summary>
        public int EstadoArticulo { get; set; }      

        /// <summary>
        /// Indica la cantidad del pedido
        /// </summary>
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Indica la cantidad aprobada del pedido
        /// </summary>
        public decimal? CantidadAprobada { get; set; }

        /// <summary>
        /// Indica la unidad de medida del artículo
        /// </summary>
        public string UnidadMedida { get; set; }   
        
        /// <summary>
        /// Indica el pedido sugerido 
        /// </summary>
        public string PedidoSugerido { get; set; }   

        /// <summary>
        /// Indica el stock del artículo del pedido
        /// </summary>
        public string Stock { get; set; }      

        /// <summary>
        /// Indica el stock minimo del pedido
        /// </summary>
        public string StockMinimo { get; set; }      

        /// <summary>
        /// Indica el stock maximo del pedido
        /// </summary>
        public string StockMaximo { get; set; }

        /// <summary>
        /// Observación
        /// </summary>      
        public string Observacion { get; set; }
    }
}
