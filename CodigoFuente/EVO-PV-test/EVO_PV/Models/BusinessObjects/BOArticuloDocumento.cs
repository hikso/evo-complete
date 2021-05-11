namespace EVO_PV.Models.BusinessObjects
{
    public class BOArticuloDocumento
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>
        public string ArticleCode { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Estado del artículo</value>
        public string ArticleState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ArticleName { get; set; }

        /// <summary>
        /// Id del documento
        /// </summary>
        /// <value>Id del documento</value>
        public int DocumentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Document { get; set; }

        /// <summary>
        /// Nombre del documento
        /// </summary>
        /// <value>Nombre del documento</value>
        public string DocumentName { get; set; }

    }
}
