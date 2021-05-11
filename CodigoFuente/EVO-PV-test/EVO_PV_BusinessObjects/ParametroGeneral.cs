namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga S
    /// Fecha de Creación: 08-Ago/2019
    /// Descripción      : Esta clase representa un Parámetro General
    /// </summary>
    public class ParametroGeneral
    {
        /// <summary>
        /// Id del Parámetro General
        /// </summary>
        public int ParametroGeneralId { get; set; }

        /// <summary>
        /// Nombre del Parámetro General
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Valor del Parámetro General
        /// </summary>
        public string Valor { get; set; }

        /// <summary>
        /// Define si el registro se encuentra activo o inactivo
        /// </summary>
        public bool Activo { get; set; }
    }
}