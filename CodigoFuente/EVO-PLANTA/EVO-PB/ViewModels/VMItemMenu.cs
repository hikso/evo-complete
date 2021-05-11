using EVO_PV;
using EVO_PB.Utilities;
using EVO_PB.Views;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Controls;

namespace EVO_PB.ViewModels
{

    public class VMItemMenu : NotifyPropertyChanged
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        public VMItemMenu(string header, List<VMSubItem> subItems, PackIconKind icon, MainWindow principal)
        {
            Header = header;
            SubItems = subItems;
            Icon = icon;
            this.PrincipalScreen = principal;

        }

        public VMItemMenu(string header, UserControl screen, PackIconKind icon)
        {
            Header = header;
            Screen = screen;
            Icon = icon;
        }

        public string Header { get; private set; }
        public PackIconKind Icon { get; private set; }
        public List<VMSubItem> SubItems { get; private set; }
        public UserControl Screen { get; private set; }

        private VMSubItem selectItemSubmenu { get; set; }
        public VMSubItem SelectItemSubmenu
        {
            get { return selectItemSubmenu; }
            set
            {

                selectItemSubmenu = value;
                OnPropertyChanged("selectItemSubmenu");
                switch (SelectItemSubmenu.Name)
                {
                    case "Inicio":
                        this.PrincipalScreen.ContentPage.Content = new UCDashboard(this.PrincipalScreen);
                        break;

                    case "Alistamiento":
                        this.PrincipalScreen.ContentPage.Content = new UCEnlistment(this.PrincipalScreen);
                        break;                    
                }
            }
        }

    }
}
