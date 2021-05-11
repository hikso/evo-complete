namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 9-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo Pesaje Contenedor Solicitud
    /// </summary>
    public class PesajeContenedor
    {
        /// <summary>
        /// Id del tipo de contenedor
        /// </summary>
        /// <value>Id del tipo de contenedor</value>
      
        public int TipoContenedorId { get; set; }

        /// <summary>
        /// nombre del tipo de contenedor
        /// </summary>
        /// <value>nombre del tipo de contenedor</value>
      
        public string NombreTipoContenedor { get; set; }

        /// <summary>
        /// Cantidad del contenedor
        /// </summary>
        /// <value>Cantidad del contenedor</value>    
        public int Cantidad { get; set; }
    }
}
