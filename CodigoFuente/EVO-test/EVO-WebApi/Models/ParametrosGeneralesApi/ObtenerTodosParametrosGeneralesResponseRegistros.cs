/*
 * API de Parámetros Generales
 *
 * API de administración de Parámetros Generales
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.ParametrosGeneralesApi
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ObtenerTodosParametrosGeneralesResponseRegistros : IEquatable<ObtenerTodosParametrosGeneralesResponseRegistros>
    { 
        /// <summary>
        /// id del parámetro general
        /// </summary>
        /// <value>id del parámetro general</value>
        [DataMember(Name="parametroGeneralId")]
        public int ParametroGeneralId { get; set; }

        /// <summary>
        /// nombre del parámetro general
        /// </summary>
        /// <value>nombre del parámetro general</value>
        [DataMember(Name="nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// valor de parámetro general
        /// </summary>
        /// <value>valor de parámetro general</value>
        [DataMember(Name="valor")]
        public string Valor { get; set; }

        /// <summary>
        /// Indica si el Parámetro General se encuentra activo / inactivo
        /// </summary>
        /// <value>Indica si el Parámetro General se encuentra activo / inactivo</value>
        [DataMember(Name="activo")]
        public bool Activo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerTodosParametrosGeneralesResponseRegistros {\n");
            sb.Append("  ParametroGeneralId: ").Append(ParametroGeneralId).Append("\n");
            sb.Append("  Nombre: ").Append(Nombre).Append("\n");
            sb.Append("  Valor: ").Append(Valor).Append("\n");
            sb.Append("  Activo: ").Append(Activo).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerTodosParametrosGeneralesResponseRegistros)obj);
        }

        /// <summary>
        /// Returns true if ObtenerTodosParametrosGeneralesResponseRegistros instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerTodosParametrosGeneralesResponseRegistros to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerTodosParametrosGeneralesResponseRegistros other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    ParametroGeneralId == other.ParametroGeneralId  &&
                    ParametroGeneralId.Equals(other.ParametroGeneralId)
                ) && 
                (
                    Nombre == other.Nombre ||
                    Nombre != null &&
                    Nombre.Equals(other.Nombre)
                ) && 
                (
                    Valor == other.Valor ||
                    Valor != null &&
                    Valor.Equals(other.Valor)
                ) && 
                (
                    Activo == other.Activo  &&
                    Activo.Equals(other.Activo)
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
                    hashCode = hashCode * 59 + ParametroGeneralId.GetHashCode();
                    if (Nombre != null)
                    hashCode = hashCode * 59 + Nombre.GetHashCode();
                    if (Valor != null)
                    hashCode = hashCode * 59 + Valor.GetHashCode();
                    hashCode = hashCode * 59 + Activo.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ObtenerTodosParametrosGeneralesResponseRegistros left, ObtenerTodosParametrosGeneralesResponseRegistros right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerTodosParametrosGeneralesResponseRegistros left, ObtenerTodosParametrosGeneralesResponseRegistros right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}