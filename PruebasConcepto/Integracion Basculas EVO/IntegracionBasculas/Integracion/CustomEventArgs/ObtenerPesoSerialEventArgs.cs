using System;

namespace IntegracionBasculasPorcicarnes.CustomEventArgs
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 04-Dic/2019
    /// Descripción      : Esta clase es la implementación de los argumentos personalizados del evento ObtenerPeso. Requerido en las lecturas de peso en las básculas seriales.
    /// </summary>
    public class ObtenerPesoSerialEventArgs : EventArgs
    {
        /// <summary>
        /// Propiedad que indica el peso leído de la báscula
        /// </summary>
        public float Peso { get; set; }
    }
}