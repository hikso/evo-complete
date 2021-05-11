using EVO_PV;
using EVO_PV.Interfaces;
using EVO_PV.Utilities;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    public class VMCustomMessages : NotifyPropertyChanged
    {
        #region Atributos        
        private MainWindow PrincipalScreen;
        public ICommand ConfirmationYesCommand { get; }
        public ICommand ConfirmationNotCommand { get; }

        private IConfirmationModal viewModel = null;
        private string iconName { get; set; }

        private string messageConfirmation;
        private string foreground { get; set; }
        private bool showSpinner { get; set; }
        #endregion

        #region Propiedades
        public string IconName
        {
            get { return iconName; }
            set
            {
                this.iconName = value;
                this.OnPropertyChanged("IconName");
            }
        }

        public bool ShowSpinner
        {
            get { return showSpinner; }
            set
            {
                this.showSpinner = value;
                this.OnPropertyChanged("ShowSpinner");
            }
        }

        public string MessageConfirmation
        {
            get { return messageConfirmation; }
            set
            {
                this.messageConfirmation = value;
                this.OnPropertyChanged("MessageConfirmation");
            }
        }

        public string Foreground
        {
            get { return foreground; }
            set
            {
                this.foreground = value;
                this.OnPropertyChanged("Foreground");
            }
        }
        #endregion

        #region Contructores

        public VMCustomMessages(IConfirmationModal viewModel)
        {
            this.viewModel = viewModel;
            this.ConfirmationYesCommand = new RelayCommand(ConfirmationYes);
            this.ConfirmationNotCommand = new RelayCommand(ConfirmationNot);
            this.IconName = viewModel.IconName;
            this.MessageConfirmation = viewModel.MessageConfirmation;
            this.Foreground = viewModel.Foreground;

        }

        #endregion

        #region Métodos
        private void ConfirmationYes()
        {
            viewModel.ExecuteConfirmationYes();
        }

        private void ConfirmationNot()
        {
            viewModel.ExecuteConfirmationNot();
        }

        #endregion
    }
}
