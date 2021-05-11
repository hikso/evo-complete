namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 04-Feb/2019
    /// Descripción     : Clase que representa un artículo de la entrega
    /// </summary>
    public class ObtenerViajeEntregasRespuestaArticulos
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>     
        public string Codigo { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>
       
        public string Nombre { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Estado del artículo</value>
      
        public string Estado { get; set; }

        /// <summary>
        /// Cantidad
        /// </summary>
        /// <value>Cantidad</value>
     
        public string Cantidad { get; set; }

        /// <summary>
        /// Unidad de medida
        /// </summary>
        /// <value>Unidad de medida</value>
      
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Observaciones
        /// </summary>
        /// <value>Observaciones</value>
      
        public string Observaciones { get; set; }

        /// <summary>
        /// Observación
        /// </summary>
        /// <value></value>       
        public string Observacion { get; set; }
    }
}
