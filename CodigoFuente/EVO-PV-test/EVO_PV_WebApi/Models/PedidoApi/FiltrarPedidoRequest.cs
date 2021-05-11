/*
 * API de Pedidos
 *
 * API de administración de Pedidos 
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

namespace EVO_PV_WebApi.Models.PedidosApi
{ 
    /// <summary>
    /// Objeto que contiene los filtros de los pedidos
    /// </summary>
    [DataContract]
    public partial class FiltrarPedidoRequest : IEquatable<FiltrarPedidoRequest>
    { 
        /// <summary>
        /// Indica el número de registro desde el cuál se deben obtener los registros
        /// </summary>
        /// <value>Indica el número de registro desde el cuál se deben obtener los registros</value>
        [DataMember(Name="desde")]
        public int Desde { get; set; }

        /// <summary>
        /// Indica el número de registro hasta el cuál se deben obtener los registros
        /// </summary>
        /// <value>Indica el número de registro hasta el cuál se deben obtener los registros</value>
        [DataMember(Name="hasta")]
        public int Hasta { get; set; }

        ///// <summary>
        ///// Indica el código de la bodega
        ///// </summary>
        ///// <value>Indica el código de la bodega</value>
        //[DataMember(Name="whsCode")]
        //public string WhsCode { get; set; }

        /// <summary>
        /// Gets or Sets Filtro
        /// </summary>
        [DataMember(Name="filtro")]
        public FiltrarPedidoRequestFiltro Filtro { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FiltrarPedidoRequest {\n");
            sb.Append("  Desde: ").Append(Desde).Append("\n");
            sb.Append("  Hasta: ").Append(Hasta).Append("\n");
            //sb.Append("  WhsCode: ").Append(WhsCode).Append("\n");
            sb.Append("  Filtro: ").Append(Filtro).Append("\n");
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
            return obj.GetType() == GetType() && Equals((FiltrarPedidoRequest)obj);
        }

        /// <summary>
        /// Returns true if FiltrarPedidoRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of FiltrarPedidoRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FiltrarPedidoRequest other)
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
                )
                //&& 
                //(
                //    WhsCode == other.WhsCode ||
                //    WhsCode != null &&
                //    WhsCode.Equals(other.WhsCode)
                //) 
                && 
                (
                    Filtro == other.Filtro ||
                    Filtro != null &&
                    Filtro.Equals(other.Filtro)
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
                    //if (WhsCode != null)
                    //hashCode = hashCode * 59 + WhsCode.GetHashCode();
                    if (Filtro != null)
                    hashCode = hashCode * 59 + Filtro.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(FiltrarPedidoRequest left, FiltrarPedidoRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FiltrarPedidoRequest left, FiltrarPedidoRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
