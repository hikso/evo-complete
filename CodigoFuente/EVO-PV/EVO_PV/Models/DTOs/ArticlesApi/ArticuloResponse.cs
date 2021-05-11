/*
 * API de Artículos
 *
 * API de administración de Articulos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV.Models.DTOs.ArticlesApi
{
    /// <summary>
    /// Artículo encontrado
    /// </summary>
    [DataContract]
    public partial class ArticuloResponse : IEquatable<ArticuloResponse>
    {
        /// <summary>
        /// Codigo de el artículo
        /// </summary>
        /// <value>Codigo de el artículo</value>
        [DataMember(Name = "codigoArticulo")]
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Nombre de el producto
        /// </summary>
        /// <value>Nombre de el producto</value>
        [DataMember(Name = "NombreArticulo")]
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Stock de el producto en bodega
        /// </summary>
        /// <value>Stock de el producto en bodega</value>
        [DataMember(Name = "stock")]
        public string Stock { get; set; }

        /// <summary>
        /// Stock mínimo que se debe tener de el producto en bodega
        /// </summary>
        /// <value>Stock mínimo que se debe tener de el producto en bodega</value>
        [DataMember(Name = "minimo")]
        public string Minimo { get; set; }

        /// <summary>
        /// Stock máximo que se debe tener de el producto en bodega
        /// </summary>
        /// <value>Stock máximo que se debe tener de el producto en bodega</value>
        [DataMember(Name = "maximo")]
        public string Maximo { get; set; }

        /// <summary>
        /// Unidad de medida 
        /// </summary>
        /// <value> Unidad de medida </value>
        [DataMember(Name = "unidadMedida")]
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Pedido Sugerido
        /// </summary>
        /// <value> </value>
        [DataMember(Name = "pedidoSugerido")]
        public string PedidoSugerido { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ArticuloResponse {\n");
            sb.Append("  CodigoArticulo: ").Append(CodigoArticulo).Append("\n");
            sb.Append("  NombreArticulo: ").Append(NombreArticulo).Append("\n");
            sb.Append("  Stock: ").Append(Stock).Append("\n");
            sb.Append("  Minimo: ").Append(Minimo).Append("\n");
            sb.Append("  Maximo: ").Append(Maximo).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ArticuloResponse)obj);
        }

        /// <summary>
        /// Returns true if ArticuloResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ArticuloResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ArticuloResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    CodigoArticulo == other.CodigoArticulo ||
                    CodigoArticulo != null &&
                    CodigoArticulo.Equals(other.CodigoArticulo)
                ) &&
                (
                    NombreArticulo == other.NombreArticulo ||
                    NombreArticulo != null &&
                    NombreArticulo.Equals(other.NombreArticulo)
                ) &&
                (
                    Stock == other.Stock ||
                    Stock != null &&
                    Stock.Equals(other.Stock)
                ) &&
                (
                    Minimo == other.Minimo ||
                    Minimo != null &&
                    Minimo.Equals(other.Minimo)
                ) &&
                (
                    Maximo == other.Maximo ||
                    Maximo != null &&
                    Maximo.Equals(other.Maximo)
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
                if (CodigoArticulo != null)
                    hashCode = hashCode * 59 + CodigoArticulo.GetHashCode();
                if (NombreArticulo != null)
                    hashCode = hashCode * 59 + NombreArticulo.GetHashCode();
                if (Stock != null)
                    hashCode = hashCode * 59 + Stock.GetHashCode();
                if (Minimo != null)
                    hashCode = hashCode * 59 + Minimo.GetHashCode();
                if (Maximo != null)
                    hashCode = hashCode * 59 + Maximo.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ArticuloResponse left, ArticuloResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArticuloResponse left, ArticuloResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
