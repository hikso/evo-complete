using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 19-Feb/2020
    /// Descripción     : Clase que representa el estado del viaje del vehículo en enrutamiento 
    /// </summary>
    public class VehiculoEnrutamientoRespuesta
    {
        /// <summary>
        /// Id del tipo del vehiculo
        /// </summary>
        /// <value>Id del tipo del vehiculo</value>      
        public int TipoVehiculoId { get; set; }

        /// <summary>
        /// Id del vehiculo
        /// </summary>
        /// <value>Id del vehiculo</value>      
        public int VehiculoId { get; set; }

        /// <summary>
        /// Id del muelle
        /// </summary>
        /// <value>Id del muelle</value>      
        public int MuelleId { get; set; }

        /// <summary>
        /// Id del conductor
        /// </summary>
        /// <value>Id del conductor</value>       
        public int ConductorId { get; set; }

        /// <summary>
        /// Id del auxiliar
        /// </summary>
        /// <value>Id del auxiliar</value>       
        public int AuxiliarId { get; set; }
    }
}
