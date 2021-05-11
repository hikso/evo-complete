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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using EVO_PV;
using EVO_PV.ViewModels;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para UCCheckInconsistencies.xaml
    /// </summary>
    public partial class UCCheckInconsistencies : UserControl
    {
        private MainWindow PrincipalScreen;

        public UCCheckInconsistencies(MainWindow principalScreen) : this(new VMCheckInconsistencies(principalScreen))
        {
            this.PrincipalScreen = principalScreen;
            this.PrincipalScreen.ContentPage.VerticalAlignment = VerticalAlignment.Stretch;
            this.PrincipalScreen.ContentPage.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        public UCCheckInconsistencies(VMCheckInconsistencies vMCheckInconsitencies)
        {
            InitializeComponent();
            this.DataContext = vMCheckInconsitencies;
        }

        public void reloadPage()
        {
            dpStartDate.Language = XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag);
            dpEndDate.Language = XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag);
            (this.DataContext as VMCheckInconsistencies).reloadPage();
        }
    }
}
