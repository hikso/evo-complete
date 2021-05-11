/*
 * API de Evidencias
 *
 * OpenAPI spec version: 1.0.0
 * Contact: galfonso@digitalcg.com.co
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV.Models.RecepcionApi
{
    /// <summary>
    /// Representa el encabezado de recepción
    /// </summary>
    [DataContract]
    public partial class InconsistenciaArchivoResponse : IEquatable<InconsistenciaArchivoResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "NombreArchivo")]
        public string NombreArchivo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ExtensionArchivo")]
        public string ExtensionArchivo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InconsistenciaResponse {\n");
            sb.Append("  NombreArchivo: ").Append(NombreArchivo).Append("\n");
            sb.Append("  ExtensionArchivo: ").Append(ExtensionArchivo).Append("\n");
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
            return obj.GetType() == GetType() && Equals((InconsistenciaResponse)obj);
        }

        /// <summary>
        /// Returns true if RecepcionEncabezadoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of RecepcionEncabezadoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InconsistenciaArchivoResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    NombreArchivo == other.NombreArchivo ||
                    NombreArchivo != null &&
                    NombreArchivo.Equals(other.NombreArchivo)
                ) &&
                (
                    ExtensionArchivo == other.ExtensionArchivo ||
                    ExtensionArchivo != null &&
                    ExtensionArchivo.Equals(other.ExtensionArchivo)
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
                if (NombreArchivo != null) hashCode = hashCode * 59 + NombreArchivo.GetHashCode();
                if (ExtensionArchivo != null) hashCode = hashCode * 59 + ExtensionArchivo.GetHashCode();
                
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(InconsistenciaArchivoResponse left, InconsistenciaArchivoResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InconsistenciaArchivoResponse left, InconsistenciaArchivoResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
