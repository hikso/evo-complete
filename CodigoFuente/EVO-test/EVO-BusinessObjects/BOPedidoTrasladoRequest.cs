using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 18-Sep/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo PedidoTrasladoRequest
    /// </summary>
    public class BOPedidoTrasladoRequest
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>       
        public int PedidoId { get; set; }

        /// <summary>
        /// Fecha limite sugerida
        /// </summary>
        /// <value>Fecha limite sugerida</value>     
        public string FechaLimiteSugerida { get; set; }

        /// <summary>
        /// Artículos del pedido
        /// </summary>
        /// <value>Artículos del pedido</value>       
        public List<BOArticuloTrasladoRequest> Articulos { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        /// <value>cg-jcusuga</value>       
        public string Usuario { get; set; }

        /// <summary>
        /// Usuario Id
        /// </summary>
        /// <value>2</value>       
        public int UsuarioId { get; set; }
    }
}
