/*
 * API de Pedidos
 *
 * API de administración de Pedidos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace EVO_PV.Models.OrderListApi
{
    /// <summary>
    /// Indica la solicitud del pedido en estado borrador
    /// </summary>
    [DataContract]
    public partial class ObtenerSolicitudPedidoBorradorResponse : IEquatable<ObtenerSolicitudPedidoBorradorResponse>
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>
        [DataMember(Name = "PedidoId")]
        public int? PedidoId { get; set; }

        /// <summary>
        /// Fecha de la solicitud
        /// </summary>
        /// <value>Fecha de la solicitud</value>
        [DataMember(Name = "FechaSolicitud")]
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Fecha limite de la solicitud
        /// </summary>
        /// <value>Fecha limite de la solicitud</value>
        [DataMember(Name = "FechaLimiteSolicitud")]
        public string FechaLimiteSolicitud { get; set; }

        /// <summary>
        /// Estado de la solicitud
        /// </summary>
        /// <value>Estado de la solicitud</value>
        [DataMember(Name = "EstadoPedido")]
        public string EstadoPedido { get; set; }

        /// <summary>
        /// Quien recibe la solicitud
        /// </summary>
        /// <value>Quien recibe la socilicitud</value>
        [DataMember(Name = "SolicitudA")]
        public string SolicitudA { get; set; }

        /// <summary>
        /// Días para la entrega
        /// </summary>
        /// <value>Días para la entrega</value>
        [DataMember(Name = "DiasEntrega")]
        public string DiasEntrega { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerSolicitudPedidoBorradorResponse {\n");
            sb.Append("  PedidoId: ").Append(PedidoId).Append("\n");
            sb.Append("  FechaSolicitud: ").Append(FechaSolicitud).Append("\n");
            sb.Append("  FechaLimiteSolicitud: ").Append(FechaLimiteSolicitud).Append("\n");
            sb.Append("  EstadoPedido: ").Append(EstadoPedido).Append("\n");
            sb.Append("  SolicitudA: ").Append(SolicitudA).Append("\n");
            sb.Append("  DiasEntrega: ").Append(DiasEntrega).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerSolicitudPedidoBorradorResponse)obj);
        }

        /// <summary>
        /// Returns true if ObtenerSolicitudPedidoBorradorResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerSolicitudPedidoBorradorResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerSolicitudPedidoBorradorResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    PedidoId == other.PedidoId ||
                    PedidoId != null &&
                    PedidoId.Equals(other.PedidoId)
                ) &&
                (
                    FechaSolicitud == other.FechaSolicitud ||
                    FechaSolicitud != null &&
                    FechaSolicitud.Equals(other.FechaSolicitud)
                ) &&
                (
                    FechaLimiteSolicitud == other.FechaLimiteSolicitud ||
                    FechaLimiteSolicitud != null &&
                    FechaLimiteSolicitud.Equals(other.FechaLimiteSolicitud)
                ) &&
                (
                    EstadoPedido == other.EstadoPedido ||
                    EstadoPedido != null &&
                    EstadoPedido.Equals(other.EstadoPedido)
                ) &&
                (
                    SolicitudA == other.SolicitudA ||
                    SolicitudA != null &&
                    SolicitudA.Equals(other.SolicitudA)
                ) &&
                (
                    DiasEntrega == other.DiasEntrega ||
                    DiasEntrega != null &&
                    DiasEntrega.Equals(other.DiasEntrega)
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
                if (PedidoId != null)
                    hashCode = hashCode * 59 + PedidoId.GetHashCode();
                if (FechaSolicitud != null)
                    hashCode = hashCode * 59 + FechaSolicitud.GetHashCode();
                if (FechaLimiteSolicitud != null)
                    hashCode = hashCode * 59 + FechaLimiteSolicitud.GetHashCode();
                if (EstadoPedido != null)
                    hashCode = hashCode * 59 + EstadoPedido.GetHashCode();
                if (SolicitudA != null)
                    hashCode = hashCode * 59 + SolicitudA.GetHashCode();
                if (DiasEntrega != null)
                    hashCode = hashCode * 59 + DiasEntrega.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ObtenerSolicitudPedidoBorradorResponse left, ObtenerSolicitudPedidoBorradorResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerSolicitudPedidoBorradorResponse left, ObtenerSolicitudPedidoBorradorResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
