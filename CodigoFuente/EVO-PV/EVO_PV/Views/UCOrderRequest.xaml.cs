using EVO_PV;
using EVO_PV.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using EVO_PV.Utilities;

namespace EVO_PV.Views
{
    /// <summary>
    /// Interaction logic for UCOrderRequest.xaml
    /// </summary>
    public partial class UCOrderRequest : UserControl
    {

        #region Global 
        private MainWindow PrincipalScreen;
        private bool WasEdited { get; set; }
        #endregion

        #region Contructores

        public UCOrderRequest(MainWindow principalScreen) : this(new VMOrderRequest(principalScreen))
        {
            this.PrincipalScreen = principalScreen;
            this.PrincipalScreen.ContentPage.VerticalAlignment = VerticalAlignment.Stretch;
            this.PrincipalScreen.ContentPage.HorizontalAlignment = HorizontalAlignment.Stretch;
            //this.PrincipalScreen.ListMenu.SelectedIndex = 1;
            this.UserControl.Focus();
            dpDateDelivery.Language = XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag);
        }

        #endregion

        /// <summary>
        /// Constructor que recibe como argumento una referencia del view model.
        /// </summary>
        /// <param name="vMOrderRequest"></param>
        public UCOrderRequest(VMOrderRequest vMOrderRequest)
        {
            InitializeComponent();

            if (vMOrderRequest == null)
            {
                throw new ArgumentNullException("");
            }

            this.DataContext = vMOrderRequest;
            dpDateDelivery.Focus();
            this.WasEdited = false;

        }

        public void reloadPage()
        {
            (this.DataContext as VMOrderRequest).reloadPage();
        }

        private void UserControl_KeyDown(object sender,KeyEventArgs e)
        {            
            (this.DataContext as VMOrderRequest).KeyDownUserControl(e.Key);
        }      

        private void dpDateDelivery_GotFocus(object sender, RoutedEventArgs e)
        {
            DatePicker picker = sender as DatePicker;
            if (!picker.IsDropDownOpen)
            {
                picker.IsDropDownOpen = true;
            }
        }

        private void dg_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;
            int i = dgOrderArticles.SelectedIndex+1;
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
