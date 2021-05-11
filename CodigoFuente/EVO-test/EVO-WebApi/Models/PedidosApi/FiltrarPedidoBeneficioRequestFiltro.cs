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
using System.Runtime.Serialization;

namespace EVO_WebApi.Models.PedidosApi
{
    /// <summary>
    /// Criterios por los que se filtrará la consulta
    /// </summary>
    [DataContract]
    public partial class FiltrarPedidoBeneficioRequestFiltro : IEquatable<FiltrarPedidoBeneficioRequestFiltro>
    {
        /// <summary>
        /// Código de la solicitud del pedido
        /// </summary>
        /// <value>Código de la solicitud del pedido</value>
        [DataMember(Name = "codigoPedido")]
        public string CodigoPedido { get; set; }

        /// <summary>
        /// Fecha de solicitud del pedido
        /// </summary>
        /// <value>Fecha de solicitud del pedido</value>
        [DataMember(Name = "fechaSolicitud")]
        public string FechaSolicitud { get; set; }

        /// <summary>
        /// Fecha de solicitud del pedido
        /// </summary>
        /// <value>Fecha de solicitud del pedido</value>
        [DataMember(Name = "fechaEntrega")]
        public string FechaEntrega { get; set; }

        /// <summary>
        /// Estado de la solicitud pedido
        /// </summary>
        /// <value>Estado de la solicitud pedido</value>
        [DataMember(Name = "estado")]
        public string Estado { get; set; }

        /// <summary>
        /// Nombre del cliente externo o punto de venta
        /// </summary>
        /// <value>Nombre del cliente externo o punto de venta</value>
        [DataMember(Name = "cliente")]
        public string Cliente { get; set; }

        /// <summary>
        /// Diás para la entrega del pedido
        /// </summary>
        /// <value>Diás para la entrega del pedido</value>
        [DataMember(Name = "diasEntrega")]
        public string DiasEntrega { get; set; }

        /// <summary>
        /// Indica la zona del punto de venta o cliente externo
        /// </summary>
        /// <value>Indica la zona del punto de venta o cliente externo</value>
        [DataMember(Name = "zona")]
        public string Zona { get; set; }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((FiltrarPedidoBeneficioRequestFiltro)obj);
        }

        bool IEquatable<FiltrarPedidoBeneficioRequestFiltro>.Equals(FiltrarPedidoBeneficioRequestFiltro other)
        {
            throw new NotImplementedException();
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(FiltrarPedidoBeneficioRequestFiltro left, FiltrarPedidoBeneficioRequestFiltro right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FiltrarPedidoBeneficioRequestFiltro left, FiltrarPedidoBeneficioRequestFiltro right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}