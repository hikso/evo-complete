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

using EVO_PV;
using EVO_PV.ViewModels;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para UCGenerateInvoice.xaml
    /// </summary>
    public partial class UCGenerateInvoice : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        public UCGenerateInvoice(MainWindow principalScreen) : this(new VMGenerateInvoice(principalScreen))
        {
            this.PrincipalScreen = principalScreen;
            this.PrincipalScreen.ContentPage.VerticalAlignment = VerticalAlignment.Stretch;
            this.PrincipalScreen.ContentPage.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        public UCGenerateInvoice(VMGenerateInvoice vMCheckInconsistenceDetail)
        {
            InitializeComponent();
            this.DataContext = vMCheckInconsistenceDetail;
        }

        private void cbArticles_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsKeyEnterPressed(e))
            {
                (this.DataContext as VMGenerateInvoice).OpenFilterArticles();
                e.Handled = true;
            }
        }

        private void cbCustomerIdentification_KeyDown(object sender, KeyEventArgs e)
        {
            OpenByEnterPressedClientFilterModal(e);
        }

        private void cbCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            OpenByEnterPressedClientFilterModal(e);
        }
        private void OpenByEnterPressedClientFilterModal(KeyEventArgs e)
        {
            if (IsKeyEnterPressed(e))
            {
                (this.DataContext as VMGenerateInvoice).OpenFilterClients();
                e.Handled = true;
            }
        }
        private bool IsKeyEnterPressed(KeyEventArgs e)
        {
            return e != null && e.Key == Key.Enter;
        }

        private void cbArticlesName_KeyUp(object sender, KeyEventArgs e)
        {
            if (IsKeyEnterPressed(e))
            {
                (this.DataContext as VMGenerateInvoice).OpenFilterArticles();
                e.Handled = true;
            }
        }

    }
}
