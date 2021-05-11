using EVO_PV;
using EVO_PB.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EVO_PB
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
            switch (dat)
            {
                case "Inicio":
                    this.PrincipalScreen.ContentPage.Content = new UCDashboard(this.PrincipalScreen);
                    break;
            }
        }
    }
}
