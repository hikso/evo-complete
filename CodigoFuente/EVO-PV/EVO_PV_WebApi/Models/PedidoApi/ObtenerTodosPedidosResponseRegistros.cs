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

namespace EVO_PV_WebApi.Models.PedidosApi
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ObtenerTodosPedidosResponseRegistros : IEquatable<ObtenerTodosPedidosResponseRegistros>
    { 
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>
        [DataMember(Name="PedidoId")]
        public int? PedidoId { get; set; }

        /// <summary>
        /// Código del pedido
        /// </summary>
        /// <value>Código del pedido</value>
        [DataMember(Name="codigoPedido")]
        public string CodigoPedido { get; set; }

        /// <summary>
        /// Fecha en la que se registra el pedido
        /// </summary>
        /// <value>Fecha en la que se registra el pedido</value>
        [DataMember(Name="fechaSolicitud")]
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Fecha en que se entrega el pedido
        /// </summary>
        /// <value>Fecha en que se entrega el pedido</value>
        [DataMember(Name="fechaEntrega")]
        public string FechaEntrega { get; set; }

        /// <summary>
        /// Estado el pedido
        /// </summary>
        /// <value>Estado el pedido</value>
        [DataMember(Name="estado")]
        public string Estado { get; set; }

        /// <summary>
        /// Nombre de la planta
        /// </summary>
        /// <value>Nombre de la planta</value>
        [DataMember(Name="planta")]
        public string Planta { get; set; }

        /// <summary>
        /// Días para la entrega del pedido
        /// </summary>
        /// <value>Días para la entrega del pedido</value>
        [DataMember(Name="diasEntrega")]
        public string DiasEntrega { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerTodosPedidosResponseRegistros {\n");
            sb.Append("  PedidoId: ").Append(PedidoId).Append("\n");
            sb.Append("  CodigoPedido: ").Append(CodigoPedido).Append("\n");
            sb.Append("  FechaSolicitud: ").Append(FechaSolicitud).Append("\n");
            sb.Append("  FechaEntrega: ").Append(FechaEntrega).Append("\n");
            sb.Append("  Estado: ").Append(Estado).Append("\n");
            sb.Append("  Planta: ").Append(Planta).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerTodosPedidosResponseRegistros)obj);
        }

        /// <summary>
        /// Returns true if ObtenerTodosPedidosResponseRegistros instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerTodosPedidosResponseRegistros to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerTodosPedidosResponseRegistros other)
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
                    CodigoPedido == other.CodigoPedido ||
                    CodigoPedido != null &&
                    CodigoPedido.Equals(other.CodigoPedido)
                ) && 
                (
                    FechaSolicitud == other.FechaSolicitud ||
                    FechaSolicitud != null &&
                    FechaSolicitud.Equals(other.FechaSolicitud)
                ) && 
                (
                    FechaEntrega == other.FechaEntrega ||
                    FechaEntrega != null &&
                    FechaEntrega.Equals(other.FechaEntrega)
                ) && 
                (
                    Estado == other.Estado ||
                    Estado != null &&
                    Estado.Equals(other.Estado)
                ) && 
                (
                    Planta == other.Planta ||
                    Planta != null &&
                    Planta.Equals(other.Planta)
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
                    if (CodigoPedido != null)
                    hashCode = hashCode * 59 + CodigoPedido.GetHashCode();
                    if (FechaSolicitud != null)
                    hashCode = hashCode * 59 + FechaSolicitud.GetHashCode();
                    if (FechaEntrega != null)
                    hashCode = hashCode * 59 + FechaEntrega.GetHashCode();
                    if (Estado != null)
                    hashCode = hashCode * 59 + Estado.GetHashCode();
                    if (Planta != null)
                    hashCode = hashCode * 59 + Planta.GetHashCode();
                    if (DiasEntrega != null)
                    hashCode = hashCode * 59 + DiasEntrega.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ObtenerTodosPedidosResponseRegistros left, ObtenerTodosPedidosResponseRegistros right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerTodosPedidosResponseRegistros left, ObtenerTodosPedidosResponseRegistros right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
