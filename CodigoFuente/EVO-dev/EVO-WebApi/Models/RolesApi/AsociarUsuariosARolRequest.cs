/*
 * API de Roles de Usuario
 *
 * API de administración de Roles de usuario
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using EVO_WebApi.Models.RolesApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.UsuariosApi
{
    /// <summary>
    /// Objeto necesario para asociar los usuarios al rol
    /// </summary>
    [DataContract]
    public partial class AsociarUsuariosARolRequest : IEquatable<AsociarUsuariosARolRequest>
    { 
        /// <summary>
        /// Id del Rol a asociar
        /// </summary>
        /// <value>Id del Rol a asociar</value>
        [Required]
        [DataMember(Name="rolId")]
        public int RolId { get; set; }

        /// <summary>
        /// Lista de usuarios a asociar al rol
        /// </summary>
        /// <value>Lista de usuarios a asociar al rol</value>
        [Required]
        [DataMember(Name="usuarios")]
        public List<UsuarioResponse> Usuarios { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AsociarUsuariosARolRequest {\n");
            sb.Append("  RolId: ").Append(RolId).Append("\n");
            sb.Append("  Usuarios: ").Append(Usuarios).Append("\n");
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
            return obj.GetType() == GetType() && Equals((AsociarUsuariosARolRequest)obj);
        }

        /// <summary>
        /// Returns true if AsociarUsuariosARolRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of AsociarUsuariosARolRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AsociarUsuariosARolRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    RolId == other.RolId &&
                    RolId.Equals(other.RolId)
                ) && 
                (
                    Usuarios == other.Usuarios ||
                    Usuarios != null &&
                    Usuarios.SequenceEqual(other.Usuarios)
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
                    hashCode = hashCode * 59 + RolId.GetHashCode();
                    if (Usuarios != null)
                    hashCode = hashCode * 59 + Usuarios.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(AsociarUsuariosARolRequest left, AsociarUsuariosARolRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AsociarUsuariosARolRequest left, AsociarUsuariosARolRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
