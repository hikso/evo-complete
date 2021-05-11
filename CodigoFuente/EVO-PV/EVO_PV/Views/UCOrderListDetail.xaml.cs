using EVO_PV;
using EVO_PV.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace EVO_PV.Views
{

    /// <summary>
    /// Lógica de interacción para UCOrderListDetail.xaml
    /// </summary>
    public partial class UCOrderListDetail : UserControl
    {

        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        #region Contructores

        public UCOrderListDetail(MainWindow principalScreen, int id) : this(new VMOrderListDetail(principalScreen, id))
        {
            this.PrincipalScreen = principalScreen;
            this.PrincipalScreen.ContentPage.VerticalAlignment = VerticalAlignment.Stretch;
            this.PrincipalScreen.ContentPage.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        #endregion



        public UCOrderListDetail(VMOrderListDetail vMOrderListDetail)
        {
            InitializeComponent();
            this.DataContext = vMOrderListDetail;
        }
    }
}
