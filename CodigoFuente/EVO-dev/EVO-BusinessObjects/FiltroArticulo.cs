using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Duban Cardona
    /// Fecha de Creación: 22-Ago/2019
    /// Descripción      : Esta clase contiene las propiedades de los filtros de artículos
    /// </summary>

    public class FiltroArticulo
    {
        /// <summary>
        /// Indica desde que registro se debe cargar la consulta
        /// </summary>
        public int Desde { get; set; }

        /// <summary>
        /// Indica hasta que registro se debe cargar la consulta
        /// </summary>
        public int Hasta { get; set; }

        /// <summary>
        /// Indica el código del articulo
        /// </summary>
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Indica el Nombre del articulo
        /// </summary>
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Indica el stock
        /// </summary>
        public string Stock { get; set; }

        /// <summary>
        /// Indica el minimo
        /// </summary>
        public string Minimo { get; set; }

        /// <summary>
        /// Indica el maximo
        /// </summary>
        public string Maximo { get; set; }

        /// <summary>
        /// Código de la bodega
        /// </summary>
        public string WhsCode { get; set; }

    }
}
