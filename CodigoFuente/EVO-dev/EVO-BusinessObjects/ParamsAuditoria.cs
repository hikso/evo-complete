using System;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Esta clase se utiliza para enviar parámetros a el método de obtener todas las consultorias
    /// </summary>
    public class ParamsAuditoria
    {
        /// <summary>
        /// Indica desde que número empiezan los registros
        /// </summary>
        public int Desde { get; set; }
        /// <summary>
        /// Indica hasta que número terminan los registros
        /// </summary>
        public int Hasta { get; set; }

    }
}