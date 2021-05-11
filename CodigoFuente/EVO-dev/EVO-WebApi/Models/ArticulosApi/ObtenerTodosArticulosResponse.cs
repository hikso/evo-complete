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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.ArticuloApi
{
    /// <summary>
    /// Resultado general de consulta
    /// </summary>
    [DataContract]
    public partial class ObtenerTodosArticulosResponse : IEquatable<ObtenerTodosArticulosResponse>
    {
        /// <summary>
        /// Número total de registros que posee la consulta
        /// </summary>
        /// <value>Número total de registros que posee la consulta</value>
        [DataMember(Name = "numeroTotalRegistros")]
        public int NumeroTotalRegistros { get; set; }

        /// <summary>
        /// Número de registros a mostrar por página
        /// </summary>
        /// <value>Número de registros a mostrar por página</value>
        [DataMember(Name = "tamanhoPaginacion")]
        public int TamanhoPaginacion { get; set; }

        /// <summary>
        /// Lista de registros de Articulos
        /// </summary>
        /// <value>Lista de registros de Articulos</value>
        [DataMember(Name = "registros")]
        public List<ObtenerTodosArticulosResponseRegistros> Registros { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerTodosArticulosResponse {\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerTodosArticulosResponse)obj);
        }

        /// <summary>
        /// Returns true if ObtenerTodosArticulosResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerTodosArticulosResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerTodosArticulosResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    NumeroTotalRegistros == other.NumeroTotalRegistros &&
                    NumeroTotalRegistros.Equals(other.NumeroTotalRegistros)
                ) &&
                (
                    TamanhoPaginacion == other.TamanhoPaginacion &&
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
                    hashCode = hashCode * 59 + NumeroTotalRegistros.GetHashCode();              
                    hashCode = hashCode * 59 + TamanhoPaginacion.GetHashCode();
                if (Registros != null)
                    hashCode = hashCode * 59 + Registros.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ObtenerTodosArticulosResponse left, ObtenerTodosArticulosResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerTodosArticulosResponse left, ObtenerTodosArticulosResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
