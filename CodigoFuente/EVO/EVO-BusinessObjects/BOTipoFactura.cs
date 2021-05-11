namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 25-May/2020
    /// Descripción     : Clase que representa un objeto de negocio de TipoFactura
    /// </summary>
    public class BOTipoFactura
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public int TipoFacturaId { get; set; }

        /// <summary>
        /// Define el nombre
        /// </summary>
        public string Nombre { get; set; }
       
    }
}
