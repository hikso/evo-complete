using EVO_PV;
using EVO_PV.Utilities;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Input;
using EVO_PV.Models.BusinessObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using EVO_PV.Services;
using System.Threading.Tasks;
using EVO_PV.Resources.Dictionaries;
using Notifications.Wpf;
using System.Linq;

namespace EVO_PV.ViewModels
{
    public class VMModalEvidenceForm : NotifyPropertyChanged
    {

        public ICommand BrowseEvidenceFilesCommand { get; }
        public ICommand SendEvidenceFilesCommand { get; }
        private ObservableCollection<BOInconsistenceFile> articuloDocumentos { get; set; }
        public BOArticleReceive ArticleSelected { get; set; }
        private InconsistenciesService inconsistenciesService;
        private Task inconsistenciesTask;
        private string observation { get; set; }
        public bool spinnerIsLoading { get; set; }
        public bool spinnerIsNotLoading { get; set; }
        private BODeliveryReceiveHeader deliveryReceiveHeader { get; set; }
        private Notification notification;
        private string message { get; set; }
        public bool isAnyDocumentAttached { get; set; }
        MainWindow PrincipalScreen;

        public bool IsAnyDocumentAttached
        {
            get { return this.isAnyDocumentAttached; }
            set
            {
                this.isAnyDocumentAttached = value;
                this.OnPropertyChanged("IsAnyDocumentAttached");
            }
        }

        public string Message
        {
            get { return this.message; }
            set
            {
                this.message = value;
                this.OnPropertyChanged("Message");
            }
        }
        public ObservableCollection<BOInconsistenceFile> ArticuloDocumentos
        {
            get
            {
                return this.articuloDocumentos;
            }
            set
            {
                this.articuloDocumentos = value;
                this.OnPropertyChanged("ArticuloDocumentos");
            }
        }

        public string Observation
        {
            get
            {
                return this.observation;
            }
            set
            {
                this.observation = value;
                this.OnPropertyChanged("Observation");
            }
        }

        public bool SpinnerIsNotLoading
        {
            get
            {
                return this.spinnerIsNotLoading;
            }
            set
            {
                this.spinnerIsNotLoading = value;
                this.OnPropertyChanged("SpinnerIsNotLoading");
            }
        }

        public bool SpinnerIsLoading
        {
            get
            {
                return this.spinnerIsLoading;
            }
            set
            {
                this.spinnerIsLoading = value;
                this.OnPropertyChanged("SpinnerIsLoading");
            }
        }

        public BODeliveryReceiveHeader DeliveryReceiveHeader
        {
            get
            {
                return this.deliveryReceiveHeader;
            }
            set
            {
                this.deliveryReceiveHeader = value;
                this.OnPropertyChanged("DeliveryReceiveHeader");
            }
        }


        #region Constructores
        public VMModalEvidenceForm(MainWindow principalScreen, BOArticleReceive bOArticleReceive, BODeliveryReceiveHeader bODeliveryReceiveHeader)
        {
            this.BrowseEvidenceFilesCommand = new RelayCommand(BrowseEvidenceFiles);
            this.SendEvidenceFilesCommand = new RelayCommand(SendEvidenceFiles);
            this.ArticleSelected = bOArticleReceive;
            this.DeliveryReceiveHeader = bODeliveryReceiveHeader;

            this.Message = "Se han generado los siguientes documentos: ";
            int i = 1;
            DeliveryReceiveHeader.Documents.ForEach(item =>
            {
                if (DeliveryReceiveHeader.Documents.First() == item)
                {
                    this.Message += i.ToString() + ". '" + item.FileName + "'";
                    i++;
                }
                else
                {
                    this.Message += ", " + i.ToString() + ". '" + item.FileName + "'";
                    i++;
                }
            });
            if (this.Message == "")
            {
                this.Message = "No se han generado documentos";
            }

            this.PrincipalScreen = principalScreen;
            this.inconsistenciesService = new InconsistenciesService();
            this.SpinnerIsLoading = false;
            this.SpinnerIsNotLoading = true;
        }
        #endregion
        
        public void SendEvidenceFiles()
        {
            BOInconsistenceNew bOInconsistenceNew = new BOInconsistenceNew();
            bOInconsistenceNew.ArticleWeighingId = int.Parse(this.DeliveryReceiveHeader.DeliveryReceiveId);
            bOInconsistenceNew.Observation = observation;
            bOInconsistenceNew.Details = new List<BOInconsistenceFile>(ArticuloDocumentos);
            this.SpinnerIsLoading = true;
            this.SpinnerIsNotLoading = false;
            this.inconsistenciesTask = this.SendInconsistenceAsync(bOInconsistenceNew);
        }

        /// <summary>
        /// Método que obtiene las entregas de forma asíncrona
        /// </summary>  
        private async Task SendInconsistenceAsync(BOInconsistenceNew bOInconsistenceNew)
        {
            string response = await this.inconsistenciesService.SendInconsistence(bOInconsistenceNew);
            this.SpinnerIsLoading = false;
            this.SpinnerIsNotLoading = true;
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
            this.PrincipalScreen.notification.Show(DictMessages.Information, "Las incidencias han sido enviadas con éxito.", NotificationType.Information);
        }

        void BrowseEvidenceFiles()
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.Multiselect = true;

            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                this.ArticuloDocumentos = new ObservableCollection<BOInconsistenceFile>();
                foreach (var file in openFileDlg.FileNames)
                {
                    BOInconsistenceFile bOInconsistenceFile = new BOInconsistenceFile();
                    Byte[] bytes = File.ReadAllBytes(file);
                    bOInconsistenceFile.Base64Code = Convert.ToBase64String(bytes);
                    bOInconsistenceFile.FileName = Path.GetFileName(file);
                    bOInconsistenceFile.FileExtension = Path.GetExtension(file).Replace(".", "");
                    this.ArticuloDocumentos.Add(bOInconsistenceFile);
                }
                this.isAnyDocumentAttached = true;
            }
            else
            {
                this.isAnyDocumentAttached = false;
            }
        }
    }
}
