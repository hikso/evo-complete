namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 11-Sep/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo ArticuloPendienteCompraResponse
    /// </summary>
    public class BOArticuloPendienteCompraResponse
    {

        /// <summary>
        /// Id del detalle de pedido
        /// </summary>
        /// <value>Id del detalle de pedido</value>
                                                              
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
                                                               
        public string Nombre { get; set; }

        /// <summary>
        /// Cantidad solicitada
        /// </summary>
        /// <value>Cantidad solicitada</value>
                                                                 
        public string CantidadSolicitada { get; set; }

        /// <summary>
        /// Unidad de medida
        /// </summary>
        /// <value>Unidad de medida</value>
                                                             
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Cantidad gestionar
        /// </summary>
        /// <value>Cantidad gestionar</value>
                                                               
        public string CantidadGestionar { get; set; }

        /// <summary>
        /// Stock del almacen
        /// </summary>
        /// <value>Stock del almacen</value>
                                                               
        public string StockAlmacen { get; set; }

        /// <summary>
        /// Orden de compra
        /// </summary>
        /// <value>Orden de compra</value>
                                                                
        public string OrdenCompra { get; set; }

        /// <summary>
        /// Observaciones
        /// </summary>
        /// <value>Observaciones</value>
                                                               
        public string Observaciones { get; set; }

        /// <summary>
        /// Incluir
        /// </summary>
        /// <value>True</value>

        public bool Incluir { get; set; } = true;

        /// <summary>
        /// Cantidad faltante de gestionar
        /// </summary>
        /// <value>12000</value>
        public string CantidadFaltanteGestionar { get; set; }

        
    }
}
