using IntegracionBasculasPorcicarnes.CustomEventArgs;
using IntegracionBasculasPorcicarnes.Interfaces;
using System;

namespace IntegracionBasculasPorcicarnes.Adapter
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 05-Dic/2019
    /// Descripción      : Esta clase es la implementación del patrón de diseño adaptador, que permite describir el comportamiento que debe tener un adaptador específico de una báscula.
    /// </summary>
    public abstract class BasculasIPAdapter : IBasculasIPBehavior
    {
        #region IBasculasIPBehavior
        /// <summary>
        /// Manejador de evento para Obtener el Peso de la báscula.
        /// </summary>
        public abstract event EventHandler<ObtenerPesoIPEventArgs> ObtenerPeso;

        /// <summary>
        /// Este método permite abrir un EndPoint, para iniciar el proceso de lectura de peso de la báscula.
        /// </summary>
        /// <param name="IP">Dirección IP</param>
        /// <param name="Puerto">Número de Puerto</param>
        public abstract void AbrirEndPoint(string IP, int Puerto);

        /// <summary>
        /// Este método cierra el Cliente TCP y el Listener TCP.
        /// </summary>
        public abstract void CerrarEndPoint();
        #endregion
    }
}