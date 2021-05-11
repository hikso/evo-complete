using IntegracionBasculasPorcicarnes.CustomEventArgs;
using IntegracionBasculasPorcicarnes.Interfaces;
using System;
using System.IO.Ports;

namespace IntegracionBasculasPorcicarnes.Adapter
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 28-Nov/2019
    /// Descripción      : Esta clase es la implementación del patrón de diseño adaptador, que permite describir el comportamiento que debe tener un adaptador específico de una báscula.
    /// </summary>
    public abstract class BasculasSerialesAdapter : IBasculasSerialesBehavior
    {
        #region IBasculasSerialesBehavior   
        /// <summary>
        /// Manejador de evento para Obtener el Peso de la báscula.
        /// </summary>
        public abstract event EventHandler<ObtenerPesoSerialEventArgs> ObtenerPeso;

        /// <summary>
        /// Este método permite abrir el puerto serial, para que se pueda iniciar el proceso de lectura sobre el puerto.
        /// </summary>
        /// <param name="COMPort">Nombre del puerto serial</param>
        /// <param name="baudRate">Velocidad del puerto en baudios/seg</param>
        /// <param name="parity">Paridad</param>
        /// <param name="dataBits">Número de bits</param>
        public abstract void AbrirPuerto(string COMPort, int baudRate, Parity parity, int dataBits);

        /// <summary>
        /// Este método permite cerrar el puerto serial.
        /// </summary>
        public abstract void CerrarPuerto();
        #endregion
    }
}