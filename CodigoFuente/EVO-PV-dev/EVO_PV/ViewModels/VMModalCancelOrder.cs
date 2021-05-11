using EVO_PV;
using EVO_PV.Interfaces;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Resources.Dictionaries;
using EVO_PV.Services;
using EVO_PV.Utilities;
using GalaSoft.MvvmLight.Command;
using Notifications.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    public class VMModalCancelOrder : NotifyPropertyChanged
    {
        #region Atributos

        public ICommand ConfirmationYesCommand { get; }
        public ICommand ConfirmationNotCommand { get; }

        private IConfirmationModal viewModel = null;
        private string iconName { get; set; }

        private string messageConfirmation;
        private string foreground { get; set; }
        private string reasonName { get; set; }
        private ObservableCollection<BOReason> reasons { get; set; }
        private BOReason reason { get; set; }
        /// <summary>
        /// Notificación de mensajes
        /// </summary>
        private Notification notification;
        private VMOrderListDetail VMOrderListDetail;
        #endregion

        #region Objetos de Servicios
        private OrderListService OrderListServices;
        #endregion

        #region Propiedades
        public string IconName
        {
            get { return iconName; }
            set
            {
                this.iconName = value;
                this.OnPropertyChanged("IconName");
            }
        }

        public string MessageConfirmation
        {
            get { return messageConfirmation; }
            set
            {
                this.messageConfirmation = value;
                this.OnPropertyChanged("MessageConfirmation");
            }
        }

        public string Foreground
        {
            get { return foreground; }
            set
            {
                this.foreground = value;
                this.OnPropertyChanged("Foreground");
            }
        }
        
        public ObservableCollection<BOReason> Reasons
        {
            get { return reasons; }
            set
            {
                this.reasons = value;
                this.OnPropertyChanged("Reasons");
            }
        }
        
        public BOReason Reason
        {
            get { return reason; }
            set
            {
                this.reason = value;
                this.OnPropertyChanged("Reason");
            }
        }
        
        public string ReasonName
        {
            get { return reasonName; }
            set
            {
                this.reasonName = value;
                this.Reason = this.Reasons.Where(d => d.ReasonName == this.ReasonName).FirstOrDefault();
                this.OnPropertyChanged("ReasonName");
            }
        }
        #endregion
        
        #region Tareas
        /// <summary>
        /// Task para llamar en el constructor métodos asyncronos
        /// </summary>
        private Task GetReasons;
        #endregion

        #region Contructores

        public VMModalCancelOrder(IConfirmationModal viewModel, VMOrderListDetail vMOrderListDetail)
        {
            this.viewModel = viewModel;
            this.VMOrderListDetail = vMOrderListDetail;
            this.ConfirmationYesCommand = new RelayCommand(ConfirmationYes);
            this.ConfirmationNotCommand = new RelayCommand(ConfirmationNot);
            this.IconName = viewModel.IconName;
            this.MessageConfirmation = viewModel.MessageConfirmation;
            this.Foreground = viewModel.Foreground;
            this.OrderListServices = new OrderListService();
            this.GetReasons = GetReasonsAsync();
            this.notification = new Notification();

        }

        #endregion

        #region Métodos
        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetReasonsAsync()
        {
            List<BOReason> listBOReason = await this.OrderListServices.GetReasons();
            this.Reasons = new ObservableCollection<BOReason>(listBOReason);
        }

        private void ConfirmationYes()
        {
            if (Reason == null)
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorDebeSeleccionarUnMotivo, NotificationType.Error);
                return;
            }
            VMOrderListDetail.CancelReason = Reason;
            viewModel.ExecuteConfirmationYes();
        }

        private void ConfirmationNot()
        {
            viewModel.ExecuteConfirmationNot();
        }

        #endregion
    }
}
