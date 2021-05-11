using EVO_PV.Models.BusinessObjects;
using EVO_PV.Services;
using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    public class VMCheckInconsistencies : NotifyPropertyChanged
    {
        #region Constructor

        public VMCheckInconsistencies(MainWindow principalScreen)
        {
            this.PrincipalScreen = principalScreen;
            startDateSelected = string.Empty;
            endDateSelected = string.Empty;
            salePointSelected = string.Empty;

            this.warehouseService = new WareHouseService();
            this.inconsistenciesService = new InconsistenciesService();

            this.GetSalePoints = this.GetSalePointsAsync();
            GetInconsistencies();
            this.CmdViewInconsistencies = new RelayCommand(GetInconsistenciesFilter);
            this.CmdViewDetail = new RelayCommand(RedirectDetail);
        }

        #endregion


        #region Task

        private Task GetSalePoints;

        #endregion


        #region Atributos privados

        private MainWindow PrincipalScreen;

        private string startDateSelected { get; set; }

        private string endDateSelected { get; set; }

        private string salePointSelected { get; set; }

        private InconsistenciesService inconsistenciesService;

        private WareHouseService warehouseService;

        private ObservableCollection<BOInconsistence> inconsistencies { get; set; }

        private BOInconsistence inconsistenceSelected { get; set; }

        private ObservableCollection<BOWareHouse> salePoints { get; set; }

        #endregion


        #region Atributos públicos

        public BOInconsistence InconsistenceSelected
        {
            get { return inconsistenceSelected; }

            set
            {
                this.inconsistenceSelected = value;
                this.OnPropertyChanged("InconsistenceSelected");
            }
        }

        public ObservableCollection<BOInconsistence> Inconsistencies
        {
            get { return inconsistencies; }

            set
            {
                this.inconsistencies = value;
                this.OnPropertyChanged("Inconsistencies");
            }
        }

        public ObservableCollection<BOWareHouse> SalePoints
        {
            get { return salePoints; }

            set
            {
                this.salePoints = value;
                this.OnPropertyChanged("SalePoints");
            }
        }

        public string StartDateSelected
        {
            get
            {
                return this.startDateSelected;
            }
            set
            {
                this.startDateSelected = value;
                this.OnPropertyChanged("StartDateSelected");
            }
        }

        public string EndDateSelected
        {
            get
            {
                return this.endDateSelected;
            }
            set
            {
                this.endDateSelected = value;
                this.OnPropertyChanged("EndDateSelected");
            }
        }

        public string SalePointSelected
        {
            get
            {
                return this.salePointSelected;
            }
            set
            {
                this.salePointSelected = value;
                this.OnPropertyChanged("SalePointSelected");
            }
        }

        #endregion


        #region Comandos

        public ICommand CmdViewInconsistencies { get; }

        public ICommand CmdViewDetail { get; }

        #endregion

        #region Métodos Privados
        public void reloadPage()
        {
            startDateSelected = string.Empty;
            endDateSelected = string.Empty;
            salePointSelected = string.Empty;

            this.GetSalePoints = this.GetSalePointsAsync();
            GetInconsistencies();
        }
        #endregion

        #region Métodos Privados

        private async void GetInconsistencies()
        {
            List<BOInconsistence> boInconsistencies = await this.inconsistenciesService.GetInconsistencies();
            this.Inconsistencies = new ObservableCollection<BOInconsistence>(boInconsistencies);
        }

        private async void GetInconsistenciesFilter()
        {
            if (!string.IsNullOrEmpty(startDateSelected))
            {
                startDateSelected = startDateSelected.Substring(0, 10);
            }

            if (!string.IsNullOrEmpty(endDateSelected))
            {
                endDateSelected = endDateSelected.Substring(0, 10);
            }

            List<BOInconsistence> boInconsistencies = await this.inconsistenciesService.GetInconsistencies(startDateSelected, endDateSelected, salePointSelected);
            this.Inconsistencies = new ObservableCollection<BOInconsistence>(boInconsistencies);
        }

        private async Task GetSalePointsAsync()
        {
            List<BOWareHouse> boSalePoints = await this.warehouseService.GetSalePoints();
            this.SalePoints = new ObservableCollection<BOWareHouse>(boSalePoints);
        }

        private void RedirectDetail()
        {
            this.PrincipalScreen.ContentPage.Content = new UCCheckInconsistenceDetail(this.PrincipalScreen, InconsistenceSelected.InconsistenceId, InconsistenceSelected.RequestNumber, InconsistenceSelected.DeliveryNumber);
        }
        #endregion

    }
}
