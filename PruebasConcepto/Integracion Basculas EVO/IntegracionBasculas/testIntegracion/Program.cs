using IntegracionBasculasPorcicarnes.Adapter;
using IntegracionBasculasPorcicarnes.CustomEventArgs;
using IntegracionBasculasPorcicarnes.Factory;
using System;
using System.IO.Ports;
using System.Threading;

namespace testIntegracion
{
    class Program
    {
        static void Main(string[] Args)
        {
            #region Prueba Adaptador Serial Avery
            //BasculasSerialesFactory factory = new BasculasSerialesAveryE1010();

            //BasculasSerialesAdapter adapter = factory.GetAdapter();

            //adapter.AbrirPuerto("COM3", 9600, Parity.None, 8);

            //adapter.ObtenerPeso += Adapter_ObtenerPeso;

            //Thread.Sleep(100);

            //adapter.CerrarPuerto();

            //adapter.ObtenerPeso -= Adapter_ObtenerPeso;
            #endregion

            #region Prueba Adaptador IP Avery
            BasculasIPFactory factory = new BasculasIPAveryZM201();

            BasculasIPAdapter adapter = factory.GetAdapter();

            adapter.ObtenerPeso += AdapterIP_ObtenerPeso;

            adapter.AbrirEndPoint("192.168.249.107", 3000);

            Thread.Sleep(10000);

            adapter.CerrarEndPoint();

            adapter.ObtenerPeso -= AdapterIP_ObtenerPeso;
            #endregion
        }

        private static void AdapterIP_ObtenerPeso(object sender, ObtenerPesoIPEventArgs e)
        {
            Console.WriteLine(string.Format("El peso obtenido es: {0}", e.Peso));
        }

        /// <summary>
        /// Este método es el manejador de eventos de ObtenerPeso para el Adaptador Serial Avery
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Adapter_ObtenerPeso(object sender, ObtenerPesoSerialEventArgs e)
        {
            Console.WriteLine(string.Format("El peso obtenido es: {0}", e.Peso));
        }
    }
}