/*
 * API de Contenedores
 *
 * API de administración de Contenedores
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV.Models.ContenedoresApi
{
    /// <summary>
    /// Representa la cantidad y tipo de contenedor usado para el pesaje
    /// </summary>
    [DataContract]
    public partial class PesajeContenedorResponse : IEquatable<PesajeContenedorResponse>
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
        /// Cantidad usados
        /// </summary>
        /// <value>Cantidad usados</value>
        [DataMember(Name = "cantidad")]
        public int Cantidad { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PesajeContenedorResponse {\n");
            sb.Append("  TipoContenedorId: ").Append(TipoContenedorId).Append("\n");
            sb.Append("  Nombre: ").Append(Nombre).Append("\n");
            sb.Append("  Peso: ").Append(Peso).Append("\n");
            sb.Append("  Cantidad: ").Append(Cantidad).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PesajeContenedorResponse)obj);
        }

        /// <summary>
        /// Returns true if PesajeContenedorResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of PesajeContenedorResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PesajeContenedorResponse other)
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
                    Cantidad == other.Cantidad ||
                    Cantidad != null &&
                    Cantidad.Equals(other.Cantidad)
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
                if (Cantidad != null)
                    hashCode = hashCode * 59 + Cantidad.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(PesajeContenedorResponse left, PesajeContenedorResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PesajeContenedorResponse left, PesajeContenedorResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
