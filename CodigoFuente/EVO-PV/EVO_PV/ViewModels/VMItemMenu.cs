using EVO_PV;
using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    public class VMItemMenu : NotifyPropertyChanged
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        public VMItemMenu(string header, List<VMSubItem> subItems, PackIconKind icon, MainWindow principal)
        {
            Header = header;
            HeaderBackUp = header;
            SubItems = subItems;
            
            if (SubItems.Count() == 0) ThereAreNoSubItems = true;

            MenuIsExpanded = true;
            Icon = icon;
            this.PrincipalScreen = principal;
            this.ClickCommand = new RelayCommand(Click);
            this.CmdOpen = new RelayCommand(Open);
        }

        public ICommand ClickCommand { get; }
        public ICommand CmdOpen { get; }

        public void OpenPageContent()
        {
            this.PrincipalScreen.StickyContent.Content = null;
            if (this.PrincipalScreen == null)
            {
                return;
            }
            List<UCItemMenu> collection = this.PrincipalScreen.Menu.Children.OfType<UCItemMenu>().ToList();
            foreach (var item in  collection)
            {
                List<VMSubItem> _SubItems = (item.DataContext as VMItemMenu).SubItems;
                if (_SubItems != null)
                {
                    foreach (var subitem in _SubItems)
                    {
                        subitem.IsSelected = false;
                    }
                }
            }
            
            if (this.SelectItemSubmenu == null)
            {
                return;
            }
            switch (this.SelectItemSubmenu.Name)
            {
                case "Inicio":
                    this.PrincipalScreen.ContentPage.Content = this.PrincipalScreen.UCDashboard;
                    this.SubItems.Where(x => x.Name == SelectItemSubmenu.Name).FirstOrDefault().IsSelected = true;
                    break;

                case "Consulta":
                    this.PrincipalScreen.ContentPage.Content = this.PrincipalScreen.UCOrderList;
                    this.PrincipalScreen.UCOrderList.reloadPage();
                    this.SubItems.Where(x => x.Name == SelectItemSubmenu.Name).FirstOrDefault().IsSelected = true;
                    break;

                case "Solicitud":
                    this.PrincipalScreen.ContentPage.Content = new UCOrderRequest(this.PrincipalScreen);
                    this.SubItems.Where(x => x.Name == SelectItemSubmenu.Name).FirstOrDefault().IsSelected = true;
                    break;

                case "Recibir":
                    this.PrincipalScreen.ContentPage.Content = this.PrincipalScreen.UCReceive;
                    this.SubItems.Where(x => x.Name == SelectItemSubmenu.Name).FirstOrDefault().IsSelected = true;
                    break;

                case "Inconsistencias":
                    this.PrincipalScreen.ContentPage.Content = this.PrincipalScreen.UCCheckInconsistencies;
                    this.PrincipalScreen.UCCheckInconsistencies.reloadPage();
                    this.SubItems.Where(x => x.Name == SelectItemSubmenu.Name).FirstOrDefault().IsSelected = true;
                    break;

                case "Factura POS":
                    this.SubItems.Where(x => x.Name == SelectItemSubmenu.Name).FirstOrDefault().IsSelected = true;

                    //ItemControForInvoice itemControForInvoice = new ItemControForInvoice();
                    //itemControForInvoice.Title = "Factura POS";
                    //itemControForInvoice.UCGenerateInvoice = new UCGenerateInvoice(this.PrincipalScreen);
                    this.PrincipalScreen.ContentPage.Content = this.PrincipalScreen.UCGenerateInvoice;
                    //(this.PrincipalScreen.UCPopPages.DataContext as VMPopPages).AddPage(itemControForInvoice);

                    break;
            }
        }
        public void Click()
        {

            this.OpenPageContent();
        }
        
        public async void Open()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();


            Task delay = Task.Delay(500);
            await delay;


            switch (SelectItemSubmenu.Name)
            {
                case "Inicio":
                    mainWindow.ContentPage.Content = mainWindow.UCDashboard;
                    mainWindow.SubItemsOrders.Where(x => x.Name == SelectItemSubmenu.Name).FirstOrDefault().IsSelected = true;
                    break;

                case "Consulta":
                    mainWindow.ContentPage.Content = mainWindow.UCOrderList;
                    mainWindow.UCOrderList.reloadPage();
                    mainWindow.SubItemsOrders.Where(x => x.Name == SelectItemSubmenu.Name).FirstOrDefault().IsSelected = true;
                    break;

                case "Solicitud":
                    mainWindow.ContentPage.Content = mainWindow.UCOrderRequest;
                    mainWindow.UCOrderRequest.reloadPage();
                    mainWindow.SubItemsOrders.Where(x => x.Name == SelectItemSubmenu.Name).FirstOrDefault().IsSelected = true;
                    break;

                case "Recibir":
                    mainWindow.ContentPage.Content = mainWindow.UCReceive;
                    mainWindow.SubItemsOrders.Where(x => x.Name == SelectItemSubmenu.Name).FirstOrDefault().IsSelected = true;
                    break;

                case "Inconsistencias":
                    mainWindow.ContentPage.Content = mainWindow.UCCheckInconsistencies;
                    mainWindow.UCCheckInconsistencies.reloadPage();
                    mainWindow.SubItemsOrders.Where(x => x.Name == SelectItemSubmenu.Name).FirstOrDefault().IsSelected = true;
                    break;

                case "Factura POS":
                    mainWindow.SubItemsOrders.Where(x => x.Name == SelectItemSubmenu.Name).FirstOrDefault().IsSelected = true;
                    mainWindow.ContentPage.Content = mainWindow.UCGenerateInvoice;

                    break;
            }
        }

        public VMItemMenu(string header, UserControl screen, PackIconKind icon, MainWindow principal)
        {
            Header = header;
            HeaderBackUp = header;
            Screen = screen;
            Icon = icon;
            this.PrincipalScreen = principal;
        }

        public string HeaderBackUp { get; set; }
        public PackIconKind Icon { get; private set; }
        public List<VMSubItem> SubItems { get; private set; }
        public UserControl Screen { get; private set; }

        private string header { get; set; }
        public string Header
        {
            get { return header; }
            set
            {
                header = value;
                OnPropertyChanged("Header");
            }
        }

        private bool thereAreNoSubItems { get; set; }
        public bool ThereAreNoSubItems
        {
            get { return thereAreNoSubItems; }
            set
            {
                thereAreNoSubItems = value;
                OnPropertyChanged("ThereAreNoSubItems");
            }
        }
        private bool menuIsExpanded { get; set; }
        public bool MenuIsExpanded
        {
            get { return menuIsExpanded; }
            set
            {
                menuIsExpanded = value;
                OnPropertyChanged("MenuIsExpanded");
            }
        }

        private VMSubItem selectItemSubmenu { get; set; }
        public VMSubItem SelectItemSubmenu
        {
            get { return selectItemSubmenu; }
            set
            {

                selectItemSubmenu = value;
                this.OnPropertyChanged("SelectItemSubmenu");
                bool mouseIsDown = System.Windows.Input.Mouse.LeftButton == MouseButtonState.Pressed;
                if (mouseIsDown)
                {
                    this.OpenPageContent();
                }
            }
        }

    }
}
