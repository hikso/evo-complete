using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{

    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 21-Oct/2019
    /// Descripción     : Clase que representa un objeto de negocio de una Bodega
    /// </summary>
    public class BOBodega
    {
        /// <summary>
        /// Indica el código de la bodega
        /// </summary>
        public string WhsCode { get; set; }      
        
        /// <summary>
        /// Indica el nombre de la bodega
        /// </summary>
        public string WhsName { get; set; }

        /// <summary>
        /// Indica el email al cual se va enviar
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Define el porcentaje de descuento para facturación
        /// </summary>
        /// <value>50</value>    
        public decimal? FacturacionPorcentajeDescuento { get; set; }

        /// <summary>
        /// Cantidad de pedidos tipo borrador por bodega
        /// </summary>
        /// <value>4</value>    
        public int? CantidadPedidosBorradorxBodega { get; set; }

        /// <summary>
        /// Identifica si una bodega es nueva o no.
        /// </summary>
        public bool Nuevo { get; set; }

    }
}
