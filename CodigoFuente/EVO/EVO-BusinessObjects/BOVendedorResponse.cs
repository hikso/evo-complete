namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 28-Abr/2020
    /// Descripción     : Clase que representa un objeto de negocio de la respuesta de un Vendedor
    /// </summary>
    public class BOVendedorResponse
    {
        /// <summary>
        /// Id del vendedor
        /// </summary>
        /// <value>Id del vendedor</value>     
        public int VendedorId { get; set; }

        /// <summary>
        /// Nombres del vendedor
        /// </summary>
        /// <value>Nombres del vendedor</value>     
        public string Nombres { get; set; }

        /// <summary>
        /// Apellidos del vendedor
        /// </summary>
        /// <value>Apellidos del vendedor</value>       
        public string Apellidos { get; set; }

        /// <summary>
        /// Indica si está activo
        /// </summary>
        /// <value>true</value>       
        public bool Activo { get; set; }
    }
}
