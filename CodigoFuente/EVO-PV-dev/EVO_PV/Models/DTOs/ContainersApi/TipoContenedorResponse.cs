using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV.Models.DTOs.BusinessObjects
{
    /// <summary>
    /// Representa un tipo de contenedor
    /// </summary>
    [DataContract]
    public partial class TipoContenedorResponse : IEquatable<TipoContenedorResponse>
    {
        /// <summary>
        /// Id
        /// </summary>
        /// <value>Id</value>
        [DataMember(Name = "tipoContenedorId")]
        public int TipoContenedorId { get; set; }

        /// <summary>
        /// Nomnbre
        /// </summary>
        /// <value>Nomnbre</value>
        [DataMember(Name = "nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// peso
        /// </summary>
        /// <value>peso</value>
        [DataMember(Name = "peso")]
        public decimal Peso { get; set; }

        /// <summary>
        /// indica si tienen código de barras
        /// </summary>
        /// <value>indica si tienen código de barras</value>
        [DataMember(Name = "codigoBarras")]
        public bool CodigoBarras { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TipoContenedorResponse {\n");
            sb.Append("  TipoContenedorId: ").Append(TipoContenedorId).Append("\n");
            sb.Append("  Nombre: ").Append(Nombre).Append("\n");
            sb.Append("  Peso: ").Append(Peso).Append("\n");
            sb.Append("  CodigoBarras: ").Append(CodigoBarras).Append("\n");
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
            return obj.GetType() == GetType() && Equals((TipoContenedorResponse)obj);
        }

        /// <summary>
        /// Returns true if TipoContenedorResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of TipoContenedorResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TipoContenedorResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    TipoContenedorId == other.TipoContenedorId ||
                    TipoContenedorId != null &&
                    TipoContenedorId.Equals(other.TipoContenedorId)
                ) &&
                (
                    Nombre == other.Nombre ||
                    Nombre != null &&
                    Nombre.Equals(other.Nombre)
                ) &&
                (
                    Peso == other.Peso ||
                    Peso != null &&
                    Peso.Equals(other.Peso)
                ) &&
                (
                    CodigoBarras == other.CodigoBarras ||
                    CodigoBarras != null &&
                    CodigoBarras.Equals(other.CodigoBarras)
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
                if (TipoContenedorId != null)
                    hashCode = hashCode * 59 + TipoContenedorId.GetHashCode();
                if (Nombre != null)
                    hashCode = hashCode * 59 + Nombre.GetHashCode();
                if (Peso != null)
                    hashCode = hashCode * 59 + Peso.GetHashCode();
                if (CodigoBarras != null)
                    hashCode = hashCode * 59 + CodigoBarras.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(TipoContenedorResponse left, TipoContenedorResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TipoContenedorResponse left, TipoContenedorResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
