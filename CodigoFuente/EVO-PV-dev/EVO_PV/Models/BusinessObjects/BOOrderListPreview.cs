using System;
using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOOrderListPreview
    {
        /// <summary>
        /// Fecha del pedido
        /// </summary>
        /// <value>Fecha del pedido</value>
        public DateTime DateorderList { get; set; }

        /// <summary>
        /// Código del pedido
        /// </summary>
        /// <value>Código del pedido</value>
        public string CodeOrderList { get; set; }

        /// <summary>
        /// Código de la bodega tipo planta
        /// </summary>
        /// <value>Código de la bodega tipo planta</value>
        public string RequestFor { get; set; }

        /// <summary>
        /// Fecha entrega
        /// </summary>
        /// <value>Fecha entrega</value>
        public DateTime? DateDelivery { get; set; }

        /// <summary>
        /// Estado Pedido Id
        /// </summary>
        /// <value>Estado Pedido Id</value>
        public int StateOrderListId { get; set; }

        /// <summary>
        /// TipoSolicitudId
        /// </summary>
        /// <value>1</value>
        public int TypeOrderId { get; set; }


        /// <summary>
        /// Lista de detalles del Pedido
        /// </summary>
        /// <value>Lista de detalles del Pedido</value>
        public List<BOArticleOrder> Registers { get; set; }




    }
}
