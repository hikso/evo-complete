using IntegracionBasculasPorcicarnes.CustomEventArgs;
using System;
using System.Globalization;
using System.IO.Ports;

namespace IntegracionBasculasPorcicarnes.Adapter
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 28-Nov/2019
    /// Descripción      : Esta clase es la implementación de un adaptador específico de una báscula; el adaptador para Avery.
    /// </summary>
    public class BasculasSerialesAveryE1010Adapter : BasculasSerialesAdapter
    {
        #region Campos Privados
        /// <summary>
        /// Puerto serial a utilizar para conectarse a la báscula
        /// </summary>
        private SerialPort _serialPort;
        #endregion

        #region BasculasSerialesAdapter
        /// <summary>
        /// Manejador de evento para Obtener el Peso de la báscula.
        /// </summary>
        public override event EventHandler<ObtenerPesoSerialEventArgs> ObtenerPeso;

        /// <summary>
        /// Este método permite abrir el puerto serial, para que se pueda iniciar el proceso de lectura sobre el puerto
        /// </summary>
        /// <param name="COMPort">Nombre del puerto serial</param>
        /// <param name="baudRate">Velocidad del puerto en baudios/seg</param>
        /// <param name="parity">Paridad</param>
        /// <param name="dataBits">Número de bits</param>
        public override void AbrirPuerto(string COMPort, int baudRate, Parity parity, int dataBits)
        {
            this._serialPort = new SerialPort(COMPort, baudRate, parity, dataBits);

            this._serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);

            this._serialPort.Open();
        }

        /// <summary>
        /// Este método permite cerrar el puerto serial
        /// </summary>
        public override void CerrarPuerto()
        {
            this._serialPort.Close();

            this._serialPort.Dispose();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Este método representa el Evento que se dispara cuándo se obtiene el peso de la báscula.
        /// </summary>
        /// <param name="e">Objeto de tipo ObtenerPesoEventArgs, que contiene información del peso.</param>
        protected virtual void OnObtenerPeso(ObtenerPesoSerialEventArgs e)
        {
            EventHandler<ObtenerPesoSerialEventArgs> handler = ObtenerPeso;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Este método se llama cada vez que se detecta una lectura desde el puerto configurado; evento: DataReceived.
        /// </summary>
        /// <param name="sender">Puerto Serial</param>
        /// <param name="e">Parámetros de la lectura</param>
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            // Se debe usar SIEMPRE el método ReadLine.
            // Si se cambia, la lectura obtenida será diferente y el método
            // ProcesarLEcturaPuertoSerial no puede tener una entrada consistente para parsear.
            string data = sp.ReadLine();

            ObtenerPesoSerialEventArgs args = new ObtenerPesoSerialEventArgs();

            args.Peso = this.ProcesarLecturaPuertoSerial(data);

            this.OnObtenerPeso(args);
        }

        /// <summary>
        /// Este método procesa la lectura cruda (RAW) obtenida desde la báscula para obtener el valor numérico del peso.
        /// </summary>
        /// <param name="lectura">Lectrua cruda (RAW) desde la báscula.</param>
        /// <returns>Valor numérico del peso</returns>
        private float ProcesarLecturaPuertoSerial(string lectura)
        {
            //Lectura esperada
            string lecturaEsperada = "G        0.0 kg\r";

            if (string.IsNullOrWhiteSpace(lectura))
            {
                return 0;
            }

            //Estos valores son CONSTANTES
            string cadenaInicio = "G";
            string cadenaFin = " kg\r";

            int posicionInicio = lectura.IndexOf(cadenaInicio);
            int posicionFin = lectura.IndexOf(cadenaFin);

            if (posicionInicio < 0 || posicionFin < 0)
            {
                throw new Exception(string.Format("Cadena errada. Se recibió: {0}\nY se esperaba: {1}", lectura, lecturaEsperada));
            }

            posicionInicio += cadenaInicio.Length;
            posicionFin -= cadenaFin.Length;

            string data = lectura.Substring(posicionInicio + 1, posicionFin).Trim();

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