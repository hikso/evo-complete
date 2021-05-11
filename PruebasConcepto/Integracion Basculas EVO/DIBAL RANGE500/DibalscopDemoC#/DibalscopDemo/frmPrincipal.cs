//#define UNICODE //#undef UNICODE
//UNICODE flag is defined or not in project properties. 
//If flag UNICODE is defined strings are considered as Wide String(2 bytes), if not they are considered as Narrow String(1 byte)
//If you want to work with wide strings(Unicode), it is necessary that 
//dibalscop.dll is compiled with the flag Unicode(Check it in Dibalscop.dll Properties->Version->Comments)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using DibalImage;


namespace DibalscopDemo
{
    public partial class frmPrincipal : Form
    {

        #region Dibalscop IMPORTED METHODS

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
#if UNICODE
										[MarshalAs(UnmanagedType.LPWStr)] //Manage as wide string
#endif
 string pathLogs);

        [DllImport("Dibalscop.dll")]
        static extern int CancelReadRegister(ref int serverHandle,
#if UNICODE
												[MarshalAs(UnmanagedType.LPWStr)] //Manage as wide string
#endif
 string pathLogs);

        

        #endregion

        #region ESTRUCTURES

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

        public struct DibalItem2
        {
            public char action;
            public int code;
            public int directKey;
            public double price;
#if UNICODE
           [MarshalAs(UnmanagedType.LPWStr)]   
#endif
            public string itemName;
#if UNICODE
           [MarshalAs(UnmanagedType.LPWStr)]   
#endif
            public string itemName2;
            public int type;
            public int section;
            public int labelFormat;
            public int EAN13Format;
            public int VATType;
            public double offerPrice;
#if UNICODE
           [MarshalAs(UnmanagedType.LPWStr)]   
#endif
            public string expiryDate;
#if UNICODE
           [MarshalAs(UnmanagedType.LPWStr)]   
#endif
            public string extraDate;
            public double tare;
#if UNICODE
           [MarshalAs(UnmanagedType.LPWStr)]   
#endif
            public string EANScanner;
            public int productClass;
            public int productDirectNumber;
            public int alterPrice;
#if UNICODE
           [MarshalAs(UnmanagedType.LPWStr)]   
#endif
            public string textG;

            public DibalItem2(char _action, int _code, int _directKey, double _price, string _name, string _name2, int _type, int _section, int _labelFormat, int _EAN13Format, int _VATType, double _offerPrice, string _expiryDate, string _extraDate, double _tare, string _EANScanner, int _productClass, int _productDirectNumber, int _alterPrice, string _textG)
            {
                this.action = _action;
                this.code = _code;
                this.directKey = _directKey;
                this.price = _price;
                this.itemName = _name;
                this.itemName2 = _name2;
                this.type = _type;
                this.section = _section;
                this.labelFormat = _labelFormat;
                this.EAN13Format = _EAN13Format;
                this.VATType = _VATType;
                this.offerPrice = _offerPrice;
                this.expiryDate = _expiryDate;
                this.extraDate = _extraDate;
                this.tare = _tare;
                this.EANScanner = _EANScanner;
                this.productClass = _productClass;
                this.productDirectNumber = _productDirectNumber;
                this.alterPrice = _alterPrice;
                this.textG = _textG;
            }
        }
        public struct DibalRegister
        {
#if UNICODE
			[MarshalAs(UnmanagedType.LPWStr)]   //Manage as wide string
#endif
            public string register;
            int sendCompleted;

            public DibalRegister(string _register, int _sendCompleted)
            {
                this.register = _register;
                this.sendCompleted = _sendCompleted;
            }
        }

        public struct DibalImageStruct
        {
            public string path;
            public int type;
            public int id;
            public int assignPlu;

            public DibalImageStruct(string _path, int _type, int _id,int _assignPlu)
            {
                this.path = _path;
                this.type = _type;
                this.id = _id;
                this.assignPlu = _assignPlu;
            }
        }

        
        #endregion

        #region VARIABLES

        DataSet ds = new DataSet();
        const string MODEL500RANGE = "500RANGE";
        const string MODELLSERIES = "LSERIES";        

        #region Export variables

        public const int TIMEOUT = 10;	//10secons is the minimum time out for the socket

        bool cancel = false;
        bool finish = false;
        IPAddress[] Addresses;			//PC Ip addresses
        Thread[] oExportScaleThread;	//Scale threads
        string PcIp = string.Empty;		//PC Ip address
        Int32 totalRegisters = 0;
        bool exportContinuous;

        string pathLogs = string.Empty;

        #endregion

        #endregion

        #region INVOKE

        delegate void SetText(string text);
        delegate void SetRegisterDs(int a, string b, string c);
        delegate void SetResultDs(string a, int b);

        #endregion

        public frmPrincipal()
        {
            try
            {
                InitializeComponent();
                Load_Language();
                DataLoad();
                Application.Idle += new EventHandler(Application_Idle);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region PRIVATED METHODS

        private void DataLoad()
        {
            //Get DibaloscopDemo version
            lblDibalSDK.Text = "DibalSDK v1.0.1.13";

            string versionDemo = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
            versionDemo = versionDemo.Replace(" ", "");
            this.Text = "DibalscopDemoC# v" + versionDemo;
#if UNICODE
            lblDibalSDK.Text += " (UNICODE)";
            this.Text = this.Text + " (UNICODE)";
#endif
            //Get Diabalscop version
            string versionDibalscop = System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.StartupPath + "\\Dibalscop.dll").FileVersion;
            versionDibalscop = versionDibalscop.Replace(" ", "");
            versionDibalscop = versionDibalscop.Replace(',', '.');
            this.lblDibaldll.Text = "Dibalscop.dll v" + versionDibalscop;

            //Create Items table
            this.grvItems.AutoGenerateColumns = false;

            this.ds.Tables.Add(new DataTable("Items"));
            this.ds.Tables["Items"].Columns.Add(new DataColumn("Code"));
            this.ds.Tables["Items"].Columns.Add(new DataColumn("DirectKey"));
            this.ds.Tables["Items"].Columns.Add(new DataColumn("Price"));
            this.ds.Tables["Items"].Columns.Add(new DataColumn("Name"));
            this.ds.Tables["Items"].Columns.Add(new DataColumn("Type"));

            //Create items type column
            this.ds.Tables.Add(new DataTable("ArticleType"));
            this.ds.Tables["ArticleType"].Columns.Add(new DataColumn("articleValue"));
            this.ds.Tables["ArticleType"].Columns.Add(new DataColumn("articleType"));
            DataRow dr = this.ds.Tables["ArticleType"].NewRow();
            dr[0] = "0";
            dr[1] = Languages.Messages.weight;
            this.ds.Tables["ArticleType"].Rows.Add(dr);
            dr = this.ds.Tables["ArticleType"].NewRow();
            dr[0] = "1";
            dr[1] = Languages.Messages.unit;
            this.ds.Tables["ArticleType"].Rows.Add(dr);

            this.Type.ValueMember = this.ds.Tables["ArticleType"].Columns["articleValue"].ToString();
            this.Type.DisplayMember = this.ds.Tables["ArticleType"].Columns["articleType"].ToString();
            this.Type.DataSource = this.ds.Tables["ArticleType"];

            this.Code.DataPropertyName = "Code";
            this.DirectKey.DataPropertyName = "DirectKey";
            this.Price.DataPropertyName = "Price";
            this.itemName.DataPropertyName = "Name";
            this.Type.DataPropertyName = "Type";

            this.grvItems.DataSource = this.ds.Tables["Items"];

            //Create Scale table
            this.grvScales.AutoGenerateColumns = false;

            this.ds.Tables.Add(new DataTable("Scales"));
            this.ds.Tables["Scales"].Columns.Add(new DataColumn("MasterAddress"));
            this.ds.Tables["Scales"].Columns.Add(new DataColumn("Group"));
            this.ds.Tables["Scales"].Columns.Add(new DataColumn("IpAddress"));
            this.ds.Tables["Scales"].Columns.Add(new DataColumn("ReceptionPortRx"));
            this.ds.Tables["Scales"].Columns.Add(new DataColumn("Model"));

            //Create Model column
            this.ds.Tables.Add(new DataTable("ScalesModel"));
            this.ds.Tables["ScalesModel"].Columns.Add(new DataColumn("modelValue"));
            this.ds.Tables["ScalesModel"].Columns.Add(new DataColumn("modelType"));
            DataRow drModel = this.ds.Tables["ScalesModel"].NewRow();
            drModel[0] = "0";
            drModel[1] = "500RANGE";
            this.ds.Tables["ScalesModel"].Rows.Add(drModel);
            drModel = this.ds.Tables["ScalesModel"].NewRow();
            drModel[0] = "1";
            drModel[1] = "LSERIES";
            this.ds.Tables["ScalesModel"].Rows.Add(drModel);

            this.Model.ValueMember = this.ds.Tables["ScalesModel"].Columns["modelValue"].ToString();
            this.Model.DisplayMember = this.ds.Tables["ScalesModel"].Columns["modelType"].ToString();
            this.Model.DataSource = this.ds.Tables["ScalesModel"];

            this.MasterAddress.DataPropertyName = "MasterAddress";
            this.Group.DataPropertyName = "Group";
            this.IpAddress.DataPropertyName = "IpAddress";
            this.ReceptionPortRx.DataPropertyName = "ReceptionPortRx";
            this.Model.DataPropertyName = "Model";
            this.grvScales.DataSource = this.ds.Tables["Scales"];      
            
            //create results grid
            this.ds.Tables.Add(new DataTable("Result"));
            this.ds.Tables["Result"].Columns.Add(new DataColumn("IpAddress"));
            this.ds.Tables["Result"].Columns.Add(new DataColumn("Result"));

            //create imageResults grid
            this.ds.Tables.Add(new DataTable("ImageResult"));
            this.ds.Tables["ImageResult"].Columns.Add(new DataColumn("IpAddress"));
            this.ds.Tables["ImageResult"].Columns.Add(new DataColumn("Result"));

            this.IpAddressResult.DataPropertyName = "ImageIpAddressResult";
            this.Result.DataPropertyName = "ImageResult";

            this.grvImageResult.DataSource = this.ds.Tables["ImageResult"];


            //create registers grid
            this.ds.Tables.Add(new DataTable("Registers"));
            this.ds.Tables["Registers"].Columns.Add(new DataColumn("Register"));
            this.Register.DataPropertyName = "Register";

            this.grvRegisters.DataSource = this.ds.Tables["Registers"];

            //Create showWindow combo
            this.ds.Tables.Add(new DataTable("ShowWindow"));
            this.ds.Tables["ShowWindow"].Columns.Add(new DataColumn("ShowWindowValue"));
            this.ds.Tables["ShowWindow"].Columns.Add(new DataColumn("ShowWindowText"));
            dr = this.ds.Tables["ShowWindow"].NewRow();
            dr[0] = "0";
            dr[1] = Languages.Messages.no;
            this.ds.Tables["ShowWindow"].Rows.Add(dr);
            dr = this.ds.Tables["ShowWindow"].NewRow();
            dr[0] = "1";
            dr[1] = Languages.Messages.yes;
            this.ds.Tables["ShowWindow"].Rows.Add(dr);

            this.cboShowWindow.ValueMember = this.ds.Tables["ShowWindow"].Columns["ShowWindowValue"].ToString();
            this.cboShowWindow.DisplayMember = this.ds.Tables["ShowWindow"].Columns["ShowWindowText"].ToString();
            this.cboShowWindow.DataSource = this.ds.Tables["ShowWindow"];
            this.cboShowWindow.SelectedIndex = 1;

            //Create closeTime combo
            this.ds.Tables.Add(new DataTable("CloseTime"));
            this.ds.Tables["CloseTime"].Columns.Add(new DataColumn("CloseTimeValue"));
            this.ds.Tables["CloseTime"].Columns.Add(new DataColumn("CloseTimeText"));
            dr = this.ds.Tables["CloseTime"].NewRow();
            dr[0] = "-1";
            dr[1] = Languages.Messages.manual;
            this.ds.Tables["CloseTime"].Rows.Add(dr);
            dr = this.ds.Tables["CloseTime"].NewRow();
            dr[0] = "0";
            dr[1] = "0 " + Languages.Messages.seconds;
            this.ds.Tables["CloseTime"].Rows.Add(dr);
            dr = this.ds.Tables["CloseTime"].NewRow();
            dr[0] = "2";
            dr[1] = "2 " + Languages.Messages.seconds;
            this.ds.Tables["CloseTime"].Rows.Add(dr);
            dr = this.ds.Tables["CloseTime"].NewRow();
            dr[0] = "5";
            dr[1] = "5 " +Languages.Messages.seconds;;
            this.ds.Tables["CloseTime"].Rows.Add(dr);
            dr = this.ds.Tables["CloseTime"].NewRow();
            dr[0] = "10";
            dr[1] = "10 " + Languages.Messages.seconds;
            this.ds.Tables["CloseTime"].Rows.Add(dr);
            dr = this.ds.Tables["CloseTime"].NewRow();
            dr[0] = "20";
            dr[1] = "20 " + Languages.Messages.seconds;
            this.ds.Tables["CloseTime"].Rows.Add(dr);

            this.cboCloseTime.ValueMember = this.ds.Tables["CloseTime"].Columns["CloseTimeValue"].ToString();
            this.cboCloseTime.DisplayMember = this.ds.Tables["CloseTime"].Columns["CloseTimeText"].ToString();
            this.cboCloseTime.DataSource = this.ds.Tables["CloseTime"];
            this.cboCloseTime.SelectedIndex = 2;

            //Create Export Scale table
            this.grvExportScales.AutoGenerateColumns = false;

            this.ds.Tables.Add(new DataTable("ExportScales"));
            this.ds.Tables["ExportScales"].Columns.Add(new DataColumn("ExMasterAddress"));
            this.ds.Tables["ExportScales"].Columns.Add(new DataColumn("ExIpAddress"));
            this.ds.Tables["ExportScales"].Columns.Add(new DataColumn("ExReceptionPortRx"));
            this.ds.Tables["ExportScales"].Columns.Add(new DataColumn("ExSendPortTx"));

            this.ExMasterAddress.DataPropertyName = "ExMasterAddress";
            this.ExIpAddress.DataPropertyName = "ExIpAddress";
            this.ExReceptionPortRx.DataPropertyName = "ExReceptionPortRx";
            this.ExSendPortTx.DataPropertyName = "ExSendPortTx";

            this.grvExportScales.DataSource = this.ds.Tables["ExportScales"];


            //create Export registers grid
            this.grvExRegisters.AutoGenerateColumns = false;

            this.ds.Tables.Add(new DataTable("ExportedRegisters"));
            this.ds.Tables["ExportedRegisters"].Columns.Add(new DataColumn("NumRegister"));
            this.ds.Tables["ExportedRegisters"].Columns.Add(new DataColumn("ScaleIpAddress"));
            this.ds.Tables["ExportedRegisters"].Columns.Add(new DataColumn("ScaleRegister"));

            this.NumRegister.DataPropertyName = "NumRegister";
            this.ScaleIpAddress.DataPropertyName = "ScaleIpAddress";
            this.ScaleRegister.DataPropertyName = "ScaleRegister";

            this.grvExRegisters.DataSource = this.ds.Tables["ExportedRegisters"];

            //create Export result grid
            this.grvExResult.AutoGenerateColumns = false;

            this.ds.Tables.Add(new DataTable("ExportedResult"));
            this.ds.Tables["ExportedResult"].Columns.Add(new DataColumn("IpAddressResult"));
            this.ds.Tables["ExportedResult"].Columns.Add(new DataColumn("ExResult"));

            this.IpAddressResult.DataPropertyName = "IpAddressResult";
            this.ExResult.DataPropertyName = "ExResult";

            this.grvExResult.DataSource = this.ds.Tables["ExportedResult"];


            //Insert Pc Ip address
            string hostname = Dns.GetHostName();
            this.Addresses = Dns.GetHostAddresses(hostname);
            for (int i = 0; i < Addresses.Length; i++)
            {
                if (Addresses[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    this.PcIp = Convert.ToString(Addresses[i]);
                    break;
                }
            }
            this.txtExIpPc.Text = PcIp;

            //Default export file path
            this.txtExportFilePath.Text = Application.StartupPath;
            this.txtLogsFilePath.Text = string.Empty;	//No logs

            //Create Image Scale table
            this.grvImageScales.AutoGenerateColumns = false;

            this.ds.Tables.Add(new DataTable("ImageScales"));
            this.ds.Tables["ImageScales"].Columns.Add(new DataColumn("ImgMasterAddress"));
            this.ds.Tables["ImageScales"].Columns.Add(new DataColumn("ImgGroup"));
            this.ds.Tables["ImageScales"].Columns.Add(new DataColumn("ImgIpAddress"));
            this.ds.Tables["ImageScales"].Columns.Add(new DataColumn("ImgReceptionPortRx"));
            this.ds.Tables["ImageScales"].Columns.Add(new DataColumn("ImgModel"));
            this.ds.Tables["ImageScales"].Columns.Add(new DataColumn("ImgDisplaySize"));

            //Create Image Model column
            this.ds.Tables.Add(new DataTable("ImageScalesModel"));
            this.ds.Tables["ImageScalesModel"].Columns.Add(new DataColumn("imgModelValue"));
            this.ds.Tables["ImageScalesModel"].Columns.Add(new DataColumn("imgModelType"));
            DataRow drImgModel = this.ds.Tables["ImageScalesModel"].NewRow();
            drImgModel[0] = "0";
            drImgModel[1] = "500RANGE";
            this.ds.Tables["ImageScalesModel"].Rows.Add(drImgModel);
            drImgModel = this.ds.Tables["ImageScalesModel"].NewRow();
            drImgModel[0] = "1";
            drImgModel[1] = "LSERIES";
            this.ds.Tables["ImageScalesModel"].Rows.Add(drImgModel);

            this.ImgModel.ValueMember = this.ds.Tables["ImageScalesModel"].Columns["imgModelValue"].ToString();
            this.ImgModel.DisplayMember = this.ds.Tables["ImageScalesModel"].Columns["imgModelType"].ToString();
            this.ImgModel.DataSource = this.ds.Tables["ImageScalesModel"];

            this.ImgMasterAddress.DataPropertyName = "ImgMasterAddress";
            this.ImgGroup.DataPropertyName = "ImgGroup";
            this.ImgIpAddress.DataPropertyName = "ImgIpAddress";
            this.ImgReceptionPortRx.DataPropertyName = "ImgReceptionPortRx";
            this.ImgModel.DataPropertyName = "ImgModel";
            this.grvImageScales.DataSource = this.ds.Tables["ImageScales"];

            //Create Image DisplaySize column
            this.ds.Tables.Add(new DataTable("ImageScalesDisplaySize"));
            this.ds.Tables["ImageScalesDisplaySize"].Columns.Add(new DataColumn("imgDisplaySizeValue"));
            this.ds.Tables["ImageScalesDisplaySize"].Columns.Add(new DataColumn("imgDisplaySizeType"));
            DataRow drImgDisplaySize = this.ds.Tables["ImageScalesDisplaySize"].NewRow();
            drImgDisplaySize[0] = "0";
            drImgDisplaySize[1] = "7 " + Languages.Messages.inches;
            this.ds.Tables["ImageScalesDisplaySize"].Rows.Add(drImgDisplaySize);
            drImgDisplaySize = this.ds.Tables["ImageScalesDisplaySize"].NewRow();
            drImgDisplaySize[0] = "1";
            drImgDisplaySize[1] = "12 " + Languages.Messages.inches;
            this.ds.Tables["ImageScalesDisplaySize"].Rows.Add(drImgDisplaySize);
            drImgDisplaySize = this.ds.Tables["ImageScalesDisplaySize"].NewRow();
            drImgDisplaySize[0] = "2";
            drImgDisplaySize[1] = "15 " + Languages.Messages.inches;
            this.ds.Tables["ImageScalesDisplaySize"].Rows.Add(drImgDisplaySize);


            this.ImgDisplaySize.ValueMember = this.ds.Tables["ImageScalesDisplaySize"].Columns["imgDisplaySizeValue"].ToString();
            this.ImgDisplaySize.DisplayMember = this.ds.Tables["ImageScalesDisplaySize"].Columns["imgDisplaySizeType"].ToString();
            this.ImgDisplaySize.DataSource = this.ds.Tables["ImageScalesDisplaySize"];

            this.ImgMasterAddress.DataPropertyName = "ImgMasterAddress";
            this.ImgGroup.DataPropertyName = "ImgGroup";
            this.ImgIpAddress.DataPropertyName = "ImgIpAddress";
            this.ImgReceptionPortRx.DataPropertyName = "ImgReceptionPortRx";
            this.ImgModel.DataPropertyName = "ImgModel";
            this.ImgDisplaySize.DataPropertyName = "ImgDisplaySize";
            this.grvImageScales.DataSource = this.ds.Tables["ImageScales"];

            //Create Images table
            this.grvImages.AutoGenerateColumns = false;

            this.ds.Tables.Add(new DataTable("Images"));
            this.ds.Tables["Images"].Columns.Add(new DataColumn("ImgPath"));
            this.ds.Tables["Images"].Columns.Add(new DataColumn("ImgId"));
            this.ds.Tables["Images"].Columns.Add(new DataColumn("ImgType"));
            
            //Create Image Type column
            this.ds.Tables.Add(new DataTable("ImageType"));
            this.ds.Tables["ImageType"].Columns.Add(new DataColumn("typeValue"));
            this.ds.Tables["ImageType"].Columns.Add(new DataColumn("typeType"));
            DataRow drImgType = this.ds.Tables["ImageType"].NewRow();
            drImgType[0] = "1";
            drImgType[1] = Languages.Messages.publicity;
            this.ds.Tables["ImageType"].Rows.Add(drImgType);
            drImgType = this.ds.Tables["ImageType"].NewRow();
            drImgType[0] = "2";
            drImgType[1] = Languages.Messages.article_order;
            this.ds.Tables["ImageType"].Rows.Add(drImgType);
            drImgType = this.ds.Tables["ImageType"].NewRow();
            drImgType[0] = "0";
            drImgType[1] = Languages.Messages.article_plu;
            this.ds.Tables["ImageType"].Rows.Add(drImgType);

            this.ImgType.ValueMember = this.ds.Tables["ImageType"].Columns["typeValue"].ToString();
            this.ImgType.DisplayMember = this.ds.Tables["ImageType"].Columns["typeType"].ToString();
            this.ImgType.DataSource = this.ds.Tables["ImageType"];
            
            this.ImgPath.DataPropertyName = "ImgPath";
            this.ImgId.DataPropertyName = "ImgId";
            this.ImgType.DataPropertyName = "ImgType";
            DataRow datar = this.ds.Tables["Images"].NewRow();
            //datar["ImgPath"] = "";
            //datar["ImgId"] = 0;
            this.ds.Tables["Images"].Rows.Add(datar);
            this.grvImages.DataSource = this.ds.Tables["Images"];



            this.ds.Tables.Add(new DataTable("ImageFolder"));
            this.ds.Tables["ImageFolder"].Columns.Add(new DataColumn("ImgPathFolder"));
            this.ds.Tables["ImageFolder"].Columns.Add(new DataColumn("ImgTypeFolder"));


            this.ds.Tables.Add(new DataTable("ImageTypeFolder"));
            this.ds.Tables["ImageTypeFolder"].Columns.Add(new DataColumn("typeValue"));
            this.ds.Tables["ImageTypeFolder"].Columns.Add(new DataColumn("typeType"));
            DataRow drImgTypeF = this.ds.Tables["ImageTypeFolder"].NewRow();
            drImgTypeF[0] = "1";
            drImgTypeF[1] = Languages.Messages.publicity;
            this.ds.Tables["ImageTypeFolder"].Rows.Add(drImgTypeF);
            drImgTypeF = this.ds.Tables["ImageTypeFolder"].NewRow();
            drImgTypeF[0] = "2";
            drImgTypeF[1] = Languages.Messages.article_order;
            this.ds.Tables["ImageTypeFolder"].Rows.Add(drImgTypeF);
            drImgTypeF = this.ds.Tables["ImageTypeFolder"].NewRow();
            drImgTypeF[0] = "0";
            drImgTypeF[1] = Languages.Messages.article_plu;
            this.ds.Tables["ImageTypeFolder"].Rows.Add(drImgTypeF);

            this.ImgTypeFolder.ValueMember = this.ds.Tables["ImageTypeFolder"].Columns["typeValue"].ToString();
            this.ImgTypeFolder.DisplayMember = this.ds.Tables["ImageTypeFolder"].Columns["typeType"].ToString();
            this.ImgTypeFolder.DataSource = this.ds.Tables["ImageTypeFolder"];

            this.ImgPathFolder.DataPropertyName = "ImgPathFolder";
            this.ImgTypeFolder.DataPropertyName = "ImgTypeFolder";
            DataRow datar1 = this.ds.Tables["ImageFolder"].NewRow();

            this.ds.Tables["ImageFolder"].Rows.Add(datar1);
            this.grvImageFolder.DataSource = this.ds.Tables["ImageFolder"];
           
            this.chkImageFile.Checked = true;
            this.chkImageFolder.Checked = true;
            this.chkImageFolder.Checked = false;
            
            this.grvImages.Columns["ImgPath"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.grvImageFolder.Columns["ImgPathFolder"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.grvImages.Columns["ImgPath"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.grvImageFolder.Columns["ImgPathFolder"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //this.grvImageFolder.Rows.Add();
            this.grvImageFolder.ClearSelection();
            this.grvImages.ClearSelection();
        }

        #region Import Methods

        private void GenerateImportScales()
        {
            try
            {
                int numScales = 0;
                //Example values
                string IpAddress = "192.168.1."; // string.Empty;
                int Rxport = 3000;

                //delete result rows
                this.ds.Tables["Scales"].Rows.Clear();
                int.TryParse(this.txtNScales.Text, out numScales);

                //Add scales to gridView
                this.ds.Tables["Scales"].BeginLoadData();
                for (int j = 1; j <= numScales; j++)
                {
                    DataRow dr = ds.Tables["Scales"].NewRow();

                    dr["MasterAddress"] = Convert.ToString((j * 2) - 2);
                    dr["IpAddress"] = Convert.ToString(IpAddress + j);
                    dr["ReceptionPortRx"] = Convert.ToString(Rxport);
                    dr["Model"] = 0;
                    dr["Group"] = Convert.ToString(0);

                    this.ds.Tables["Scales"].Rows.Add(dr);
                }
                this.ds.Tables["Scales"].EndLoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }        

        private DibalScale[] GetScales(DataTable dtScales)
        {
            try
            {
                DibalScale scale;
                DibalScale[] myScales = new DibalScale[dtScales.Rows.Count];
                ArrayList arlScale = new ArrayList();
                //Default Scale variables
                int scaleMasterAddressAux = 0;
                string scaleIpAddressAux = string.Empty;
                int scalePortRxAux = 3000;
                int scalePortTxAux = 3001;
                string scaleModelAux = MODEL500RANGE;
                string scaleDisplayAux = string.Empty;
                string scaleSectionsAux = string.Empty;
                int scaleGroupAux = 0;
                string scaleLogsPathAux = string.Empty;
                
                foreach (DataRow dr in dtScales.Rows)
                {
                    if (dtScales.TableName == "Scales")
                    {
                        //Cast DBnull of DataGrid
                        int.TryParse(Convert.ToString(dr["MasterAddress"]), out scaleMasterAddressAux);
                        int.TryParse(Convert.ToString(dr["Group"]), out scaleGroupAux);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["IpAddress"])))
                            scaleIpAddressAux = Convert.ToString(dr["IpAddress"]);
                        int.TryParse(Convert.ToString(dr["ReceptionPortRx"]), out scalePortRxAux);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Model"])))
                        {
                            if (Convert.ToString(dr["Model"]) == "0")
                                scaleModelAux = MODEL500RANGE;
                            else
                                scaleModelAux = MODELLSERIES;
                        }


                    }
                    else if (dtScales.TableName == "ExportScales")
                    {
                        //Cast DBnull of DataGrid
                        int.TryParse(Convert.ToString(dr["ExMasterAddress"]), out scaleMasterAddressAux);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ExIpAddress"])))
                            scaleIpAddressAux = Convert.ToString(dr["ExIpAddress"]);
                        int.TryParse(Convert.ToString(dr["ExReceptionPortRx"]), out scalePortRxAux);
                        int.TryParse(Convert.ToString(dr["ExSendPortTx"]), out scalePortTxAux);
                    }
                    else
                    {
                        //Cast DBnull of DataGrid
                        int.TryParse(Convert.ToString(dr["ImgMasterAddress"]), out scaleMasterAddressAux);
                        int.TryParse(Convert.ToString(dr["ImgGroup"]), out scaleGroupAux);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ImgIpAddress"])))
                            scaleIpAddressAux = Convert.ToString(dr["ImgIpAddress"]);
                        int.TryParse(Convert.ToString(dr["ImgReceptionPortRx"]), out scalePortRxAux);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ImgModel"])))
                        {
                            if (Convert.ToString(dr["ImgModel"]) == "0")
                                scaleModelAux = MODEL500RANGE;
                            else
                                scaleModelAux = MODELLSERIES;
                        }
                        
                    }
                    //Create a scale
                    scale = new DibalScale(scaleMasterAddressAux, scaleIpAddressAux, scalePortTxAux, scalePortRxAux, scaleModelAux, scaleDisplayAux, scaleSectionsAux, scaleGroupAux, scaleLogsPathAux);
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


        private ImagePalletized.DibalScale[] GetImageScales(DataTable dtScales)
        {
            try
            {
                ImagePalletized.DibalScale scale;
                ImagePalletized.DibalScale[] myScales = new ImagePalletized.DibalScale[dtScales.Rows.Count];
                ArrayList arlScale = new ArrayList();
                //Default Scale variables
                int scaleMasterAddressAux = 0;
                string scaleIpAddressAux = string.Empty;
                int scalePortRxAux = 3000;
                int scalePortTxAux = 3001;
                string scaleModelAux = MODEL500RANGE;
                string scaleDisplayAux = string.Empty;
                string scaleSectionsAux = string.Empty;
                int scaleGroupAux = 0;
                string scaleLogsPathAux = string.Empty;

                foreach (DataRow dr in dtScales.Rows)
                {
                    if (dtScales.TableName == "Scales")
                    {
                        //Cast DBnull of DataGrid
                        int.TryParse(Convert.ToString(dr["MasterAddress"]), out scaleMasterAddressAux);
                        int.TryParse(Convert.ToString(dr["Group"]), out scaleGroupAux);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["IpAddress"])))
                            scaleIpAddressAux = Convert.ToString(dr["IpAddress"]);
                        int.TryParse(Convert.ToString(dr["ReceptionPortRx"]), out scalePortRxAux);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["Model"])))
                        {
                            if (Convert.ToString(dr["Model"]) == "0")
                                scaleModelAux = MODEL500RANGE;
                            else
                                scaleModelAux = MODELLSERIES;
                        }


                    }
                    else if (dtScales.TableName == "ExportScales")
                    {
                        //Cast DBnull of DataGrid
                        int.TryParse(Convert.ToString(dr["ExMasterAddress"]), out scaleMasterAddressAux);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ExIpAddress"])))
                            scaleIpAddressAux = Convert.ToString(dr["ExIpAddress"]);
                        int.TryParse(Convert.ToString(dr["ExReceptionPortRx"]), out scalePortRxAux);
                        int.TryParse(Convert.ToString(dr["ExSendPortTx"]), out scalePortTxAux);
                    }
                    else
                    {
                        //Cast DBnull of DataGrid
                        int.TryParse(Convert.ToString(dr["ImgMasterAddress"]), out scaleMasterAddressAux);
                        int.TryParse(Convert.ToString(dr["ImgGroup"]), out scaleGroupAux);
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ImgIpAddress"])))
                            scaleIpAddressAux = Convert.ToString(dr["ImgIpAddress"]);
                        int.TryParse(Convert.ToString(dr["ImgReceptionPortRx"]), out scalePortRxAux);

                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ImgModel"])))
                        {
                            if (Convert.ToString(dr["ImgModel"]) == "0")
                                scaleModelAux = MODEL500RANGE;
                            else
                                scaleModelAux = MODELLSERIES;
                        }

                    }
                    //Create a scale
                    scale = new ImagePalletized.DibalScale(scaleMasterAddressAux, scaleIpAddressAux, scalePortTxAux, scalePortRxAux, scaleModelAux, scaleDisplayAux, scaleSectionsAux, scaleGroupAux, scaleLogsPathAux);
                    //Add a scale to ArrayList "arlScale"
                    arlScale.Add(scale);
                    //Copy the Scale objects of the ArrayList "arlScale" to a Scale array "myScales"
                    myScales = (ImagePalletized.DibalScale[])arlScale.ToArray(typeof(ImagePalletized.DibalScale));
                }
                return myScales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerateItems()
        {
            try
            {
                int numArticles = 0;
                //Example values
                int directkey = 0;
                double price = 2.45;
                string name = Languages.Messages.item + " ";
                int type = 0;

                //delete result rows
                this.ds.Tables["Items"].Rows.Clear();
                int.TryParse(this.txtNArticles.Text, out numArticles);

                //Add Items to gridView
                this.ds.Tables["Items"].BeginLoadData();
                for (int j = 1; j <= numArticles; j++)
                {
                    DataRow dr = ds.Tables["Items"].NewRow();

                    dr["Code"] = Convert.ToString(j);
                    dr["DirectKey"] = Convert.ToString(directkey + j);
                    dr["Price"] = Convert.ToString(price);
                    dr["Name"] = Convert.ToString(name + j);
                    dr["Type"] = Convert.ToInt32(type);

                    this.ds.Tables["Items"].Rows.Add(dr);
                }
                this.ds.Tables["Items"].EndLoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DibalItem2[] GetItems()
        {
            try
            {
                DibalItem2 item;
                DibalItem2[] myItems = new DibalItem2[ds.Tables["Items"].Rows.Count];
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

                foreach (DataRow dr in ds.Tables["Items"].Rows)
                {
                    //Cast DBnull of DataGrid
                    int.TryParse(Convert.ToString(dr["Code"]), out itemCodeAux);

                    int.TryParse(Convert.ToString(dr["DirectKey"]), out itemDirectKeyAux);

                    double.TryParse(Convert.ToString(dr["Price"]), out itemPriceAux);

                    if (!string.IsNullOrEmpty(Convert.ToString(dr["Name"])))
                        itemNameAux = Convert.ToString(dr["Name"]);

                    int.TryParse(Convert.ToString(dr["Type"]), out itemTypeAux);

                    //Create an Item
                    item = new DibalItem2(action, itemCodeAux, itemDirectKeyAux, itemPriceAux, itemNameAux, itemName2Aux, itemTypeAux, itemSectionAux, labelFormat, EAN13Format, VATType, offerPrice, itemExpiryDaysAux, itemExtraDate, tare, EANScanner, productClass, NRP, itemAlterPrice, itemTextG);
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

        private DibalRegister[] GetRegisters()
        {
            try
            {
                DibalRegister register;
                DibalRegister[] myRegister = new DibalRegister[ds.Tables["Registers"].Rows.Count]; 
                ArrayList arlRegister = new ArrayList();
                string registerAux = string.Empty;

                foreach (DataRow dr in ds.Tables["Registers"].Rows)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dr["Register"])))
                        registerAux = Convert.ToString(dr["Register"]);

                    register = new DibalRegister(registerAux, 0);
                    arlRegister.Add(register);
                    myRegister = (DibalRegister[])arlRegister.ToArray(typeof(DibalRegister));
                }
                return myRegister;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateResultTable(string result, DibalScale[] myScale)
        {
            try
            {
                int i = 0;
                int j = 0;

                this.ds.Tables["Result"].BeginLoadData();
                this.ds.Tables["Result"].Rows.Clear();

                if (result == "OK") //Correct comunication with all the scales 
                {
                    for (i = 0; i < myScale.Length; i++)
                    {
                        DataRow dr = this.ds.Tables["Result"].NewRow();
                        dr["IpAddress"] = myScale[i].IpAddress;//((DibalScale)arl).IpAddress;
                        dr["Result"] = "OK";
                        this.ds.Tables["Result"].Rows.Add(dr);
                    }
                }
                else if (result == "No commL.dll") //we do not have the commL.dll
                {
                    for (i = 0; i < myScale.Length; i++)
                    {
                        DataRow dr = this.ds.Tables["Result"].NewRow();
                        dr["IpAddress"] = myScale[i].IpAddress;
                        dr["Result"] = "No commL.dll";
                        this.ds.Tables["Result"].Rows.Add(dr);
                    }
                }
                else //Some scale have not comunicated
                {
                    string[] ScalesError = result.Split(';');

                    for (i = 0; i < myScale.Length; i++)
                    {
                        DataRow dr = this.ds.Tables["Result"].NewRow();
                        dr["IpAddress"] = myScale[i].IpAddress;
                        for (j = 0; j < ScalesError.Length; j++)
                        {
                            if ((ScalesError[0] == "") || (ScalesError[j] == myScale[i].IpAddress))
                            {
                                dr["Result"] = "ERROR";
                                break;
                            }
                            else
                                dr["Result"] = "OK";
                        }
                        this.ds.Tables["Result"].Rows.Add(dr);
                    }
                }
               
                this.ds.Tables["Result"].EndLoadData();
                this.grvResult.DataSource = this.ds.Tables["Result"];
                if (grvResult.Columns.Count == 3)
                    this.grvResult.Columns.RemoveAt(0);
                this.grvResult.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void grvResult_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        private void UpdateResultTable(string result)
        {
            try
            {
                this.ds.Tables["Result"].BeginLoadData();
                this.ds.Tables["Result"].Rows.Clear();

                if (result == "OK") //Correct comunication with all the scales 
                {
                    DataRow dr = this.ds.Tables["Result"].NewRow();
                    dr["Result"] = "OK";
                    this.ds.Tables["Result"].Rows.Add(dr);
                }
                else if (result == "No commL.dll") //we do not have the commL.dll
                {
                    DataRow dr = this.ds.Tables["Result"].NewRow();
                    dr["Result"] = "No commL.dll";
                    this.ds.Tables["Result"].Rows.Add(dr);
                }
                else //Some scale have not comunicated
                {
                    string[] ScalesError = result.Split(';');
                    int i = 0;

                    DataRow dr;
                    for (i = 0; i < ScalesError.Length; i++)
                    {
                        dr = this.ds.Tables["Result"].NewRow();
                        dr["IpAddress"] = ScalesError[i];
                        dr["Result"] = "ERROR";
                        this.ds.Tables["Result"].Rows.Add(dr);
                    }
                }
                this.ds.Tables["Result"].EndLoadData();
                this.grvResult.DataSource = this.ds.Tables["Result"];
                if (grvResult.Columns.Count == 3)
                    this.grvResult.Columns.RemoveAt(0);
                this.grvResult.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }              

        private string GetResultFile()
        {
            try
            {
                string path_ = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
                StreamReader sr = new StreamReader(path_ + "\\dibalscopResults.txt");
                string linea = sr.ReadLine();
                sr.Close();

                return linea;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        #endregion

        #region Image Methods

        private DibalImageStruct[] GetImages()
        {
            try
            {
                DibalImageStruct image = new DibalImageStruct();
                DibalImageStruct[] myImage; 
                ArrayList arlImage = new ArrayList();
                int type = 0;
                int plu = 0;



                if (chkImageFile.Checked)
                {
                    myImage = new DibalImageStruct[ds.Tables["Images"].Rows.Count];
                    foreach (DataRow dr in ds.Tables["Images"].Rows)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ImgPath"])) && !string.IsNullOrEmpty(Convert.ToString(dr["ImgId"])) && !string.IsNullOrEmpty(Convert.ToString(dr["ImgType"])))
                        {
                            if (Convert.ToInt32(dr["ImgType"]) == 0)
                            {
                                type = 2;
                                plu = 1;
                            }
                            else if (Convert.ToInt32(dr["ImgType"]) == 2)
                            {
                                type = 2;
                                plu = 0;
                            }
                            else
                            {
                                type = 1;
                                plu = 0;
                            }
                            image = new DibalImageStruct(Convert.ToString(dr["ImgPath"]), type, Convert.ToInt32(dr["ImgId"]), plu);
                            arlImage.Add(image);
                            myImage = (DibalImageStruct[])arlImage.ToArray(typeof(DibalImageStruct));
                        }
                    }
                }
                else
                {
                    myImage = new DibalImageStruct[ds.Tables["ImageFolder"].Rows.Count];
                    foreach (DataRow dr in ds.Tables["ImageFolder"].Rows)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dr["ImgPathFolder"])) && !string.IsNullOrEmpty(Convert.ToString(dr["ImgTypeFolder"])))
                        {
                            if (Convert.ToInt32(dr["ImgTypeFolder"]) == 0)
                            {
                                type = 2;
                                plu = 1;
                            }
                            else if (Convert.ToInt32(dr["ImgTypeFolder"]) == 2)
                            {
                                type = 2;
                                plu = 0;
                            }
                            else
                            {
                                type = 1;
                                plu = 0;
                            }
                            image = new DibalImageStruct(Convert.ToString(dr["ImgPathFolder"]), type,0, plu);
                            arlImage.Add(image);
                            myImage = (DibalImageStruct[])arlImage.ToArray(typeof(DibalImageStruct));
                        }
                    }
                }
                return myImage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerateImageScales()
        {
            try
            {
                int numScales = 0;
                //Example values
                string IpAddress = "192.168.1.";
                int Rxport = 3000;

                //delete result rows
                this.ds.Tables["ImageScales"].Rows.Clear();
                int.TryParse(this.txtImgNScales.Text, out numScales);

                //Add scales to gridView
                this.ds.Tables["ImageScales"].BeginLoadData();
                for (int j = 1; j <= numScales; j++)
                {
                    DataRow dr = ds.Tables["ImageScales"].NewRow();

                    dr["ImgMasterAddress"] = Convert.ToString((j * 2) - 2);
                    dr["ImgIpAddress"] = Convert.ToString(IpAddress + j);
                    dr["ImgReceptionPortRx"] = Convert.ToString(Rxport);
                    dr["ImgModel"] = 0;
                    dr["ImgGroup"] = Convert.ToString(0);
                    dr["ImgDisplaySize"] = 0;

                    this.ds.Tables["ImageScales"].Rows.Add(dr);
                }
                this.ds.Tables["ImageScales"].EndLoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        

        #endregion

        #region Export Methods

        private void StartExport()
        {
            try
            {
                DibalScale[] myScales = new DibalScale[ds.Tables["ExportScales"].Rows.Count];
                myScales = GetScales(ds.Tables["ExportScales"]);
                if (string.IsNullOrEmpty(this.txtExIpPc.Text))
                    this.txtExIpPc.Text = PcIp;

                this.ds.Tables["ExportedRegisters"].Rows.Clear();
                this.ds.Tables["ExportedResult"].Rows.Clear();
                this.btnStartExportContinuous.Enabled = false;
                this.btnStartExportFin.Enabled = false;
                this.gExAddData.Enabled = false;
                this.pctExporting.Visible = true;
                this.lblExportStatus.Text = Languages.Messages.exporting;
                this.lblNRegisters.Text = "0";
                this.totalRegisters = 0;
                this.cancel = false;

                if (myScales.Length == 0)
                    this.finish = true;	//finish if we dont have scales
                else
                    this.finish = false;

                //Create thread for each scale
                this.oExportScaleThread = new Thread[myScales.Length];
                for (int i = 0; i < myScales.Length; i++)
                {
                    oExportScaleThread[i] = new Thread(new ParameterizedThreadStart(ReceiveRegisters));
                    this.oExportScaleThread[i].Name = "Scale_" + myScales[i].IpAddress;
                    this.oExportScaleThread[i].Start(myScales[i]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Receive registers from the scale with "ReadRegister" function, 
        /// which let the register in "registerBytes" string
        /// Call to "CancelReadRegister" function to finish the reception.
        /// </summary>
        /// <param name="scale"></param>
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

                this.SetResultGrid(((DibalScale)scale).IpAddress, readResult);

                do
                {
                    //1- Read the 130 character Dibal scale register
                    readResult = ReadRegister(ref serverHandle, registerBytes, ((DibalScale)scale).IpAddress, ((DibalScale)scale).txPort, this.txtExIpPc.Text, ((DibalScale)scale).txPort, TIMEOUT, txtLogsFilePath.Text);

                    if (readResult == 1)	//Register received ok
                    {
                        //2-Manage the received register
                        scaleNumRegister++;
                        this.totalRegisters++;

                        //Convert array of bytes into string
                        register = ConvertByteArrayToString(registerBytes);
                        //Write register of each scale in its file
                        if (txtExportFilePath.Text != string.Empty)
                            this.WriteRegisterFile(txtExportFilePath.Text + "\\" + ((DibalScale)scale).IpAddress + "_registers.txt", register);
                        //Update registers grid
                        this.SetRegisterGrid(scaleNumRegister, ((DibalScale)scale).IpAddress, register);
                        //Update registers Counter 
                        this.SetTotalRegister(Convert.ToString(totalRegisters));
                        //Finalize export if the scale dont have more registers HV to send.
                        if (exportContinuous == false)
                            noMoreHV = ManageRegister(register);
                    }
                    else
                    {	//4-After cancel (cancelled == true) you must call to ReadRegister until you dont have nothing to read (readResult == 0)
                        // - if you are in "start/end" mode and you have nothing to read, finalize.
                        if (cancelled == true || (exportContinuous == false && readResult == 0))
                        {
                            this.finish = true;	//starting to wait for close of all the threads in Application_Idle
                            stop = true;		//exit of ReceiveRegisters function 
                        }
                    }

                    if ((this.cancel == true && cancelled != true) || noMoreHV == true)
                    {
                        //3-Cancel export under control, PC sends FIN,ACK to the scale
                        cancelResult = CancelReadRegister(ref serverHandle, txtLogsFilePath.Text);
                        cancelled = true;
                    }
                    //Only refresh if the "readResult" is diference or process cancelled or scale dont have more registers to send
                    if (readResult != readResultPrevious || stop == true)
                    {
                        if (noMoreHV == true || (exportContinuous == false && readResult == 0))
                            this.SetResultGrid(((DibalScale)scale).IpAddress, 2);
                        else if (cancelled == true)
                            this.SetResultGrid(((DibalScale)scale).IpAddress, cancelResult);
                        else
                            this.SetResultGrid(((DibalScale)scale).IpAddress, readResult);

                        readResultPrevious = readResult;
                    }
                    Application.DoEvents();
                }
                while (!stop);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        private void SetResultGrid(string scaleIpAddress, int result)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new SetResultDs(SetResultGrid), new object[] { scaleIpAddress, result });
                }
                else
                {
                    DataRow[] rows = this.ds.Tables["ExportedResult"].Select("IpAddressResult='" + scaleIpAddress + "'");

                    if (rows.Length > 0)
                    {
                        rows[0]["ExResult"] = DibalscopResultToString(result);
                    }
                    else
                    {
                        DataRow dr = this.ds.Tables["ExportedResult"].NewRow();
                        dr["IpAddressResult"] = scaleIpAddress;
                        dr["ExResult"] = Languages.Messages.waiting;
                        this.ds.Tables["ExportedResult"].Rows.Add(dr);
                    }
                    this.grvExResult.Refresh();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string DibalscopResultToString(int result)
        {
            try
            {
                string strResult = string.Empty;
                switch (result)
                {
                    case 0:
                        strResult = "0." + Languages.Messages.nothing2read; //"0.Waiting...Nothing to read";
                        break;
                    case 1:
                        strResult = "1." + Languages.Messages.readingRegister;  //"1.Reading register";
                        break;
                    case 2:
                        strResult = "2." + Languages.Messages.finished; //"2.Finished";
                        break;
                    case -1:
                        strResult = "-1." + Languages.Messages.inac_socket; //"-1.Inaccessible socket";
                        break;
                    case -2:
                        strResult = "-2." + Languages.Messages.scaleEndCom; //"-2.Scale ends communication";
                        break;
                    case -3:
                        strResult = "-3." + Languages.Messages.socketNoCon; //"-3.Socket is not connected";
                        break;
                    case -4:
                        strResult = "-4." + Languages.Messages.netError; //"-4.Net error";
                        break;
                    case -5:
                        strResult = "-5." + Languages.Messages.conError; //"-5.Connection error";
                        break;
                    case -6:
                        strResult = "-6." + Languages.Messages.lenError; //"-6.Length of register < 2";
                        break;
                    case -7:
                        strResult = "-7." + Languages.Messages.logsError; //"-7.Logs file error";
                        break;
                    case -9:
                        strResult = "-9." + Languages.Messages.readRegError; //"-9.ReadRegister Error";
                        break;
                    case -10:
                        strResult = "-10." + Languages.Messages.timeoutCon; //"-10.Timeout without connection";
                        break;
                    case -11:
                        strResult = "-11." + Languages.Messages.conError; //"-11.Connecting error";
                        break;
                    case -12:
                        strResult = "-12." + Languages.Messages.unScaleCon; //"-12.Unexpected scale connection";
                        break;
                    case -13:
                        strResult = "-13." + Languages.Messages.logsError; //"-13.Logs file error";
                        break;
                    case -14:
                        strResult = "-14." + Languages.Messages.scaleIPFormatError; //"-14.Scale Ip format error";
                        break;
                    case -15:
                        strResult = "-15." + Languages.Messages.pcIPFormatError; // "-15.PC Ip format error";
                        break;
                    case -19:
                        strResult = "-19." + Languages.Messages.opServerError; //"-19.Open Server error";
                        break;
                    case -21:
                        strResult = "-21." + Languages.Messages.closeSockErr; //"-21.Closing socket error";
                        break;
                    case -22:
                        strResult = "-22." + Languages.Messages.closeSockErr; //"-22.Closing socket error";
                        break;
                    case -23:
                        strResult = "-23." + Languages.Messages.resourceErr; //"-23.Releasing resources error";
                        break;
                    case -24:
                        strResult = "-24." + Languages.Messages.pendRegErr; //"-24.Pending registers error";
                        break;
                    case -25:
                        strResult = "-25." + Languages.Messages.logsError; //"-25.Logs file error";
                        break;
                    case -29:
                        strResult = "-29." + Languages.Messages.closeServerErr; //"-29.Close Server error";
                        break;
                    case 31:
                        strResult = "-30." + Languages.Messages.cancelled; //"30.Cancelled";
                        break;
                    case -31:
                        strResult = "-31." + Languages.Messages.FINSendErr; //"-31.FIN sending error";
                        break;
                    case -32:
                        strResult = strResult = "-32." + Languages.Messages.logsError; //"-32.Logs file error";
                        break;
                    case -39:
                        strResult = "-39." + Languages.Messages.cancellingErr; //"-39.Canceling error";
                        break;
                }
                return strResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetRegisterGrid(int NumRegister, string scaleIpAddress, string register)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new SetRegisterDs(SetRegisterGrid), new object[] { NumRegister, scaleIpAddress, register });
                }
                else
                {
                    DataRow dr = this.ds.Tables["ExportedRegisters"].NewRow();
                    dr["NumRegister"] = Convert.ToString(NumRegister);
                    dr["ScaleIpAddress"] = scaleIpAddress;
                    dr["ScaleRegister"] = register;
                    this.ds.Tables["ExportedRegisters"].Rows.Add(dr);

                    this.grvExRegisters.Refresh();
                    this.grvExRegisters.FirstDisplayedScrollingRowIndex = this.grvExRegisters.Rows.Count - 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SetTotalRegister(string text)
        {
            if (this.lblNRegisters.InvokeRequired)
            {
                this.Invoke(new SetText(SetTotalRegister), new object[] { text });
            }
            else
            {
                this.lblNRegisters.Text = text;
            }
        }

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

        private void CloseThreads()
        {
            try
            {
                if (this.oExportScaleThread != null)
                {
                    for (int i = 0; i < oExportScaleThread.Length; i++)
                    {
                        while ((this.oExportScaleThread[i] != null && this.oExportScaleThread[i].IsAlive))
                        {
                            Application.DoEvents();
                            Thread.Sleep(5);
                        }
                    }
                }
                this.oExportScaleThread = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerateExportScales()
        {
            try
            {
                int numScales = 0;
                //Example values
                string IpAddress = "192.168.1.";
                int rxPort = 3000;
                int txPort = 3000;

                //delete result rows
                this.ds.Tables["ExportScales"].Rows.Clear();
                int.TryParse(this.txtExNScales.Text, out numScales);

                //Add scales to gridView
                this.ds.Tables["ExportScales"].BeginLoadData();
                for (int j = 1; j <= numScales; j++)
                {
                    DataRow dr = ds.Tables["ExportScales"].NewRow();

                    dr["ExMasterAddress"] = Convert.ToString((j * 2) - 2);
                    dr["ExIpAddress"] = Convert.ToString(IpAddress + (j));
                    dr["ExReceptionPortRx"] = Convert.ToString(rxPort);
                    dr["ExSendPortTx"] = Convert.ToString(txPort + j);

                    this.ds.Tables["ExportScales"].Rows.Add(dr);
                }
                this.ds.Tables["ExportScales"].EndLoadData();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        #endregion

        #endregion

        #region EVENTS

        #region Import Events

        private void btnItemsSend_Click(object sender, EventArgs e)
        {
            try
            {
                DibalItem2[] myItems = new DibalItem2[ds.Tables["Items"].Rows.Count];
                DibalScale[] myScales = new DibalScale[ds.Tables["Scales"].Rows.Count];
                string Result = string.Empty;
                if (ds.Tables["Scales"].Rows.Count == 0)
                {
                    MessageBox.Show(Languages.Messages.noScaleSet, "DibalscopDemoC#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //delete result rows
                this.ds.Tables["Result"].Rows.Clear();

                this.btnItemsSend.Enabled = false;
                this.btnDataSend.Enabled = false;
                this.btnRegistersSend.Enabled = false;

                myScales = GetScales(ds.Tables["Scales"]);
                myItems = GetItems();

                //Import Items to scales
                this.lblStatus.Text = Languages.Messages.importing;
                this.lblStatus.Refresh();
                //Here you have to call to the function "ItemsSend2" to send the articles to scales.
                //We use IntPtr because Windows(from Framework 4.5) does not allow to assign a C++ LPSTR(char*) to C# String.
                IntPtr ptrResult = ItemsSend2(myScales, myScales.Length, myItems, myItems.Length, Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                //ItemsSend2 returns an ANSI char array(LPSTR)
                Result = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(ptrResult);
                this.lblStatus.Text = Languages.Messages.finished;

                this.UpdateResultTable(Result, myScales);

                this.btnItemsSend.Enabled = true;
                this.btnDataSend.Enabled = true;
                this.btnRegistersSend.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDataSend_Click(object sender, EventArgs e)
        {
            try
            {
                string Result = string.Empty;

                this.btnDataSend.Enabled = false;
                this.btnItemsSend.Enabled = false;
                this.btnRegistersSend.Enabled = false;

                this.lblStatus.Text = Languages.Messages.importing;
                this.lblStatus.Refresh();
                
                //We use IntPtr because Windows(from Framework 4.5) does not allow to assign a C++ LPSTR(char*) to C# String.
                IntPtr ptrResult = DataSend2();
                //DataSend2 returns an ANSI char array(LPSTR)
                Result = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(ptrResult);
                this.lblStatus.Text = Languages.Messages.finished;

                UpdateResultTable(GetResultFile());
                this.btnDataSend.Enabled = true;
                this.btnItemsSend.Enabled = true;
                this.btnRegistersSend.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnRegistersSend_Click(object sender, EventArgs e)
        {
            try
            {
                DibalScale[] myScales = new DibalScale[ds.Tables["Scales"].Rows.Count];
                DibalRegister[] myRegisters = new DibalRegister[ds.Tables["Registers"].Rows.Count];
                string Result = string.Empty;
                if (ds.Tables["Scales"].Rows.Count == 0)
                {
                    MessageBox.Show(Languages.Messages.noScaleSet, "DibalscopDemoC#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //delete result rows
                this.ds.Tables["Result"].Rows.Clear();

                this.btnItemsSend.Enabled = false;
                this.btnDataSend.Enabled = false;
                this.btnRegistersSend.Enabled = false;

                myScales = GetScales(ds.Tables["Scales"]);
                myRegisters = GetRegisters();

                //Import Items to scales
                this.lblStatus.Text = Languages.Messages.importing;
                this.lblStatus.Refresh();
                //Here you have to call to the function "RegistersSend" to send the registers to scales.
                //We use IntPtr because Windows(from Framework 4.5) does not allow to assign a C++ LPSTR(char*) to C# String.
                IntPtr ptrResult = RegistersSend(myScales, myScales.Length, myRegisters, myRegisters.Length, Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                //RegistersSend returns an ANSI char array(LPSTR)
                Result = System.Runtime.InteropServices.Marshal.PtrToStringAnsi(ptrResult);
                this.lblStatus.Text = Languages.Messages.finished;

                this.UpdateResultTable(Result, myScales);

                this.btnItemsSend.Enabled = true;
                this.btnDataSend.Enabled = true;
                this.btnRegistersSend.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnGenerateArticles_Click(object sender, EventArgs e)
        {
            GenerateItems();
        }

        private void btnDeleteArticlesGrid_Click(object sender, EventArgs e)
        {
            //delete result rows
            this.ds.Tables["Items"].Rows.Clear();
        }

        private void btnGenerateScales_Click(object sender, EventArgs e)
        {
            GenerateImportScales();
        }

        private void txtNScales_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GenerateImportScales();
            }
        }       


        private void btnDeleteScalesGrid_Click(object sender, EventArgs e)
        {
            //delete result rows
            this.ds.Tables["Scales"].Rows.Clear();
        }

        private void txtNArticles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GenerateItems();
            }
        }

        private void txtImgNScales_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                GenerateImageScales();
            }
        }

        #endregion

        #region Image Events

        private void btnImgGenerateScales_Click(object sender, EventArgs e)
        {
            GenerateImageScales();
        }

        private void btnImgDeleteScales_Click(object sender, EventArgs e)
        {
            //delete result rows
            this.ds.Tables["ImageScales"].Rows.Clear();
        }

        private void btnImageSend_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable imageScales = ds.Tables["ImageScales"];
                DibalImage.ImagePalletized.DibalScale[] myImageScales = new DibalImage.ImagePalletized.DibalScale[ds.Tables["ImageScales"].Rows.Count];
                ArrayList mySevenInchScales = new ArrayList();
                ArrayList myTwelveInchScales = new ArrayList();
                ArrayList myFifteenInchScales = new ArrayList();
                DibalImageStruct[] myImages;
                DibalImage.ImagePalletized.ImageStruct[] myImagesRegisters = new DibalImage.ImagePalletized.ImageStruct[ds.Tables["Images"].Rows.Count * ds.Tables["ImageScales"].Rows.Count];
                DibalImage.ImagePalletized.ImageStruct image = new DibalImage.ImagePalletized.ImageStruct();
                string Result = string.Empty;
                string imageRegister = string.Empty;
                int con = 0;
                int row = 0;

                if (imageScales.Rows.Count == 0)
                {
                    MessageBox.Show(Languages.Messages.noScaleSet,"DibalscopDemoC#",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    return;
                }

                if (chkImageFile.Checked)
                    myImages = new DibalImageStruct[ds.Tables["Images"].Rows.Count];
                else
                    myImages = new DibalImageStruct[ds.Tables["ImageFolder"].Rows.Count];


                //delete result rows
                this.ds.Tables["ImageResult"].Rows.Clear();

                this.btnImageFileGenerator.Enabled = false;
                this.btnImageSend.Enabled = false;

                myImageScales = GetImageScales(ds.Tables["ImageScales"]);
                myImages = GetImages();

                //Import Images to scales
                this.lblImageStatus.Text = Languages.Messages.importing;
                this.lblImageStatus.Refresh();

                //Separate scales by display size

                foreach (DataRow dr in imageScales.Rows)
                {
                    if (Convert.ToInt32(dr["ImgDisplaySize"]) == 0)
                    {
                        mySevenInchScales.Add(myImageScales[row]);
                        row++;
                    }
                    else if (Convert.ToInt32(dr["ImgDisplaySize"]) == 1)
                    {
                        myTwelveInchScales.Add(myImageScales[row]);
                        row++;
                    }
                    else if (Convert.ToInt32(dr["ImgDisplaySize"]) == 2)
                    {
                        myFifteenInchScales.Add(myImageScales[row]);
                        row++;
                    }
                }
                //Here you have to call to the function "ImageRegisterGenerator" to create registers and "ImageSend" or "MultiImageSend" to send them to scales.                
                //send 7 Inch scales
                if (mySevenInchScales.Count > 0)
                {


                    DibalImage.ImagePalletized.DibalScale[] sevenScales = (DibalImage.ImagePalletized.DibalScale[])mySevenInchScales.ToArray(typeof(DibalImage.ImagePalletized.DibalScale));

                    if (sevenScales.Length == 1)
                    {
                        foreach (DibalImageStruct di in myImages)
                        {
                            if (chkImageFolder.Checked) //It is a folder
                            {
                                if (di.path != null)
                                    Result = DibalImage.ImagePalletized.SendMultiImagestoSingleScale(sevenScales[0], di.type, di.path, di.assignPlu, 0,Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                            }
                            else
                            {
                                if (di.path != null)
                                    Result = DibalImage.ImagePalletized.SendImagetoSingleScale(sevenScales[0], di.type,di.id, di.path, di.assignPlu, 0,Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                            }
                        }
                    }
                    else
                    {
                        foreach (DibalImageStruct di in myImages)
                        {
                            if (chkImageFolder.Checked) //It is a folder
                            {
                                if (di.path != null)
                                    Result = DibalImage.ImagePalletized.SendMultiImagestoMultiScales(sevenScales,sevenScales.Length, di.type, di.path, di.assignPlu, 0,Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                            }
                            else
                            {
                                if (di.path != null)
                                    Result = DibalImage.ImagePalletized.SendImagetoMultiScales(sevenScales,sevenScales.Length, di.type,di.id, di.path, di.assignPlu, 0,Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                            }
                        }
                    }
                }
                //Send 12 Inch scales
                if (myTwelveInchScales.Count > 0)
                {
                    DibalImage.ImagePalletized.DibalScale[] twelveScales = ((DibalImage.ImagePalletized.DibalScale[])myTwelveInchScales.ToArray(typeof(DibalImage.ImagePalletized.DibalScale)));

                    if (twelveScales.Length == 1)
                    {
                        foreach (DibalImageStruct di in myImages)
                        {
                            if (chkImageFolder.Checked) //It is a folder
                            {
                                if (di.path != null)
                                    Result = DibalImage.ImagePalletized.SendMultiImagestoSingleScale(twelveScales[0], di.type, di.path, di.assignPlu, 0, Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                            }
                            else
                            {
                                if (di.path != null)
                                    Result = DibalImage.ImagePalletized.SendImagetoSingleScale(twelveScales[0], di.type, di.id, di.path, di.assignPlu, 0, Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                            }
                        }
                    }
                    else
                    {
                        foreach (DibalImageStruct di in myImages)
                        {
                            if (chkImageFolder.Checked) //It is a folder
                            {
                                if (di.path != null)
                                    Result = DibalImage.ImagePalletized.SendMultiImagestoMultiScales(twelveScales, twelveScales.Length, di.type, di.path, di.assignPlu, 0, Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                            }
                            else
                            {
                                if (di.path != null)
                                    Result = DibalImage.ImagePalletized.SendImagetoMultiScales(twelveScales, twelveScales.Length, di.type, di.id, di.path, di.assignPlu, 0, Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                            }
                        }
                    }
                }
                //Send 15 Inch scales
                if (myFifteenInchScales.Count > 0)
                {
                    DibalImage.ImagePalletized.DibalScale[] fifteenScales = ((DibalImage.ImagePalletized.DibalScale[])myFifteenInchScales.ToArray(typeof(DibalImage.ImagePalletized.DibalScale)));

                    if (fifteenScales.Length == 1)
                    {
                        foreach (DibalImageStruct di in myImages)
                        {
                            if (chkImageFolder.Checked) //It is a folder
                            {
                                if (di.path != null)
                                    Result = DibalImage.ImagePalletized.SendMultiImagestoSingleScale(fifteenScales[0], di.type, di.path, di.assignPlu, 0, Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                            }
                            else
                            {
                                if (di.path != null)
                                    Result = DibalImage.ImagePalletized.SendImagetoSingleScale(fifteenScales[0], di.type, di.id, di.path, di.assignPlu, 0, Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                            }
                        }
                    }
                    else
                    {
                        foreach (DibalImageStruct di in myImages)
                        {
                            if (chkImageFolder.Checked) //It is a folder
                            {
                                if (di.path != null)
                                    Result = DibalImage.ImagePalletized.SendMultiImagestoMultiScales(fifteenScales, fifteenScales.Length, di.type, di.path, di.assignPlu, 0, Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                            }
                            else
                            {
                                if (di.path != null)
                                    Result = DibalImage.ImagePalletized.SendImagetoMultiScales(fifteenScales, fifteenScales.Length, di.type, di.id, di.path, di.assignPlu, 0, Convert.ToInt32(cboShowWindow.SelectedValue), Convert.ToInt32(cboCloseTime.SelectedValue));
                            }
                        }
                    }
                }

                this.lblImageStatus.Text = Languages.Messages.finished;

                this.UpdateImageResultTable(Result, myImageScales);

                this.btnImageSend.Enabled = true;
                this.btnImageFileGenerator.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnImageFileGenerator_Click(object sender, EventArgs e)
        {
            try
            {
                DibalImageStruct[] myImages = new DibalImageStruct[ds.Tables["Images"].Rows.Count];
                int concatenate = 0;

                if (ds.Tables["ImageScales"].Rows.Count == 0)
                {
                    MessageBox.Show(Languages.Messages.noScaleSet, "DibalscopDemoC#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (ds.Tables["ImageScales"].Rows.Count > 0 && ds.Tables["Images"].Rows.Count > 0)
                {
                    if (rdbConcatenate.Checked)
                    {
                        sfd1.OverwritePrompt = false;
                        concatenate = 1;
                    }
                    else
                    {
                        sfd1.OverwritePrompt = true;
                        if (ds.Tables["ImageScales"].Rows.Count <= 1)
                        {
                            concatenate = 0;
                        }
                    }
                    this.btnImageSend.Enabled = false;
                    this.btnImageFileGenerator.Enabled = false;
                    if (concatenate == 1)
                        rdbReplace.Checked = false;

                    else
                        rdbReplace.Checked = true;

                    sfd1.AddExtension = true;
                    sfd1.DefaultExt = "txt";
                    sfd1.InitialDirectory = @"C:\";
                    sfd1.RestoreDirectory = true;
                    sfd1.Title = "Save Document as";
                    sfd1.Filter = "txt files (*.txt)|*.txt";
                    sfd1.CheckPathExists = true;
                    
                    if (sfd1.ShowDialog() == DialogResult.OK)
                    {
                        //Create Document
                        this.lblImageStatus.Text = Languages.Messages.generating;
                        this.lblImageStatus.Refresh();

                        myImages = GetImages();
                        //Delete result rows
                        this.ds.Tables["ImageResult"].Rows.Clear();

                        //Here you have to call to the function "ImageFileGenerator" to create registers.
                        foreach (DataRow dr in ds.Tables["ImageScales"].Rows)
                        {

                            foreach (DibalImageStruct di in myImages)
                            {
                                DibalImage.ImagePalletized.ImageFileGeneratorBytes(Convert.ToInt32(dr["ImgMasterAddress"]), di.type, di.id, di.path, sfd1.FileName, concatenate, di.assignPlu, Convert.ToInt32(dr["ImgDisplaySize"]));
                            }

                        }

                    }

                    this.lblImageStatus.Text = Languages.Messages.finished;

                    this.btnImageFileGenerator.Enabled = true;
                    this.btnImageSend.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void UpdateImageResultTable(string result, ImagePalletized.DibalScale[] myScale)
        {
            try
            {
                int i = 0;
                int j = 0;

                this.ds.Tables["ImageResult"].BeginLoadData();
                this.ds.Tables["ImageResult"].Rows.Clear();

                if (result == "OK") //Correct comunication with all the scales 
                {
                    for (i = 0; i < myScale.Length; i++)
                    {
                        DataRow dr = this.ds.Tables["ImageResult"].NewRow();
                        dr["IpAddress"] = myScale[i].IpAddress;//((DibalScale)arl).IpAddress;
                        dr["Result"] = "OK";
                        this.ds.Tables["ImageResult"].Rows.Add(dr);
                    }
                }
                else if (result == "No commL.dll") //we do not have the commL.dll
                {
                    for (i = 0; i < myScale.Length; i++)
                    {
                        DataRow dr = this.ds.Tables["ImageResult"].NewRow();
                        dr["IpAddress"] = myScale[i].IpAddress;
                        dr["Result"] = "No commL.dll";
                        this.ds.Tables["ImageResult"].Rows.Add(dr);
                    }
                }
                else if(result == "NoImageFile" || result == "ImageFolderError" || result == "ImageFormatError")
                {

                    for (i = 0; i < myScale.Length; i++)
                    {
                        DataRow dr = this.ds.Tables["ImageResult"].NewRow();
                        dr["IpAddress"] = myScale[i].IpAddress;
                        dr["Result"] = result;
                        this.ds.Tables["ImageResult"].Rows.Add(dr);
                    }
                }   
                else //Some scale have not comunicated
                {
                    string[] ScalesError = result.Split(';');

                    for (i = 0; i < myScale.Length; i++)
                    {
                        DataRow dr = this.ds.Tables["ImageResult"].NewRow();
                        dr["IpAddress"] = myScale[i].IpAddress;
                        for (j = 0; j < ScalesError.Length; j++)
                        {
                            if ((ScalesError[0] == "") || (ScalesError[j] == myScale[i].IpAddress))
                            {
                                dr["Result"] = "ERROR";
                                break;
                            }
                            else
                                dr["Result"] = "OK";
                        }
                        this.ds.Tables["ImageResult"].Rows.Add(dr);
                    }
                }
                this.ds.Tables["ImageResult"].EndLoadData();
                this.grvImageResult.DataSource = this.ds.Tables["ImageResult"];
                this.grvImageResult.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        

        #endregion

        #region Export Events

        private void btnExportScalesGenerate_Click(object sender, EventArgs e)
        {
            GenerateExportScales();
        }
        private void txtExNScales_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GenerateExportScales();
            }
        }

        private void btnExportScalesDelete_Click(object sender, EventArgs e)
        {
            //delete ExportScales rows
            this.ds.Tables["ExportScales"].Rows.Clear();
        }

        private void btnStartExportContinuous_Click(object sender, EventArgs e)
        {
            if (ds.Tables["ExportScales"].Rows.Count == 0)
            {
                MessageBox.Show(Languages.Messages.noScaleSet, "DibalscopDemoC#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            exportContinuous = true;
            StartExport();
        }

        private void btnStartExportFin_Click(object sender, EventArgs e)
        {
            if (ds.Tables["ExportScales"].Rows.Count == 0)
            {
                MessageBox.Show(Languages.Messages.noScaleSet, "DibalscopDemoC#", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            exportContinuous = false;
            StartExport();
        }

        private void btnCancelExport_Click(object sender, EventArgs e)
        {
            this.cancel = true;
            this.lblExportStatus.Text = Languages.Messages.cancelling;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            if (this.finish == true)
            {
                this.CloseThreads();

                this.pctExporting.Visible = false;
                this.lblExportStatus.Text = Languages.Messages.finished;
                this.btnStartExportContinuous.Enabled = true;
                this.btnStartExportFin.Enabled = true;
                this.gExAddData.Enabled = true;
            }
        }

        #endregion

       

       
        #endregion

        private void chkImageFile_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkImageFile.Checked == true)
            {
                label20.Enabled = true;
                this.chkImageFolder.Checked = false;
                grvImages.Enabled = true;                
                groupBox13.Enabled = true;
            }
            else
            {
                label20.Enabled = false;
                this.grvImages.Enabled = false;
                this.chkImageFolder.Checked = true;                
                groupBox13.Enabled = false;
            }
            
        }

        private void chkImageFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkImageFolder.Checked == true)
            {
                label21.Enabled = true;
                this.chkImageFile.Checked = false;
                grvImageFolder.Enabled = true;                
                groupBox13.Enabled = false;
            }
            else
            {
                label21.Enabled = false;
                this.grvImageFolder.Enabled = false;
                this.chkImageFile.Checked = true;                
                groupBox13.Enabled = true;

            }
            
        }

        private void grvImageFolder_SelectionChanged(object sender, EventArgs e)
        {
            this.grvImageFolder.ClearSelection();
            
        }

        private void grvImages_SelectionChanged(object sender, EventArgs e)
        {
            this.grvImages.ClearSelection();
        }

        private void Load_Language()
        {

            this.tabCom.TabPages[0].Text = Languages.Messages.import;
            this.tabCom.TabPages[1].Text = Languages.Messages.export;
            this.tabCom.TabPages[2].Text = Languages.Messages.image;
            this.gAddData.Text = Languages.Messages.editData;
            this.lblAddScales.Text = Languages.Messages.scales;
            this.lblAddArticles.Text = Languages.Messages.items;
            this.lblAddRegisters.Text = Languages.Messages.registers;
            this.gGenerateScales.Text = Languages.Messages.generateScalesAutomatically;
            this.gGenerateArticles.Text = Languages.Messages.generateItemsAutomatically;
            this.lblNumScales.Text = Languages.Messages.generateScales + ":";
            this.lblNumItems.Text = Languages.Messages.generateItemslabel + ":";
            this.btnGenerateScales.Text = Languages.Messages.generateScalesButton;
            this.btnGenerateAticles.Text = Languages.Messages.generateItems;
            this.btnDeleteScalesGrid.Text = Languages.Messages.deleteScales;
            this.btnDeleteArticlesGrid.Text = Languages.Messages.deleteItems;
            this.lblShowWindow.Text = Languages.Messages.showWindow;
            this.lblCloseTime.Text = Languages.Messages.closeTime;
            this.gImportParameters.Text = Languages.Messages.importItemsParameters;
            this.gImportFiles.Text = Languages.Messages.importItemsFile;
            this.gRegistersSend.Text = Languages.Messages.importDataRegisters;
            this.lblInfo1.Text = Languages.Messages.useGrid;
            this.lblInfo2.Text = Languages.Messages.useFIles;
            this.lblInfo3.Text = Languages.Messages.useRegister;
            this.lblStatus.Text = Languages.Messages.stopped;
            this.MasterAddress.HeaderText = Languages.Messages.masterAdd;
            this.Group.HeaderText = Languages.Messages.group;
            this.IpAddress.HeaderText = Languages.Messages.IPAddress;
            this.ReceptionPortRx.HeaderText = Languages.Messages.receptionPortRX;
            this.Model.HeaderText = Languages.Messages.model;
            this.Code.HeaderText = Languages.Messages.code;
            this.DirectKey.HeaderText = Languages.Messages.directKey;
            this.Type.HeaderText = Languages.Messages.type;
            this.Price.HeaderText = Languages.Messages.price;
            this.itemName.HeaderText = Languages.Messages.name;
            this.Register.HeaderText = Languages.Messages.register;
            this.RIpAddress.HeaderText = Languages.Messages.IPAddress;
            this.Result.HeaderText = Languages.Messages.result;


            this.gExAddData.Text = Languages.Messages.addData;
            this.lblAddScalesEx.Text = Languages.Messages.addScales;
            this.ExMasterAddress.HeaderText = Languages.Messages.masterAdd;
            this.ExIpAddress.HeaderText = Languages.Messages.IPAddress;
            this.ExReceptionPortRx.HeaderText = Languages.Messages.receptionPortRX;
            this.ExSendPortTx.HeaderText = Languages.Messages.sendPortTx;
            this.lblExIpPc.Text = Languages.Messages.PcIPAddress+ ":";
            this.lblExportFilePath.Text = Languages.Messages.registersFilePath +":";
            this.lblExportLogPath.Text = Languages.Messages.logsFile + ":"; ;
            this.gExGenerateScales.Text = Languages.Messages.generateScalesAutomatically;
            this.lblExGenerateScales.Text = Languages.Messages.generateScales + ":";
            this.btnExGenerateScales.Text = Languages.Messages.generateScalesButton;
            this.btnExDeleteScales.Text = Languages.Messages.deleteScales;
            this.gExport.Text = Languages.Messages.export;
            this.btnStartExportContinuous.Text = Languages.Messages.startContinuous;
            this.btnStartExportFin.Text = Languages.Messages.startEnd;
            this.btnCancelExport.Text = Languages.Messages.cancel;
            this.lblRRegisters.Text = Languages.Messages.receivedRegisters + ":";
            this.RIpAddress.HeaderText = Languages.Messages.IPAddress;
            this.ExResult.HeaderText = Languages.Messages.result;
            this.NumRegister.HeaderText = Languages.Messages.numRegister;
            this.ScaleIpAddress.HeaderText = Languages.Messages.IPAddress;
            this.ScaleRegister.HeaderText = Languages.Messages.register;
            this.lblExportStatus.Text = Languages.Messages.stopped;
            this.IpAddressResult.HeaderText = Languages.Messages.IPAddress;

            this.gImages.Text = Languages.Messages.editData;
            this.lblImScales.Text = Languages.Messages.scales;
            this.ImgMasterAddress.HeaderText = Languages.Messages.masterAdd;
            this.ImgGroup.HeaderText = Languages.Messages.group;
            this.ImgIpAddress.HeaderText = Languages.Messages.IPAddress;
            this.ImgReceptionPortRx.HeaderText = Languages.Messages.receptionPortRX;
            this.ImgModel.HeaderText = Languages.Messages.model;
            this.ImgDisplaySize.HeaderText = Languages.Messages.displaySize;
            this.gImgGenerateScales.Text = Languages.Messages.generateScalesAutomatically;
            this.label23.Text = Languages.Messages.generateScales + ":";
            this.btnImgGenerateScales.Text = Languages.Messages.generateScalesButton;
            this.btnImgDeleteScales.Text = Languages.Messages.deleteScales;
            this.label20.Text = Languages.Messages.imageFile;
            this.label21.Text = Languages.Messages.imageFolder;
            this.ImgPath.HeaderText = Languages.Messages.path;
            this.ImgId.HeaderText = Languages.Messages.imageID;
            this.ImgType.HeaderText = Languages.Messages.type;
            this.ImgPathFolder.HeaderText = Languages.Messages.path;
            this.ImgTypeFolder.HeaderText = Languages.Messages.type;
            this.groupBox13.Text = Languages.Messages.createImageFile;
            this.groupBox12.Text = Languages.Messages.importImages;
            this.label27.Text = Languages.Messages.useImages;
            this.label25.Text = Languages.Messages.useImages;
            this.rdbConcatenate.Text = Languages.Messages.concatenateFile;
            this.rdbReplace.Text = Languages.Messages.replaceFile;
            this.btnImageSend.Text = Languages.Messages.sendImage;
            this.lblImageStatus.Text = Languages.Messages.stopped;
            this.dataGridViewTextBoxColumn22.HeaderText = Languages.Messages.IPAddress;
            this.dataGridViewTextBoxColumn23.HeaderText = Languages.Messages.result;








        }

       

        

        

       

        
        

                       
       
    }
}