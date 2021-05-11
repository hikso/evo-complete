/*
 * API de    API de administración de Socios de Negocio
 *
 * API de administración de Socios de Negocio 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.SociosNegocioApi
{
    /// <summary>
    /// Representa un socio de negocio
    /// </summary>
    [DataContract]
    public partial class SocioNegocioResponse : IEquatable<SocioNegocioResponse>
    {
        /// <summary>
        /// Indica la Identificación
        /// </summary>
        /// <value>Indica la Identificación</value>
        [DataMember(Name = "Identificacion")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Indica el nombre
        /// </summary>
        /// <value>Indica el nombre</value>
        [DataMember(Name = "Nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SocioNegocioResponse {\n");
            sb.Append("  Identificacion: ").Append(Identificacion).Append("\n");
            sb.Append("  Nombre: ").Append(Nombre).Append("\n");
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
            return obj.GetType() == GetType() && Equals((SocioNegocioResponse)obj);
        }

        /// <summary>
        /// Returns true if SocioNegocioResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of SocioNegocioResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SocioNegocioResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Identificacion == other.Identificacion ||
                    Identificacion != null &&
                    Identificacion.Equals(other.Identificacion)
                ) &&
                (
                    Nombre == other.Nombre ||
                    Nombre != null &&
                    Nombre.Equals(other.Nombre)
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
                if (Identificacion != null)
                    hashCode = hashCode * 59 + Identificacion.GetHashCode();
                if (Nombre != null)
                    hashCode = hashCode * 59 + Nombre.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(SocioNegocioResponse left, SocioNegocioResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SocioNegocioResponse left, SocioNegocioResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
