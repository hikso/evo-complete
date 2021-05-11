/*
 * API de Artículos
 *
 * API de administración de Articulos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jegiraldo@porcicarnes.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV_WebApi.Models.ArticulosApi
{
    /// <summary>
    /// Representa un artículo
    /// </summary>
    [DataContract]
    public partial class ArticuloUnicoResponse : IEquatable<ArticuloUnicoResponse>
    {
        /// <summary>
        /// Representa el código del artículo
        /// </summary>
        /// <value>Representa el código del artículo</value>
        [DataMember(Name = "itemCode")]
        public string ItemCode { get; set; }

        /// <summary>
        /// Representa el nombre del artículo
        /// </summary>
        /// <value>Representa el nombre del artículo</value>
        [DataMember(Name = "itemName")]
        public string ItemName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ArticuloUnicoResponse {\n");
            sb.Append("  ItemCode: ").Append(ItemCode).Append("\n");
            sb.Append("  ItemName: ").Append(ItemName).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ArticuloUnicoResponse)obj);
        }

        /// <summary>
        /// Returns true if ArticuloUnicoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ArticuloUnicoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ArticuloUnicoResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    ItemCode == other.ItemCode ||
                    ItemCode != null &&
                    ItemCode.Equals(other.ItemCode)
                ) &&
                (
                    ItemName == other.ItemName ||
                    ItemName != null &&
                    ItemName.Equals(other.ItemName)
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
                if (ItemCode != null)
                    hashCode = hashCode * 59 + ItemCode.GetHashCode();
                if (ItemName != null)
                    hashCode = hashCode * 59 + ItemName.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ArticuloUnicoResponse left, ArticuloUnicoResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArticuloUnicoResponse left, ArticuloUnicoResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
