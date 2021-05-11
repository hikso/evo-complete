/*
 * API de Pesaje
 *
 * API de administración de Pesaje 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.PesajeApi
{
    /// <summary>
    /// Representa un pesaje
    /// </summary>
    [DataContract]
    public partial class PesajeRequest : IEquatable<PesajeRequest>
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>PT-1485</value>
        [DataMember(Name = "codigoArticulo")]
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Id de la entrega
        /// </summary>
        /// <value>Id de la entrega</value>
        [DataMember(Name = "entregaId")]
        public int EntregaId { get; set; }

        /// <summary>
        /// Id del detalle de la entrega
        /// </summary>
        /// <value>Id del detalle de la entrega</value>
        [DataMember(Name = "detalleEntregaId")]
        public int DetalleEntregaId { get; set; }

        /// <summary>
        /// Peso de la báscula
        /// </summary>
        /// <value>Peso de la báscula</value>
        [DataMember(Name = "pesoBascula")]
        public decimal PesoBascula { get; set; }

        /// <summary>
        /// Peso del artículo
        /// </summary>
        /// <value>Peso del artículo</value>
        [DataMember(Name = "pesoArticulo")]
        public decimal PesoArticulo { get; set; }

        /// <summary>
        /// Gets or Sets Contenedores
        /// </summary>
        [DataMember(Name = "contenedores")]
        public List<ContenedorRequest> Contenedores { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PesajeRequest {\n");
            sb.Append("  DetalleEntregaId: ").Append(DetalleEntregaId).Append("\n");
            sb.Append("  PesoBascula: ").Append(PesoBascula).Append("\n");
            sb.Append("  PesoArticulo: ").Append(PesoArticulo).Append("\n");
            sb.Append("  Contenedores: ").Append(Contenedores).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PesajeRequest)obj);
        }

        /// <summary>
        /// Returns true if PesajeRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of PesajeRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PesajeRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    DetalleEntregaId == other.DetalleEntregaId ||
                    DetalleEntregaId != null &&
                    DetalleEntregaId.Equals(other.DetalleEntregaId)
                ) &&
                (
                    PesoBascula == other.PesoBascula ||
                    PesoBascula != null &&
                    PesoBascula.Equals(other.PesoBascula)
                ) &&
                (
                    PesoArticulo == other.PesoArticulo ||
                    PesoArticulo != null &&
                    PesoArticulo.Equals(other.PesoArticulo)
                ) &&
                (
                    Contenedores == other.Contenedores ||
                    Contenedores != null &&
                    Contenedores.SequenceEqual(other.Contenedores)
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
                if (DetalleEntregaId != null)
                    hashCode = hashCode * 59 + DetalleEntregaId.GetHashCode();
                if (PesoBascula != null)
                    hashCode = hashCode * 59 + PesoBascula.GetHashCode();
                if (PesoArticulo != null)
                    hashCode = hashCode * 59 + PesoArticulo.GetHashCode();
                if (Contenedores != null)
                    hashCode = hashCode * 59 + Contenedores.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(PesajeRequest left, PesajeRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PesajeRequest left, PesajeRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
