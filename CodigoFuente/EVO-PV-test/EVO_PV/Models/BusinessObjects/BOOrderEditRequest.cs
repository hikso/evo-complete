using System;
using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOOrderEditRequest
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>PV-PRA</value>
        public int OrderListId { get; set; }

        /// <summary>
        /// Código de la bodega que genera el pedido
        /// </summary>
        /// <value>PV-PRA</value>
        public string WhsCodePointSale { get; set; }

        /// <summary>
        /// Código de la bodega para donde va el pedido
        /// </summary>
        /// <value>PB-PT</value>
        public string WhsCodeFactory { get; set; }

        /// <summary>
        /// Usuario del usuario
        /// </summary>
        /// <value>USER123</value>
        public string User { get; set; }

        /// <summary>
        /// Indica la fecha de entrega del pedido
        /// </summary>
        /// <value>12/12/2020</value>
        public DateTime? DateDelivery { get; set; }

        /// <summary>
        /// Estado del pedido
        /// </summary>
        /// <value>Borrador</value>
        public string StateOrder { get; set; }

        /// <summary>
        /// Estado del pedido
        /// </summary>
        /// <value>Borrador</value>
        public int OrderTypeId { get; set; }

        /// <summary>
        /// email de la bodega
        /// </summary>
        /// <value>1</value>
        public string WhsEmail { get; set; }

        /// <summary>
        /// email de la bodega
        /// </summary>
        /// <value>1</value>
        public string UserName { get; set; }

        /// <summary>
        /// Detalles del Pedido
        /// </summary>

        public List<BOOrderRequestDetail> Details { get; set; }
    }
}
