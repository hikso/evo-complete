namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 08-Ago/2019
    /// Descripción      : Esta clase contiene las propiedades de los filtros de roles
    /// </summary>
    public class FiltroRol
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
        /// Indica el filtro por nombre
        /// </summary>
        public string Nombre { get; set; }
    }
}