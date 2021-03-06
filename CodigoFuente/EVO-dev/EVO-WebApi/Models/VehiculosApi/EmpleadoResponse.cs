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
    /// Respuesta de un empleado
    /// </summary>
    [DataContract]
    public partial class EmpleadoResponse : IEquatable<EmpleadoResponse>
    {
        /// <summary>
        /// Id del empleado
        /// </summary>
        /// <value>Id del empleado</value>
        [Required]
        [DataMember(Name = "empleadoId")]
        public int EmpleadoId { get; set; }

        /// <summary>
        /// Nombres
        /// </summary>
        /// <value>Nombres</value>
        [Required]
        [DataMember(Name = "nombres")]
        public string Nombres { get; set; }

        /// <summary>
        /// Apellidos
        /// </summary>
        /// <value>Apellidos</value>
        [Required]
        [DataMember(Name = "apellidos")]
        public string Apellidos { get; set; }

        /// <summary>
        /// Cédula
        /// </summary>
        /// <value>Cédula</value>
        [Required]
        [DataMember(Name = "cedula")]
        public string Cedula { get; set; }

        /// <summary>
        /// Tipo de cargo
        /// </summary>
        /// <value>Tipo de cargo</value>
        [Required]
        [DataMember(Name = "cargo")]
        public string Cargo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EmpleadoResponse {\n");
            sb.Append("  EmpleadoId: ").Append(EmpleadoId).Append("\n");
            sb.Append("  Nombres: ").Append(Nombres).Append("\n");
            sb.Append("  Apellidos: ").Append(Apellidos).Append("\n");
            sb.Append("  Cedula: ").Append(Cedula).Append("\n");
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
            return obj.GetType() == GetType() && Equals((EmpleadoResponse)obj);
        }

        /// <summary>
        /// Returns true if EmpleadoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of EmpleadoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EmpleadoResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    EmpleadoId == other.EmpleadoId ||
                    EmpleadoId != null &&
                    EmpleadoId.Equals(other.EmpleadoId)
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
                ) &&
                (
                    Cedula == other.Cedula ||
                    Cedula != null &&
                    Cedula.Equals(other.Cedula)
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
                if (EmpleadoId != null)
                    hashCode = hashCode * 59 + EmpleadoId.GetHashCode();
                if (Nombres != null)
                    hashCode = hashCode * 59 + Nombres.GetHashCode();
                if (Apellidos != null)
                    hashCode = hashCode * 59 + Apellidos.GetHashCode();
                if (Cedula != null)
                    hashCode = hashCode * 59 + Cedula.GetHashCode();
                if (Cargo != null)
                    hashCode = hashCode * 59 + Cargo.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(EmpleadoResponse left, EmpleadoResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EmpleadoResponse left, EmpleadoResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
