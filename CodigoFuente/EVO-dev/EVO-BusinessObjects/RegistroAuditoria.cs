using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Kevin Restrepo
    /// Fecha de Creación: 30-Jul/2019
    /// Descripción      : Esta clase representa un Registro de Auditoria
    /// </summary>
    public class RegistroAuditoria
    {
        /// <summary>
        /// Id de el registro
        /// </summary>
        public int RegistroAuditoriaId { get; set; }

        /// <summary>
        /// Fecha del registro
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Usuario de el registro
        /// </summary>
        public string Usuario { get; set; }       

        /// <summary>
        /// Accion de el registro
        /// </summary>
        public string Accion { get; set; }

        /// <summary>
        /// Parámetros del registro
        /// </summary>
        public string Parametros { get; set; }

        /// <summary>
        /// IP de el registro
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Id del usuario
        /// </summary>
        public int UsuarioId { get; set; }
    }
}