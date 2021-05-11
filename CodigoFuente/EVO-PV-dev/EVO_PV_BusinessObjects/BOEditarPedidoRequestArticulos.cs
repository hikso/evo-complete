

namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 28-jul/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo EditarPedidoRequestArticulos
    /// </summary>

    public class BOEditarPedidoRequestArticulos
    {        
        /// <summary>
        /// Id del detalle del pedido
        /// </summary>
        /// <value>Id del estado del pedido</value>    
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Id del estado del pedido
        /// </summary>
        /// <value>Id del estado del pedido</value>    
        public int EstadoArticuloId { get; set; }

        /// <summary>
        /// Cantidad del artículo solicitada
        /// </summary>
        /// <value>Cantidad del artículo solicitada</value>     
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Id del empaque
        /// </summary>
        /// <value>Id del empaque</value>      
        public int EmpaqueId { get; set; }

        /// <summary>
        /// Observacion
        /// </summary>
        /// <value>Observacion</value>       
        public string Observacion { get; set; }

       
    }
}
