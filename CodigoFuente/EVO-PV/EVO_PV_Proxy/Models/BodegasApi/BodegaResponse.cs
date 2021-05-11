/*
 * API de Bodegas
 *
 * API de administración de Bodegas 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV_Proxy.Models.BodegasApi
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class BodegaResponse : IEquatable<BodegaResponse>
    {
        /// <summary>
        /// Código bodega
        /// </summary>
        /// <value>Código bodega</value>
        [Required]
        [DataMember(Name = "WhsCode")]
        public string WhsCode { get; set; }

        /// <summary>
        /// Nombre bodega
        /// </summary>
        /// <value>Nombre bodega</value>
        [Required]
        [DataMember(Name = "WhsName")]
        public string WhsName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class BodegaResponse {\n");
            sb.Append("  WhsCode: ").Append(WhsCode).Append("\n");
            sb.Append("  WhsName: ").Append(WhsName).Append("\n");
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
            return obj.GetType() == GetType() && Equals((BodegaResponse)obj);
        }

        /// <summary>
        /// Returns true if BodegaResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of BodegaResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BodegaResponse other)
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
                    WhsName == other.WhsName ||
                    WhsName != null &&
                    WhsName.Equals(other.WhsName)
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
                if (WhsName != null)
                    hashCode = hashCode * 59 + WhsName.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(BodegaResponse left, BodegaResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BodegaResponse left, BodegaResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}