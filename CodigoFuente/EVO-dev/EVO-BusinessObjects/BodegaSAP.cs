namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 05-Ene/2021
    /// Descripción     : Clase que representa un objeto de negocio de una bodega en SAP
    /// </summary>
    public class BodegaSAP
    {
        /// <summary>
        /// Define el código de la bodega
        /// </summary>
        public string WhsCode { get; set; }

        /// <summary>
        /// Define el nombre de la bodega
        /// </summary>
        public string WhsName { get; set; }
    }
}
