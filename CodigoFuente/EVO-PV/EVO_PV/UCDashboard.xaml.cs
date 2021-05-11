using EVO_PV;
using EVO_PV.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EVO_PV
{
    /// <summary>
    /// Lógica de interacción para UCDashboard.xaml
    /// </summary>
    public partial class UCDashboard : UserControl
    {

        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        public UCDashboard(MainWindow principalScreen)
        {
            InitializeComponent();
            this.PrincipalScreen = principalScreen;
            this.PrincipalScreen.ContentPage.VerticalAlignment = VerticalAlignment.Top;
            this.PrincipalScreen.ContentPage.HorizontalAlignment = HorizontalAlignment.Left;           
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var option = sender as Grid;

            switch (option.Name)
            {
                case "UCOrderRequest":
                    this.PrincipalScreen.ContentPage.Content = new UCOrderRequest(this.PrincipalScreen);
                    break;
                case "UCOrderList":
                    this.PrincipalScreen.ContentPage.Content = new UCOrderList(this.PrincipalScreen);
                    break;
                case "UCReceive":
                    this.PrincipalScreen.ContentPage.Content = this.PrincipalScreen.UCReceive;
                    break;
                //case "UCModalClientFilter":
                //    this.PrincipalScreen.ModalContainer.Content = new UCModalClientFilter(this.PrincipalScreen);
                //    this.PrincipalScreen.ModalPrincipal.IsOpen = true;
                //    break;
            }
        }
    }
}
