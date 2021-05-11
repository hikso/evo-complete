using EVO_PV;
using EVO_PV.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EVO_PV
{
    /// <summary>
    /// Lógica de interacción para UCItemMenu.xaml
    /// </summary>
    public partial class UCItemMenu : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        public UCItemMenu(VMItemMenu itemMenu, MainWindow principalScreen)
        {
            InitializeComponent();

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
            this.PrincipalScreen = principalScreen;
        }

        private void ListViewItemMenu_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var dat = (sender as ListBoxItem).Content;
            List<UCItemMenu> collection = this.PrincipalScreen.Menu.Children.OfType<UCItemMenu>().ToList();
            foreach (var item in collection)
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
            switch (dat)
            {
                case "Inicio":
                    this.PrincipalScreen.StickyContent.Content = null;
                    this.PrincipalScreen.ContentPage.Content = new UCDashboard(this.PrincipalScreen);
                    break;
            }
        }

        private void WrapPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
