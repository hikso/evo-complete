using EVO_PV;
using EVO_PV.Enums;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.ViewModels;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using EVO_PV.Views;
using System.Threading.Tasks;
using System.Diagnostics;
using EVO_PV.Services;
using Notifications.Wpf;
using EVO_PV.Resources.Dictionaries;
using EVO_PV.Utilities;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Media;
using System.Linq;

namespace EVO_PV
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UCModalBoxSetting UCModalBoxSetting;
        private Task openBoxSetting;
        BoxSettingService boxSettingService;
        public Notification notification;

        public UCDashboard UCDashboard;
        public UCOrderList UCOrderList;
        public UCNewOrders UCNewOrders;
        public UCOrderRequest UCOrderRequest;
        public UCReceive UCReceive;
        public UCCheckInconsistencies UCCheckInconsistencies;
        public UCGenerateInvoice UCGenerateInvoice;
        public List<VMSubItem> SubItemsOrders;
        public UCPopPages UCPopPages;
        public bool MenuIsOpen = true;
        public event NotifyOpen NotifyOpenMenu;
        
        public delegate void NotifyOpen();

        public MainWindow()
        {
            InitializeComponent();
            SubItemsOrders = new List<VMSubItem>();
            ContentPage.Content = new UCDashboard(this);
            notification = new Notification();
            //ListMenu.SelectedIndex = 0;

            object whsName = App.Current.Properties[EnumConstanst.WhsName.ToString()];
            object maximumPageSize = App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()];
            BOUser bOUser = App.Current.Properties[EnumConstanst.BOUser.ToString()] as BOUser;
            object version = App.Current.Properties[EnumConstanst.Version.ToString()];
            object decimals = App.Current.Properties[EnumConstanst.Decimals.ToString()];

            if (whsName != null)
            {
                this.Title = $"{(string)whsName} - {bOUser.UserName}";
            }

            var item0 = new VMItemMenu("Inicio", new UserControl(), PackIconKind.ViewDashboard, this);

            var menuPedidos = new List<VMSubItem>();
            menuPedidos.Add(new VMSubItem("Solicitud"));
            menuPedidos.Add(new VMSubItem("Consulta"));
            SubItemsOrders.AddRange(menuPedidos);
            var item1 = new VMItemMenu("Pedidos", menuPedidos, PackIconKind.Read, this);

            //var menuRecepcion = new List<VMSubItem>();
            //menuRecepcion.Add(new VMSubItem("Recibir"));
            //menuRecepcion.Add(new VMSubItem("Inconsistencias"));
            //SubItemsOrders.AddRange(menuRecepcion);
            //var item2 = new VMItemMenu("Recepción", menuRecepcion, PackIconKind.Hand, this);

            //var menuFacturacion = new List<VMSubItem>();
            //menuFacturacion.Add(new VMSubItem("Factura POS"));
            //SubItemsOrders.AddRange(menuFacturacion);
            //var item3 = new VMItemMenu("Facturación", menuFacturacion, PackIconKind.Paper, this);

            Menu.Children.Add(new UCItemMenu(item0, this));
            Menu.Children.Add(new UCItemMenu(item1, this));
            //Menu.Children.Add(new UCItemMenu(item2, this));
            //Menu.Children.Add(new UCItemMenu(item3, this));

            boxSettingService = new BoxSettingService();
            this.openBoxSetting = GetDeliveryReceiveHeaderAsync();
            this.InitializeComponentsAsync();
            this.UCPopPages = new UCPopPages(this);

            this.FrameUCPopPages.Content = UCPopPages;

        }

        public void InitializeComponentsAsync()
        {

            UCLoadingTemplate UCLoadingTemplate = new UCLoadingTemplate();
            LoadingElement.Content = UCLoadingTemplate;

            UCDashboard = new UCDashboard(this);
            UCGenerateInvoice = new UCGenerateInvoice(this);
            UCCheckInconsistencies = new UCCheckInconsistencies(this);
            //UCOrderRequest = new UCOrderRequest(this);
            UCNewOrders = new UCNewOrders(this);
            UCReceive = new UCReceive(this);
            UCOrderList = new UCOrderList(this);
            (UCOrderList.DataContext as VMOrderList).SubItems = this.SubItemsOrders;
            
            ModalLoading.IsOpen = false;

        }
        public async Task OpenBoxSettingAsync()
        {
            Task delay = Task.Delay(500);
            await delay;
            UCModalBoxSetting = new UCModalBoxSetting(this);
            ModalContainer.Content = UCModalBoxSetting;
            ModalPrincipal.IsOpen = true;
        }

        /// <summary>
        /// Método que obtiene las entregas de forma asíncrona
        /// </summary>  
        private async Task GetDeliveryReceiveHeaderAsync()
        {
            this.boxSettingService = new BoxSettingService();
            BOBoxState bOBoxState = await this.boxSettingService.GetBoxState();
            if (!bOBoxState.TodayIsConfigured)
            {
                this.openBoxSetting = OpenBoxSettingAsync();
            }
            //if (!bOBoxState.YesterdayIsClosed)
            //{
            //    this.notification.Show(DictMessages.Warning, "El día de ayer no se realizó el respectivo cierre de caja", NotificationType.Error);
            //}
           
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonMenu_Open(object sender, RoutedEventArgs e)
        {
            this.ButtonOpenMenu.Visibility = Visibility.Collapsed;
            this.ButtonCloseMenu.Visibility = Visibility.Visible;
            this.ImageOpen.Visibility = Visibility.Visible;
            this.ImageClose.Visibility = Visibility.Collapsed;
            this.MenuIsOpen = true;

            foreach (UCItemMenu item in this.Menu.Children)
            {
                (item.DataContext as VMItemMenu).MenuIsExpanded = true;
                (item.DataContext as VMItemMenu).Header = (item.DataContext as VMItemMenu).HeaderBackUp;
            }
            NotifyOpenMenu?.Invoke();

        }

        private void ButtonMenu_Close(object sender, RoutedEventArgs e)
        {
            this.ButtonOpenMenu.Visibility = Visibility.Visible;
            this.ButtonCloseMenu.Visibility = Visibility.Collapsed;
            this.ImageOpen.Visibility = Visibility.Collapsed;
            this.ImageClose.Visibility = Visibility.Visible;
            this.MenuIsOpen = false;

            foreach (UCItemMenu item in this.Menu.Children)
            {
                (item.DataContext as VMItemMenu).MenuIsExpanded = false;
                (item.DataContext as VMItemMenu).Header = "";
            }
            NotifyOpenMenu?.Invoke();
        }
    }
}
