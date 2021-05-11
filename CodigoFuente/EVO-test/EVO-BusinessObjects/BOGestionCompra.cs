

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 02-Sep/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo GestionCompra
    /// </summary>
    public class BOGestionCompra
    {
        /// <summary>
        /// Define la clave primaria de Gestión compra
        /// </summary>
        public int GestionCompraId { get; set; }

        /// <summary>
        /// Define la clave foránea a DetallesPedido
        /// </summary>    
        public int DetallePedidoId { get; set; }

        /// <summary>
        /// Define la cantidad solicitada menos las cantidades ya gestionadas en la otras acciones
        /// </summary>
        public decimal CantidadSolicitadaFaltante { get; set; }

        /// <summary>
        /// Define la clave foránea a Acciones
        /// </summary>  
        public int AccionId { get; set; }

        /// <summary>
        /// Define la cantidad a gestionar la compra
        /// </summary>  
        public decimal Cantidad { get; set; }
      
        /// <summary>
        /// Define la orden de compra
        /// </summary>  
        public string OrdenCompra { get; set; }

        /// <summary>
        /// Define si se actualiza
        /// </summary>  
        public bool Actualizar { get; set; } = false;

        /// <summary>
        /// Define si es nuevo
        /// </summary>  
        public bool Nuevo { get; set; } = false;
        public string CodigoArticulo { get; set; }
    }
}
