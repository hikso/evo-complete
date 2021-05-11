using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace EVO_PV_Proxy.Models.AuditoriaApi
{
    /// <summary>
    /// Objeto que contiene un registro de Auditoria
    /// </summary>
    [DataContract]
    public partial class RegistroAuditoriaRequest : IEquatable<RegistroAuditoriaRequest>
    {
        /// <summary>
        /// Acción que está siendo auditada
        /// </summary>
        /// <value>Acción que está siendo auditada</value>
        [Required]
        [DataMember(Name = "accion")]
        public string Accion { get; set; }

        /// <summary>
        /// Objeto serializado en formato JSON que contiene los parámetros de la acción
        /// </summary>
        /// <value>Objeto serializado en formato JSON que contiene los parámetros de la acción</value>
        [DataMember(Name = "parametros")]
        public string Parametros { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RegistroAuditoriaRequest {\n");
            sb.Append("  Accion: ").Append(Accion).Append("\n");
            sb.Append("  Parametros: ").Append(Parametros).Append("\n");
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
            return obj.GetType() == GetType() && Equals((RegistroAuditoriaRequest)obj);
        }

        /// <summary>
        /// Returns true if RegistroAuditoriaRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of RegistroAuditoriaRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RegistroAuditoriaRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Accion == other.Accion ||
                    Accion != null &&
                    Accion.Equals(other.Accion)
                ) &&
                (
                    Parametros == other.Parametros ||
                    Parametros != null &&
                    Parametros.Equals(other.Parametros)
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
                if (Accion != null)
                    hashCode = hashCode * 59 + Accion.GetHashCode();
                if (Parametros != null)
                    hashCode = hashCode * 59 + Parametros.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(RegistroAuditoriaRequest left, RegistroAuditoriaRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RegistroAuditoriaRequest left, RegistroAuditoriaRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}