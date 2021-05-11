using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga S
    /// Fecha de Creación: 26-Ago/2019
    /// Descripción      : Esta clase representa una solicitud de autenticación
    /// </summary>
    public class AutenticarSolicitud
    {
        /// <summary>
        /// Usuario del Usuario
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Dominio del Usuario
        /// </summary>
        public string Dominio { get; set; }

        /// <summary>
        /// Id Usuario
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Token de la sesión
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Fecha de inicio de la sesión
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha de expiración de la sesión
        /// </summary>
        public DateTime FechaExpiracion { get; set; }

        /// <summary>
        /// IP del equipo que solicitó iniciar sesión
        /// </summary>
        public string IP { get; set; }

    }
}
