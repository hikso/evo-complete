namespace EVO_PV.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 27-Oct/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo auditoria
    /// </summary>
   public  class BOAudit
    {
        /// <summary>
        /// Acción que está siendo auditada
        /// </summary>
        /// <value>Acción que está siendo auditada</value>      
        public string Action { get; set; }

        /// <summary>
        /// Objeto serializado en formato JSON que contiene los parámetros de la acción
        /// </summary>
        /// <value>Objeto serializado en formato JSON que contiene los parámetros de la acción</value>      
        public string Parameters { get; set; }
    }
}
