/*
 * API de Pedidos
 *
 * API de administración de Pedidos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace EVO_PV_WebApi.Models.PedidosApi
{ 
    /// <summary>
    /// Indica un estado del pedido
    /// </summary>
    [DataContract]
    public partial class ObtenerEstadoPedidoResponse : IEquatable<ObtenerEstadoPedidoResponse>
    { 
        /// <summary>
        /// Id del estado del pedido
        /// </summary>
        /// <value>Id del estado del pedido</value>
        [Required]
        [DataMember(Name="EstadoId")]
        public int EstadoId { get; set; }

        /// <summary>
        /// Estado del pedido
        /// </summary>
        /// <value>Estado del pedido</value>
        [Required]
        [DataMember(Name="EstadoNombre")]
        public string EstadoNombre { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerEstadoPedidoResponse {\n");
            sb.Append("  EstadoId: ").Append(EstadoId).Append("\n");
            sb.Append("  EstadoNombre: ").Append(EstadoNombre).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerEstadoPedidoResponse)obj);
        }

        /// <summary>
        /// Returns true if ObtenerEstadoPedidoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerEstadoPedidoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerEstadoPedidoResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    EstadoId == other.EstadoId &&
                    EstadoId.Equals(other.EstadoId)
                ) && 
                (
                    EstadoNombre == other.EstadoNombre ||
                    EstadoNombre != null &&
                    EstadoNombre.Equals(other.EstadoNombre)
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
                    hashCode = hashCode * 59 + EstadoId.GetHashCode();
                    if (EstadoNombre != null)
                    hashCode = hashCode * 59 + EstadoNombre.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ObtenerEstadoPedidoResponse left, ObtenerEstadoPedidoResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerEstadoPedidoResponse left, ObtenerEstadoPedidoResponse right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}