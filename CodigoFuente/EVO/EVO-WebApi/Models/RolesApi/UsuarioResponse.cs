/*
 * API de Roles de Usuario
 *
 * API de administración de Roles de usuario
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

namespace EVO_WebApi.Models.RolesApi
{
    /// <summary>
    /// Objeto que representa un Usuario
    /// </summary>
    [DataContract]
    public partial class UsuarioResponse : IEquatable<UsuarioResponse>
    { 
        /// <summary>
        /// Id del usuario
        /// </summary>
        /// <value>Id del usuario</value>
        [Required]
        [DataMember(Name="usuarioId")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Nombre de usuario
        /// </summary>
        /// <value>Nombre de usuario</value>
        [Required]
        [DataMember(Name="nombreUsuario")]
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Nombre completo del usuario
        /// </summary>
        /// <value>Nombre completo del usuario</value>
        [Required]
        [DataMember(Name="nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UsuarioResponse {\n");
            sb.Append("  UsuarioId: ").Append(UsuarioId).Append("\n");
            sb.Append("  NombreUsuario: ").Append(NombreUsuario).Append("\n");
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
            return obj.GetType() == GetType() && Equals((UsuarioResponse)obj);
        }

        /// <summary>
        /// Returns true if UsuarioResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of UsuarioResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UsuarioResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    UsuarioId == other.UsuarioId  &&
                    UsuarioId.Equals(other.UsuarioId)
                ) && 
                (
                    NombreUsuario == other.NombreUsuario ||
                    NombreUsuario != null &&
                    NombreUsuario.Equals(other.NombreUsuario)
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
                    hashCode = hashCode * 59 + UsuarioId.GetHashCode();
                    if (NombreUsuario != null)
                    hashCode = hashCode * 59 + NombreUsuario.GetHashCode();
                    if (Nombre != null)
                    hashCode = hashCode * 59 + Nombre.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(UsuarioResponse left, UsuarioResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UsuarioResponse left, UsuarioResponse right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}