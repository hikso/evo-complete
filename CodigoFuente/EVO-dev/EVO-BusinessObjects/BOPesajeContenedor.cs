namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 9-Abr/2020
    /// Descripción     : Clase que representa un objeto de actualización de PesajeContenedor
    /// </summary>
    public class BOPesajeContenedor
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public int PesajeContenedorId { get; set; }

        /// <summary>
        /// Define la clave foránea a Pesajes
        /// </summary>      
        public int PesajeId { get; set; }       

        /// <summary>
        /// Define la clave foránea a TipoContenedor
        /// </summary>       
        public int TipoContenedorId { get; set; }       

        /// <summary>
        /// Define la cantidad de este tipo de contenedores
        /// </summary>     
        public int Cantidad { get; set; }
    }
}
