using EVO_PV.Interfaces;
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
    /// Lógica de interacción para UCModalCancelOrder.xaml
    /// </summary>
    public partial class UCModalCancelOrder : UserControl
    {
        #region Private
        private UCModalCancelOrder uCModalCancelOrder;
        #endregion

        #region Public
        public VMModalCancelOrder vMModalCancelOrder { get { return DataContext as VMModalCancelOrder; } }
        #endregion

        #region Contructores
        public UCModalCancelOrder(IConfirmationModal confirmationModal, VMOrderListDetail vMOrderListDetail) : this(new VMModalCancelOrder(confirmationModal, vMOrderListDetail))
        {

        }

        public UCModalCancelOrder(VMModalCancelOrder vMModalCancelOrder)
        {
            InitializeComponent();

            if (vMModalCancelOrder == null)
            {
                throw new ArgumentNullException("");
            }

            this.DataContext = vMModalCancelOrder;
        }
        #endregion
    }
}
