namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 19-Dic/2019
    /// Descripción     : Clase que representa un objeto de negocio de un VehiculoEntregaDetalle
    /// </summary>
    public class VehiculoEntregaDetalle
    {
        /// <summary>
        /// Id del detalle 
        /// </summary>
        public int VehiculoEntregaDetalleId { get; set; }

        /// <summary>
        /// Id del encabezado 
        /// </summary>
        public int VehiculoEntregaId { get; set; }

        /// <summary>
        ///  Id de la entrega
        /// </summary>
        public int EntregaId { get; set; }

        public Entrega Entrega { get; set; }
    }
}
