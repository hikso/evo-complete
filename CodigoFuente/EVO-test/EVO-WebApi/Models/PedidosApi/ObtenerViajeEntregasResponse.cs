/*
 * API de Pedidos
 *
 * API de administración de Pedidos 
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

namespace EVO_WebApi.Models.PedidosApi

{
    /// <summary>
    /// Obtiene las entregas de un viaje
    /// </summary>
    [DataContract]
    public partial class ObtenerViajeEntregasResponse : IEquatable<ObtenerViajeEntregasResponse>
    {
        /// <summary>
        /// Nombre del tipo de vehiculo
        /// </summary>
        /// <value>Nombre del tipo de vehiculo</value>
        [DataMember(Name = "tipoVehiculo")]
        public string TipoVehiculo { get; set; }

        /// <summary>
        /// Capacidad en KG
        /// </summary>
        /// <value>Capacidad en KG</value>
        [DataMember(Name = "capacidadVehiculo")]
        public string CapacidadVehiculo { get; set; }

        /// <summary>
        /// Unidades de canastas
        /// </summary>
        /// <value>Unidades de canastas</value>
        [DataMember(Name = "unidadesCanastas")]
        public string UnidadesCanastas { get; set; }

        /// <summary>
        /// Placa del vehiculo
        /// </summary>
        /// <value>Placa del vehiculo</value>
        [DataMember(Name = "placa")]
        public string Placa { get; set; }

        /// <summary>
        /// Total entregas asociadas
        /// </summary>
        /// <value>Total entregas asociadas</value>
        [DataMember(Name = "totalEntregasAsociadas")]
        public string TotalEntregasAsociadas { get; set; }

        /// <summary>
        /// Cantidad total en KG
        /// </summary>
        /// <value>Cantidad total en KG</value>
        [DataMember(Name = "cantidadTotal")]
        public string CantidadTotal { get; set; }

        /// <summary>
        /// Unidades totales
        /// </summary>
        /// <value>Unidades totales</value>
        [DataMember(Name = "unidadesTotales")]
        public string UnidadesTotales { get; set; }

        /// <summary>
        /// Lista de las entregas
        /// </summary>
        /// <value>Lista de las entregas</value>
        [DataMember(Name = "entregas")]
        public List<ObtenerViajeEntregasResponseEntregas> Entregas { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ObtenerViajeEntregasResponse {\n");
            sb.Append("  TipoVehiculo: ").Append(TipoVehiculo).Append("\n");
            sb.Append("  CapacidadVehiculo: ").Append(CapacidadVehiculo).Append("\n");
            sb.Append("  UnidadesCanastas: ").Append(UnidadesCanastas).Append("\n");
            sb.Append("  Placa: ").Append(Placa).Append("\n");
            sb.Append("  TotalEntregasAsociadas: ").Append(TotalEntregasAsociadas).Append("\n");
            sb.Append("  CantidadTotal: ").Append(CantidadTotal).Append("\n");
            sb.Append("  UnidadesTotales: ").Append(UnidadesTotales).Append("\n");
            sb.Append("  Entregas: ").Append(Entregas).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ObtenerViajeEntregasResponse)obj);
        }

        /// <summary>
        /// Returns true if ObtenerViajeEntregasResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ObtenerViajeEntregasResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ObtenerViajeEntregasResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    TipoVehiculo == other.TipoVehiculo ||
                    TipoVehiculo != null &&
                    TipoVehiculo.Equals(other.TipoVehiculo)
                ) &&
                (
                    CapacidadVehiculo == other.CapacidadVehiculo ||
                    CapacidadVehiculo != null &&
                    CapacidadVehiculo.Equals(other.CapacidadVehiculo)
                ) &&
                (
                    UnidadesCanastas == other.UnidadesCanastas ||
                    UnidadesCanastas != null &&
                    UnidadesCanastas.Equals(other.UnidadesCanastas)
                ) &&
                (
                    Placa == other.Placa ||
                    Placa != null &&
                    Placa.Equals(other.Placa)
                ) &&
                (
                    TotalEntregasAsociadas == other.TotalEntregasAsociadas ||
                    TotalEntregasAsociadas != null &&
                    TotalEntregasAsociadas.Equals(other.TotalEntregasAsociadas)
                ) &&
                (
                    CantidadTotal == other.CantidadTotal ||
                    CantidadTotal != null &&
                    CantidadTotal.Equals(other.CantidadTotal)
                ) &&
                (
                    UnidadesTotales == other.UnidadesTotales ||
                    UnidadesTotales != null &&
                    UnidadesTotales.Equals(other.UnidadesTotales)
                ) &&
                (
                    Entregas == other.Entregas ||
                    Entregas != null &&
                    Entregas.SequenceEqual(other.Entregas)
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
                if (TipoVehiculo != null)
                    hashCode = hashCode * 59 + TipoVehiculo.GetHashCode();
                if (CapacidadVehiculo != null)
                    hashCode = hashCode * 59 + CapacidadVehiculo.GetHashCode();
                if (UnidadesCanastas != null)
                    hashCode = hashCode * 59 + UnidadesCanastas.GetHashCode();
                if (Placa != null)
                    hashCode = hashCode * 59 + Placa.GetHashCode();
                if (TotalEntregasAsociadas != null)
                    hashCode = hashCode * 59 + TotalEntregasAsociadas.GetHashCode();
                if (CantidadTotal != null)
                    hashCode = hashCode * 59 + CantidadTotal.GetHashCode();
                if (UnidadesTotales != null)
                    hashCode = hashCode * 59 + UnidadesTotales.GetHashCode();
                if (Entregas != null)
                    hashCode = hashCode * 59 + Entregas.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ObtenerViajeEntregasResponse left, ObtenerViajeEntregasResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ObtenerViajeEntregasResponse left, ObtenerViajeEntregasResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
