using System;

namespace EVO_BusinessObjects
{
    public class InventarioBO
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public int InventarioId { get; set; }

        /// <summary>
        /// Define la clave foránea a TipoInventario
        /// </summary>     
        public int TipoInventarioId { get; set; }      

        /// <summary>
        /// Define la clave foránea a Procesos
        /// </summary>      
        public int ProcesoId { get; set; }      

        /// <summary>
        /// Define la clave foránea a PesajesArticulo
        /// </summary>
        public int? PesajeArticuloId { get; set; }       

        /// <summary>
        /// Define la clave foránea a DetalleFactura
        /// </summary>      
        public int? DetalleFacturaId { get; set; }

        /// <summary>
        /// Define la fecha de registro
        /// </summary>
        public DateTime FechaRegistro { get; set; }
    }
}
