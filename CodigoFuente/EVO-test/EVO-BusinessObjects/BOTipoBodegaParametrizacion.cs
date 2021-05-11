namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor                  : Juan Camilo Usuga Sepúlveda
    /// Fecha de creación      : 23-Jul/2020    
    /// Descripción            : Objecto de negocio de tipo EFTipoBodegaParametrizacion
    /// </summary> 
    public class BOTipoBodegaParametrizacion
    {
        public int TipoBodegaParametrizacionId { get; set; }

        public string PrefijoBodega { get; set; }

        public string CodigoBodega { get; set; }

        public int CantidadPedidosBorrador { get; set; }
    }
}
