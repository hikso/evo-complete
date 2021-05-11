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
    /// Resultado general de consulta
    /// </summary>
    [DataContract]
    public partial class ObtenerTodosPedidosBeneficioResponse : IEquatable<ObtenerTodosPedidosBeneficioResponse>
    { 
        /// <summary>
        /// Número total de registros que posee la consulta
        /// </summary>
        /// <value>Número total de registros que posee la consulta</value>
        [DataMember(Name="numeroTotalRegistros")]
        public int? NumeroTotalRegistros { get; set; }

        /// <summary>
        /// Número de registros a mostrar por página
        /// </summary>
        /// <value>Número de registros a mostrar por página</value>
        [DataMember(Name="tamanhoPaginacion")]
        public int? TamanhoPaginacion { get; set; }

        /// <summary>
        /// Lista de registros de Pedidos
        /// </summary>
        /// <value>Lista de registros de Pedidos</value>
        [DataMember(Name="registros")]
        public List<ObtenerTodosPedidosBeneficioResponseRegistros> Registros { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerTodosPedidosBeneficioResponse {\n");
            sb.Append("  NumeroTotalRegistros: ").Append(NumeroTotalRegistros).Append("\n");
            sb.Append("  TamanhoPaginacion: ").Append(TamanhoPaginacion).Append("\n");
            sb.Append("  Registros: ").Append(Registros).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerTodosPedidosBeneficioResponse)obj);
        }

        /// <summary>
        /// Returns true if ObtenerTodosPedidosBeneficioResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerTodosPedidosBeneficioResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerTodosPedidosBeneficioResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    NumeroTotalRegistros == other.NumeroTotalRegistros ||
                    NumeroTotalRegistros != null &&
                    NumeroTotalRegistros.Equals(other.NumeroTotalRegistros)
                ) && 
                (
                    TamanhoPaginacion == other.TamanhoPaginacion ||
                    TamanhoPaginacion != null &&
                    TamanhoPaginacion.Equals(other.TamanhoPaginacion)
                ) && 
                (
                    Registros == other.Registros ||
                    Registros != null &&
                    Registros.SequenceEqual(other.Registros)
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
                    if (NumeroTotalRegistros != null)
                    hashCode = hashCode * 59 + NumeroTotalRegistros.GetHashCode();
                    if (TamanhoPaginacion != null)
                    hashCode = hashCode * 59 + TamanhoPaginacion.GetHashCode();
                    if (Registros != null)
                    hashCode = hashCode * 59 + Registros.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ObtenerTodosPedidosBeneficioResponse left, ObtenerTodosPedidosBeneficioResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerTodosPedidosBeneficioResponse left, ObtenerTodosPedidosBeneficioResponse right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
