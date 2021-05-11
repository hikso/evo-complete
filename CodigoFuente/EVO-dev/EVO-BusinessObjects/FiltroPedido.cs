using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Duban Cardona
    /// Fecha de Creación: 20-Ago/2019
    /// Descripción      : Esta clase contiene las propiedades del FiltroPedido
    /// </summary>
    public class FiltroPedido
    {
        /// <summary>
        /// Indica el código de la bodega
        /// </summary>
        public string WhsCode { get; set; }

        /// <summary>
        /// Indica el número de registro desde el cuál se deben obtener los registros
        /// </summary>
        /// <value>Indica el número de registro desde el cuál se deben obtener los registros</value>

        public int Desde { get; set; }

        /// <summary>
        /// Indica el número de registro hasta el cuál se deben obtener los registros
        /// </summary>
        /// <value>Indica el número de registro hasta el cuál se deben obtener los registros</value>
       
        public int Hasta { get; set; }

        /// <summary>
        /// Fecha en la que se registra el pedido
        /// </summary>
        /// <value>Fecha en la que se registra el pedido</value>

        public string FechaDesde { get; set; }

        /// <summary>
        /// Fecha en la que se registra el pedido
        /// </summary>
        /// <value>Fecha en la que se registra el pedido</value>
       
        public string FechaHasta { get; set; }

        /// <summary>
        /// Id del estado del pedido
        /// </summary>
        /// <value>Id del estado del pedido</value>
      
        public string Estado { get; set; }

        /// <summary>
        /// Filtro por Planta Beneficio
        /// </summary>
        /// <value>Filtro por Planta Beneficio</value>
       
        public bool? PlantaBeneficio { get; set; }

        /// <summary>
        /// Indica el código de la planta
        /// </summary>
        public string CodigoPlantaBeneficio { get; set; }

        /// <summary>
        /// Filtro por Planta Derivados
        /// </summary>
        /// <value>Filtro por Planta Derivados</value>

        public bool? PlantaDerivados { get; set; }

        public string CodigoPlantaDerivados { get; set; }
        /// <summary>
        /// Los pendientes son todos los NO cerrados
        /// </summary>
        /// <value>Los pendientes son todos los NO cerrados</value>

        public string Pendientes { get; set; }


        /// <summary>
        /// Filtro por numero de pedido
        /// </summary>
        /// <value>Filtro por numero de pedido</value>
        /// 
        public string Numeropedido { get; set; }
    }
}
