namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 11-Mar/2020
    /// Descripción     : Clase que representa un objeto de actualización de alistamiento tolerancia
    /// </summary>
    public class AlistamientoTolerancia
    {
        /// <summary>
        /// "Define la clave primaria
        /// </summary>       
        public int AlistamientoToleranciaId { get; set; }
        /// <summary>
        /// Define el código del cliente ya sea interno o externo
        /// </summary>       
        public string CodigoCliente { get; set; }
        /// <summary>
        /// Define la tolerancia inferior
        /// </summary>

        public decimal Inferior { get; set; }
        /// <summary>
        /// Define la tolerancia superior
        /// </summary>

        public decimal Superior { get; set; }
    }
}
