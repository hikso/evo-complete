namespace EVO_PV.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 30-Dic/2019
    /// Descripción     : Clase que representa un objeto de negocio de tipo almacen
    /// </summary>
    public class BOWareHouse
    {
        /// <summary>
        /// Código bodega
        /// </summary>
        /// <value>Código almacen</value>       
        public string WhsCode { get; set; }

        /// <summary>
        /// Nombre bodega
        /// </summary>
        /// <value>Nombre almacen</value>       
        public string WhsName { get; set; }


        /// <summary>
        /// email bodega
        /// </summary>
        /// <value>email bodega</value>
        public string Email { get; set; }

        /// <summary>
        /// Porcentaje de descuento para la factura
        /// </summary>
        /// <value>Porcentaje de descuento para la factura</value>
        public string InvoiceDiscountPercent { get; set; }
    }
}
