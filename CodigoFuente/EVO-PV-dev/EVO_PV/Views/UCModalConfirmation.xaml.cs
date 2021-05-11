using EVO_PV.Interfaces;
using EVO_PV.ViewModels;
using System;
using System.Windows.Controls;

namespace EVO_PV.Views
{
    /// <summary>
    /// Interaction logic for UCModalConfirmation.xaml
    /// </summary>
    public partial class UCModalConfirmation : UserControl
    {
        private UCModalConfirmation uCModalConfirmation;

        #region
        public VMModalConfirmation vMModalArticles { get { return DataContext as VMModalConfirmation; } }
        #endregion
        #region Contructores

        public UCModalConfirmation(IConfirmationModal confirmationModal) : this(new VMModalConfirmation(confirmationModal))
        {

        }
        public UCModalConfirmation(VMModalConfirmation vMModalConfirmation)
        {
            InitializeComponent();

            if (vMModalConfirmation == null)
            {
                throw new ArgumentNullException("");
            }

            this.DataContext = vMModalConfirmation;
        }
        #endregion


    }
}
