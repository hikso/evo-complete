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
    /// Objeto que petición para actualizar una entrega
    /// </summary>
    [DataContract]
    public partial class EntregaRequest : IEquatable<EntregaRequest>
    {
        /// <summary>
        /// Id de la entrega
        /// </summary>
        /// <value>Id de la entrega</value>
        [DataMember(Name = "EntregaId")]
        public int EntregaId { get; set; }

        /// <summary>
        /// Fecha de entrega
        /// </summary>
        /// <value>Fecha de entrega</value>
        [DataMember(Name = "FechaEntrega")]
        public string FechaEntrega { get; set; }
        ///TODO: corregir en el .yaml
        /// <summary>
        /// Hora entrega
        /// </summary>
        /// <value>Código del pedido</value>
        [DataMember(Name = "HoraEntrega")]
        public string HoraEntrega { get; set; }

        /// <summary>
        /// Id del tipo de vehículo
        /// </summary>
        /// <value>4</value>
        [DataMember(Name = "TipoVehiculoId")]
        public int TipoVehiculoId { get; set; }

        /// <summary>
        /// Lista artículos de la entrega a actualizar
        /// </summary>
        /// <value>Lista artículos de la entrega a actualizar</value>
        [DataMember(Name = "Articulos")]
        public List<EntregaRequestArticulos> Articulos { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EntregaRequest {\n");
            sb.Append("  EntregaId: ").Append(EntregaId).Append("\n");
            sb.Append("  FechaEntrega: ").Append(FechaEntrega).Append("\n");
            sb.Append("  HoraEntrega: ").Append(HoraEntrega).Append("\n");
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
            return obj.GetType() == GetType() && Equals((EntregaRequest)obj);
        }

        /// <summary>
        /// Returns true if EntregaRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of EntregaRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EntregaRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    EntregaId == other.EntregaId ||
                    EntregaId != null &&
                    EntregaId.Equals(other.EntregaId)
                ) &&
                (
                    FechaEntrega == other.FechaEntrega ||
                    FechaEntrega != null &&
                    FechaEntrega.Equals(other.FechaEntrega)
                ) &&
                (
                    HoraEntrega == other.HoraEntrega ||
                    HoraEntrega != null &&
                    HoraEntrega.Equals(other.HoraEntrega)
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
                if (EntregaId != null)
                    hashCode = hashCode * 59 + EntregaId.GetHashCode();
                if (FechaEntrega != null)
                    hashCode = hashCode * 59 + FechaEntrega.GetHashCode();
                if (HoraEntrega != null)
                    hashCode = hashCode * 59 + HoraEntrega.GetHashCode();
                if (Articulos != null)
                    hashCode = hashCode * 59 + Articulos.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(EntregaRequest left, EntregaRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EntregaRequest left, EntregaRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
