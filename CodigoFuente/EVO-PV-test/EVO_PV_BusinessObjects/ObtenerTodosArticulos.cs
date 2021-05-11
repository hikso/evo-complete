namespace EVO_PV_BusinessObjects
{
    public class ObtenerTodosArticulos
    {
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public string UnidadMedida { get; set; }
        public string Stock { get; set; }
        public string Minimo { get; set; }
        public string Maximo { get; set; }
        public string PedidoSugerido { get; set; }      
        public int EstadoId { get; set; }       
        public int EmpaqueId { get; set; }

    }
}
