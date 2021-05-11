using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Kevin Restrepo
    /// Fecha de Creación: 01-Ago/2019
    /// Descripción      : Esta clase representa un Registro de Usuario
    /// </summary>
    public class Usuario
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

        /// <summary>
        /// Define la identificación del usuario
        /// </summary>       
        public string Identificacion { get; set; }

        /// <summary>
        /// Define si el Usuario está activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Nombres de los cargos(roles) del usuario
        /// </summary>
        /// <value>Nombres de los cargos(roles) del usuario</value>       
        public List<string> Cargos { get; set; }
    }
}