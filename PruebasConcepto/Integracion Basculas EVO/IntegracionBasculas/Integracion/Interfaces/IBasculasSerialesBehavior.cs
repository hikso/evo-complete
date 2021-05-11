using IntegracionBasculasPorcicarnes.CustomEventArgs;
using System;
using System.IO.Ports;

namespace IntegracionBasculasPorcicarnes.Interfaces
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 04-Dic/2019
    /// Descripción      : Esta interfaz implementa el comportamiento del adaptador de una báscula a través de un puerto serial; las operaciones que se pueden realizar con la báscula.
    /// </summary>
    public interface IBasculasSerialesBehavior
    {
        /// <summary>
        /// Este método permite abrir el puerto serial, para que se pueda iniciar el proceso de lectura sobre el puerto
        /// </summary>
        /// <param name="COMPort">Nombre del puerto serial</param>
        /// <param name="baudRate">Velocidad del puerto en baudios/seg</param>
        /// <param name="parity">Paridad</param>
        /// <param name="dataBits">Número de bits</param>
        void AbrirPuerto(string COMPort, int baudRate, Parity parity, int dataBits);

        /// <summary>
        /// Este método permite cerrar el puerto serial
        /// </summary>
        void CerrarPuerto();

        /// <summary>
        /// Manejador de evento para Obtener el Peso de la báscula.
        /// </summary>
        event EventHandler<ObtenerPesoSerialEventArgs> ObtenerPeso;
    }
}