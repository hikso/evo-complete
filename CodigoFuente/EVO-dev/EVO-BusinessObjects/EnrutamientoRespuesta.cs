using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 26-Feb/2020
    /// Descripción     : Clase que representa el encabezado del enrutamiento
    /// </summary>
    public class EnrutamientoRespuesta
    {
        /// <summary>
        /// Id del viaje
        /// </summary>
        /// <value>Id del viaje</value>
      
        public int VehiculoEntregaId { get; set; }

        /// <summary>
        /// Peso de la entrega
        /// </summary>
        /// <value>Peso de la entrega</value>
       
        public decimal TotalPeso { get; set; }

        /// <summary>
        /// cantidad de entregas
        /// </summary>
        /// <value>cantidad de entregas</value>
     
        public int CantidadEntregas { get; set; }

        /// <summary>
        /// Gets or Sets TipoVehiculo
        /// </summary>
      
        public TipoVehiculoRespuesta TipoVehiculo { get; set; }

        /// <summary>
        /// Gets or Sets Vehiculo
        /// </summary>
      
        public VehiculoRespuesta Vehiculo { get; set; }

        /// <summary>
        /// Gets or Sets Muelle
        /// </summary>
       
        public MuelleRespuesta Muelle { get; set; }

        /// <summary>
        /// Gets or Sets Conductor
        /// </summary>
       
        public Empleado Conductor { get; set; }

        /// <summary>
        /// Gets or Sets Auxiliar
        /// </summary>
        /// 
        public Empleado Auxiliar { get; set; }
    }
}
