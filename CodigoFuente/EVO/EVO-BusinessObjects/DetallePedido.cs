using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 20-Sep/2019
    /// Descripción      : Esta clase representa un detalle pedido
    /// </summary>
    public class DetallePedido
    {
        public int DetallePedidoId { get; set; }
        public int PedidoId { get; set; }

        /// <summary>
        /// Indica el código del artículo
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// Indica el id del estado del artículo
        /// </summary>
        public int EstadoArticuloId { get; set; }

        /// <summary>
        /// Indica el id de la unidad de medida
        /// </summary>
        public int UnidadMedidaId { get; set; }

        /// <summary>
        /// Indica la cantidad del pedido
        /// </summary>
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Observación
        /// </summary>
        /// <value></value>     
        public string Observacion { get; set; }

        public Pedido Pedido { get; set; }

        /// <summary>
        /// Id del empaque
        /// </summary>
        /// <value>1</value>       
        public int EmpaqueId { get; set; }
    }
}