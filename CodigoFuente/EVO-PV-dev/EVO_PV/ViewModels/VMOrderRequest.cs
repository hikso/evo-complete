using EVO_PV.Enums;
using EVO_PV.Interfaces;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Resources.Dictionaries;
using EVO_PV.Services;
using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
        private bool isPopObservationOpen { get; set; }
        private bool isNotFactory { get; set; }
        private DateTime nowDate { get; set; }
        private string whsCodePointSale { get; set; }
        private string observation { get; set; }
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
        private string widthForUserControl { get; set; }

        /// <summary>
        /// Servicios de datos
        /// </summary>
        private WareHouseService wareHouseService;

        private ArticleService articleService;

        private UserService userService;

        private OrderListService orderListService;

        private AuditService auditService;
        /// <summary>
        /// Notificación de mensajes
        /// </summary>

        private Notification notification;
        /// <summary>
        /// Tareas para usar metodos asyncrnos en los contructores
        /// </summary>


        private Task getFactorieTypes;

        private Task getArticles;

        private Task getStatesArticles;

        private Task getPackages;

        /// <summary>
        /// Commandos para asociar eventos del viewmodel con los botones de las vistas
        /// </summary>
        public ICommand ShowModalArticlesCommand { get; }
        //public ICommand DeleteArticlesOrderCommand { get; }
        public ICommand DeleteArticleOrderCommand { get; }
        public ICommand ValidateFindArticleCommand { get; }
        public ICommand CmdOpenEditObservation { get; }
        public ICommand CmdOpenEditObservationItem { get; }
        public ICommand KeyDownFindCodeArticleCommand { get; }
        public ICommand KeyDownFindNameArticleCommand { get; }
        public ICommand ValidateOpenConfirmationCommand { get; }
        public ICommand ValidateErasedConfirmationCommand { get; }
        public ICommand CleanFormCommand { get; }
        public ICommand ViewDetailsCraft { get; } /// Botón


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
        private bool isPurchaseOrder { get; set; }
        private bool isNotPurchaseOrder { get; set; }
        private int maximumPageSize { get; set; }
        /// <summary>
        /// Colecciones
        /// </summary>
        private ObservableCollection<BOWareHouseTypes> factorieTypes { get; set; }
        private ObservableCollection<BOWareHouse> factories { get; set; }
        private ObservableCollection<BOArticle> articles { get; set; }
        private ObservableCollection<BOArticle> articlesSelected { get; set; }
        private BOWareHouseTypes factoryTypeSelected { get; set; }
        private string factoryTypeSelectedName { get; set; }
        private BOArticle findArticle { get; set; }
        private BOArticleOrder articleOrderSelected { get; set; }
        private BOGetOrderErasedRequest bOGetOrderErasedRequest { get; set; }
        private ObservableCollection<BOArticleOrder> articlesOrder { get; set; }
        private ObservableCollection<BOStateArticle> statesArticle { get; set; }
        private ObservableCollection<BOPackage> packages { get; set; }
        private ObservableCollection<BOArticle> findArticles { get; set; }

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
        private bool enableSavedAndSendOrder { get; set; }
        private bool enableAddedItems { get; set; }
        private bool disableAddedItems { get; set; }
        private BOOrderType orderType { get; set; }
        private string state { get; set; }
        private Key prevKey { get; set; }
        private bool NotPresentModalDelete { get; set; }
        #endregion

        #region Propiedades 

        public BOOrderType OrderType
        {
            get { return orderType; }
            set
            {
                this.orderType = value;
                this.OnPropertyChanged("OrderType");
            }
        }

        public DateTime NowDate
        {
            get { return nowDate; }
            set
            {
                this.nowDate = value;
                this.OnPropertyChanged("NowDate");
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

        public bool IsNotFactory
        {
            get { return isNotFactory; }
            set
            {
                this.isNotFactory = value;
                this.OnPropertyChanged("IsNotFactory");
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

        private string observation50;
        public string Observation50
        {
            get
            {
                if (observation50 == null)
                {
                    return null;
                }

                if (observation50.Length <= 50)
                {
                    return observation50;
                }

                return observation50.Substring(0, 50);

            }

            set { observation50 = value; this.OnPropertyChanged("Observation50"); }

        }

        public string Observation
        {
            get { return observation; }

            set
            {
                if (value != null && value.Length > 100)
                {
                    return;
                }

                this.observation = value;
                Observation50 = this.observation;
                this.OnPropertyChanged("Observation");

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

        public bool EnableAddedItems
        {
            get { return enableAddedItems; }

            set
            {
                this.enableAddedItems = value;
                DisableAddedItems = !value;
                this.OnPropertyChanged("EnableAddedItems");

            }
        }

        public bool DisableAddedItems
        {
            get { return disableAddedItems; }

            set
            {
                this.disableAddedItems = value;

                this.OnPropertyChanged("DisableAddedItems");

            }
        }

        public string CodeArticleSearch
        {
            get 
            {                
                return codeArticleSearch;
            }

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
            get 
            {    
                return nameArticleSearch;
            }

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
            get 
            {               
                return articlesOrder;
            }

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

        public ObservableCollection<BOWareHouseTypes> FactorieTypes
        {
            get { return factorieTypes; }

            set
            {
                this.factorieTypes = value;

                this.OnPropertyChanged("FactorieTypes");
            }
        }

        public BOWareHouseTypes FactoryTypeSelected
        {
            get { return factoryTypeSelected; }

            set
            {

                this.factoryTypeSelected = value;
                this.factoryTypeSelected.WareHouses = this.factoryTypeSelected.WareHouses.OrderBy(r => r.WhsName).ToList();
                this.Factories = new ObservableCollection<BOWareHouse>(this.factoryTypeSelected.WareHouses);
                this.OnPropertyChanged("FactoryTypeSelected");

            }
        }

        public string FactoryTypeSelectedName
        {
            get { return factoryTypeSelectedName; }

            set
            {
                EmptyFieldsFindArticle();
                this.factoryTypeSelectedName = value;
                this.FactoryTypeSelected = this.FactorieTypes.Where(r => r.WhsTypeName == this.FactoryTypeSelectedName).FirstOrDefault();
                //TODO: Factory codes to identify there
                this.IsNotFactory = this.FactoryTypeSelected.WhsTypeName == "Puntos De Venta";
                FactoryCode = null;
                if (!IsNotFactory)
                {
                    FactoryCode = this.FactoryTypeSelected.WareHouses[0].WhsCode;
                }
                this.OnPropertyChanged("FactoryTypeSelectedName");


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

                if (!string.IsNullOrWhiteSpace(this.factoryCode))
                {
                    {
                        BOGetOrderErasedRequest request = new BOGetOrderErasedRequest()
                        {
                            CodePointSale = ConfigurationManager.AppSettings[EnumConstanst.CODIGO_PUNTO_VENTA.ToString()],
                            CodeFactory = this.factoryCode
                        };

                        if (this.orderListService.GetStateErasedOrderRequestFactory(request))
                        {
                            this.State = "true";
                            this.notification.Show(DictMessages.Error, DictMessages.ExistePedidoBorrador, NotificationType.Error);
                            this.EnableSavedAndSendOrder = false;
                        }
                        else
                        {
                            this.State = "false";
                            this.EnableSavedAndSendOrder = true;
                        }
                    }

                    if (this.endConfirmationNot)
                    {
                        //Si es "True" es porque viene de la confirmación del "No".
                        this.endConfirmationNot = false;
                        return;
                    }

                    if (this.ArticlesOrder.Count > 0 && !NotPresentModalDelete && this.OrderType.OrderTypeId != 2)
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

                    //if (!string.IsNullOrWhiteSpace(this.factoryCode))
                    //{
                    //    string prefix = this.OrderType.OrderTypeId == 2 ? this.factoryCode.Substring(0, this.factoryCode.IndexOf("-")) : FactoryTypeSelected.WhsPrefix;
                    //    bOGetOrderErasedRequest.CodeFactory = this.factoryCode;

                    //    this.auditService.SetAudit(new BOAudit()
                    //    {
                    //        Action = "Existen solicitudes de pedidos en estado Borrador en todas las plantas",
                    //        Parameters = $" whsCodePointSale = { JsonConvert.SerializeObject(whsCodePointSale)} , prefix = {prefix} "
                    //    });

                    //    if (this.orderListService.ExistRequestFactoryErased(whsCodePointSale, this.factoryCode))
                    //    //if (!this.orderListService.ExistRequestFactoryErased(whsCodePointSale, prefix))
                    //    {
                    //        this.State = "true";
                    //        this.notification.Show(DictMessages.Information, DictMessages.ErrorOrderErased, NotificationType.Information);
                    //        this.EnableSavedAndSendOrder = false;
                    //    }
                    //    else
                    //    {
                    //        this.State = "false";
                    //        this.EnableSavedAndSendOrder = true;
                    //    }


                    //}

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

        public bool IsPurchaseOrder
        {
            get { return this.isPurchaseOrder; }
            set
            {
                this.isPurchaseOrder = value;
                this.OnPropertyChanged("IsPurchaseOrder");
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

        public string WidthForUserControl
        {
            get { return widthForUserControl; }

            set
            {
                this.widthForUserControl = value;
                this.OnPropertyChanged("WidthForUserControl");
            }
        }
        #endregion

        #region Constructores
        public VMOrderRequest(MainWindow principalScreen, BOOrderType bOOrderType)
        {

            this.PrincipalScreen = principalScreen;
            this.OrderType = bOOrderType;
            this.IsPurchaseOrder = OrderType.OrderTypeId == int.Parse(App.Current.Properties[EnumConstanst.PurchaseOrderTypeId.ToString()].ToString());
            this.IsNotPurchaseOrder = OrderType.OrderTypeId != int.Parse(App.Current.Properties[EnumConstanst.PurchaseOrderTypeId.ToString()].ToString());
            this.DateOrder = DateTime.Now.Date;
            this.IsPopObservationOpen = false;
            this.maximumPageSize = Convert.ToInt32(App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()]);
            this.whsCodePointSale = App.Current.Properties[EnumConstanst.WhsCode.ToString()].ToString();
            this.EnableAddedItems = false;
            this.wareHouseService = new WareHouseService();
            this.articleService = new ArticleService();
            this.notification = new Notification();
            this.userService = new UserService();
            this.orderListService = new OrderListService();
            this.auditService = new AuditService();

            this.getFactorieTypes = GetFactorieTypesAsync();
            this.getStatesArticles = GetStatesArticleAsync();
            this.getPackages = GetPackagesAsync();

            this.ShowModalArticlesCommand = new RelayCommand(ShowModalArticles);
            //this.DeleteArticlesOrderCommand = new RelayCommand(DeleteArticlesOrder);
            this.DeleteArticleOrderCommand = new RelayCommand(DeleteArticleOrder);
            this.ValidateOpenConfirmationCommand = new RelayCommand(ValidateOpenConfirmation);
            this.ValidateErasedConfirmationCommand = new RelayCommand(ValidateErasedConfirmation);
            this.ValidateFindArticleCommand = new RelayCommand(ValidateFindArticle);
            this.CmdOpenEditObservation = new RelayCommand(OpenEditObservation);
            this.CmdOpenEditObservationItem = new RelayCommand<BOArticleOrder>(OpenEditObservationItem);
            this.ViewDetailsCraft = new RelayCommand(ViewDetailShowCraft);

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

            if (FactoryCode != null)
            {

                auditService.SetAudit(new BOAudit()
                {
                    Action = "Existen solicitudes de pedidos en estado Borrador en todas las plantas",
                    Parameters = $" whsCodePointSale = { JsonConvert.SerializeObject(whsCodePointSale)} , FactoryTypeSelected.WhsPrefix = {FactoryTypeSelected.WhsPrefix} "
                });


                if (!this.orderListService.ExistRequestFactoryErased(whsCodePointSale, FactoryTypeSelected.WhsPrefix))
                {
                    this.EnableSavedAndSendOrder = false;
                    this.notification.Show(DictMessages.Information, DictMessages.SolicitudesBorradores, NotificationType.Information);
                }
            }
            if (this.OrderType.OrderTypeId == 2)
            {
                string codePontOfSale = ConfigurationManager.AppSettings[EnumConstanst.CODIGO_PUNTO_VENTA.ToString()];
                this.FactoryCode = codePontOfSale;
            }
            principalScreen.SizeChanged += PrincipalScreen_SizeChanged;
            principalScreen.StateChanged += PrincipalScreen_StateChanged;
            principalScreen.NotifyOpenMenu += PrincipalScreen_NotifyOpenMenu;
        }

        private void PrincipalScreen_NotifyOpenMenu()
        {
            if (this.PrincipalScreen.MenuIsOpen)
            {
                this.WidthForUserControl = (this.PrincipalScreen.Width - 290).ToString();
            }
            else
            {
                this.WidthForUserControl = (this.PrincipalScreen.Width - 100).ToString();
            }
        }

        private void PrincipalScreen_StateChanged(object sender, EventArgs e)
        {
            if (this.PrincipalScreen.WindowState == WindowState.Maximized)
            {
                this.PrincipalScreen.Width = SystemParameters.PrimaryScreenWidth;
            }
        }

        private void PrincipalScreen_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.PrincipalScreen.MenuIsOpen)
            {
                this.WidthForUserControl = (this.PrincipalScreen.Width - 290).ToString();
            }
            else
            {
                this.WidthForUserControl = (this.PrincipalScreen.Width - 100).ToString();
            }
        }
        #endregion

        #region Métodos 

        public void reloadPage()
        {
            this.DateDelivery = DateTime.Now;
            this.NotPresentModalDelete = true;
            this.FactoryCode = null;
            this.ArticlesOrder = new ObservableCollection<BOArticleOrder>();
        }

        private string getCodePrefix(string factoryCode)
        {
            string[] factories = { "PT", "PTD" };
            return Array.Exists(factories, element => element == factoryCode) ? factoryCode : "";
        }

        private void SearchArticles(EnumFieldsFindArticles enumFieldsFindArticles)
        {
            this.IsOpenPopNameArticle = false;

            this.IsOpenPopCodeArticle = false;

            this.EmptyFieldsFindArticle();

            if (string.IsNullOrEmpty(this.FactoryCode) && this.OrderType.OrderTypeId != 2)
            {
                if (FactoryTypeSelectedName == "Puntos De Venta")
                {
                    this.notification.Show(DictMessages.Information, DictMessages.ErrorNoSeleccionPuntoVenta, NotificationType.Information);
                    return;
                }
                this.notification.Show(DictMessages.Information, DictMessages.ErrorSeleccionarPlanta, NotificationType.Information);
                return;
            }

            string codeArticlePrefix = string.Empty;

            if (!string.IsNullOrEmpty(this.FactoryCode))
            {
                codeArticlePrefix = getCodePrefix(this.factoryCode.Substring(this.factoryCode.IndexOf("-") + 1));
            }

            this.FindArticle = null;

            BOSearchArticleRequest bOSearchArticleRequest = new BOSearchArticleRequest()
            {
                WhsCode = this.whsCodePointSale,
                PrefixCodeArticle = codeArticlePrefix,
                TypeOrder = this.OrderType.OrderTypeId

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

                    if (string.IsNullOrEmpty(bOSearchArticleRequest.Code))
                    {
                        return;
                    }

                    this.FindArticles = new ObservableCollection<BOArticle>(this.articleService.GetArticlesSearch(bOSearchArticleRequest));

                    if (this.FindArticles.Count == 0)
                    {
                        return;
                    }

                    this.IsOpenPopCodeArticle = true;

                    break;
            }

            this.auditService.SetAudit(new BOAudit()
            {
                Action = "Buscar artículo",
                Parameters = JsonConvert.SerializeObject(bOSearchArticleRequest)
            });
        }

        public void KeyDownUserControl(Key key)
        {
            switch (key)
            {
                case Key.F3:

                    if (string.IsNullOrEmpty(this.FactoryCode) && this.OrderType.OrderTypeId != 2)
                    {
                        if (FactoryTypeSelectedName == "Puntos De Venta")
                        {
                            this.notification.Show(DictMessages.Information, DictMessages.ErrorNoSeleccionPuntoVenta, NotificationType.Information);
                            return;
                        }
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

            }
        }

        private void SetFindArticle()
        {
            if (this.FindArticle != null)
            {
                this.CodeArticleSearch = this.FindArticle.CodeArticle;
                this.NameArticleSearch = this.FindArticle.NameArticle;
                this.UnitMeasureArticleSearch = this.FindArticle.UnitMeasure;
                this.SuggestedOrderArticleSearch = this.FindArticle.SuggestedOrder.ToString();
                this.StateArticleIdSearch = this.FindArticle.StateId != null ? this.FindArticle.StateId.GetValueOrDefault() : 0;
                this.PackageIdSearch = this.FindArticle.PackageId != null ? this.FindArticle.PackageId.GetValueOrDefault() : 0;
                this.SuggestedOrderArticleSearch = this.FindArticle.SuggestedOrder.ToString();
                this.QuantityArticleSearch = (decimal)this.FindArticle.SuggestedOrder;
                this.StockArticleSearch = this.FindArticle.Stock.ToString();
                this.MinimumArticleSearch = this.FindArticle.Minimum.ToString();
                this.MaximumArticleSearch = this.FindArticle.Maximum.ToString();
            }
        }

        private void OpenEditObservation()
        {
            this.IsPopObservationOpen = !this.IsPopObservationOpen;
        }

        private void OpenEditObservationItem(BOArticleOrder bOArticleOrder)
        {
            this.ArticlesOrder.Where(a => a.CodeArticle == bOArticleOrder.CodeArticle && a.StateArticleId == bOArticleOrder.StateArticleId).FirstOrDefault().IsPopObservationOpen = true;
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
            bOArticleOrder.StateArticleId = this.FindArticle.StateId;
            bOArticleOrder.PackageId = this.FindArticle.PackageId;
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
            this.ArticlesOrder.OrderBy(a => a.CodeArticle);
            EnableAddedItems = this.articlesOrder.Count() > 0;
        }



        private void EmptyFieldsFindArticle()
        {
            this.QuantityArticleSearch = 0;
            this.StateArticleIdSearch = 0;
            this.PackageIdSearch = 0;
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
                bOArticleOrder.StateArticleId = 1;

                this.ArticlesOrder.Add(bOArticleOrder);
            }

            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
            this.ArticlesOrder.OrderBy(a => a.CodeArticle);
            EnableAddedItems = this.articlesOrder.Count() > 0;
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
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetFactorieTypesAsync()
        {
            List<BOWareHouseTypes> boFactorieTypes = await this.wareHouseService.GetFactorieTypes();

            this.FactorieTypes = new ObservableCollection<BOWareHouseTypes>(boFactorieTypes);

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            foreach (var item in FactorieTypes)
            {
                item.WhsTypeName = textInfo.ToTitleCase(item.WhsTypeName.ToLower());
            }
        }

        /// <summary>
        /// Método que obtiene los estados de los artículos de forma asíncrona
        /// </summary>  
        private async Task GetStatesArticleAsync()
        {
            List<BOStateArticle> boStatesArticle = await this.articleService.GetStatesArticles();

            await this.auditService.SetAuditAsync(new BOAudit()
            {
                Action = "Obtener estado de artículos",
                Parameters = string.Empty
            });

            this.StatesArticle = new ObservableCollection<BOStateArticle>(boStatesArticle);
        }

        /// <summary>
        /// Método que obtiene los estados de los artículos de forma asíncrona
        /// </summary>  
        private async Task GetPackagesAsync()
        {
            List<BOPackage> bOPackage = await this.articleService.GetPackages();

            await this.auditService.SetAuditAsync(new BOAudit()
            {
                Action = "Obtener empaques",
                Parameters = string.Empty
            });

            this.Packages = new ObservableCollection<BOPackage>(bOPackage);
        }

        /// <summary>
        /// Método que obtiene los artículos de forma asíncrona
        /// </summary>  
        private async Task GetArticlesAsync(int from, int to, string whsCodeFactory)
        {
            await this.auditService.SetAuditAsync(new BOAudit()
            {
                Action = "Obtener artículos",
                Parameters = $"from = {from} , to = {to} , whsCodeFactory = {whsCodeFactory}"
            });

            BOPaginationArticle bOPaginationArticle = await this.articleService.GetArticlesByWhsCodeSale(from, to, whsCodeFactory, this.OrderType.OrderTypeId.GetValueOrDefault());

            this.Articles = new ObservableCollection<BOArticle>(bOPaginationArticle.Articles);
        }

        private void ShowModalArticles()
        {

            if ((this.FactoryCode == null || string.IsNullOrEmpty(this.FactoryCode)) && this.OrderType.OrderTypeId != 2)
            {
                if (FactoryTypeSelectedName == "Puntos De Venta")
                {
                    this.notification.Show(DictMessages.Information, DictMessages.ErrorNoSeleccionPuntoVenta, NotificationType.Information);
                    return;
                }

                this.notification.Show(DictMessages.Information, DictMessages.ErrorSeleccionarPlanta, NotificationType.Information);
                return;
            }

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
            if (this.OrderType.OrderTypeId != 2)
            {
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
            }
            else
            {
                string codePontOfSale = ConfigurationManager.AppSettings[EnumConstanst.CODIGO_PUNTO_VENTA.ToString()];
                this.FactoryCode = codePontOfSale;
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
                        this.notification.Show(DictMessages.Information, DictMessages.ErrorDebeSeleccionarEstadoYEmpaque, NotificationType.Information);
                        return false;
                    }

                    if (bOArticleOrder.PackageId == 0)
                    {
                        bOArticleOrder.ErrorArticle = DictColors.Warning;
                        this.notification.Show(DictMessages.Information, DictMessages.ErrorDebeSeleccionarEstadoYEmpaque, NotificationType.Information);
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
                case EnumNamesMethods.ITEM_ADDED_AND_BACK:
                    ComeBack();
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
            this.DateDelivery = DateTime.Now;
            this.FactoryCode = null;
            if (this.ArticlesOrder != null && this.ArticlesOrder.Count > 0)
            {
                this.ArticlesOrder.Clear();
                this.notification.Show(DictMessages.Success, DictMessages.CleanFormSuccess, NotificationType.Success);

            }
            EnableAddedItems = this.articlesOrder.Count() > 0;
        }

        private void ViewDetailShowCraft()
        {
            if (this.EnableAddedItems)
            {
                ConfigureModalConfirmation(
                    EnumNamesMethods.ITEM_ADDED_AND_BACK,
                    DictMessages.ItemAddedAndBack,
                    DictIcons.Alert,
                    DictColors.Info
                );
            }
            else
            {
                this.PrincipalScreen.ContentPage.Content = new UCNewOrders(this.PrincipalScreen);
            }
        }

        private void ComeBack()
        {
            this.PrincipalScreen.ContentPage.Content = new UCNewOrders(this.PrincipalScreen);
        }

        private void DeleteArticlesToOrder()
        {
            this.ArticlesOrder.Clear();
            this.notification.Show(DictMessages.Success, DictMessages.ArticulosEliminadosCorrectamente, NotificationType.Success);
            EnableAddedItems = this.articlesOrder.Count() > 0;
        }
        private void DeleteArticleToOrder()
        {
            this.ArticlesOrder.Remove(this.ArticleOrderSelected);
            this.notification.Show(DictMessages.Success, DictMessages.ArticuloEliminadoCorrectamente, NotificationType.Success);
            EnableAddedItems = this.articlesOrder.Count() > 0;
        }
        private void SaveOrder(EnumStatesOrder enumStatesOrder)
        {
            BOUser bOUser = this.userService.GetUser();

            BOWareHouse bOWareHouse = this.wareHouseService.GetWareHouseByCode(this.whsCodePointSale);

            BOOrderRequest bOOrderRequest = new BOOrderRequest()
            {
                WhsCodePointSale = this.whsCodePointSale,
                StateOrder = enumStatesOrder == EnumStatesOrder.Borrador ? EnumStatesOrder.Borrador.ToString() : EnumStatesOrder.Abierto.ToString(),
                WhsCodeFactory = this.factoryCode,
                OrderTypeId = this.OrderType.OrderTypeId,
                User = bOUser.UserName,
                UserName = bOUser.Name,
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
                  PackageId = a.PackageId,
                  Observations = a.Observations == null ? "" : a.Observations,
                  StateArticleId = this.OrderType.OrderTypeId != 2 ? a.StateArticleId.Value : 0
              }).ToList();

            bOOrderRequest.Details.AddRange(Details);

            BOPedidoRespuesta success = this.orderListService.SetOrderRequest(bOOrderRequest);

            this.auditService.SetAudit(new BOAudit()
            {
                Action = "Guarda el pedido creado en solicitud de pedido",
                Parameters = $" bOOrderRequest = { JsonConvert.SerializeObject(bOOrderRequest)} "
            });
            
            if (success.Estado)
            {
                this.notification.Show(DictMessages.Success, enumStatesOrder == EnumStatesOrder.Borrador ? DictMessages.RegistrarSolicitudPedidoBorrador : String.Format(DictMessages.RegistrarSolicitudPedidoDefinitivo, success.Codigo, success.RespuestaSAP), NotificationType.Success);

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
                this.notification.Show(DictMessages.Warning, enumStatesOrder == EnumStatesOrder.Borrador ? DictMessages.RegistrarSolicitudPedidoBorrador : success.RespuestaSAP, NotificationType.Warning, 1);
            }
        }

        public void Ver()
        {
            this.Open = !this.Open;
        }

        #endregion
    }
}
