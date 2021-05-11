/*
 * API de Pedidos
 *
 * API de administración de Pedidos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System.Runtime.Serialization;

namespace EVO_PV_WebApi.Models.PedidosApi
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ObtenerPedidoResponseDetalles
    {
        /// <summary>
        /// Detalle Pedido Id
        /// </summary>
        /// <value>Detalle Pedido Id</value>
        [DataMember(Name = "DetallePedidoId")]
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>
        [DataMember(Name = "CodigoArticulo")]
        public string ItemCode { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>
        [DataMember(Name = "NombreArticulo")]
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Id del estado del artículo
        /// </summary>
        /// <value>Id del estado del artículo</value>
        [DataMember(Name = "EstadoArticulo")]
        public int EstadoArticulo { get; set; }

        /// <summary>
        /// Cantidad del artículo solicitada
        /// </summary>
        /// <value>Cantidad del artículo solicitada</value>
        [DataMember(Name = "Cantidad")]
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Unidad de medida del artículo
        /// </summary>
        /// <value>Unidad de medida del artículo</value>
        [DataMember(Name = "UnidadMedida")]
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Pedido sugerido
        /// </summary>
        /// <value>Pedido sugerido</value>
        [DataMember(Name = "PedidoSugerido")]
        public string PedidoSugerido { get; set; }

        /// <summary>
        /// Stock
        /// </summary>
        /// <value>Stock</value>
        [DataMember(Name = "Stock")]
        public string Stock { get; set; }

        /// <summary>
        /// Stock minímo
        /// </summary>
        /// <value>Stock minímo</value>
        [DataMember(Name = "StockMinimo")]
        public string StockMinimo { get; set; }

        /// <summary>
        /// Stock máximo
        /// </summary>
        /// <value>Stock máximo</value>
        [DataMember(Name = "StockMaximo")]
        public string StockMaximo { get; set; }

        /// <summary>
        /// Observación
        /// </summary>
        /// <value></value>      
        [DataMember(Name = "Observacion")]
        public string Observacion { get; set; }

    }
}
