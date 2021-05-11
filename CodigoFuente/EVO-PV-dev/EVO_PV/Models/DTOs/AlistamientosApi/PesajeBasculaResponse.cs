﻿/*
 * API de Alistamiento
 *
 * API de administración de Alistamiento 
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

namespace EVO_PV.Models.AlistamientosApi
{
    /// <summary>
    /// Representa un pesaje por báscula de un articulo
    /// </summary>
    [DataContract]
    public partial class PesajeBasculaResponse : IEquatable<PesajeBasculaResponse>
    {
        /// <summary>
        /// Pesaje de la báscula
        /// </summary>
        /// <value>Pesaje de la báscula</value>
        [DataMember(Name = "pesoBascula")]
        public decimal PesoBascula { get; set; }

        /// <summary>
        /// Peso del artículo(peso báscula menos los pesos de los contenedores usados en el pesaje)
        /// </summary>
        /// <value>Peso del artículo(peso báscula menos los pesos de los contenedores usados en el pesaje)</value>
        [DataMember(Name = "pesoArticulo")]
        public decimal PesoArticulo { get; set; }

        /// <summary>
        /// Representa el nombre de la bodega donde fueron sacados los artículos del mismo tipo
        /// </summary>
        /// <value>Representa el nombre de la bodega donde fueron sacados los artículos del mismo tipo</value>
        [DataMember(Name = "bodega")]
        public string Bodega { get; set; }

        /// <summary>
        /// Gets or Sets ContenedoresRequest
        /// </summary>
        [DataMember(Name = "contenedoresRequest")]
        public List<PesajeContenedorRequest> ContenedoresRequest { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PesajeBasculaResponse {\n");
            sb.Append("  PesoBascula: ").Append(PesoBascula).Append("\n");
            sb.Append("  PesoArticulo: ").Append(PesoArticulo).Append("\n");
            sb.Append("  Bodega: ").Append(Bodega).Append("\n");
            sb.Append("  ContenedoresRequest: ").Append(ContenedoresRequest).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PesajeBasculaResponse)obj);
        }

        /// <summary>
        /// Returns true if PesajeBasculaResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of PesajeBasculaResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PesajeBasculaResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    PesoBascula == other.PesoBascula ||
                    PesoBascula != null &&
                    PesoBascula.Equals(other.PesoBascula)
                ) &&
                (
                    PesoArticulo == other.PesoArticulo ||
                    PesoArticulo != null &&
                    PesoArticulo.Equals(other.PesoArticulo)
                ) &&
                (
                    Bodega == other.Bodega ||
                    Bodega != null &&
                    Bodega.Equals(other.Bodega)
                ) &&
                (
                    ContenedoresRequest == other.ContenedoresRequest ||
                    ContenedoresRequest != null &&
                    ContenedoresRequest.SequenceEqual(other.ContenedoresRequest)
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
                if (PesoBascula != null)
                    hashCode = hashCode * 59 + PesoBascula.GetHashCode();
                if (PesoArticulo != null)
                    hashCode = hashCode * 59 + PesoArticulo.GetHashCode();
                if (Bodega != null)
                    hashCode = hashCode * 59 + Bodega.GetHashCode();
                if (ContenedoresRequest != null)
                    hashCode = hashCode * 59 + ContenedoresRequest.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(PesajeBasculaResponse left, PesajeBasculaResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PesajeBasculaResponse left, PesajeBasculaResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
