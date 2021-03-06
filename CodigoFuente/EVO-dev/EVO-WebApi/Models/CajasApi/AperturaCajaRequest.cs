/*
 * API de    API de administración de Cajas
 *
 * API de administración de Cajas 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.CajasApi
{
    /// <summary>
    /// Representa el registro de apertura de caja
    /// </summary>
    [DataContract]
    public partial class AperturaCajaRequest : IEquatable<AperturaCajaRequest>
    {
        /// <summary>
        /// Indica el código del punto de venta
        /// </summary>
        /// <value>Indica el código del punto de venta</value>
        [DataMember(Name = "codigoPuntoVenta")]
        public string CodigoPuntoVenta { get; set; }

        /// <summary>
        /// Indica el valor de apertura de la caja
        /// </summary>
        /// <value>Indica el valor de apertura de la caja</value>
        [DataMember(Name = "valorApertura")]
        public decimal ValorApertura { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AperturaCajaRequest {\n");
            sb.Append("  CodigoPuntoVenta: ").Append(CodigoPuntoVenta).Append("\n");
            sb.Append("  ValorApertura: ").Append(ValorApertura).Append("\n");
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
            return obj.GetType() == GetType() && Equals((AperturaCajaRequest)obj);
        }

        /// <summary>
        /// Returns true if AperturaCajaRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of AperturaCajaRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AperturaCajaRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    CodigoPuntoVenta == other.CodigoPuntoVenta ||
                    CodigoPuntoVenta != null &&
                    CodigoPuntoVenta.Equals(other.CodigoPuntoVenta)
                ) &&
                (
                    ValorApertura == other.ValorApertura ||
                    ValorApertura != null &&
                    ValorApertura.Equals(other.ValorApertura)
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
                if (CodigoPuntoVenta != null)
                    hashCode = hashCode * 59 + CodigoPuntoVenta.GetHashCode();
                if (ValorApertura != null)
                    hashCode = hashCode * 59 + ValorApertura.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(AperturaCajaRequest left, AperturaCajaRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AperturaCajaRequest left, AperturaCajaRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
