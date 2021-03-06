/*
 * API de Evidencia
 *
 * API de administración de Evidencia 
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

namespace EVO_WebApi.Models.EvidenciaApi
{
    /// <summary>
    /// Representa el detalle de la evidencia
    /// </summary>
    [DataContract]
    public partial class DetalleEvidenciaResponse : IEquatable<DetalleEvidenciaResponse>
    {
        /// <summary>
        /// Nombre de punto de venta
        /// </summary>
        /// <value>Nombre de punto de venta</value>
        [DataMember(Name = "puntoVenta")]
        public string PuntoVenta { get; set; }

        /// <summary>
        /// Número del pedido
        /// </summary>
        /// <value>Número del pedido</value>
        [DataMember(Name = "numeroPedido")]
        public string NumeroPedido { get; set; }

        /// <summary>
        /// Usuario que generó la evidencia
        /// </summary>
        /// <value>Usuario que generó la evidencia</value>
        [DataMember(Name = "usaurio")]
        public string Usuario { get; set; }

        /// <summary>
        /// Fecha de la evidencia
        /// </summary>
        /// <value>Fecha de la evidencia</value>
        [DataMember(Name = "fechaEvidencia")]
        public string FechaEvidencia { get; set; }

        /// <summary>
        /// Email de origen
        /// </summary>
        /// <value>Email de origen</value>
        [DataMember(Name = "correoOrigen")]
        public string CorreoOrigen { get; set; }

        /// <summary>
        /// Email de destino
        /// </summary>
        /// <value>Email de destino</value>
        [DataMember(Name = "correoDestino")]
        public string CorreoDestino { get; set; }

        /// <summary>
        /// Observaciones de la evidencia
        /// </summary>
        /// <value>Observaciones de la evidencia</value>
        [DataMember(Name = "observaciones")]
        public string Observaciones { get; set; }

        /// <summary>
        /// Identificador del directorio donde están ubicados los archivos
        /// </summary>
        /// <value>Identificador del directorio donde están ubicados los archivos</value>
        [DataMember(Name = "GUID")]
        public string GUID { get; set; }

        /// <summary>
        /// Gets or Sets Archivos
        /// </summary>
        [DataMember(Name = "archivos")]
        public List<ArchivoResponse> Archivos { get; set; }

        /// <summary>
        /// Gets or Sets DocumentosArticulos
        /// </summary>
        [DataMember(Name = "documentosArticulos")]
        public List<DocumentoArticuloResponse> DocumentosArticulos { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DetalleEvidenciaResponse {\n");
            sb.Append("  PuntoVenta: ").Append(PuntoVenta).Append("\n");
            sb.Append("  NumeroPedido: ").Append(NumeroPedido).Append("\n");
            sb.Append("  Usuario: ").Append(Usuario).Append("\n");
            sb.Append("  FechaEvidencia: ").Append(FechaEvidencia).Append("\n");
            sb.Append("  CorreoOrigen: ").Append(CorreoOrigen).Append("\n");
            sb.Append("  CorreoDestino: ").Append(CorreoDestino).Append("\n");
            sb.Append("  Observaciones: ").Append(Observaciones).Append("\n");
            sb.Append("  Archivos: ").Append(Archivos).Append("\n");
            sb.Append("  DocumentosArticulos: ").Append(DocumentosArticulos).Append("\n");
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
            return obj.GetType() == GetType() && Equals((DetalleEvidenciaResponse)obj);
        }

        /// <summary>
        /// Returns true if DetalleEvidenciaResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of DetalleEvidenciaResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DetalleEvidenciaResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    PuntoVenta == other.PuntoVenta ||
                    PuntoVenta != null &&
                    PuntoVenta.Equals(other.PuntoVenta)
                ) &&
                (
                    NumeroPedido == other.NumeroPedido ||
                    NumeroPedido != null &&
                    NumeroPedido.Equals(other.NumeroPedido)
                ) &&
                (
                    Usuario == other.Usuario ||
                    Usuario != null &&
                    Usuario.Equals(other.Usuario)
                ) &&
                (
                    FechaEvidencia == other.FechaEvidencia ||
                    FechaEvidencia != null &&
                    FechaEvidencia.Equals(other.FechaEvidencia)
                ) &&
                (
                    CorreoOrigen == other.CorreoOrigen ||
                    CorreoOrigen != null &&
                    CorreoOrigen.Equals(other.CorreoOrigen)
                ) &&
                (
                    CorreoDestino == other.CorreoDestino ||
                    CorreoDestino != null &&
                    CorreoDestino.Equals(other.CorreoDestino)
                ) &&
                (
                    Observaciones == other.Observaciones ||
                    Observaciones != null &&
                    Observaciones.Equals(other.Observaciones)
                ) &&
                (
                    Archivos == other.Archivos ||
                    Archivos != null &&
                    Archivos.SequenceEqual(other.Archivos)
                ) &&
                (
                    DocumentosArticulos == other.DocumentosArticulos ||
                    DocumentosArticulos != null &&
                    DocumentosArticulos.SequenceEqual(other.DocumentosArticulos)
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
                if (PuntoVenta != null)
                    hashCode = hashCode * 59 + PuntoVenta.GetHashCode();
                if (NumeroPedido != null)
                    hashCode = hashCode * 59 + NumeroPedido.GetHashCode();
                if (Usuario != null)
                    hashCode = hashCode * 59 + Usuario.GetHashCode();
                if (FechaEvidencia != null)
                    hashCode = hashCode * 59 + FechaEvidencia.GetHashCode();
                if (CorreoOrigen != null)
                    hashCode = hashCode * 59 + CorreoOrigen.GetHashCode();
                if (CorreoDestino != null)
                    hashCode = hashCode * 59 + CorreoDestino.GetHashCode();
                if (Observaciones != null)
                    hashCode = hashCode * 59 + Observaciones.GetHashCode();
                if (Archivos != null)
                    hashCode = hashCode * 59 + Archivos.GetHashCode();
                if (DocumentosArticulos != null)
                    hashCode = hashCode * 59 + DocumentosArticulos.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(DetalleEvidenciaResponse left, DetalleEvidenciaResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DetalleEvidenciaResponse left, DetalleEvidenciaResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
