namespace EVO_PB.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 17-Ene/2019
    /// Descripción     : Clase que representa el detalle de la solicitud del pedido
    /// </summary>
    public class BOOrderRequestDetail
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>PT-1405</value>       
        public string ItemCode { get; set; }

        /// <summary>
        /// Id del estado del pedido
        /// </summary>
        /// <value>1</value>      
        public int StateArticleId { get; set; }

        /// <summary>
        /// Cantidad del artículo solicitada
        /// </summary>
        /// <value>23456.67</value>      
        public decimal Quantity { get; set; }
    }
}
