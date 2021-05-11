using ServiceStack;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace EVO_PB
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-MX");
        }

    }
}
