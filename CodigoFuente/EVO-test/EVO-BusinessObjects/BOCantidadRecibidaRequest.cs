namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 24-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de CantidadRecibidaRequest
    /// </summary>
    public class BOCantidadRecibidaRequest
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>       
        public string CodigoArticulo { get; set; }       

        /// <summary>
        /// Id de la entrega
        /// </summary>
        /// <value>Id de la entrega</value>       
        public int EntregaId { get; set; }

        /// <summary>
        /// Id del detalle de la entrega
        /// </summary>
        /// <value>Id del detalle de la entrega</value>       
        public int DetalleEntregaId { get; set; }

        /// <summary>
        /// Cantidad recibida con unidad de medida por unidad
        /// </summary>
        /// <value>Cantidad recibida con unidad de medida por unidad</value>       
        public decimal CantidadRecibida { get; set; }

        /// <summary>
        /// Usuario del usuario
        /// </summary>
        /// <value>Usuario del usuario</value>       
        public string Usuario { get; set; }

        /// <summary>
        /// UsuarioId del usuario
        /// </summary>
        /// <value>UsuarioId del usuario</value>  
        public int UsuarioId { get; set; }
    }
}
