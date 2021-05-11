using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 20-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de PesajeEntrega
    /// </summary>
    public class BOPesajeEntrega
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
        /// Define la clave foránea de EstadoEntrega
        /// </summary>       
        public int EstadoEntregaId { get; set; }

        /// <summary>
        /// Define la clave foránea de Entrega
        /// </summary>     
        public int EntregaId { get; set; }

        public BOEntrega Entrega { get; set; }

        /// <summary>
        /// Define si se genera el documento de salida de mercancia
        /// </summary>      
        public bool? SalidaMercancia { get; set; }

        /// <summary>
        /// Define se se genera el documento de mercancia en exceso
        /// </summary>       
        public bool? MercanciaExceso { get; set; }

        /// <summary>
        /// Define si ya finalizó el proceso
        /// </summary>       
        public bool? Finalizado { get; set; }

        public List<BOPesajeArticulo> PesajesArticulo { get; set; }
    }
}
