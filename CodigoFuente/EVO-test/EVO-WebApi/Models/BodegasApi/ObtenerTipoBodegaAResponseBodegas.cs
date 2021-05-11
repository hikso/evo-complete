/*
 * API de Pedidos
 *
 * API de administración de Pedidos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.BodegasApi
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ObtenerTipoBodegaAResponseBodegas : IEquatable<ObtenerTipoBodegaAResponseBodegas>
    {
        /// <summary>
        /// Código de la bodega
        /// </summary>
        /// <value>Código de la bodega</value>
        [DataMember(Name = "codigo")]
        public string Codigo { get; set; }

        /// <summary>
        /// Nombre de la bodega
        /// </summary>
        /// <value>Nombre de la bodega</value>
        [DataMember(Name = "nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerSolicitudPedidoAResponseBodegas {\n");
            sb.Append("  Codigo: ").Append(Codigo).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerTipoBodegaAResponseBodegas)obj);
        }

        /// <summary>
        /// Returns true if ObtenerSolicitudPedidoAResponseBodegas instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerSolicitudPedidoAResponseBodegas to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerTipoBodegaAResponseBodegas other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Codigo == other.Codigo ||
                    Codigo != null &&
                    Codigo.Equals(other.Codigo)
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
                if (Codigo != null)
                    hashCode = hashCode * 59 + Codigo.GetHashCode();
                if (Nombre != null)
                    hashCode = hashCode * 59 + Nombre.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ObtenerTipoBodegaAResponseBodegas left, ObtenerTipoBodegaAResponseBodegas right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerTipoBodegaAResponseBodegas left, ObtenerTipoBodegaAResponseBodegas right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}