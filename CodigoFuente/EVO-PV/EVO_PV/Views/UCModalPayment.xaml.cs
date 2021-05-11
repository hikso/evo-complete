using EVO_PV.Models.BusinessObjects;
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
    /// Lógica de interacción para UCModalPayment.xaml
    /// </summary>
    public partial class UCModalPayment : UserControl
    {
        #region Global
        private MainWindow PrincipalScreen;
        #endregion

        public UCModalPayment(MainWindow principalScreen, BOGenerateInvoice bOGenerateInvoice) : this(new VMModalPayment(principalScreen, bOGenerateInvoice))
        {
            this.PrincipalScreen = principalScreen;
        }

        public UCModalPayment(VMModalPayment vMModalPayment)
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
