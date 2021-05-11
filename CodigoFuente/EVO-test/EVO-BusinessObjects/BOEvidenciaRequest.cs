using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 26-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de EvidenciaRequest
    /// </summary>
    public class BOEvidenciaRequest
    {
        /// <summary>
        /// Id del pesaje entrega
        /// </summary>
        /// <value>Id del pesaje entrega</value>      
        public int PesajeEntregaId { get; set; }

        /// <summary>
        /// Identificador unico de la evidencia
        /// </summary>
        /// <value>Identificador unico de la evidencia</value>
        public string GUID { get; set; }

        /// <summary>
        /// Observaciones de la evidencia
        /// </summary>
        /// <value>Observaciones de la evidencia</value>
        public string Observaciones { get; set; }

        /// <summary>
        /// Usuario del usuario
        /// </summary>
        /// <value>Usuario del usuario</value>
        public string Usuario { get; set; }

        /// <summary>
        /// Id del usuario
        /// </summary>
        /// <value>Id del usuario</value>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Fecha de la evidencia
        /// </summary>
        /// <value>12/12/2020</value>
        public DateTime FechaEvidencia { get; set; }        

        /// <summary>
        /// Gets or Sets Detalles
        /// </summary>
        public List<BOArchivoRequest> Detalles { get; set; }
      
    }
}
