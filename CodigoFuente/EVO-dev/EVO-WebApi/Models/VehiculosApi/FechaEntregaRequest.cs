/*
 * API de Vehiculos
 *
 * API de administración de Vehiculos 
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

namespace EVO_WebApi.Models.VehiculosApi
{
    /// <summary>
    /// Fecha de una entrega
    /// </summary>
    [DataContract]
    public partial class FechaEntregaRequest : IEquatable<FechaEntregaRequest>
    {
        /// <summary>
        /// Fecha de entrega
        /// </summary>
        /// <value>Fecha de entrega</value>
        [Required]
        [DataMember(Name = "fecha")]
        public string Fecha { get; set; }

        /// <summary>
        /// Hora de entrega
        /// </summary>
        /// <value>Hora de entrega</value>
        [DataMember(Name = "cargo")]
        public string Cargo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FechaEntregaRequest {\n");
            sb.Append("  Fecha: ").Append(Fecha).Append("\n");
            sb.Append("  Cargo: ").Append(Cargo).Append("\n");
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
            return obj.GetType() == GetType() && Equals((FechaEntregaRequest)obj);
        }

        /// <summary>
        /// Returns true if FechaEntregaRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of FechaEntregaRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FechaEntregaRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Fecha == other.Fecha ||
                    Fecha != null &&
                    Fecha.Equals(other.Fecha)
                ) &&
                (
                    Cargo == other.Cargo ||
                    Cargo != null &&
                    Cargo.Equals(other.Cargo)
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
                if (Fecha != null)
                    hashCode = hashCode * 59 + Fecha.GetHashCode();
                if (Cargo != null)
                    hashCode = hashCode * 59 + Cargo.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(FechaEntregaRequest left, FechaEntregaRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FechaEntregaRequest left, FechaEntregaRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
