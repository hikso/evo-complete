using System;

namespace EVO_PV_BusinessObjects.Exceptions
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 07-Ene/2020
    /// Descripción      : Esta clase permite identificar las excepciones personalizadas que son fruto de validaciones controladas de las excepciones del sistema
    /// </summary>
    public class EVOException : Exception
    {
        public EVOException(string message) : base(message)
        {

        }
    }
}