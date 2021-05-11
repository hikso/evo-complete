/*
 * API de Pedidos
 *
 * API de administración de Pedidos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.PedidosApi
{
    /// <summary>
    /// Criterios por los que se filtrará la consulta
    /// </summary>
    [DataContract]
    public partial class FiltrarPedidoRequestFiltro : IEquatable<FiltrarPedidoRequestFiltro>
    {
        /// <summary>
        /// Fecha en la que se registra el pedido
        /// </summary>
        /// <value>Fecha en la que se registra el pedido</value>
        [DataMember(Name = "desde")]
        public string Desde { get; set; }

        /// <summary>
        /// Fecha en la que se registra el pedido
        /// </summary>
        /// <value>Fecha en la que se registra el pedido</value>
        [DataMember(Name = "hasta")]
        public string Hasta { get; set; }

        /// <summary>
        /// Id del estado del pedido
        /// </summary>
        /// <value>Id del estado del pedido</value>
        [DataMember(Name = "estado")]
        public string Estado { get; set; }

        /// <summary>
        /// Filtro por Planta Beneficio
        /// </summary>
        /// <value>Filtro por Planta Beneficio</value>
        [DataMember(Name = "plantaBeneficio")]
        public bool? PlantaBeneficio { get; set; }

        /// <summary>
        /// Filtro por Planta Derivados
        /// </summary>
        /// <value>Filtro por Planta Derivados</value>
        [DataMember(Name = "plantaDerivados")]
        public bool? PlantaDerivados { get; set; }


        /// <summary>
        /// Los pendientes son todos los NO cerrados
        /// </summary>
        /// <value>Los pendientes son todos los NO cerrados</value>
        [DataMember(Name = "pendientes")]
        public string Pendientes { get; set; }

        /// <summary>
        /// Filtro por numero de pedido
        /// </summary>
        /// <value>Filtro por numero de pedido</value>
        [DataMember(Name = "numeropedido")]
        public string Numeropedido { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FiltrarPedidoRequestFiltro {\n");
            sb.Append("  Desde: ").Append(Desde).Append("\n");
            sb.Append("  Hasta: ").Append(Hasta).Append("\n");
            sb.Append("  Estado: ").Append(Estado).Append("\n");          
            sb.Append("  Pendientes: ").Append(Pendientes).Append("\n");
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
            return obj.GetType() == GetType() && Equals((FiltrarPedidoRequestFiltro)obj);
        }

        /// <summary>
        /// Returns true if FiltrarPedidoRequestFiltro instances are equal
        /// </summary>
        /// <param name="other">Instance of FiltrarPedidoRequestFiltro to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FiltrarPedidoRequestFiltro other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Desde == other.Desde ||
                    Desde != null &&
                    Desde.Equals(other.Desde)
                ) &&
                (
                    Hasta == other.Hasta ||
                    Hasta != null &&
                    Hasta.Equals(other.Hasta)
                ) &&
                (
                    Estado == other.Estado &&
                    Estado.Equals(other.Estado)
                ) &&                
                (
                    Pendientes == other.Pendientes &&
                    Pendientes.Equals(other.Pendientes)
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
                if (Desde != null)
                    hashCode = hashCode * 59 + Desde.GetHashCode();
                if (Hasta != null)
                    hashCode = hashCode * 59 + Hasta.GetHashCode();
                hashCode = hashCode * 59 + Estado.GetHashCode();               
                hashCode = hashCode * 59 + Pendientes.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(FiltrarPedidoRequestFiltro left, FiltrarPedidoRequestFiltro right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FiltrarPedidoRequestFiltro left, FiltrarPedidoRequestFiltro right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
