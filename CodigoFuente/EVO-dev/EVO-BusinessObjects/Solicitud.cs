using System;
using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 19-Dic/2019
    /// Descripción     : Clase que representa un objeto de negocio que realiza una distribución del pedido en entregas
    /// </summary>
    public class DistribucionSolicitud
    {
        /// <summary>
        /// Id del vehiculo
        /// </summary>
        /// <value>Id del vehiculo</value>     
        public int VehiculoId { get; set; }

        /// <summary>
        /// Id del Muelle
        /// </summary>
        /// <value>Id del vehiculo</value>     
        public int MuelleId { get; set; }

        /// <summary>
        /// Id del conductor
        /// </summary>
        /// <value>Id del conductor</value>       
        public int ConductorId { get; set; }

        /// <summary>
        /// Id del conductor auxiliar
        /// </summary>
        /// <value>Id del conductor auxiliar</value>       
        public int AuxiliarId { get; set; }

        /// <summary>
        /// Ids de las entregas asociadas al viaje
        /// </summary>
        /// <value>Ids de las entregas asociadas al viaje</value>
      
        public List<int> EntregasIds { get; set; }

        /// <summary>
        /// Identifica si es o no un nuevo viaje
        /// </summary>
        /// <value>Identifica si es o no un nuevo viaje</value>      
        public bool? NuevoViaje { get; set; }

        /// <summary>
        /// Nombre de usuario del Usuario EVO
        /// </summary>
        /// <value>Usuario</value>      
        public string Usuario { get; set; }

        /// <summary>
        /// Usuario Id del Usuario EVO
        /// </summary>
        /// <value>UsuarioId</value>      
        public int UsuarioId { get; set; }

        /// <summary>
        /// Fecha de registro 
        /// </summary>
        /// <value>FechaRegistro</value>      
        public DateTime FechaRegistro { get; set; }

        /// <summary>
        /// Id del estado de alistamiento
        /// </summary>
        /// <value>7</value>     
        public int EstadoId { get; set; }
    }
}
