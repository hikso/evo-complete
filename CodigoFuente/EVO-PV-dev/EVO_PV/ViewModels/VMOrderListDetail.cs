
using EVO_PV;
using EVO_PV.Enums;
using EVO_PV.Interfaces;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Resources.Dictionaries;
using EVO_PV.Services;
using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    public class VMOrderListDetail : NotifyPropertyChanged, IConfirmationModal
    {
        #region Atributos privados
        private MainWindow PrincipalScreen;
        private int ID;
        private bool isCraftOrder;
        private bool isNotCraftOrder;
        private bool isAprovedtOrder;
        private bool isNotAprovedtOrder;
        private bool enableCancelOrder;
        private bool isOpenOrder;
        private bool isNotOpenOrder;
        private BOOrderListDetails orderListDetails { get; set; }
        private ObservableCollection<BOActions> actions { get; set; }
        private BOReason cancelReason { get; set; }
        private Notification notification;
        private bool isNotPurchaseOrder { get; set; }
        private bool isPurchaseOrder { get; set; }
        private bool notShowQuantityColumns { get; set; }

        /// <summary>
        /// atributos del contrato de IConfirmationModal
        /// </summary>
        private string messageConfirmation { get; set; }
        private string iconName { get; set; }
        private EnumNamesMethods enumNameMethodYes { get; set; }
        private EnumNamesMethods enumNameMethodNot { get; set; }
        private string foreground { get; set; }
        UCModalCancelOrder UCModalCancelOrder;

        private string widthForUserControl { get; set; }
        #endregion

        #region Atributos públicos
        /// <summary>
        /// Propiedades del contrato de IConfirmationModal
        /// </summary>
        public EnumNamesMethods EnumNameMethodYes
        {
            get { return this.enumNameMethodYes; }
        }

        public EnumNamesMethods EnumNameMethodNot
        {
            get { return this.enumNameMethodNot; }
        }

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

        public BOOrderListDetails OrderListDetails
        {
            get { return orderListDetails; }

            set
            {
                this.orderListDetails = value;
                IsCraftOrder = this.OrderListDetails.State == "Borrador";
                IsNotCraftOrder = this.OrderListDetails.State != "Borrador";
                IsAprovedtOrder = this.OrderListDetails.State == "Aprobación Parcial" || this.OrderListDetails.State == "Aprobación Completa";
                IsNotAprovedtOrder = this.OrderListDetails.State != "Aprobación Parcial" || this.OrderListDetails.State == "Aprobación Completa";
                IsOpenOrder = this.OrderListDetails.State == "Abierto";
                IsNotOpenOrder = this.OrderListDetails.State != "Abierto";
                this.OnPropertyChanged("OrderListDetails");
            }
        }

        public ObservableCollection<BOActions> Actions
        {
            get { return actions; }

            set
            {
                this.actions = value;
                this.OnPropertyChanged("Actions");
            }
        }

        public BOReason CancelReason
        {
            get { return cancelReason; }

            set
            {
                this.cancelReason = value;
                this.OnPropertyChanged("CancelReason");
            }
        }
        
        public bool IsCraftOrder
        {
            get { return isCraftOrder; }

            set
            {
                this.isCraftOrder = value;
                this.OnPropertyChanged("IsCraftOrder");
            }
        }
        
        public bool IsNotCraftOrder
        {
            get { return isNotCraftOrder; }

            set
            {
                this.isNotCraftOrder = value;
                NotShowQuantityColumns = IsPurchaseOrder && IsNotCraftOrder;
                this.OnPropertyChanged("IsNotCraftOrder");
            }
        }

        public bool IsAprovedtOrder
        {
            get { return isAprovedtOrder; }

            set
            {
                this.isAprovedtOrder = value;
                this.OnPropertyChanged("IsAprovedtOrder");
            }
        }

        public bool IsNotAprovedtOrder
        {
            get { return isNotAprovedtOrder; }

            set
            {
                this.isNotAprovedtOrder = value;
                this.OnPropertyChanged("IsNotAprovedtOrder");
            }
        }
        
        public bool EnableCancelOrder
        {
            get { return enableCancelOrder; }

            set
            {
                this.enableCancelOrder = value;
                this.OnPropertyChanged("EnableCancelOrder");
            }
        }
        
        public bool IsOpenOrder
        {
            get { return isOpenOrder; }

            set
            {
                this.isOpenOrder = value;
                this.OnPropertyChanged("IsOpenOrder");
            }
        }
        
        public bool IsNotOpenOrder
        {
            get { return isNotOpenOrder; }

            set
            {
                this.isNotOpenOrder = value;
                this.OnPropertyChanged("IsNotOpenOrder");
            }
        }

        public bool IsNotPurchaseOrder
        {
            get { return this.isNotPurchaseOrder; }
            set
            {
                this.isNotPurchaseOrder = value;
                NotShowQuantityColumns = IsNotPurchaseOrder && IsNotCraftOrder;
                this.OnPropertyChanged("IsNotPurchaseOrder");
            }
        }

        public bool IsPurchaseOrder
        {
            get { return this.isPurchaseOrder; }
            set
            {
                this.isPurchaseOrder = value;
                this.OnPropertyChanged("IsPurchaseOrder");
            }
        }
        
        public bool NotShowQuantityColumns
        {
            get { return this.notShowQuantityColumns; }
            set
            {
                this.notShowQuantityColumns = value;
                this.OnPropertyChanged("NotShowQuantityColumns");
            }
        }

        public string WidthForUserControl
        {
            get { return widthForUserControl; }
            set
            {
                this.widthForUserControl = value;
                this.OnPropertyChanged("WidthForUserControl");
            }
        }

        #endregion

        #region Comandos Eventos de botones 
        public ICommand CmdOpenEditObservationItem { get; }
        public ICommand ViewDetails { get; } /// Botón
        public ICommand ViewDetailsCraft { get; } /// Botón
        public ICommand CancelOrderCommand { get; } /// Botón
        #endregion

        #region Objetos de Servicios
        private OrderListService OrderListServices;
        private ArticleService ArticleService;
        #endregion

        #region Tareas
        /// <summary>
        /// Task para llamar en el constructor métodos asyncronos
        /// </summary>
        private Task GetOrderListDetails;
        private Task GetActions;
        #endregion

        #region Constructor
        public VMOrderListDetail(MainWindow principalScreen, int id)
        {
            this.PrincipalScreen = principalScreen;
            this.ViewDetails = new RelayCommand(ViewDetailShow);
            this.ViewDetailsCraft = new RelayCommand(ViewDetailShowCraft);
            this.CmdOpenEditObservationItem = new RelayCommand<BORegisterOrderListDetails>(OpenEditObservationItem);
            this.CancelOrderCommand = new RelayCommand(CancelOrder);
            this.ID = id;
            this.OrderListServices = new OrderListService();
            this.ArticleService = new ArticleService();
            this.GetOrderListDetails = GetOrderListAsync(this.ID);
            this.GetActions = GetActionsAsync();
            this.notification = new Notification();

            principalScreen.SizeChanged += PrincipalScreen_SizeChanged;
            principalScreen.StateChanged += PrincipalScreen_StateChanged;
            principalScreen.NotifyOpenMenu += PrincipalScreen_NotifyOpenMenu;
        }

        #endregion


        #region Métodos Privados

        /// <summary>
        /// Método que controla el tamaño de pantalla de acuerdo a la interación del usuario (Abrir o cerrar menú)
        /// </summary>  
        private void PrincipalScreen_NotifyOpenMenu()
        {
            if (this.PrincipalScreen.MenuIsOpen)
            {
                this.WidthForUserControl = (this.PrincipalScreen.Width - 290).ToString();
            }
            else
            {
                this.WidthForUserControl = (this.PrincipalScreen.Width - 100).ToString();
            }
        }

        /// <summary>
        /// Método que controla el tamaño de pantalla de acuerdo a la interación del usuario (MAXIMIZAR/MINIMIZAR)
        /// </summary>  
        private void PrincipalScreen_StateChanged(object sender, EventArgs e)
        {
            if (this.PrincipalScreen.WindowState == WindowState.Maximized)
            {
                this.PrincipalScreen.Width = SystemParameters.PrimaryScreenWidth;
            }
        }

        /// <summary>
        /// Método que controla el tamaño de pantalla de acuero a la interación del usuario (Cambiar tamaño)
        /// </summary>  
        private void PrincipalScreen_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            if (this.PrincipalScreen.MenuIsOpen)
            {
                this.WidthForUserControl = (this.PrincipalScreen.Width - 290).ToString();
            }
            else
            {
                this.WidthForUserControl = (this.PrincipalScreen.Width - 100).ToString();
            }
        }


        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetOrderListAsync(int id)
        {
            this.OrderListDetails = await this.OrderListServices.GetOrderListById(id);
            
            //Removemos las acciones sin artículos
            this.OrderListDetails.Actions.RemoveAll(x => x.Articles.Count() == 0);

            this.EnableCancelOrder = this.OrderListDetails.CancelOrder && this.OrderListDetails.State == "Abierto";
            this.OrderListDetails.DateSend = this.OrderListDetails.DateSend != null ? this.OrderListDetails.DateSend.Substring(0, 10):"";
            //TOFIX: Organizar para que se valide con typeorderid
            this.IsPurchaseOrder = OrderListDetails.TypeOrder == "Compras";
            this.IsNotPurchaseOrder = OrderListDetails.TypeOrder != "Compras";
        }

        /// <summary>
        /// Método que obtiene las acciones que se pueden realizar por producto
        /// </summary>  
        private async Task GetActionsAsync()
        {
            List<BOActions> bOActions = await this.ArticleService.GetActions();
            this.Actions = new ObservableCollection<BOActions>(bOActions);
        }
        
        private void ViewDetailShow()
        {
            this.PrincipalScreen.ContentPage.Content = new UCOrderList(this.PrincipalScreen);
        }
        
        
        private void ViewDetailShowCraft()
        {
            this.PrincipalScreen.ContentPage.Content = new UCNewOrders(this.PrincipalScreen);
        }
        
        
        private void CancelOrder()
        {
            this.ConfigureModalConfirmation(
                    DictMessages.ConfirmarGuadarSolicitudPedido,
                    DictIcons.Backup,
                    DictColors.Warning
                );
        }

        private void ConfigureModalConfirmation(string messageConfirmation, string iconName, string foreground)
        {
            this.messageConfirmation = messageConfirmation; //DictMessages
            this.iconName = iconName;//DictIcons
            this.foreground = foreground;
            UCModalCancelOrder = new UCModalCancelOrder(this, this);
            this.PrincipalScreen.ModalContainer.Content = UCModalCancelOrder;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
        }

        private void OpenEditObservationItem(BORegisterOrderListDetails bORegisterOrderListDetails)
        {
            this.OrderListDetails.Registers.Where(a => a.CodeArticle == bORegisterOrderListDetails.CodeArticle).FirstOrDefault().IsPopObservationOpen = true;
        }

        public void ExecuteConfirmationYes()
        {
            bool cancelORder = this.OrderListServices.CancelOrder(this.ID, CancelReason.ReasonId);
            if (cancelORder)
            {
                this.notification.Show(DictMessages.Success, string.Format(DictMessages.SolicitudCancelada, this.OrderListDetails.NumberOrderList), NotificationType.Success);
            }

            this.PrincipalScreen.ContentPage.Content = this.PrincipalScreen.UCOrderList;
            this.PrincipalScreen.UCOrderList.reloadPage();
            this.PrincipalScreen.SubItemsOrders.Where(x => x.Name == "Consulta").FirstOrDefault().IsSelected = true;

            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }
        public void ExecuteConfirmationNot()
        {
            //this.PrincipalScreen.ContentPage.Content = this.PrincipalScreen.UCOrderList;
            //this.PrincipalScreen.UCOrderList.reloadPage();
            //this.PrincipalScreen.SubItemsOrders.Where(x => x.Name == "Consulta").FirstOrDefault().IsSelected = true;

            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }

        #endregion


    }
}
