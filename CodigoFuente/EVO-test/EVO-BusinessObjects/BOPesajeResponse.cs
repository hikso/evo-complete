namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 08-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de un Pesaje
    /// </summary>
    public class BOPesajeResponse
    {
        /// <summary>
        /// Id del pesaje
        /// </summary>
        /// <value>Id del pesaje</value>       
        public int PesajeId { get; set; }

        /// <summary>
        /// Peso de la báscula
        /// </summary>
        /// <value>Peso de la báscula</value>       
        public decimal PesoBascula { get; set; }

        /// <summary>
        /// Peso del artículo
        /// </summary>
        /// <value>Peso del artículo</value>       
        public decimal PesoArticulo { get; set; }
    }
}
