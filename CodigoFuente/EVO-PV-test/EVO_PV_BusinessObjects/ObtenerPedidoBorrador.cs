/*
 * API de Pedidos
 *
 * API de administración de Pedidos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Solicitud verificar si existe pedido en borrador
    /// </summary>
    [DataContract]
    public partial class ObtenerPedidoBorrador
    {
        /// <summary>
        /// Código de la bodega que genera el pedido
        /// </summary>
        /// <value>Código de la bodega que genera el pedido</value>
        [Required]
        [DataMember(Name = "WhsCode")]
        public string WhsCode { get; set; }

        /// <summary>
        /// Código de la bodega para donde va el pedido
        /// </summary>
        /// <value>Código de la bodega para donde va el pedido</value>
        [Required]
        [DataMember(Name = "SolicitudPara")]
        public string SolicitudPara { get; set; }


    }
}