namespace EVO_PB.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 3-Ene/2020
    /// Descripción     : Clase que representa un parámetro general
    /// </summary>
    public class BOGeneralParameter
    {
        /// <summary>
        /// id del parámetro general
        /// </summary>
        /// <value>id del parámetro general</value>       
        public int ParametroGeneralId { get; set; }

        /// <summary>
        /// nombre del parámetro general
        /// </summary>
        /// <value>nombre del parámetro general</value>      
        public string Nombre { get; set; }

        /// <summary>
        /// valor de parámetro general
        /// </summary>
        /// <value>valor de parámetro general</value>      
        public string Valor { get; set; }

       
    }
}
