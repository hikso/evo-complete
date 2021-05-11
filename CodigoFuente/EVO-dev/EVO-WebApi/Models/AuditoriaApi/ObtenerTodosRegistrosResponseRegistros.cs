/*
 * API de Auditoria
 *
 * API de administración de Auditoria 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.AuditoriaApi
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ObtenerTodosRegistrosResponseRegistros : IEquatable<ObtenerTodosRegistrosResponseRegistros>
    { 
        /// <summary>
        /// Fecha en la que se registra la acción
        /// </summary>
        /// <value>Fecha en la que se registra la acción</value>
        [DataMember(Name="fecha")]
        public string Fecha { get; set; }

        /// <summary>
        /// Usuario cuya acción está siendo auditada
        /// </summary>
        /// <value>Usuario cuya acción está siendo auditada</value>
        [DataMember(Name="usuario")]
        public string Usuario { get; set; }

        /// <summary>
        /// Acción que está siendo auditada
        /// </summary>
        /// <value>Acción que está siendo auditada</value>
        [DataMember(Name="accion")]
        public string Accion { get; set; }

        /// <summary>
        /// Objeto serializado en formato JSON que contiene los parámetros de la acción
        /// </summary>
        /// <value>Objeto serializado en formato JSON que contiene los parámetros de la acción</value>
        [DataMember(Name="parametros")]
        public string Parametros { get; set; }

        /// <summary>
        /// Dirección IP desde la cuál se realizó la acción
        /// </summary>
        /// <value>Dirección IP desde la cuál se realizó la acción</value>
        [DataMember(Name="ip")]
        public string Ip { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerTodosRegistrosResponseRegistros {\n");
            sb.Append("  Fecha: ").Append(Fecha).Append("\n");
            sb.Append("  Usuario: ").Append(Usuario).Append("\n");
            sb.Append("  Accion: ").Append(Accion).Append("\n");
            sb.Append("  Parametros: ").Append(Parametros).Append("\n");
            sb.Append("  Ip: ").Append(Ip).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerTodosRegistrosResponseRegistros)obj);
        }

        /// <summary>
        /// Returns true if ObtenerTodosRegistrosResponseRegistros instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerTodosRegistrosResponseRegistros to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerTodosRegistrosResponseRegistros other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Fecha == other.Fecha ||
                    Fecha != null &&
                    Fecha.Equals(other.Fecha)
                ) && 
                (
                    Usuario == other.Usuario ||
                    Usuario != null &&
                    Usuario.Equals(other.Usuario)
                ) && 
                (
                    Accion == other.Accion ||
                    Accion != null &&
                    Accion.Equals(other.Accion)
                ) && 
                (
                    Parametros == other.Parametros ||
                    Parametros != null &&
                    Parametros.Equals(other.Parametros)
                ) && 
                (
                    Ip == other.Ip ||
                    Ip != null &&
                    Ip.Equals(other.Ip)
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
                    if (Fecha != null)
                    hashCode = hashCode * 59 + Fecha.GetHashCode();
                    if (Usuario != null)
                    hashCode = hashCode * 59 + Usuario.GetHashCode();
                    if (Accion != null)
                    hashCode = hashCode * 59 + Accion.GetHashCode();
                    if (Parametros != null)
                    hashCode = hashCode * 59 + Parametros.GetHashCode();
                    if (Ip != null)
                    hashCode = hashCode * 59 + Ip.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ObtenerTodosRegistrosResponseRegistros left, ObtenerTodosRegistrosResponseRegistros right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerTodosRegistrosResponseRegistros left, ObtenerTodosRegistrosResponseRegistros right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}