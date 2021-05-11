namespace EVO_PV_BusinessObjects
{
    public class ObtenerDetallesPedido
    {
        public int DetallePedidoId { get; set; }
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public int EstadoArticulo { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public string PedidoSugerido { get; set; }
        public string Stock { get; set; }
        public string StockMinimo { get; set; }
        public string StockMaximo { get; set; }
    }
}
