namespace EVO_PV_BusinessObjects
{
    public class ArticuloBodega
    {
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public string WhsCode { get; set; }
        public decimal? Stock { get; set; }
        public decimal? Minimo { get; set; }
        public decimal? Maximo { get; set; }
        public string UnidadMedida { get; set; }
        public decimal? PedidoSugerido { get; set; }
    }
}
