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
    /// Representa la respuesta de un pedido
    /// </summary>
    [DataContract]
    public partial class PedidoRespuestaResponse : IEquatable<PedidoRespuestaResponse>
    {
        /// <summary>
        /// Define el estado de la respuesta
        /// </summary>  
        [DataMember(Name = "Estado")]
        public bool Estado { get; set; }

        /// <summary>
        /// Código del pedido
        /// </summary>
        /// <value>PRA-1</value>
        [DataMember(Name = "Codigo")]
        public string Codigo { get; set; }

        /// <summary>
        /// Respuesta de SAP
        /// </summary>
        /// <value>True | Mensaje</value>
        [DataMember(Name = "RespuestaSAP")]
        public string RespuestaSAP { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PedidoRespuestaResponse {\n");
            sb.Append("  RespuestaSAP: ").Append(RespuestaSAP).Append("\n");
            sb.Append("  Codigo: ").Append(Codigo).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PedidoRespuestaResponse)obj);
        }

        /// <summary>
        /// Returns true if PedidoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of PedidoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PedidoRespuestaResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    RespuestaSAP == other.RespuestaSAP ||
                    RespuestaSAP != null &&
                    RespuestaSAP.Equals(other.RespuestaSAP)
                ) &&
                (
                    Codigo == other.Codigo ||
                    Codigo != null &&
                    Codigo.Equals(other.Codigo)
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
                if (RespuestaSAP != null)
                    hashCode = hashCode * 59 + RespuestaSAP.GetHashCode();
                if (Codigo != null)
                    hashCode = hashCode * 59 + Codigo.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(PedidoRespuestaResponse left, PedidoRespuestaResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PedidoRespuestaResponse left, PedidoRespuestaResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
