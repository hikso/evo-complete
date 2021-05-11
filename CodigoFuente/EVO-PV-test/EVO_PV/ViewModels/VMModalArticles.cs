using EVO_PV;
using EVO_PV.Enums;
using EVO_PV.Interfaces;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Resources.Dictionaries;
using EVO_PV.Services;
using EVO_PV.Utilities;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 15-Ene/2019
    /// Descripción      : Esta clase implementa el View Model del modal de artículos
    /// </summary>
    public class VMModalArticles : NotifyPropertyChanged
    {
        #region Atributos        
        private MainWindow PrincipalScreen;

        private ArticleService articleService;
        private ObservableCollection<BOArticle> articlesSelected { get; set; }
        private ObservableCollection<BOArticle> articles { get; set; }
        private List<BOArticle> articlesTemp { get; set; }
        private int maximumPageSize { get; set; }
        /// <summary>
        /// Tareas para usar métodos asyncrnos en los contructores
        /// </summary>
        private Task getArticles;
        public ICommand HideModalArticlesCommand { get; }
        public ICommand AddArticlesToOrderCommand { get; }

        private INotificationVM viewModel = null;

        /// <summary>
        /// Filtros
        /// </summary>        
        private string maximumFilter { get; set; }
        private string minimumFilter { get; set; }
        private string stockFilter { get; set; }
        private string suggestedOrderFilter { get; set; }
        private string unitMeasureFilter { get; set; }
        private string nameFilter { get; set; }
        private string codeFilter { get; set; }
        private BOOrderType orderType { get; set; }

        #endregion

        #region Propiedades

        public string UnitMeasureFilter
        {
            get { return unitMeasureFilter; }
            set
            {
                unitMeasureFilter = value;
                this.Filters();
                this.OnPropertyChanged("UnitMeasureFilter");
            }
        }

        public string MaximumFilter
        {
            get { return maximumFilter; }
            set
            {
                maximumFilter = value;
                this.Filters();
                this.OnPropertyChanged("MaximumFilter");
            }
        }

        public string MinimumFilter
        {
            get { return minimumFilter; }
            set
            {
                minimumFilter = value;
                this.Filters();
                this.OnPropertyChanged("MinimumFilter");
            }
        }

        public string StockFilter
        {
            get { return stockFilter; }
            set
            {
                stockFilter = value;
                this.Filters();
                this.OnPropertyChanged("StockFilter");
            }
        }

        public string SuggestedOrderFilter
        {
            get { return suggestedOrderFilter; }
            set
            {
                suggestedOrderFilter = value;
                this.Filters();
                this.OnPropertyChanged("SuggestedOrderFilter");
            }
        }

        public string NameFilter
        {
            get { return nameFilter; }
            set
            {
                nameFilter = value;
                this.Filters();
                this.OnPropertyChanged("NameFilter");
            }
        }

        public string CodeFilter
        {
            get { return codeFilter; }
            set
            {
                codeFilter = value;
                this.Filters();
                this.OnPropertyChanged("CodeFilter");
            }
        }

        public ObservableCollection<BOArticle> ArticlesSelected
        {
            get { return articlesSelected; }

            set
            {
                this.articlesSelected = value;
                this.Filters();
                this.OnPropertyChanged("ArticlesSelected");
            }
        }

        public ObservableCollection<BOArticle> Articles
        {
            get { return articles; }

            set
            {
                this.articles = value;
                this.Filters();
                this.OnPropertyChanged("Articles");
            }
        }

        public BOOrderType OrderType
        {
            get { return orderType; }
            set
            {
                this.orderType = value;
                this.OnPropertyChanged("OrderType");
            }
        }

        #endregion

        #region Constructores
        public VMModalArticles(MainWindow principalScreen, INotificationVM viewModel, BOOrderType bOOrderType)
        {
            this.viewModel = viewModel;
            this.PrincipalScreen = principalScreen;
            this.OrderType = bOOrderType;
            this.maximumPageSize = Convert.ToInt32(App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()]);
            this.articleService = new ArticleService();
            this.getArticles = GetArticlesAsync(1, this.maximumPageSize, viewModel.FactoryCode);
            this.AddArticlesToOrderCommand = new RelayCommand(AddArticlesToOrder);
            this.articlesTemp = new List<BOArticle>();
        }
        #endregion

        #region Métodos 
        
        private void Filters()
        {
            foreach (BOArticle bOArticle in this.articlesTemp)
            {
                this.Articles.Add(bOArticle);
            }

            this.articlesTemp.Clear();

            if (!string.IsNullOrEmpty(this.CodeFilter))
            {
                this.articlesTemp.AddRange(this.Articles.Where(a => ! EF.Functions.Like(a.CodeArticle.ToUpper(),$"%{this.CodeFilter.ToUpper()}%")));

                foreach (BOArticle articleTemp in this.articlesTemp)
                {
                    this.Articles.Remove(articleTemp);
                }
            }

            if (!string.IsNullOrEmpty(this.NameFilter))
            {
                this.articlesTemp.AddRange(this.Articles.Where(a => ! EF.Functions.Like(a.NameArticle.ToUpper(), $"{this.NameFilter.ToUpper()}%")));

                foreach (BOArticle bOArticle in this.articlesTemp)
                {
                    this.Articles.Remove(bOArticle);
                }
            }

            if (!string.IsNullOrEmpty(this.MaximumFilter))
            {
                this.articlesTemp.AddRange(this.Articles.Where(a => !EF.Functions.Like(string.IsNullOrEmpty(a.Maximum) ? string.Empty : a.Maximum.ToUpper(), $"{this.MaximumFilter.ToUpper()}%")));

                foreach (BOArticle bOArticle in this.articlesTemp)
                {
                    this.Articles.Remove(bOArticle);
                }
            }

            if (!string.IsNullOrEmpty(this.MinimumFilter))
            {
                this.articlesTemp.AddRange(this.Articles.Where(a => !EF.Functions.Like(string.IsNullOrEmpty(a.Minimum) ? string.Empty : a.Minimum.ToUpper(), $"{this.MinimumFilter.ToUpper()}%")));
                foreach (BOArticle bOArticle in this.articlesTemp)
                {
                    this.Articles.Remove(bOArticle);
                }
            }

            if (!string.IsNullOrEmpty(this.StockFilter))
            {
                this.articlesTemp.AddRange(this.Articles.Where(a => !EF.Functions.Like(a.Stock.ToUpper(), $"{this.StockFilter.ToUpper()}%")));

                foreach (BOArticle bOArticle in this.articlesTemp)
                {
                    this.Articles.Remove(bOArticle);
                }
            }

            if (!string.IsNullOrEmpty(this.SuggestedOrderFilter))
            {
                this.articlesTemp.AddRange(this.Articles.Where(a => !EF.Functions.Like(string.IsNullOrEmpty(a.SuggestedOrder)?string.Empty:a.SuggestedOrder.ToUpper(), $"{this.SuggestedOrderFilter.ToUpper()}%")));

                foreach (BOArticle bOArticle in this.articlesTemp)
                {
                    this.Articles.Remove(bOArticle);
                }
            }

            if (!string.IsNullOrEmpty(this.UnitMeasureFilter))
            {
                this.articlesTemp.AddRange(this.Articles.Where(a => !EF.Functions.Like(a.UnitMeasure.ToUpper(), $"{this.UnitMeasureFilter.ToUpper()}%")));

                foreach (BOArticle bOArticle in this.articlesTemp)
                {
                    this.Articles.Remove(bOArticle);
                }
            }

            this.Articles.OrderBy(a => a.CodeArticle);
        }

        private void AddArticlesToOrder()
        {
            viewModel.NotificationVMFather();
        }

        /// <summary>
        /// Método que obtiene los artículos de forma asíncrona
        /// </summary>  
        private async Task GetArticlesAsync(int from, int to, string whsCode)
        {
            BOPaginationArticle bOPaginationArticle = await this.articleService.GetArticlesByWhsCodeSale(from, to, whsCode, this.OrderType.OrderTypeId.GetValueOrDefault());

            this.Articles = new ObservableCollection<BOArticle>(bOPaginationArticle.Articles);
            foreach (var item in this.Articles)
            {
                item.IconCheckStock = DictIcons.TrendingNeutral;
                if (float.Parse(item.SuggestedOrder) != 0 && this.OrderType.OrderTypeId != 2)
                {
                    item.ColorCheckStockArticle = DictColors.WarningYellow;
                    item.IconCheckStock = DictIcons.TrendingDown;
                }

            }
            this.Articles = new ObservableCollection<BOArticle>(
                this.Articles.OrderByDescending(d => float.Parse(d.SuggestedOrder) != 0).ToList()
            );
        }
        #endregion

    }
}
