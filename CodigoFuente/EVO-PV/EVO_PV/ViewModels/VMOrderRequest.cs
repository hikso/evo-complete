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
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 26-Dic/2019
    /// Descripción      : Esta clase implementa el View Model del formulario de solicitud de pedido
    /// </summary>
    public class VMOrderRequest : NotifyPropertyChanged, INotificationVM, IConfirmationModal
    {
        #region Atributos
        private bool open { get; set; }
        private DateTime nowDate { get; set; }

        private string whsCodePointSale { get; set; }
        private bool isOpenPopCodeArticle { get; set; }
        private bool isOpenPopNameArticle { get; set; }

        /// <summary>
        /// Modales
        /// </summary>
        UCModalArticles uCModalArticles;
        UCModalConfirmation UCModalConfirmation;
        /// <summary>
        /// atributos del contrato de IConfirmationModal
        /// </summary>
        private string messageConfirmation { get; set; }
        private string iconName { get; set; }
        private EnumNamesMethods enumNameMethodYes { get; set; }
        private EnumNamesMethods enumNameMethodNot { get; set; }
        private string foreground { get; set; }
        private string previousFactorySelected { get; set; }
        private bool endConfirmationNot { get; set; }

        /// <summary>
        /// Servicios de datos
        /// </summary>
        private WareHouseService wareHouseService;

        private ArticleService articleService;

        private OrderListService orderListService;
        /// <summary>
        /// Notificación de mensajes
        /// </summary>

        private Notification notification;
        /// <summary>
        /// Tareas para usar metodos asyncrnos en los contructores
        /// </summary>

        private Task getFactories;

        private Task getArticles;

        private Task getStatesArticles;

        /// <summary>
        /// Commandos para asociar eventos del viewmodel con los botones de las vistas
        /// </summary>
        public ICommand ShowModalArticlesCommand { get; }
        //public ICommand DeleteArticlesOrderCommand { get; }
        public ICommand DeleteArticleOrderCommand { get; }
        public ICommand ValidateFindArticleCommand { get; }
        public ICommand KeyDownFindCodeArticleCommand { get; }
        public ICommand KeyDownFindNameArticleCommand { get; }
        public ICommand ValidateOpenConfirmationCommand { get; }
        public ICommand ValidateErasedConfirmationCommand { get; }
        public ICommand CleanFormCommand { get; }


        /// <summary>
        /// Referencia al main
        /// </summary>
        private MainWindow PrincipalScreen;
        /// <summary>
        /// Propiedades del formulario
        /// </summary>
        private DateTime dateOrder { get; set; }
        private DateTime? dateDelivery { get; set; }
        private string factoryCode { get; set; }
        private bool isOpenModal { get; set; }
        private int maximumPageSize { get; set; }
        /// <summary>
        /// Colecciones
        /// </summary>
        private ObservableCollection<BOWareHouse> factories { get; set; }
        private ObservableCollection<BOArticle> articles { get; set; }
        private ObservableCollection<BOArticle> articlesSelected { get; set; }
        private BOArticle findArticle { get; set; }
        private BOArticleOrder articleOrderSelected { get; set; }
        private BOGetOrderErasedRequest bOGetOrderErasedRequest { get; set; }
        private ObservableCollection<BOArticleOrder> articlesOrder { get; set; }
        private ObservableCollection<BOStateArticle> statesArticle { get; set; }
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
        private bool enableSavedAndSendOrder { get; set; }
        private string state { get; set; }
        private Key prevKey { get; set; }
        private bool NotPresentModalDelete { get; set; }
        #endregion

        #region Propiedades 

        public DateTime NowDate
        {
            get { return nowDate; }
            set
            {
                this.nowDate = value;
                this.OnPropertyChanged("NowDate");
            }
        }

        public bool Open
        {
            get { return open; }

            set
            {
                this.open = value;

                this.OnPropertyChanged("Open");

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

        /// <summary>
        /// Propiedades de búsqueda de artículo para el pedido 
        /// </summary>
        /// 
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

        public string State
        {
            get { return state; }

            set
            {
                this.state = value;

                this.OnPropertyChanged("State");

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

                this.OnPropertyChanged("NameArticleSearch");

                if (this.FindArticle == null)
                {
                    SearchArticles(EnumFieldsFindArticles.Name);
                }

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
                this.OnPropertyChanged("UnitMeasureArticleSearch");
            }
        }

        public string SuggestedOrderArticleSearch
        {
            get { return suggestedOrderArticleSearch; }

            set
            {
                this.suggestedOrderArticleSearch = value;
                this.OnPropertyChanged("SuggestedOrderArticleSearch");
            }
        }

        public string StockArticleSearch
        {
            get { return stockArticleSearch; }

            set
            {
                this.stockArticleSearch = value;
                this.OnPropertyChanged("StockArticleSearch");
            }
        }

        public string MinimumArticleSearch
        {
            get { return minimumArticleSearch; }

            set
            {
                this.minimumArticleSearch = value;
                this.OnPropertyChanged("MinimumArticleSearch");
            }
        }

        public string MaximumArticleSearch
        {
            get { return maximumArticleSearch; }

            set
            {
                this.maximumArticleSearch = value;
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
                if (articleOrderSelected != null)
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

        public ObservableCollection<BOArticle> FindArticles
        {
            get { return findArticles; }

            set
            {
                this.findArticles = value;

                this.OnPropertyChanged("FindArticles");

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

                if (this.endConfirmationNot)
                {
                    //Si es "True" es porque viene de la confirmación del "No".
                    this.endConfirmationNot = false;
                    return;
                }

                if (this.ArticlesOrder.Count > 0 && !NotPresentModalDelete)
                {
                    ConfigureModalConfirmation(
                    EnumNamesMethods.CLEAR_ARTICLES_CHANGE_FACTORY,
                    EnumNamesMethods.CLEAR_ARTICLES_CHANGE_FACTORY_CANCEL,
                    DictMessages.EliminarArticulosCambioPlanta,
                    DictIcons.DeleteEmpty,
                    DictColors.Red
                    );

                    return;

                }
                NotPresentModalDelete = false;
                if (!string.IsNullOrWhiteSpace(this.factoryCode))
                {
                    bOGetOrderErasedRequest.CodeFactory = this.factoryCode;

                    if (this.orderListService.GetStateErasedOrderRequestFactory(bOGetOrderErasedRequest))
                    {
                        this.State = "true";
                        this.notification.Show(DictMessages.Information, DictMessages.ErrorOrderErased, NotificationType.Information);
                        this.EnableSavedAndSendOrder = false;
                    }
                    else
                    {
                        this.State = "false";
                        this.EnableSavedAndSendOrder = true;
                    }

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

        #endregion

        #region Constructores
        public VMOrderRequest(MainWindow principalScreen)
        {
            this.PrincipalScreen = principalScreen;
            this.DateOrder = DateTime.Now.Date;

            this.maximumPageSize = Convert.ToInt32(App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()]);
            this.whsCodePointSale = App.Current.Properties[EnumConstanst.WhsCode.ToString()].ToString();

            this.wareHouseService = new WareHouseService();
            this.articleService = new ArticleService();
            this.notification = new Notification();
            this.orderListService = new OrderListService();

            this.getFactories = GetFactoriesAsync();
            this.getStatesArticles = GetStatesArticleAsync();

            this.ShowModalArticlesCommand = new RelayCommand(ShowModalArticles);
            //this.DeleteArticlesOrderCommand = new RelayCommand(DeleteArticlesOrder);
            this.DeleteArticleOrderCommand = new RelayCommand(DeleteArticleOrder);
            this.ValidateOpenConfirmationCommand = new RelayCommand(ValidateOpenConfirmation);
            this.ValidateErasedConfirmationCommand = new RelayCommand(ValidateErasedConfirmation);
            this.ValidateFindArticleCommand = new RelayCommand(ValidateFindArticle);
            this.CleanFormCommand = new RelayCommand(CleanForm);
            this.NotPresentModalDelete = false;

            this.IsOpenModal = false;

            this.ArticlesOrder = new ObservableCollection<BOArticleOrder>();

            bOGetOrderErasedRequest = new BOGetOrderErasedRequest()
            {
                CodePointSale = this.whsCodePointSale
            };

            this.EmptyFieldsFindArticle();

            this.EnableSavedAndSendOrder = true;

            if (this.orderListService.ExistRequestFactoryErased(whsCodePointSale))
            {
                this.EnableSavedAndSendOrder = false;
                this.notification.Show(DictMessages.Information, DictMessages.SolicitudesBorradores, NotificationType.Information);
            }

        }

        #endregion

        #region Métodos 
        
        public void reloadPage()
        {
            this.DateDelivery = null;
            this.NotPresentModalDelete = true;
            this.FactoryCode = null;
            this.ArticlesOrder = new ObservableCollection<BOArticleOrder>();
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
                    if (this.FindArticles.Count == 1)
                    {
                        this.FindArticle = this.FindArticles[0];

                        return;
                    }

                    this.IsOpenPopNameArticle = true;

                    break;

                case EnumFieldsFindArticles.Code:

                    bOSearchArticleRequest.Code = this.CodeArticleSearch;

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

            }
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
                this.StateArticleIdSearch = 0;
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
                this.notification.Show(DictMessages.Error, string.Format(DictMessages.ErrMasDosArticulos, this.findArticle.CodeArticle, this.findArticle.NameArticle), NotificationType.Error);

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

            this.ArticlesOrder.OrderBy(a => a.CodeArticle);
        }

        private void EmptyFieldsFindArticle()
        {
            this.QuantityArticleSearch = 0;
            this.StateArticleIdSearch = 0;
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

        private void CleanForm()
        {
            ConfigureModalConfirmation(
               EnumNamesMethods.CLEAN_FORM,
               DictMessages.CleanForm,
               DictIcons.DeleteEmpty,
               DictColors.Red
               );
        }

        public void NotificationVMFather()
        {
            this.ArticlesSelected = uCModalArticles.vMModalArticles.ArticlesSelected;
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
            this.ArticlesOrder.OrderBy(a => a.CodeArticle);
        }

        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetFactoriesAsync()
        {
            List<BOWareHouse> boFactories = await this.wareHouseService.GetFactories();

            this.Factories = new ObservableCollection<BOWareHouse>(boFactories);

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            foreach (var item in Factories)
            {
                item.WhsName = textInfo.ToTitleCase(item.WhsName.ToLower());
            }
        }

        /// <summary>
        /// Método que obtiene los estados de los artículos de forma asíncrona
        /// </summary>  
        private async Task GetStatesArticleAsync()
        {
            List<BOStateArticle> boStatesArticle = await this.articleService.GetStatesArticles();

            this.StatesArticle = new ObservableCollection<BOStateArticle>(boStatesArticle);
        }

        /// <summary>
        /// Método que obtiene los artículos de forma asíncrona
        /// </summary>  
        private async Task GetArticlesAsync(int from, int to, string whsCodeFactory)
        {
            BOPaginationArticle bOPaginationArticle = await this.articleService.GetArticlesByWhsCodeSale(from, to, whsCodeFactory);

            this.Articles = new ObservableCollection<BOArticle>(bOPaginationArticle.Articles);
        }

        private void ShowModalArticles()
        {          

            if (this.FactoryCode == null || string.IsNullOrEmpty(this.FactoryCode))
            {
                this.notification.Show(DictMessages.Information, DictMessages.ErrorSeleccionarPlanta, NotificationType.Information);
                return;
            }           

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

        private void ConfigureModalConfirmation(EnumNamesMethods enumNamesMethodsYes, string messageConfirmation, string iconName, string foreground)
        {
            this.enumNameMethodYes = enumNamesMethodsYes;
            this.messageConfirmation = messageConfirmation; //DictMessages
            this.iconName = iconName;//DictIcons
            this.foreground = foreground;//DictColors
            UCModalConfirmation = new UCModalConfirmation(this);
            this.PrincipalScreen.ModalContainer.Content = UCModalConfirmation;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
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
                case EnumNamesMethods.CLEAN_FORM:
                    CleanFormOrderRequest();
                    break;
                case EnumNamesMethods.DELETE_ARTICLE_ORDER_REQUEST:
                    DeleteArticleToOrder();
                    break;
                case EnumNamesMethods.CLEAR_ARTICLES_CHANGE_FACTORY:
                    DeleteArticlesToOrder();
                    break;
                default:
                    break;
            }

            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }

        public void ExecuteConfirmationNot()
        {

            switch (this.enumNameMethodNot)
            {
                case EnumNamesMethods.CLEAR_ARTICLES_CHANGE_FACTORY_CANCEL:
                    ClearArticlesChangeFactoryCancel();
                    break;
                default:
                    break;
            }

            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }
        private void ClearArticlesChangeFactoryCancel()
        {
            this.FactoryCode = this.previousFactorySelected;
            this.endConfirmationNot = true;
        }
        private void CleanFormOrderRequest()
        {
            this.DateDelivery = null;
            this.FactoryCode = null;
            if (this.ArticlesOrder != null && this.ArticlesOrder.Count > 0)
            {
                this.ArticlesOrder.Clear();
                this.notification.Show(DictMessages.Success, DictMessages.CleanFormSuccess, NotificationType.Success);
            }
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
        private void SaveOrder(EnumStatesOrder enumStatesOrder)
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

            if (this.orderListService.SetOrderRequest(bOOrderRequest))
            {
                this.notification.Show(DictMessages.Success, enumStatesOrder == EnumStatesOrder.Borrador ? DictMessages.RegistrarSolicitudPedidoBorrador : DictMessages.RegistrarSolicitudPedidoDefinitivo, NotificationType.Success);
                this.PrincipalScreen.ContentPage.Content = new UCOrderList(this.PrincipalScreen);
            }
            else
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorGeneral, NotificationType.Error);
            }
        }

        public void Ver()
        {
            this.Open = !this.Open;
        }

        #endregion
    }
}
