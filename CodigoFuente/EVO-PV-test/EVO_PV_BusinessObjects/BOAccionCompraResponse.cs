using System.Collections.Generic;

namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 27-Ago/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo AccionCompraResponse
    /// </summary>
    public class BOAccionCompraResponse
    {
        /// <summary>
        /// Id de la acción de compra
        /// </summary>
        /// <value>Id de la acción de compra</value>      
        public int AccionId { get; set; }

        /// <summary>
        /// Nombre de la acción de compra
        /// </summary>
        /// <value>Nombre de la acción de compra</value>      
        public string NombreAccion { get; set; }

        /// <summary>
        /// Artículos asociados a las gestiones de compra del pedido
        /// </summary>
        /// <value>Artículos asociados a las gestiones de compra del pedido</value>      
        public List<BOArticuloAccionCompraResponse> Articulos { get; set; }
    }
}
