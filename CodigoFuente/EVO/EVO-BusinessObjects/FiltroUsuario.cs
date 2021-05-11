namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 23-Ago/2019
    /// Descripción      : Esta clase contiene las propiedades de los filtros de Usuarios
    /// </summary>
    public class FiltroUsuario
    {
        /// <summary>
        /// Indica desde que registro se debe cargar la consulta
        /// </summary>
        public int Desde { get; set; }

        /// <summary>
        /// Indica hasta que registro se debe cargar la consulta
        /// </summary>
        public int Hasta { get; set; }

        /// <summary>
        /// Indica el id del rol
        /// </summary>
        public int rolId { get; set; }

        /// <summary>
        /// Indica el filtro por nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Indica el filtro por usuario
        /// </summary>
        public string Usuario { get; set; }
    }
}