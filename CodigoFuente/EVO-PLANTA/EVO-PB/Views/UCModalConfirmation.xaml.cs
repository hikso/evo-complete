using EVO_PV;
using EVO_PB.Interfaces;
using EVO_PB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EVO_PB.Views
{
    /// <summary>
    /// Interaction logic for UCModalConfirmation.xaml
    /// </summary>
    public partial class UCModalConfirmation : UserControl
    {
        
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
