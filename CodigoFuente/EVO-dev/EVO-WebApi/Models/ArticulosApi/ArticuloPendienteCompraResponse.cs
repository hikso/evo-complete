/*
 * API de Artículos
 *
 * API de administración de Articulos 
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

namespace EVO_WebApi.Models.ArticulosApi
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ArticuloPendienteCompraResponse : IEquatable<ArticuloPendienteCompraResponse>
    { 
        /// <summary>
        /// Id del detalle de pedido
        /// </summary>
        /// <value>Id del detalle de pedido</value>
        [DataMember(Name="detallePedidoId")]
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>
        [DataMember(Name="codigoArticulo")]
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>
        [DataMember(Name="nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Cantidad solicitada
        /// </summary>
        /// <value>Cantidad solicitada</value>
        [DataMember(Name="cantidadSolicitada")]
        public string CantidadSolicitada { get; set; }

        /// <summary>
        /// Unidad de medida
        /// </summary>
        /// <value>Unidad de medida</value>
        [DataMember(Name="unidadMedida")]
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Cantidad gestionar
        /// </summary>
        /// <value>Cantidad gestionar</value>
        [DataMember(Name="cantidadGestionar")]
        public string CantidadGestionar { get; set; }

        /// <summary>
        /// Stock del almacen
        /// </summary>
        /// <value>Stock del almacen</value>
        [DataMember(Name="stockAlmacen")]
        public string StockAlmacen { get; set; }

        /// <summary>
        /// Orden de compra
        /// </summary>
        /// <value>Orden de compra</value>
        [DataMember(Name="ordenCompra")]
        public string OrdenCompra { get; set; }

        /// <summary>
        /// Observaciones
        /// </summary>
        /// <value>Observaciones</value>
        [DataMember(Name="observaciones")]
        public string Observaciones { get; set; }

        /// <summary>
        /// Cantidad faltante de gestionar
        /// </summary>
        /// <value>12000</value>
        [DataMember(Name = "cantidadFaltanteGestionar")]
        public string CantidadFaltanteGestionar { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ArticuloPendienteCompraResponse {\n");
            sb.Append("  DetallePedidoId: ").Append(DetallePedidoId).Append("\n");
            sb.Append("  CodigoArticulo: ").Append(CodigoArticulo).Append("\n");
            sb.Append("  Nombre: ").Append(Nombre).Append("\n");
            sb.Append("  CantidadSolicitada: ").Append(CantidadSolicitada).Append("\n");
            sb.Append("  UnidadMedida: ").Append(UnidadMedida).Append("\n");
            sb.Append("  CantidadGestionar: ").Append(CantidadGestionar).Append("\n");
            sb.Append("  StockAlmacen: ").Append(StockAlmacen).Append("\n");
            sb.Append("  OrdenCompra: ").Append(OrdenCompra).Append("\n");
            sb.Append("  Observaciones: ").Append(Observaciones).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ArticuloPendienteCompraResponse)obj);
        }

        /// <summary>
        /// Returns true if ArticuloPendienteCompraResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ArticuloPendienteCompraResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ArticuloPendienteCompraResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    DetallePedidoId == other.DetallePedidoId ||
                    DetallePedidoId != null &&
                    DetallePedidoId.Equals(other.DetallePedidoId)
                ) && 
                (
                    CodigoArticulo == other.CodigoArticulo ||
                    CodigoArticulo != null &&
                    CodigoArticulo.Equals(other.CodigoArticulo)
                ) && 
                (
                    Nombre == other.Nombre ||
                    Nombre != null &&
                    Nombre.Equals(other.Nombre)
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
                    CantidadGestionar == other.CantidadGestionar ||
                    CantidadGestionar != null &&
                    CantidadGestionar.Equals(other.CantidadGestionar)
                ) && 
                (
                    StockAlmacen == other.StockAlmacen ||
                    StockAlmacen != null &&
                    StockAlmacen.Equals(other.StockAlmacen)
                ) && 
                (
                    OrdenCompra == other.OrdenCompra ||
                    OrdenCompra != null &&
                    OrdenCompra.Equals(other.OrdenCompra)
                ) && 
                (
                    Observaciones == other.Observaciones ||
                    Observaciones != null &&
                    Observaciones.Equals(other.Observaciones)
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
                    if (DetallePedidoId != null)
                    hashCode = hashCode * 59 + DetallePedidoId.GetHashCode();
                    if (CodigoArticulo != null)
                    hashCode = hashCode * 59 + CodigoArticulo.GetHashCode();
                    if (Nombre != null)
                    hashCode = hashCode * 59 + Nombre.GetHashCode();
                    if (CantidadSolicitada != null)
                    hashCode = hashCode * 59 + CantidadSolicitada.GetHashCode();
                    if (UnidadMedida != null)
                    hashCode = hashCode * 59 + UnidadMedida.GetHashCode();
                    if (CantidadGestionar != null)
                    hashCode = hashCode * 59 + CantidadGestionar.GetHashCode();
                    if (StockAlmacen != null)
                    hashCode = hashCode * 59 + StockAlmacen.GetHashCode();
                    if (OrdenCompra != null)
                    hashCode = hashCode * 59 + OrdenCompra.GetHashCode();
                    if (Observaciones != null)
                    hashCode = hashCode * 59 + Observaciones.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ArticuloPendienteCompraResponse left, ArticuloPendienteCompraResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArticuloPendienteCompraResponse left, ArticuloPendienteCompraResponse right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
