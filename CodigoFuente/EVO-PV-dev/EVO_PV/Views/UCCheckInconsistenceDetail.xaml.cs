using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using EVO_PV;
using EVO_PV.ViewModels;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para CheckInconsistenceDetail.xaml
    /// </summary>
    public partial class UCCheckInconsistenceDetail : UserControl
    {

        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        public UCCheckInconsistenceDetail(MainWindow principalScreen, int id, string requestNumber, string deliverNumber) : this(new VMCheckInconsistenceDetail(principalScreen, id, requestNumber, deliverNumber))
        {
            this.PrincipalScreen = principalScreen;
            this.PrincipalScreen.ContentPage.VerticalAlignment = VerticalAlignment.Stretch;
            this.PrincipalScreen.ContentPage.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        public UCCheckInconsistenceDetail(VMCheckInconsistenceDetail vMCheckInconsistenceDetail)
        {
            InitializeComponent();
            this.DataContext = vMCheckInconsistenceDetail;
        }

    }
}
