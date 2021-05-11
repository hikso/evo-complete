using EVO_PV.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Windows.Input;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para UCReceive.xaml
    /// </summary>
    public partial class UCReceive : UserControl
    {

        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        #region Contructores

        public UCReceive(MainWindow principalScreen) : this(new VMReceive(principalScreen))
        {
            this.PrincipalScreen = principalScreen;
            this.PrincipalScreen.ContentPage.VerticalAlignment = VerticalAlignment.Stretch;
            this.PrincipalScreen.ContentPage.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        #endregion

        /// <summary>
        /// Constructor que recibe como argumento una referencia del view model.
        /// </summary>
        /// <param name="vMReceive"></param>
        public UCReceive(VMReceive vMReceive)
        {
            InitializeComponent();

            if (vMReceive == null)
            {
                throw new ArgumentNullException("");
            }

            this.DataContext = vMReceive;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = "0";
                textBox.Focus();
                textBox.SelectAll();
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = "0";
            }
            textBox.SelectAll();
        }

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            int i = dgDeliveryArticles.SelectedIndex;
            if (e != null && e.Key == Key.Enter)
            {
                (this.DataContext as VMReceive).QuantityReceive();
                e.Handled = true;
            }
        }

        //private void ConfigurarBasculaPiso()
        //{
        //    #region Adaptador IP Avery
        //    BasculasIPFactory factory = new BasculasIPAveryZM201();
        //    BasculasIPAdapter adapter = factory.GetAdapter();
        //    adapter.ObtenerPeso += AdapterIP_ObtenerPeso;
        //    adapter.AbrirEndPoint("172.50.0.180", 3000);

        //    //Thread.Sleep(10000);
        //    //adapter.CerrarEndPoint();
        //    //adapter.ObtenerPeso -= AdapterIP_ObtenerPeso;

        //    #endregion
        //}

        //private void AdapterIP_ObtenerPeso(object sender, ObtenerPesoIPEventArgs e)
        //{
        //    (this.DataContext as VMReceive).AdapterIP_ObtenerPeso(e.Peso);
        //}
    }
}
