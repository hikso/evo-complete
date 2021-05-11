using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga S
    /// Fecha de Creación: 12-Ago/2019
    /// Descripción      : Esta clase representa un Registro de Módulo
    /// </summary>
    public class Modulo
    {
        /// <summary>
        /// Id de Módulo
        /// </summary>
        public int ModuloId { get; set; }
        
        /// <summary>
        /// Nombre del Módulo
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Define si el registro se encuentra activo o inactivo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Coleccón de funcionalidades
        /// </summary>
        public List<Funcionalidad> Funcionalidades { get; set; }
    }
}