using EVO_PV.Interfaces;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Services;
using EVO_PV.Utilities;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    public class VMModalPayment : NotifyPropertyChanged
    {
        #region Atributos Públicos
        
        MainWindow PrincipalScreen;
        

        #endregion
        #region Constructor
        public VMModalPayment(MainWindow principalScreen, BOGenerateInvoice bOGenerateInvoice)
        {
            this.GenerateInvoice = bOGenerateInvoice;
            this.PrincipalScreen = principalScreen;
            this.CmdCancelPayment = new RelayCommand(CancelPayment);
            this.CmdSavePayment = new RelayCommand(SavePayment);
            this.CmdAddOtherFormPayment = new RelayCommand(AddOtherFormPayment);
            this.billingService = new BillingService();
            this.GetPaymentWays = GetPaymentWaysAsync();
            this.GetBanks = GetBanksAsync();
            this.PaymentWaysAdded = new ObservableCollection<BOPaymentWayStructure>();
        }
        #endregion

        #region Comandos

        public ICommand CmdCancelPayment { get; }

        public ICommand CmdSavePayment { get; }

        public ICommand CmdAddOtherFormPayment { get; }

        #endregion

        #region Task

        private Task GetPaymentWays;

        private Task GetBanks;

        #endregion

        #region Atributos Privados
        private BillingService billingService;

        private ObservableCollection<BOPayWays> paymentWays { get; set; }

        private ObservableCollection<BOBank> banks { get; set; }

        private BOPayWays selectedPaymentWay { get; set; }
        
        private BOGenerateInvoice generateInvoice { get; set; }

        private ObservableCollection<BOPaymentWayStructure> paymentWaysAdded { get; set; }

        private int totalCash { get; set; }

        private int totalReceived { get; set; }

        private float returned { get; set; }
        #endregion

        #region Métodos Privados
        private void CancelPayment()
        {
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }

        private void SavePayment()
        {
            this.GenerateInvoice.PaymentWays = new List<BOPaymentWayStructure>();

            if (this.TotalCash > 0)
            {
                BOPaymentWayStructure bOPaymentWayStructure = new BOPaymentWayStructure();
                bOPaymentWayStructure.BankId = 0;
                bOPaymentWayStructure.ConsecutiveBond = null;
                bOPaymentWayStructure.EmployeeBond = null;
                bOPaymentWayStructure.PaymentValue = this.TotalCash;
                bOPaymentWayStructure.PaymentWayId = 1;
                bOPaymentWayStructure.PaymentName = "Efectivo";
                this.GenerateInvoice.PaymentWays.Add(bOPaymentWayStructure);
            }
            if (this.PaymentWaysAdded != null)
            {
                this.GenerateInvoice.PaymentWays.AddRange(this.PaymentWaysAdded);
            }
            this.billingService.GenerateInvoice(GenerateInvoice);
        }

        private void AddOtherFormPayment()
        {
            BOPaymentWayStructure bOPaymentWayStructure = new BOPaymentWayStructure();
            bOPaymentWayStructure.BankId = 0;
            bOPaymentWayStructure.ConsecutiveBond = null;
            bOPaymentWayStructure.EmployeeBond = null;
            bOPaymentWayStructure.PaymentValue = 0;
            bOPaymentWayStructure.PaymentWayId = 0;
            bOPaymentWayStructure.PaymentName = SelectedPaymentWay.Name;
            switch (SelectedPaymentWay.Id)
            {
                case 2:
                    bOPaymentWayStructure.HasBank = true;
                    break;
                case 3:
                    bOPaymentWayStructure.HasBank = true;
                    break;
                case 4:
                    bOPaymentWayStructure.HasConsecutiveBond = true;
                    break;
                default:
                    break;
            }
            this.PaymentWaysAdded.Add(bOPaymentWayStructure);
        }

        #endregion

        #region Atributos Públicos
        public int TotalCash
        {
            get { return totalCash; }
            set
            {
                this.totalCash = value;
                this.TotalReceived = this.TotalCash;
                this.Returned = this.TotalCash - this.GenerateInvoice.TotalDocument;
                this.OnPropertyChanged("TotalCash");
            }
        }

        public int TotalReceived
        {
            get { return this.totalReceived; }
            set
            {
                this.totalReceived = value;
                this.OnPropertyChanged("TotalReceived");
            }
        }

        public float Returned
        {
            get { return this.returned; }
            set
            {
                this.returned = value;
                this.OnPropertyChanged("Returned");
            }
        }

        public BOGenerateInvoice GenerateInvoice
        {
            get { return generateInvoice; }
            set
            {
                this.generateInvoice = value;
                this.OnPropertyChanged("GenerateInvoice");
            }
        }

        public ObservableCollection<BOBank> Banks
        {
            get { return this.banks; }
            set
            {
                this.banks = value;
                this.OnPropertyChanged("Banks");
            }
        }
        
        public ObservableCollection<BOPayWays> PaymentWays
        {
            get { return this.paymentWays; }
            set
            {
                this.paymentWays = value;
                this.OnPropertyChanged("PaymentWays");
            }
        }
        
        public ObservableCollection<BOPaymentWayStructure> PaymentWaysAdded
        {
            get { return this.paymentWaysAdded; }
            set
            {
                this.paymentWaysAdded = value;
                this.OnPropertyChanged("PaymentWaysAdded");
            }
        }
        
        public BOPayWays SelectedPaymentWay
        {
            get { return this.selectedPaymentWay; }
            set
            {
                this.selectedPaymentWay = value;
                this.OnPropertyChanged("SelectedPaymentWay");
            }
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Método que obtiene los vendedores de forma asíncrona
        /// </summary>  
        public async Task GetPaymentWaysAsync()
        {
            List<BOPayWays> bOPayWays = await this.billingService.GetPaymentWays();

            this.PaymentWays = new ObservableCollection<BOPayWays>(bOPayWays);
            ///Removemos la forma de pago en efectivo
            BOPayWays itemToRemove = PaymentWays.Where(r => r.Id == 1).FirstOrDefault();
            PaymentWays.Remove(itemToRemove);
        }

        /// <summary>
        /// Método que obtiene los vendedores de forma asíncrona
        /// </summary>  
        public async Task GetBanksAsync()
        {
            List<BOBank> bOBanks = await this.billingService.GetBanks();

            this.Banks = new ObservableCollection<BOBank>(bOBanks);
        }

        #endregion
    }
}
