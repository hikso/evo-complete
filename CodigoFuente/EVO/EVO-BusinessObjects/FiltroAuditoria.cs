namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 08-Ago/2019
    /// Descripción      : Esta clase contiene las propiedades de los filtros de auditoria
    /// </summary>
    public class FiltroAuditoria
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
        /// Indica el filtro por usuario
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Indica el filtro por fecha
        /// </summary>
        public string Fecha { get; set; }

        /// <summary>
        /// Indica el filtro por acción
        /// </summary>
        public string Accion { get; set; }

        /// <summary>
        /// Indica el filtro de parámetros
        /// </summary>
        public string Parametros { get; set; }

        /// <summary>
        /// Indica el filtro por IP
        /// </summary>
        public string IP { get; set; }
    }
}