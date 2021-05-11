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
using EVO_PV.Interfaces;
using EVO_PV.Enums;
using EVO_PV.Views;

namespace EVO_PV.ViewModels
{
    public class VMModalBoxSetting : NotifyPropertyChanged, IConfirmationModal
    {

        public ICommand BrowseEvidenceFilesCommand { get; }
        public ICommand SendEvidenceFilesCommand { get; }
        public ICommand UpdateRealValueCommand { get; }
        public ICommand SendBoxSettingCommand { get; }

        public ICommand CancelCommand { get; }
        private ObservableCollection<BOInconsistenceFile> articuloDocumentos { get; set; }
        public BOArticleReceive ArticleSelected { get; set; }
        private InconsistenciesService inconsistenciesService;
        private Task inconsistenciesTask;
        private string observation { get; set; }
        public bool spinnerIsLoading { get; set; }
        public bool spinnerIsNotLoading { get; set; }
        private BOBoxSetting boxSettingHeader { get; set; }
        private BOUser user { get; set; }
        private Notification notification;
        private EnumNamesMethods enumNameMethodYes { get; set; }
        private EnumNamesMethods enumNameMethodNot { get; set; }
        UCModalConfirmation UCModalConfirmation;
        UCCustomMessages UCCustomMessages;

        /// <summary>
        /// Propiedades del contrato de IConfirmationModal
        /// </summary>
        /// 
        public EnumNamesMethods EnumNameMethodYes
        {
            get { return this.enumNameMethodYes; }
        }

        public EnumNamesMethods EnumNameMethodNot
        {
            get { return this.enumNameMethodNot; }
        }

        private string messageConfirmation { get; set; }
        private string iconName { get; set; }
        private string foreground { get; set; }
        private bool showSpinner { get; set; }
        public string MessageConfirmation
        {
            get { return this.messageConfirmation; }
        }

        public string IconName
        {
            get { return this.iconName; }
        }

        public string Foreground
        {
            get { return this.foreground; }
        }

        BoxSettingService boxSettingService;
        UserService userService;
        private Task getBoxSettingHeader;
        private Nullable<bool> isMin;
        MainWindow PrincipalScreen;
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

        public BOBoxSetting BoxSettingHeader
        {
            get
            {
                return this.boxSettingHeader;
            }
            set
            {
                this.boxSettingHeader = value;
                this.OnPropertyChanged("BoxSettingHeader");
            }
        }

        public BOUser User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
                this.OnPropertyChanged("User");
            }
        }
        public Nullable<bool> IsMin
        {
            get
            {
                return this.isMin;
            }
            set
            {
                this.isMin = value;
                this.OnPropertyChanged("IsMin");
            }
        }

        #region Constructores
        public VMModalBoxSetting(MainWindow principalScreen)
        {
            this.SendEvidenceFilesCommand = new RelayCommand(SendEvidenceFiles);
            this.inconsistenciesService = new InconsistenciesService();
            this.SpinnerIsLoading = false;
            this.SpinnerIsNotLoading = true;
            this.boxSettingService = new BoxSettingService();
            this.userService = new UserService();
            this.notification = new Notification();
            this.PrincipalScreen = principalScreen;
            this.GetUser();
            this.getBoxSettingHeader = GetBoxSettingHeaderAsync();
            this.UpdateRealValueCommand = new RelayCommand(UpdateRealValue);
            this.SendBoxSettingCommand = new RelayCommand(SendBoxSetting);
            this.CancelCommand = new RelayCommand(Cancel);
        }
        #endregion

        public void UpdateRealValue()
        {
            this.BoxSettingHeader.Difference = this.BoxSettingHeader.RealValue-this.BoxSettingHeader.AsignedValue;
            this.IsMin = null;
            this.IsMin = this.BoxSettingHeader.Difference > 0;
            if (this.BoxSettingHeader.Difference == 0)
            {
                this.IsMin = null;
            }
            BoxSettingHeader.Difference = BoxSettingHeader.Difference;
            
        }
        
        public void SendBoxSetting()
        {
            string response = this.boxSettingService.SetBoxSetting(BoxSettingHeader);
            if (response == "")
            {
                this.ConfigureModalCustomMessage(
                    "Se ha realizado el cuadre de caja exitosamente.",
                    DictIcons.AlertCircle,
                    DictColors.Success,
                    true
                );
                //this.notification.Show(DictMessages.Information, "Se ha realizado el cuadre de caja exitosamente", NotificationType.Success);
            }
            else
            {
                this.ConfigureModalCustomMessage(
                    response,
                    DictIcons.Alert,
                    DictColors.Warning,
                    true
                );
                //this.notification.Show(DictMessages.Information, response, NotificationType.Error);
            }
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }

        private void ConfigureModalCustomMessage(string messageConfirmation, string iconName, string foreground, bool showSpinner)
        {
            this.messageConfirmation = messageConfirmation; //DictMessages
            this.iconName = iconName;//DictIcons
            this.foreground = foreground;//DictColors
            this.showSpinner = showSpinner;
            UCCustomMessages = new UCCustomMessages(this);
            this.PrincipalScreen.ModalContainerConfirmation.Content = UCCustomMessages;
            this.PrincipalScreen.ModalPrincipalConfirmation.IsOpen = true;
        }

        public void Cancel()
        {
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }
        public void SendEvidenceFiles()
        {

        }


        /// <summary>
        /// Método que obtiene las entregas de forma asíncrona
        /// </summary>  
        private async Task GetBoxSettingHeaderAsync()
        {
            BOBoxSetting bOBoxSetting = await this.boxSettingService.GetBoxSettingHeader();

            this.BoxSettingHeader = bOBoxSetting;
        }

        /// <summary>
        /// Método que obtiene las entregas de forma asíncrona
        /// </summary>  
        private void GetUser()
        {
            BOUser bOUser = this.userService.GetUser();

            this.User = bOUser;
        }

        public void ExecuteConfirmationYes()
        {
            string response = this.boxSettingService.SetBoxSetting(BoxSettingHeader);
            if (response != null)
            {
                this.notification.Show(DictMessages.Information, "Se ha realizado el cuadre de caja exitosamente", NotificationType.Success);
            }
            else
            {
                this.notification.Show(DictMessages.Information, DictMessages.ErrorAlAbrirCaja, NotificationType.Error);
            }
            this.PrincipalScreen.ModalPrincipalConfirmation.IsOpen = false;
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }

        public void ExecuteConfirmationNot()
        {
            this.PrincipalScreen.ModalPrincipalConfirmation.IsOpen = false;
        }
    }
}
