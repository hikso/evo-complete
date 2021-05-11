using EVO_PV;
using EVO_PB.Interfaces;
using EVO_PB.Utilities;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace EVO_PB.ViewModels
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 15-Ene/2019
    /// Descripción      : Esta clase implementa el View Model del modal de confirmación
    /// </summary>
    public class VMModalConfirmation : NotifyPropertyChanged
    {
        #region Atributos        
        private MainWindow PrincipalScreen;      
        public ICommand ConfirmationYesCommand { get; }
        public ICommand ConfirmationNotCommand { get; }

        private IConfirmationModal viewModel = null;
        private string iconName { get; set; }

        private string messageConfirmation;
        private string foreground { get; set; }
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

        public VMModalConfirmation(IConfirmationModal viewModel)
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
