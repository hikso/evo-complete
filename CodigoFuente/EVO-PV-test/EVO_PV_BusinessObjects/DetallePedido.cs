namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 20-Sep/2019
    /// Descripción      : Esta clase representa un detalle pedido
    /// </summary>
    public class DetallePedido
    {

        public int DetallePedidoId { get; set; }
        public string ItemCode { get; set; }
        public string NombreArticulo { get; set; }
        public int EstadoArticulo { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public string PedidoSugerido { get; set; }
        public string Stock { get; set; }
        public string StockMinimo { get; set; }
        public string StockMaximo { get; set; }      
        public string Observacion { get; set; }       
        public int EmpaqueId { get; set; }
    }
}