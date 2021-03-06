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
    /// Articulo tipo traslado a actualizar en comercial
    /// </summary>
    [DataContract]
    public partial class ArticuloTrasladoRequest : IEquatable<ArticuloTrasladoRequest>
    {
        /// <summary>
        /// Id del detalle del pedido
        /// </summary>
        /// <value>Id del detalle del pedido</value>
        [DataMember(Name = "detallePedidoId")]
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Id del estado del artículo
        /// </summary>
        /// <value>Id del estado del artículo</value>
        [DataMember(Name = "estadoArticuloId")]
        public int EstadoArticuloId { get; set; }

        /// <summary>
        /// Id del tipo de empaque
        /// </summary>
        /// <value>Id del tipo de empaque</value>
        [DataMember(Name = "empaqueId")]
        public int EmpaqueId { get; set; }

        /// <summary>
        /// Cantidad del artículo aprobada
        /// </summary>
        /// <value>Cantidad del artículo aprobada</value>
        [DataMember(Name = "cantidadAprobada")]
        public string CantidadAprobada { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ArticuloTrasladoRequest {\n");
            sb.Append("  DetallePedidoId: ").Append(DetallePedidoId).Append("\n");
            sb.Append("  EstadoArticuloId: ").Append(EstadoArticuloId).Append("\n");
            sb.Append("  EmpaqueId: ").Append(EmpaqueId).Append("\n");
            sb.Append("  CantidadAprobada: ").Append(CantidadAprobada).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ArticuloTrasladoRequest)obj);
        }

        /// <summary>
        /// Returns true if ArticuloTrasladoRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of ArticuloTrasladoRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ArticuloTrasladoRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    DetallePedidoId == other.DetallePedidoId ||
                    DetallePedidoId != null &&
                    DetallePedidoId.Equals(other.DetallePedidoId)
                ) &&
                (
                    EstadoArticuloId == other.EstadoArticuloId ||
                    EstadoArticuloId != null &&
                    EstadoArticuloId.Equals(other.EstadoArticuloId)
                ) &&
                (
                    EmpaqueId == other.EmpaqueId ||
                    EmpaqueId != null &&
                    EmpaqueId.Equals(other.EmpaqueId)
                ) &&
                (
                    CantidadAprobada == other.CantidadAprobada ||
                    CantidadAprobada != null &&
                    CantidadAprobada.Equals(other.CantidadAprobada)
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
                if (DetallePedidoId != null)
                    hashCode = hashCode * 59 + DetallePedidoId.GetHashCode();
                if (EstadoArticuloId != null)
                    hashCode = hashCode * 59 + EstadoArticuloId.GetHashCode();
                if (EmpaqueId != null)
                    hashCode = hashCode * 59 + EmpaqueId.GetHashCode();
                if (CantidadAprobada != null)
                    hashCode = hashCode * 59 + CantidadAprobada.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ArticuloTrasladoRequest left, ArticuloTrasladoRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArticuloTrasladoRequest left, ArticuloTrasladoRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
