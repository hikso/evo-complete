using EVO_PV;
using EVO_PB.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EVO_PB
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
                case "UCEnlistment":
                    this.PrincipalScreen.ContentPage.Content = new UCEnlistment(this.PrincipalScreen);
                    break;
            }
        }
    }
}
