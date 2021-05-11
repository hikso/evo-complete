﻿using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV.Models.DTOs.BasculasApi
{
    /// <summary>
    /// Representa un tipo de báscula
    /// </summary>
    [DataContract]
    public class TipoBasculaResponse : IEquatable<TipoBasculaResponse>
    {
        /// <summary>
        /// Id del tipo de báscula
        /// </summary>
        /// <value>Id del tipo de báscula</value>
        [DataMember(Name = "tipoBasculaId")]
        public int TipoBasculaId { get; set; }

        /// <summary>
        /// Nomnbre del tipo de báscula
        /// </summary>
        /// <value>Nomnbre del tipo de báscula</value>
        [DataMember(Name = "nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TipoBasculaResponse {\n");
            sb.Append("  TipoBasculaId: ").Append(TipoBasculaId).Append("\n");
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
            return obj.GetType() == GetType() && Equals((TipoBasculaResponse)obj);
        }

        /// <summary>
        /// Returns true if TipoBasculaResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TipoBasculaResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TipoBasculaResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    TipoBasculaId == other.TipoBasculaId ||
                    TipoBasculaId != null &&
                    TipoBasculaId.Equals(other.TipoBasculaId)
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
                if (TipoBasculaId != null)
                    hashCode = hashCode * 59 + TipoBasculaId.GetHashCode();
                if (Nombre != null)
                    hashCode = hashCode * 59 + Nombre.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(TipoBasculaResponse left, TipoBasculaResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TipoBasculaResponse left, TipoBasculaResponse right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
