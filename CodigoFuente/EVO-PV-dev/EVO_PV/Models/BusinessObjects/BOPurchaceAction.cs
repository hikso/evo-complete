using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOPurchaceAction
    {
        /// <summary>
        /// Id de la acción de compra
        /// </summary>
        /// <value>Id de la acción de compra</value>
        public int ActionId { get; set; }

        /// <summary>
        /// Nombre de la acción de compra
        /// </summary>
        /// <value>Nombre de la acción de compra</value>
        public string ActionName { get; set; }

        /// <summary>
        /// Artículos asociados a las gestiones de compra del pedido
        /// </summary>
        /// <value>Artículos asociados a las gestiones de compra del pedido</value>
        public List<BOPurchaceActionArticle> Articles { get; set; }
    }
}
