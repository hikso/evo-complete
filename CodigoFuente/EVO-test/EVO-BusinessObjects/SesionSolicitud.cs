using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 27-Ago/2019
    /// Descripción      : Esta clase representa una Sesión de solicitud del usuario
    /// </summary>
    public class SesionSolicitud
    {
        /// <summary>
        /// Token de la sesión
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// IP de equipo que solicitó iniciar sesión
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Fecha de expiración de la sesión
        /// </summary>
        public DateTime FechaExpiracion { get; set; }

        /// <summary>
        /// Id del usuario
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Fecha de inicio de la sesión
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Id de la sesión
        /// </summary>
        public int SesionId { get; set; }        

    }
}