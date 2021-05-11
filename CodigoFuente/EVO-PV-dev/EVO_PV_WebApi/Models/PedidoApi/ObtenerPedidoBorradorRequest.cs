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
    /// Solicitud verificar si existe pedido en borrador
    /// </summary>
    [DataContract]
    public partial class ObtenerPedidoBorradorRequest : IEquatable<ObtenerPedidoBorradorRequest>
    { 
        /// <summary>
        /// Código de la bodega que genera el pedido
        /// </summary>
        /// <value>Código de la bodega que genera el pedido</value>
        [Required]
        [DataMember(Name="WhsCode")]
        public string WhsCode { get; set; }

        /// <summary>
        /// Código de la bodega para donde va el pedido
        /// </summary>
        /// <value>Código de la bodega para donde va el pedido</value>
        [Required]
        [DataMember(Name="SolicitudPara")]
        public string SolicitudPara { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerPedidoBorradorRequest {\n");
            sb.Append("  WhsCode: ").Append(WhsCode).Append("\n");
            sb.Append("  SolicitudPara: ").Append(SolicitudPara).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerPedidoBorradorRequest)obj);
        }

        /// <summary>
        /// Returns true if ObtenerPedidoBorradorRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerPedidoBorradorRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerPedidoBorradorRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    WhsCode == other.WhsCode ||
                    WhsCode != null &&
                    WhsCode.Equals(other.WhsCode)
                ) && 
                (
                    SolicitudPara == other.SolicitudPara ||
                    SolicitudPara != null &&
                    SolicitudPara.Equals(other.SolicitudPara)
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
                    if (WhsCode != null)
                    hashCode = hashCode * 59 + WhsCode.GetHashCode();
                    if (SolicitudPara != null)
                    hashCode = hashCode * 59 + SolicitudPara.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ObtenerPedidoBorradorRequest left, ObtenerPedidoBorradorRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerPedidoBorradorRequest left, ObtenerPedidoBorradorRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
