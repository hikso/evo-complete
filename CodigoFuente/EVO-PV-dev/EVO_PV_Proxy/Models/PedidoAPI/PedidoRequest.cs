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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV_Proxy.Models.PedidoAPI
{
    /// <summary>
    /// Solicitud del pedido
    /// </summary>
    [DataContract]
    public partial class PedidoRequest : IEquatable<PedidoRequest>
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>
        [DataMember(Name = "PedidoId")]
        public int PedidoId { get; set; }

        /// <summary>
        /// Código de la bodega que genera el pedido
        /// </summary>
        /// <value>Código de la bodega que genera el pedido</value>
        [Required]
        [DataMember(Name = "WhsCode")]
        public string WhsCode { get; set; }

        /// <summary>
        /// Código de la bodega para donde va el pedido
        /// </summary>
        /// <value>Código de la bodega para donde va el pedido</value>
        [Required]
        [DataMember(Name = "SolicitudPara")]
        public string SolicitudPara { get; set; }

        /// <summary>
        /// Usuario del Usuario que generó el pedido
        /// </summary>
        /// <value>Usuario del Usuario que generó el pedido</value>
        [Required]
        [DataMember(Name = "Usuario")]
        public string Usuario { get; set; }

        /// <summary>
        /// Indica la fecha de entrega del pedido
        /// </summary>
        /// <value>Indica la fecha de entrega del pedido</value>
        [DataMember(Name = "FechaEntrega")]
        public DateTime? FechaEntrega { get; set; }

        /// <summary>
        /// Estado del pedido
        /// </summary>
        /// <value>Estado del pedido</value>
        [Required]
        [DataMember(Name = "EstadoPedido")]
        public string EstadoPedido { get; set; }

        /// <summary>
        /// Id del tipo de solicitud
        /// </summary>
        /// <value>1</value>
        [Required]
        [DataMember(Name = "TipoSolicitudId")]
        public int TipoSolicitudId { get; set; }

        /// <summary>
        /// email de la bodega
        /// </summary>
        /// <value>1</value>
        [Required]
        [DataMember(Name = "EmailBodega")]
        public string EmailBodega { get; set; }

        /// <summary>
        /// email de la bodega
        /// </summary>
        /// <value>1</value>
        [Required]
        [DataMember(Name = "NombreUsuario")]
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Detalles del Pedido
        /// </summary>
        /// <value>Detalles del Pedido</value>
        [DataMember(Name = "detalles")]
        public List<PedidoRequestDetalles> Detalles { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PedidoRequest {\n");
            sb.Append("  PedidoId: ").Append(PedidoId).Append("\n");
            sb.Append("  WhsCode: ").Append(WhsCode).Append("\n");
            sb.Append("  SolicitudPara: ").Append(SolicitudPara).Append("\n");
            sb.Append("  Usuario: ").Append(Usuario).Append("\n");
            sb.Append("  FechaEntrega: ").Append(FechaEntrega).Append("\n");
            sb.Append("  EstadoPedido: ").Append(EstadoPedido).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PedidoRequest)obj);
        }

        /// <summary>
        /// Returns true if PedidoRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of PedidoRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PedidoRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    PedidoId == other.PedidoId &&
                    PedidoId.Equals(other.PedidoId)
                ) &&
                (
                    WhsCode == other.WhsCode ||
                    WhsCode != null &&
                    WhsCode.Equals(other.WhsCode)
                ) &&
                (
                    SolicitudPara == other.SolicitudPara ||
                    SolicitudPara != null &&
                    SolicitudPara.Equals(other.SolicitudPara)
                ) &&
                (
                    Usuario == other.Usuario ||
                    Usuario != null &&
                    Usuario.Equals(other.Usuario)
                ) &&
                (
                    FechaEntrega == other.FechaEntrega ||
                    FechaEntrega != null &&
                    FechaEntrega.Equals(other.FechaEntrega)
                ) &&
                (
                    EstadoPedido == other.EstadoPedido ||
                    EstadoPedido != null &&
                    EstadoPedido.Equals(other.EstadoPedido)
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
                hashCode = hashCode * 59 + PedidoId.GetHashCode();
                if (WhsCode != null)
                    hashCode = hashCode * 59 + WhsCode.GetHashCode();
                if (SolicitudPara != null)
                    hashCode = hashCode * 59 + SolicitudPara.GetHashCode();
                if (Usuario != null)
                    hashCode = hashCode * 59 + Usuario.GetHashCode();
                if (FechaEntrega != null)
                    hashCode = hashCode * 59 + FechaEntrega.GetHashCode();
                if (EstadoPedido != null)
                    hashCode = hashCode * 59 + EstadoPedido.GetHashCode();
                if (Detalles != null)
                    hashCode = hashCode * 59 + Detalles.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(PedidoRequest left, PedidoRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PedidoRequest left, PedidoRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
