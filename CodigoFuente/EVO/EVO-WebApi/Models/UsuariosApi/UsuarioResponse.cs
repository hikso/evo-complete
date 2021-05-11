/*
 * API de Usuarios
 *
 * API de administración de Usuarios
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.UsuariosApi
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class UsuarioResponse : IEquatable<UsuarioResponse>
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
        /// <value>Id del usuario</value>
        [DataMember(Name = "usuarioId")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Usuario del usuario
        /// </summary>
        /// <value>Usuario del usuario</value>
        [DataMember(Name = "nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        /// <value>Nombre del Usuario</value>
        [DataMember(Name = "nombreUsuario")]
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Identificación del Usuario
        /// </summary>
        /// <value>Identificación del Usuario</value>
        [DataMember(Name = "identificacion")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Nombres de los cargos(roles) del usuario
        /// </summary>
        /// <value>Nombres de los cargos(roles) del usuario</value>
        [DataMember(Name = "cargos")]
        public List<string> Cargos { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UsuarioResponse {\n");
            sb.Append("  UsuarioId: ").Append(UsuarioId).Append("\n");
            sb.Append("  Nombre: ").Append(Nombre).Append("\n");
            sb.Append("  NombreUsuario: ").Append(NombreUsuario).Append("\n");
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
                    UsuarioId == other.UsuarioId ||
                    UsuarioId != null &&
                    UsuarioId.Equals(other.UsuarioId)
                ) &&
                (
                    Nombre == other.Nombre ||
                    Nombre != null &&
                    Nombre.Equals(other.Nombre)
                ) &&
                (
                    NombreUsuario == other.NombreUsuario ||
                    NombreUsuario != null &&
                    NombreUsuario.Equals(other.NombreUsuario)
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
                if (UsuarioId != null)
                    hashCode = hashCode * 59 + UsuarioId.GetHashCode();
                if (Nombre != null)
                    hashCode = hashCode * 59 + Nombre.GetHashCode();
                if (NombreUsuario != null)
                    hashCode = hashCode * 59 + NombreUsuario.GetHashCode();
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
