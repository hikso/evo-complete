using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace AdaptadorDibal
{
    #region Estructuras
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
    #endregion

    public class Dibal500RANGE
    {
        #region Campos Privados
        //Scale threads
        Thread[] oExportScaleThread;
        Int32 totalRegisters = 0;
        public const int TIMEOUT = 10;  //10 secons is the minimum time out for the socket
        #endregion


        [DllImport("Dibalscop.dll")]
        static extern int ReadRegister(ref int serverHandle,
                                byte[] register,
                                string scaleIpAddress,
                                int scalePortTx,
                                string pcIpAddress,
                                int pcPorRx,
                                int timeOut,
                                string pathLogs);


        private DibalScale[] GetScales(List<Balanza> misBalanzas)
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

        //HACK: GetScales solo sirve para convertir una lista de Balanza en un array de DibalScale... no debería usarse un mapeo mejor? dónde se llena la lista de DibalScale? deberíamos llenar siempre la lista de maestra + esclavas? sólo esclavas?




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



        public void DebeQuedar()
        {
            //var readResult = ReadRegister(ref serverHandle, registerBytes, ((DibalScale)scale).IpAddress, ((DibalScale)scale).txPort, ((DibalScale)scale).IpAddress, ((DibalScale)scale).txPort, TIMEOUT, ((DibalScale)scale).logsPath);

            //IntPtr ptrResult = ItemsSend2(_dibalBalanzas, _dibalBalanzas.Length, _dibalArticulos, _dibalArticulos.Length, 1, 10);
        }







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
                    //TODO: AGiraldo - Porqué la dirección IP de la báscula y el PC es la misma?

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


        // Método usado por ReceiveRegisters
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
    }
}