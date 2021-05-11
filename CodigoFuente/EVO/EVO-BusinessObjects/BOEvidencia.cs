using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    public class BOEvidencia
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>     
        public int EvidenciaId { get; set; }

        /// <summary>
        /// Define la clave foránea de PesajesEntrega
        /// </summary>       
        public int PesajeEntregaId { get; set; }      

        /// <summary>
        /// Define la clave foránea del usuario
        /// </summary>     
        public int UsuarioId { get; set; }

        public BOUsuario Usuario { get; set; }

        /// <summary>
        /// Define el GUID que sera el nombre del directorio de las evidencias
        /// </summary>      
        public string GUID { get; set; }

        /// <summary>
        /// Define las observaciones de la evidencia
        /// </summary>        
        public string Observaciones { get; set; }

        /// <summary>
        /// Define la fecha de la evidencia
        /// </summary>        
        public DateTime FechaEvidencia { get; set; }

        public List<BODetalleEvidencia> DetallesEvidencia { get; set; }
    }
}
