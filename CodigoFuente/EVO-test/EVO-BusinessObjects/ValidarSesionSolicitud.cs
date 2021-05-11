using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 26-Ago/2019
    /// Descripción      : Esta clase representa una validación de solicitud de sesión.
    /// </summary>
    public class ValidarSesionSolicitud
    {
        /// <summary>
        /// Token de la sesión
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// IP de equipo que solicitó iniciar sesión
        /// </summary>
        public string IP { get; set; }

    }
}
