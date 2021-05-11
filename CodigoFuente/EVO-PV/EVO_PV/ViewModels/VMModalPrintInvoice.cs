using EVO_PV.Utilities;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    public class VMModalPrintInvoice : NotifyPropertyChanged
    {
        #region Atributos
        MainWindow PrincipalScreen;
        public ICommand CancelCommand { get; }

        private string consecutive;

        private string numbersCopies;
        #endregion

        #region Propiedades
        public string Consecutive
        {
            get
            {
                return this.consecutive;
            }
            set
            {
                this.consecutive = value;
                this.OnPropertyChanged("Consecutive");
            }
        }

        public string NumbersCopies
        {
            get
            {
                return this.numbersCopies;
            }
            set
            {
                this.numbersCopies = value;
                this.OnPropertyChanged("NumbersCopies");
            }
        }

        #endregion

        #region Constructor
        public VMModalPrintInvoice(MainWindow principalScreen)
        {
            this.PrincipalScreen = principalScreen;
            this.CancelCommand = new RelayCommand(Cancel);
        }
        #endregion

        private void Cancel()
        {
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
            Clean();
        }

        private void Clean()
        {
            NumbersCopies = string.Empty;
            Consecutive = string.Empty;
        }

    }

}
