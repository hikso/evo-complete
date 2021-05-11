using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace IntegracionBasculasPorcicarnes.Adapter
{
    #region Estructuras
    //TODO: Se debe crear un ejemplo en comentarios o un archivo de texto de cómo crear una estructura de báscula
    public struct DibalScale
    {
        public int masterAddress;
#if UNICODE
            [MarshalAs(UnmanagedType.LPWStr)]   //Manage as wide string
#endif
        public string IpAddress;
        public int txPort;
        public int rxPort;
#if UNICODE
            [MarshalAs(UnmanagedType.LPWStr)]   //Manage as wide string
#endif
        public string model;
#if UNICODE
            [MarshalAs(UnmanagedType.LPWStr)]   //Manage as wide string
#endif
        public string display;
#if UNICODE
            [MarshalAs(UnmanagedType.LPWStr)]   //Manage as wide string
#endif
        public string section;
        public int group;
#if UNICODE
            [MarshalAs(UnmanagedType.LPWStr)]   //Manage as wide string
#endif
        public string logsPath;

        public DibalScale(int _masterAddress, string _IpAddress, int _txPort, int _rxPort, string _model, string _display, string _section, int _group, string _logsPath)
        {
            this.masterAddress = _masterAddress;
            this.IpAddress = _IpAddress;
            this.txPort = _txPort;
            this.rxPort = _rxPort;
            this.model = _model;
            this.display = _display;
            this.section = _section;
            this.group = _group;
            this.logsPath = _logsPath;
        }
    }

    //TODO: Se debe crear un ejemplo en comentarios o un archivo de texto de cómo crear un estructura de artículo
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

    public class BasculasIPDibal500RANGEAdapter
    {
        #region Métodos Importados de DibalImage.dll
        [DllImport("DibalImage.dll")]
        static extern int ReadRegister(ref int serverHandle,
            byte[] register,
            string scaleIpAddress,
            int scalePortTx,
            string pcIpAddress,
            int pcPorRx,
            int timeOut,
            string pathLogs);

        [DllImport("DibalImage.dll")]
        static extern IntPtr ItemsSend(DibalScale[] myScales,
            int numberScales,
            DibalItem[] myItems,
            int numberItems,
            int showWindow,
            int closeTime);
        #endregion

        #region Métodos Públicos
        public void EnviarArticulos(DibalScale[] basculas, DibalItem[]articulos)
        {
            //We use IntPtr because Windows(from Framework 4.5) does not allow to assign a C++ LPSTR(char*) to C# String.
            IntPtr ptrResult = ItemsSend(basculas, basculas.Length, articulos, articulos.Length, 0, 0);

            //ItemsSend returns an ANSI char array(LPSTR)
            string Result = Marshal.PtrToStringAnsi(ptrResult);

            if (Result != "OK")
            {
                throw new Exception(Result);
            }

            //TODO: Que pasa si la masterAddress y la IpAddress del objeto DibalScale para qué son? Qué pasa si son los mismos valores? Sí van vacíos una de las 2 o las 2?
            //TODO: QUe pasa si el model de DibalScale va vacío o con un valor que no es RANGE500?
            //TODO: Que es el display de DibalScale???? Que pasa si va vacío? Para que sirve?
            //TODO: Que es el section de DibalScale???? Que pasa si va vacío? Para que sirve?
            //TODO: Que es el group de DibalScale???? Que pasa si va vacío? Para que sirve?
            //TODO: Que es el logsPath de DibalScale???? Que pasa si va vacío? Para que sirve?
            //TODO: Que es el code de DibalItem? El código del artículo?
            //TODO: Que es el directKey de DibalItem? Cómo se identifican las teclas de la báscula?
            //TODO: Que es el type de DibalItem??? Que pasa si va vacío? Para que sirve?
            //TODO: Que es el section de DibalItem??? Que pasa si va vacío? Para que sirve?
            //TODO: Que es el expiryDate de DibalItem??? Que pasa si va vacío? Para que sirve? Qué formato de fecha recibe?
            //TODO: Que es el alterPrice de DibalItem??? Que pasa si va vacío? Para que sirve?
            //TODO: Que es el number de DibalItem??? Que pasa si va vacío? Para que sirve?
            //TODO: Que es el priceFactor de DibalItem??? Que pasa si va vacío? Para que sirve?
            //TODO: Que es el textG de DibalItem??? Que pasa si va vacío? Para que sirve?

        }

        public float LeerPeso(DibalScale bascula, string pcIpAddress, int timeOut, string rutaArchivoTiquetes)
        {
            int serverHandle = 0;
            int readResult = 0;
            string register = string.Empty;
            byte[] registerBytes = new byte[130];

            //TODO: Para qué el timeout? Lo puedo mandar en 0?
            //TODO: Para qué el rutaArchivoTiquetes? Lo puedo mandar vacío?

            //1- Read the 130 character Dibal scale register
            readResult = ReadRegister(ref serverHandle, registerBytes, bascula.IpAddress, bascula.txPort, pcIpAddress, bascula.rxPort, timeOut, rutaArchivoTiquetes);

            if (readResult == 1) //Register received ok
            {

                //Convert array of bytes into string
                register = ConvertByteArrayToString(registerBytes);
            }
            else
            {
                //TODO: Qué pasa si no es 1 la respuesta?
            }

            return 0;
        }

        private string ConvertByteArrayToString(byte[] msgBytes)
        {
            try
            {
                string msgString = UTF8Encoding.Default.GetString(msgBytes);

                msgString = Encoding.GetEncoding(Thread.CurrentThread.CurrentCulture.TextInfo.ANSICodePage).GetString(msgBytes);
                
                return msgString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}