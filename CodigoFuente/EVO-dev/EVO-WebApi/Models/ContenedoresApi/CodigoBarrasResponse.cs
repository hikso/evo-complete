/*
 * API de Contenedores
 *
 * API de administración de Contenedores
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.ContenedoresApi
{
    /// <summary>
    /// Representa un código de barras de un contenedor
    /// </summary>
    [DataContract]
    public partial class CodigoBarrasResponse : IEquatable<CodigoBarrasResponse>
    {
        /// <summary>
        /// Código de barras (01485&#x3D;código artículo | 00123&#x3D;lote | 220120&#x3D;fecha vencimiento | 00006 &#x3D; cantidad artículo | 00101&#x3D;peso)
        /// </summary>
        /// <value>Código de barras (01485&#x3D;código artículo | 00123&#x3D;lote | 220120&#x3D;fecha vencimiento | 00006 &#x3D; cantidad artículo | 00101&#x3D;peso)</value>
        [DataMember(Name = "codigoBarras")]
        public string CodigoBarras { get; set; }

        /// <summary>
        /// Lote de la bodega
        /// </summary>
        /// <value>Lote de la bodega</value>
        [DataMember(Name = "lote")]
        public string Lote { get; set; }

        /// <summary>
        /// Fecha de vencimiento de los artículos del contenedor
        /// </summary>
        /// <value>Fecha de vencimiento de los artículos del contenedor</value>
        [DataMember(Name = "fechaVencimiento")]
        public string FechaVencimiento { get; set; }

        /// <summary>
        /// Unidades del artículo del contenedor
        /// </summary>
        /// <value>Unidades del artículo del contenedor</value>
        [DataMember(Name = "unidadesArticulo")]
        public int Unidades { get; set; }

        /// <summary>
        /// Peso del contenedor con los articulos
        /// </summary>
        /// <value>Peso del contenedor con los articulos</value>
        [DataMember(Name = "peso")]
        public decimal Peso { get; set; }

        /// <summary>
        /// Indica si existe alguna inconsistencia entre pesaje de código de barras y báscula
        /// </summary>
        /// <value>Indica si existe alguna inconsistencia entre pesaje de código de barras y báscula</value>
        [DataMember(Name = "inconsistenciaCodigoBarras")]
        public bool? InconsistenciaCodigoBarras { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CodigoBarrasResponse {\n");
            sb.Append("  CodigoBarras: ").Append(CodigoBarras).Append("\n");
            sb.Append("  Lote: ").Append(Lote).Append("\n");
            sb.Append("  FechaVencimiento: ").Append(FechaVencimiento).Append("\n");
            sb.Append("  UnidadesArticulo: ").Append(Unidades).Append("\n");
            sb.Append("  Peso: ").Append(Peso).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CodigoBarrasResponse)obj);
        }

        /// <summary>
        /// Returns true if CodigoBarrasResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of CodigoBarrasResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CodigoBarrasResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    CodigoBarras == other.CodigoBarras ||
                    CodigoBarras != null &&
                    CodigoBarras.Equals(other.CodigoBarras)
                ) &&
                (
                    Lote == other.Lote ||
                    Lote != null &&
                    Lote.Equals(other.Lote)
                ) &&
                (
                    FechaVencimiento == other.FechaVencimiento ||
                    FechaVencimiento != null &&
                    FechaVencimiento.Equals(other.FechaVencimiento)
                ) &&
                (
                    Unidades == other.Unidades ||
                    Unidades != null &&
                    Unidades.Equals(other.Unidades)
                ) &&
                (
                    Peso == other.Peso ||
                    Peso != null &&
                    Peso.Equals(other.Peso)
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
                if (CodigoBarras != null)
                    hashCode = hashCode * 59 + CodigoBarras.GetHashCode();
                if (Lote != null)
                    hashCode = hashCode * 59 + Lote.GetHashCode();
                if (FechaVencimiento != null)
                    hashCode = hashCode * 59 + FechaVencimiento.GetHashCode();
                if (Unidades != null)
                    hashCode = hashCode * 59 + Unidades.GetHashCode();
                if (Peso != null)
                    hashCode = hashCode * 59 + Peso.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(CodigoBarrasResponse left, CodigoBarrasResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CodigoBarrasResponse left, CodigoBarrasResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
