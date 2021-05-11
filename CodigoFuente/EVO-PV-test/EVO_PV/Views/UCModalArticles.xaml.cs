using EVO_PV;
using EVO_PV.Interfaces;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para UCModalArticles.xaml
    /// </summary>
    public partial class UCModalArticles : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        #region
        public VMModalArticles vMModalArticles { get { return DataContext as VMModalArticles; } }
        #endregion

        #region Contructores

        public UCModalArticles(MainWindow principalScreen,INotificationVM vm, BOOrderType bOOrderType) : this(new VMModalArticles(principalScreen,vm, bOOrderType))
        {
            this.PrincipalScreen = principalScreen;
        }

        public UCModalArticles(VMModalArticles vMModalArticles)
        {
            InitializeComponent();

            if (vMModalArticles == null)
            {
                throw new ArgumentNullException("");
            }

            this.DataContext = vMModalArticles;
        }

        #endregion
    }
}
