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

namespace EVO_WebApi.Models.MotivosApi
{
    /// <summary>
    /// Indica un motivo
    /// </summary>
    [DataContract]
    public partial class MotivoResponse : IEquatable<MotivoResponse>
    {
        /// <summary>
        /// Id del motivo
        /// </summary>
        /// <value>Id del motivo</value>
        [Required]
        [DataMember(Name = "MotivoId")]
        public int MotivoId { get; set; }

        /// <summary>
        /// Valor del motivo
        /// </summary>
        /// <value>Valor del motivo</value>
        [Required]
        [DataMember(Name = "Motivo")]
        public string Motivo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MotivoResponse {\n");
            sb.Append("  MotivoId: ").Append(MotivoId).Append("\n");
            sb.Append("  Motivo: ").Append(Motivo).Append("\n");
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
            return obj.GetType() == GetType() && Equals((MotivoResponse)obj);
        }

        /// <summary>
        /// Returns true if MotivoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of MotivoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MotivoResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    MotivoId == other.MotivoId ||
                    MotivoId != null &&
                    MotivoId.Equals(other.MotivoId)
                ) &&
                (
                    Motivo == other.Motivo ||
                    Motivo != null &&
                    Motivo.Equals(other.Motivo)
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
                if (MotivoId != null)
                    hashCode = hashCode * 59 + MotivoId.GetHashCode();
                if (Motivo != null)
                    hashCode = hashCode * 59 + Motivo.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(MotivoResponse left, MotivoResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MotivoResponse left, MotivoResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
