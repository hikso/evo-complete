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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.PedidosApi
{
    /// <summary>
    /// Pedido tipo compra a gestionar
    /// </summary>
    [DataContract]
    public partial class PedidoCompraGestionResponse : IEquatable<PedidoCompraGestionResponse>
    {
        /// <summary>
        /// Número pedido
        /// </summary>
        /// <value>Número pedido</value>
        [DataMember(Name = "numeroPedido")]
        public string NumeroPedido { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>
        [DataMember(Name = "cliente")]
        public string Cliente { get; set; }

        /// <summary>
        /// Fecha limite sugerida
        /// </summary>
        /// <value>Fecha limite sugerida</value>
        [DataMember(Name = "fechaLimiteSugerida")]
        public string FechaLimiteSugerida { get; set; }

        /// <summary>
        /// Fecha de solicitud
        /// </summary>
        /// <value>Fecha de solicitud</value>
        [DataMember(Name = "fechaSolicitud")]
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Fecha de la gestión de compra
        /// </summary>
        /// <value>Fecha de la gestión de compra</value>
        [DataMember(Name = "fechaGestionCompra")]
        public string FechaGestionCompra { get; set; }

        /// <summary>
        /// Nombre del usuario que realizó el pedido
        /// </summary>
        /// <value>Nombre del usuario que realizó el pedido</value>
        [DataMember(Name = "usuarioPedido")]
        public string UsuarioPedido { get; set; }

        /// <summary>
        /// Nombre del estado del pedido
        /// </summary>
        /// <value>Abierto</value>
        [DataMember(Name = "nombreEstadoPedido")]
        public string NombreEstadoPedido { get; set; }

        /// <summary>
        /// Artículos del pedido
        /// </summary>
        /// <value>Artículos del pedido</value>
        [DataMember(Name = "articulos")]
        public List<ArticuloCompraResponse> Articulos { get; set; }

        /// <summary>
        /// Acciones de compras asociadas a los artículos del pedido
        /// </summary>
        /// <value>Acciones de compras asociadas a los artículos del pedido</value>
        [DataMember(Name = "acciones")]
        public List<AccionCompraResponse> Acciones { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PedidoCompraGestionResponse {\n");
            sb.Append("  NumeroPedido: ").Append(NumeroPedido).Append("\n");
            sb.Append("  Cliente: ").Append(Cliente).Append("\n");
            sb.Append("  FechaLimiteSugerida: ").Append(FechaLimiteSugerida).Append("\n");
            sb.Append("  FechaSolicitud: ").Append(FechaSolicitud).Append("\n");
            sb.Append("  FechaGestionCompra: ").Append(FechaGestionCompra).Append("\n");
            sb.Append("  UsuarioPedido: ").Append(UsuarioPedido).Append("\n");
            sb.Append("  Articulos: ").Append(Articulos).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PedidoCompraGestionResponse)obj);
        }

        /// <summary>
        /// Returns true if PedidoCompraGestionResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of PedidoCompraGestionResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PedidoCompraGestionResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    NumeroPedido == other.NumeroPedido ||
                    NumeroPedido != null &&
                    NumeroPedido.Equals(other.NumeroPedido)
                ) &&
                (
                    Cliente == other.Cliente ||
                    Cliente != null &&
                    Cliente.Equals(other.Cliente)
                ) &&
                (
                    FechaLimiteSugerida == other.FechaLimiteSugerida ||
                    FechaLimiteSugerida != null &&
                    FechaLimiteSugerida.Equals(other.FechaLimiteSugerida)
                ) &&
                (
                    FechaSolicitud == other.FechaSolicitud ||
                    FechaSolicitud != null &&
                    FechaSolicitud.Equals(other.FechaSolicitud)
                ) &&
                (
                    FechaGestionCompra == other.FechaGestionCompra ||
                    FechaGestionCompra != null &&
                    FechaGestionCompra.Equals(other.FechaGestionCompra)
                ) &&
                (
                    UsuarioPedido == other.UsuarioPedido ||
                    UsuarioPedido != null &&
                    UsuarioPedido.Equals(other.UsuarioPedido)
                ) &&
                (
                    Articulos == other.Articulos ||
                    Articulos != null &&
                    Articulos.SequenceEqual(other.Articulos)
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
                if (NumeroPedido != null)
                    hashCode = hashCode * 59 + NumeroPedido.GetHashCode();
                if (Cliente != null)
                    hashCode = hashCode * 59 + Cliente.GetHashCode();
                if (FechaLimiteSugerida != null)
                    hashCode = hashCode * 59 + FechaLimiteSugerida.GetHashCode();
                if (FechaSolicitud != null)
                    hashCode = hashCode * 59 + FechaSolicitud.GetHashCode();
                if (FechaGestionCompra != null)
                    hashCode = hashCode * 59 + FechaGestionCompra.GetHashCode();
                if (UsuarioPedido != null)
                    hashCode = hashCode * 59 + UsuarioPedido.GetHashCode();
                if (Articulos != null)
                    hashCode = hashCode * 59 + Articulos.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(PedidoCompraGestionResponse left, PedidoCompraGestionResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PedidoCompraGestionResponse left, PedidoCompraGestionResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
