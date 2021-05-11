using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    public class AlistamientoArticulo
    {
        public int AlistamientoArticuloId { get; set; }

        /// <summary>
        /// Define la clave foránea de Alistamiento
        /// </summary>       
        public int AlistamientoId { get; set; }

        /// <summary>
        /// Define la clave foránea de DetalleEntrega
        /// </summary>      
        public int DetalleEntregaId { get; set; }
        /// <summary>
        /// Define si el artículo de la entrega fue pesado en su totalidad
        /// </summary>      
        public bool PesajeFinalizado { get; set; } = false;//Por defecto.  

        /// <summary>
        /// Define la cantidad pendiente del pesaje de este artículo
        /// </summary>

        public decimal CantidadPendiente { get; set; }

        public List<AlistamientoPesaje> AlistamientosPesaje { get; set; }

    }
}
