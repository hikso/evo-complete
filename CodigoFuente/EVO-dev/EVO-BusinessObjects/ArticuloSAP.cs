namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 05-Ene/2021
    /// Descripción     : Clase que representa un objeto de negocio de un artículo en SAP
    /// </summary>
    public class ArticuloSAP
    {
        /// <summary>
        /// Define el código del artículo
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// Define el nombre del artículo
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Define la unidad de medida del artículo
        /// </summary>
        public string SalUnitMsr { get; set; }
       
    }
}
