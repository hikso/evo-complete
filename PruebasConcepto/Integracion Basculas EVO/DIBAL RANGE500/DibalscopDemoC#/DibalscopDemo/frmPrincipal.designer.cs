using System;
using System.Windows.Forms;

namespace DibalscopDemo
{
	partial class frmPrincipal
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabCom = new System.Windows.Forms.TabControl();
            this.tapPageImport = new System.Windows.Forms.TabPage();
            this.gImportFiles = new System.Windows.Forms.GroupBox();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.btnDataSend = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gRegistersSend = new System.Windows.Forms.GroupBox();
            this.lblInfo3 = new System.Windows.Forms.Label();
            this.btnRegistersSend = new System.Windows.Forms.Button();
            this.grvResult = new System.Windows.Forms.DataGridView();
            this.RIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gAddData = new System.Windows.Forms.GroupBox();
            this.lblAddRegisters = new System.Windows.Forms.Label();
            this.grvRegisters = new System.Windows.Forms.DataGridView();
            this.Register = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboCloseTime = new System.Windows.Forms.ComboBox();
            this.cboShowWindow = new System.Windows.Forms.ComboBox();
            this.lblCloseTime = new System.Windows.Forms.Label();
            this.lblShowWindow = new System.Windows.Forms.Label();
            this.gGenerateScales = new System.Windows.Forms.GroupBox();
            this.btnDeleteScalesGrid = new System.Windows.Forms.Button();
            this.lblNumScales = new System.Windows.Forms.Label();
            this.btnGenerateScales = new System.Windows.Forms.Button();
            this.txtNScales = new System.Windows.Forms.TextBox();
            this.gGenerateArticles = new System.Windows.Forms.GroupBox();
            this.btnDeleteArticlesGrid = new System.Windows.Forms.Button();
            this.lblNumItems = new System.Windows.Forms.Label();
            this.btnGenerateAticles = new System.Windows.Forms.Button();
            this.txtNArticles = new System.Windows.Forms.TextBox();
            this.lblAddArticles = new System.Windows.Forms.Label();
            this.grvItems = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirectKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.itemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAddScales = new System.Windows.Forms.Label();
            this.grvScales = new System.Windows.Forms.DataGridView();
            this.MasterAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceptionPortRx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gImportParameters = new System.Windows.Forms.GroupBox();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.btnItemsSend = new System.Windows.Forms.Button();
            this.tabPageExport = new System.Windows.Forms.TabPage();
            this.grvExResult = new System.Windows.Forms.DataGridView();
            this.IpAddressResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblNRegisters = new System.Windows.Forms.Label();
            this.lblRRegisters = new System.Windows.Forms.Label();
            this.gExAddData = new System.Windows.Forms.GroupBox();
            this.txtLogsFilePath = new System.Windows.Forms.TextBox();
            this.txtExportFilePath = new System.Windows.Forms.TextBox();
            this.lblExportLogPath = new System.Windows.Forms.Label();
            this.lblExportFilePath = new System.Windows.Forms.Label();
            this.lblAddScalesEx = new System.Windows.Forms.Label();
            this.lblExIpPc = new System.Windows.Forms.Label();
            this.grvExportScales = new System.Windows.Forms.DataGridView();
            this.ExMasterAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExReceptionPortRx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExSendPortTx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtExIpPc = new System.Windows.Forms.TextBox();
            this.gExGenerateScales = new System.Windows.Forms.GroupBox();
            this.btnExDeleteScales = new System.Windows.Forms.Button();
            this.lblExGenerateScales = new System.Windows.Forms.Label();
            this.btnExGenerateScales = new System.Windows.Forms.Button();
            this.txtExNScales = new System.Windows.Forms.TextBox();
            this.lblExportStatus = new System.Windows.Forms.Label();
            this.grvExRegisters = new System.Windows.Forms.DataGridView();
            this.NumRegister = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScaleIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScaleRegister = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gExport = new System.Windows.Forms.GroupBox();
            this.btnStartExportFin = new System.Windows.Forms.Button();
            this.btnCancelExport = new System.Windows.Forms.Button();
            this.btnStartExportContinuous = new System.Windows.Forms.Button();
            this.pctExporting = new System.Windows.Forms.PictureBox();
            this.tabPageImage = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btnImageSend = new System.Windows.Forms.Button();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.rdbConcatenate = new System.Windows.Forms.RadioButton();
            this.rdbReplace = new System.Windows.Forms.RadioButton();
            this.label27 = new System.Windows.Forms.Label();
            this.btnImageFileGenerator = new System.Windows.Forms.Button();
            this.lblImageStatus = new System.Windows.Forms.Label();
            this.grvImageResult = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gImages = new System.Windows.Forms.GroupBox();
            this.chkImageFolder = new System.Windows.Forms.CheckBox();
            this.chkImageFile = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.grvImageFolder = new System.Windows.Forms.DataGridView();
            this.ImgPathFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImgTypeFolder = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grvImages = new System.Windows.Forms.DataGridView();
            this.ImgPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImgId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImgType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.gImgGenerateScales = new System.Windows.Forms.GroupBox();
            this.btnImgDeleteScales = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.btnImgGenerateScales = new System.Windows.Forms.Button();
            this.txtImgNScales = new System.Windows.Forms.TextBox();
            this.lblImScales = new System.Windows.Forms.Label();
            this.grvImageScales = new System.Windows.Forms.DataGridView();
            this.ImgMasterAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImgGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImgIpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImgReceptionPortRx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImgModel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ImgDisplaySize = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.sfd1 = new System.Windows.Forms.SaveFileDialog();
            this.picDown = new System.Windows.Forms.PictureBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.picUp = new System.Windows.Forms.PictureBox();
            this.lblDibalSDK = new System.Windows.Forms.Label();
            this.lblDibaldll = new System.Windows.Forms.Label();
            this.tabCom.SuspendLayout();
            this.tapPageImport.SuspendLayout();
            this.gImportFiles.SuspendLayout();
            this.gRegistersSend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).BeginInit();
            this.gAddData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvRegisters)).BeginInit();
            this.gGenerateScales.SuspendLayout();
            this.gGenerateArticles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvScales)).BeginInit();
            this.gImportParameters.SuspendLayout();
            this.tabPageExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvExResult)).BeginInit();
            this.gExAddData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvExportScales)).BeginInit();
            this.gExGenerateScales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvExRegisters)).BeginInit();
            this.gExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctExporting)).BeginInit();
            this.tabPageImage.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvImageResult)).BeginInit();
            this.gImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvImageFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvImages)).BeginInit();
            this.gImgGenerateScales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvImageScales)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).BeginInit();
            this.picDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUp)).BeginInit();
            this.picUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCom
            // 
            this.tabCom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCom.Controls.Add(this.tapPageImport);
            this.tabCom.Controls.Add(this.tabPageExport);
            this.tabCom.Controls.Add(this.tabPageImage);
            this.tabCom.Location = new System.Drawing.Point(0, 39);
            this.tabCom.Name = "tabCom";
            this.tabCom.SelectedIndex = 0;
            this.tabCom.Size = new System.Drawing.Size(1211, 679);
            this.tabCom.TabIndex = 32;
            // 
            // tapPageImport
            // 
            this.tapPageImport.AutoScroll = true;
            this.tapPageImport.Controls.Add(this.gImportFiles);
            this.tapPageImport.Controls.Add(this.lblStatus);
            this.tapPageImport.Controls.Add(this.gRegistersSend);
            this.tapPageImport.Controls.Add(this.grvResult);
            this.tapPageImport.Controls.Add(this.gAddData);
            this.tapPageImport.Controls.Add(this.gImportParameters);
            this.tapPageImport.Location = new System.Drawing.Point(4, 28);
            this.tapPageImport.Name = "tapPageImport";
            this.tapPageImport.Padding = new System.Windows.Forms.Padding(3);
            this.tapPageImport.Size = new System.Drawing.Size(1203, 647);
            this.tapPageImport.TabIndex = 0;
            this.tapPageImport.Text = "Import";
            this.tapPageImport.UseVisualStyleBackColor = true;
            // 
            // gImportFiles
            // 
            this.gImportFiles.Controls.Add(this.lblInfo2);
            this.gImportFiles.Controls.Add(this.btnDataSend);
            this.gImportFiles.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gImportFiles.Location = new System.Drawing.Point(314, 514);
            this.gImportFiles.Name = "gImportFiles";
            this.gImportFiles.Size = new System.Drawing.Size(334, 117);
            this.gImportFiles.TabIndex = 32;
            this.gImportFiles.TabStop = false;
            this.gImportFiles.Text = "Import Items using FILES";
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo2.Location = new System.Drawing.Point(2, 89);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(331, 16);
            this.lblInfo2.TabIndex = 2;
            this.lblInfo2.Text = "Used: dibalscopItems2.txt  and dibalscopScales.ini files";
            // 
            // btnDataSend
            // 
            this.btnDataSend.BackColor = System.Drawing.Color.PowderBlue;
            this.btnDataSend.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataSend.Location = new System.Drawing.Point(69, 27);
            this.btnDataSend.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnDataSend.Name = "btnDataSend";
            this.btnDataSend.Size = new System.Drawing.Size(197, 47);
            this.btnDataSend.TabIndex = 0;
            this.btnDataSend.Text = "DataSend2";
            this.btnDataSend.UseVisualStyleBackColor = false;
            this.btnDataSend.Click += new System.EventHandler(this.btnDataSend_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(913, 503);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(122, 38);
            this.lblStatus.TabIndex = 35;
            this.lblStatus.Text = "Stopped";
            // 
            // gRegistersSend
            // 
            this.gRegistersSend.Controls.Add(this.lblInfo3);
            this.gRegistersSend.Controls.Add(this.btnRegistersSend);
            this.gRegistersSend.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gRegistersSend.Location = new System.Drawing.Point(653, 514);
            this.gRegistersSend.Name = "gRegistersSend";
            this.gRegistersSend.Size = new System.Drawing.Size(251, 117);
            this.gRegistersSend.TabIndex = 9;
            this.gRegistersSend.TabStop = false;
            this.gRegistersSend.Text = "Import Data using REGISTERS";
            // 
            // lblInfo3
            // 
            this.lblInfo3.AutoSize = true;
            this.lblInfo3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo3.Location = new System.Drawing.Point(30, 89);
            this.lblInfo3.Name = "lblInfo3";
            this.lblInfo3.Size = new System.Drawing.Size(195, 16);
            this.lblInfo3.TabIndex = 1;
            this.lblInfo3.Text = "Used: Scales and Registers grid";
            // 
            // btnRegistersSend
            // 
            this.btnRegistersSend.BackColor = System.Drawing.Color.PowderBlue;
            this.btnRegistersSend.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistersSend.Location = new System.Drawing.Point(28, 27);
            this.btnRegistersSend.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnRegistersSend.Name = "btnRegistersSend";
            this.btnRegistersSend.Size = new System.Drawing.Size(197, 47);
            this.btnRegistersSend.TabIndex = 0;
            this.btnRegistersSend.Text = "RegistersSend";
            this.btnRegistersSend.UseVisualStyleBackColor = false;
            this.btnRegistersSend.Click += new System.EventHandler(this.btnRegistersSend_Click);
            // 
            // grvResult
            // 
            this.grvResult.AllowUserToAddRows = false;
            this.grvResult.AllowUserToDeleteRows = false;
            this.grvResult.AllowUserToResizeColumns = false;
            this.grvResult.AllowUserToResizeRows = false;
            this.grvResult.BackgroundColor = System.Drawing.Color.LightGray;
            this.grvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RIpAddress,
            this.Result});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvResult.DefaultCellStyle = dataGridViewCellStyle1;
            this.grvResult.Location = new System.Drawing.Point(920, 544);
            this.grvResult.Name = "grvResult";
            this.grvResult.ReadOnly = true;
            this.grvResult.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvResult.Size = new System.Drawing.Size(243, 87);
            this.grvResult.TabIndex = 33;
            // 
            // RIpAddress
            // 
            this.RIpAddress.DataPropertyName = "IpAddress";
            this.RIpAddress.HeaderText = "IP Address";
            this.RIpAddress.Name = "RIpAddress";
            this.RIpAddress.ReadOnly = true;
            // 
            // Result
            // 
            this.Result.DataPropertyName = "Result";
            this.Result.FillWeight = 70F;
            this.Result.HeaderText = "Result";
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            // 
            // gAddData
            // 
            this.gAddData.Controls.Add(this.lblAddRegisters);
            this.gAddData.Controls.Add(this.grvRegisters);
            this.gAddData.Controls.Add(this.cboCloseTime);
            this.gAddData.Controls.Add(this.cboShowWindow);
            this.gAddData.Controls.Add(this.lblCloseTime);
            this.gAddData.Controls.Add(this.lblShowWindow);
            this.gAddData.Controls.Add(this.gGenerateScales);
            this.gAddData.Controls.Add(this.gGenerateArticles);
            this.gAddData.Controls.Add(this.lblAddArticles);
            this.gAddData.Controls.Add(this.grvItems);
            this.gAddData.Controls.Add(this.lblAddScales);
            this.gAddData.Controls.Add(this.grvScales);
            this.gAddData.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gAddData.Location = new System.Drawing.Point(11, 6);
            this.gAddData.Name = "gAddData";
            this.gAddData.Size = new System.Drawing.Size(1168, 495);
            this.gAddData.TabIndex = 1;
            this.gAddData.TabStop = false;
            this.gAddData.Text = "EDIT DATA";
            // 
            // lblAddRegisters
            // 
            this.lblAddRegisters.AutoSize = true;
            this.lblAddRegisters.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddRegisters.Location = new System.Drawing.Point(22, 324);
            this.lblAddRegisters.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddRegisters.Name = "lblAddRegisters";
            this.lblAddRegisters.Size = new System.Drawing.Size(66, 19);
            this.lblAddRegisters.TabIndex = 35;
            this.lblAddRegisters.Text = "Registers";
            // 
            // grvRegisters
            // 
            this.grvRegisters.BackgroundColor = System.Drawing.Color.LightGray;
            this.grvRegisters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvRegisters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Register});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvRegisters.DefaultCellStyle = dataGridViewCellStyle2;
            this.grvRegisters.Location = new System.Drawing.Point(22, 346);
            this.grvRegisters.Name = "grvRegisters";
            this.grvRegisters.Size = new System.Drawing.Size(871, 132);
            this.grvRegisters.TabIndex = 2;
            // 
            // Register
            // 
            this.Register.HeaderText = "Register";
            this.Register.Name = "Register";
            this.Register.Width = 828;
            // 
            // cboCloseTime
            // 
            this.cboCloseTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCloseTime.FormattingEnabled = true;
            this.cboCloseTime.Location = new System.Drawing.Point(1046, 376);
            this.cboCloseTime.Name = "cboCloseTime";
            this.cboCloseTime.Size = new System.Drawing.Size(113, 27);
            this.cboCloseTime.TabIndex = 4;
            // 
            // cboShowWindow
            // 
            this.cboShowWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShowWindow.FormattingEnabled = true;
            this.cboShowWindow.Location = new System.Drawing.Point(1046, 342);
            this.cboShowWindow.Name = "cboShowWindow";
            this.cboShowWindow.Size = new System.Drawing.Size(113, 27);
            this.cboShowWindow.TabIndex = 3;
            // 
            // lblCloseTime
            // 
            this.lblCloseTime.AutoSize = true;
            this.lblCloseTime.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCloseTime.Location = new System.Drawing.Point(935, 380);
            this.lblCloseTime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCloseTime.Name = "lblCloseTime";
            this.lblCloseTime.Size = new System.Drawing.Size(83, 19);
            this.lblCloseTime.TabIndex = 28;
            this.lblCloseTime.Text = "Close Time:";
            // 
            // lblShowWindow
            // 
            this.lblShowWindow.AutoSize = true;
            this.lblShowWindow.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowWindow.Location = new System.Drawing.Point(935, 346);
            this.lblShowWindow.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblShowWindow.Name = "lblShowWindow";
            this.lblShowWindow.Size = new System.Drawing.Size(103, 19);
            this.lblShowWindow.TabIndex = 27;
            this.lblShowWindow.Text = "Show Window:";
            // 
            // gGenerateScales
            // 
            this.gGenerateScales.Controls.Add(this.btnDeleteScalesGrid);
            this.gGenerateScales.Controls.Add(this.lblNumScales);
            this.gGenerateScales.Controls.Add(this.btnGenerateScales);
            this.gGenerateScales.Controls.Add(this.txtNScales);
            this.gGenerateScales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gGenerateScales.Location = new System.Drawing.Point(657, 39);
            this.gGenerateScales.Name = "gGenerateScales";
            this.gGenerateScales.Size = new System.Drawing.Size(288, 115);
            this.gGenerateScales.TabIndex = 4;
            this.gGenerateScales.TabStop = false;
            this.gGenerateScales.Text = "Generate scales automatically";
            // 
            // btnDeleteScalesGrid
            // 
            this.btnDeleteScalesGrid.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteScalesGrid.Location = new System.Drawing.Point(151, 64);
            this.btnDeleteScalesGrid.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnDeleteScalesGrid.Name = "btnDeleteScalesGrid";
            this.btnDeleteScalesGrid.Size = new System.Drawing.Size(124, 37);
            this.btnDeleteScalesGrid.TabIndex = 2;
            this.btnDeleteScalesGrid.Text = "Delete scales";
            this.btnDeleteScalesGrid.UseVisualStyleBackColor = true;
            this.btnDeleteScalesGrid.Click += new System.EventHandler(this.btnDeleteScalesGrid_Click);
            // 
            // lblNumScales
            // 
            this.lblNumScales.AutoSize = true;
            this.lblNumScales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumScales.Location = new System.Drawing.Point(8, 31);
            this.lblNumScales.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNumScales.Name = "lblNumScales";
            this.lblNumScales.Size = new System.Drawing.Size(114, 19);
            this.lblNumScales.TabIndex = 20;
            this.lblNumScales.Text = "Generate scales:";
            // 
            // btnGenerateScales
            // 
            this.btnGenerateScales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateScales.Location = new System.Drawing.Point(12, 64);
            this.btnGenerateScales.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnGenerateScales.Name = "btnGenerateScales";
            this.btnGenerateScales.Size = new System.Drawing.Size(124, 37);
            this.btnGenerateScales.TabIndex = 1;
            this.btnGenerateScales.Text = "Generate scales";
            this.btnGenerateScales.UseVisualStyleBackColor = true;
            this.btnGenerateScales.Click += new System.EventHandler(this.btnGenerateScales_Click);
            // 
            // txtNScales
            // 
            this.txtNScales.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNScales.Location = new System.Drawing.Point(127, 31);
            this.txtNScales.MaxLength = 5;
            this.txtNScales.Name = "txtNScales";
            this.txtNScales.Size = new System.Drawing.Size(103, 22);
            this.txtNScales.TabIndex = 0;
            this.txtNScales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNScales.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNScales_KeyUp);
            // 
            // gGenerateArticles
            // 
            this.gGenerateArticles.Controls.Add(this.btnDeleteArticlesGrid);
            this.gGenerateArticles.Controls.Add(this.lblNumItems);
            this.gGenerateArticles.Controls.Add(this.btnGenerateAticles);
            this.gGenerateArticles.Controls.Add(this.txtNArticles);
            this.gGenerateArticles.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gGenerateArticles.Location = new System.Drawing.Point(657, 190);
            this.gGenerateArticles.Name = "gGenerateArticles";
            this.gGenerateArticles.Size = new System.Drawing.Size(288, 121);
            this.gGenerateArticles.TabIndex = 2;
            this.gGenerateArticles.TabStop = false;
            this.gGenerateArticles.Text = "Generate items automatically";
            // 
            // btnDeleteArticlesGrid
            // 
            this.btnDeleteArticlesGrid.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteArticlesGrid.Location = new System.Drawing.Point(151, 68);
            this.btnDeleteArticlesGrid.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnDeleteArticlesGrid.Name = "btnDeleteArticlesGrid";
            this.btnDeleteArticlesGrid.Size = new System.Drawing.Size(124, 37);
            this.btnDeleteArticlesGrid.TabIndex = 2;
            this.btnDeleteArticlesGrid.Text = "Delete  items";
            this.btnDeleteArticlesGrid.UseVisualStyleBackColor = true;
            this.btnDeleteArticlesGrid.Click += new System.EventHandler(this.btnDeleteArticlesGrid_Click);
            // 
            // lblNumItems
            // 
            this.lblNumItems.AutoSize = true;
            this.lblNumItems.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumItems.Location = new System.Drawing.Point(8, 33);
            this.lblNumItems.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNumItems.Name = "lblNumItems";
            this.lblNumItems.Size = new System.Drawing.Size(113, 19);
            this.lblNumItems.TabIndex = 3;
            this.lblNumItems.Text = "Generate Items:";
            // 
            // btnGenerateAticles
            // 
            this.btnGenerateAticles.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateAticles.Location = new System.Drawing.Point(12, 68);
            this.btnGenerateAticles.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnGenerateAticles.Name = "btnGenerateAticles";
            this.btnGenerateAticles.Size = new System.Drawing.Size(124, 37);
            this.btnGenerateAticles.TabIndex = 1;
            this.btnGenerateAticles.Text = "Generate items";
            this.btnGenerateAticles.UseVisualStyleBackColor = true;
            this.btnGenerateAticles.Click += new System.EventHandler(this.btnGenerateArticles_Click);
            // 
            // txtNArticles
            // 
            this.txtNArticles.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNArticles.Location = new System.Drawing.Point(129, 31);
            this.txtNArticles.MaxLength = 5;
            this.txtNArticles.Name = "txtNArticles";
            this.txtNArticles.Size = new System.Drawing.Size(103, 22);
            this.txtNArticles.TabIndex = 0;
            this.txtNArticles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNArticles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNArticles_KeyUp);
            // 
            // lblAddArticles
            // 
            this.lblAddArticles.AutoSize = true;
            this.lblAddArticles.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddArticles.Location = new System.Drawing.Point(18, 156);
            this.lblAddArticles.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddArticles.Name = "lblAddArticles";
            this.lblAddArticles.Size = new System.Drawing.Size(45, 19);
            this.lblAddArticles.TabIndex = 24;
            this.lblAddArticles.Text = "Items";
            // 
            // grvItems
            // 
            this.grvItems.BackgroundColor = System.Drawing.Color.LightGray;
            this.grvItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.DirectKey,
            this.Type,
            this.itemName,
            this.Price});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvItems.DefaultCellStyle = dataGridViewCellStyle3;
            this.grvItems.Location = new System.Drawing.Point(22, 179);
            this.grvItems.Name = "grvItems";
            this.grvItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grvItems.Size = new System.Drawing.Size(570, 142);
            this.grvItems.TabIndex = 1;
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.MaxInputLength = 6;
            this.Code.Name = "Code";
            this.Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DirectKey
            // 
            this.DirectKey.HeaderText = "DirectKey";
            this.DirectKey.MaxInputLength = 3;
            this.DirectKey.Name = "DirectKey";
            this.DirectKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DirectKey.Width = 80;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.Width = 90;
            // 
            // itemName
            // 
            this.itemName.HeaderText = "Name";
            this.itemName.MaxInputLength = 36;
            this.itemName.Name = "itemName";
            this.itemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.itemName.Width = 170;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MaxInputLength = 6;
            this.Price.Name = "Price";
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Price.Width = 90;
            // 
            // lblAddScales
            // 
            this.lblAddScales.AutoSize = true;
            this.lblAddScales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddScales.Location = new System.Drawing.Point(18, 16);
            this.lblAddScales.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddScales.Name = "lblAddScales";
            this.lblAddScales.Size = new System.Drawing.Size(49, 19);
            this.lblAddScales.TabIndex = 18;
            this.lblAddScales.Text = "Scales";
            // 
            // grvScales
            // 
            this.grvScales.AllowUserToResizeColumns = false;
            this.grvScales.BackgroundColor = System.Drawing.Color.LightGray;
            this.grvScales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvScales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grvScales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvScales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MasterAddress,
            this.Group,
            this.IpAddress,
            this.ReceptionPortRx,
            this.Model});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvScales.DefaultCellStyle = dataGridViewCellStyle6;
            this.grvScales.GridColor = System.Drawing.Color.Silver;
            this.grvScales.Location = new System.Drawing.Point(21, 21);
            this.grvScales.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grvScales.Name = "grvScales";
            this.grvScales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grvScales.Size = new System.Drawing.Size(613, 116);
            this.grvScales.TabIndex = 0;
            // 
            // MasterAddress
            // 
            this.MasterAddress.FillWeight = 120F;
            this.MasterAddress.HeaderText = "MasterAddress";
            this.MasterAddress.MaxInputLength = 2;
            this.MasterAddress.Name = "MasterAddress";
            this.MasterAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MasterAddress.Width = 120;
            // 
            // Group
            // 
            dataGridViewCellStyle5.NullValue = null;
            this.Group.DefaultCellStyle = dataGridViewCellStyle5;
            this.Group.FillWeight = 70F;
            this.Group.HeaderText = "Group";
            this.Group.MaxInputLength = 2;
            this.Group.Name = "Group";
            this.Group.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Group.Width = 70;
            // 
            // IpAddress
            // 
            this.IpAddress.FillWeight = 140F;
            this.IpAddress.HeaderText = "IpAddress";
            this.IpAddress.MaxInputLength = 15;
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IpAddress.Width = 140;
            // 
            // ReceptionPortRx
            // 
            this.ReceptionPortRx.FillWeight = 140F;
            this.ReceptionPortRx.HeaderText = "ReceptionPortRx";
            this.ReceptionPortRx.MaxInputLength = 5;
            this.ReceptionPortRx.Name = "ReceptionPortRx";
            this.ReceptionPortRx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ReceptionPortRx.Width = 140;
            // 
            // Model
            // 
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            this.Model.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gImportParameters
            // 
            this.gImportParameters.Controls.Add(this.lblInfo1);
            this.gImportParameters.Controls.Add(this.btnItemsSend);
            this.gImportParameters.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gImportParameters.Location = new System.Drawing.Point(11, 514);
            this.gImportParameters.Name = "gImportParameters";
            this.gImportParameters.Size = new System.Drawing.Size(297, 117);
            this.gImportParameters.TabIndex = 8;
            this.gImportParameters.TabStop = false;
            this.gImportParameters.Text = "Import Items using PARAMETERS";
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo1.Location = new System.Drawing.Point(29, 89);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(172, 16);
            this.lblInfo1.TabIndex = 2;
            this.lblInfo1.Text = "Used: Scales and Items grid";
            // 
            // btnItemsSend
            // 
            this.btnItemsSend.BackColor = System.Drawing.Color.PowderBlue;
            this.btnItemsSend.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItemsSend.Location = new System.Drawing.Point(28, 27);
            this.btnItemsSend.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnItemsSend.Name = "btnItemsSend";
            this.btnItemsSend.Size = new System.Drawing.Size(197, 47);
            this.btnItemsSend.TabIndex = 0;
            this.btnItemsSend.Text = "ItemsSend2";
            this.btnItemsSend.UseVisualStyleBackColor = false;
            this.btnItemsSend.Click += new System.EventHandler(this.btnItemsSend_Click);
            // 
            // tabPageExport
            // 
            this.tabPageExport.AutoScroll = true;
            this.tabPageExport.Controls.Add(this.grvExResult);
            this.tabPageExport.Controls.Add(this.lblNRegisters);
            this.tabPageExport.Controls.Add(this.lblRRegisters);
            this.tabPageExport.Controls.Add(this.gExAddData);
            this.tabPageExport.Controls.Add(this.lblExportStatus);
            this.tabPageExport.Controls.Add(this.grvExRegisters);
            this.tabPageExport.Controls.Add(this.gExport);
            this.tabPageExport.Controls.Add(this.pctExporting);
            this.tabPageExport.Location = new System.Drawing.Point(4, 28);
            this.tabPageExport.Name = "tabPageExport";
            this.tabPageExport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExport.Size = new System.Drawing.Size(1203, 647);
            this.tabPageExport.TabIndex = 1;
            this.tabPageExport.Text = "Export";
            this.tabPageExport.UseVisualStyleBackColor = true;
            // 
            // grvExResult
            // 
            this.grvExResult.BackgroundColor = System.Drawing.Color.LightGray;
            this.grvExResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvExResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IpAddressResult,
            this.ExResult});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvExResult.DefaultCellStyle = dataGridViewCellStyle8;
            this.grvExResult.Location = new System.Drawing.Point(743, 298);
            this.grvExResult.Name = "grvExResult";
            this.grvExResult.Size = new System.Drawing.Size(342, 131);
            this.grvExResult.TabIndex = 50;
            // 
            // IpAddressResult
            // 
            this.IpAddressResult.HeaderText = "IpAddress";
            this.IpAddressResult.Name = "IpAddressResult";
            // 
            // ExResult
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExResult.DefaultCellStyle = dataGridViewCellStyle7;
            this.ExResult.HeaderText = "Result";
            this.ExResult.Name = "ExResult";
            this.ExResult.Width = 198;
            // 
            // lblNRegisters
            // 
            this.lblNRegisters.AutoSize = true;
            this.lblNRegisters.Location = new System.Drawing.Point(652, 393);
            this.lblNRegisters.Name = "lblNRegisters";
            this.lblNRegisters.Size = new System.Drawing.Size(17, 19);
            this.lblNRegisters.TabIndex = 49;
            this.lblNRegisters.Text = "0";
            // 
            // lblRRegisters
            // 
            this.lblRRegisters.AutoSize = true;
            this.lblRRegisters.Location = new System.Drawing.Point(485, 393);
            this.lblRRegisters.Name = "lblRRegisters";
            this.lblRRegisters.Size = new System.Drawing.Size(132, 19);
            this.lblRRegisters.TabIndex = 45;
            this.lblRRegisters.Text = "Received Registers:";
            // 
            // gExAddData
            // 
            this.gExAddData.Controls.Add(this.txtLogsFilePath);
            this.gExAddData.Controls.Add(this.txtExportFilePath);
            this.gExAddData.Controls.Add(this.lblExportLogPath);
            this.gExAddData.Controls.Add(this.lblExportFilePath);
            this.gExAddData.Controls.Add(this.lblAddScalesEx);
            this.gExAddData.Controls.Add(this.lblExIpPc);
            this.gExAddData.Controls.Add(this.grvExportScales);
            this.gExAddData.Controls.Add(this.txtExIpPc);
            this.gExAddData.Controls.Add(this.gExGenerateScales);
            this.gExAddData.Location = new System.Drawing.Point(11, 6);
            this.gExAddData.Name = "gExAddData";
            this.gExAddData.Size = new System.Drawing.Size(1077, 279);
            this.gExAddData.TabIndex = 44;
            this.gExAddData.TabStop = false;
            this.gExAddData.Text = "Add Data";
            // 
            // txtLogsFilePath
            // 
            this.txtLogsFilePath.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogsFilePath.Location = new System.Drawing.Point(246, 239);
            this.txtLogsFilePath.Name = "txtLogsFilePath";
            this.txtLogsFilePath.Size = new System.Drawing.Size(606, 22);
            this.txtLogsFilePath.TabIndex = 3;
            // 
            // txtExportFilePath
            // 
            this.txtExportFilePath.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExportFilePath.Location = new System.Drawing.Point(246, 211);
            this.txtExportFilePath.Name = "txtExportFilePath";
            this.txtExportFilePath.Size = new System.Drawing.Size(606, 22);
            this.txtExportFilePath.TabIndex = 2;
            // 
            // lblExportLogPath
            // 
            this.lblExportLogPath.AutoSize = true;
            this.lblExportLogPath.Location = new System.Drawing.Point(38, 246);
            this.lblExportLogPath.Name = "lblExportLogPath";
            this.lblExportLogPath.Size = new System.Drawing.Size(70, 19);
            this.lblExportLogPath.TabIndex = 46;
            this.lblExportLogPath.Text = "Logs file:";
            // 
            // lblExportFilePath
            // 
            this.lblExportFilePath.AutoSize = true;
            this.lblExportFilePath.Location = new System.Drawing.Point(38, 214);
            this.lblExportFilePath.Name = "lblExportFilePath";
            this.lblExportFilePath.Size = new System.Drawing.Size(134, 19);
            this.lblExportFilePath.TabIndex = 45;
            this.lblExportFilePath.Text = "Registers file path:";
            // 
            // lblAddScalesEx
            // 
            this.lblAddScalesEx.AutoSize = true;
            this.lblAddScalesEx.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddScalesEx.Location = new System.Drawing.Point(18, 16);
            this.lblAddScalesEx.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAddScalesEx.Name = "lblAddScalesEx";
            this.lblAddScalesEx.Size = new System.Drawing.Size(81, 19);
            this.lblAddScalesEx.TabIndex = 20;
            this.lblAddScalesEx.Text = "Add Scales";
            // 
            // lblExIpPc
            // 
            this.lblExIpPc.AutoSize = true;
            this.lblExIpPc.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExIpPc.Location = new System.Drawing.Point(38, 184);
            this.lblExIpPc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblExIpPc.Name = "lblExIpPc";
            this.lblExIpPc.Size = new System.Drawing.Size(101, 19);
            this.lblExIpPc.TabIndex = 43;
            this.lblExIpPc.Text = "PC IpAddress:";
            // 
            // grvExportScales
            // 
            this.grvExportScales.AllowUserToResizeColumns = false;
            this.grvExportScales.BackgroundColor = System.Drawing.Color.LightGray;
            this.grvExportScales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvExportScales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grvExportScales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvExportScales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExMasterAddress,
            this.ExIpAddress,
            this.ExReceptionPortRx,
            this.ExSendPortTx});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvExportScales.DefaultCellStyle = dataGridViewCellStyle10;
            this.grvExportScales.GridColor = System.Drawing.Color.Silver;
            this.grvExportScales.Location = new System.Drawing.Point(22, 38);
            this.grvExportScales.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grvExportScales.Name = "grvExportScales";
            this.grvExportScales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grvExportScales.Size = new System.Drawing.Size(659, 123);
            this.grvExportScales.TabIndex = 0;
            // 
            // ExMasterAddress
            // 
            this.ExMasterAddress.FillWeight = 150F;
            this.ExMasterAddress.HeaderText = "MasterAddress";
            this.ExMasterAddress.MaxInputLength = 2;
            this.ExMasterAddress.Name = "ExMasterAddress";
            this.ExMasterAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExMasterAddress.Width = 150;
            // 
            // ExIpAddress
            // 
            this.ExIpAddress.FillWeight = 160F;
            this.ExIpAddress.HeaderText = "IpAddress";
            this.ExIpAddress.MaxInputLength = 15;
            this.ExIpAddress.Name = "ExIpAddress";
            this.ExIpAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExIpAddress.Width = 165;
            // 
            // ExReceptionPortRx
            // 
            this.ExReceptionPortRx.FillWeight = 150F;
            this.ExReceptionPortRx.HeaderText = "ReceptionPortRx";
            this.ExReceptionPortRx.MaxInputLength = 5;
            this.ExReceptionPortRx.Name = "ExReceptionPortRx";
            this.ExReceptionPortRx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExReceptionPortRx.Width = 150;
            // 
            // ExSendPortTx
            // 
            this.ExSendPortTx.HeaderText = "SendPortTx";
            this.ExSendPortTx.Name = "ExSendPortTx";
            this.ExSendPortTx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ExSendPortTx.Width = 150;
            // 
            // txtExIpPc
            // 
            this.txtExIpPc.AcceptsTab = true;
            this.txtExIpPc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExIpPc.Location = new System.Drawing.Point(249, 180);
            this.txtExIpPc.MaxLength = 15;
            this.txtExIpPc.Name = "txtExIpPc";
            this.txtExIpPc.Size = new System.Drawing.Size(131, 22);
            this.txtExIpPc.TabIndex = 1;
            // 
            // gExGenerateScales
            // 
            this.gExGenerateScales.Controls.Add(this.btnExDeleteScales);
            this.gExGenerateScales.Controls.Add(this.lblExGenerateScales);
            this.gExGenerateScales.Controls.Add(this.btnExGenerateScales);
            this.gExGenerateScales.Controls.Add(this.txtExNScales);
            this.gExGenerateScales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gExGenerateScales.Location = new System.Drawing.Point(725, 31);
            this.gExGenerateScales.Name = "gExGenerateScales";
            this.gExGenerateScales.Size = new System.Drawing.Size(309, 132);
            this.gExGenerateScales.TabIndex = 41;
            this.gExGenerateScales.TabStop = false;
            this.gExGenerateScales.Text = "Generate scales automatically";
            // 
            // btnExDeleteScales
            // 
            this.btnExDeleteScales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExDeleteScales.Location = new System.Drawing.Point(173, 74);
            this.btnExDeleteScales.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnExDeleteScales.Name = "btnExDeleteScales";
            this.btnExDeleteScales.Size = new System.Drawing.Size(124, 37);
            this.btnExDeleteScales.TabIndex = 2;
            this.btnExDeleteScales.Text = "Delete scales";
            this.btnExDeleteScales.UseVisualStyleBackColor = true;
            this.btnExDeleteScales.Click += new System.EventHandler(this.btnExportScalesDelete_Click);
            // 
            // lblExGenerateScales
            // 
            this.lblExGenerateScales.AutoSize = true;
            this.lblExGenerateScales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExGenerateScales.Location = new System.Drawing.Point(13, 36);
            this.lblExGenerateScales.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblExGenerateScales.Name = "lblExGenerateScales";
            this.lblExGenerateScales.Size = new System.Drawing.Size(114, 19);
            this.lblExGenerateScales.TabIndex = 20;
            this.lblExGenerateScales.Text = "Generate scales:";
            // 
            // btnExGenerateScales
            // 
            this.btnExGenerateScales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExGenerateScales.Location = new System.Drawing.Point(17, 74);
            this.btnExGenerateScales.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnExGenerateScales.Name = "btnExGenerateScales";
            this.btnExGenerateScales.Size = new System.Drawing.Size(124, 37);
            this.btnExGenerateScales.TabIndex = 1;
            this.btnExGenerateScales.Text = "Generate scales";
            this.btnExGenerateScales.UseVisualStyleBackColor = true;
            this.btnExGenerateScales.Click += new System.EventHandler(this.btnExportScalesGenerate_Click);
            // 
            // txtExNScales
            // 
            this.txtExNScales.AcceptsTab = true;
            this.txtExNScales.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExNScales.Location = new System.Drawing.Point(132, 34);
            this.txtExNScales.MaxLength = 5;
            this.txtExNScales.Name = "txtExNScales";
            this.txtExNScales.Size = new System.Drawing.Size(103, 22);
            this.txtExNScales.TabIndex = 0;
            this.txtExNScales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExNScales.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtExNScales_KeyUp);
            // 
            // lblExportStatus
            // 
            this.lblExportStatus.AutoSize = true;
            this.lblExportStatus.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblExportStatus.Location = new System.Drawing.Point(482, 328);
            this.lblExportStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblExportStatus.Name = "lblExportStatus";
            this.lblExportStatus.Size = new System.Drawing.Size(122, 38);
            this.lblExportStatus.TabIndex = 40;
            this.lblExportStatus.Text = "Stopped";
            // 
            // grvExRegisters
            // 
            this.grvExRegisters.BackgroundColor = System.Drawing.Color.LightGray;
            this.grvExRegisters.ColumnHeadersHeight = 27;
            this.grvExRegisters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grvExRegisters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumRegister,
            this.ScaleIpAddress,
            this.ScaleRegister});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvExRegisters.DefaultCellStyle = dataGridViewCellStyle12;
            this.grvExRegisters.Location = new System.Drawing.Point(9, 440);
            this.grvExRegisters.Name = "grvExRegisters";
            this.grvExRegisters.Size = new System.Drawing.Size(1182, 190);
            this.grvExRegisters.TabIndex = 36;
            // 
            // NumRegister
            // 
            this.NumRegister.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumRegister.HeaderText = "NumRegister";
            this.NumRegister.Name = "NumRegister";
            this.NumRegister.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ScaleIpAddress
            // 
            this.ScaleIpAddress.HeaderText = "IpAddress";
            this.ScaleIpAddress.Name = "ScaleIpAddress";
            this.ScaleIpAddress.Width = 110;
            // 
            // ScaleRegister
            // 
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScaleRegister.DefaultCellStyle = dataGridViewCellStyle11;
            this.ScaleRegister.HeaderText = "Register";
            this.ScaleRegister.Name = "ScaleRegister";
            this.ScaleRegister.Width = 925;
            // 
            // gExport
            // 
            this.gExport.Controls.Add(this.btnStartExportFin);
            this.gExport.Controls.Add(this.btnCancelExport);
            this.gExport.Controls.Add(this.btnStartExportContinuous);
            this.gExport.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gExport.Location = new System.Drawing.Point(11, 287);
            this.gExport.Name = "gExport";
            this.gExport.Size = new System.Drawing.Size(435, 143);
            this.gExport.TabIndex = 21;
            this.gExport.TabStop = false;
            this.gExport.Text = "Export";
            // 
            // btnStartExportFin
            // 
            this.btnStartExportFin.BackColor = System.Drawing.Color.PowderBlue;
            this.btnStartExportFin.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartExportFin.Location = new System.Drawing.Point(28, 83);
            this.btnStartExportFin.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnStartExportFin.Name = "btnStartExportFin";
            this.btnStartExportFin.Size = new System.Drawing.Size(188, 47);
            this.btnStartExportFin.TabIndex = 1;
            this.btnStartExportFin.TabStop = false;
            this.btnStartExportFin.Text = "Start and End";
            this.btnStartExportFin.UseVisualStyleBackColor = false;
            this.btnStartExportFin.Click += new System.EventHandler(this.btnStartExportFin_Click);
            // 
            // btnCancelExport
            // 
            this.btnCancelExport.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCancelExport.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelExport.Location = new System.Drawing.Point(249, 56);
            this.btnCancelExport.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnCancelExport.Name = "btnCancelExport";
            this.btnCancelExport.Size = new System.Drawing.Size(163, 47);
            this.btnCancelExport.TabIndex = 2;
            this.btnCancelExport.Text = "Cancel";
            this.btnCancelExport.UseVisualStyleBackColor = false;
            this.btnCancelExport.Click += new System.EventHandler(this.btnCancelExport_Click);
            // 
            // btnStartExportContinuous
            // 
            this.btnStartExportContinuous.BackColor = System.Drawing.Color.PowderBlue;
            this.btnStartExportContinuous.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartExportContinuous.Location = new System.Drawing.Point(28, 27);
            this.btnStartExportContinuous.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnStartExportContinuous.Name = "btnStartExportContinuous";
            this.btnStartExportContinuous.Size = new System.Drawing.Size(188, 47);
            this.btnStartExportContinuous.TabIndex = 0;
            this.btnStartExportContinuous.Text = "Start Continuous";
            this.btnStartExportContinuous.UseVisualStyleBackColor = false;
            this.btnStartExportContinuous.Click += new System.EventHandler(this.btnStartExportContinuous_Click);
            // 
            // pctExporting
            // 
            this.pctExporting.Image = ((System.Drawing.Image)(resources.GetObject("pctExporting.Image")));
            this.pctExporting.Location = new System.Drawing.Point(643, 334);
            this.pctExporting.Name = "pctExporting";
            this.pctExporting.Size = new System.Drawing.Size(26, 27);
            this.pctExporting.TabIndex = 46;
            this.pctExporting.TabStop = false;
            this.pctExporting.Visible = false;
            // 
            // tabPageImage
            // 
            this.tabPageImage.Controls.Add(this.groupBox12);
            this.tabPageImage.Controls.Add(this.groupBox13);
            this.tabPageImage.Controls.Add(this.lblImageStatus);
            this.tabPageImage.Controls.Add(this.grvImageResult);
            this.tabPageImage.Controls.Add(this.gImages);
            this.tabPageImage.Location = new System.Drawing.Point(4, 28);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImage.Size = new System.Drawing.Size(1203, 647);
            this.tabPageImage.TabIndex = 2;
            this.tabPageImage.Text = "Image";
            this.tabPageImage.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label25);
            this.groupBox12.Controls.Add(this.btnImageSend);
            this.groupBox12.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.Location = new System.Drawing.Point(440, 515);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(334, 117);
            this.groupBox12.TabIndex = 39;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Import IMAGES";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(2, 89);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(182, 16);
            this.label25.TabIndex = 2;
            this.label25.Text = "Used: Scales and Images grid";
            // 
            // btnImageSend
            // 
            this.btnImageSend.BackColor = System.Drawing.Color.PowderBlue;
            this.btnImageSend.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImageSend.Location = new System.Drawing.Point(69, 27);
            this.btnImageSend.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnImageSend.Name = "btnImageSend";
            this.btnImageSend.Size = new System.Drawing.Size(197, 47);
            this.btnImageSend.TabIndex = 0;
            this.btnImageSend.Text = "ImageSend";
            this.btnImageSend.UseVisualStyleBackColor = false;
            this.btnImageSend.Click += new System.EventHandler(this.btnImageSend_Click);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.rdbConcatenate);
            this.groupBox13.Controls.Add(this.rdbReplace);
            this.groupBox13.Controls.Add(this.label27);
            this.groupBox13.Controls.Add(this.btnImageFileGenerator);
            this.groupBox13.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.Location = new System.Drawing.Point(11, 515);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(392, 117);
            this.groupBox13.TabIndex = 38;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Create Image register FILE";
            // 
            // rdbConcatenate
            // 
            this.rdbConcatenate.AutoSize = true;
            this.rdbConcatenate.Checked = true;
            this.rdbConcatenate.Location = new System.Drawing.Point(244, 53);
            this.rdbConcatenate.Name = "rdbConcatenate";
            this.rdbConcatenate.Size = new System.Drawing.Size(132, 23);
            this.rdbConcatenate.TabIndex = 4;
            this.rdbConcatenate.TabStop = true;
            this.rdbConcatenate.Text = "Concatenate File";
            this.rdbConcatenate.UseVisualStyleBackColor = true;
            // 
            // rdbReplace
            // 
            this.rdbReplace.AutoSize = true;
            this.rdbReplace.Location = new System.Drawing.Point(244, 25);
            this.rdbReplace.Name = "rdbReplace";
            this.rdbReplace.Size = new System.Drawing.Size(103, 23);
            this.rdbReplace.TabIndex = 3;
            this.rdbReplace.TabStop = true;
            this.rdbReplace.Text = "Replace File";
            this.rdbReplace.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(29, 89);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(182, 16);
            this.label27.TabIndex = 2;
            this.label27.Text = "Used: Scales and Images grid";
            // 
            // btnImageFileGenerator
            // 
            this.btnImageFileGenerator.BackColor = System.Drawing.Color.PowderBlue;
            this.btnImageFileGenerator.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImageFileGenerator.Location = new System.Drawing.Point(28, 27);
            this.btnImageFileGenerator.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnImageFileGenerator.Name = "btnImageFileGenerator";
            this.btnImageFileGenerator.Size = new System.Drawing.Size(197, 47);
            this.btnImageFileGenerator.TabIndex = 0;
            this.btnImageFileGenerator.Text = "ImageFileGenerator";
            this.btnImageFileGenerator.UseVisualStyleBackColor = false;
            this.btnImageFileGenerator.Click += new System.EventHandler(this.btnImageFileGenerator_Click);
            // 
            // lblImageStatus
            // 
            this.lblImageStatus.AutoSize = true;
            this.lblImageStatus.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblImageStatus.Location = new System.Drawing.Point(916, 504);
            this.lblImageStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblImageStatus.Name = "lblImageStatus";
            this.lblImageStatus.Size = new System.Drawing.Size(122, 38);
            this.lblImageStatus.TabIndex = 37;
            this.lblImageStatus.Text = "Stopped";
            // 
            // grvImageResult
            // 
            this.grvImageResult.AllowUserToAddRows = false;
            this.grvImageResult.AllowUserToDeleteRows = false;
            this.grvImageResult.AllowUserToResizeColumns = false;
            this.grvImageResult.AllowUserToResizeRows = false;
            this.grvImageResult.BackgroundColor = System.Drawing.Color.LightGray;
            this.grvImageResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvImageResult.DefaultCellStyle = dataGridViewCellStyle13;
            this.grvImageResult.Location = new System.Drawing.Point(923, 545);
            this.grvImageResult.Name = "grvImageResult";
            this.grvImageResult.ReadOnly = true;
            this.grvImageResult.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvImageResult.Size = new System.Drawing.Size(243, 87);
            this.grvImageResult.TabIndex = 36;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "IpAddress";
            this.dataGridViewTextBoxColumn22.HeaderText = "IP Address";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Result";
            this.dataGridViewTextBoxColumn23.FillWeight = 70F;
            this.dataGridViewTextBoxColumn23.HeaderText = "Result";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            // 
            // gImages
            // 
            this.gImages.Controls.Add(this.chkImageFolder);
            this.gImages.Controls.Add(this.chkImageFile);
            this.gImages.Controls.Add(this.label21);
            this.gImages.Controls.Add(this.grvImageFolder);
            this.gImages.Controls.Add(this.grvImages);
            this.gImages.Controls.Add(this.label20);
            this.gImages.Controls.Add(this.gImgGenerateScales);
            this.gImages.Controls.Add(this.lblImScales);
            this.gImages.Controls.Add(this.grvImageScales);
            this.gImages.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gImages.Location = new System.Drawing.Point(11, 6);
            this.gImages.Name = "gImages";
            this.gImages.Size = new System.Drawing.Size(1168, 495);
            this.gImages.TabIndex = 2;
            this.gImages.TabStop = false;
            this.gImages.Text = "EDIT DATA";
            // 
            // chkImageFolder
            // 
            this.chkImageFolder.AutoSize = true;
            this.chkImageFolder.Location = new System.Drawing.Point(22, 357);
            this.chkImageFolder.Name = "chkImageFolder";
            this.chkImageFolder.Size = new System.Drawing.Size(15, 14);
            this.chkImageFolder.TabIndex = 40;
            this.chkImageFolder.UseVisualStyleBackColor = true;
            this.chkImageFolder.CheckedChanged += new System.EventHandler(this.chkImageFolder_CheckedChanged);
            // 
            // chkImageFile
            // 
            this.chkImageFile.AutoSize = true;
            this.chkImageFile.Location = new System.Drawing.Point(22, 201);
            this.chkImageFile.Name = "chkImageFile";
            this.chkImageFile.Size = new System.Drawing.Size(15, 14);
            this.chkImageFile.TabIndex = 39;
            this.chkImageFile.UseVisualStyleBackColor = true;
            this.chkImageFile.CheckedChanged += new System.EventHandler(this.chkImageFile_CheckedChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(43, 335);
            this.label21.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(93, 19);
            this.label21.TabIndex = 38;
            this.label21.Text = "Image Folder";
            // 
            // grvImageFolder
            // 
            this.grvImageFolder.AllowUserToAddRows = false;
            this.grvImageFolder.AllowUserToResizeColumns = false;
            this.grvImageFolder.AllowUserToResizeRows = false;
            this.grvImageFolder.BackgroundColor = System.Drawing.Color.LightGray;
            this.grvImageFolder.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvImageFolder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.grvImageFolder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvImageFolder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImgPathFolder,
            this.ImgTypeFolder});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvImageFolder.DefaultCellStyle = dataGridViewCellStyle15;
            this.grvImageFolder.GridColor = System.Drawing.Color.Silver;
            this.grvImageFolder.Location = new System.Drawing.Point(47, 357);
            this.grvImageFolder.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grvImageFolder.Name = "grvImageFolder";
            this.grvImageFolder.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grvImageFolder.Size = new System.Drawing.Size(930, 64);
            this.grvImageFolder.TabIndex = 37;
            this.grvImageFolder.SelectionChanged += new System.EventHandler(this.grvImageFolder_SelectionChanged);
            // 
            // ImgPathFolder
            // 
            this.ImgPathFolder.FillWeight = 120F;
            this.ImgPathFolder.HeaderText = "Path";
            this.ImgPathFolder.MaxInputLength = 0;
            this.ImgPathFolder.Name = "ImgPathFolder";
            this.ImgPathFolder.Width = 730;
            // 
            // ImgTypeFolder
            // 
            this.ImgTypeFolder.HeaderText = "Type";
            this.ImgTypeFolder.Name = "ImgTypeFolder";
            this.ImgTypeFolder.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ImgTypeFolder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ImgTypeFolder.Width = 154;
            // 
            // grvImages
            // 
            this.grvImages.AllowUserToAddRows = false;
            this.grvImages.AllowUserToResizeColumns = false;
            this.grvImages.BackgroundColor = System.Drawing.Color.LightGray;
            this.grvImages.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvImages.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.grvImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImgPath,
            this.ImgId,
            this.ImgType});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvImages.DefaultCellStyle = dataGridViewCellStyle17;
            this.grvImages.GridColor = System.Drawing.Color.Silver;
            this.grvImages.Location = new System.Drawing.Point(47, 201);
            this.grvImages.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grvImages.Name = "grvImages";
            this.grvImages.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grvImages.Size = new System.Drawing.Size(930, 68);
            this.grvImages.TabIndex = 36;
            this.grvImages.SelectionChanged += new System.EventHandler(this.grvImages_SelectionChanged);
            // 
            // ImgPath
            // 
            this.ImgPath.FillWeight = 120F;
            this.ImgPath.HeaderText = "Path";
            this.ImgPath.MaxInputLength = 0;
            this.ImgPath.Name = "ImgPath";
            this.ImgPath.Width = 575;
            // 
            // ImgId
            // 
            this.ImgId.FillWeight = 140F;
            this.ImgId.HeaderText = "Image ID";
            this.ImgId.MaxInputLength = 15;
            this.ImgId.Name = "ImgId";
            this.ImgId.Width = 153;
            // 
            // ImgType
            // 
            this.ImgType.HeaderText = "Type";
            this.ImgType.Name = "ImgType";
            this.ImgType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ImgType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ImgType.Width = 154;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(43, 177);
            this.label20.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 19);
            this.label20.TabIndex = 35;
            this.label20.Text = "Image File";
            // 
            // gImgGenerateScales
            // 
            this.gImgGenerateScales.Controls.Add(this.btnImgDeleteScales);
            this.gImgGenerateScales.Controls.Add(this.label23);
            this.gImgGenerateScales.Controls.Add(this.btnImgGenerateScales);
            this.gImgGenerateScales.Controls.Add(this.txtImgNScales);
            this.gImgGenerateScales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gImgGenerateScales.Location = new System.Drawing.Point(784, 41);
            this.gImgGenerateScales.Name = "gImgGenerateScales";
            this.gImgGenerateScales.Size = new System.Drawing.Size(288, 115);
            this.gImgGenerateScales.TabIndex = 4;
            this.gImgGenerateScales.TabStop = false;
            this.gImgGenerateScales.Text = "Generate scales automatically";
            // 
            // btnImgDeleteScales
            // 
            this.btnImgDeleteScales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImgDeleteScales.Location = new System.Drawing.Point(151, 64);
            this.btnImgDeleteScales.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnImgDeleteScales.Name = "btnImgDeleteScales";
            this.btnImgDeleteScales.Size = new System.Drawing.Size(124, 37);
            this.btnImgDeleteScales.TabIndex = 2;
            this.btnImgDeleteScales.Text = "Delete scales";
            this.btnImgDeleteScales.UseVisualStyleBackColor = true;
            this.btnImgDeleteScales.Click += new System.EventHandler(this.btnImgDeleteScales_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(8, 31);
            this.label23.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(114, 19);
            this.label23.TabIndex = 20;
            this.label23.Text = "Generate scales:";
            // 
            // btnImgGenerateScales
            // 
            this.btnImgGenerateScales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImgGenerateScales.Location = new System.Drawing.Point(12, 64);
            this.btnImgGenerateScales.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnImgGenerateScales.Name = "btnImgGenerateScales";
            this.btnImgGenerateScales.Size = new System.Drawing.Size(124, 37);
            this.btnImgGenerateScales.TabIndex = 1;
            this.btnImgGenerateScales.Text = "Generate scales";
            this.btnImgGenerateScales.UseVisualStyleBackColor = true;
            this.btnImgGenerateScales.Click += new System.EventHandler(this.btnImgGenerateScales_Click);
            // 
            // txtImgNScales
            // 
            this.txtImgNScales.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImgNScales.Location = new System.Drawing.Point(127, 31);
            this.txtImgNScales.MaxLength = 5;
            this.txtImgNScales.Name = "txtImgNScales";
            this.txtImgNScales.Size = new System.Drawing.Size(103, 22);
            this.txtImgNScales.TabIndex = 0;
            this.txtImgNScales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImgNScales.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtImgNScales_KeyUp);
            // 
            // lblImScales
            // 
            this.lblImScales.AutoSize = true;
            this.lblImScales.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImScales.Location = new System.Drawing.Point(18, 16);
            this.lblImScales.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblImScales.Name = "lblImScales";
            this.lblImScales.Size = new System.Drawing.Size(49, 19);
            this.lblImScales.TabIndex = 18;
            this.lblImScales.Text = "Scales";
            // 
            // grvImageScales
            // 
            this.grvImageScales.AllowUserToResizeColumns = false;
            this.grvImageScales.BackgroundColor = System.Drawing.Color.LightGray;
            this.grvImageScales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvImageScales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.grvImageScales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvImageScales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImgMasterAddress,
            this.ImgGroup,
            this.ImgIpAddress,
            this.ImgReceptionPortRx,
            this.ImgModel,
            this.ImgDisplaySize});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvImageScales.DefaultCellStyle = dataGridViewCellStyle20;
            this.grvImageScales.GridColor = System.Drawing.Color.Silver;
            this.grvImageScales.Location = new System.Drawing.Point(22, 38);
            this.grvImageScales.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grvImageScales.Name = "grvImageScales";
            this.grvImageScales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grvImageScales.Size = new System.Drawing.Size(715, 116);
            this.grvImageScales.TabIndex = 0;
            // 
            // ImgMasterAddress
            // 
            this.ImgMasterAddress.FillWeight = 120F;
            this.ImgMasterAddress.HeaderText = "MasterAddress";
            this.ImgMasterAddress.MaxInputLength = 2;
            this.ImgMasterAddress.Name = "ImgMasterAddress";
            this.ImgMasterAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ImgMasterAddress.Width = 120;
            // 
            // ImgGroup
            // 
            this.ImgGroup.FillWeight = 70F;
            this.ImgGroup.HeaderText = "Group";
            this.ImgGroup.MaxInputLength = 2;
            this.ImgGroup.Name = "ImgGroup";
            this.ImgGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ImgGroup.Width = 70;
            // 
            // ImgIpAddress
            // 
            dataGridViewCellStyle19.NullValue = null;
            this.ImgIpAddress.DefaultCellStyle = dataGridViewCellStyle19;
            this.ImgIpAddress.FillWeight = 140F;
            this.ImgIpAddress.HeaderText = "IpAddress";
            this.ImgIpAddress.MaxInputLength = 15;
            this.ImgIpAddress.Name = "ImgIpAddress";
            this.ImgIpAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ImgIpAddress.Width = 140;
            // 
            // ImgReceptionPortRx
            // 
            this.ImgReceptionPortRx.FillWeight = 140F;
            this.ImgReceptionPortRx.HeaderText = "ReceptionPortRx";
            this.ImgReceptionPortRx.MaxInputLength = 5;
            this.ImgReceptionPortRx.Name = "ImgReceptionPortRx";
            this.ImgReceptionPortRx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ImgReceptionPortRx.Width = 140;
            // 
            // ImgModel
            // 
            this.ImgModel.HeaderText = "Model";
            this.ImgModel.Name = "ImgModel";
            this.ImgModel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ImgDisplaySize
            // 
            this.ImgDisplaySize.HeaderText = "DisplaySize";
            this.ImgDisplaySize.Name = "ImgDisplaySize";
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1203, 647);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Import";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(272, 514);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 117);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import Items using FILES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Used: dibalscopItems2.txt  and dibalscopScales.ini files";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(69, 27);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "DataSend2";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(913, 503);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 38);
            this.label2.TabIndex = 35;
            this.label2.Text = "Stopped";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(617, 514);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 117);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Import Data using REGISTERS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Used: Scales and Registers grid";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PowderBlue;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(28, 27);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 47);
            this.button2.TabIndex = 0;
            this.button2.Text = "RegistersSend";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridView1.Location = new System.Drawing.Point(920, 544);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.Size = new System.Drawing.Size(243, 87);
            this.dataGridView1.TabIndex = 33;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IpAddress";
            this.dataGridViewTextBoxColumn1.HeaderText = "IP Address";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Result";
            this.dataGridViewTextBoxColumn2.FillWeight = 70F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Result";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.dataGridView3);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dataGridView4);
            this.groupBox3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(11, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1168, 495);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "EDIT DATA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 324);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 35;
            this.label4.Text = "Registers";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridView2.Location = new System.Drawing.Point(22, 346);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(872, 132);
            this.dataGridView2.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Register";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 828;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1046, 376);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(113, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1046, 342);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(113, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(935, 380);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 19);
            this.label5.TabIndex = 28;
            this.label5.Text = "Close Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(935, 346);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 19);
            this.label6.TabIndex = 27;
            this.label6.Text = "Show Window:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(657, 39);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(288, 115);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Generate scales automatically";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(151, 64);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 37);
            this.button3.TabIndex = 2;
            this.button3.Text = "Delete scales";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 19);
            this.label7.TabIndex = 20;
            this.label7.Text = "Generate scales:";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(12, 64);
            this.button4.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 37);
            this.button4.TabIndex = 1;
            this.button4.Text = "Generate scales";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(127, 31);
            this.textBox1.MaxLength = 5;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(103, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(657, 190);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(288, 121);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Generate items automatically";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(151, 68);
            this.button5.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 37);
            this.button5.TabIndex = 2;
            this.button5.Text = "Delete  items";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 33);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 19);
            this.label8.TabIndex = 3;
            this.label8.Text = "Generate Items:";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(12, 68);
            this.button6.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(124, 37);
            this.button6.TabIndex = 1;
            this.button6.Text = "Generate items";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(129, 31);
            this.textBox2.MaxLength = 5;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(103, 22);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 156);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 19);
            this.label9.TabIndex = 24;
            this.label9.Text = "Items";
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView3.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView3.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridView3.Location = new System.Drawing.Point(22, 179);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView3.Size = new System.Drawing.Size(573, 142);
            this.dataGridView3.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Code";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "DirectKey";
            this.dataGridViewTextBoxColumn5.MaxInputLength = 3;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "Type";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Name";
            this.dataGridViewTextBoxColumn6.MaxInputLength = 36;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 170;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Price";
            this.dataGridViewTextBoxColumn7.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 16);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 19);
            this.label10.TabIndex = 18;
            this.label10.Text = "Scales";
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToResizeColumns = false;
            this.dataGridView4.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView4.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewComboBoxColumn2});
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView4.DefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridView4.GridColor = System.Drawing.Color.Silver;
            this.dataGridView4.Location = new System.Drawing.Point(22, 38);
            this.dataGridView4.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView4.Size = new System.Drawing.Size(617, 116);
            this.dataGridView4.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 120F;
            this.dataGridViewTextBoxColumn8.HeaderText = "MasterAddress";
            this.dataGridViewTextBoxColumn8.MaxInputLength = 2;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewCellStyle25.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewTextBoxColumn9.FillWeight = 70F;
            this.dataGridViewTextBoxColumn9.HeaderText = "Group";
            this.dataGridViewTextBoxColumn9.MaxInputLength = 2;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.FillWeight = 140F;
            this.dataGridViewTextBoxColumn10.HeaderText = "IpAddress";
            this.dataGridViewTextBoxColumn10.MaxInputLength = 15;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 140;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.FillWeight = 140F;
            this.dataGridViewTextBoxColumn11.HeaderText = "ReceptionPortRx";
            this.dataGridViewTextBoxColumn11.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 140;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.HeaderText = "Model";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.button7);
            this.groupBox6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(11, 514);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(251, 117);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Import Items using PARAMETERS";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(29, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(172, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Used: Scales and Items grid";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.PowderBlue;
            this.button7.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(28, 27);
            this.button7.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(197, 47);
            this.button7.TabIndex = 0;
            this.button7.Text = "ItemsSend2";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.dataGridView5);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.dataGridView7);
            this.tabPage2.Controls.Add(this.groupBox9);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1203, 647);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Export";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView5
            // 
            this.dataGridView5.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView5.DefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridView5.Location = new System.Drawing.Point(743, 298);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.Size = new System.Drawing.Size(342, 131);
            this.dataGridView5.TabIndex = 50;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "IpAddress";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridViewTextBoxColumn13.HeaderText = "Result";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 198;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(652, 393);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 49;
            this.label12.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(643, 334);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 27);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(485, 393);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "Received Registers:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox3);
            this.groupBox7.Controls.Add(this.textBox4);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.dataGridView6);
            this.groupBox7.Controls.Add(this.textBox5);
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Location = new System.Drawing.Point(8, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1077, 279);
            this.groupBox7.TabIndex = 44;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Add Data";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(187, 242);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(606, 22);
            this.textBox3.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(187, 210);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(606, 22);
            this.textBox4.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(38, 246);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 46;
            this.label14.Text = "Logs file:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 214);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 45;
            this.label15.Text = "Registers file path:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(22, 18);
            this.label16.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 19);
            this.label16.TabIndex = 20;
            this.label16.Text = "Add Scales";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(38, 184);
            this.label17.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 19);
            this.label17.TabIndex = 43;
            this.label17.Text = "PC IpAddress:";
            // 
            // dataGridView6
            // 
            this.dataGridView6.AllowUserToResizeColumns = false;
            this.dataGridView6.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView6.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView6.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17});
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView6.DefaultCellStyle = dataGridViewCellStyle30;
            this.dataGridView6.GridColor = System.Drawing.Color.Silver;
            this.dataGridView6.Location = new System.Drawing.Point(26, 40);
            this.dataGridView6.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView6.Size = new System.Drawing.Size(659, 123);
            this.dataGridView6.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.FillWeight = 150F;
            this.dataGridViewTextBoxColumn14.HeaderText = "MasterAddress";
            this.dataGridViewTextBoxColumn14.MaxInputLength = 2;
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 150;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.FillWeight = 160F;
            this.dataGridViewTextBoxColumn15.HeaderText = "IpAddress";
            this.dataGridViewTextBoxColumn15.MaxInputLength = 15;
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.Width = 165;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.FillWeight = 150F;
            this.dataGridViewTextBoxColumn16.HeaderText = "ReceptionPortRx";
            this.dataGridViewTextBoxColumn16.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 150;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "SendPortTx";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Width = 150;
            // 
            // textBox5
            // 
            this.textBox5.AcceptsTab = true;
            this.textBox5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(187, 182);
            this.textBox5.MaxLength = 15;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(131, 22);
            this.textBox5.TabIndex = 1;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button8);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Controls.Add(this.button9);
            this.groupBox8.Controls.Add(this.textBox6);
            this.groupBox8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(725, 31);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(309, 132);
            this.groupBox8.TabIndex = 41;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Generate scales automatically";
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(173, 74);
            this.button8.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(124, 37);
            this.button8.TabIndex = 2;
            this.button8.Text = "Delete scales";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(13, 36);
            this.label18.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 19);
            this.label18.TabIndex = 20;
            this.label18.Text = "Generate scales:";
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(17, 74);
            this.button9.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(124, 37);
            this.button9.TabIndex = 1;
            this.button9.Text = "Generate scales";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.AcceptsTab = true;
            this.textBox6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(132, 34);
            this.textBox6.MaxLength = 5;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(103, 22);
            this.textBox6.TabIndex = 0;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Blue;
            this.label19.Location = new System.Drawing.Point(482, 328);
            this.label19.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(122, 38);
            this.label19.TabIndex = 40;
            this.label19.Text = "Stopped";
            // 
            // dataGridView7
            // 
            this.dataGridView7.BackgroundColor = System.Drawing.Color.LightGray;
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20});
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView7.DefaultCellStyle = dataGridViewCellStyle32;
            this.dataGridView7.Location = new System.Drawing.Point(9, 440);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.Size = new System.Drawing.Size(1182, 190);
            this.dataGridView7.TabIndex = 36;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn18.HeaderText = "NumRegister";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn18.Width = 90;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "IpAddress";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // dataGridViewTextBoxColumn20
            // 
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn20.DefaultCellStyle = dataGridViewCellStyle31;
            this.dataGridViewTextBoxColumn20.HeaderText = "Register";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.Width = 945;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.button10);
            this.groupBox9.Controls.Add(this.button11);
            this.groupBox9.Controls.Add(this.button12);
            this.groupBox9.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(8, 287);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(435, 143);
            this.groupBox9.TabIndex = 21;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Export";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.PowderBlue;
            this.button10.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(28, 83);
            this.button10.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(188, 47);
            this.button10.TabIndex = 1;
            this.button10.TabStop = false;
            this.button10.Text = "Start and End";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.PowderBlue;
            this.button11.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(249, 56);
            this.button11.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(163, 47);
            this.button11.TabIndex = 2;
            this.button11.Text = "Cancel";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.PowderBlue;
            this.button12.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(28, 27);
            this.button12.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(188, 47);
            this.button12.TabIndex = 0;
            this.button12.Text = "Start Continuous";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // picDown
            // 
            this.picDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picDown.BackgroundImage = global::DibalscopDemo.Properties.Resources.INFERIOR_02;
            this.picDown.Controls.Add(this.lblInfo);
            this.picDown.Location = new System.Drawing.Point(0, 719);
            this.picDown.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.picDown.Name = "picDown";
            this.picDown.Size = new System.Drawing.Size(1211, 71);
            this.picDown.TabIndex = 2;
            this.picDown.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Black;
            this.lblInfo.Location = new System.Drawing.Point(1031, 3);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(123, 55);
            this.lblInfo.TabIndex = 26;
            this.lblInfo.Text = "Dibal.SA,\r\nAstintze Kalea, nº 24\r\n48160 Derio(Vizcaya)\r\nTlf:(+34)944521510";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picUp
            // 
            this.picUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picUp.BackgroundImage = global::DibalscopDemo.Properties.Resources.Azul_pie;
            this.picUp.Controls.Add(this.lblDibalSDK);
            this.picUp.Controls.Add(this.lblDibaldll);
            this.picUp.Location = new System.Drawing.Point(-4, -3);
            this.picUp.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.picUp.Name = "picUp";
            this.picUp.Size = new System.Drawing.Size(1211, 45);
            this.picUp.TabIndex = 1;
            this.picUp.TabStop = false;
            // 
            // lblDibalSDK
            // 
            this.lblDibalSDK.AutoSize = true;
            this.lblDibalSDK.BackColor = System.Drawing.Color.Transparent;
            this.lblDibalSDK.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDibalSDK.ForeColor = System.Drawing.Color.Black;
            this.lblDibalSDK.Location = new System.Drawing.Point(14, 9);
            this.lblDibalSDK.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDibalSDK.Name = "lblDibalSDK";
            this.lblDibalSDK.Size = new System.Drawing.Size(168, 23);
            this.lblDibalSDK.TabIndex = 33;
            this.lblDibalSDK.Text = "DibalSDK v1.0.1.10";
            this.lblDibalSDK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDibaldll
            // 
            this.lblDibaldll.AutoSize = true;
            this.lblDibaldll.BackColor = System.Drawing.Color.Transparent;
            this.lblDibaldll.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDibaldll.ForeColor = System.Drawing.Color.Black;
            this.lblDibaldll.Location = new System.Drawing.Point(956, 11);
            this.lblDibaldll.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDibaldll.Name = "lblDibaldll";
            this.lblDibaldll.Size = new System.Drawing.Size(182, 23);
            this.lblDibaldll.TabIndex = 24;
            this.lblDibaldll.Text = "Dibalscop.dll v1.0.1.9";
            this.lblDibaldll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1211, 749);
            this.Controls.Add(this.tabCom);
            this.Controls.Add(this.picDown);
            this.Controls.Add(this.picUp);
            this.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DibalscopDemo ";
            this.tabCom.ResumeLayout(false);
            this.tapPageImport.ResumeLayout(false);
            this.tapPageImport.PerformLayout();
            this.gImportFiles.ResumeLayout(false);
            this.gImportFiles.PerformLayout();
            this.gRegistersSend.ResumeLayout(false);
            this.gRegistersSend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvResult)).EndInit();
            this.gAddData.ResumeLayout(false);
            this.gAddData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvRegisters)).EndInit();
            this.gGenerateScales.ResumeLayout(false);
            this.gGenerateScales.PerformLayout();
            this.gGenerateArticles.ResumeLayout(false);
            this.gGenerateArticles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvScales)).EndInit();
            this.gImportParameters.ResumeLayout(false);
            this.gImportParameters.PerformLayout();
            this.tabPageExport.ResumeLayout(false);
            this.tabPageExport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvExResult)).EndInit();
            this.gExAddData.ResumeLayout(false);
            this.gExAddData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvExportScales)).EndInit();
            this.gExGenerateScales.ResumeLayout(false);
            this.gExGenerateScales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvExRegisters)).EndInit();
            this.gExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctExporting)).EndInit();
            this.tabPageImage.ResumeLayout(false);
            this.tabPageImage.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvImageResult)).EndInit();
            this.gImages.ResumeLayout(false);
            this.gImages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvImageFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvImages)).EndInit();
            this.gImgGenerateScales.ResumeLayout(false);
            this.gImgGenerateScales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvImageScales)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDown)).EndInit();
            this.picDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picUp)).EndInit();
            this.picUp.ResumeLayout(false);
            this.picUp.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picUp;
		private System.Windows.Forms.PictureBox picDown;
		private Label lblDibaldll;
		private Label lblInfo;
		private TabControl tabCom;
		private TabPage tapPageImport;
		private GroupBox gAddData;
		private Label lblAddRegisters;
		private DataGridView grvRegisters;
		private DataGridViewTextBoxColumn Register;
		private ComboBox cboCloseTime;
		private GroupBox gRegistersSend;
		private Button btnRegistersSend;
		private ComboBox cboShowWindow;
		private Label lblCloseTime;
		private Label lblShowWindow;
		private GroupBox gGenerateScales;
		private Button btnDeleteScalesGrid;
		private Label lblNumScales;
		private Button btnGenerateScales;
		private TextBox txtNScales;
		private GroupBox gGenerateArticles;
		private Button btnDeleteArticlesGrid;
		private Label lblNumItems;
		private Button btnGenerateAticles;
		private TextBox txtNArticles;
		private Label lblAddArticles;
        private DataGridView grvItems;
		private GroupBox gImportParameters;
		private Button btnItemsSend;
		private Label lblAddScales;
		private DataGridView grvScales;
		private GroupBox gImportFiles;
		private Button btnDataSend;
		private Label lblStatus;
		private DataGridView grvResult;
		private DataGridViewTextBoxColumn RIpAddress;
		private DataGridViewTextBoxColumn Result;
		private Label lblInfo2;
		private Label lblInfo3;
		private Label lblInfo1;
		private TabPage tabPageExport;
		private Label lblExIpPc;
		private TextBox txtExIpPc;
		private GroupBox gExGenerateScales;
		private Button btnExDeleteScales;
		private Label lblExGenerateScales;
		private Button btnExGenerateScales;
		private TextBox txtExNScales;
		private Label lblExportStatus;
		private DataGridView grvExRegisters;
		private GroupBox gExport;
		private Button btnStartExportContinuous;
		private Label lblAddScalesEx;
        private DataGridView grvExportScales;
		private GroupBox gExAddData;
		private Button btnCancelExport;
		private Label lblRRegisters;
		private PictureBox pctExporting;
		private Label lblNRegisters;
		private TextBox txtLogsFilePath;
		private TextBox txtExportFilePath;
		private Label lblExportLogPath;
		private Label lblExportFilePath;
        private DataGridView grvExResult;
		private Button btnStartExportFin;
		private DataGridViewTextBoxColumn IpAddressResult;
        private DataGridViewTextBoxColumn ExResult;
        private Label lblDibalSDK;
        private TabPage tabPageImage;
        private TabPage tabPage1;
        private GroupBox groupBox1;
        private Label label1;
        private Button button1;
        private Label label2;
        private GroupBox groupBox2;
        private Label label3;
        private Button button2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private GroupBox groupBox3;
        private Label label4;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label5;
        private Label label6;
        private GroupBox groupBox4;
        private Button button3;
        private Label label7;
        private Button button4;
        private TextBox textBox1;
        private GroupBox groupBox5;
        private Button button5;
        private Label label8;
        private Button button6;
        private TextBox textBox2;
        private Label label9;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private Label label10;
        private DataGridView dataGridView4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private GroupBox groupBox6;
        private Label label11;
        private Button button7;
        private TabPage tabPage2;
        private DataGridView dataGridView5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private Label label12;
        private PictureBox pictureBox1;
        private Label label13;
        private GroupBox groupBox7;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private DataGridView dataGridView6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private TextBox textBox5;
        private GroupBox groupBox8;
        private Button button8;
        private Label label18;
        private Button button9;
        private TextBox textBox6;
        private Label label19;
        private DataGridView dataGridView7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private GroupBox groupBox9;
        private Button button10;
        private Button button11;
        private Button button12;
        private GroupBox gImages;
        private Label label20;
        private GroupBox gImgGenerateScales;
        private Button btnImgDeleteScales;
        private Label label23;
        private Button btnImgGenerateScales;
        private TextBox txtImgNScales;
        private Label lblImScales;
        private DataGridView grvImageScales;        
        private GroupBox groupBox12;
        private Label label25;
        private Button btnImageSend;
        private GroupBox groupBox13;
        private Label label27;
        private Button btnImageFileGenerator;
        private Label lblImageStatus;
        private DataGridView grvImageResult;
        private SaveFileDialog sfd1;
        private DataGridView grvImages;
        private DataGridViewTextBoxColumn ImgPath;
        private DataGridViewTextBoxColumn ImgId;
        private DataGridViewComboBoxColumn ImgType;
        private RadioButton rdbConcatenate;
        private RadioButton rdbReplace;
        private Label label21;
        private DataGridView grvImageFolder;
        private CheckBox chkImageFolder;
        private CheckBox chkImageFile;
        private DataGridViewTextBoxColumn ImgPathFolder;
        private DataGridViewComboBoxColumn ImgTypeFolder;
        private DataGridViewTextBoxColumn NumRegister;
        private DataGridViewTextBoxColumn ScaleIpAddress;
        private DataGridViewTextBoxColumn ScaleRegister;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn DirectKey;
        private DataGridViewComboBoxColumn Type;
        private DataGridViewTextBoxColumn itemName;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn MasterAddress;
        private DataGridViewTextBoxColumn Group;
        private DataGridViewTextBoxColumn IpAddress;
        private DataGridViewTextBoxColumn ReceptionPortRx;
        private DataGridViewComboBoxColumn Model;
        private DataGridViewTextBoxColumn ExMasterAddress;
        private DataGridViewTextBoxColumn ExIpAddress;
        private DataGridViewTextBoxColumn ExReceptionPortRx;
        private DataGridViewTextBoxColumn ExSendPortTx;
        private DataGridViewTextBoxColumn ImgMasterAddress;
        private DataGridViewTextBoxColumn ImgGroup;
        private DataGridViewTextBoxColumn ImgIpAddress;
        private DataGridViewTextBoxColumn ImgReceptionPortRx;
        private DataGridViewComboBoxColumn ImgModel;
        private DataGridViewComboBoxColumn ImgDisplaySize;
    }
}

