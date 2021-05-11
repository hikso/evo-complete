namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 29-jul/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo CancelarPedidoRequest
    /// </summary>
    public class BOCancelarPedidoRequest
    {
        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>      
        public int PedidoId { get; set; }

        /// <summary>
        /// Id del Motivo
        /// </summary>
        /// <value>Id del Motivo</value>       
        public int MotivoId { get; set; }
    }
}
