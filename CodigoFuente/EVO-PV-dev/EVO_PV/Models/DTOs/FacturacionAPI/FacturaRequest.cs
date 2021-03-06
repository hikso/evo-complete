/*
 * API de administración de Facturación
 *
 * API de administración de facturación 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace EVO_PV.Models.FacturacionApi
{
    /// <summary>
    /// Representa la solicitud de la factura
    /// </summary>
    [DataContract]
    public partial class FacturaRequest : IEquatable<FacturaRequest>
    {
        /// <summary>
        /// Indica el código del punto de venta
        /// </summary>
        /// <value>Indica el código del punto de venta</value>
        [Required]
        [DataMember(Name = "codigoPuntoVenta")]
        public string CodigoPuntoVenta { get; set; }

        /// <summary>
        /// Indica el id del vendedor
        /// </summary>
        /// <value>Indica el id del vendedor</value>
        [Required]
        [DataMember(Name = "vendedorId")]
        public int VendedorId { get; set; }

        /// <summary>
        /// Indica la identificación del socio de negocio(cliente de la factura)
        /// </summary>
        /// <value>Indica la identificación del socio de negocio(cliente de la factura)</value>
        [Required]
        [DataMember(Name = "identificacionCliente")]
        public string IdentificacionCliente { get; set; }

        /// <summary>
        /// Indica el id del tipo de báscula
        /// </summary>
        /// <value>Indica el id del tipo de báscula</value>
        [Required]
        [DataMember(Name = "tipoBasculaId")]
        public int TipoBasculaId { get; set; }

        /// <summary>
        /// Indica las observaciones de la factura(Opcional)
        /// </summary>
        /// <value>Indica las observaciones de la factura(Opcional)</value>
        [DataMember(Name = "observaciones")]
        public string Observaciones { get; set; }

        /// <summary>
        /// Indica la sumatoria de los totales por artículo
        /// </summary>
        /// <value>Indica la sumatoria de los totales por artículo</value>
        [Required]
        [DataMember(Name = "totalAntesDescuento")]
        public int TotalAntesDescuento { get; set; }

        /// <summary>
        /// Indica el porcentaje de descuento(Opcional)
        /// </summary>
        /// <value>Indica el porcentaje de descuento(Opcional)</value>
        [DataMember(Name = "porcentajeDescuento")]
        public decimal? PorcentajeDescuento { get; set; }

        /// <summary>
        /// Indica el total de descuento(Opcional)
        /// </summary>
        /// <value>12345</value>
        [DataMember(Name = "totalConDescuento")]
        public int? TotalConDescuento { get; set; }

        /// <summary>
        /// Indica la cantidad de bolsas
        /// </summary>
        /// <value>Indica la cantidad de bolsas</value>
        [DataMember(Name = "cantidadBolsas")]
        public int CantidadBolsas { get; set; }

        /// <summary>
        ///  Indica el porcentaje de cobro del valor de la bolsa(Opcional)
        /// </summary>
        /// <value>40</value>
        [DataMember(Name = "porcentajeCobroBolsa")]
        public int? PorcentajeCobroBolsa { get; set; }

        /// <summary>
        /// Indica el valor de la bolsa(Opcional)
        /// </summary>
        /// <value>40</value>
        [DataMember(Name = "valorBolsa")]
        public int? ValorBolsa { get; set; }

        /// <summary>
        /// Indica el valor del impuesto de bolsas(Opcional)
        /// </summary>
        /// <value>40</value>
        [DataMember(Name = "impuestoBolsas")]
        public int? ImpuestoBolsas { get; set; }

        /// <summary>
        /// Indica el valor de los impuestos de la factura
        /// </summary>
        /// <value>75000</value>
        [Required]
        [DataMember(Name = "valorImpuestos")]
        public int ValorImpuestos { get; set; }

        /// <summary>
        /// Indica el total de la factura
        /// </summary>
        /// <value>Indica el total de la factura</value>
        [Required]
        [DataMember(Name = "totalDocumento")]
        public int TotalDocumento { get; set; }

        /// <summary>
        /// Gets or Sets Articulos
        /// </summary>
        [Required]
        [DataMember(Name = "articulos")]
        public List<ArticuloRequest> Articulos { get; set; }

        /// <summary>
        /// Gets or Sets FormasPago
        /// </summary>
        [DataMember(Name = "formasPago")]
        public List<FormaPagoRequest> FormasPago { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FacturaRequest {\n");
            sb.Append("  CodigoPuntoVenta: ").Append(CodigoPuntoVenta).Append("\n");
            sb.Append("  VendedorId: ").Append(VendedorId).Append("\n");
            sb.Append("  IdentificacionCliente: ").Append(IdentificacionCliente).Append("\n");
            sb.Append("  TipoBasculaId: ").Append(TipoBasculaId).Append("\n");
            sb.Append("  Observaciones: ").Append(Observaciones).Append("\n");
            sb.Append("  TotalAntesDescuento: ").Append(TotalAntesDescuento).Append("\n");
            sb.Append("  PorcentajeDescuento: ").Append(PorcentajeDescuento).Append("\n");
            sb.Append("  TotalConDescuento: ").Append(TotalConDescuento).Append("\n");
            sb.Append("  CantidadBolsas: ").Append(CantidadBolsas).Append("\n");
            sb.Append("  PorcentajeCobroBolsa: ").Append(PorcentajeCobroBolsa).Append("\n");
            sb.Append("  ValorImpuestos: ").Append(ValorImpuestos).Append("\n");
            sb.Append("  TotalDocumento: ").Append(TotalDocumento).Append("\n");
            sb.Append("  Articulos: ").Append(Articulos).Append("\n");
            sb.Append("  FormasPago: ").Append(FormasPago).Append("\n");
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
            return obj.GetType() == GetType() && Equals((FacturaRequest)obj);
        }

        /// <summary>
        /// Returns true if FacturaRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of FacturaRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FacturaRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    CodigoPuntoVenta == other.CodigoPuntoVenta ||
                    CodigoPuntoVenta != null &&
                    CodigoPuntoVenta.Equals(other.CodigoPuntoVenta)
                ) &&
                (
                    VendedorId == other.VendedorId ||
                    VendedorId != null &&
                    VendedorId.Equals(other.VendedorId)
                ) &&
                (
                    IdentificacionCliente == other.IdentificacionCliente ||
                    IdentificacionCliente != null &&
                    IdentificacionCliente.Equals(other.IdentificacionCliente)
                ) &&
                (
                    TipoBasculaId == other.TipoBasculaId ||
                    TipoBasculaId != null &&
                    TipoBasculaId.Equals(other.TipoBasculaId)
                ) &&
                (
                    Observaciones == other.Observaciones ||
                    Observaciones != null &&
                    Observaciones.Equals(other.Observaciones)
                ) &&
                (
                    TotalAntesDescuento == other.TotalAntesDescuento ||
                    TotalAntesDescuento != null &&
                    TotalAntesDescuento.Equals(other.TotalAntesDescuento)
                ) &&
                (
                    PorcentajeDescuento == other.PorcentajeDescuento ||
                    PorcentajeDescuento != null &&
                    PorcentajeDescuento.Equals(other.PorcentajeDescuento)
                ) &&
                (
                    TotalConDescuento == other.TotalConDescuento ||
                    TotalConDescuento != null &&
                    TotalConDescuento.Equals(other.TotalConDescuento)
                ) &&
                (
                    CantidadBolsas == other.CantidadBolsas ||
                    CantidadBolsas != null &&
                    CantidadBolsas.Equals(other.CantidadBolsas)
                ) &&
                (
                    PorcentajeCobroBolsa == other.PorcentajeCobroBolsa ||
                    PorcentajeCobroBolsa != null &&
                    PorcentajeCobroBolsa.Equals(other.PorcentajeCobroBolsa)
                ) &&
                (
                    ValorImpuestos == other.ValorImpuestos ||
                    ValorImpuestos != null &&
                    ValorImpuestos.Equals(other.ValorImpuestos)
                ) &&
                (
                    TotalDocumento == other.TotalDocumento ||
                    TotalDocumento != null &&
                    TotalDocumento.Equals(other.TotalDocumento)
                ) &&
                (
                    Articulos == other.Articulos ||
                    Articulos != null &&
                    Articulos.SequenceEqual(other.Articulos)
                ) &&
                (
                    FormasPago == other.FormasPago ||
                    FormasPago != null &&
                    FormasPago.SequenceEqual(other.FormasPago)
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
                if (CodigoPuntoVenta != null)
                    hashCode = hashCode * 59 + CodigoPuntoVenta.GetHashCode();
                if (VendedorId != null)
                    hashCode = hashCode * 59 + VendedorId.GetHashCode();
                if (IdentificacionCliente != null)
                    hashCode = hashCode * 59 + IdentificacionCliente.GetHashCode();
                if (TipoBasculaId != null)
                    hashCode = hashCode * 59 + TipoBasculaId.GetHashCode();
                if (Observaciones != null)
                    hashCode = hashCode * 59 + Observaciones.GetHashCode();
                if (TotalAntesDescuento != null)
                    hashCode = hashCode * 59 + TotalAntesDescuento.GetHashCode();
                if (PorcentajeDescuento != null)
                    hashCode = hashCode * 59 + PorcentajeDescuento.GetHashCode();
                if (TotalConDescuento != null)
                    hashCode = hashCode * 59 + TotalConDescuento.GetHashCode();
                if (CantidadBolsas != null)
                    hashCode = hashCode * 59 + CantidadBolsas.GetHashCode();
                if (PorcentajeCobroBolsa != null)
                    hashCode = hashCode * 59 + PorcentajeCobroBolsa.GetHashCode();
                if (ValorImpuestos != null)
                    hashCode = hashCode * 59 + ValorImpuestos.GetHashCode();
                if (TotalDocumento != null)
                    hashCode = hashCode * 59 + TotalDocumento.GetHashCode();
                if (Articulos != null)
                    hashCode = hashCode * 59 + Articulos.GetHashCode();
                if (FormasPago != null)
                    hashCode = hashCode * 59 + FormasPago.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(FacturaRequest left, FacturaRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FacturaRequest left, FacturaRequest right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
