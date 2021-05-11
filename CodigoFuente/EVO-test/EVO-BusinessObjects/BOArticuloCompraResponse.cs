namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 27-Ago/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo ArticuloCompraResponse
    /// </summary>
    public class BOArticuloCompraResponse
    {
        /// <summary>
        /// Id del detalle del pedido
        /// </summary>
        /// <value>Id del detalle del pedido</value>      
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>     
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>       
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Cantidad solicitada
        /// </summary>
        /// <value>Cantidad solicitada</value>        
        public string CantidadSolicitada { get; set; }

        /// <summary>
        /// Unidad de medida del artículo
        /// </summary>
        /// <value>Unidad de medida del artículo</value>       
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Cantidad a gestionar
        /// </summary>
        /// <value>Cantidad a gestionar</value>       
        public string CantidadGestionar { get; set; }

        /// <summary>
        /// Stock del almacen de compras de este artículo
        /// </summary>
        /// <value>Stock del almacen de compras de este artículo</value>        
        public string StockAlmacen { get; set; }

        /// <summary>
        /// Observaciones del artículo
        /// </summary>
        /// <value>Observaciones del artículo</value>      
        public string Observaciones { get; set; }

        /// <summary>
        /// Cantidad faltante a gestionar
        /// </summary>
        /// <value>Cantidad a gestionar</value>       
        public string CantidadFaltanteGestionar { get; set; }

        /// <summary>
        /// Si ya fué gestionado no se retorna al cliente
        /// </summary>
        /// <value>true</value>       
        public bool Incluir { get; set; } = true;

        /// <summary>
        /// Cantidad comprometida del artículo
        /// </summary>
        /// <value>37500.000000</value>        
        public decimal CantidadComprometida { get; set; }
    }
}
