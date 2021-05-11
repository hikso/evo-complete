using EVO_PB;
using EVO_PB.Enums;
using EVO_PB.Models.BusinessObjects;
using EVO_PB.ViewModels;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace EVO_PV
{
   
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public delegate void MainSizeChangedDelegate(double Width, double heigth);
        //public event MainSizeChangedDelegate MainSizeChangedEvent = null;
        public MainWindow()
        {
            InitializeComponent();
            //MainSizeChangedEvent += new MainSizeChangedDelegate(Window_SizeChanged);
            ContentPage.Content = new UCDashboard(this);           

            object whsName = App.Current.Properties[EnumConstanst.WhsName.ToString()];
            object maximumPageSize = App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()];
            BOUser bOUser = App.Current.Properties[EnumConstanst.BOUser.ToString()] as BOUser;
            object version = App.Current.Properties[EnumConstanst.Version.ToString()];

            if (whsName != null)
            {
                this.Title = $"{(string)whsName} - {bOUser.UserName}";
            }

            var item0 = new VMItemMenu("Inicio", new UserControl(), PackIconKind.ViewDashboard);

            var menuRegister = new List<VMSubItem>();          
            menuRegister.Add(new VMSubItem("Alistamiento"));
            var item1 = new VMItemMenu("Distribución", menuRegister, PackIconKind.PlaylistAddCheck, this);          

            Menu.Children.Add(new UCItemMenu(item0, this));
            Menu.Children.Add(new UCItemMenu(item1, this));           

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
        }

        private void ButtonMenu_Close(object sender, RoutedEventArgs e)
        {
            this.ButtonOpenMenu.Visibility = Visibility.Visible;
            this.ButtonCloseMenu.Visibility = Visibility.Collapsed;
            this.ImageOpen.Visibility = Visibility.Collapsed;
            this.ImageClose.Visibility = Visibility.Visible;
        }
      
    }
}
