/*
 * API de Artículos
 *
 * API de administración de Articulos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jegiraldo@porcicarnes.com.co
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

namespace EVO_PV_Proxy.Models.ArticulosApi
{ 
    /// <summary>
    /// Criterios por los que se filtrará la consulta
    /// </summary>
    [DataContract]
    public partial class FiltrarArticuloRequestFiltro : IEquatable<FiltrarArticuloRequestFiltro>
    { 
        /// <summary>
        /// Filtro por Codigo de Artículo
        /// </summary>
        /// <value>Filtro por Codigo de Artículo</value>
        [DataMember(Name="codigoArticulo")]
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Filtro por Nombre de Artículo
        /// </summary>
        /// <value>Filtro por Nombre de Artículo</value>
        [DataMember(Name="nombreArticulo")]
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Filtro por Unidad de Medida
        /// </summary>
        /// <value>Filtro por Unidad de Medida</value>
        [DataMember(Name="unidadMedida")]
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Filtro por el stock del Artículo
        /// </summary>
        /// <value>Filtro por el stock del Artículo</value>
        [DataMember(Name="stock")]
        public string Stock { get; set; }

        /// <summary>
        /// Filtro por cantidad mínima de stock
        /// </summary>
        /// <value>Filtro por cantidad mínima de stock</value>
        [DataMember(Name="minimo")]
        public string Minimo { get; set; }

        /// <summary>
        /// Filtro por cantidad máxima de stock
        /// </summary>
        /// <value>Filtro por cantidad máxima de stock</value>
        [DataMember(Name="maximo")]
        public string Maximo { get; set; }

        /// <summary>
        /// Indica el código de la bodega
        /// </summary>
        /// <value>Indica el código de la bodega</value>
        [DataMember(Name="whsCode")]
        public string WhsCode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FiltrarArticuloRequestFiltro {\n");
            sb.Append("  CodigoArticulo: ").Append(CodigoArticulo).Append("\n");
            sb.Append("  NombreArticulo: ").Append(NombreArticulo).Append("\n");
            sb.Append("  UnidadMedida: ").Append(UnidadMedida).Append("\n");
            sb.Append("  Stock: ").Append(Stock).Append("\n");
            sb.Append("  Minimo: ").Append(Minimo).Append("\n");
            sb.Append("  Maximo: ").Append(Maximo).Append("\n");
            sb.Append("  WhsCode: ").Append(WhsCode).Append("\n");
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
            return obj.GetType() == GetType() && Equals((FiltrarArticuloRequestFiltro)obj);
        }

        /// <summary>
        /// Returns true if FiltrarArticuloRequestFiltro instances are equal
        /// </summary>
        /// <param name="other">Instance of FiltrarArticuloRequestFiltro to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FiltrarArticuloRequestFiltro other)
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
                    UnidadMedida == other.UnidadMedida ||
                    UnidadMedida != null &&
                    UnidadMedida.Equals(other.UnidadMedida)
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
                ) && 
                (
                    WhsCode == other.WhsCode ||
                    WhsCode != null &&
                    WhsCode.Equals(other.WhsCode)
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
                    if (UnidadMedida != null)
                    hashCode = hashCode * 59 + UnidadMedida.GetHashCode();
                    if (Stock != null)
                    hashCode = hashCode * 59 + Stock.GetHashCode();
                    if (Minimo != null)
                    hashCode = hashCode * 59 + Minimo.GetHashCode();
                    if (Maximo != null)
                    hashCode = hashCode * 59 + Maximo.GetHashCode();
                    if (WhsCode != null)
                    hashCode = hashCode * 59 + WhsCode.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(FiltrarArticuloRequestFiltro left, FiltrarArticuloRequestFiltro right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FiltrarArticuloRequestFiltro left, FiltrarArticuloRequestFiltro right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
