using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 21-Sep/2019
    /// Descripción     : Clase que representa un objeto de negocio de un EstadoArticulo
    /// </summary>
    public class BOEstadoArticulo
    {
        /// <summary>
        /// Indica el id del estado del artículo 
        /// </summary>
        public int EstadoArticuloId { get; set; }      

        /// <summary>
        /// Indica el nombre del estado del pedido
        /// </summary>
        public string Nombre { get; set; }      

        /// <summary>
        /// Indica si el pedido se encuentra activo
        /// </summary>
        public bool Activo { get; set; } = true;      
    }
}
