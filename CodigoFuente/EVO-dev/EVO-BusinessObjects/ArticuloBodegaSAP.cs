namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 06-Ene/2021
    /// Descripción     : Clase que representa un objeto de negocio de un artículo en una bodega en SAP
    /// </summary>
    public class ArticuloBodegaSAP
    {
        /// <summary>
        /// Define el artículo
        /// </summary>
        public ArticuloSAP ArticuloSAP { get; set; }

        /// <summary>
        /// Define la bodega
        /// </summary>
        public BodegaSAP BodegaSAP { get; set; }

        /// <summary>
        /// Define el stock
        /// </summary>
        public string OnHand { get; set; }

        /// <summary>
        /// Define el mínimo
        /// </summary>
        public string MinStock { get; set; }

        /// <summary>
        /// Define el máximo
        /// </summary>
        public string MaxStock { get; set; }
    }
}
