/*
 * API de Evidencias
 *
 * OpenAPI spec version: 1.0.0
 * Contact: galfonso@digitalcg.com.co
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV.Models.RecepcionApi
{
    /// <summary>
    /// Representa el encabezado de recepción
    /// </summary>
    [DataContract]
    public partial class InconsistenciaResponse : IEquatable<InconsistenciaResponse>
    {
        [DataMember(Name = "evidenciaId")]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>
        [DataMember(Name = "puntoVenta")]
        public string PuntoVenta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "numeroPedido")]
        public string NumeroPedido { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "numeroEntrega")]
        public string NumeroEntrega { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "fechaEvidencia")]
        public string FechaEvidencia { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InconsistenciaResponse {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  PuntoVenta: ").Append(PuntoVenta).Append("\n");
            sb.Append("  FechaEvidencia: ").Append(FechaEvidencia).Append("\n");
            sb.Append("  NumeroPedido: ").Append(NumeroPedido).Append("\n");
            sb.Append("  NumeroEntrega: ").Append(NumeroEntrega).Append("\n");
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
            return obj.GetType() == GetType() && Equals((InconsistenciaResponse)obj);
        }

        /// <summary>
        /// Returns true if RecepcionEncabezadoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of RecepcionEncabezadoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InconsistenciaResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    PuntoVenta == other.PuntoVenta ||
                    PuntoVenta != null &&
                    PuntoVenta.Equals(other.PuntoVenta)
                ) &&
                (
                    FechaEvidencia == other.FechaEvidencia ||
                    FechaEvidencia != null &&
                    FechaEvidencia.Equals(other.FechaEvidencia)
                ) &&
                (
                    NumeroPedido == other.NumeroPedido ||
                    NumeroPedido != null &&
                    NumeroPedido.Equals(other.NumeroPedido)
                ) &&
                (
                    NumeroEntrega == other.NumeroEntrega ||
                    NumeroEntrega != null &&
                    NumeroEntrega.Equals(other.NumeroEntrega)
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
                if (Id != null) hashCode = hashCode * 59 + Id.GetHashCode();
                if (PuntoVenta != null) hashCode = hashCode * 59 + PuntoVenta.GetHashCode();
                if (FechaEvidencia != null) hashCode = hashCode * 59 + FechaEvidencia.GetHashCode();
                if (NumeroPedido != null) hashCode = hashCode * 59 + NumeroPedido.GetHashCode();
                if (NumeroEntrega != null) hashCode = hashCode * 59 + NumeroEntrega.GetHashCode();
                
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(InconsistenciaResponse left, InconsistenciaResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InconsistenciaResponse left, InconsistenciaResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
