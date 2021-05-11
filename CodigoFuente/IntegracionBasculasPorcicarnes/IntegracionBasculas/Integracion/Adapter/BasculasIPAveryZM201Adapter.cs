using IntegracionBasculasPorcicarnes.CustomEventArgs;
using System;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace IntegracionBasculasPorcicarnes.Adapter
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 05-Dic/2019
    /// Descripción      : Esta clase es la implementación de un adaptador específico para la báscula Avery ZM201, usando una conexión IP.
    /// </summary>
    public class BasculasIPAveryZM201Adapter : BasculasIPAdapter
    {
        #region Campos Privados
        private IPEndPoint _IPEndPoint;
        private TcpListener _TCPListener;
        private TcpClient _TCPClient;
        private NetworkStream _Stream;
        private Timer _Timer;
        private bool _debugMode = false;
        #endregion

        #region Propiedades
        /// <summary>
        /// Indica si la dll imprimirá por consola, la lectura realizada de la báscula. Por defecto el valor es false.
        /// </summary>
        public bool DebugMode
        {
            get
            {
                return this._debugMode;
            }
            set
            {
                this._debugMode = value;
            }
        }
        #endregion

        #region BasculasIPAdapter
        /// <summary>
        /// Manejador de evento para Obtener el Peso de la báscula.
        /// </summary>
        public override event EventHandler<ObtenerPesoIPEventArgs> ObtenerPeso;

        /// <summary>
        /// Este método permite abrir un EndPoint, para iniciar el proceso de lectura de peso de la báscula.
        /// </summary>
        /// <param name="IP">Dirección IP</param>
        /// <param name="Puerto">Número de Puerto</param>
        public override void AbrirEndPoint(string IP, int Puerto)
        {
            this._IPEndPoint = new IPEndPoint(IPAddress.Parse(IP), Puerto);

            if (this._IPEndPoint == null)
            {
                throw new Exception(string.Format("No posee una conexión. Se recibió: {0}\n", this._IPEndPoint));
            }

            this._TCPListener = new TcpListener(this._IPEndPoint);

            this._TCPListener.Start();

            this._TCPClient = this._TCPListener.AcceptTcpClient();

            if (!this._TCPClient.Connected)
            {
                throw new Exception(string.Format("NO ESTA CONECTADO Al PUERTO DE RED: {0}\n", this._IPEndPoint));
            }

            this._Stream = this._TCPClient.GetStream();

            this._Timer = new Timer(100);

            this._Timer.Elapsed += Timer_Elapsed;

            this._Timer.Start();
        }

        /// <summary>
        /// Manejador de eventos que se dispara cuándo se cumple el temporizador configurado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.LeerPeso();
        }

        /// <summary>
        /// Este método cierra el timer, el Cliente TCP y el Listener TCP.
        /// </summary>
        public override void CerrarEndPoint()
        {
            this._Timer.Stop();

            this._Timer.Close();

            this._Timer.Dispose();

            this._Stream.Close();

            this._Stream.Dispose();

            this._TCPClient.Close();

            this._TCPClient.Dispose();

            this._TCPListener.Stop();

            this._TCPListener.Stop();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Este método representa el Evento que se dispara cuándo se obtiene el peso de la báscula.
        /// </summary>
        /// <param name="e">Objeto de tipo ObtenerPesoEventArgs, que contiene información del peso.</param>
        protected virtual void OnObtenerPeso(ObtenerPesoIPEventArgs e)
        {
            EventHandler<ObtenerPesoIPEventArgs> handler = ObtenerPeso;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Este método permite leer el peso de la báscula y disparar el evento OnObtenerPeso cuándo se realiza.
        /// </summary>
        private void LeerPeso()
        {
            string mensajeObtenido = null;

            byte[] canalEnvioByte = Encoding.ASCII.GetBytes("\nW\r");

            this._Stream.Write(canalEnvioByte, 0, canalEnvioByte.Length);

            // Se tiene que garantizar un tiempo de espera, para que la lectura se pueda realizar.
            Thread.Sleep(100);

            byte[] canalRecepcionBytes = new byte[this._TCPClient.Available];

            this._TCPClient.GetStream().Read(canalRecepcionBytes, 0, this._TCPClient.Available);

            mensajeObtenido = Encoding.Default.GetString(canalRecepcionBytes);

            float peso = this.ProcesarLecturaIP(mensajeObtenido);            

            ObtenerPesoIPEventArgs args = new ObtenerPesoIPEventArgs();

            args.Peso = peso;

            this.OnObtenerPeso(args);
        }

        /// <summary>
        /// Este método procesa la lectura cruda (RAW) obtenida desde la báscula para obtener el valor numérico del peso.
        /// </summary>
        /// <param name="lectura">Lectrua cruda (RAW) desde la báscula.</param>
        /// <returns>Valor numérico del peso</returns>
        private float ProcesarLecturaIP(string lectura)
        {
            if (this._debugMode)
            {
                Console.WriteLine(string.Format("RAW: {0}", lectura));
            }

            //Lectura esperada
            //\n 1G         0.0kg \r
            //\n 1GM         0.0kg \r
            //\nZ1GM        0.0kg \r
            string lecturaEsperada = "\n 1G         0.0kg \r";

            if (string.IsNullOrWhiteSpace(lectura))
            {
                return 0;
            }

            //Estos valores son CONSTANTES
            //\n 1GM         0.0kg \r
            string cadenaInicio = "\n 1GM";

            int inicio = lectura.IndexOf(cadenaInicio);

            if (inicio < 0)
            {
                //\nZ1GM        0.0kg \r
                cadenaInicio = "\nZ1GM";

                inicio = lectura.IndexOf(cadenaInicio);

                if (inicio < 0)
                {
                    //\n 1G         0.0kg \r
                    cadenaInicio = "\n 1G";

                    inicio = lectura.IndexOf(cadenaInicio);
                }
            }

            string cadenaFin = "kg \r";

            int fin = lectura.IndexOf(cadenaFin);

            if (inicio < 0 || fin <= 0)
            {
                throw new Exception(string.Format("Cadena errada. Se recibió: {0}\nY se esperaba: {1}", lectura, lecturaEsperada));
            }

            inicio += cadenaInicio.Length;
            fin -= cadenaInicio.Length;

            string data = lectura.Substring(inicio, fin).Trim();

            float respuesta = 0;

            try
            {
                respuesta = float.Parse(data, CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new Exception(string.Format("Cadena errada. Se recibió: {0}\nY se esperaba: {1}", lectura, lecturaEsperada));
            }

            return respuesta;
        }
        #endregion
    }
}