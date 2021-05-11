using EVO_PV.Models.BusinessObjects;
using EVO_PV.ViewModels;
using System;
using System.Windows.Controls;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para UCModalArticleFilter.xaml
    /// </summary>
    public partial class UCModalArticleFilter : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        #region
        public VMModalArticleFilter vMModalArticleFilter { get { return DataContext as VMModalArticleFilter; } }
        #endregion

        #region Contructores

        public UCModalArticleFilter(MainWindow principalScreen, VMGenerateInvoice vMGenerateInvoice) : this(new VMModalArticleFilter(principalScreen, vMGenerateInvoice))
        {

        }

        public UCModalArticleFilter(VMModalArticleFilter vMModalArticleFilter)
        {
            InitializeComponent();

            if (vMModalArticleFilter == null)
            {
                throw new ArgumentNullException("");
            }
            this.DataContext = vMModalArticleFilter;
        }

        #endregion
    }
}
