using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DibalImage;

namespace AdaptadorDibal
{
    public class ErwinAdaptadorDibal
    {
        #region Métodos Importados de Dibalscop.dll
        [DllImport("Dibalscop.dll")]
        static extern int ReadRegister(ref int serverHandle,
                                        byte[] register,
                                        string scaleIpAddress,
                                        int scalePortTx,
                                        string pcIpAddress,
                                        int pcPorRx,
                                        int timeOut,
#if UNICODE
										[MarshalAs(UnmanagedType.LPWStr)] //Manage as wide string
#endif
 string pathLogs);

        [DllImport("Dibalscop.dll")]
        static extern IntPtr ItemsSend(DibalScale[] myScales,
                                    int numberScales,
                                    DibalItem[] myItems,
                                    int numberItems,
                                    int showWindow, int closeTime);
        #endregion

        public string leerAlgo()
        {
            int serverHandle = 0;
            byte[] registerBytes = new byte[130];

            //Confirmar esta dirección
            string scaleIpAddress = "192.168.1.10";
            //Confirmar esta dirección
            string pcIpAddress = "192.168.1.0";
            //Confirmar este puerto
            int scalePortTx = 3000;
            //Confirmar este puerto
            int pcPorRx = 3000;

            int timeOut = 10;   //10secons is the minimum time out for the socket
            string register = string.Empty;

            //No debería ser????:
            //string pathLogs = "C:\Temp\log.txt";
            string pathLogs = string.Empty;

            // Que obtengo con el readResult?????
            int readResult = ReadRegister(ref serverHandle,
                registerBytes,
                scaleIpAddress,
                scalePortTx,
                pcIpAddress,
                pcPorRx,
                timeOut,
                pathLogs);

            if (readResult == 1)    //Register received ok
            {
                //Convert array of bytes into string
                register = ConvertByteArrayToString(registerBytes);
            }
            else
            {
                //y si no es 1, que se debe hacer???????
            }

            return null;
        }

        public void enviarItems()
        {
            //Implementar ItemsSend
        }


        public long obtenerPeso()
        {
            //Leer el peso de la báscula
            throw new NotImplementedException();
        }

        public void enviarArticulos()
        {
            //Enviar una lista de artículos a la báscula con su precio
        }

        public void enviarVendedores()
        {
            //Enviar una lista de vendendores a la báscula
        }

        public void generarSticker()
        {
            //Enviar una petición a la báscula para que genere un sticker
        }

        public void configurarBascula()
        {
            //Enviar parámetros de configuración a la báscula
            //IP, txPort, rxPort, Master/Slave, no sé si se requiera otro método para configurar el formato del sticker
        }


        #region Métodos Privados
        private string ConvertByteArrayToString(byte[] msgBytes)
        {
            try
            {
                string msgString = System.Text.UTF8Encoding.Default.GetString(msgBytes);
                msgString = System.Text.Encoding.GetEncoding(System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ANSICodePage).GetString(msgBytes);
                return msgString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Clases requeridas por Dibascop.dll
        public struct DibalItem
        {
            public int code;
            public int directKey;
            public double price;
#if UNICODE
            [MarshalAs(UnmanagedType.LPWStr)]   //Manage as wide string
#endif
            public string itemName;
            public int type;
            public int section;
#if UNICODE
            [MarshalAs(UnmanagedType.LPWStr)]   //Manage as wide string
#endif
            public string expiryDate;
            public int alterPrice;
            public int number;
            public int priceFactor;
#if UNICODE
            [MarshalAs(UnmanagedType.LPWStr)]   //Manage as wide string
#endif
            public string textG;

            public DibalItem(int _code, int _directKey, double _price, string _name, int _type, int _section, string _expiryDate, int _alterPrice, int _number, int _priceFactor, string _textG)
            {
                this.code = _code;
                this.directKey = _directKey;
                this.price = _price;
                this.itemName = _name;
                this.type = _type;
                this.section = _section;
                this.expiryDate = _expiryDate;
                this.alterPrice = _alterPrice;
                this.number = _number;
                this.priceFactor = _priceFactor;
                this.textG = _textG;
            }
        }
        #endregion
    }
}
