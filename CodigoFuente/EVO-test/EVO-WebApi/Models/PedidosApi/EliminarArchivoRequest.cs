/*
 * API de Pedidos
 *
 * API de administración de Pedidos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
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

namespace EVO_WebApi.Models.PedidosApi
{ 
    /// <summary>
    /// Representa archivo enviado
    /// </summary>
    [DataContract]
    public partial class EliminarArchivoRequest : IEquatable<EliminarArchivoRequest>
    { 
        /// <summary>
        /// Nombre del archivo
        /// </summary>
        /// <value>Nombre del archivo</value>
        [DataMember(Name="NombreArchivo")]
        public string NombreArchivo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EliminarArchivoRequest {\n");
            sb.Append("  NombreArchivo: ").Append(NombreArchivo).Append("\n");
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
            return obj.GetType() == GetType() && Equals((EliminarArchivoRequest)obj);
        }

        /// <summary>
        /// Returns true if EliminarArchivoRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of EliminarArchivoRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EliminarArchivoRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    NombreArchivo == other.NombreArchivo ||
                    NombreArchivo != null &&
                    NombreArchivo.Equals(other.NombreArchivo)
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
                    if (NombreArchivo != null)
                    hashCode = hashCode * 59 + NombreArchivo.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(EliminarArchivoRequest left, EliminarArchivoRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EliminarArchivoRequest left, EliminarArchivoRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
