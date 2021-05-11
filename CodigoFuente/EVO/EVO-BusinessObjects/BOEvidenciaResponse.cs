using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 083-Abr/2020
    /// Descripción     : Clase que representa un objeto de negocio evidencias response
    /// </summary>
    public class BOEvidenciaResponse
    {
        /// <summary>
        /// Id de la evidencia
        /// </summary>
        /// <value>Id de la evidencia</value>      
        public int EvidenciaId { get; set; }

        /// <summary>
        /// Nombre de punto de venta
        /// </summary>
        /// <value>Nombre de punto de venta</value>       
        public string PuntoVenta { get; set; }

        /// <summary>
        /// Número del pedido
        /// </summary>
        /// <value>Número del pedido</value>       
        public string NumeroPedido { get; set; }

        /// <summary>
        /// Número de la entrega
        /// </summary>
        /// <value>Número de la entrega</value>       
        public string NumeroEntrega { get; set; }

        /// <summary>
        /// Fecha de la evidencia
        /// </summary>
        /// <value>Fecha de la evidencia</value>       
        public string FechaEvidencia { get; set; }

        /// <summary>
        /// Fwcha de la entrega
        /// </summary>
        /// <value>Fecha de la entrega</value>       
        public DateTime FechaEntrega { get; set; }
    }
}
