/*
 * API de Vehiculos
 *
 * API de administración de Vehiculos 
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

namespace IO.Swagger.Models.VehiculosApi
{ 
    /// <summary>
    /// Solicitud de parámetros del vehiculo para actualizar en enrutamiento
    /// </summary>
    [DataContract]
    public class ActualizaVehiculoEnrutamientoRequest : IEquatable<ActualizaVehiculoEnrutamientoRequest>
    { 
        /// <summary>
        /// Id del viaje
        /// </summary>
        /// <value>Id del viaje</value>
        [DataMember(Name="vehiculoEntregaId")]
        public int VehiculoEntregaId { get; set; }

        /// <summary>
        /// Id del vehiculo
        /// </summary>
        /// <value>Id del vehiculo</value>
        [DataMember(Name="vehiculoId")]
        public int VehiculoId { get; set; }

        /// <summary>
        /// Id del muelle
        /// </summary>
        /// <value>Id del muelle</value>
        [DataMember(Name="muelleId")]
        public int MuelleId { get; set; }

        /// <summary>
        /// Id del conductor
        /// </summary>
        /// <value>Id del conductor</value>
        [DataMember(Name="conductorId")]
        public int ConductorId { get; set; }

        /// <summary>
        /// Id del auxiliar
        /// </summary>
        /// <value>Id del auxiliar</value>
        [DataMember(Name="auxiliarId")]
        public int AuxiliarId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ActualizaVehiculoEnrutamientoRequest {\n");
            sb.Append("  VehiculoEntregaId: ").Append(VehiculoEntregaId).Append("\n");
            sb.Append("  VehiculoId: ").Append(VehiculoId).Append("\n");
            sb.Append("  MuelleId: ").Append(MuelleId).Append("\n");
            sb.Append("  ConductorId: ").Append(ConductorId).Append("\n");
            sb.Append("  AuxiliarId: ").Append(AuxiliarId).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ActualizaVehiculoEnrutamientoRequest)obj);
        }

        /// <summary>
        /// Returns true if ActualizaVehiculoEnrutamientoRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of ActualizaVehiculoEnrutamientoRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ActualizaVehiculoEnrutamientoRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    VehiculoEntregaId == other.VehiculoEntregaId ||
                    VehiculoEntregaId != null &&
                    VehiculoEntregaId.Equals(other.VehiculoEntregaId)
                ) && 
                (
                    VehiculoId == other.VehiculoId ||
                    VehiculoId != null &&
                    VehiculoId.Equals(other.VehiculoId)
                ) && 
                (
                    MuelleId == other.MuelleId ||
                    MuelleId != null &&
                    MuelleId.Equals(other.MuelleId)
                ) && 
                (
                    ConductorId == other.ConductorId ||
                    ConductorId != null &&
                    ConductorId.Equals(other.ConductorId)
                ) && 
                (
                    AuxiliarId == other.AuxiliarId ||
                    AuxiliarId != null &&
                    AuxiliarId.Equals(other.AuxiliarId)
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
                    if (VehiculoEntregaId != null)
                    hashCode = hashCode * 59 + VehiculoEntregaId.GetHashCode();
                    if (VehiculoId != null)
                    hashCode = hashCode * 59 + VehiculoId.GetHashCode();
                    if (MuelleId != null)
                    hashCode = hashCode * 59 + MuelleId.GetHashCode();
                    if (ConductorId != null)
                    hashCode = hashCode * 59 + ConductorId.GetHashCode();
                    if (AuxiliarId != null)
                    hashCode = hashCode * 59 + AuxiliarId.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ActualizaVehiculoEnrutamientoRequest left, ActualizaVehiculoEnrutamientoRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ActualizaVehiculoEnrutamientoRequest left, ActualizaVehiculoEnrutamientoRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
