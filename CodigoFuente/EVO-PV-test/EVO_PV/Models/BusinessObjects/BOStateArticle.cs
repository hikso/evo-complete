namespace EVO_PV.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 14-Ene/2020
    /// Descripción     : Clase que representa un objeto de negocio del estado del artículo
    /// </summary>
    public class BOStateArticle
    {
        /// <summary>
        /// Id del estado del artículo
        /// </summary>
        /// <value>1</value>      
        public int StateArticleId { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Borrador</value>      
        public string Name { get; set; }
    }
}
