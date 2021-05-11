namespace EVO_BusinessObjects
{
    public class BOTipoContenedor
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>        
        public int TipoContenedorId { get; set; }

        /// <summary>
        /// Define el nombre
        /// </summary>       
        public string Nombre { get; set; }

        /// <summary>
        /// Define el peso
        /// </summary>        
        public decimal Peso { get; set; }

        /// <summary>
        /// Define si tiene código de barras
        /// </summary>        
        public bool CodigoBarras { get; set; }

        /// <summary>
        /// Define el estado
        /// </summary>       
        public bool Activo { get; set; }
    }
}
