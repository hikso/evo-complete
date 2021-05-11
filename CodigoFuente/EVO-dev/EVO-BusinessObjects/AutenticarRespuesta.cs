using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga S
    /// Fecha de Creación: 26-Ago/2019
    /// Descripción      : Esta clase representa una respuesta de autenticación
    /// </summary>
    public class AutenticarRespuesta
    {
        /// <summary>
        /// Token de la sesión
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Respuesta de la autenticación
        /// </summary>
        public bool estaAutenticado { get; set; }

        /// <summary>
        /// Fecha de expiración de la sesión 
        /// </summary>
        public DateTime FechaExpiracion { get; set; }
    }
}
