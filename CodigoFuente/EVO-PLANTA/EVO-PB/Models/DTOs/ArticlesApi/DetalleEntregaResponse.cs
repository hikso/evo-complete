﻿/*
 * API de Artículos
 *
 * API de administración de Articulos 
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

namespace EVO_PB.Models.DTOs.ArticulosApi
{
    /// <summary>
    /// Representa un detalle de entrega en alistamiento
    /// </summary>
    [DataContract]
    public partial class DetalleEntregaResponse : IEquatable<DetalleEntregaResponse>
    {
        /// <summary>
        /// Representa el consecutivo del alistamiento
        /// </summary>
        /// <value>Representa el consecutivo del alistamiento</value>
        [DataMember(Name = "consecutivo")]
        public int? Consecutivo { get; set; }

        /// <summary>
        /// Representa la fecha del alistamiento
        /// </summary>
        /// <value>Representa la fecha del alistamiento</value>
        [DataMember(Name = "fecha")]
        public string Fecha { get; set; }

        /// <summary>
        /// Representa el muelle donde estará el vehiculo
        /// </summary>
        /// <value>Representa el muelle donde estará el vehiculo</value>
        [DataMember(Name = "muelle")]
        public string Muelle { get; set; }

        /// <summary>
        /// Representa el tipo de cliente
        /// </summary>
        /// <value>Representa el tipo de cliente</value>
        [DataMember(Name = "tipoCliente")]
        public string TipoCliente { get; set; }

        /// <summary>
        /// Representa el nombre del cliente
        /// </summary>
        /// <value>Representa el nombre del cliente</value>
        [DataMember(Name = "cliente")]
        public string Cliente { get; set; }

        /// <summary>
        /// Gets or Sets ArticulosResponse
        /// </summary>
        [DataMember(Name = "articulosResponse")]
        public List<ArticuloAlistamientoResponse> ArticulosResponse { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DetalleEntregaResponse {\n");
            sb.Append("  Consecutivo: ").Append(Consecutivo).Append("\n");
            sb.Append("  Fecha: ").Append(Fecha).Append("\n");
            sb.Append("  Muelle: ").Append(Muelle).Append("\n");
            sb.Append("  TipoCliente: ").Append(TipoCliente).Append("\n");
            sb.Append("  Cliente: ").Append(Cliente).Append("\n");
            sb.Append("  ArticulosResponse: ").Append(ArticulosResponse).Append("\n");
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
            return obj.GetType() == GetType() && Equals((DetalleEntregaResponse)obj);
        }

        /// <summary>
        /// Returns true if DetalleEntregaResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of DetalleEntregaResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DetalleEntregaResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Consecutivo == other.Consecutivo ||
                    Consecutivo != null &&
                    Consecutivo.Equals(other.Consecutivo)
                ) &&
                (
                    Fecha == other.Fecha ||
                    Fecha != null &&
                    Fecha.Equals(other.Fecha)
                ) &&
                (
                    Muelle == other.Muelle ||
                    Muelle != null &&
                    Muelle.Equals(other.Muelle)
                ) &&
                (
                    TipoCliente == other.TipoCliente ||
                    TipoCliente != null &&
                    TipoCliente.Equals(other.TipoCliente)
                ) &&
                (
                    Cliente == other.Cliente ||
                    Cliente != null &&
                    Cliente.Equals(other.Cliente)
                ) &&
                (
                    ArticulosResponse == other.ArticulosResponse ||
                    ArticulosResponse != null &&
                    ArticulosResponse.SequenceEqual(other.ArticulosResponse)
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
                if (Consecutivo != null)
                    hashCode = hashCode * 59 + Consecutivo.GetHashCode();
                if (Fecha != null)
                    hashCode = hashCode * 59 + Fecha.GetHashCode();
                if (Muelle != null)
                    hashCode = hashCode * 59 + Muelle.GetHashCode();
                if (TipoCliente != null)
                    hashCode = hashCode * 59 + TipoCliente.GetHashCode();
                if (Cliente != null)
                    hashCode = hashCode * 59 + Cliente.GetHashCode();
                if (ArticulosResponse != null)
                    hashCode = hashCode * 59 + ArticulosResponse.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(DetalleEntregaResponse left, DetalleEntregaResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DetalleEntregaResponse left, DetalleEntregaResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
