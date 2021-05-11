/*
 * API de Pedidos
 *
 * API de administración de Pedidos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.PedidosApi
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ObtenerPedidoResponseDetalles : IEquatable<ObtenerPedidoResponseDetalles>
    {
        /// <summary>
        /// Id del estado del artículo
        /// </summary>
        /// <value>Id del estado del artículo</value>
        [DataMember(Name = "DetallePedidoId")]
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>
        [DataMember(Name = "CodigoArticulo")]
        public string CodigoArticulo { get; set; }

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
        public int? EstadoArticulo { get; set; }

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

        /// <summary>
        /// empaqueId
        /// </summary>
        /// <value>1</value>
        [DataMember(Name = "EmpaqueId")]
        public int? EmpaqueId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerPedidoResponseDetalles {\n");
            sb.Append("  CodigoArticulo: ").Append(CodigoArticulo).Append("\n");
            sb.Append("  NombreArticulo: ").Append(NombreArticulo).Append("\n");
            sb.Append("  EstadoArticulo: ").Append(EstadoArticulo).Append("\n");
            sb.Append("  Cantidad: ").Append(Cantidad).Append("\n");
            sb.Append("  UnidadMedida: ").Append(UnidadMedida).Append("\n");
            sb.Append("  PedidoSugerido: ").Append(PedidoSugerido).Append("\n");
            sb.Append("  Stock: ").Append(Stock).Append("\n");
            sb.Append("  StockMinimo: ").Append(StockMinimo).Append("\n");
            sb.Append("  StockMaximo: ").Append(StockMaximo).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ObtenerPedidoResponseDetalles)obj);
        }

        /// <summary>
        /// Returns true if ObtenerPedidoResponseDetalles instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerPedidoResponseDetalles to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerPedidoResponseDetalles other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    CodigoArticulo == other.CodigoArticulo ||
                    CodigoArticulo != null &&
                    CodigoArticulo.Equals(other.CodigoArticulo)
                ) &&
                (
                    NombreArticulo == other.NombreArticulo ||
                    NombreArticulo != null &&
                    NombreArticulo.Equals(other.NombreArticulo)
                ) &&
                (
                    EstadoArticulo == other.EstadoArticulo  &&
                    EstadoArticulo.Equals(other.EstadoArticulo)
                ) &&
                (
                    Cantidad == other.Cantidad  &&
                    Cantidad.Equals(other.Cantidad)
                ) &&
                (
                    UnidadMedida == other.UnidadMedida ||
                    UnidadMedida != null &&
                    UnidadMedida.Equals(other.UnidadMedida)
                ) &&
                (
                    PedidoSugerido == other.PedidoSugerido ||
                    PedidoSugerido != null &&
                    PedidoSugerido.Equals(other.PedidoSugerido)
                ) &&
                (
                    Stock == other.Stock ||
                    Stock != null &&
                    Stock.Equals(other.Stock)
                ) &&
                (
                    StockMinimo == other.StockMinimo ||
                    StockMinimo != null &&
                    StockMinimo.Equals(other.StockMinimo)
                ) &&
                (
                    StockMaximo == other.StockMaximo ||
                    StockMaximo != null &&
                    StockMaximo.Equals(other.StockMaximo)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (CodigoArticulo != null)
                    hashCode = hashCode * 59 + CodigoArticulo.GetHashCode();
                if (NombreArticulo != null)
                    hashCode = hashCode * 59 + NombreArticulo.GetHashCode();
               
                    hashCode = hashCode * 59 + EstadoArticulo.GetHashCode();
            
                    hashCode = hashCode * 59 + Cantidad.GetHashCode();
                if (UnidadMedida != null)
                    hashCode = hashCode * 59 + UnidadMedida.GetHashCode();
                if (PedidoSugerido != null)
                    hashCode = hashCode * 59 + PedidoSugerido.GetHashCode();
                if (Stock != null)
                    hashCode = hashCode * 59 + Stock.GetHashCode();
                if (StockMinimo != null)
                    hashCode = hashCode * 59 + StockMinimo.GetHashCode();
                if (StockMaximo != null)
                    hashCode = hashCode * 59 + StockMaximo.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ObtenerPedidoResponseDetalles left, ObtenerPedidoResponseDetalles right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerPedidoResponseDetalles left, ObtenerPedidoResponseDetalles right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}