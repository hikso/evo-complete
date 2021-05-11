using EVO_PV;
using EVO_PV.Enums;
using EVO_PV.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EVO_PV.Utilities;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para UCOrderListEdit.xaml
    /// </summary>
    public partial class UCOrderListEdit : UserControl
    {

        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        #region Contructores

        public UCOrderListEdit(MainWindow principalScreen, int id, EnumConstanst typeVM) : this(new VMOrderListEdit(principalScreen, id, typeVM))
        {
            this.PrincipalScreen = principalScreen;
            this.PrincipalScreen.ContentPage.VerticalAlignment = VerticalAlignment.Stretch;
            this.PrincipalScreen.ContentPage.HorizontalAlignment = HorizontalAlignment.Stretch;
            this.UserControl.Focus();
        }

        #endregion


        /// <summary>
        /// Constructor que recibe como argumento una referencia del view model.
        /// </summary>
        /// <param name="vMOrderListEdit"></param>
        public UCOrderListEdit(VMOrderListEdit vMOrderListEdit)
        {
            InitializeComponent();

            if (vMOrderListEdit == null)
            {
                throw new ArgumentNullException("");
            }

            this.DataContext = vMOrderListEdit;
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            (this.DataContext as VMOrderListEdit).KeyDownUserControl(e.Key);
        }

        private void dpDateDelivery_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DatePicker picker = sender as DatePicker;
            if (!picker.IsDropDownOpen)
            {
                picker.IsDropDownOpen = true;
            }
        }

        private void dgOrderArticles_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                Convert.ToInt32(e.Text);
            }
            catch
            {
                e.Handled = true;
            }
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;
            int i = dgOrderArticles.SelectedIndex + 1;
            if (i >= dgOrderArticles.Items.Count) i = 0;

            DataGridRow rowContainer = (DataGridRow)dgOrderArticles.ItemContainerGenerator
                .ContainerFromItem(dgOrderArticles.Items[i]);
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = FindVisual.FindVisualChild<DataGridCellsPresenter>(rowContainer);
                int columnIndex = dgOrderArticles.Columns.IndexOf(dgOrderArticles.CurrentColumn);
                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(columnIndex);
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Last);
                /* FocusNavigationDirection.Last is used because the 
                    TextBox I want to focus on is the Last control in that Cell*/
                request.Wrapped = true;
                cell.MoveFocus(request);

                dgOrderArticles.SelectedItem = dgOrderArticles.Items[i];
                e.Handled = true;
                dgOrderArticles.UpdateLayout();
            }
        }
    }
}
