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
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Models.PedidosApi
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ObtenerTodosPedidosDistribucionResponseRegistros : IEquatable<ObtenerTodosPedidosDistribucionResponseRegistros>
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>
        [DataMember(Name = "pedidoId")]
        public int PedidoId { get; set; }

        /// <summary>
        /// Código del pedido
        /// </summary>
        /// <value>Código del pedido</value>
        [DataMember(Name = "codigoPedido")]
        public string CodigoPedido { get; set; }

        /// <summary>
        /// Orden de compra (para clientes externos)
        /// </summary>
        /// <value>Orden de compra (para clientes externos)</value>
        [DataMember(Name = "ordenCompra")]
        public string OrdenCompra { get; set; }

        /// <summary>
        /// Fecha en la que se registra el pedido
        /// </summary>
        /// <value>Fecha en la que se registra el pedido</value>
        [DataMember(Name = "fechaSolicitud")]
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Estado el pedido
        /// </summary>
        /// <value>Estado el pedido</value>
        [DataMember(Name = "estado")]
        public string Estado { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>
        [DataMember(Name = "cliente")]
        public string Cliente { get; set; }

        /// <summary>
        /// Cantidad máxima de entregas
        /// </summary>
        /// <value>Cantidad máxima de entregas</value>
        [DataMember(Name = "entregas")]
        public string Entregas { get; set; }       

        /// <summary>
        /// Indica la zona del punto de venta o cliente externo
        /// </summary>
        /// <value>Indica la zona del punto de venta o cliente externo</value>
        [DataMember(Name = "zona")]
        public string Zona { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerTodosPedidosDistribucionResponseRegistros {\n");
            sb.Append("  PedidoId: ").Append(PedidoId).Append("\n");
            sb.Append("  CodigoPedido: ").Append(CodigoPedido).Append("\n");
            sb.Append("  OrdenCompra: ").Append(OrdenCompra).Append("\n");
            sb.Append("  FechaSolicitud: ").Append(FechaSolicitud).Append("\n");
            sb.Append("  Estado: ").Append(Estado).Append("\n");
            sb.Append("  Cliente: ").Append(Cliente).Append("\n");
            sb.Append("  Entregas: ").Append(Entregas).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerTodosPedidosDistribucionResponseRegistros)obj);
        }

        /// <summary>
        /// Returns true if ObtenerTodosPedidosDistribucionResponseRegistros instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerTodosPedidosDistribucionResponseRegistros to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerTodosPedidosDistribucionResponseRegistros other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    PedidoId == other.PedidoId &&
                    PedidoId.Equals(other.PedidoId)
                ) &&
                (
                    CodigoPedido == other.CodigoPedido ||
                    CodigoPedido != null &&
                    CodigoPedido.Equals(other.CodigoPedido)
                ) &&
                (
                    OrdenCompra == other.OrdenCompra ||
                    OrdenCompra != null &&
                    OrdenCompra.Equals(other.OrdenCompra)
                ) &&
                (
                    FechaSolicitud == other.FechaSolicitud ||
                    FechaSolicitud != null &&
                    FechaSolicitud.Equals(other.FechaSolicitud)
                ) &&
                (
                    Estado == other.Estado ||
                    Estado != null &&
                    Estado.Equals(other.Estado)
                ) &&
                (
                    Cliente == other.Cliente ||
                    Cliente != null &&
                    Cliente.Equals(other.Cliente)
                ) &&
                (
                    Entregas == other.Entregas ||
                    Entregas != null &&
                    Entregas.Equals(other.Entregas)
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
                if (CodigoPedido != null)
                    hashCode = hashCode * 59 + CodigoPedido.GetHashCode();
                if (OrdenCompra != null)
                    hashCode = hashCode * 59 + OrdenCompra.GetHashCode();
                if (FechaSolicitud != null)
                    hashCode = hashCode * 59 + FechaSolicitud.GetHashCode();
                if (Estado != null)
                    hashCode = hashCode * 59 + Estado.GetHashCode();
                if (Cliente != null)
                    hashCode = hashCode * 59 + Cliente.GetHashCode();
                if (Entregas != null)
                    hashCode = hashCode * 59 + Entregas.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ObtenerTodosPedidosDistribucionResponseRegistros left, ObtenerTodosPedidosDistribucionResponseRegistros right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerTodosPedidosDistribucionResponseRegistros left, ObtenerTodosPedidosDistribucionResponseRegistros right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
