namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 18-Dic/2019
    /// Descripción     : Clase que representa un vehiculo
    /// </summary>
    public class VehiculoRespuesta
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
        /// Número de la placa
        /// </summary>
        /// <value>Número de la placa</value>       
        public string Placa { get; set; }

        /// <summary>
        /// Capacidad de peso
        /// </summary>
        /// <value>Capacidad de peso</value>

        public decimal Capacidad { get; set; }

        /// <summary>
        /// Tipo de vehiculo
        /// </summary>
        /// <value>Tipo de vehiculo</value>      
        public string TipoVehiculoNombre { get; set; }       

        /// <summary>
        /// Peso
        /// </summary>
        /// <value>Peso</value>      
        public decimal Peso { get; set; }

        /// <summary>
        /// Unidad del peso (Kilogramos)
        /// </summary>
        /// <value>Unidad del peso (Kilogramos)</value>      
        public string Unidad { get; set; }

        /// <summary>
        /// Peso de los artículos
        /// </summary>
        /// <value>Peso de los artículos</value>
      
        public decimal TotalEntregas { get; set; }

        /// <summary>
        /// Propiedad de navegación al tipo de vehículo
        /// </summary>
        /// <value>TipoVehiculo</value>
      
        /// <summary>
        /// Nombre del Muelle
        /// </summary>
        /// <value>Muelle 1</value>       
        public string Muelle { get; set; }

        public TipoVehiculoRespuesta TipoVehiculo { get; set; }
    }
}
