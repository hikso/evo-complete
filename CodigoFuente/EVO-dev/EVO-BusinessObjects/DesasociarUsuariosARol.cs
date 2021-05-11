using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 14-Ago/2019
    /// Descripción      : Esta clase representa una desasociación de un usuario de un rol
    /// </summary>
    public class DesasociarUsuariosARol
    {
        /// <summary>
        /// Id de el rol
        /// </summary>
        public int RolId { get; set; }

        /// <summary>
        /// Ids de los usuarios
        /// </summary>
        public List<int> UsuariosIds { get; set; }        

    }
}