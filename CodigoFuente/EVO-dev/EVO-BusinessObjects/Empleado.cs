namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 19-Dic/2019
    /// Descripción     : Clase que representa un objeto de negocio de un Empleado
    /// </summary>
    public class Empleado
    {
        /// <summary>
        /// Id del empleado
        /// </summary>
        /// <value>Id del empleado</value>       
        public int EmpleadoId { get; set; }

        /// <summary>
        /// Nombres
        /// </summary>
        /// <value>Nombres</value>      
        public string Nombres { get; set; }

        /// <summary>
        /// Apellidos
        /// </summary>
        /// <value>Apellidos</value>      
        public string Apellidos { get; set; }

        /// <summary>
        /// Cédula
        /// </summary>
        /// <value>Cédula</value>       
        public string Cedula { get; set; }

        /// <summary>
        /// Tipo de cargo
        /// </summary>
        /// <value>Tipo de cargo</value>       
        public string Cargo { get; set; }
    }
}
