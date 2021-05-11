using EVO_PV.Enums;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Resources.Dictionaries;
using EVO_PV.Services;
using EVO_PV.Utilities;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    public class VMModalArticleFilter : NotifyPropertyChanged
    {

        #region Atributos privados
        private BillingService billingService;
        private ObservableCollection<BOBillingArticle> articles { get; set; }
        private ObservableCollection<BOBillingArticle> restoreArticles { get; set; }
        private string filterName { get; set; }
        private string filterArticleCode { get; set; }
        private string filterStock { get; set; }
        private string filterUnitMeasure { get; set; }
        private ObservableCollection<BOBillingArticle>  articlesSelected { get; set; }
        private Notification notification;
        #endregion

        #region Atributos publicos
        public MainWindow PrincipalScreen;
        public VMGenerateInvoice VMGenerateInvoice;

        public ObservableCollection<BOBillingArticle> Articles
        {
            get { return articles; }

            set
            {
                this.articles = value;
                this.OnPropertyChanged("Articles");
            }
        }
        
        public string FilterArticleCode
        {
            get { return filterArticleCode; }
            set
            {
                filterArticleCode = value;
                this.Filters();
                this.OnPropertyChanged("FilterArticleCode");
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

        public string FilterStock
        {
            get { return filterStock; }
            set
            {
                filterStock = value;
                this.Filters();
                this.OnPropertyChanged("FilterStock");
            }
        }

        public string FilterUnitMeasure
        {
            get { return filterUnitMeasure; }
            set
            {
                filterUnitMeasure = value;
                this.Filters();
                this.OnPropertyChanged("FilterUnitMeasure");
            }
        }
        
        public ObservableCollection<BOBillingArticle> RestoreArticles
        {
            get { return restoreArticles; }

            set
            {
                this.restoreArticles = value;
                this.OnPropertyChanged("RestoreArticles");
            }
        }

        public ObservableCollection<BOBillingArticle> ArticlesSelected
        {
            get { return articlesSelected; }

            set
            {
                this.articlesSelected = value;
                this.OnPropertyChanged("ArticlesSelected");
            }
        }
        
        #endregion
        #region Commands
        public ICommand CmdAddArticles { get; }
        public ICommand CmdCancel { get; }
        #endregion
        #region Task
        private Task GetArticles;
        #endregion
        #region Constructor
        public VMModalArticleFilter(MainWindow principalScreen, VMGenerateInvoice vMGenerateInvoice)
        {
            PrincipalScreen = principalScreen;
            VMGenerateInvoice = vMGenerateInvoice;
            this.billingService = new BillingService();
            this.GetArticles = this.GetArticlesAsync();

            this.CmdAddArticles = new RelayCommand(AddArticles);
            this.CmdCancel = new RelayCommand(Cancel);
            this.notification = new Notification();
        }
        #endregion
        #region Privete Methods
        private async Task GetArticlesAsync()
        {
            string codePontOfSale = ConfigurationManager.AppSettings[EnumConstanst.CODIGO_PUNTO_VENTA.ToString()];
            List<BOBillingArticle> bOBillingArticles = await this.billingService.GetArticles(codePontOfSale, VMGenerateInvoice.SelectedCustomer);
            this.Articles = new ObservableCollection<BOBillingArticle>(bOBillingArticles);
            this.RestoreArticles = new ObservableCollection<BOBillingArticle>(bOBillingArticles);
        }
        private void AddArticles()
        {
            if (this.VMGenerateInvoice.SelectedArticles == null) this.VMGenerateInvoice.SelectedArticles = new ObservableCollection<BOBillingArticle>();
            foreach (var Article in ArticlesSelected)
            {
                if (float.Parse(Article.Stock) <= 0)
                {
                    this.notification.Show(DictMessages.Warning, DictMessages.ErrorAlAgregarArticuloSinStock, NotificationType.Error);
                    continue;
                }
                this.VMGenerateInvoice.SelectedArticles.Add(Article);
            }
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }
        private void Cancel()
        {
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }
        private void Filters()
        {
            this.Articles = RestoreArticles;

            if (!string.IsNullOrEmpty(this.FilterName))
            {
                this.Articles = new ObservableCollection<BOBillingArticle>(
                    this.Articles.Where(a => EF.Functions.Like(a.Name.ToUpper(), $"%{this.FilterName.ToUpper()}%")).ToList()
                );
            }
            if (!string.IsNullOrEmpty(this.FilterArticleCode))
            {
                this.Articles = new ObservableCollection<BOBillingArticle>(
                    this.Articles.Where(a => EF.Functions.Like(a.Code.ToUpper(), $"%{this.FilterArticleCode.ToUpper()}%")).ToList()
                );
            }
            if (!string.IsNullOrEmpty(this.FilterStock))
            {
                this.Articles = new ObservableCollection<BOBillingArticle>(
                    this.Articles.Where(a => EF.Functions.Like(a.Stock.ToUpper(), $"%{this.FilterStock.ToUpper()}%")).ToList()
                );
            }
            if (!string.IsNullOrEmpty(this.FilterUnitMeasure))
            {
                this.Articles = new ObservableCollection<BOBillingArticle>(
                    this.Articles.Where(a => EF.Functions.Like(a.UnitMeasure.ToUpper(), $"%{this.FilterUnitMeasure.ToUpper()}%")).ToList()
                );
            }

            this.Articles.OrderBy(a => a.Code);
        }
        #endregion
    }
}
