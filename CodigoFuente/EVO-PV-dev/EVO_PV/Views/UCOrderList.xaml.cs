using EVO_PV;
using EVO_PV.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para UCOrderList.xaml
    /// </summary>
    public partial class UCOrderList : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        #region Contructores

        public UCOrderList(MainWindow principalScreen) : this(new VMOrderList(principalScreen))
        {
            this.PrincipalScreen = principalScreen;
            this.PrincipalScreen.ContentPage.VerticalAlignment = VerticalAlignment.Stretch;
            this.PrincipalScreen.ContentPage.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        #endregion

        public UCOrderList(VMOrderList vMOrderList)
        {
            InitializeComponent();
            this.DataContext = vMOrderList;
        }
        public void reloadPage()
        {
            (this.DataContext as VMOrderList).reloadPage();
        }
        private void NewRequest_Click(object sender, RoutedEventArgs e)
        {
            this.PrincipalScreen.ContentPage.Content = new UCOrderRequest(this.PrincipalScreen);
        }

    }
}
