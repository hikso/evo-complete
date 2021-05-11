using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 19-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio PesajeEntrega
    /// </summary>
    public class PesajeEntrega
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>       
        public int PesajeEntregaId { get; set; }

        /// <summary>
        /// Define la fecha del pesaje
        /// </summary>      
        public DateTime FechaPesaje { get; set; }

        /// <summary>
        /// Define el consecutivo
        /// </summary>       
        public int Consecutivo { get; set; }

        /// <summary>
        /// Define la clave foránea de EstadoEntregaId
        /// </summary>    
        public int EstadoEntregaId { get; set; }

        /// <summary>
        /// Define la clave foránea de EntregaId
        /// </summary>      
        public int EntregaId { get; set; } 
       
    }
}
