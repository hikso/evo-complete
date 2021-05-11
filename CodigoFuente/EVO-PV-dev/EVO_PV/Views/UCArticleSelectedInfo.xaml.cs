using EVO_PV.Models.BusinessObjects;
using EVO_PV.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para UCArticleSelectedInfo.xaml
    /// </summary>
    public partial class UCArticleSelectedInfo : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        #region
        public VMArticleSelectedInfo vMArticleSelectedInfo { get { return DataContext as VMArticleSelectedInfo; } }
        #endregion

        #region Contructores

        public UCArticleSelectedInfo(MainWindow principalScreen, BOArticleReceive bOArticleReceive) : this(new VMArticleSelectedInfo(principalScreen, bOArticleReceive))
        {
            this.PrincipalScreen = principalScreen;
        }

        public UCArticleSelectedInfo(VMArticleSelectedInfo vMArticleSelectedInfo)
        {
            InitializeComponent();

            if (vMArticleSelectedInfo == null)
            {
                throw new ArgumentNullException("");
            }

            this.DataContext = vMArticleSelectedInfo;
        }

        #endregion
    }
}
