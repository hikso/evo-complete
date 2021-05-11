/*
 * API de Configuración General
 *
 * API de configuración general del sistema EVO
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.ConfigApi
{
    /// <summary>
    /// Objeto que contiene la versión de la aplicación
    /// </summary>
    [DataContract]
    public partial class VersionResponse : IEquatable<VersionResponse>
    {
        /// <summary>
        /// Indica la versión de la aplicación
        /// </summary>
        /// <value>Indica la versión de la aplicación</value>
        [DataMember(Name = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VersionResponse {\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
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
            return obj.GetType() == GetType() && Equals((VersionResponse)obj);
        }

        /// <summary>
        /// Returns true if VersionResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of VersionResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VersionResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Version == other.Version ||
                    Version != null &&
                    Version.Equals(other.Version)
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
                if (Version != null)
                    hashCode = hashCode * 59 + Version.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(VersionResponse left, VersionResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(VersionResponse left, VersionResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
