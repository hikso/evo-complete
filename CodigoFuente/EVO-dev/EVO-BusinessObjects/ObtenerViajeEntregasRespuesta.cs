using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 04-Feb/2019
    /// Descripción     : Clase que representa un viaje para las entregas
    /// </summary>
    public class ObtenerViajeEntregasRespuesta
    {
        /// <summary>
        /// Nombre del tipo de vehiculo
        /// </summary>
        /// <value>Nombre del tipo de vehiculo</value>      
        public string TipoVehiculo { get; set; }

        /// <summary>
        /// Capacidad en KG
        /// </summary>
        /// <value>Capacidad en KG</value>        [
        public string CapacidadVehiculo { get; set; }

        /// <summary>
        /// Unidades de canastas
        /// </summary>
        /// <value>Unidades de canastas</value>        
        public string UnidadesCanastas { get; set; }

        /// <summary>
        /// Placa del vehiculo
        /// </summary>
        /// <value>Placa del vehiculo</value>
       
        public string Placa { get; set; }

        /// <summary>
        /// Total entregas asociadas
        /// </summary>
        /// <value>Total entregas asociadas</value>
       
        public string TotalEntregasAsociadas { get; set; }

        /// <summary>
        /// Cantidad total en KG
        /// </summary>
        /// <value>Cantidad total en KG</value>
       
        public string CantidadTotal { get; set; }

        /// <summary>
        /// Unidades totales
        /// </summary>
        /// <value>Unidades totales</value>
       
        public string UnidadesTotales { get; set; }

        /// <summary>
        /// Lista de las entregas
        /// </summary>
        /// <value>Lista de las entregas</value>
     
        public List<ObtenerViajeEntregasRespuestaEntregas> Entregas { get; set; }
    }
}
