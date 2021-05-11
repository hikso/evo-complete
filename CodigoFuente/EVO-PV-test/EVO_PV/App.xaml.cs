using ServiceStack;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace EVO_PV
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            string culture = System.Configuration.ConfigurationManager.AppSettings.Get("CULTURE");
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture);
        }

    }
}
