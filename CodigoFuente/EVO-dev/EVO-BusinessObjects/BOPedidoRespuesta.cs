namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 28-Ene/2021
    /// Descripción     : Clase que representa un objeto de negocio de Respuesta de un pedido
    /// </summary>
    public class BOPedidoRespuesta
    {
        /// <summary>
        /// Define el estado de la respuesta
        /// </summary>       
        public bool Estado { get; set; }

        /// <summary>
        /// Define el código del pedido
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Define un mensaje de respuesta SAP
        /// </summary>
        public string RespuestaSAP { get; set; }
    }
}
