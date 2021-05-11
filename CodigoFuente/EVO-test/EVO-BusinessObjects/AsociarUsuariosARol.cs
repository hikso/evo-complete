using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 14-Ago/2019
    /// Descripción      : Esta clase representa una asosociación de un usuario a un rol
    /// </summary>
    public class AsociarUsuariosARol
    {
        /// <summary>
        /// Id de el rol
        /// </summary>
        public int RolId { get; set; }

        /// <summary>
        /// List de usuarios a asociar
        /// </summary>
        public List<Usuario> Usuarios { get; set; }
      
    }
}