using System;

namespace EVO_PB.Models.BusinessObjects.Exceptions
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 12-Ago/2019
    /// Descripción      : Esta clase permite identificar las excepciones personalizadas que son fruto de validaciones controladas de las excepciones del sistema
    /// </summary>
    public class EVOException : Exception
    {
        public EVOException(string message) : base(message)
        {

        }
    }
}