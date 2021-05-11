namespace EVO_PV.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 19-Ene/2020
    /// Descripción     : Clase que representa un objeto de petición para saber si existe una solicitud de pedido a una planta
    /// </summary>
    public class BOGetOrderErasedRequest
    {
        /// <summary>
        /// Código del punto de venta
        /// </summary>
        /// <value>PV-PRA</value>      
        public string CodePointSale { get; set; }
        /// <summary>
        /// CÓdigo de la planta
        /// </summary>
        /// <value>PV-PT</value>      
        public string CodeFactory { get; set; }
    }
}
