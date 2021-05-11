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

namespace EVO_WebApi.Models.PedidosApi
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ObtenerPedidoEnPlantaResponsePedidoDetallesRespuesta : IEquatable<ObtenerPedidoEnPlantaResponsePedidoDetallesRespuesta>
    {
        /// <summary>
        /// Detalle Pedido Id
        /// </summary>
        /// <value>Detalle Pedido Id</value>
        [DataMember(Name = "DetallePedidoId")]
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>
        [DataMember(Name = "Codigo")]
        public string Codigo { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>
        [DataMember(Name = "Nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Estado del artículo</value>
        [DataMember(Name = "Estado")]
        public string Estado { get; set; }

        /// <summary>
        /// Cantidad solicitada del articulo
        /// </summary>
        /// <value>Cantidad solicitada del articulo</value>
        [DataMember(Name = "CantidadSolicitada")]
        public decimal? CantidadSolicitada { get; set; }

        /// <summary>
        /// Unidad de medida del artículo
        /// </summary>
        /// <value>Unidad de medida del artículo</value>
        [DataMember(Name = "UnidadMedida")]
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Cantidad aprobada del artículo
        /// </summary>
        /// <value>Cantidad aprobada del artículo</value>
        [DataMember(Name = "CantidadAprobada")]
        public decimal? CantidadAprobada { get; set; }

        /// <summary>
        /// Stock disponible
        /// </summary>
        /// <value>Stock disponible</value>
        [DataMember(Name = "StockDisponible")]
        public decimal? StockDisponible { get; set; }

        /// <summary>
        /// Observación
        /// </summary>
        /// <value></value>      
        [DataMember(Name = "Observacion")]
        public string Observacion { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerPedidoEnPlantaResponsePedidoDetallesRespuesta {\n");
            sb.Append("  Codigo: ").Append(Codigo).Append("\n");
            sb.Append("  Nombre: ").Append(Nombre).Append("\n");
            sb.Append("  Estado: ").Append(Estado).Append("\n");
            sb.Append("  CantidadSolicitada: ").Append(CantidadSolicitada).Append("\n");
            sb.Append("  UnidadMedida: ").Append(UnidadMedida).Append("\n");
            sb.Append("  CantidadAprobada: ").Append(CantidadAprobada).Append("\n");
            sb.Append("  StockDisponible: ").Append(StockDisponible).Append("\n");      
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
            return obj.GetType() == GetType() && Equals((ObtenerPedidoEnPlantaResponsePedidoDetallesRespuesta)obj);
        }

        /// <summary>
        /// Returns true if ObtenerPedidoEnPlantaResponsePedidoDetallesRespuesta instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerPedidoEnPlantaResponsePedidoDetallesRespuesta to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerPedidoEnPlantaResponsePedidoDetallesRespuesta other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Codigo == other.Codigo ||
                    Codigo != null &&
                    Codigo.Equals(other.Codigo)
                ) &&
                (
                    Nombre == other.Nombre ||
                    Nombre != null &&
                    Nombre.Equals(other.Nombre)
                ) &&
                (
                    Estado == other.Estado ||
                    Estado != null &&
                    Estado.Equals(other.Estado)
                ) &&
                (
                    CantidadSolicitada == other.CantidadSolicitada ||
                    CantidadSolicitada != null &&
                    CantidadSolicitada.Equals(other.CantidadSolicitada)
                ) &&
                (
                    UnidadMedida == other.UnidadMedida ||
                    UnidadMedida != null &&
                    UnidadMedida.Equals(other.UnidadMedida)
                ) &&
                (
                    CantidadAprobada == other.CantidadAprobada ||
                    CantidadAprobada != null &&
                    CantidadAprobada.Equals(other.CantidadAprobada)
                ) &&
                (
                    StockDisponible == other.StockDisponible ||
                    StockDisponible != null &&
                    StockDisponible.Equals(other.StockDisponible)
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
                if (Codigo != null)
                    hashCode = hashCode * 59 + Codigo.GetHashCode();
                if (Nombre != null)
                    hashCode = hashCode * 59 + Nombre.GetHashCode();
                if (Estado != null)
                    hashCode = hashCode * 59 + Estado.GetHashCode();
                if (CantidadSolicitada != null)
                    hashCode = hashCode * 59 + CantidadSolicitada.GetHashCode();
                if (UnidadMedida != null)
                    hashCode = hashCode * 59 + UnidadMedida.GetHashCode();
                if (CantidadAprobada != null)
                    hashCode = hashCode * 59 + CantidadAprobada.GetHashCode();
                if (StockDisponible != null)
                    hashCode = hashCode * 59 + StockDisponible.GetHashCode();              
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ObtenerPedidoEnPlantaResponsePedidoDetallesRespuesta left, ObtenerPedidoEnPlantaResponsePedidoDetallesRespuesta right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerPedidoEnPlantaResponsePedidoDetallesRespuesta left, ObtenerPedidoEnPlantaResponsePedidoDetallesRespuesta right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}