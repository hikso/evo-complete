namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 24-Oct/2019
    /// Descripción     : Clase que representa un objeto de negocio de un ClienteExterno
    /// </summary>
    public class ClienteExterno
    {
        /// <summary>
        /// Indica el código del cliente
        /// </summary>
        public string CodigoCliente { get; set; }

        /// <summary>
        /// Indica el nombre del cliente externo
        /// </summary>
        public string Nombre { get; set; }
    }
}
