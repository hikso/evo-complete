using EVO_PV.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EVO_PV.Views
{
    /// <summary>
    /// Interaction logic for UCModalPrintInvoice.xaml
    /// </summary>
    public partial class UCModalPrintInvoice : UserControl
    {
        #region Global
        private MainWindow PrincipalScreen;       
        #endregion

        public UCModalPrintInvoice(MainWindow principalScreen) : this(new VMModalPrintInvoice(principalScreen))
        {
            this.PrincipalScreen = principalScreen;
        }

        public UCModalPrintInvoice(VMModalPrintInvoice vMModalPayment)
        {
            InitializeComponent();

            if (vMModalPayment == null)
            {
                throw new ArgumentNullException("");
            }

            this.DataContext = vMModalPayment;
        }
       
    }
}
