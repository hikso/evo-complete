using EVO_PV.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para UCNewOrders.xaml
    /// </summary>
    public partial class UCNewOrders : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        #region Contructores

        public UCNewOrders(MainWindow principalScreen) : this(new VMNewOrders(principalScreen))
        {
            this.PrincipalScreen = principalScreen;
            this.PrincipalScreen.ContentPage.VerticalAlignment = VerticalAlignment.Stretch;
            this.PrincipalScreen.ContentPage.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        #endregion

        public UCNewOrders(VMNewOrders vMNewOrders)
        {
            InitializeComponent();
            this.DataContext = vMNewOrders;
        }
        public void reloadPage()
        {
            (this.DataContext as VMNewOrders).reloadPage();
        }
        private void NewRequest_Click(object sender, RoutedEventArgs e)
        {
            this.PrincipalScreen.ContentPage.Content = new UCOrderRequest(this.PrincipalScreen);
        }
    }
}

