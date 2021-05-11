using EVO_PV.Models.BusinessObjects;
using EVO_PV.ViewModels;
using System;
using System.Windows.Controls;

namespace EVO_PV.Views
{
    /// <summary>
    /// Lógica de interacción para UCModalEvidenceForm.xaml
    /// </summary>
    public partial class UCModalEvidenceForm : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        private BOArticleReceive ArticleSelected { get; set; }
        private BODeliveryReceiveHeader DeliveryReceiveHeader { get; set; }
        #endregion

        #region
        public VMModalEvidenceForm vMModalEvidenceForm { get { return DataContext as VMModalEvidenceForm; } }
        #endregion

        #region Contructores

        public UCModalEvidenceForm(MainWindow principalScreen, BOArticleReceive ArticleSelected, BODeliveryReceiveHeader bODeliveryReceiveHeader) : this(new VMModalEvidenceForm(principalScreen, ArticleSelected, bODeliveryReceiveHeader))
        {
            this.PrincipalScreen = principalScreen;
            this.ArticleSelected = ArticleSelected;
            this.DeliveryReceiveHeader = bODeliveryReceiveHeader;
        }

        public UCModalEvidenceForm(VMModalEvidenceForm vMModalEvidenceForm)
        {
            InitializeComponent();

            if (vMModalEvidenceForm == null)
            {
                throw new ArgumentNullException("");
            }
            this.DataContext = vMModalEvidenceForm;
        }

        #endregion
    }
}
