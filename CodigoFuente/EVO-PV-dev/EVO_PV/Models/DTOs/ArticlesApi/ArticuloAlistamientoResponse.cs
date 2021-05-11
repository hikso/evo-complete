﻿/*
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
    /// Artículo en alistamiento
    /// </summary>
    [DataContract]
    public partial class ArticuloAlistamientoResponse : IEquatable<ArticuloAlistamientoResponse>
    {
        /// <summary>
        /// Id del detalle entrega
        /// </summary>
        /// <value>5</value>
        [DataMember(Name = "detalleEntregaId")]
        public int DetalleEntregaId { get; set; }

        /// <summary>
        /// Código de el artículo
        /// </summary>
        /// <value>Código de el artículo</value>
        [DataMember(Name = "codigoArticulo")]
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Nombre de el producto
        /// </summary>
        /// <value>Nombre de el producto</value>
        [DataMember(Name = "nombreArticulo")]
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Estado del artículo</value>
        [DataMember(Name = "estado")]
        public string Estado { get; set; }

        /// <summary>
        /// Cantidad de entrega del artículo
        /// </summary>
        /// <value>Cantidad de entrega del artículo</value>
        [DataMember(Name = "cantidadEntrega")]
        public decimal CantidadEntrega { get; set; }

        /// <summary>
        /// Cantidad de pendiente del artículo
        /// </summary>
        /// <value>Cantidad de pendiente del artículo</value>
        [DataMember(Name = "cantidadPendiente")]
        public decimal CantidadPendiente { get; set; }

        /// <summary>
        /// Unidad de medida del artículo
        /// </summary>
        /// <value>Unidad de medida del artículo</value>
        [DataMember(Name = "unidadMedida")]
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ArticuloAlistamientoResponse {\n");
            sb.Append("  CodigoArticulo: ").Append(CodigoArticulo).Append("\n");
            sb.Append("  NombreArticulo: ").Append(NombreArticulo).Append("\n");
            sb.Append("  Estado: ").Append(Estado).Append("\n");
            sb.Append("  CantidadEntrega: ").Append(CantidadEntrega).Append("\n");
            sb.Append("  CantidadPendiente: ").Append(CantidadPendiente).Append("\n");
            sb.Append("  UnidadMedida: ").Append(UnidadMedida).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ArticuloAlistamientoResponse)obj);
        }

        /// <summary>
        /// Returns true if ArticuloAlistamientoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ArticuloAlistamientoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ArticuloAlistamientoResponse other)
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
                    Estado == other.Estado ||
                    Estado != null &&
                    Estado.Equals(other.Estado)
                ) &&
                (
                    CantidadEntrega == other.CantidadEntrega ||
                    CantidadEntrega != null &&
                    CantidadEntrega.Equals(other.CantidadEntrega)
                ) &&
                (
                    CantidadPendiente == other.CantidadPendiente ||
                    CantidadPendiente != null &&
                    CantidadPendiente.Equals(other.CantidadPendiente)
                ) &&
                (
                    UnidadMedida == other.UnidadMedida ||
                    UnidadMedida != null &&
                    UnidadMedida.Equals(other.UnidadMedida)
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
                if (Estado != null)
                    hashCode = hashCode * 59 + Estado.GetHashCode();
                if (CantidadEntrega != null)
                    hashCode = hashCode * 59 + CantidadEntrega.GetHashCode();
                if (CantidadPendiente != null)
                    hashCode = hashCode * 59 + CantidadPendiente.GetHashCode();
                if (UnidadMedida != null)
                    hashCode = hashCode * 59 + UnidadMedida.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ArticuloAlistamientoResponse left, ArticuloAlistamientoResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArticuloAlistamientoResponse left, ArticuloAlistamientoResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
