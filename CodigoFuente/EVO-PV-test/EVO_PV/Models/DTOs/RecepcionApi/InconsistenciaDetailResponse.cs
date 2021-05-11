/*
 * API de Evidencias
 *
 * OpenAPI spec version: 1.0.0
 * Contact: * Contact: galfonso@digitalcg.com.co
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV.Models.RecepcionApi
{
    /// <summary>
    /// Representa el encabezado de recepción
    /// </summary>
    [DataContract]
    public partial class InconsistenciaDetailResponse : IEquatable<InconsistenciaDetailResponse>
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "evidenciaId")]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>
        [DataMember(Name = "puntoVenta")]
        public string PuntoVenta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "numeroPedido")]
        public string NumeroPedido { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "usaurio")]
        public string Usuario { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "fechaEvidencia")]
        public string FechaEvidencia { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "correoOrigen")]
        public string CorreoOrigen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "correoDestino")]
        public string CorreoDestino { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "observaciones")]
        public string Observaciones { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "GUID")]
        public string GUID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "archivos")]
        public List<InconsistenciaArchivoResponse> Archivos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "documentosArticulos")]
        public List<ArticuloDocumentoResponse> DocumentosArticulos { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class InconsistenciaResponse {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  PuntoVenta: ").Append(PuntoVenta).Append("\n");
            sb.Append("  NumeroPedido: ").Append(NumeroPedido).Append("\n");
            sb.Append("  Usuario: ").Append(Usuario).Append("\n");
            sb.Append("  FechaEvidencia: ").Append(FechaEvidencia).Append("\n");
            sb.Append("  CorreoDestino: ").Append(CorreoDestino).Append("\n");
            sb.Append("  CorreoOrigen: ").Append(CorreoOrigen).Append("\n");
            sb.Append("  Observaciones: ").Append(Observaciones).Append("\n");
            sb.Append("  GUID: ").Append(GUID).Append("\n");
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
            return obj.GetType() == GetType() && Equals((InconsistenciaResponse)obj);
        }

        /// <summary>
        /// Returns true if RecepcionEncabezadoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of RecepcionEncabezadoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InconsistenciaDetailResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
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
                    GUID == other.GUID ||
                    GUID != null &&
                    GUID.Equals(other.GUID)
                ) &&
                (
                    Archivos == other.Archivos ||
                    Archivos != null &&
                    Archivos.Equals(other.Archivos)
                ) &&
                (
                    DocumentosArticulos == other.DocumentosArticulos ||
                    DocumentosArticulos != null &&
                    DocumentosArticulos.Equals(other.DocumentosArticulos)
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
                if (Id != null) hashCode = hashCode * 59 + Id.GetHashCode();
                if (PuntoVenta != null) hashCode = hashCode * 59 + PuntoVenta.GetHashCode();
                if (NumeroPedido != null) hashCode = hashCode * 59 + NumeroPedido.GetHashCode();
                if (Usuario != null) hashCode = hashCode * 59 + Usuario.GetHashCode();
                if (FechaEvidencia != null) hashCode = hashCode * 59 + FechaEvidencia.GetHashCode();
                if (CorreoOrigen != null) hashCode = hashCode * 59 + CorreoOrigen.GetHashCode();
                if (CorreoDestino != null) hashCode = hashCode * 59 + CorreoDestino.GetHashCode();
                if (Observaciones != null) hashCode = hashCode * 59 + Observaciones.GetHashCode();
                if (GUID != null) hashCode = hashCode * 59 + GUID.GetHashCode();
                if (Archivos != null) hashCode = hashCode * 59 + Archivos.GetHashCode();
                if (DocumentosArticulos != null) hashCode = hashCode * 59 + DocumentosArticulos.GetHashCode();

                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(InconsistenciaDetailResponse left, InconsistenciaDetailResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(InconsistenciaDetailResponse left, InconsistenciaDetailResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
