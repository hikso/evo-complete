using EVO_PV;
using EVO_PV.Enums;
using EVO_PV.Interfaces;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Resources.Dictionaries;
using EVO_PV.Services;
using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
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
    public class VMOrderListEdit : NotifyPropertyChanged, INotificationVM, IConfirmationModal
    {

        #region Atributos privados
        private MainWindow PrincipalScreen;
        private int ID;
        private ObservableCollection<BOWareHouseTypes> factorieTypes { get; set; }
        private bool isPopObservationOpen { get; set; }
        private string observation { get; set; }
        private DateTime? dateDelivery { get; set; }
        private DateTime dateOrder { get; set; }
        private string factoryCode { get; set; }
        private bool isOpenModal { get; set; }
        private int maximumPageSize { get; set; }
        private EnumConstanst typeVM;
        private string title { get; set; }
        private string subtitle { get; set; }
        private string whsCodePointSale { get; set; }
        private bool isCraftOrder;
        private bool isNotCraftOrder;
        private bool isOnDuplyState;
        private bool isNotDuplyState;
        private bool isNotPurchaseOrder { get; set; }
        private bool isPurchaseOrder { get; set; }
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
        private BOOrderType orderType { get; set; }
        private ObservableCollection<BOOrderType> orderTypes { get; set; }
        private ObservableCollection<BOPackage> packages { get; set; }
        private BOArticle findArticle { get; set; }
        private BOArticleOrder articleOrderSelected { get; set; }
        private ObservableCollection<BOArticleOrder> articlesOrder { get; set; }
        private ObservableCollection<BOStateArticle> statesArticle { get; set; }
        private BOOrderListDetails orderListDetails { get; set; }
        private BOGetOrderErasedRequest bOGetOrderErasedRequest { get; set; }
        private ObservableCollection<BOArticle> findArticles { get; set; }
        private bool enableCleanOrder { get; set; }

        /// <summary>
        /// Campos de búsqueda del artículo
        /// </summary>
        private string codeArticleSearch { get; set; }
        private string nameArticleSearch { get; set; }
        private decimal quantityArticleSearch { get; set; }
        private int stateArticleIdSearch { get; set; }
        private int packageIdSearch { get; set; }
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
        public bool EnableCleanOrder
        {
            get { return enableCleanOrder; }
            set
            {
                this.enableCleanOrder = value;
                this.OnPropertyChanged("EnableCleanOrder");
            }
        }

        public ObservableCollection<BOOrderType> OrderTypes
        {
            get { return orderTypes; }
            set
            {
                orderTypes = value;
                this.OnPropertyChanged("OrderTypes");
            }
        }
        
        public BOOrderType OrderType
        {
            get { return orderType; }
            set
            {
                orderType = value;
                this.OnPropertyChanged("OrderType");
            }
        }

        public bool IsPopObservationOpen
        {
            get { return isPopObservationOpen; }
            set
            {
                this.isPopObservationOpen = value;
                this.OnPropertyChanged("IsPopObservationOpen");
            }
        }

        public string Observation
        {
            get { return observation; }
            set
            {
                this.observation = value;
                this.OnPropertyChanged("Observation");
            }
        }

        public int PackageIdSearch
        {
            get { return packageIdSearch; }

            set
            {
                this.packageIdSearch = value;
                this.OnPropertyChanged("PackageIdSearch");
                if (this.FindArticle != null)
                {
                    this.FindArticle.PackageId = value;
                }
            }
        }

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
                if (this.codeArticleSearch == string.Empty)
                {
                    this.FindArticle = null;
                }
                this.OnPropertyChanged("CodeArticleSearch");

                if (this.FindArticle == null)
                {
                    SearchArticles(EnumFieldsFindArticles.Code);
                }

            }
        }

        public string NameArticleSearch
        {
            get { return nameArticleSearch; }

            set
            {

                this.nameArticleSearch = value;
                if (this.nameArticleSearch == string.Empty)
                {
                    this.FindArticle = null;
                }
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
                if (this.FindArticle != null)
                {
                    this.FindArticle.StateId = value;
                }
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

        public ObservableCollection<BOWareHouseTypes> FactorieTypes
        {
            get { return factorieTypes; }

            set
            {
                this.factorieTypes = value;

                this.OnPropertyChanged("FactorieTypes");
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

        public ObservableCollection<BOPackage> Packages
        {
            get { return packages; }
            set
            {
                this.packages = value;
                this.OnPropertyChanged("Packages");
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
                if (value == null)
                {
                    this.PackageIdSearch = 0;
                }
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

        public bool IsCraftOrder
        {
            get { return isCraftOrder; }

            set
            {
                this.isCraftOrder = value;
                this.OnPropertyChanged("IsCraftOrder");
            }
        }

        public bool IsNotCraftOrder
        {
            get { return isNotCraftOrder; }

            set
            {
                this.isNotCraftOrder = value;
                this.OnPropertyChanged("IsNotCraftOrder");
            }
        }


        public bool IsOnDuplyState
        {
            get { return isOnDuplyState; }

            set
            {
                this.isOnDuplyState = value;
                this.OnPropertyChanged("IsOnDuplyState");
            }
        }
        
        public bool IsNotDuplyState
        {
            get { return isNotDuplyState; }

            set
            {
                this.isNotDuplyState = value;
                this.OnPropertyChanged("IsNotDuplyState");
            }
        }

        public bool IsNotPurchaseOrder
        {
            get { return this.isNotPurchaseOrder; }
            set
            {
                this.isNotPurchaseOrder = value;
                this.OnPropertyChanged("IsNotPurchaseOrder");
            }
        }
        
        public bool IsPurchaseOrder
        {
            get { return this.isPurchaseOrder; }
            set
            {
                this.isPurchaseOrder = value;
                this.OnPropertyChanged("IsPurchaseOrder");
            }
        }

        #endregion

        #region Comandos Eventos de botones 
        public ICommand ViewDetails { get; }
        public ICommand ViewDetailsCraft { get; } /// Botón
        public ICommand ShowModalArticlesCommand { get; }
        public ICommand DeleteArticlesOrderCommand { get; }
        public ICommand DeleteArticleOrderCommand { get; }
        public ICommand KeyDownFindArticleCommand { get; }
        public ICommand ValidateOpenConfirmationCommand { get; }
        public ICommand ValidateErasedConfirmationCommand { get; }
        public ICommand ValidateErasedConfirmationUpdateCommand { get; }
        public ICommand KeyDownFindCodeArticleCommand { get; }
        public ICommand KeyDownFindNameArticleCommand { get; }
        public ICommand ValidateFindArticleCommand { get; }
        public ICommand CmdOpenEditObservation { get; }
        public ICommand CmdOpenEditObservationItem { get; }

        #endregion

        #region Objetos de Servicios
        /// <summary>
        /// Servicios de datos
        /// </summary>
        private WareHouseService wareHouseService;
        private ArticleService articleService;
        private OrderListService OrderListServices;
        private UserService userService;
        private AuditService auditService;
        #endregion

        #region Tareas
        /// <summary>
        /// Task para llamar en el constructor métodos asyncronos
        /// </summary>
        private Task getFactories;
        private Task getArticles;
        private Task getStatesArticles;
        private Task GetOrderListDetails;
        private Task getPackages;
        #endregion

        #region Constructor
        public VMOrderListEdit(MainWindow principalScreen, int id, EnumConstanst type)
        {
            this.PrincipalScreen = principalScreen;
            this.ViewDetails = new RelayCommand(ViewDetailShow);
            this.ViewDetailsCraft = new RelayCommand(ViewDetailShowCraft);
            this.ID = id;
            this.typeVM = type;

            this.maximumPageSize = Convert.ToInt32(App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()]);
            this.whsCodePointSale = App.Current.Properties[EnumConstanst.WhsCode.ToString()].ToString();
            this.OrderListServices = new OrderListService();
            this.wareHouseService = new WareHouseService();
            this.articleService = new ArticleService();
            this.userService = new UserService();
            this.notification = new Notification();
            this.auditService = new AuditService();

            //this.getFactories = GetFactoriesAsync();
            this.getStatesArticles = GetStatesArticleAsync();
            this.GetOrderListDetails = GetOrderListAsync(this.ID);
            this.getPackages = GetPackagesAsync();

            this.ShowModalArticlesCommand = new RelayCommand(ShowModalArticles);
            this.DeleteArticlesOrderCommand = new RelayCommand(DeleteArticlesOrder);
            this.DeleteArticleOrderCommand = new RelayCommand(DeleteArticleOrder);
            this.ValidateOpenConfirmationCommand = new RelayCommand(ValidateOpenConfirmation);
            this.ValidateErasedConfirmationCommand = new RelayCommand(ValidateErasedConfirmation);
            this.ValidateErasedConfirmationUpdateCommand = new RelayCommand(ValidateErasedConfirmationUpdate);
            this.ValidateFindArticleCommand = new RelayCommand(ValidateFindArticle);
            this.CmdOpenEditObservation = new RelayCommand(OpenEditObservation);
            this.CmdOpenEditObservationItem = new RelayCommand<BOArticleOrder>(OpenEditObservationItem);

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

        /// <summary>
        /// Método que abre el pop de observaciones en los detalles del articulo uno a uno
        /// </summary>  
        private void OpenEditObservation()
        {
            this.IsPopObservationOpen = !this.IsPopObservationOpen;
        }

        /// <summary>
        /// Método que abre el pop de observaciones en los detalles del articulo
        /// </summary>  
        private void OpenEditObservationItem(BOArticleOrder bOArticleOrder)
        {
            this.ArticlesOrder.Where(a => a.CodeArticle == bOArticleOrder.CodeArticle && a.StateArticleId == bOArticleOrder.StateArticleId).FirstOrDefault().IsPopObservationOpen = true;
        }

        /// <summary>
        /// Método que obtiene los estados de los artículos de forma asíncrona
        /// </summary>  
        private async Task GetPackagesAsync()
        {
            List<BOPackage> bOPackage = await this.articleService.GetPackages();

            this.Packages = new ObservableCollection<BOPackage>(bOPackage);
            this.Packages.Add(new BOPackage() { PackageName = "Seleccione...", PackageId = 0 });
        }

        private async Task GetOrderListAsync(int id)
        {
            BOOrderListPreview bOOrderListPreview = await this.OrderListServices.GetOrderListDetailsById(id);
            this.FactoryCode = bOOrderListPreview.RequestFor;
            List<BOOrderType> ORegisterorderlist = await this.OrderListServices.GetOrderTypes();
            this.OrderTypes = new ObservableCollection<BOOrderType>(ORegisterorderlist);
            this.OrderType = OrderTypes.Where(r => r.OrderTypeId == bOOrderListPreview.TypeOrderId).FirstOrDefault();
            this.IsCraftOrder = bOOrderListPreview.StateOrderListId == 1;
            this.IsNotCraftOrder = bOOrderListPreview.StateOrderListId != 1;
            this.IsOnDuplyState = false;
            this.IsNotDuplyState = true;
            this.IsPurchaseOrder = bOOrderListPreview.TypeOrderId == int.Parse(App.Current.Properties[EnumConstanst.PurchaseOrderTypeId.ToString()].ToString());
            this.IsNotPurchaseOrder = bOOrderListPreview.TypeOrderId != int.Parse(App.Current.Properties[EnumConstanst.PurchaseOrderTypeId.ToString()].ToString());
            this.DateDelivery = bOOrderListPreview.DateDelivery;


            if (this.typeVM == EnumConstanst.Duplicate)
            {
                this.IsCraftOrder = true;
                this.IsNotCraftOrder = false;
                this.IsOnDuplyState = true;
                this.IsNotDuplyState = false;
            }

            foreach (var item in bOOrderListPreview.Registers)
            {
                item.MaxModification = item.Quantity;
                item.IsNotCraftOrder = this.IsNotCraftOrder;
                this.ArticlesOrder.Add(item);
            }
            EnableCleanOrder = this.ArticlesOrder.Count() > 0;

            this.DateOrder = DateTime.Now.Date;

            DateTime dtDelivery=new DateTime(),dtNow=DateTime.Now.Date;
            if (bOOrderListPreview.DateDelivery!=null)
            {                
                dtDelivery = new DateTime(bOOrderListPreview.DateDelivery.Value.Year, bOOrderListPreview.DateDelivery.Value.Month, bOOrderListPreview.DateDelivery.Value.Day);
            }

            switch (this.typeVM)
            {
                case EnumConstanst.Edit:
                    this.Title = "Editar Pedido: ";
                    this.Subtitle = "Borrador";
                    this.EnableSavedAndSendOrder = true;
                    break;
                case EnumConstanst.Duplicate:
                    bOGetOrderErasedRequest = new BOGetOrderErasedRequest()
                    {
                        CodePointSale = this.whsCodePointSale
                    };

                    if (FactoryCode != null)
                    {
                        if (!this.OrderListServices.ExistRequestFactoryErased(whsCodePointSale, FactoryCode))
                        {
                            this.EnableSavedAndSendOrder = false;
                            this.notification.Show(DictMessages.Information, DictMessages.SolicitudesBorradores, NotificationType.Information);
                        }
                    }

                    this.Title = "Solicitud Pedido: ";
                    this.Subtitle = "Duplicado";
                    break;
            }

            if (bOOrderListPreview.TypeOrderId == 1)
            {
                this.getFactories = this.GetFactoriesAsync(this.FactoryCode);
            }

        }

        private void ViewDetailShow()
        {
            this.PrincipalScreen.ContentPage.Content = new UCOrderList(this.PrincipalScreen);
        }

        private void ViewDetailShowCraft()
        {
            this.PrincipalScreen.ContentPage.Content = new UCNewOrders(this.PrincipalScreen);
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
                this.SuggestedOrderArticleSearch = this.FindArticle.SuggestedOrder.ToString();
                this.QuantityArticleSearch = 0;
                this.StateArticleIdSearch = this.FindArticle.StateId.GetValueOrDefault();
                this.PackageIdSearch = this.FindArticle.PackageId.GetValueOrDefault();
                this.StockArticleSearch = this.FindArticle.Stock.ToString();
                this.MinimumArticleSearch = this.FindArticle.Minimum.ToString();
                this.MaximumArticleSearch = this.FindArticle.Maximum.ToString();
            }
        }

        private void ValidateFindArticle()
        {
            if (this.QuantityArticleSearch <= 0)
            {
                this.notification.Show(DictMessages.Error, DictMessages.ErrorCantidadArticulo, NotificationType.Error);
                return;
            }

            if (this.OrderType.OrderTypeId != 2)
            {
                if (this.StateArticleIdSearch <= 0)
                {
                    this.notification.Show(DictMessages.Error, DictMessages.ErrorEstadoArticulo, NotificationType.Error);
                    return;
                }

            }

            if (this.OrderType.OrderTypeId == 2 && this.ArticlesOrder.Where(a => a.CodeArticle == this.findArticle.CodeArticle).Count() == 1)
            {
                this.notification.Show(
                    DictMessages.Error,
                    string.Format(DictMessages.ErrMasArticulo, this.findArticle.CodeArticle, this.findArticle.NameArticle),
                    NotificationType.Error);
                this.FindArticle = null;

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
            bOArticleOrder.Observations = this.Observation;

            this.ArticlesOrder.Add(bOArticleOrder);
            EmptyFieldsFindArticle();
            this.NameArticleSearch = string.Empty;
            this.CodeArticleSearch = string.Empty;
            this.StateArticleIdSearch = 0;
            this.PackageIdSearch = 0;
            this.UnitMeasureArticleSearch = null;
            this.FindArticle = null;
            this.Observation = string.Empty;
            EnableCleanOrder = this.articlesOrder.Count() > 0;
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
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
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
                if (this.OrderType.OrderTypeId == 2 && this.ArticlesOrder.Where(a => a.CodeArticle == bOArticle.CodeArticle).Count() == 1)
                {
                    this.notification.Show(
                        DictMessages.Error,
                        string.Format(DictMessages.ErrMasArticulo, bOArticle.CodeArticle, bOArticle.NameArticle),
                        NotificationType.Error);
                    this.FindArticle = null;

                    continue;
                }

                if (this.ArticlesOrder.Where(ao => ao.CodeArticle == bOArticle.CodeArticle).Count() == 2)
                {
                    this.notification.Show(DictMessages.Error, DictMessages.ErrMasDosArticulos, NotificationType.Error);
                    continue;
                }

                BOArticleOrder bOArticleOrder = this.mapper.Map<BOArticle, BOArticleOrder>(bOArticle);
                bOArticleOrder.Quantity = (decimal)bOArticle.SuggestedOrder;
                bOArticleOrder.StateArticleId = bOArticle.StateId == null ? 1: bOArticle.StateId;
                bOArticleOrder.PackageId = bOArticle.PackageId == null ? 1: bOArticle.PackageId;
                this.ArticlesOrder.Add(bOArticleOrder);
            }

            EnableCleanOrder = this.articlesOrder.Count() > 0;
        }

        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        //private async Task GetFactoriesAsync()
        //{
        //    List<BOWareHouse> boFactories = await this.wareHouseService.GetFactories();

        //    this.Factories = new ObservableCollection<BOWareHouse>(boFactories);
        //}

        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetFactoriesAsync(string FactoryCode)
        {
            List<BOWareHouseTypes> boFactorieTypes = await this.wareHouseService.GetFactorieTypes();

            this.FactorieTypes = new ObservableCollection<BOWareHouseTypes>(boFactorieTypes);

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            foreach (var item in FactorieTypes)
            {
                item.WhsTypeName = textInfo.ToTitleCase(item.WhsTypeName.ToLower());
                string pfx = FactoryCode.Substring(0,this.factoryCode.IndexOf("-"));
                if (pfx == item.WhsPrefix)
                {
                    this.Factories = new ObservableCollection<BOWareHouse>( item.WareHouses );
                }
            }
            if (this.OrderType.OrderTypeId == 2)
            {
                BOWareHouse buyAreaItem = new BOWareHouse();
                buyAreaItem.InvoiceDiscountPercent = "";
                buyAreaItem.WhsCode = "AR-COM";
                buyAreaItem.WhsName = "Área de Compra";
                this.Factories = new ObservableCollection<BOWareHouse>();
                this.Factories.Add(buyAreaItem);
            }
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
            await this.auditService.SetAuditAsync(new BOAudit()
            {
                Action = "Detalle Pedido",
                Parameters = $"from = {from} , to = {to} , factoryCode = {whsCode}"
            });

            BOPaginationArticle bOPaginationArticle = await this.articleService.GetArticlesByWhsCodeSale(from, to, whsCode, this.OrderType.OrderTypeId.GetValueOrDefault());
            
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

            uCModalArticles = new UCModalArticles(this.PrincipalScreen, this, this.OrderType);
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
            EnableCleanOrder = this.articlesOrder.Count() > 0;
        }

        private void DeleteArticleToOrder()
        {
            this.ArticlesOrder.Remove(this.ArticleOrderSelected);
            this.notification.Show(DictMessages.Success, DictMessages.ArticuloEliminadoCorrectamente, NotificationType.Success);
            EnableCleanOrder = this.articlesOrder.Count() > 0;
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
                if (this.OrderType.OrderTypeId != 2)
                {
                    if (bOArticleOrder.StateArticleId == 0)
                    {
                        bOArticleOrder.ErrorArticle = DictColors.Warning;
                        this.notification.Show(DictMessages.Warning, DictMessages.ErrorDebeSeleccionarEstadoYEmpaque, NotificationType.Warning);
                        return false;
                    }

                    if (bOArticleOrder.PackageId == 0)
                    {
                        bOArticleOrder.ErrorArticle = DictColors.Warning;
                        this.notification.Show(DictMessages.Warning, DictMessages.ErrorDebeSeleccionarEstadoYEmpaque, NotificationType.Warning);
                        return false;
                    }
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
                if (this.OrderType.OrderTypeId != 2)
                {

                    if (articlesOrderEqualCode.Where(a => a.StateArticleId.Value == 0).Count() > 0)
                    {
                        if (this.OrderType.OrderTypeId != 2)
                        {
                            this.notification.Show(DictMessages.Error, DictMessages.ErrorEstadoArticulo, NotificationType.Error);
                        }
                        foreach (BOArticleOrder bOArticleOrder in articlesOrderEqualCode.Where(a => a.StateArticleId.Value == 0))
                        {
                            bOArticleOrder.ErrorArticle = DictColors.Warning;
                        }

                        return false;
                    }

                    if (articlesOrderEqualCode.Where(a => a.StateArticleId == null).Count() > 0)
                    {
                        if (this.OrderType.OrderTypeId != 2)
                        {
                            this.notification.Show(DictMessages.Error, DictMessages.ErrorEstadoArticulo, NotificationType.Error);
                        }
                        foreach (BOArticleOrder bOArticleOrder in articlesOrderEqualCode.Where(a => a.StateArticleId.Value == 0))
                        {
                            bOArticleOrder.ErrorArticle = DictColors.Warning;
                        }

                        return false;
                    }
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

        private void ValidateErasedConfirmationUpdate()
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
                DictMessages.ConfirmarActualizarSolicitud,
                DictIcons.PlaylistAddCheck,
                DictColors.Success
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
            BOUser user = this.userService.GetUser();
            BOWareHouse bOWareHouse = this.wareHouseService.GetWareHouseByCode(this.whsCodePointSale);

            BOOrderEditRequest bOOrderEditRequest = new BOOrderEditRequest()
            {
                OrderListId = id,
                WhsCodePointSale = this.whsCodePointSale,
                StateOrder = enumStatesOrder == EnumStatesOrder.Borrador ? EnumStatesOrder.Borrador.ToString() : EnumStatesOrder.Abierto.ToString(),
                WhsCodeFactory = this.factoryCode,
                OrderTypeId = this.OrderType.OrderTypeId.GetValueOrDefault(),
                User = user.UserName,
                UserName = user.Name,
                WhsEmail = bOWareHouse.Email,
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
                  DetailDeliveryId = a.DetailId,
                  StateArticleId = this.OrderType.OrderTypeId != 2 ? a.StateArticleId.Value : 0,
                  PackageId = a.PackageId,
                  Observations=a.Observations
              }).ToList();

            bOOrderEditRequest.Details.AddRange(Details);
            BOPedidoRespuesta success = this.OrderListServices.SetOrderEditRequest(bOOrderEditRequest);

            if (success.Estado)
            {
                
                this.notification.Show(DictMessages.Success, enumStatesOrder == EnumStatesOrder.Borrador ? DictMessages.RegistrarSolicitudPedidoBorradorActualizado : String.Format(DictMessages.RegistrarSolicitudPedidoDefinitivoActualizar, success.Codigo, success.RespuestaSAP), NotificationType.Success);
                
                if (enumStatesOrder == EnumStatesOrder.Borrador)
                {
                    this.PrincipalScreen.ContentPage.Content = new UCNewOrders(this.PrincipalScreen);
                }
                else
                {
                    this.PrincipalScreen.ContentPage.Content = new UCOrderList(this.PrincipalScreen);
                    this.PrincipalScreen.SubItemsOrders.Where(x => x.Name == "Consulta").FirstOrDefault().IsSelected = true;
                }
            }
            else
            {
                this.notification.Show(DictMessages.Warning, enumStatesOrder == EnumStatesOrder.Borrador ? DictMessages.RegistrarSolicitudPedidoBorradorError : success.RespuestaSAP, NotificationType.Warning, 1);
            }
        }

        private void SaveOrderDuplicate(EnumStatesOrder enumStatesOrder)
        {
            BOUser user = this.userService.GetUser();
            BOWareHouse bOWareHouse = this.wareHouseService.GetWareHouseByCode(this.whsCodePointSale);

            BOOrderRequest bOOrderRequest = new BOOrderRequest()
            {
                WhsCodePointSale = this.whsCodePointSale,
                StateOrder = enumStatesOrder == EnumStatesOrder.Borrador ? EnumStatesOrder.Borrador.ToString() : EnumStatesOrder.Abierto.ToString(),
                WhsCodeFactory = this.factoryCode,
                OrderTypeId = this.OrderType.OrderTypeId.GetValueOrDefault(),
                User = user.UserName,
                UserName = user.Name,
                WhsEmail = bOWareHouse.Email,
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
                  StateArticleId = a.StateArticleId.Value,
                  PackageId = a.PackageId,
                  Observations = a.Observations == null ? "": a.Observations
              }).ToList();

            bOOrderRequest.Details.AddRange(Details);

            BOPedidoRespuesta success = this.OrderListServices.SetOrderRequest(bOOrderRequest);

            if (success.Estado)
            {
                this.notification.Show(DictMessages.Success, enumStatesOrder == EnumStatesOrder.Borrador ? DictMessages.RegistrarSolicitudPedidoBorradorActualizado : String.Format(DictMessages.RegistrarSolicitudPedidoDefinitivo, success.Codigo, success.RespuestaSAP), NotificationType.Success);
                this.PrincipalScreen.ContentPage.Content = new UCOrderList(this.PrincipalScreen);
            }
            else
            {
                this.notification.Show(DictMessages.Warning, enumStatesOrder == EnumStatesOrder.Borrador ? DictMessages.RegistrarSolicitudPedidoBorradorError : success.RespuestaSAP, NotificationType.Warning, 1);
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
            string codeArticlePrefix = this.factoryCode.Substring(this.factoryCode.IndexOf("-") + 1);
            if (this.OrderType.OrderTypeId == 2)
            {
                codeArticlePrefix = "";
            }

            this.FindArticle = null;

            BOSearchArticleRequest bOSearchArticleRequest = new BOSearchArticleRequest()
            {
                WhsCode = this.whsCodePointSale,
                PrefixCodeArticle = codeArticlePrefix,
                TypeOrder = this.OrderType.OrderTypeId.GetValueOrDefault()
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
                    uCModalArticles = new UCModalArticles(this.PrincipalScreen, this, this.OrderType);
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
