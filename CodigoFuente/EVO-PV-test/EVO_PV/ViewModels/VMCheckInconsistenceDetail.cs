using EVO_PV;
using EVO_PV.Enum;
using EVO_PV.Enums;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Services;
using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace EVO_PV.ViewModels
{
    public class VMCheckInconsistenceDetail : NotifyPropertyChanged
    {
        #region Constructor
        
        public VMCheckInconsistenceDetail(MainWindow principalScreen, int id, string requestNumber, string deliveryNumber)
        {
            this.PrincipalScreen = principalScreen;
            this.inconsistenciesService = new InconsistenciesService();
            this.CmdBack = new RelayCommand(Back);
            this.CmdViewFile = new RelayCommand(ViewFile);
            this.CmdCloseDialog = new RelayCommand(CloseDialog);
            this.id = id;
            this.requestNumber = requestNumber;
            this.deliveryNumber = deliveryNumber;
            this.GetInconsistence = this.GetInconsistenceDetailAsync();
            this.DialogOpen = false;
        }

        #endregion

        #region Task

        private Task GetInconsistence;

        #endregion
       
        #region Atributos privados

        private MainWindow PrincipalScreen;

        private InconsistenciesService inconsistenciesService;

        private int id;

        private string requestNumber;

        private string deliveryNumber;

        private BOInconsistenceDetail inconsistence { get; set; }

        private BOInconsistenceFile fileSelected { get; set; }

        public BitmapImage imgSource { get; set; }

        public bool dialogOpen { get; set; }

        #endregion


        #region Atributos públicos 

        public BOInconsistenceDetail Inconsistence
        {
            get { return inconsistence; }

            set
            {
                this.inconsistence = value;

                this.OnPropertyChanged("Inconsistence");
            }
        }

        public BOInconsistenceFile FileSelected
        {
            get { return fileSelected; }

            set
            {
                this.fileSelected = value;

                this.OnPropertyChanged("FileSelected");
            }
        }

        public BitmapImage ImgSource
        {
            get { return imgSource; }

            set
            {
                this.imgSource = value;

                this.OnPropertyChanged("ImgSource");
            }
        }

        public bool DialogOpen
        {
            get { return dialogOpen; }

            set
            {
                this.dialogOpen = value;

                this.OnPropertyChanged("DialogOpen");
            }
        }

        public string DeliveryNumber
        {
            get { return deliveryNumber; }

            set
            {
                this.deliveryNumber = value;

                this.OnPropertyChanged("DeliveryNumber");
            }
        }

        #endregion


        #region Comandos

        public ICommand CmdViewFile { get; }

        public ICommand CmdBack { get; }

        public ICommand CmdCloseDialog { get; }

        #endregion


        #region Métodos Privados

        private async Task GetInconsistenceDetailAsync()
        {
            BOInconsistenceDetail boInconsistenceDetail = await this.inconsistenciesService.GetInconsistenceById(this.id, requestNumber);
            this.Inconsistence = boInconsistenceDetail;
        }
 
        private void Back()
        {
            this.PrincipalScreen.ContentPage.Content = new UCCheckInconsistencies(this.PrincipalScreen);
        }

        private async void ViewFile()
        {
            string base64 = await this.inconsistenciesService.GetFile(this.Inconsistence.GUID, FileSelected.FileName, FileSelected.FileExtension);

            byte[] streamBase = Convert.FromBase64String(base64);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new System.IO.MemoryStream(streamBase);
            bi.EndInit();
            this.ImgSource = bi;
            this.DialogOpen = true;

        }

        private void CloseDialog()
        {
            this.ImgSource = null;
            this.DialogOpen = false;
        }

        #endregion

    }
}
