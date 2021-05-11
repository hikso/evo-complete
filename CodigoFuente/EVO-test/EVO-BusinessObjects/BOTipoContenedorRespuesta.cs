namespace EVO_BusinessObjects
{
    public class BOTipoContenedorRespuesta
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
        /// indica si tienen código de barras
        /// </summary>
        /// <value>indica si tienen código de barras</value>       
        public bool CodigoBarras { get; set; }
    }
}
