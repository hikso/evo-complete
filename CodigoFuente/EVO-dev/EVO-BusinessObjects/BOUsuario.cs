namespace EVO_BusinessObjects
{
    public class BOUsuario
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>      
        public int UsuarioId { get; set; }

        /// <summary>
        /// Define el usuario
        /// </summary>      
        public string Usuario { get; set; }

        /// <summary>
        /// Define el nombre del usuario
        /// </summary>       
        public string Nombre { get; set; }

        /// <summary>
        /// Define si el registro se encuentra activo o inactivo
        /// </summary>        
        public bool Activo { get; set; }
    }
}
