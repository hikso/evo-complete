using EVO_PV.Interfaces;
using EVO_PV.ViewModels;
using System;
using System.Windows.Controls;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para UCCustomMessages.xaml
    /// </summary>
    public partial class UCCustomMessages : UserControl
    {

        #region
        public VMCustomMessages vMCustomMessages { get { return DataContext as VMCustomMessages; } }
        #endregion
        #region Contructores

        public UCCustomMessages(IConfirmationModal confirmationModal) : this(new VMCustomMessages(confirmationModal))
        {

        }
        public UCCustomMessages(VMCustomMessages vMCustomMessages)
        {
            InitializeComponent();

            if (vMCustomMessages == null)
            {
                throw new ArgumentNullException("");
            }

            this.DataContext = vMCustomMessages;
        }
        #endregion
    }
}
