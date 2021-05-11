using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Aholguin 
    /// Fecha de Creación: 01-Oct/2020
    /// Descripción      : Esta clase contiene las propiedades del FiltroPedido
    /// </summary>
    public class FiltroArchivo
    {

        /// <summary>
        /// Fecha inicial en la que se carga el archivo
        /// </summary>
        /// <value>Fecha inicial en la que se carga el archivo</value>        
        public int Desde { get; set; }

        /// <summary>
        /// Fecha final en la que se carga el archivo
        /// </summary>
        /// <value>Fecha final en la que se carga el archivo</value>           
        public int Hasta { get; set; }

        /// <summary>
        /// Fecha en la que se carga el archivo
        /// </summary>
        /// <value>Fecha en la que se carga el archivo</value>       
        public string FechaCarga { get; set; }

        /// <summary>
        /// Fecha inicial en la que se carga el archivo
        /// </summary>
        /// <value>Fecha en la que se carga el archivo</value>       
        public string FechaInicial { get; set; }

        /// <summary>
        /// Fecha final en la que se carga el archivo
        /// </summary>
        /// <value>Fecha en la que se carga el archivo</value>       
        public string FechaFinal { get; set; }

        /// <summary>
        /// Id del estado del pedido
        /// </summary>
        /// <value>Id del estado del pedido</value>           
        public string NombreArchivo { get; set; }
    }
}
