using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 04-Feb/2019
    /// Descripción     : Clase que representa una entrega del viaje
    /// </summary>
    public class ObtenerViajeEntregasRespuestaEntregas
    {
        /// <summary>
        /// Número de la entrega
        /// </summary>
        /// <value>Número de la entrega</value>

        public string NumeroEntrega { get; set; }

        /// <summary>
        /// Número del pedido
        /// </summary>
        /// <value>Número del pedido</value>

        public string NumeroPedido { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>

        public string Cliente { get; set; }

        /// <summary>
        /// Para cliente externo es NIT y para interno es el código bodega
        /// </summary>
        /// <value>Para cliente externo es NIT y para interno es el código bodega</value>

        public string Codigo { get; set; }

        /// <summary>
        /// Zona del cliente
        /// </summary>
        /// <value>Zona del cliente</value>

        public string Zona { get; set; }

        /// <summary>
        /// Fecha entrega
        /// </summary>
        /// <value>Fecha entrega</value>

        public string FechaEntrega { get; set; }

        /// <summary>
        /// Hora militar de la entrega
        /// </summary>
        /// <value>Hora militar de la entrega</value>

        public string HoraEntrega { get; set; }

        /// <summary>
        /// Peso de la cantidad de los artículo
        /// </summary>
        /// <value>Peso de la cantidad de los artículo</value>

        public string Cantidad { get; set; }

        /// <summary>
        /// Unidades solicitadas por artículo
        /// </summary>
        /// <value>Unidades solicitadas por artículo</value>

        public string Unidades { get; set; }

        /// <summary>
        /// Lista de artículos de la entrega
        /// </summary>
        /// <value>Lista de artículos de la entrega</value>

        public List<ObtenerViajeEntregasRespuestaArticulos> Articulos { get; set; }
    }
}
