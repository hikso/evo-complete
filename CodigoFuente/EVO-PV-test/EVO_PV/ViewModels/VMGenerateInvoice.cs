using EVO_PV;
using EVO_PV.Enum;
using EVO_PV.Enums;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Services;
using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Configuration;
using EVO_PV.Resources.Dictionaries;
using EVO_PV.Interfaces;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Notifications.Wpf;

namespace EVO_PV.ViewModels
{
    public class VMGenerateInvoice : NotifyPropertyChanged, IConfirmationModal
    {
        #region Constructor

        public VMGenerateInvoice(MainWindow principalScreen)
        {
            this.PrincipalScreen = principalScreen;
            this.DeletedArticles = new ObservableCollection<BOBillingArticle>();
            this.configService = new ConfigService();
            this.customerService = new CustomerService();
            this.wareHouseService = new WareHouseService();
            this.Invoice = new BOInvoice();
            this.billingService = new BillingService();
            this.sellerService = new SellerService();
            this.GetCustomers = this.GetCustomersAsync();
            this.OpenFilterCommand = new RelayCommand(OpenFilterClients);
            this.CmdAddArticle = new RelayCommand(AddArticle);
            this.CmdEditSelectedArticle = new RelayCommand(EditSelectedArticle);
            this.CmdDeleteSelectedArticle = new RelayCommand(DeleteSelectedArticle);
            this.CmdPayment = new RelayCommand(Payment);
            this.CmdCancelPayment = new RelayCommand(CancelPayment);
            this.CmdCell = new RelayCommand(Cell);
            this.WidhtForUserControl = (principalScreen.Width - 260).ToString();
            this.GetSellers = GetSellersAsync();
            this.BagTax = new BOBagTax();
            this.notification = new Notification();
            this.InvoiceDiscountPercent = decimal.Parse(App.Current.Properties[EnumConstanst.INVOICEDISCOUNTPERCENT.ToString()].ToString());
            this.CmdPrintInvoice = new RelayCommand(PrintInvoice);
           
        }

        #endregion

        #region Task

        private Task GetNit;

        private Task GetCustomers;

        private Task GetInvoiceData;

        private Task GetArticles;

        private Task GetSellers;

        #endregion

        #region Atributos privados

        public bool isOpenModalPayment { get; set; }

        private string widhtForUserControl { get; set; }

        private string messageConfirmation { get; set; }

        private string iconName { get; set; }

        private string foreground { get; set; }

        private EnumNamesMethods enumNameMethodYes { get; set; }

        private EnumNamesMethods enumNameMethodNot { get; set; }

        public UCModalConfirmation UCModalConfirmation { get; private set; }
        public UCModalPayment UCModalPayment { get; private set; }
        public UCModalPrintInvoice UCModalPrintInvoice { get; private set; }

        private MainWindow PrincipalScreen;

        private ConfigService configService;

        private CustomerService customerService;

        private WareHouseService wareHouseService;

        private BillingService billingService;

        private SellerService sellerService;

        private BOGeneralParameter nit;

        private bool isAntioquena;

        private ObservableCollection<BOCustomer> customers { get; set; }

        private ObservableCollection<BOBillingArticle> articles { get; set; }

        private ObservableCollection<BOBillingArticle> articlesBackUp { get; set; }

        private string selectedCustomer;

        private bool InternalChange { get; set; }

        private BOBillingArticle selectedArticle;

        private ObservableCollection<BOBillingArticle> selectedArticles { get; set; }

        private ObservableCollection<BOSeller> sellers { get; set; }
        
        private BOSeller sellerSelected { get; set; }

        private ObservableCollection<BOBillingArticle> deletedArticles { get; set; }

        private string codeArticleSearch { get; set; }

        private string nameArticleSearch { get; set; }

        private bool isOpenModalPrintInvoice { get; set; }

        private bool isOpenPopArticle { get; set; }       

        private BOBagTax bagTax { get; set; }

        private decimal invoiceDiscountPercent { get; set; }

        private BOInvoice invoice { get; set; }

        private float quantity { get; set; }

        private decimal bagsQuantity { get; set; }

        private string observation { get; set; }

        private Notification notification;

        #endregion

        #region Atributos públicos
        public string Observation
        {
            get { return this.observation; }
            set
            {
                this.observation = value;
                this.OnPropertyChanged("Observation");
            }
        }

        public decimal InvoiceDiscountPercent
        {
            get { return invoiceDiscountPercent; }
            set
            {
                this.invoiceDiscountPercent = value;
                this.OnPropertyChanged("InvoiceDiscountPercent");
            }
        }

        public BOBagTax BagTax
        {
            get { return bagTax; }
            set
            {
                this.bagTax = value;
                this.OnPropertyChanged("BagTax");
            }
        }        

        public bool IsOpenModalPrintInvoice
        {
            get { return isOpenModalPrintInvoice; }

            set
            {
                this.isOpenModalPrintInvoice = value;

                this.OnPropertyChanged("IsOpenModalPrintInvoice");

            }
        }

        public bool IsOpenModalPayment
        {
            get { return isOpenModalPayment; }

            set
            {
                this.isOpenModalPayment = value;

                this.OnPropertyChanged("IsOpenModalPayment");

            }
        }

        public bool IsOpenPopArticle
        {
            get { return isOpenPopArticle; }

            set
            {
                this.isOpenPopArticle = value;

                this.OnPropertyChanged("IsOpenPopArticle");

            }
        }

        public string MessageConfirmation
        {
            get { return this.messageConfirmation; }
        }

        public string IconName
        {
            get { return this.iconName; }
        }

        public string Foreground
        {
            get { return this.foreground; }
        }

        public string WidhtForUserControl
        {
            get { return widhtForUserControl; }

            set
            {
                this.widhtForUserControl = value;
                this.OnPropertyChanged("WidhtForUserControl");
            }
        }

        public ObservableCollection<BOSeller> Sellers
        {
            get { return sellers; }
            set
            {
                this.sellers = value;
                this.OnPropertyChanged("Sellers");
            }
        }

        public BOSeller SellerSelected
        {
            get { return sellerSelected; }
            set
            {
                this.sellerSelected = value;
                this.OnPropertyChanged("SellerSelected");
            }
        }


        public ObservableCollection<BOCustomer> Customers
        {
            get { return customers; }

            set
            {
                this.customers = value;
                this.OnPropertyChanged("Customers");
            }
        }

        public ObservableCollection<BOBillingArticle> ArticlesBackUp
        {
            get { return articlesBackUp; }

            set
            {
                this.articlesBackUp = value;
                this.OnPropertyChanged("ArticlesBackUp");
            }
        }
        public string NameArticleSearch
        {
            get { return nameArticleSearch; }

            set
            {
                this.nameArticleSearch = value;
                if (this.nameArticleSearch == "")
                {
                    this.SelectedArticle = null;
                    return;
                }

                if (!InternalChange)
                {
                    SearchArticles(EnumFieldsFindArticles.Code);
                }

                this.OnPropertyChanged("NameArticleSearch");

            }
        }

        public string CodeArticleSearch
        {
            get { return codeArticleSearch; }

            set
            {
                this.codeArticleSearch = value;

                if (this.codeArticleSearch == "")
                {
                    this.SelectedArticle = null;
                    return;
                }

                if (!InternalChange)
                {
                    SearchArticles(EnumFieldsFindArticles.Code);
                }

                this.OnPropertyChanged("CodeArticleSearch");

            }
        }


        public ObservableCollection<BOBillingArticle> Articles
        {
            get { return articles; }

            set
            {
                this.articles = value;
                this.OnPropertyChanged("Articles");
            }
        }
        /// <summary>
        /// Propiedades del contrato de IConfirmationModal
        /// </summary>
        public EnumNamesMethods EnumNameMethodYes
        {
            get { return this.enumNameMethodYes; }
        }

        public EnumNamesMethods EnumNameMethodNot
        {
            get { return this.enumNameMethodNot; }
        }

        public string SelectedCustomer
        {
            get { return selectedCustomer; }

            set
            {
                this.selectedCustomer = value;
                this.isAntioquena = (this.selectedCustomer == this.nit.Valor);

                this.OnPropertyChanged("SelectedCustomer");
                this.OnPropertyChanged("IsAntioquena");
            }
        }
        public BOInvoice Invoice
        {
            get { return invoice; }
            set
            {
                this.invoice = value;
                this.Invoice.TotalBeforeDiscount = 0;
                if (this.SelectedArticles != null)
                {
                    foreach (BOBillingArticle item in this.SelectedArticles)
                    {
                        this.Invoice.TotalBeforeDiscount += item.Total;
                    }
                }
                this.OnPropertyChanged("Invoice");
            }
        }

        public void Cell()
        {
            this.Invoice.TotalBeforeDiscount = 0;
            this.Invoice.TaxValue = 0;
            if (this.SelectedArticles != null)
            {
                foreach (BOBillingArticle item in this.SelectedArticles)
                {
                    this.Invoice.TotalBeforeDiscount += item.Total;
                    this.Invoice.TaxValue += item.TotalIVA;
                }
            }
            this.Invoice.TaxValue += float.Parse(this.Invoice.BagsTotalValue.ToString());
            this.Invoice.TotalInvoice = this.Invoice.TotalBeforeDiscount - (
                    (float.Parse(this.InvoiceDiscountPercent.ToString()) / 100) * this.Invoice.TotalBeforeDiscount
                ) + this.Invoice.TaxValue;
        }

        public float Quantity
        {
            get { return quantity; }
            set
            {
                this.quantity = value;
                this.Invoice.TotalBeforeDiscount = 0;
                this.Invoice.TaxValue = 0;
                if (this.selectedArticle != null)
                {
                    this.SelectedArticle.Quantity = Quantity;
                }

                if (this.SelectedArticles != null)
                {
                    foreach (BOBillingArticle item in this.SelectedArticles)
                    {
                        this.Invoice.TotalBeforeDiscount += item.Total;
                        this.Invoice.TaxValue += item.TotalIVA;
                    }
                }

                this.Invoice.TaxValue += float.Parse(this.Invoice.BagsTotalValue.ToString());
                this.Invoice.TotalInvoice = this.Invoice.TotalBeforeDiscount - (
                        (float.Parse(this.InvoiceDiscountPercent.ToString()) / 100) * this.Invoice.TotalBeforeDiscount
                    ) + this.Invoice.TaxValue;
                this.OnPropertyChanged("Quantity");
            }
        }
        public decimal BagsQuantity
        {
            get { return bagsQuantity; }
            set
            {
                this.bagsQuantity = value;
                this.Invoice.BagsQuantity = BagsQuantity;
                this.Invoice.TaxValue = 0;
                if (this.SelectedArticles != null)
                {
                    foreach (BOBillingArticle item in this.SelectedArticles)
                    {
                        this.Invoice.TaxValue += item.TotalIVA;
                    }
                }

                this.Invoice.TaxValue += float.Parse(this.Invoice.BagsTotalValue.ToString());

                this.Invoice.TotalInvoice = this.Invoice.TotalBeforeDiscount - (
                        (float.Parse(this.InvoiceDiscountPercent.ToString()) / 100) * this.Invoice.TotalBeforeDiscount
                    ) + this.Invoice.TaxValue;
                this.OnPropertyChanged("BagsQuantity");
            }
        }
        public BOBillingArticle SelectedArticle
        {
            get { return selectedArticle; }

            set
            {
                this.selectedArticle = value;
                this.IsOpenPopArticle = false;
                this.IsOpenPopArticle = false;
                if (selectedArticle != null)
                {
                    InternalChange = true;
                    this.NameArticleSearch = selectedArticle.Name;
                    this.CodeArticleSearch = selectedArticle.Code;
                    this.Quantity = 0;
                    InternalChange = false;
                }
                else
                {
                    InternalChange = true;
                    this.NameArticleSearch = null;
                    this.CodeArticleSearch = null;
                    this.Quantity = 0;
                    InternalChange = false;
                }

                this.OnPropertyChanged("SelectedArticle");
            }
        }

        public bool IsAntioquena
        {
            get { return isAntioquena; }

            set
            {
                this.isAntioquena = value;
                this.OnPropertyChanged("IsAntioquena");
            }
        }

        public string DateTimeNow
        {
            get { return DateTime.Now.ToString("dd/MM/yyyy"); }
        }

        public ObservableCollection<BOBillingArticle> SelectedArticles
        {
            get { return selectedArticles; }
            set
            {
                this.selectedArticles = value;
                this.OnPropertyChanged("SelectedArticles");
            }
        }

        public ObservableCollection<BOBillingArticle> DeletedArticles
        {
            get { return deletedArticles; }
            set
            {
                this.deletedArticles = value;
                this.OnPropertyChanged("DeletedArticles");
            }
        }
        #endregion

        #region Comandos

        public ICommand Cmd { get; }

        public ICommand OpenFilterCommand { get; }

        public ICommand CmdAddArticle { get; }

        public ICommand CmdEditSelectedArticle { get; }

        public ICommand CmdDeleteSelectedArticle { get; }

        public ICommand CmdPayment { get; }

        public ICommand CmdCancelPayment { get; }

        public ICommand CmdCell { get; }
        


        public ICommand CmdPrintInvoice { get; }
     

        #endregion

        #region Métodos Privados

        public void OpenFilterClients()
        {
            this.PrincipalScreen.ModalContainer.Content = new UCModalClientFilter(this.PrincipalScreen, this);
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
        }

        public void OpenFilterArticles()
        {
            this.PrincipalScreen.ModalContainer.Content = new UCModalArticleFilter(this.PrincipalScreen, this);
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
        }

        private async Task GetNitAsync()
        {
            this.nit = await this.configService.GetParameterByName("NIT_DEFECTO_FACTURACION");
            this.SelectedCustomer = this.nit.Valor;
            this.GetArticles = this.GetArticlesAsync();
            this.isAntioquena = true;
        }

        private async Task GetCustomersAsync()
        {
            List<BOCustomer> lstCusotmers = await this.customerService.GetCustomers();
            this.Customers = new ObservableCollection<BOCustomer>(lstCusotmers);
            this.GetNit = this.GetNitAsync();
        }

        private async Task GetArticlesAsync()
        {
            string codePontOfSale = ConfigurationManager.AppSettings[EnumConstanst.CODIGO_PUNTO_VENTA.ToString()];
            List<BOBillingArticle> lstArticles = await this.billingService.GetArticles(codePontOfSale, SelectedCustomer);

            this.Articles = new ObservableCollection<BOBillingArticle>(lstArticles);
            this.ArticlesBackUp = new ObservableCollection<BOBillingArticle>(lstArticles);
        }

        /// <summary>
        /// Método que obtiene los vendedores de forma asíncrona
        /// </summary>  
        public async Task GetSellersAsync()
        {
            List<BOSeller> bOSellers = await this.sellerService.GetSellers();

            this.Sellers = new ObservableCollection<BOSeller>(bOSellers);
        }

        private void AddArticle()
        {
            if (this.SelectedArticles == null) this.SelectedArticles = new ObservableCollection<BOBillingArticle>();
            if (this.SelectedArticle == null) return;
            if (string.IsNullOrEmpty(this.SelectedArticle.UnitPrice) || double.Parse(this.SelectedArticle.UnitPrice)<=0)
            {
                this.notification.Show(DictMessages.Warning, DictMessages.ErrorAlAgregarArticuloSinPrecioUnitario, NotificationType.Error);
                return;
            }
            if (float.Parse(this.SelectedArticle.Stock) == 0)
            {
                this.notification.Show(DictMessages.Warning, DictMessages.ErrorAlAgregarArticuloSinStock, NotificationType.Error);
                return;
            }
            if(this.selectedArticles.Where(x => x.Code == this.SelectedArticle.Code).FirstOrDefault() != null)
            {
                this.notification.Show(DictMessages.Warning, DictMessages.ErrorAlAgregarArticuloExistente, NotificationType.Error);
                return;
            }
            string codePontOfSale = ConfigurationManager.AppSettings[EnumConstanst.CODIGO_PUNTO_VENTA.ToString()];
            this.selectedArticle.WarehouseCode = (string)codePontOfSale;
            this.selectedArticle.IsDeleted = false;
            this.SelectedArticles.Add(this.selectedArticle);
            this.Invoice.TotalBeforeDiscount = 0;

            if (this.SelectedArticles != null)
            {
                foreach (BOBillingArticle item in this.SelectedArticles)
                {
                    this.Invoice.TaxValue += item.TotalIVA;
                }
            }

            this.Invoice.TaxValue += float.Parse(this.Invoice.BagsTotalValue.ToString());

            this.Invoice.TotalInvoice = this.Invoice.TotalBeforeDiscount - (
                    (float.Parse(this.InvoiceDiscountPercent.ToString()) / 100) * this.Invoice.TotalBeforeDiscount
                ) + this.Invoice.TaxValue;

            this.CodeArticleSearch = null;
            this.NameArticleSearch = null;
            this.SelectedArticle = null;
        }

        private void EditSelectedArticle()
        {
            BOBillingArticle boArticle = this.SelectedArticles.Where(x => x.Code == this.selectedArticle.Code).First();
            boArticle = this.selectedArticle;
        }   

        private void DeleteSelectedArticle()
        {

            this.messageConfirmation = DictMessages.ConfirmarEliminarArticulo; //DictMessages
            this.iconName = DictIcons.Backup;//DictIcons
            this.foreground = DictColors.Warning;//DictColors
            UCModalConfirmation = new UCModalConfirmation(this);
            this.PrincipalScreen.ModalContainer.Content = UCModalConfirmation;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
        }

        private void PrintInvoice()
        {
            UCModalPrintInvoice = new UCModalPrintInvoice(PrincipalScreen);
            this.PrincipalScreen.ModalContainer.Content = UCModalPrintInvoice;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
            this.PrincipalScreen.ModalPrincipal.CloseOnClickAway = false;

            this.IsOpenModalPrintInvoice = true;
        }      

        private void Payment()
        {
            if (SelectedArticles == null)
            {
                this.notification.Show(DictMessages.Warning, DictMessages.ErrorSinArticulosParaFacturar, NotificationType.Error);
                return;
            }
            else {

                if (SelectedArticles.Count() == 0)
                {
                    this.notification.Show(DictMessages.Warning, DictMessages.ErrorSinArticulosParaFacturar, NotificationType.Error);
                    return;
                }
            }


            foreach (BOBillingArticle item in SelectedArticles)
            {
                if (item.Quantity <= 0)
                {
                    this.notification.Show(DictMessages.Warning, DictMessages.ErrorAlGuardarFacturaArticuloSinCantidad, NotificationType.Error);
                    return;
                }
            }

            if (SellerSelected == null)
            {
                this.notification.Show(DictMessages.Warning, DictMessages.ErrorDebeSeleccionarUnVendedor, NotificationType.Error);
                return;
            }

            BOGenerateInvoice bOGenerateInvoice = new BOGenerateInvoice();
            bOGenerateInvoice.Articles = new List<BOBillingArticle>(this.SelectedArticles);
            bOGenerateInvoice.BagsQuantity = int.Parse(BagsQuantity.ToString());
            bOGenerateInvoice.ClientId = SelectedCustomer;
            bOGenerateInvoice.Observations = Observation;
            string codePontOfSale = ConfigurationManager.AppSettings[EnumConstanst.CODIGO_PUNTO_VENTA.ToString()];
            bOGenerateInvoice.SalePointId = (string)codePontOfSale;
            bOGenerateInvoice.SellerId = SellerSelected.SellerId;
            bOGenerateInvoice.TaxValue = (int)Convert.ToDouble(this.Invoice.TaxValue);
            bOGenerateInvoice.TotalBeforeDiscount = this.Invoice.TotalBeforeDiscount;
            bOGenerateInvoice.TotalDocument = this.invoice.TotalInvoice;
            bOGenerateInvoice.TypeBasculeId = 1;

            UCModalPayment = new UCModalPayment(PrincipalScreen, bOGenerateInvoice);
            this.PrincipalScreen.ModalContainer.Content = UCModalPayment;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
            this.PrincipalScreen.ModalPrincipal.CloseOnClickAway = false;

            this.IsOpenModalPayment = true;
        }

        private void CancelPayment()
        {
            this.IsOpenModalPayment = false;
        }


        public void ExecuteConfirmationYes()
        {
            this.DeletedArticles.Add(this.SelectedArticle);
            this.SelectedArticles.Remove(this.SelectedArticle);
            this.SelectedArticle = null;
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }

        public void ExecuteConfirmationNot()
        {
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }

        private void EmptyFieldsFindArticle()
        {
            //this.QuantityArticleSearch = 0;
            //this.StateArticleIdSearch = 0;
            //this.UnitMeasureArticleSearch = string.Empty;
            //this.SuggestedOrderArticleSearch = string.Empty;
            //this.MinimumArticleSearch = string.Empty;
            //this.StockArticleSearch = string.Empty;
            //this.MaximumArticleSearch = string.Empty;
        }

        private void SearchArticles(EnumFieldsFindArticles enumFieldsFindArticles)
        {
            this.IsOpenPopArticle = false;
            this.IsOpenPopArticle = false;
            this.EmptyFieldsFindArticle();
            this.Articles = this.ArticlesBackUp;

            if (this.ArticlesBackUp == null)
            {
                    return;
            }
            switch (enumFieldsFindArticles)
            {
                case EnumFieldsFindArticles.Name:
                    if (NameArticleSearch == null || NameArticleSearch == "")
                    {
                        return;
                    }
                    this.Articles = new ObservableCollection<BOBillingArticle>(this.articles.Where(x => EF.Functions.Like(x.Name.ToUpper(), $"%{this.NameArticleSearch.ToUpper()}%")).ToList());

                    if (this.Articles.Count == 0)
                    {
                        return;
                    }

                    this.IsOpenPopArticle = true;

                    break;

                case EnumFieldsFindArticles.Code:
                    if (CodeArticleSearch == null || CodeArticleSearch == "")
                    {
                        return;
                    }
                    this.Articles = new ObservableCollection<BOBillingArticle>(this.articles.Where(x => EF.Functions.Like(x.Code.ToUpper(), $"%{this.CodeArticleSearch.ToUpper()}%")).ToList());

                    if (this.Articles.Count == 0)
                    {
                        return;
                    }

                    this.IsOpenPopArticle = true;

                    break;
            }
        }
        #endregion
    }
}
