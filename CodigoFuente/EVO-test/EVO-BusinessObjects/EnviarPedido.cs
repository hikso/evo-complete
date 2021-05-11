using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 27-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio EnviarPedido
    /// </summary>
    public class EnviarPedido
    {
        public string PuntoVenta { get; set; }

        public string NumeroPedido { get; set; }

        public string EstadoPedido { get; set; }

        public string Usuario { get; set; }

        public string Nombre { get; set; }

        public List<string> Articulos { get; set; }

    }
}
