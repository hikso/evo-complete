/*
 * API de Vendedores
 *
 * API de administración de Vendedores 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV.Models
{
    /// <summary>
    /// Representa un vendedor
    /// </summary>
    [DataContract]
    public partial class VendedorResponse : IEquatable<VendedorResponse>
    {
        /// <summary>
        /// Id del vendedor
        /// </summary>
        /// <value>Id del vendedor</value>
        [DataMember(Name = "vendedorId")]
        public int VendedorId { get; set; }

        /// <summary>
        /// Nombres del vendedor
        /// </summary>
        /// <value>Nombres del vendedor</value>
        [DataMember(Name = "nombres")]
        public string Nombres { get; set; }

        /// <summary>
        /// Apellidos del vendedor
        /// </summary>
        /// <value>Apellidos del vendedor</value>
        [DataMember(Name = "apellidos")]
        public string Apellidos { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VendedorResponse {\n");
            sb.Append("  VendedorId: ").Append(VendedorId).Append("\n");
            sb.Append("  Nombres: ").Append(Nombres).Append("\n");
            sb.Append("  Apellidos: ").Append(Apellidos).Append("\n");
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
            return obj.GetType() == GetType() && Equals((VendedorResponse)obj);
        }

        /// <summary>
        /// Returns true if VendedorResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of VendedorResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VendedorResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    VendedorId == other.VendedorId ||
                    VendedorId != null &&
                    VendedorId.Equals(other.VendedorId)
                ) &&
                (
                    Nombres == other.Nombres ||
                    Nombres != null &&
                    Nombres.Equals(other.Nombres)
                ) &&
                (
                    Apellidos == other.Apellidos ||
                    Apellidos != null &&
                    Apellidos.Equals(other.Apellidos)
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
                if (VendedorId != null)
                    hashCode = hashCode * 59 + VendedorId.GetHashCode();
                if (Nombres != null)
                    hashCode = hashCode * 59 + Nombres.GetHashCode();
                if (Apellidos != null)
                    hashCode = hashCode * 59 + Apellidos.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(VendedorResponse left, VendedorResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(VendedorResponse left, VendedorResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
