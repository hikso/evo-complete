using EVO_PV;
using EVO_PB.Interfaces;
using EVO_PB.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;
using System.Text.RegularExpressions;
using EVO_PB.Utilities;
namespace EVO_PB.Views
{
    /// <summary>
    /// Interaction logic for UCEnlistment.xaml
    /// </summary>
    public partial class UCEnlistment : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        public VMEnlistment vMEnlistment { get { return DataContext as VMEnlistment; } }
        #endregion
        public UCEnlistment(MainWindow principalScreen) : this(new VMEnlistment(principalScreen))
        {
            InitializeComponent();
        }

        public UCEnlistment(VMEnlistment vMEnlistment)
        {
            InitializeComponent();

            if (vMEnlistment == null)
            {
                throw new ArgumentNullException("");
            }

            this.DataContext = vMEnlistment;
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            var cBoxDeliveries = this.FindName("cBoxDeliveries");
            ComboBox box = cBoxDeliveries as ComboBox;
            box.SelectedIndex = 0;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = "0";
                textBox.Focus();
            }
        }
    }
}
