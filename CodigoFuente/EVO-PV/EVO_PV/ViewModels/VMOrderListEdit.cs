using EVO_PV;
using EVO_PV.Enum;
using EVO_PV.Enums;
using EVO_PV.Interfaces;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Resources.Dictionaries;
using EVO_PV.Services;
using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    public class VMOrderListEdit : NotifyPropertyChanged, INotificationVM, IConfirmationModal
    {

        #region Atributos privados
        private MainWindow PrincipalScreen;
        private int ID;
        private DateTime? dateDelivery { get; set; }
        private DateTime dateOrder { get; set; }
        private string factoryCode { get; set; }
        private bool isOpenModal { get; set; }
        private int maximumPageSize { get; set; }
        private EnumConstanst typeVM;
        private string title { get; set; }
        private string subtitle { get; set; }
        private string whsCodePointSale { get; set; }

        /// <summary>
        /// Modales
        /// </summary>
        UCModalArticles uCModalArticles;
        UCModalConfirmation UCModalConfirmation;

        /// <summary>
        /// Colecciones
        /// </summary>
        private ObservableCollection<BOWareHouse> factories { get; set; }
        private ObservableCollection<BOArticle> articles { get; set; }
        private ObservableCollection<BOArticle> articlesSelected { get; set; }
        private BOArticle findArticle { get; set; }
        private BOArticleOrder articleOrderSelected { get; set; }
        private ObservableCollection<BOArticleOrder> articlesOrder { get; set; }
        private ObservableCollection<BOStateArticle> statesArticle { get; set; }
        private BOOrderListDetails orderListDetails { get; set; }
        private BOGetOrderErasedRequest bOGetOrderErasedRequest { get; set; }
        private ObservableCollection<BOArticle> findArticles { get; set; }

        /// <summary>
        /// Campos de búsqueda del artículo
        /// </summary>
        private string codeArticleSearch { get; set; }
        private string nameArticleSearch { get; set; }
        private decimal quantityArticleSearch { get; set; }
        private int stateArticleIdSearch { get; set; }
        private string unitMeasureArticleSearch { get; set; }
        private string suggestedOrderArticleSearch { get; set; }
        private string stockArticleSearch { get; set; }
        private string minimumArticleSearch { get; set; }
        private string maximumArticleSearch { get; set; }

        /// <summary>
        /// Notificación de mensajes
        /// </summary>
        private Notification notification;

        /// <summary>
        /// atributos del contrato de IConfirmationModal
        /// </summary>
        private string messageConfirmation { get; set; }
        private string iconName { get; set; }
        private EnumNamesMethods enumNameMethodYes { get; set; }
        private EnumNamesMethods enumNameMethodNot { get; set; }
        private string foreground { get; set; }

        private bool enableSavedAndSendOrder { get; set; }
        private string state { get; set; }

        /// <summary>
        /// Pop up
        /// </summary>
        private bool isOpenPopCodeArticle { get; set; }
        private bool isOpenPopNameArticle { get; set; }
        private string previousFactorySelected { get; set; }
        private bool endConfirmationNot { get; set; }
        #endregion

        #region Atributos públicos
        public String Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }

        public String Subtitle
        {
            get { return this.subtitle; }
            set
            {
                this.subtitle = value;
                this.OnPropertyChanged("Subtitle");
            }
        }

        public DateTime DateOrder
        {
            get { return this.dateOrder; }
            set
            {
                this.dateOrder = value;
                this.OnPropertyChanged("DateOrder");
            }
        }

        public DateTime? DateDelivery
        {
            get { return this.dateDelivery; }
            set
            {
                this.dateDelivery = value;
                this.OnPropertyChanged("DateDelivery");
            }
        }

        public BOOrderListDetails OrderListDetails
        {
            get { return orderListDetails; }

            set
            {
                this.orderListDetails = value;
                this.OnPropertyChanged("OrderListDetails");
            }
        }

        /// <summary>
        /// Propiedades de búsqueda de artículo para el pedido 
        /// </summary>
        public string CodeArticleSearch
        {
            get { return codeArticleSearch; }

            set
            {
                this.codeArticleSearch = value;
                if (this.FindArticle == null)
                {
                    SearchArticles(EnumFieldsFindArticles.Code);
                }
                this.OnPropertyChanged("CodeArticleSearch");

            }
        }

        public string NameArticleSearch
        {
            get { return nameArticleSearch; }

            set
            {
                this.nameArticleSearch = value;
                if (this.FindArticle == null)
                {
                    SearchArticles(EnumFieldsFindArticles.Name);
                }
                this.OnPropertyChanged("NameArticleSearch");
            }
        }

        public decimal QuantityArticleSearch
        {
            get { return quantityArticleSearch; }

            set
            {

                this.quantityArticleSearch = value;
                this.OnPropertyChanged("QuantityArticleSearch");
            }
        
        }

        public int StateArticleIdSearch
        {
            get { return stateArticleIdSearch; }

            set
            {
                this.stateArticleIdSearch = value;
                this.OnPropertyChanged("StateArticleIdSearch");
            }
        }

        public string UnitMeasureArticleSearch
        {
            get { return unitMeasureArticleSearch; }

            set
            {
                this.unitMeasureArticleSearch = value;
                this.unitMeasureArticleSearch = value == "" ? "KG" : value;
                this.OnPropertyChanged("UnitMeasureArticleSearch");
            }
        }

        public string SuggestedOrderArticleSearch
        {
            get { return suggestedOrderArticleSearch; }

            set
            {
                this.suggestedOrderArticleSearch = value;
                this.suggestedOrderArticleSearch = value == "" ? "0" : value;
                this.OnPropertyChanged("SuggestedOrderArticleSearch");
            }
        }

        public string StockArticleSearch
        {
            get { return stockArticleSearch; }

            set
            {
                this.stockArticleSearch = value;
                this.stockArticleSearch = value == "" ? "0" : value;
                this.OnPropertyChanged("StockArticleSearch");
            }
        }

        public string MinimumArticleSearch
        {
            get { return minimumArticleSearch; }

            set
            {
                this.minimumArticleSearch = value;
                this.minimumArticleSearch = value == "" ? "0" : value;
                this.OnPropertyChanged("MinimumArticleSearch");
            }
        }

        public string MaximumArticleSearch
        {
            get { return maximumArticleSearch; }

            set
            {
                this.maximumArticleSearch = value == "" ? "0" : value;
                this.OnPropertyChanged("MaximumArticleSearch");
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

        public BOArticleOrder ArticleOrderSelected
        {
            get { return articleOrderSelected; }

            set
            {
                this.articleOrderSelected = value;
                if (this.ArticleOrderSelected != null)
                {
                    articleOrderSelected.ErrorArticle = string.Empty;
                }
                this.OnPropertyChanged("ArticleOrderSelected");
            }
        }

        public ObservableCollection<BOArticleOrder> ArticlesOrder
        {
            get { return articlesOrder; }

            set
            {
                this.articlesOrder = value;
                this.OnPropertyChanged("ArticlesOrder");
            }
        }

        public ObservableCollection<BOArticle> ArticlesSelected
        {
            get { return articlesSelected; }

            set
            {
                this.articlesSelected = value;
                this.OnPropertyChanged("ArticlesSelected");
                this.AddArticlesToOrder();

            }
        }

        public ObservableCollection<BOWareHouse> Factories
        {
            get { return factories; }

            set
            {
                this.factories = value;
                this.OnPropertyChanged("Factories");
            }
        }

        public ObservableCollection<BOStateArticle> StatesArticle
        {
            get { return statesArticle; }

            set
            {
                this.statesArticle = value;
                this.OnPropertyChanged("StatesArticle");
            }
        }

        public ObservableCollection<BOArticle> Articles
        {
            get { return articles; }

            set
            {
                this.articles = value;
                this.OnPropertyChanged("Articles");
            }
        }

        public string FactoryCode
        {
            get
            {
                return this.factoryCode;
            }
            set
            {

                this.previousFactorySelected = factoryCode;
                this.factoryCode = value;
                this.OnPropertyChanged("FactoryCode");

                if (!string.IsNullOrWhiteSpace(this.factoryCode))
                {
                    bOGetOrderErasedRequest.CodeFactory = this.factoryCode;
                    this.getArticles = GetArticlesAsync(1, this.maximumPageSize, this.factoryCode);

                }

            }
        }

        public bool IsOpenModal
        {
            get { return this.isOpenModal; }
            set
            {
                this.isOpenModal = value;
                this.OnPropertyChanged("IsOpenModal");
            }
        }

        public bool EnableSavedAndSendOrder
        {
            get { return enableSavedAndSendOrder; }

            set
            {
                this.enableSavedAndSendOrder = value;
                this.OnPropertyChanged("EnableSavedAndSendOrder");
            }
        }

        public string State
        {
            get { return state; }

            set
            {
                this.state = value;
                this.OnPropertyChanged("State");

            }
        }

        public bool IsOpenPopCodeArticle
        {
            get { return isOpenPopCodeArticle; }

            set
            {
                this.isOpenPopCodeArticle = value;
                this.OnPropertyChanged("IsOpenPopCodeArticle");

            }
        }

        public bool IsOpenPopNameArticle
        {
            get { return isOpenPopNameArticle; }

            set
            {
                this.isOpenPopNameArticle = value;
                this.OnPropertyChanged("IsOpenPopNameArticle");

            }
        }

        public BOArticle FindArticle
        {
            get { return findArticle; }

            set
            {
                this.findArticle = value;
                SetFindArticle();
                this.IsOpenPopCodeArticle = false;
                this.IsOpenPopNameArticle = false;
                this.OnPropertyChanged("FindArticle");

            }
        }

        public ObservableCollection<BOArticle> FindArticles
        {
            get { return findArticles; }

            set
            {
                this.findArticles = value;
                this.OnPropertyChanged("FindArticles");

            }
        }

        #endregion

        #region Comandos Eventos de botones 
        public ICommand ViewDetails { get; }
        public ICommand ShowModalArticlesCommand { get; }
        public ICommand DeleteArticlesOrderCommand { get; }
        public ICommand DeleteArticleOrderCommand { get; }
        public ICommand KeyDownFindArticleCommand { get; }
        public ICommand ValidateOpenConfirmationCommand { get; }
        public ICommand ValidateErasedConfirmationCommand { get; }
        public ICommand KeyDownFindCodeArticleCommand { get; }
        public ICommand KeyDownFindNameArticleCommand { get; }
        public ICommand ValidateFindArticleCommand { get; }


        #endregion

        #region Objetos de Servicios
        /// <summary>
        /// Servicios de datos
        /// </summary>
        private WareHouseService wareHouseService;
        private ArticleService articleService;
        private OrderListService OrderListServices;
        #endregion

        #region Tareas
        /// <summary>
        /// Task para llamar en el constructor métodos asyncronos
        /// </summary>
        private Task getFactories;
        private Task getArticles;
        private Task getStatesArticles;
        private Task GetOrderListDetails;
        #endregion

        #region Constructor
        public VMOrderListEdit(MainWindow principalScreen, int id, EnumConstanst type)
        {
            this.PrincipalScreen = principalScreen;
            this.ViewDetails = new RelayCommand(ViewDetailShow);
            this.ID = id;
            this.typeVM = type;
            this.DateOrder = DateTime.Now.Date;
            this.maximumPageSize = Convert.ToInt32(App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()]);
            this.whsCodePointSale = App.Current.Properties[EnumConstanst.WhsCode.ToString()].ToString();
            this.OrderListServices = new OrderListService();
            this.wareHouseService = new WareHouseService();
            this.articleService = new ArticleService();
            this.notification = new Notification();

            this.getFactories = GetFactoriesAsync();
            this.getStatesArticles = GetStatesArticleAsync();
            this.GetOrderListDetails = GetOrderListAsync(this.ID);

            this.ShowModalArticlesCommand = new RelayCommand(ShowModalArticles);
            this.DeleteArticlesOrderCommand = new RelayCommand(DeleteArticlesOrder);
            this.DeleteArticleOrderCommand = new RelayCommand(DeleteArticleOrder);
            this.ValidateOpenConfirmationCommand = new RelayCommand(ValidateOpenConfirmation);
            this.ValidateErasedConfirmationCommand = new RelayCommand(ValidateErasedConfirmation);
            this.ValidateFindArticleCommand = new RelayCommand(ValidateFindArticle);

            this.IsOpenModal = false;

            this.ArticlesOrder = new ObservableCollection<BOArticleOrder>();

            this.findArticle = null;


            bOGetOrderErasedRequest = new BOGetOrderErasedRequest()
            {
                CodePointSale = this.whsCodePointSale
            };

            this.EmptyFieldsFindArticle();
            this.EnableSavedAndSendOrder = true;

        }

        #endregion

        #region Métodos Privados

        private async Task GetOrderListAsync(int id)
        {
            BOOrderListPreview bOOrderListPreview = await this.OrderListServices.GetOrderListDetailsById(id);
            this.FactoryCode = bOOrderListPreview.RequestFor;
            this.CodeArticleSearch = string.Empty;
            this.NameArticleSearch = string.Empty;
            foreach (var item in bOOrderListPreview.Registers)
            {
                this.ArticlesOrder.Add(item);
            }

            switch (this.typeVM)
            {
                case EnumConstanst.Edit:

                    if (bOOrderListPreview.DateDelivery == null)
                    {
                        this.DateDelivery = null;
                    }
                    else
                    {
                        this.DateDelivery = bOOrderListPreview.DateDelivery;
                    }

                    this.Title = "Editar Pedido: ";
                    this.Subtitle = "Borrador";
                    this.EnableSavedAndSendOrder = true;
                    break;
                case EnumConstanst.Duplicate:
                    bOGetOrderErasedRequest = new BOGetOrderErasedRequest()
                    {
                        CodePointSale = this.whsCodePointSale
                    };

                    if (this.OrderListServices.ExistRequestFactoryErased(whsCodePointSale))
                    {
                        this.EnableSavedAndSendOrder = false;
                        this.notification.Show(DictMessages.Information, DictMessages.SolicitudesBorradores, NotificationType.Information);
                    }

                    this.Title = "Solicitud Pedido: ";
                    this.Subtitle = "Duplicado";
                    break;
            }
        }

        private void ViewDetailShow()
        {
            this.PrincipalScreen.ContentPage.Content = new UCOrderList(this.PrincipalScreen);
        }


        private void SearchArticle()
        {
            this.findArticle = null;

            if (this.Articles == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(this.CodeArticleSearch))
            {
                this.findArticle = this.Articles.FirstOrDefault(a => a.CodeArticle.Trim().ToLower() == this.CodeArticleSearch.Trim().ToLower());
            }

            if (!string.IsNullOrEmpty(this.NameArticleSearch))
            {
                this.findArticle = this.Articles.FirstOrDefault(a => a.NameArticle.Trim().ToLower() == this.NameArticleSearch.Trim().ToLower());
            }

            if (this.findArticle == null)
            {
                return;
            }

            this.SetFindArticle();

        }

        private void SetFindArticle()
        {
            if (this.FindArticle != null)
            {
                this.CodeArticleSearch = this.FindArticle.CodeArticle;
                this.NameArticleSearch = this.FindArticle.NameArticle;
                this.UnitMeasureArticleSearch = this.FindArticle.UnitMeasure;
                this.SuggestedOrderArticleSearch = this.FindArticle.SuggestedOrder;
                this.QuantityArticleSearch = 0;
                this.StateArticleIdSearch = 1;
                this.StockArticleSearch = this.FindArticle.Stock;
                this.MinimumArticleSearch = this.FindArticle.Minimum;
                this.MaximumArticleSearch = this.FindArticle.Maximum;
            }
        }

        private void ValidateFindArticle()
        {
            if (this.QuantityArticleSearch <= 0)
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorCantidadArticulo, NotificationType.Error);
                return;
            }

            if (this.StateArticleIdSearch <= 0)
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorEstadoArticulo, NotificationType.Error);
                return;
            }

            if (this.ArticlesOrder.Where(a => a.CodeArticle == this.findArticle.CodeArticle || a.NameArticle == this.findArticle.NameArticle).Count() == 2)
            {
                this.notification.Show(
                    DictMessages.Error, 
                    string.Format(DictMessages.ErrMasDosArticulos, this.findArticle.CodeArticle, this.findArticle.NameArticle), 
                    NotificationType.Error);
                this.FindArticle = null;

                return;
            }

            AddArticleOrder();

        }

        private void AddArticleOrder()
        {
            BOArticleOrder bOArticleOrder = this.mapper.Map<BOArticle, BOArticleOrder>(this.FindArticle);
            bOArticleOrder.Quantity = this.QuantityArticleSearch;
            bOArticleOrder.StateArticleId = this.StateArticleIdSearch;

            this.ArticlesOrder.Add(bOArticleOrder);
            EmptyFieldsFindArticle();
            this.NameArticleSearch = string.Empty;
            this.CodeArticleSearch = string.Empty;
            this.FindArticle = null;
        }

        private void EmptyFieldsFindArticle()
        {
            this.QuantityArticleSearch = 0;
            this.StateArticleIdSearch = 1;
            this.UnitMeasureArticleSearch = string.Empty;
            this.SuggestedOrderArticleSearch = string.Empty;
            this.MinimumArticleSearch = string.Empty;
            this.StockArticleSearch = string.Empty;
            this.MaximumArticleSearch = string.Empty;
        }

        private void DeleteArticleOrder()
        {
            ConfigureModalConfirmation(
               EnumNamesMethods.DELETE_ARTICLE_ORDER_REQUEST,
               DictMessages.EliminarArticuloPedido,
               DictIcons.DeleteEmpty,
               DictColors.Red
               );
        }

        private void DeleteArticlesOrder()
        {
            if (this.ArticlesOrder == null)
            {
                return;
            }

            if (this.ArticlesOrder.Count == 0)
            {
                return;
            }

            ConfigureModalConfirmation(
               EnumNamesMethods.DELETE_ARTICLES_ORDER_REQUEST,
               DictMessages.EliminarArticulosPedido,
               DictIcons.DeleteEmpty,
               DictColors.Red
               );
        }

        private void AddArticlesToOrder()
        {
            if (this.ArticlesSelected == null)
            {
                return;
            }

            if (this.ArticlesSelected.Count == 0)
            {
                return;
            }

            foreach (BOArticle bOArticle in this.ArticlesSelected)
            {

                if (this.ArticlesOrder.Where(ao => ao.CodeArticle == bOArticle.CodeArticle).Count() == 2)
                {
                    this.notification.Show(DictMessages.Error, DictMessages.ErrMasDosArticulos, NotificationType.Error);
                    return;
                }

                BOArticleOrder bOArticleOrder = this.mapper.Map<BOArticle, BOArticleOrder>(bOArticle);
                bOArticleOrder.Quantity = 0;
                bOArticleOrder.StateArticleId = 1;
                this.ArticlesOrder.Add(bOArticleOrder);
            }

            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }

        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetFactoriesAsync()
        {
            List<BOWareHouse> boFactories = await this.wareHouseService.GetFactories();

            this.Factories = new ObservableCollection<BOWareHouse>(boFactories);
        }

        /// <summary>
        /// Método que obtiene los estados de los artículos de forma asíncrona
        /// </summary>  
        private async Task GetStatesArticleAsync()
        {
            List<BOStateArticle> boStatesArticle = await this.articleService.GetStatesArticles();

            this.StatesArticle = new ObservableCollection<BOStateArticle>(boStatesArticle);
            this.StatesArticle.Add(new BOStateArticle() { Name = "Seleccione...", StateArticleId = 0 });
        }

        /// <summary>
        /// Método que obtiene los artículos de forma asíncrona
        /// </summary>  
        private async Task GetArticlesAsync(int from, int to, string whsCode)
        {
            BOPaginationArticle bOPaginationArticle = await this.articleService.GetArticlesByWhsCodeSale(from, to, whsCode);

            this.Articles = new ObservableCollection<BOArticle>(bOPaginationArticle.Articles);
        }

        private void ShowModalArticles()
        {
            if (this.FactoryCode == null || string.IsNullOrEmpty(this.FactoryCode))
            {
                this.notification.Show(DictMessages.Information, DictMessages.ErrorSeleccionarPlanta, NotificationType.Information);
                return;
            }

            this.getArticles = GetArticlesAsync(1, this.maximumPageSize, this.FactoryCode);

            uCModalArticles = new UCModalArticles(this.PrincipalScreen, this);
            this.PrincipalScreen.ModalContainer.Content = uCModalArticles;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;

        }

        private void ConfigureModalConfirmation(EnumNamesMethods enumNamesMethodsYes, EnumNamesMethods enumNamesMethodsNot, string messageConfirmation, string iconName, string foreground)
        {
            this.enumNameMethodYes = enumNamesMethodsYes;
            this.enumNameMethodNot = enumNamesMethodsNot;
            this.messageConfirmation = messageConfirmation; //DictMessages
            this.iconName = iconName;//DictIcons
            this.foreground = foreground;//DictColors
            UCModalConfirmation = new UCModalConfirmation(this);
            this.PrincipalScreen.ModalContainer.Content = UCModalConfirmation;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
        }


        private void ConfigureModalConfirmation(EnumNamesMethods enumNamesMethods, string messageConfirmation, string iconName, string foreground)
        {
            this.enumNameMethodYes = enumNamesMethods;
            this.messageConfirmation = messageConfirmation; //DictMessages
            this.iconName = iconName;//DictIcons
            this.foreground = foreground;
            UCModalConfirmation = new UCModalConfirmation(this);
            this.PrincipalScreen.ModalContainer.Content = UCModalConfirmation;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
        }

        private void DeleteArticlesToOrder()
        {
            this.ArticlesOrder.Clear();
            this.notification.Show(DictMessages.Success, DictMessages.ArticulosEliminadosCorrectamente, NotificationType.Success);
        }

        private void DeleteArticleToOrder()
        {
            this.ArticlesOrder.Remove(this.ArticleOrderSelected);
            this.notification.Show(DictMessages.Success, DictMessages.ArticuloEliminadoCorrectamente, NotificationType.Success);
        }

        private bool ValidateSaveOrderGeneric()
        {
            if (this.ArticlesOrder == null)
            {
                return false;
            }

            if (this.ArticlesOrder.Count == 0)
            {
                return false;
            }

            if (this.DateOrder > DateTime.Now)
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorFechaPedidoMayorActual, NotificationType.Error);
                return false;
            }

            if (this.ArticlesOrder == null)
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorPedidoSinArticulos, NotificationType.Error);
                return false;
            }

            if (this.ArticlesOrder.Count == 0)
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorPedidoSinArticulos, NotificationType.Error);
                return false;
            }

            if (this.FactoryCode == null)
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorSeleccionarPlanta, NotificationType.Error);
                return false;
            }

            if (string.IsNullOrEmpty(this.FactoryCode))
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorSeleccionarPlanta, NotificationType.Error);
                return false;
            }

            List<string> codesArticlesOrder = this.ArticlesOrder.Select(a => a.CodeArticle).Distinct().ToList();

            foreach (BOArticleOrder bOArticleOrder in this.ArticlesOrder)
            {
                bOArticleOrder.ErrorArticle = string.Empty;

                if (bOArticleOrder.Quantity <= 0)
                {
                    bOArticleOrder.ErrorArticle = DictColors.Warning;
                }

                if (bOArticleOrder == null)
                {
                    bOArticleOrder.ErrorArticle = DictColors.Warning;
                }

                if (bOArticleOrder.StateArticleId == 0)
                {
                    bOArticleOrder.ErrorArticle = DictColors.Warning;
                }
            }

            foreach (string codeArticle in codesArticlesOrder)
            {
                List<BOArticleOrder> articlesOrderEqualCode = this.ArticlesOrder.Where(a => a.CodeArticle == codeArticle).ToList();

                if (articlesOrderEqualCode.Where(a => a.CodeArticle == codeArticle).Count() >= 3)
                {
                    this.notification.Show(DictMessages.Error, DictMessages.ErrMasDosArticulos, NotificationType.Error);

                    foreach (BOArticleOrder bOArticleOrder in articlesOrderEqualCode.Where(a => a.CodeArticle == codeArticle))
                    {
                        bOArticleOrder.ErrorArticle = DictColors.Warning;
                    }

                    return false;
                }

                if (articlesOrderEqualCode.Where(a => a.CodeArticle == codeArticle).Count() == 2)
                {
                    if (articlesOrderEqualCode[0].StateArticleId == articlesOrderEqualCode[1].StateArticleId)
                    {
                        this.notification.Show(DictMessages.Error, DictMessages.ErrorArticuloOrdenMismoEstado, NotificationType.Error);
                        articlesOrderEqualCode[0].ErrorArticle = DictColors.Warning;
                        articlesOrderEqualCode[1].ErrorArticle = DictColors.Warning;

                        return false;
                    }
                }

                if (articlesOrderEqualCode.Where(a => a.Quantity == 0).Count() > 0)
                {
                    this.notification.Show(DictMessages.Error, DictMessages.ErrorCantidadArticulo, NotificationType.Error);

                    foreach (BOArticleOrder bOArticleOrder in articlesOrderEqualCode.Where(a => a.Quantity == 0))
                    {
                        bOArticleOrder.ErrorArticle = DictColors.Warning;
                    }

                    return false;
                }

                if (articlesOrderEqualCode.Where(a => a.StateArticleId.Value == 0).Count() > 0)
                {
                    this.notification.Show(DictMessages.Error, DictMessages.ErrorEstadoArticulo, NotificationType.Error);

                    foreach (BOArticleOrder bOArticleOrder in articlesOrderEqualCode.Where(a => a.StateArticleId.Value == 0))
                    {
                        bOArticleOrder.ErrorArticle = DictColors.Warning;
                    }

                    return false;
                }

                if (articlesOrderEqualCode.Where(a => a.StateArticleId == null).Count() > 0)
                {
                    this.notification.Show(DictMessages.Error, DictMessages.ErrorEstadoArticulo, NotificationType.Error);
                    foreach (BOArticleOrder bOArticleOrder in articlesOrderEqualCode.Where(a => a.StateArticleId.Value == 0))
                    {
                        bOArticleOrder.ErrorArticle = DictColors.Warning;
                    }

                    return false;
                }

            }

            return true;

        }

        private void ValidateOpenConfirmation()
        {
            if (!this.ValidateSaveOrderGeneric())
            {
                return;
            }

            ConfigureModalConfirmation(
                EnumNamesMethods.SAVE_ORDER_REQUEST,
                DictMessages.ConfirmarGuadarSolicitudPedido,
                DictIcons.Backup,
                DictColors.Warning
                );
        }

        private void ValidateErasedConfirmation()
        {
            if (!this.ValidateSaveOrderGeneric())
            {
                return;
            }

            if (this.DateDelivery == null)
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorFechaEntregaSolicitudPedidoAbierto, NotificationType.Error);
                return;
            }

            ConfigureModalConfirmation(
                EnumNamesMethods.SEND_ORDER_REQUEST_COMERCIAL,
                DictMessages.ConfirmarEnviarSolicitudPedidoAComercial,
                DictIcons.PlaylistAddCheck,
                DictColors.Success
                );
        }

        private void SaveOrder(EnumStatesOrder enumStatesOrder)
        {
            switch (this.typeVM)
            {
                case EnumConstanst.Edit:
                    SaveOrderEdit(enumStatesOrder, this.ID);
                    break;
                case EnumConstanst.Duplicate:
                    SaveOrderDuplicate(enumStatesOrder);
                    break;
            }

        }

        private void SaveOrderEdit(EnumStatesOrder enumStatesOrder, int id)
        {
            BOOrderEditRequest bOOrderEditRequest = new BOOrderEditRequest()
            {
                OrderListId = id,
                WhsCodePointSale = this.whsCodePointSale,
                StateOrder = enumStatesOrder == EnumStatesOrder.Borrador ? EnumStatesOrder.Borrador.ToString() : EnumStatesOrder.Abierto.ToString(),
                WhsCodeFactory = this.factoryCode,
                User = string.Empty,
                Details = new List<BOOrderRequestDetail>()
            };

            if (this.DateDelivery == null)
            {
                bOOrderEditRequest.DateDelivery = null;
            }
            else
            {
                bOOrderEditRequest.DateDelivery = this.DateDelivery.Value.Date;
            }

            List<BOOrderRequestDetail> Details =
              this.ArticlesOrder.Select(a => new BOOrderRequestDetail()
              {
                  ItemCode = a.CodeArticle,
                  Quantity = a.Quantity,
                  DetailDeliveryId = 0,
                  StateArticleId = a.StateArticleId.Value,
                  Observations=a.Observations
              }).ToList();

            bOOrderEditRequest.Details.AddRange(Details);

            if (this.OrderListServices.SetOrderEditRequest(bOOrderEditRequest))
            {
                this.notification.Show(DictMessages.Success, enumStatesOrder == EnumStatesOrder.Borrador ? DictMessages.RegistrarSolicitudPedidoBorrador : DictMessages.RegistrarSolicitudPedidoDefinitivo, NotificationType.Success);
                this.PrincipalScreen.ContentPage.Content = new UCOrderList(this.PrincipalScreen);
            }
            else
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorGeneral, NotificationType.Error);
            }

        }

        private void SaveOrderDuplicate(EnumStatesOrder enumStatesOrder)
        {
            BOOrderRequest bOOrderRequest = new BOOrderRequest()
            {
                WhsCodePointSale = this.whsCodePointSale,
                StateOrder = enumStatesOrder == EnumStatesOrder.Borrador ? EnumStatesOrder.Borrador.ToString() : EnumStatesOrder.Abierto.ToString(),
                WhsCodeFactory = this.factoryCode,
                User = string.Empty,
                Details = new List<BOOrderRequestDetail>()
            };

            if (this.DateDelivery == null)
            {
                bOOrderRequest.DateDelivery = null;
            }
            else
            {
                bOOrderRequest.DateDelivery = this.DateDelivery.Value.Date;
            }

            List<BOOrderRequestDetail> Details =
              this.ArticlesOrder.Select(a => new BOOrderRequestDetail()
              {
                  ItemCode = a.CodeArticle,
                  Quantity = a.Quantity,
                  Observations = a.Observations == null ? "": a.Observations,
                  StateArticleId = a.StateArticleId.Value
              }).ToList();

            bOOrderRequest.Details.AddRange(Details);

            if (this.OrderListServices.SetOrderRequest(bOOrderRequest))
            {
                this.notification.Show(DictMessages.Success, enumStatesOrder == EnumStatesOrder.Borrador ? DictMessages.RegistrarSolicitudPedidoBorrador : DictMessages.RegistrarSolicitudPedidoDefinitivo, NotificationType.Success);
                this.PrincipalScreen.ContentPage.Content = new UCOrderList(this.PrincipalScreen);
            }
            else
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorGeneral, NotificationType.Error);
            }
        }

        private void SearchArticles(EnumFieldsFindArticles enumFieldsFindArticles)
        {
            this.IsOpenPopNameArticle = false;
            this.IsOpenPopCodeArticle = false;
            this.EmptyFieldsFindArticle();

            if (string.IsNullOrEmpty(this.FactoryCode))
            {
                this.notification.Show(DictMessages.Information, DictMessages.ErrorSeleccionarPlanta, NotificationType.Information);
                return;
            }

            string codeArticlePrefix = this.factoryCode.Substring(this.factoryCode.IndexOf("-") + 1) + "-";

            this.FindArticle = null;

            BOSearchArticleRequest bOSearchArticleRequest = new BOSearchArticleRequest()
            {
                WhsCode = this.whsCodePointSale,
                PrefixCodeArticle = codeArticlePrefix
            };

            switch (enumFieldsFindArticles)
            {
                case EnumFieldsFindArticles.Name:
                    bOSearchArticleRequest.Name = this.NameArticleSearch;

                    if (this.NameArticleSearch.Length == 0)
                    {
                        return;
                    }

                    this.FindArticles = new ObservableCollection<BOArticle>(this.articleService.GetArticlesSearch(bOSearchArticleRequest));

                    if (this.FindArticles.Count == 0)
                    {
                        return;
                    }

                    this.IsOpenPopNameArticle = true;

                    break;

                case EnumFieldsFindArticles.Code:                    
                    bOSearchArticleRequest.Code = bOSearchArticleRequest.PrefixCodeArticle + this.CodeArticleSearch;
                    this.FindArticles = new ObservableCollection<BOArticle>(this.articleService.GetArticlesSearch(bOSearchArticleRequest));

                    if (this.FindArticles.Count == 0)
                    {
                        return;
                    }

                    this.IsOpenPopCodeArticle = true;
                    break;
            }
        }

        public void KeyDownUserControl(Key key)
        {
            switch (key)
            {
                case Key.F3:
                    if (string.IsNullOrEmpty(this.FactoryCode))
                    {
                       this.notification.Show(DictMessages.Error, DictMessages.ErrorSeleccionarPlanta, NotificationType.Error);
                        return;
                    }

                    this.getArticles = GetArticlesAsync(1, this.maximumPageSize, this.FactoryCode);
                    uCModalArticles = new UCModalArticles(this.PrincipalScreen, this);
                    this.PrincipalScreen.ModalContainer.Content = uCModalArticles;
                    this.PrincipalScreen.ModalPrincipal.IsOpen = true;
                    break;

                case Key.S:
                    if (Keyboard.Modifiers == ModifierKeys.Control)
                    {
                        this.ValidateOpenConfirmation();
                    }
                    break;

                case Key.G:

                    if (Keyboard.Modifiers == ModifierKeys.Control)
                    {
                        this.ValidateErasedConfirmation();

                    }
                    break;

                case Key.Back:
                    return;
            
            }
        }
        #endregion

        #region Métodos Públicos
        public void ExecuteConfirmationYes()
        {
            switch (this.enumNameMethodYes)
            {
                case EnumNamesMethods.SAVE_ORDER_REQUEST:
                    SaveOrder(EnumStatesOrder.Borrador);
                    break;
                case EnumNamesMethods.SEND_ORDER_REQUEST_COMERCIAL:
                    SaveOrder(EnumStatesOrder.Abierto);
                    break;
                case EnumNamesMethods.DELETE_ARTICLES_ORDER_REQUEST:
                    DeleteArticlesToOrder();
                    break;
                case EnumNamesMethods.DELETE_ARTICLE_ORDER_REQUEST:
                    DeleteArticleToOrder();
                    break;
                default:
                    break;
            }

            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }

        public void ExecuteConfirmationNot()
        {
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }

        public void NotificationVMFather()
        {
            this.ArticlesSelected = uCModalArticles.vMModalArticles.ArticlesSelected;
        }
        #endregion

    }
}
