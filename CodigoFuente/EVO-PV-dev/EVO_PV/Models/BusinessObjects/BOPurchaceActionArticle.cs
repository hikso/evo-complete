using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOPurchaceActionArticle
    {
        /// <summary>
        /// Id del detalle del pedido
        /// </summary>
        /// <value>Id del detalle del pedido</value>
        public int DetailDeliveryId { get; set; }

        /// <summary>
        /// Cantidad asociada a esta orden de compra
        /// </summary>
        /// <value>Cantidad asociada a esta orden de compra</value>
        public string Quantity { get; set; }

        /// <summary>
        /// Orden de compra
        /// </summary>
        /// <value>Orden de compra</value>
        public string DeliveryOrder { get; set; }

        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>
        public string ArticleCode { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>
        public string ArticleName { get; set; }

        /// <summary>
        /// Cantidad solicitada
        /// </summary>
        /// <value>Cantidad solicitada</value>
        public string QuantityRequested { get; set; }

        /// <summary>
        /// Unidad de medida del artículo
        /// </summary>
        /// <value>Unidad de medida del artículo</value>
        public string MeasureUnit { get; set; }

        /// <summary>
        /// Stock del almacen de compras de este artículo
        /// </summary>
        /// <value>Stock del almacen de compras de este artículo</value>
        public string DeportStock { get; set; }

        /// <summary>
        /// Observaciones del artículo
        /// </summary>
        /// <value>Observaciones del artículo</value>
        public string Observation { get; set; }

        /// <summary>
        /// Cantidad faltante a gestionar
        /// </summary>
        /// <value>Cantidad a gestionar</value>
        public string QuantityLeftManagement { get; set; }
    }
}
