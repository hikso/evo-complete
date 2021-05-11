namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 23-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio BOContenedorRequest
    /// </summary>
    public class BOContenedorRequest
    {
        /// <summary>
        /// Id del tipo de contenedor
        /// </summary>
        /// <value>Id del tipo de contenedor</value>       
        public int TipoContenedorId { get; set; }

        /// <summary>
        /// Cantidad del contenedor
        /// </summary>
        /// <value>Cantidad del contenedor</value>      
        public int Cantidad { get; set; }
    }
}
