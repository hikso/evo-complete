using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 26-Ago/2019
    /// Descripción      : Esta clase representa una validación de respuesta de sesión.
    /// </summary>
    public class ValidarSesionRespuesta
    {
        /// <summary>
        /// Fecha de expiración de la sesión
        /// </summary>
        public DateTime FechaExpiracion { get; set; }

        /// <summary>
        /// Respuesta de la solicitud
        /// </summary>
        public bool sesionValida { get; set; }
    }
}
