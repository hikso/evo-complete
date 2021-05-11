namespace EVO_BusinessObjects
{

    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 12-Abr/2020
    /// Descripción      : Clase que representa un objeto de negocio de tipo Inconsistencia
    /// </summary>
    public class BOInconsistencia
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public int InconsistenciaId { get; set; }

        /// <summary>
        /// Define el nombre de la inconsistencia
        /// </summary>
        public string Nombre { get; set; }
       
    }
}
