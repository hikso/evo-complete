using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Andrés Holguín
    /// Fecha de Creacón: 19-Febrero/2020
    /// Descripción     : Clase que representa un objeto de negocio que realiza una actualización o edición del vehículo en el modulo de enrutamiento
    /// </summary>
    public class ActualizarVehiculoEnrutamiento
    {

        /// <summary>
        /// Id del vehiculo
        /// </summary>
        /// <value>Id del vehiculo</value>     
        public int VehiculoEntregaId { get; set; }

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
        /// Id del estado de enrutamiento
        /// </summary>
        /// <value>EnrutamientoId</value>     
        public int EnrutamientoId { get; set; }
    }
}
