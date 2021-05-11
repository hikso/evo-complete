using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Duban Cardona
    /// Fecha de Creación: 20-Ago/2019
    /// Descripción      : Clase que representa un objeto de negocio de UnidadMedida
    /// </summary>
    public class UnidadMedida
    {
        /// <summary>
        /// Indica el id de la  unidad de medida
        /// </summary>
        public int UnidadMedidaId { get; set; } 
        
        /// <summary>
        /// Indica el nombre de la unidad de medida 
        /// </summary>
        public string Nombre { get; set; }       

        /// <summary>
        /// Indica el código de la unidad de medida
        /// </summary>
        public string Codigo { get; set; }       

        /// <summary>
        /// Indica si el pedido esta activo
        /// </summary>
        public bool Activo { get; set; } = true;
    }
}
