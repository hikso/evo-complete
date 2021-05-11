using EVO_PV.Models.BusinessObjects;
using EVO_PV.ViewModels;
using System;
using System.Windows.Controls;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para UCModalClientFilter.xaml
    /// </summary>
    public partial class UCModalClientFilter : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        #region
        public VMModalClientFilter vMModalClientFilter { get { return DataContext as VMModalClientFilter; } }
        #endregion

        #region Contructores

        public UCModalClientFilter(MainWindow principalScreen, VMGenerateInvoice vMGenerateInvoice) : this(new VMModalClientFilter(principalScreen, vMGenerateInvoice))
        {

        }

        public UCModalClientFilter(VMModalClientFilter vMModalClientFilter)
        {
            InitializeComponent();

            if (vMModalClientFilter == null)
            {
                throw new ArgumentNullException("");
            }
            this.DataContext = vMModalClientFilter;
        }

        #endregion
    }
}

