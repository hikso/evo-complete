using System;

namespace EVO_BusinessObjects
{
    public class BOPesajeCodigoBarras
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public int PesajeCodigoBarrasId { get; set; }

        /// <summary>
        /// Define la clave foránea a Pesajes
        /// </summary>     
        public int PesajeId { get; set; }

        /// <summary>
        /// Define el código de barras del contenedor
        /// </summary>
        public string CodigoBarras { get; set; }

        /// <summary>
        /// Define el lote de donde fué sacado el contenedor
        /// </summary>
        public string Lote { get; set; }

        /// <summary>
        /// Define la fecha de vencimiento de los artículos del contenedor
        /// </summary>
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// Define la unidades del artículo del contenedor
        /// </summary>
        public int Unidades { get; set; }

        /// <summary>
        /// Define el peso que suman los artículos del contenedor
        /// </summary>
        public decimal Peso { get; set; }

        /// <summary>
        /// Define la clave foránea del usuario
        /// </summary>       
        public int UsuarioId { get; set; }
        
    }
}
