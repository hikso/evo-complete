namespace EVO_PB.Models.BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 07-Ene/2020
    /// Descripción      : Esta clase representa un Registro de Usuario EVO
    /// </summary>
    public class BOUser
    {
        /// <summary>
        /// Id de el registro
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Usuario del Usuario
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        public string Name { get; set; }
        
    }
}