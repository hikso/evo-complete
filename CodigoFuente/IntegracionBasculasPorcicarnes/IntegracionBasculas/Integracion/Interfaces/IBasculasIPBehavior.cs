using IntegracionBasculasPorcicarnes.CustomEventArgs;
using System;

namespace IntegracionBasculasPorcicarnes.Interfaces
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 05-Dic/2019
    /// Descripción      : Esta interfaz implementa el comportamiento del adaptador de una báscula a través de una dirección IP; las operaciones que se pueden realizar con la báscula.
    /// </summary>
    public interface IBasculasIPBehavior
    {
        /// <summary>
        /// Este método permite abrir un EndPoint, para iniciar el proceso de lectura de peso de la báscula.
        /// </summary>
        /// <param name="IP">Dirección IP</param>
        /// <param name="Puerto">Número de Puerto</param>
        public void AbrirEndPoint(string IP, int Puerto);

        /// <summary>
        /// Este método cierra el Cliente TCP y el Listener TCP.
        /// </summary>
        public void CerrarEndPoint();

        /// <summary>
        /// Manejador de evento para Obtener el Peso de la báscula.
        /// </summary>
        event EventHandler<ObtenerPesoIPEventArgs> ObtenerPeso;
    }
}