using EVO_PV;
using EVO_PV.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EVO_PV
{
    /// <summary>
    /// Lógica de interacción para UCPopPages.xaml
    /// </summary>
    public partial class UCPopPages : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        #region Constructor
        public UCPopPages(MainWindow principalScreen) : this(new VMPopPages(principalScreen))
        {
            this.PrincipalScreen = principalScreen;
        }

        public UCPopPages(VMPopPages vMPopPages)
        {
            InitializeComponent();
            this.DataContext = vMPopPages;
        }

        #endregion
    }
}
