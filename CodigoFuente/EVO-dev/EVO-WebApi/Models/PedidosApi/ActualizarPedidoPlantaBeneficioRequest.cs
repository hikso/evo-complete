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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.PedidosApi
{
    /// <summary>
    /// Objeto que contiene el pedido
    /// </summary>
    [DataContract]
    public partial class ActualizarPedidoPlantaBeneficioRequest : IEquatable<ActualizarPedidoPlantaBeneficioRequest>
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>
        [DataMember(Name = "PedidoId")]
        public int PedidoId { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        /// <value>Estado del botón</value>
        [DataMember(Name = "Estado")]
        public string Estado { get; set; }

        /// <summary>
        /// Lista de detalles del Pedido
        /// </summary>
        /// <value>Lista de detalles del Pedido</value>
        [DataMember(Name = "Detalles")]
        public List<ActualizarPedidoPlantaBeneficioRequestDetalles> Detalles { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ActualizarPedidoPlantaBeneficioRequest {\n");
            sb.Append("  PedidoId: ").Append(PedidoId).Append("\n");
            sb.Append("  Detalles: ").Append(Detalles).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ActualizarPedidoPlantaBeneficioRequest)obj);
        }

        /// <summary>
        /// Returns true if ActualizarPedidoPlantaBeneficioRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of ActualizarPedidoPlantaBeneficioRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ActualizarPedidoPlantaBeneficioRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    PedidoId == other.PedidoId &&
                    PedidoId.Equals(other.PedidoId)
                ) &&
                (
                    Detalles == other.Detalles ||
                    Detalles != null &&
                    Detalles.SequenceEqual(other.Detalles)
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
                    hashCode = hashCode * 59 + PedidoId.GetHashCode();
                if (Detalles != null)
                    hashCode = hashCode * 59 + Detalles.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ActualizarPedidoPlantaBeneficioRequest left, ActualizarPedidoPlantaBeneficioRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ActualizarPedidoPlantaBeneficioRequest left, ActualizarPedidoPlantaBeneficioRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
