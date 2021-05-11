using EVO_PV.Models.BusinessObjects;
using EVO_PV.ViewModels;
using System;
using System.Windows.Controls;

namespace EVO_PV.Views
{
    public partial class UCModalBoxSetting : UserControl
    {
        #region Global 
        private MainWindow PrincipalScreen;
        #endregion

        #region
        public VMModalEvidenceForm vMModalEvidenceForm { get { return DataContext as VMModalEvidenceForm; } }
        #endregion

        #region Contructores

        public UCModalBoxSetting(MainWindow principalScreen) : this(new VMModalBoxSetting(principalScreen))
        {

        }

        public UCModalBoxSetting(VMModalBoxSetting vMModalBoxSetting)
        {
            InitializeComponent();

            if (vMModalBoxSetting == null)
            {
                throw new ArgumentNullException("");
            }
            this.DataContext = vMModalBoxSetting;
        }

        #endregion
    }
}
