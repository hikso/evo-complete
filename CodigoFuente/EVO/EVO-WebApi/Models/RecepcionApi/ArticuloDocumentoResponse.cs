/*
 * API de Recepción
 *
 * API de administración de Recepción 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_WebApi.Models.RecepcionApi
{
    /// <summary>
    /// Representa representa que documento se generó por un artículo en recepción
    /// </summary>
    [DataContract]
    public partial class ArticuloDocumentoResponse : IEquatable<ArticuloDocumentoResponse>
    {
        /// <summary>
        /// Id del documento
        /// </summary>
        /// <value>Id del documento</value>
        [DataMember(Name = "documentoId")]
        public int DocumentoId { get; set; }

        /// <summary>
        /// Nombre del documento
        /// </summary>
        /// <value>Nombre del documento</value>
        [DataMember(Name = "nombreDocumento")]
        public string NombreDocumento { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ArticuloDocumentoResponse {\n");           
            sb.Append("  DocumentoId: ").Append(DocumentoId).Append("\n");
            sb.Append("  NombreDocumento: ").Append(NombreDocumento).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ArticuloDocumentoResponse)obj);
        }

        /// <summary>
        /// Returns true if ArticuloDocumentoResponse instances are equal
        /// </summary>
        /// <param name="other">Instance of ArticuloDocumentoResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ArticuloDocumentoResponse other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return             
                (
                    DocumentoId == other.DocumentoId ||
                    DocumentoId != null &&
                    DocumentoId.Equals(other.DocumentoId)
                ) &&
                (
                    NombreDocumento == other.NombreDocumento ||
                    NombreDocumento != null &&
                    NombreDocumento.Equals(other.NombreDocumento)
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
                //if (CodigoArticulo != null)
                //    hashCode = hashCode * 59 + CodigoArticulo.GetHashCode();
                //if (EstadoArticulo != null)
                //    hashCode = hashCode * 59 + EstadoArticulo.GetHashCode();
                if (DocumentoId != null)
                    hashCode = hashCode * 59 + DocumentoId.GetHashCode();
                if (NombreDocumento != null)
                    hashCode = hashCode * 59 + NombreDocumento.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ArticuloDocumentoResponse left, ArticuloDocumentoResponse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ArticuloDocumentoResponse left, ArticuloDocumentoResponse right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
