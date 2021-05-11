namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 24-Mar/2020
    /// Descripción     : Clase que representa un objeto de BOPesajeContenedorResponse
    /// </summary>
    public class BOPesajeContenedorResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        /// <value>Id</value>      
        public int TipoContenedorId { get; set; }

        /// <summary>
        /// Nomnbre
        /// </summary>
        /// <value>Nomnbre</value>      
        public string Nombre { get; set; }

        /// <summary>
        /// peso
        /// </summary>
        /// <value>peso</value>       
        public decimal Peso { get; set; }

        /// <summary>
        /// Cantidad usados
        /// </summary>
        /// <value>Cantidad usados</value>      
        public int Cantidad { get; set; }

        public BOTipoContenedor TipoContenedor { get; set; }
    }
}
