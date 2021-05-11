using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 07-Ene/2019
    /// Descripción      : Esta clase representá una respuesta del Usuario que está en usuarios EVO
    /// </summary>
    public class UsuarioRespuesta
    {
        /// <summary>
        /// Id de el registro
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Usuario del Usuario
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        public string Nombre { get; set; }    

    }
}