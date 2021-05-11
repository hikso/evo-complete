using EVO_PV;
using EVO_PV_New.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace EVO_PV_New.Views
{
    /// <summary>
    /// Interaction logic for UCArticles.xaml
    /// </summary>
    public partial class UCArticles : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        #region Contructores
        /// <summary>
        /// Referencia del main
        /// </summary>
        /// <param name="principalScreen"></param>
        public UCArticles(MainWindow principalScreen) : this(new VMArticles(principalScreen))
        {
            this.PrincipalScreen = principalScreen;
            this.PrincipalScreen.ContentPage.VerticalAlignment = VerticalAlignment.Stretch;
            this.PrincipalScreen.ContentPage.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        /// <summary>
        /// Constructor que recibe como argumento una referencia del view model.
        /// </summary>
        /// <param name="vMArticles"></param>
        public UCArticles(VMArticles vMArticles)
        {
            InitializeComponent();
        }
        #endregion
    }
}
