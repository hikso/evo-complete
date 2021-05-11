﻿/*
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
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV.Models.PesajeApi
{
    /// <summary>
    /// Representa un pesaje
    /// </summary>
    [DataContract]
    public partial class CantidadRecibidaRequest : IEquatable<CantidadRecibidaRequest>
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>
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
        /// Cantidad recibida con unidad de medida por unidad
        /// </summary>
        /// <value>Cantidad recibida con unidad de medida por unidad</value>
        [DataMember(Name = "cantidadRecibida")]
        public decimal CantidadRecibida { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CantidadRecibidaRequest {\n");
            sb.Append("  EntregaId: ").Append(EntregaId).Append("\n");
            sb.Append("  DetalleEntregaId: ").Append(DetalleEntregaId).Append("\n");
            sb.Append("  CantidadRecibida: ").Append(CantidadRecibida).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CantidadRecibidaRequest)obj);
        }

        /// <summary>
        /// Returns true if CantidadRecibidaRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of CantidadRecibidaRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CantidadRecibidaRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    EntregaId == other.EntregaId ||
                    EntregaId != null &&
                    EntregaId.Equals(other.EntregaId)
                ) &&
                (
                    DetalleEntregaId == other.DetalleEntregaId ||
                    DetalleEntregaId != null &&
                    DetalleEntregaId.Equals(other.DetalleEntregaId)
                ) &&
                (
                    CantidadRecibida == other.CantidadRecibida ||
                    CantidadRecibida != null &&
                    CantidadRecibida.Equals(other.CantidadRecibida)
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
                if (EntregaId != null)
                    hashCode = hashCode * 59 + EntregaId.GetHashCode();
                if (DetalleEntregaId != null)
                    hashCode = hashCode * 59 + DetalleEntregaId.GetHashCode();
                if (CantidadRecibida != null)
                    hashCode = hashCode * 59 + CantidadRecibida.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(CantidadRecibidaRequest left, CantidadRecibidaRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CantidadRecibidaRequest left, CantidadRecibidaRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
