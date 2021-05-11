namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 18-Dic/2019
    /// Descripción     : Clase que representa un tipo de vehiculo
    /// </summary>
    public class TipoVehiculoRespuesta
    {
        /// <summary>
        /// Id del tipo de vehiculo
        /// </summary>
        /// <value>Id del tipo de vehiculo</value>       
        public int TipoVehiculoId { get; set; }

        /// <summary>
        /// Tipo de vehiculo
        /// </summary>
        /// <value>Tipo de vehiculo</value>      
        public string TipoVehiculo { get; set; }

        /// <summary>
        /// Capacidad del tipo de vehículo para la carga
        /// </summary>
        /// <value>Capacidad</value>       
        public decimal Capacidad { get; set; }

        /// <summary>
        /// Peso de las canastas que tienen los artículos 
        /// </summary>
        /// <value>Canastas</value>       
        public decimal Canastas { get; set; }

        /// <summary>
        /// Peso del vehículo sin carga , canastas , conductor y auxiliar
        /// </summary>
        /// <value>Peso</value>
        public decimal Peso { get; set; }
    }
}
