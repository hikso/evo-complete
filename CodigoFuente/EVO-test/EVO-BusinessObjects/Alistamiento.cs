using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 08-Mar/2020
    /// Descripción     : Clase que representa un objeto de negocio de un Alistamiento
    /// </summary>
    public class Alistamiento
    {
        /// <summary>
        /// Consecutivo del alistamiento de la entrega
        /// </summary>
        public int Consecutivo { get; set; }
        /// <summary>
        /// Fecha en que se termina de alistar la entrega
        /// </summary>
        public DateTime FechaAlistamiento { get; set; }
    }
}
