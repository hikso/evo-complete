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
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.UsuariosApi
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ObtenerTodosUsuariosGrupoDominioMenosRolResponseRegistros : IEquatable<ObtenerTodosUsuariosGrupoDominioMenosRolResponseRegistros>
    { 
        /// <summary>
        /// Usuario del Usuario
        /// </summary>
        /// <value>Usuario del Usuario</value>
        [DataMember(Name="usuario")]
        public string Usuario { get; set; }

        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        /// <value>Nombre del Usuario</value>
        [DataMember(Name="nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerTodosUsuariosGrupoDominioMenosRolResponseRegistros {\n");
            sb.Append("  Usuario: ").Append(Usuario).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerTodosUsuariosGrupoDominioMenosRolResponseRegistros)obj);
        }

        /// <summary>
        /// Returns true if ObtenerTodosUsuariosGrupoDominioMenosRolResponseRegistros instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerTodosUsuariosGrupoDominioMenosRolResponseRegistros to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerTodosUsuariosGrupoDominioMenosRolResponseRegistros other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Usuario == other.Usuario ||
                    Usuario != null &&
                    Usuario.Equals(other.Usuario)
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
                    if (Usuario != null)
                    hashCode = hashCode * 59 + Usuario.GetHashCode();
                    if (Nombre != null)
                    hashCode = hashCode * 59 + Nombre.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ObtenerTodosUsuariosGrupoDominioMenosRolResponseRegistros left, ObtenerTodosUsuariosGrupoDominioMenosRolResponseRegistros right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerTodosUsuariosGrupoDominioMenosRolResponseRegistros left, ObtenerTodosUsuariosGrupoDominioMenosRolResponseRegistros right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}