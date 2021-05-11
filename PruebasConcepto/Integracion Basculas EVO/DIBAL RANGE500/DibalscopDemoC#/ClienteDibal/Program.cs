using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using static DibalscopDemo.frmPrincipal;

namespace ClienteDibal
{

    /// <summary>
    /// Metódos para consumir API DIBAL por Consola
    /// Obtener peso, asignar peso, Tipo de pesado, asignar número en tecla en el tablero digital y nombre del artículo o producto.
    /// </summary>
    /// 
    #region
    public class Program 
    {

        #region Dibalscop [Métodos Importados]
        [DllImport("Dibalscop.dll")]
        static extern IntPtr ItemsSend(DibalScale[] myScales,
                                        int numberScales,
                                        DibalItem[] myItems,
                                        int numberItems,
                                        int showWindow, int closeTime);

        [DllImport("Dibalscop.dll")]
        static extern IntPtr ItemsSend2(DibalScale[] myScales,
                                        int numberScales,
                                        DibalItem2[] myItems,
                                        int numberItems,
                                        int showWindow, int closeTime);

        [DllImport("Dibalscop.dll")]
        static extern IntPtr DataSend();

        [DllImport("Dibalscop.dll")]
        static extern IntPtr DataSend2();

        [DllImport("Dibalscop.dll")]
        static extern IntPtr RegistersSend(DibalScale[] myScales,
                                        int numberScales,
                                        DibalRegister[] myRegisters,
                                        int numberRegisters,
                                        int showWindow, int closeTime);

        [DllImport("Dibalscop.dll")]
        static extern int ReadRegister(ref int serverHandle,
                                        byte[] register,
                                        string scaleIpAddress,
                                        int scalePortTx,
                                        string pcIpAddress,
                                        int pcPorRx,
                                        int timeOut,
                                        string pathLogs);

        [DllImport("Dibalscop.dll")]
        static extern int CancelReadRegister(ref int serverHandle, string pathLogs);
        #endregion

        #region [Variables]
        public const int TIMEOUT = 10;  //10 secons is the minimum time out for the socket
        private readonly bool InvokeRequired;
        bool cancel = false;
        bool finish = false;
        IPAddress[] Addresses;			//PC Ip addresses
        Thread[] oExportScaleThread;	//Scale threads
        string PcIp = string.Empty;		//PC Ip address
        Int32 totalRegisters = 0;
        bool exportContinuous;
        string pathLogs = string.Empty;
        #endregion


        /// <summary>
        /// Este método agrega las balanzas conectadas al equipo
        /// </summary>
        /// <param name="misBalanzas">Agrega las balanzas</param>
        /// <returns></returns>
        #region [Adicionar Balanzas]
        private static DibalScale[] GetScales(List<Balanza> misBalanzas)
        {
            try
            {
                DibalScale scale;
                DibalScale[] myScales = new DibalScale[misBalanzas.Count];
                ArrayList arlScale = new ArrayList();
                //Default Scale variables
                int scaleMasterAddressAux = 0;
                string scaleIpAddressAux = string.Empty;
                int scalePortRxAux = 3000;
                int scalePortTxAux = 3001;
                string scaleModelAux = "MODEL500RANGE";
                string scaleDisplayAux = string.Empty;
                string scaleSectionsAux = string.Empty;
                int scaleGroupAux = 0;
                string scaleLogsPathAux = string.Empty;

                foreach (Balanza b in misBalanzas)
                {
                    //if (dtScales.TableName == "Scales")
                    //{
                    //    //Cast DBnull of DataGrid
                    //    int.TryParse(Convert.ToString(dr["MasterAddress"]), out scaleMasterAddressAux);
                    //    int.TryParse(Convert.ToString(dr["Group"]), out scaleGroupAux);
                    //    if (!string.IsNullOrEmpty(Convert.ToString(dr["IpAddress"])))
                    //        scaleIpAddressAux = Convert.ToString(dr["IpAddress"]);
                    //    int.TryParse(Convert.ToString(dr["ReceptionPortRx"]), out scalePortRxAux);

                    //    if (!string.IsNullOrEmpty(Convert.ToString(dr["Model"])))
                    //    {
                    //        if (Convert.ToString(dr["Model"]) == "0")
                    //            scaleModelAux = MODEL500RANGE;
                    //        else
                    //            scaleModelAux = MODELLSERIES;
                    //    }

                    //}
                    //else if (dtScales.TableName == "ExportScales")
                    //{
                    //    //Cast DBnull of DataGrid
                    //    int.TryParse(Convert.ToString(dr["ExMasterAddress"]), out scaleMasterAddressAux);
                    //    if (!string.IsNullOrEmpty(Convert.ToString(dr["ExIpAddress"])))
                    //        scaleIpAddressAux = Convert.ToString(dr["ExIpAddress"]);
                    //    int.TryParse(Convert.ToString(dr["ExReceptionPortRx"]), out scalePortRxAux);
                    //    int.TryParse(Convert.ToString(dr["ExSendPortTx"]), out scalePortTxAux);
                    //}
                    //else
                    //{
                    //    //Cast DBnull of DataGrid
                    //    int.TryParse(Convert.ToString(dr["ImgMasterAddress"]), out scaleMasterAddressAux);
                    //    int.TryParse(Convert.ToString(dr["ImgGroup"]), out scaleGroupAux);
                    //    if (!string.IsNullOrEmpty(Convert.ToString(dr["ImgIpAddress"])))
                    //        scaleIpAddressAux = Convert.ToString(dr["ImgIpAddress"]);
                    //    int.TryParse(Convert.ToString(dr["ImgReceptionPortRx"]), out scalePortRxAux);

                    //    if (!string.IsNullOrEmpty(Convert.ToString(dr["ImgModel"])))
                    //    {
                    //        if (Convert.ToString(dr["ImgModel"]) == "0")
                    //            scaleModelAux = MODEL500RANGE;
                    //        else
                    //            scaleModelAux = MODELLSERIES;
                    //    }

                    //}
                    //Create a scale
                    scale = new DibalScale(b.DireccionMaestra, b.DireccionIp, scalePortTxAux, b.PuertoRx, b.ModeloBascula, b.Grupo.ToString(), scaleSectionsAux, scaleGroupAux, scaleLogsPathAux);
                    //scale = new DibalScale(scaleMasterAddressAux, scaleIpAddressAux, scalePortTxAux, scalePortRxAux, scaleModelAux, scaleDisplayAux, scaleSectionsAux, scaleGroupAux, scaleLogsPathAux);
                    //Add a scale to ArrayList "arlScale"
                    arlScale.Add(scale);
                    //Copy the Scale objects of the ArrayList "arlScale" to a Scale array "myScales"
                    myScales = (DibalScale[])arlScale.ToArray(typeof(DibalScale));
                }
                return myScales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        /// <summary>
        /// Este método agrega los productos o artículos conectados al equipo
        /// </summary>
        /// <param name="articulos">Agrega los artículos</param>
        /// <returns></returns>
        #region [Adicionar Artículos/Productos]
        private static DibalItem2[] GetItems(List<Articulo> articulos)
        {
            try
            {
                DibalItem2 item;
                DibalItem2[] myItems = new DibalItem2[articulos.Count];
                ArrayList arlItem = new ArrayList();
                //Default Item variables
                char action = 'M';
                int itemCodeAux = 0;
                int itemDirectKeyAux = 0;
                double itemPriceAux = 0;
                string itemNameAux = string.Empty;
                string itemName2Aux = string.Empty;
                int itemTypeAux = 0;
                int itemSectionAux = 0;
                int labelFormat = 0;
                int EAN13Format = 0;
                int VATType = 0;
                double offerPrice = 0.0;
                string itemExpiryDaysAux = new string('0', 10);
                string itemExtraDate = new string('0', 10);
                double tare = 0.0;
                string EANScanner = string.Empty;
                int productClass = 0;
                int NRP = 0;
                int itemAlterPrice = 0;
                string itemTextG = string.Empty;

                foreach (Articulo a in articulos)
                {
                    //Cast DBnull of DataGrid
                    //int.TryParse(Convert.ToString(dr["Code"]), out itemCodeAux);

                    //int.TryParse(Convert.ToString(dr["DirectKey"]), out itemDirectKeyAux);

                    //double.TryParse(Convert.ToString(dr["Price"]), out itemPriceAux);

                    //if (!string.IsNullOrEmpty(Convert.ToString(dr["Name"])))
                    //    itemNameAux = Convert.ToString(dr["Name"]);

                    //int.TryParse(Convert.ToString(dr["Type"]), out itemTypeAux);

                    //Create an Item
                    item = new DibalItem2(action, a.Codigo, a.TeclaDirecta, Convert.ToDouble(a.Precio), a.Nombre, itemName2Aux, a.Tipo == "PESADO" ? 0 : 1, itemSectionAux, labelFormat, EAN13Format, VATType, offerPrice, itemExpiryDaysAux, itemExtraDate, tare, EANScanner, productClass, NRP, itemAlterPrice, itemTextG);
                    //Add an item to ArrayList "arlItem"
                    arlItem.Add(item);
                    //Copy the Item objects of the ArrayList "arlItem" to a Item array.
                    myItems = (DibalItem2[])arlItem.ToArray(typeof(DibalItem2));
                }
                return myItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        /// <summary>
        /// Este método indica el comienzo de la exportación de datos y sus artículos o productos asociados
        /// </summary>
        /// <param name="datoBalanza">Muestra los datos y artículos exportados</param>
        /// 
        #region [Comienza Exportación Datos/Artículos]
        private void StartExport(List<Balanza> datoBalanza)
        {
            try
            {
                DibalScale[] misBalanzas = new DibalScale[datoBalanza.Count];
                misBalanzas = GetScales(datoBalanza);

                //Create thread for each scale
                this.oExportScaleThread = new Thread[misBalanzas.Length];
                for (int i = 0; i < misBalanzas.Length; i++)
                {
                    oExportScaleThread[i] = new Thread(new ParameterizedThreadStart(ReceiveRegisters));
                    this.oExportScaleThread[i].Name = "Scale_" + misBalanzas[i].IpAddress;
                    this.oExportScaleThread[i].Start(misBalanzas[i]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        /// <summary>
        /// Receive registers from the scale with "ReadRegister" function, 
        /// which let the register in "registerBytes" string
        /// Call to "CancelReadRegister" function to finish the reception.
        /// </summary>
        /// <param name="scale">Recibe los registros de la Balanza</param>
        /// 
        #region [Recibir Registros desde Balanza]
        private void ReceiveRegisters(object scale)
        {
            try
            {
                bool stop = false;
                bool cancelled = false;
                bool noMoreHV = false;
                int serverHandle = 0;
                int cancelResult = 0;
                int readResult = 0;
                int readResultPrevious = -1;
                int scaleNumRegister = 0;
                string register = string.Empty;
                byte[] registerBytes = new byte[130];

                //this.SetResultGrid(((DibalScale)scale).IpAddress, readResult);

                do
                {
                    //1- Read the 130 character Dibal scale register
                    readResult = ReadRegister(ref serverHandle, registerBytes, ((DibalScale)scale).IpAddress, ((DibalScale)scale).txPort, ((DibalScale)scale).IpAddress, ((DibalScale)scale).txPort, TIMEOUT, ((DibalScale)scale).logsPath);

                    if (readResult == 1) //Register received ok
                    {
                        //2-Manage the received register
                        scaleNumRegister++;
                        this.totalRegisters++;

                        //Convert array of bytes into string
                        register = ConvertByteArrayToString(registerBytes);
                        Console.WriteLine(register);
                        //Write register of each scale in its file
                        //if (txtExportFilePath.Text != string.Empty)
                        //    this.WriteRegisterFile(txtExportFilePath.Text + "\\" + ((DibalScale)scale).IpAddress + "_registers.txt", register);
                        //Update registers grid
                        //this.SetRegisterGrid(scaleNumRegister, ((DibalScale)scale).IpAddress, register);
                        //Update registers Counter 
                        //this.SetTotalRegister(Convert.ToString(totalRegisters));
                        //Finalize export if the scale dont have more registers HV to send.
                        //if (exportContinuous == false)
                        //    noMoreHV = ManageRegister(register);
                    }
                    else
                    {
                        Console.WriteLine("noooo");
                    }
                    //else
                    //{	//4-After cancel (cancelled == true) you must call to ReadRegister until you dont have nothing to read (readResult == 0)
                    //    // - if you are in "start/end" mode and you have nothing to read, finalize.
                    //    if (cancelled == true || (exportContinuous == false && readResult == 0))
                    //    {
                    //        this.finish = true;	//starting to wait for close of all the threads in Application_Idle
                    //        stop = true;		//exit of ReceiveRegisters function 
                    //    }
                    //}
                    //if ((this.cancel == true && cancelled != true) || noMoreHV == true)
                    //{
                    //    //3-Cancel export under control, PC sends FIN,ACK to the scale
                    //    cancelResult = CancelReadRegister(ref serverHandle, txtLogsFilePath.Text);
                    //    cancelled = true;
                    //}
                    ////Only refresh if the "readResult" is diference or process cancelled or scale dont have more registers to send
                    //if (readResult != readResultPrevious || stop == true)
                    //{
                    //    if (noMoreHV == true || (exportContinuous == false && readResult == 0))
                    //        this.SetResultGrid(((DibalScale)scale).IpAddress, 2);
                    //    else if (cancelled == true)
                    //        this.SetResultGrid(((DibalScale)scale).IpAddress, cancelResult);
                    //    else
                    //        this.SetResultGrid(((DibalScale)scale).IpAddress, readResult);

                    //    readResultPrevious = readResult;
                    //}
                    //Application.DoEvents();
                }
                while (!stop);
                //while (true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        /// <summary>
        /// Convierte byte en una cadena
        /// </summary>
        /// <param name="msgBytes">Obtiene el mensaje</param>
        /// <returns>Mensaje dato cadena</returns>
        /// 
        #region [Convierte Byte a Cadena]
        private string ConvertByteArrayToString(byte[] msgBytes)
        {
            try
            {
                string msgString = System.Text.Encoding.Default.GetString(msgBytes);
                msgString = System.Text.Encoding.GetEncoding(Thread.CurrentThread.CurrentCulture.TextInfo.ANSICodePage).GetString(msgBytes);
                return msgString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        /// <summary>
        /// Escribe el registro en un archivo plano
        /// </summary>
        /// <param name="path">Ruta donde se ubicará el archivo</param>
        /// <param name="register">registro obtenido</param>
        /// 
        #region [Escribe Registro en Archivo Plano]
        private void WriteRegisterFile(string path, string register)
        {
            try
            {
                //Create or open the file
                StreamWriter oStreamWriter = new StreamWriter(path, true);
                //Write a register
                oStreamWriter.WriteLine(register);
                //Close the file
                oStreamWriter.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        /// <summary>
        /// Este método coloca los datos en una tabla o grilla
        /// </summary>
        /// <param name="NumRegister">Numero de registros</param>
        /// <param name="scaleIpAddress">Dirección IP Balanza</param>
        /// <param name="register">Registro obtenido</param>
        /// 
        #region [Ubica Datos en Tabla/Grilla]
        //private void SetRegisterGrid(int NumRegister, string scaleIpAddress, string register)
        //{
        //    try
        //    {
        //        if (this.InvokeRequired)
        //        {
        //            this.Invoke(new SetRegisterDs(SetRegisterGrid), new object[] { NumRegister, scaleIpAddress, register });
        //        }
        //        else
        //        {
        //            DataRow dr = this.ds.Tables["ExportedRegisters"].NewRow();
        //            dr["NumRegister"] = Convert.ToString(NumRegister);
        //            dr["ScaleIpAddress"] = scaleIpAddress;
        //            dr["ScaleRegister"] = register;
        //            this.ds.Tables["ExportedRegisters"].Rows.Add(dr);

        //            this.grvExRegisters.Refresh();
        //            this.grvExRegisters.FirstDisplayedScrollingRowIndex = this.grvExRegisters.Rows.Count - 1;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion


        /// <summary>
        /// Muestra el resultado obtenido en una grilla
        /// </summary>
        /// <param name="scaleIpAddress">Dirección IP Balanza</param>
        /// <param name="result">Resultado obtenido</param>
        /// 
        #region [Coloca Datos en Grilla]
        //private void SetResultGrid(string scaleIpAddress, int result)
        //{
        //    try
        //    {
        //        if (this.InvokeRequired)
        //        {
        //            this.Invoke(new SetResultDs(SetResultGrid), new object[] { scaleIpAddress, result });
        //        }
        //        else
        //        {
        //            DataRow[] rows = this.ds.Tables["ExportedResult"].Select("IpAddressResult='" + scaleIpAddress + "'");

        //            if (rows.Length > 0)
        //            {
        //                rows[0]["ExResult"] = DibalscopResultToString(result);
        //            }
        //            else
        //            {
        //                DataRow dr = this.ds.Tables["ExportedResult"].NewRow();
        //                dr["IpAddressResult"] = scaleIpAddress;
        //                dr["ExResult"] = Languages.Messages.waiting;
        //                this.ds.Tables["ExportedResult"].Rows.Add(dr);
        //            }
        //            this.grvExResult.Refresh();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion


        ///// <summary>
        ///// Total de Registros
        ///// </summary>
        ///// <param name="text">Muestra en un mensaje el registro total obtenido</param>
        ///// 
        //#region [Registro Total]
        //private void SetTotalRegister(string text)
        //{
        //    if (this.lblNRegisters.InvokeRequired)
        //    {
        //        this.Invoke(new SetText(SetTotalRegister), new object[] { text });
        //    }
        //    else
        //    {
        //        this.lblNRegisters.Text = text;
        //    }
        //}
        //#endregion


        /// <summary>
        /// Manejador de Registro
        /// </summary>
        /// <param name="register">Registro obtenido</param>
        /// <returns>Muestra los registros</returns>
        /// 
        #region [Manejador de Registro]
        private bool ManageRegister(string register)
        {
            try
            {
                bool stop = false;

                switch (register.Substring(2, 2))
                {
                    case "HV":
                        if (register.Substring(14, 1) == "N")
                            stop = true;
                        break;
                    case "LY":
                    case "LA":
                    default:
                        break;
                }
                return stop;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        //private string DibalscopResultToString(int result)
        //{
        //    try
        //    {
        //        string strResult = string.Empty;
        //        switch (result)
        //        {
        //            case 0:
        //                strResult = "0." + Languages.Messages.nothing2read; //"0.Waiting...Nothing to read";
        //                break;
        //            case 1:
        //                strResult = "1." + Languages.Messages.readingRegister;  //"1.Reading register";
        //                break;
        //            case 2:
        //                strResult = "2." + Languages.Messages.finished; //"2.Finished";
        //                break;
        //            case -1:
        //                strResult = "-1." + Languages.Messages.inac_socket; //"-1.Inaccessible socket";
        //                break;
        //            case -2:
        //                strResult = "-2." + Languages.Messages.scaleEndCom; //"-2.Scale ends communication";
        //                break;
        //            case -3:
        //                strResult = "-3." + Languages.Messages.socketNoCon; //"-3.Socket is not connected";
        //                break;
        //            case -4:
        //                strResult = "-4." + Languages.Messages.netError; //"-4.Net error";
        //                break;
        //            case -5:
        //                strResult = "-5." + Languages.Messages.conError; //"-5.Connection error";
        //                break;
        //            case -6:
        //                strResult = "-6." + Languages.Messages.lenError; //"-6.Length of register < 2";
        //                break;
        //            case -7:
        //                strResult = "-7." + Languages.Messages.logsError; //"-7.Logs file error";
        //                break;
        //            case -9:
        //                strResult = "-9." + Languages.Messages.readRegError; //"-9.ReadRegister Error";
        //                break;
        //            case -10:
        //                strResult = "-10." + Languages.Messages.timeoutCon; //"-10.Timeout without connection";
        //                break;
        //            case -11:
        //                strResult = "-11." + Languages.Messages.conError; //"-11.Connecting error";
        //                break;
        //            case -12:
        //                strResult = "-12." + Languages.Messages.unScaleCon; //"-12.Unexpected scale connection";
        //                break;
        //            case -13:
        //                strResult = "-13." + Languages.Messages.logsError; //"-13.Logs file error";
        //                break;
        //            case -14:
        //                strResult = "-14." + Languages.Messages.scaleIPFormatError; //"-14.Scale Ip format error";
        //                break;
        //            case -15:
        //                strResult = "-15." + Languages.Messages.pcIPFormatError; // "-15.PC Ip format error";
        //                break;
        //            case -19:
        //                strResult = "-19." + Languages.Messages.opServerError; //"-19.Open Server error";
        //                break;
        //            case -21:
        //                strResult = "-21." + Languages.Messages.closeSockErr; //"-21.Closing socket error";
        //                break;
        //            case -22:
        //                strResult = "-22." + Languages.Messages.closeSockErr; //"-22.Closing socket error";
        //                break;
        //            case -23:
        //                strResult = "-23." + Languages.Messages.resourceErr; //"-23.Releasing resources error";
        //                break;
        //            case -24:
        //                strResult = "-24." + Languages.Messages.pendRegErr; //"-24.Pending registers error";
        //                break;
        //            case -25:
        //                strResult = "-25." + Languages.Messages.logsError; //"-25.Logs file error";
        //                break;
        //            case -29:
        //                strResult = "-29." + Languages.Messages.closeServerErr; //"-29.Close Server error";
        //                break;
        //            case 31:
        //                strResult = "-30." + Languages.Messages.cancelled; //"30.Cancelled";
        //                break;
        //            case -31:
        //                strResult = "-31." + Languages.Messages.FINSendErr; //"-31.FIN sending error";
        //                break;
        //            case -32:
        //                strResult = strResult = "-32." + Languages.Messages.logsError; //"-32.Logs file error";
        //                break;
        //            case -39:
        //                strResult = "-39." + Languages.Messages.cancellingErr; //"-39.Canceling error";
        //                break;
        //        }
        //        return strResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #region INVOKE
        delegate void SetText(string text);
        delegate void SetRegisterDs(int a, string b, string c);
        delegate void SetResultDs(string a, int b);
        #endregion

        public static void Main(string[] args)
        {
            List<Balanza> listBalanzas = new List<Balanza>();

            int _direccioMaestra = 0;
            Random _random = new Random();

            for (int b = 1; b <= 1; b++)
            {
                Balanza _balanza = new Balanza()
                {
                    DireccionMaestra = _direccioMaestra,
                    Grupo = 0,
                    //DireccionIp = $"192.168.1.{b}",
                    DireccionIp = string.Empty, //"192.168.001.252",
                    PuertoRx = 3000,
                    ModeloBascula = _random.Next(2) == 0 ? "500RANGE" : "500RANGE"
                };

                listBalanzas.Add(_balanza);
                _direccioMaestra += 2;
            }

            List<Articulo> articulos = new List<Articulo>();

            for (int a = 0; a <= 69; a++)
            {
                Articulo _articulo = new Articulo()
                {
                    Codigo = a + 1,
                    TeclaDirecta = a,
                    Tipo = _random.Next(2) == 0 ? "PESADO" : "UNITARIO",
                    Nombre = $"ARTICULO {a}",
                    Precio = 2.45m
                };

                articulos.Add(_articulo);
            }

            DibalScale[] _dibalBalanzas = GetScales(listBalanzas);
            //dibalBalanzas[0].display = string.Empty;
            Program program = new Program();
            program.StartExport(listBalanzas);

            DibalItem2[] _dibalArticulos = GetItems(articulos);
            //dibalArticulos[0].type = 0;
            IntPtr ptrResult = ItemsSend2(_dibalBalanzas, _dibalBalanzas.Length, _dibalArticulos, _dibalArticulos.Length, 1, 10);
            //ItemsSend2 returns an ANSI char array(LPSTR);
            string Result = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(ptrResult);

            if (Result == "OK")
            {
                Console.WriteLine("Dato Generado!", Result);
            }
            else
            {
                Console.WriteLine("Error al ingresar el registro!", Result);
            }

            Console.WriteLine("Balanzas");

            //foreach (Balanza balanza1 in balanza)
            //{
            //    Console.WriteLine($"{balanza1.DireccionMaestra},{balanza1.Grupo},{balanza1.DireccionIp},{balanza1.PuertoRx},{balanza1.ModeloBascula}");
            //}

            Console.WriteLine("Artículos");

            foreach (Articulo articulo1 in articulos)
            {
                Console.WriteLine($"{articulo1.Codigo},{articulo1.TeclaDirecta},{articulo1.Tipo},{articulo1.Nombre},{articulo1.Precio}");
            }

            Console.ReadLine();
        }
    }

    /// <summary>
    /// Variables Balanza
    /// </summary>
    /// 
    #region
    public class Balanza
    {
        public int DireccionMaestra { get; set; }
        public int Grupo { get; set; }
        public string DireccionIp { get; set; }
        public int PuertoRx { get; set; }
        public string ModeloBascula { get; set; }
    }
    #endregion


    /// <summary>
    /// Variables Articulo
    /// </summary>
    /// 
    #region
    public class Articulo
    {
        public int Codigo { get; set; }
        public int TeclaDirecta { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
    #endregion
}
#endregion
