using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 22-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de PesajeArticulo
    /// </summary>
    public class BOPesajeArticulo
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>       
        public int PesajeArticuloId { get; set; }

        /// <summary>
        /// Define la clave foránea de PesajesEntrega
        /// </summary>      
        public int PesajeEntregaId { get; set; }       

        /// <summary>
        /// Define la clave foránea de DetalleEntrega
        /// </summary>       
        public int DetalleEntregaId { get; set; }

        /// <summary>
        /// Define la cantidad recibida
        /// </summary>       
        public decimal? CantidadRecibida { get; set; }

        /// <summary>
        /// Define si el artículo de la entrega fue pesado en su totalidad
        /// </summary>
        public bool? PesajeFinalizado { get; set; }

        /// <summary>
        /// Id del documento
        /// </summary>       
        public int? DocumentoId { get; set; }       

        /// <summary>
        /// Indica si existen inconsistencia en el pesaje y los códigos de barras
        /// </summary>       
        public bool? InconsistenciaCodigoBarras { get; set; }

        public BODocumento Documento { get; set; }

        public List<BOPesaje> Pesajes { get; set; }
        public DetalleEntrega DetalleEntrega { get; set; }
       
    }
}
