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

namespace EVO_PV_Proxy.Models.PedidoApi
{ 
    /// <summary>
    /// Objeto que contiene el pedido
    /// </summary>
    [DataContract]
    public partial class ObtenerPedidoResponse : IEquatable<ObtenerPedidoResponse>
    { 
        /// <summary>
        /// Fecha del pedido
        /// </summary>
        /// <value>Fecha del pedido</value>
        [DataMember(Name="FechaPedido")]
        public DateTime FechaPedido { get; set; }

        /// <summary>
        /// Código del pedido
        /// </summary>
        /// <value>Código del pedido</value>
        [DataMember(Name="CodigoPedido")]
        public string CodigoPedido { get; set; }

        /// <summary>
        /// Código de la bodega tipo planta
        /// </summary>
        /// <value>Código de la bodega tipo planta</value>
        [DataMember(Name="SolicitudPara")]
        public string SolicitudPara { get; set; }

        /// <summary>
        /// Fecha entrega
        /// </summary>
        /// <value>Fecha entrega</value>
        [DataMember(Name="FechaEntrega")]
        public DateTime? FechaEntrega { get; set; }

        /// <summary>
        /// Estado Pedido Id
        /// </summary>
        /// <value>Estado Pedido Id</value>
        [DataMember(Name="EstadoPedidoId")]
        public int EstadoPedidoId { get; set; }

        /// <summary>
        /// Lista de detalles del Pedido
        /// </summary>
        /// <value>Lista de detalles del Pedido</value>
        [DataMember(Name="Detalles")]
        public List<ObtenerPedidoResponseDetalles> Detalles { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerPedidoResponse {\n");
            sb.Append("  FechaPedido: ").Append(FechaPedido).Append("\n");
            sb.Append("  CodigoPedido: ").Append(CodigoPedido).Append("\n");
            sb.Append("  SolicitudPara: ").Append(SolicitudPara).Append("\n");
            sb.Append("  FechaEntrega: ").Append(FechaEntrega).Append("\n");
            sb.Append("  EstadoPedidoId: ").Append(EstadoPedidoId).Append("\n");
            sb.Append("  Detalles: ").Append(Detalles).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerPedidoResponse)obj);
        }

        /// <summary>
        /// Returns true if ObtenerPedidoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerPedidoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerPedidoResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    FechaPedido == other.FechaPedido ||
                    FechaPedido != null &&
                    FechaPedido.Equals(other.FechaPedido)
                ) && 
                (
                    CodigoPedido == other.CodigoPedido ||
                    CodigoPedido != null &&
                    CodigoPedido.Equals(other.CodigoPedido)
                ) && 
                (
                    SolicitudPara == other.SolicitudPara ||
                    SolicitudPara != null &&
                    SolicitudPara.Equals(other.SolicitudPara)
                ) && 
                (
                    FechaEntrega == other.FechaEntrega ||
                    FechaEntrega != null &&
                    FechaEntrega.Equals(other.FechaEntrega)
                ) && 
                (
                    EstadoPedidoId == other.EstadoPedidoId &&
                    EstadoPedidoId.Equals(other.EstadoPedidoId)
                ) && 
                (
                    Detalles == other.Detalles ||
                    Detalles != null &&
                    Detalles.SequenceEqual(other.Detalles)
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
                    if (FechaPedido != null)
                    hashCode = hashCode * 59 + FechaPedido.GetHashCode();
                    if (CodigoPedido != null)
                    hashCode = hashCode * 59 + CodigoPedido.GetHashCode();
                    if (SolicitudPara != null)
                    hashCode = hashCode * 59 + SolicitudPara.GetHashCode();
                    if (FechaEntrega != null)
                    hashCode = hashCode * 59 + FechaEntrega.GetHashCode();                  
                    hashCode = hashCode * 59 + EstadoPedidoId.GetHashCode();
                    if (Detalles != null)
                    hashCode = hashCode * 59 + Detalles.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ObtenerPedidoResponse left, ObtenerPedidoResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerPedidoResponse left, ObtenerPedidoResponse right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
