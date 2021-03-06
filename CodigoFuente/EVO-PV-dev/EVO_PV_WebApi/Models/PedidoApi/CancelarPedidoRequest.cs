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
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV_WebApi.Models.PedidoApi
{
    /// <summary>
    /// Cancelar pedido
    /// </summary>
    [DataContract]
    public partial class CancelarPedidoRequest : IEquatable<CancelarPedidoRequest>
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>
        [Required]
        [DataMember(Name = "pedidoId")]
        public int PedidoId { get; set; }

        /// <summary>
        /// Id del Motivo
        /// </summary>
        /// <value>Id del Motivo</value>
        [Required]
        [DataMember(Name = "motivoId")]
        public int MotivoId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CancelarPedidoRequest {\n");
            sb.Append("  PedidoId: ").Append(PedidoId).Append("\n");
            sb.Append("  MotivoId: ").Append(MotivoId).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CancelarPedidoRequest)obj);
        }

        /// <summary>
        /// Returns true if CancelarPedidoRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of CancelarPedidoRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CancelarPedidoRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    PedidoId == other.PedidoId ||
                    PedidoId != null &&
                    PedidoId.Equals(other.PedidoId)
                ) &&
                (
                    MotivoId == other.MotivoId ||
                    MotivoId != null &&
                    MotivoId.Equals(other.MotivoId)
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
                if (PedidoId != null)
                    hashCode = hashCode * 59 + PedidoId.GetHashCode();
                if (MotivoId != null)
                    hashCode = hashCode * 59 + MotivoId.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(CancelarPedidoRequest left, CancelarPedidoRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CancelarPedidoRequest left, CancelarPedidoRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
