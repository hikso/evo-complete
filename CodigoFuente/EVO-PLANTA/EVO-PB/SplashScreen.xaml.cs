using EVO_PB.Utilities;
using System;
using System.Windows;
using System.Windows.Threading;

namespace EVO_PV
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {

        #region Atributos Privados
        private DispatcherTimer dispatcherTimer;
        #endregion

        #region Contructores
        public SplashScreen()
        {
            InitializeComponent();         

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(HideSplash);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        #endregion

        #region Métodos
        private void HideSplash(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            dispatcherTimer.Stop();
            this.Close();
        }

        #endregion
    }
}
