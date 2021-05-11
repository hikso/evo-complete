﻿/*
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
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV.Models.OrderListApi
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class EditarPedidoRequestArticulos : IEquatable<EditarPedidoRequestArticulos>
    {
        /// <summary>
        /// Id del detalle del pedido
        /// </summary>
        /// <value>1</value>
        [DataMember(Name = "detallePedidoId")]
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Id del estado del pedido
        /// </summary>
        /// <value>Id del estado del pedido</value>
        [DataMember(Name = "estadoArticuloId")]
        public int EstadoArticuloId { get; set; }

        /// <summary>
        /// Cantidad del artículo solicitada
        /// </summary>
        /// <value>Cantidad del artículo solicitada</value>
        [Required]
        [DataMember(Name = "cantidad")]
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Id del empaque
        /// </summary>
        /// <value>Id del empaque</value>
        [Required]
        [DataMember(Name = "empaqueId")]
        public int EmpaqueId { get; set; }

        /// <summary>
        /// Observacion
        /// </summary>
        /// <value>Observacion</value>       
        [DataMember(Name = "observacion")]
        public string Observacion { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EditarPedidoRequestArticulos {\n");
            sb.Append("  DetallePedidoId: ").Append(DetallePedidoId).Append("\n");
            sb.Append("  EstadoArticuloId: ").Append(EstadoArticuloId).Append("\n");
            sb.Append("  Cantidad: ").Append(Cantidad).Append("\n");
            sb.Append("  EmpaqueId: ").Append(EmpaqueId).Append("\n");
            sb.Append("  Observacion: ").Append(Observacion).Append("\n");
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
            return obj.GetType() == GetType() && Equals((EditarPedidoRequestArticulos)obj);
        }

        /// <summary>
        /// Returns true if EditarPedidoRequestArticulos instances are equal
        /// </summary>
        /// <param name="other">Instance of EditarPedidoRequestArticulos to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EditarPedidoRequestArticulos other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    DetallePedidoId == other.DetallePedidoId ||
                    DetallePedidoId != null &&
                    DetallePedidoId.Equals(other.DetallePedidoId)
                ) &&
                (
                    EstadoArticuloId == other.EstadoArticuloId ||
                    EstadoArticuloId != null &&
                    EstadoArticuloId.Equals(other.EstadoArticuloId)
                ) &&
                (
                    Cantidad == other.Cantidad ||
                    Cantidad != null &&
                    Cantidad.Equals(other.Cantidad)
                ) &&
                (
                    EmpaqueId == other.EmpaqueId ||
                    EmpaqueId != null &&
                    EmpaqueId.Equals(other.EmpaqueId)
                ) &&
                (
                    Observacion == other.Observacion ||
                    Observacion != null &&
                    Observacion.Equals(other.Observacion)
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
                if (DetallePedidoId != null)
                    hashCode = hashCode * 59 + DetallePedidoId.GetHashCode();
                if (EstadoArticuloId != null)
                    hashCode = hashCode * 59 + EstadoArticuloId.GetHashCode();
                if (Cantidad != null)
                    hashCode = hashCode * 59 + Cantidad.GetHashCode();
                if (EmpaqueId != null)
                    hashCode = hashCode * 59 + EmpaqueId.GetHashCode();
                if (Observacion != null)
                    hashCode = hashCode * 59 + Observacion.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(EditarPedidoRequestArticulos left, EditarPedidoRequestArticulos right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EditarPedidoRequestArticulos left, EditarPedidoRequestArticulos right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
