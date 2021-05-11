using EVO_PV.Models.BusinessObjects;
using EVO_PV.Services;
using EVO_PV.Utilities;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    public class VMModalClientFilter : NotifyPropertyChanged
    {
        private CustomerService customerService;
        private ObservableCollection<BOCustomer> externalClients { get; set; }
        private ObservableCollection<BOCustomer> restoreClients { get; set; }
        private string filterIdentification { get; set; }
        private string filterName { get; set; }
        private BOCustomer customer { get; set; }
        public ICommand SendUserCommand { get; }
        public ICommand CancelCommand { get; }
        public MainWindow PrincipalScreen;
        public VMGenerateInvoice VMGenerateInvoice;

        public ObservableCollection<BOCustomer> ExternalClients
        {
            get { return externalClients; }

            set
            {
                this.externalClients = value;
                this.OnPropertyChanged("ExternalClients");
            }
        }
        public ObservableCollection<BOCustomer> RestoreClients
        {
            get { return restoreClients; }

            set
            {
                this.restoreClients = value;
                this.OnPropertyChanged("RestoreClients");
            }
        }

        public string FilterIdentification
        {
            get { return filterIdentification; }
            set
            {
                filterIdentification = value;
                this.Filters();
                this.OnPropertyChanged("FilterIdentification");
            }
        }
        public BOCustomer Customer
        {
            get
            {
                return customer;
            }
            set
            {
                customer = value;
                this.OnPropertyChanged("Customer");
            }
        }
        public string FilterName
        {
            get { return filterName; }
            set
            {
                filterName = value;
                this.Filters();
                this.OnPropertyChanged("FilterName");
            }
        }

        public VMModalClientFilter(MainWindow principalScreen, VMGenerateInvoice vMGenerateInvoice)
        {
            this.customerService = new CustomerService();
            this.GetCustomers = this.GetCustomersAsync();
            this.SendUserCommand = new RelayCommand(SendUser);
            this.CancelCommand = new RelayCommand(Cancel);
            PrincipalScreen = principalScreen;
            VMGenerateInvoice = vMGenerateInvoice;
        }

        #region Task

        private Task GetCustomers;

        #endregion
        private void Filters()
        {
            this.ExternalClients = RestoreClients;

            if (!string.IsNullOrEmpty(this.FilterIdentification))
            {
                this.ExternalClients = new ObservableCollection<BOCustomer>(
                    this.ExternalClients.Where(a => EF.Functions.Like(a.Identification.ToUpper(), $"%{this.FilterIdentification.ToUpper()}%")).ToList()
                );
            }

            if (!string.IsNullOrEmpty(this.FilterName))
            {
                this.ExternalClients = new ObservableCollection<BOCustomer>(
                    this.ExternalClients.Where(a => EF.Functions.Like(a.Name.ToUpper(), $"%{this.FilterName.ToUpper()}%")).ToList()
                );
            }

            this.ExternalClients.OrderBy(a => a.Identification);
        }
        public void SendUser()
        {
            this.VMGenerateInvoice.SelectedCustomer = this.Customer.Identification;
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }
        public void Cancel()
        {
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }
        private async Task GetCustomersAsync()
        {
            List<BOCustomer> lstCusotmers = await this.customerService.GetCustomers();
            this.ExternalClients = new ObservableCollection<BOCustomer>(lstCusotmers);
            this.RestoreClients = new ObservableCollection<BOCustomer>(lstCusotmers);
        }
    }
}
