using EVO_PV.Enums;
using EVO_PV.Interfaces;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Proxy;
using EVO_PV.Resources.Dictionaries;
using EVO_PV.Services;
using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
using IntegracionBasculasPorcicarnes.CustomEventArgs;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 23-Feb/2020
    /// Descripción      : Esta clase implementa la lógica de negocio de "Alistamiento"
    /// </summary>
    public class VMReceive : NotifyPropertyChanged, IConfirmationModal
    {
        #region Atributos
        #region Servicios
        private RequestService requestService;
        private DeliveryService deliveryService;
        private ArticleService articleService;
        private ContainerService containerService;
        private SellerService sellerService;
        private WeighingService weighingService;
        #endregion
        #region Observables
        private ObservableCollection<BOSeller> sellers { get; set; }
        private ObservableCollection<BODelivery> deliveries { get; set; }
        private ObservableCollection<BOContainers> containers { get; set; }
        private ObservableCollection<BOContainers> containersAtEight { get; set; }
        private ObservableCollection<BOContainers> containersAtFive { get; set; }
        private ObservableCollection<BOWeighingDetail> weighingDetail { get; set; }
        private ObservableCollection<BOBarCodeWeighing> barCodeDetails { get; set; }
        #endregion
        #region Controles de usuario
        private MainWindow PrincipalScreen;
        UCModalEvidenceForm UCModalEvidenceForm;
        UCModalConfirmation UCModalConfirmation;
        UCCustomMessages UCCustomMessages;
        #endregion
        #region Business Object
        private BOWeighing weighingByArticle { get; set; }
        private BOBarCodeWeighing articleBarCodeToRead;
        private BODeliveryReceiveHeader deliveryHeader { get; set; }
        private BOWeighingDetail articleBeingWeighing { get; set; }
        private BOArticleReceive articleSelected { get; set; }
        #endregion

        private List<BOArticleReceive> articlesToBeReceives { get; set; }
        private List<BOArticuloDocumento> articuloDocumentos { get; set; }
        private List<BOWeighingByArticle> weighingsByArticle { get; set; }
        private List<BOContainers> contenedoresPesajes { get; set; }
        
        private EnumNamesMethods enumNameMethodYes { get; set; }
        private EnumNamesMethods enumNameMethodNot { get; set; }
        
        private Notification notification;

        private string widhtForUserControl { get; set; }
        private string mainWindowWidth { get; set; }
        private string weighingBascule { get; set; }
        private string weighingBasculeState { get; set; }
        private string clientName { get; set; }
        private string previousOrderSelected { get; set; }
        private string orderId { get; set; }
        private string deliveryId { get; set; }
        private string messageConfirmation { get; set; }
        private string iconName { get; set; }
        private string foreground { get; set; }
        private string containersTotalWeight { get; set; }
        private string totalWeightByBascule { get; set; }
        private string totalWeightByBarCode { get; set; }
        private string observation { get; set; }

        private bool confirmingBascule { get; set; }
        private bool confirmingReceiving { get; set; }
        private bool confirmingReceivingByQuantityAndUnitMeasure { get; set; }
        private bool thereAreDifferences { get; set; }
        private bool isExpanded { get; set; }
        private bool showSpinner { get; set; }

        private int verification { get; set; }
        private int verificationZeros { get; set; }
        private bool enableSave { get; set; }
        private bool enableSaveFalse { get; set; }
        #endregion

        #region Propiedades publicas    

        public bool EnableSave
        {
            get { return this.enableSave; }
            set
            {
                this.enableSave = value;
                this.OnPropertyChanged("EnableSave");
            }
        }

        public bool EnableSaveFalse
        {
            get { return this.enableSaveFalse; }
            set
            {
                this.enableSaveFalse = value;
                this.OnPropertyChanged("EnableSaveFalse");
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

        public ObservableCollection<BOOrderRequestList> Requests
        {
            get { return requests; }

            set
            {
                this.requests = value;
                this.OnPropertyChanged("Requests");
            }
        }

        public string ClientName
        {
            get { return clientName; }

            set
            {
                this.clientName = value;

                this.OnPropertyChanged("ClientName");

            }
        }

        public string OrderId
        {
            get
            {
                return this.orderId;
            }
            set
            {

                this.previousOrderSelected = orderId;
                this.orderId = value;
                this.OnPropertyChanged("OrderId");

                if (!string.IsNullOrWhiteSpace(this.orderId))
                {
                    this.getDeliveries = GetDeliveriesAsync(orderId);

                }

            }
        }

        public BODeliveryReceiveHeader DeliveryHeader
        {
            get { return deliveryHeader; }

            set
            {
                this.deliveryHeader = value;

                this.OnPropertyChanged("DeliveryHeader");
            }
        }

        public ObservableCollection<BODelivery> Deliveries
        {
            get { return deliveries; }

            set
            {
                this.deliveries = value;
                this.OnPropertyChanged("Deliveries");
            }
        }

        public List<BOArticleReceive> ArticlesToBeReceives
        {
            get { return articlesToBeReceives; }

            set
            {
                this.articlesToBeReceives = value;
                this.OnPropertyChanged("ArticlesToBeReceives");
            }
        }

        public List<BOArticuloDocumento> ArticuloDocumentos
        {
            get { return articuloDocumentos; }

            set
            {
                this.articuloDocumentos = value;
                this.OnPropertyChanged("ArticuloDocumentos");
            }
        }

        public BOWeighing WeighingByArticle
        {
            get { return weighingByArticle; }

            set
            {
                this.weighingByArticle = value;
                this.OnPropertyChanged("WeighingByArticle");
            }
        }

        public string ContainersTotalWeight
        {
            get { return containersTotalWeight; }
            set
            {
                this.containersTotalWeight = value;
                this.OnPropertyChanged("ContainersTotalWeight");
            }
        }

        public string DeliveryId
        {
            get
            {
                return this.deliveryId;
            }
            set
            {

                this.deliveryId = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (!this.Deliveries.Where(d => d.DeliveryId.ToString() == value).First().CanBeReceive && this.Deliveries.First().DeliveryId.ToString() != value)
                    {
                        this.notification.Show(DictMessages.Warning, DictMessages.ErrorDebeTerminarLaEntregaAnterior, NotificationType.Error);
                        this.DeliveryId = this.Deliveries.First().DeliveryId.ToString();
                        this.deliveryId = this.Deliveries.First().DeliveryId.ToString();
                    }

                    this.getDeliveryReceiveHeader = GetDeliveryReceiveHeaderAsync(this.deliveryId);
                    this.getArticlesToBeReceive = GetArticlesToBeReceiveAsync(this.deliveryId);
                }
                this.OnPropertyChanged("DeliveryId");

            }
        }

        public string TotalWeightByBascule
        {
            get
            {
                return this.totalWeightByBascule;
            }
            set
            {
                this.totalWeightByBascule = value;
                this.OnPropertyChanged("TotalWeightByBascule");
            }
        }

        public string TotalWeightByBarCode
        {
            get
            {
                return this.totalWeightByBarCode;
            }
            set
            {
                this.totalWeightByBarCode = value;
                this.OnPropertyChanged("TotalWeightByBarCode");
            }
        }

        public ObservableCollection<BOContainers> Containers
        {
            get
            {
                return this.containers ?? (containers = new ObservableCollection<BOContainers>());
            }
            set
            {
                this.containers = value;
                this.OnPropertyChanged("Containers");
            }
        }        
        
        public ObservableCollection<BOContainers> ContainersAtEight
        {
            get
            {
                return this.containersAtEight ?? (containersAtEight = new ObservableCollection<BOContainers>());
            }
            set
            {
                this.containersAtEight = value;
                this.OnPropertyChanged("ContainersAtEight");
            }
        }        
        
        public ObservableCollection<BOContainers> ContainersAtFive
        {
            get
            {
                return this.containersAtFive ?? (containersAtFive = new ObservableCollection<BOContainers>());
            }
            set
            {
                this.containersAtFive = value;
                this.OnPropertyChanged("ContainersAtFive");
            }
        }

        public string WeighingBascule
        {
            get { return weighingBascule; }

            set
            {
                this.weighingBascule = value;
                this.OnPropertyChanged("WeighingBascule");
            }
        }

        public string WeighingBasculeState
        {
            get { return weighingBasculeState; }
            set 
            {
                this.weighingBasculeState = value;
                this.OnPropertyChanged("WeighingBasculeState");
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

        public ObservableCollection<BOWeighingDetail> WeighingDetail
        {
            get { return weighingDetail; }

            set
            {
                this.weighingDetail = value;
                this.OnPropertyChanged("WeighingDetail");
            }
        }

        public BOBarCodeWeighing ArticleBarCodeToRead
        {
            get { return this.articleBarCodeToRead; }
            set
            {
                this.articleBarCodeToRead = value;
                this.OnPropertyChanged("ArticleBarCodeToRead");
            }
        }

        public bool ThereAreDifferences
        {
            get { return this.thereAreDifferences; }
            set
            {
                this.thereAreDifferences = value;
                this.OnPropertyChanged("ThereAreDifferences");
            }
        }

        public ObservableCollection<BOBarCodeWeighing> BarCodeDetails
        {
            get
            {
                return this.barCodeDetails;
            }
            set
            {
                this.barCodeDetails = value;
                this.OnPropertyChanged("BarCodeDetails");
                double sum = 0;
                if (barCodeDetails != null)
                {
                    foreach (var item in barCodeDetails)
                    {
                        sum += double.Parse(item.Weight, CultureInfo.InvariantCulture);

                    }
                }
                this.TotalWeightByBarCode = sum.ToString();
                this.ThereAreDifferences = this.TotalWeightByBarCode != this.TotalWeightByBascule;

            }
        }

        public List<BOContainers> ContenedoresPesajes
        {
            get
            {
                return this.contenedoresPesajes;
            }
            set
            {
                this.contenedoresPesajes = value;
                this.OnPropertyChanged("ContenedoresPesajes");
            }
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

        public List<BOWeighingByArticle> WeighingsByArticle
        {
            get
            {
                return this.weighingsByArticle;
            }
            set
            {
                this.weighingsByArticle = value;
                this.OnPropertyChanged("WeighingsByArticle");
            }
        }

        public BOArticleReceive ArticleSelected
        {
            get { return articleSelected; }

            set
            {
                this.TotalWeightByBascule = "0";
                this.articleSelected = value;
                this.OnPropertyChanged("ArticleSelected");
                this.PrincipalScreen.GeneralScroll.ScrollToBottom();
                if (this.articleSelected != null)
                {
                    this.PrincipalScreen.StickyContent.Content = new UCArticleSelectedInfo(this.PrincipalScreen, this.articleSelected);
                }
                this.IsExpanded = false;
                ChargeArticle();
            }
        }
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                this.isExpanded = value;
                this.OnPropertyChanged("IsExpanded");
            }
        }
        public BOWeighingDetail ArticleBeingWeighing
        {
            get { return articleBeingWeighing; }
            set
            {
                this.articleBeingWeighing = value;
                this.OnPropertyChanged("ArticleBeingWeighing");
                this.BarCodeDetails = new ObservableCollection<BOBarCodeWeighing>();

                BOBarCodeWeighing bOBarCodeWeighing = new BOBarCodeWeighing();
                bOBarCodeWeighing.BarCode = "";
                bOBarCodeWeighing.ArticleName = ArticleSelected.ArticleName;
                bOBarCodeWeighing.ArticleCode = ArticleSelected.ArticleCode;
                bOBarCodeWeighing.MeasureUnit = ArticleSelected.MeasureUnit;
                bOBarCodeWeighing.ArticleState = ArticleSelected.State;
                BarCodeDetails.Add(bOBarCodeWeighing);
                double sum = 0;
                this.TotalWeightByBarCode = "0";
                if (articleBeingWeighing != null && articleBeingWeighing.ArticleWeighingId != "0")
                {
                    List<BOBarCodeWeighing> barCodeDetails = this.weighingService.GetBarCodes(ArticleBeingWeighing.ArticleWeighingId);


                    foreach (var item in barCodeDetails)
                    {
                        BOBarCodeWeighing bOBarCodeWeighingToBeAdded = new BOBarCodeWeighing();

                        bOBarCodeWeighingToBeAdded.ArticleName = articleSelected.ArticleName;
                        bOBarCodeWeighingToBeAdded.ArticleCode = articleSelected.ArticleCode;
                        bOBarCodeWeighingToBeAdded.MeasureUnit = articleSelected.MeasureUnit;
                        bOBarCodeWeighingToBeAdded.ArticleState = articleSelected.State;
                        bOBarCodeWeighingToBeAdded.Lot = item.Lot;
                        bOBarCodeWeighingToBeAdded.Weight = item.Weight;
                        bOBarCodeWeighingToBeAdded.BarCode = item.BarCode;
                        bOBarCodeWeighingToBeAdded.ArticleQuantity = item.ArticleQuantity;
                        bOBarCodeWeighingToBeAdded.ExpirationDate = item.ExpirationDate;

                        this.BarCodeDetails.Add(bOBarCodeWeighingToBeAdded);
                        sum += Convert.ToDouble(item.Weight);
                        this.TotalWeightByBarCode = sum.ToString();
                    }

                }
                this.UpdateContainersCommand();
                this.ThereAreDifferences = this.TotalWeightByBarCode != this.TotalWeightByBascule;
            }
        }
        #endregion

        #region Private Properties
        private ObservableCollection<BOOrderRequestList> requests { get; set; }

        /// <summary>
        /// Notificación de mensajes
        /// </summary>

        #endregion

        #region Tareas
        private Task getRequest;
        private Task getDeliveries;
        private Task getDeliveryReceiveHeader;
        private Task getArticlesToBeReceive;
        private Task getContainers;
        private Task getSellers;
        #endregion

        #region Constructor
        public VMReceive(MainWindow mw)
        {
            this.PrincipalScreen = mw;
            this.clientName = "Punto de Venta San Antonio de Prado";
            this.requestService = new RequestService();
            this.deliveryService = new DeliveryService();
            this.articleService = new ArticleService();
            this.containerService = new ContainerService();
            this.weighingByArticle = new BOWeighing();
            this.weighingService = new WeighingService();
            this.sellerService = new SellerService();
            this.BarCodeDetails = new ObservableCollection<BOBarCodeWeighing>();
            this.notification = new Notification();
            this.getRequest = GetOrdersRequestAsync();
            this.getContainers = getContainersAsync();
            this.getSellers = GetSellersAsync();
            this.OpenEvidenceFormCommand = new RelayCommand(ConfigureModalEvidenceForm);
            this.SaveWeighingConfirmationCommand = new RelayCommand(SaveWeighingConfirmation);
            this.BasculeWeightChanged = new RelayCommand(BasculeWeightChangedCommand);
            this.BarCodeReadedCommand = new RelayCommand(BarCodeReaded);
            this.QuantityReceiveCommand = new RelayCommand(QuantityReceive);
            this.UpdateContainers = new RelayCommand(UpdateContainersCommand);
            this.ConfirmReceiveByDeliveryCommand = new RelayCommand(ConfirmReceiveByDelivery);
            this.ThereAreDifferences = false;
            this.WidhtForUserControl = (mw.Width - 260).ToString();
            this.WeighingBasculeState = "init";

            try
            {
                //Conecta la báscula de piso a WPF
                WeighingMachinesIPProxy weighingMachinesIPProxy = new WeighingMachinesIPProxy();
                weighingMachinesIPProxy.adapter.ObtenerPeso += GetWeight;
                //weighingMachinesIPProxy.Connect();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion
        public ICommand SaveWeighingConfirmationCommand { get; }
        public ICommand BasculeWeightChanged { get; }
        public ICommand BarCodeReadedCommand { get; }
        public ICommand UpdateContainers { get; }
        public ICommand ConfirmReceiveByDeliveryCommand { get; }
        public ICommand QuantityReceiveCommand { get; }
        
        public void BarCodeReaded()
        {

            if (this.articleBarCodeToRead.BarCode.Length == 41 && this.articleBarCodeToRead.ExpirationDate == null)
            {
                if (!ValidateBarCode())
                {
                    return;
                }
                if (ArticleBeingWeighing == null)
                {
                    return;
                }
                BOBarCodeWeighing barCodeWeighing = this.weighingService.ReadBarCode(ArticleBeingWeighing.ArticleWeighingId, this.articleBarCodeToRead.BarCode);
                if (barCodeWeighing == null)
                {
                    this.notification.Show(DictMessages.Warning, DictMessages.ErrorCodigoDeBarrasNoEsValido, NotificationType.Error);
                }
                List<BOBarCodeWeighing> barCodeDetails = this.weighingService.GetBarCodes(ArticleBeingWeighing.ArticleWeighingId);

                this.BarCodeDetails = new ObservableCollection<BOBarCodeWeighing>();

                BOBarCodeWeighing bOBarCodeWeighing = new BOBarCodeWeighing();
                bOBarCodeWeighing.BarCode = "";
                bOBarCodeWeighing.ArticleName = articleSelected.ArticleName;
                bOBarCodeWeighing.ArticleCode = articleSelected.ArticleCode;
                bOBarCodeWeighing.MeasureUnit = articleSelected.MeasureUnit;
                bOBarCodeWeighing.ArticleState = articleSelected.State;
                this.BarCodeDetails.Add(bOBarCodeWeighing);
                double sum = 0;

                foreach (var item in barCodeDetails)
                {
                    BOBarCodeWeighing bOBarCodeWeighingToBeAdded = new BOBarCodeWeighing();

                    bOBarCodeWeighingToBeAdded.ArticleName = articleSelected.ArticleName;
                    bOBarCodeWeighingToBeAdded.ArticleCode = articleSelected.ArticleCode;
                    bOBarCodeWeighingToBeAdded.MeasureUnit = articleSelected.MeasureUnit;
                    bOBarCodeWeighingToBeAdded.ArticleState = articleSelected.State;
                    bOBarCodeWeighingToBeAdded.Lot = item.Lot;
                    bOBarCodeWeighingToBeAdded.Weight = item.Weight;
                    bOBarCodeWeighingToBeAdded.BarCode = item.BarCode;
                    bOBarCodeWeighingToBeAdded.ArticleQuantity = item.ArticleQuantity;
                    bOBarCodeWeighingToBeAdded.ExpirationDate = item.ExpirationDate;

                    this.BarCodeDetails.Add(bOBarCodeWeighingToBeAdded);
                    sum += Convert.ToDouble(item.Weight);
                    this.TotalWeightByBarCode = sum.ToString();
                }
                this.ThereAreDifferences = this.TotalWeightByBarCode != this.TotalWeightByBascule;

            }
            else
            {
                this.notification.Show(DictMessages.Warning, DictMessages.ErrorCodigoDeBarrasNoEsValido, NotificationType.Error);
            }
        }

        public void QuantityReceive()
        {
            this.messageConfirmation = DictMessages.ConfirmarPesajePorCantidad; //DictMessages
            this.iconName = DictIcons.Backup;//DictIcons
            this.foreground = DictColors.Warning;//DictColors
            UCModalConfirmation = new UCModalConfirmation(this);
            this.confirmingReceivingByQuantityAndUnitMeasure = true;
            this.PrincipalScreen.ModalContainer.Content = UCModalConfirmation;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
        }

        public bool ValidateBarCode()
        {
            return true;
        }

        public void ChargeArticle()
        {
            if (ArticleSelected == null)
            {
                return;
            }
            if (WeighingDetail == null)
            {
                this.WeighingDetail = new ObservableCollection<BOWeighingDetail>();
                BOWeighingDetail bOWeighingDetail = new BOWeighingDetail();
                bOWeighingDetail.ArticleCode = ArticleSelected.ArticleCode;
                bOWeighingDetail.ArticleName = ArticleSelected.ArticleName;
                bOWeighingDetail.BasculeWeight = 0;
                bOWeighingDetail.ArticleWeight = 0;
                bOWeighingDetail.ArticleWeighingId = "0";
                bOWeighingDetail.MeasureUnit = ArticleSelected.MeasureUnit;
                this.WeighingDetail.Add(bOWeighingDetail);
            }


            if (this.ArticleSelected.ArticleWeighingId != "0" && this.ArticleSelected.ArticleWeighingId != "false")
            {
                this.weighingsByArticle = this.weighingService.GetWeighingByArticle(this.ArticleSelected.ArticleWeighingId);
                
                foreach (var item in this.weighingsByArticle)
                {
                    BOWeighingDetail bOWeighingDetailByArticle = new BOWeighingDetail();
                    bOWeighingDetailByArticle.ArticleCode = ArticleSelected.ArticleCode;
                    bOWeighingDetailByArticle.ArticleName = ArticleSelected.ArticleName;
                    bOWeighingDetailByArticle.BasculeWeight = (float)item.TotalBasculeWeight;
                    bOWeighingDetailByArticle.ArticleWeight = (double)item.ArticleWeight;
                    bOWeighingDetailByArticle.ArticleWeighingId = item.ArticleWeighingId;
                    bOWeighingDetailByArticle.MeasureUnit = ArticleSelected.MeasureUnit;
                    this.ContenedoresPesajes = this.containerService.GetContainersByArticle(item.ArticleWeighingId);
                    bOWeighingDetailByArticle.Containers = this.contenedoresPesajes;
                    bOWeighingDetailByArticle.CalculateContainersWeight();
                    this.weighingDetail.Add(bOWeighingDetailByArticle);
                }
                this.BarCodeDetails = new ObservableCollection<BOBarCodeWeighing>();

                BOBarCodeWeighing bOBarCodeWeighing = new BOBarCodeWeighing();
                bOBarCodeWeighing.BarCode = "";
                bOBarCodeWeighing.ArticleName = ArticleSelected.ArticleName;
                bOBarCodeWeighing.ArticleCode = ArticleSelected.ArticleCode;
                bOBarCodeWeighing.MeasureUnit = ArticleSelected.MeasureUnit;
                bOBarCodeWeighing.ArticleState = ArticleSelected.State;
                BarCodeDetails.Add(bOBarCodeWeighing);

                if (ArticleBeingWeighing != null)
                {
                    List<BOBarCodeWeighing> barCodeDetails = this.weighingService.GetBarCodes(ArticleBeingWeighing.ArticleWeighingId);
                    double sum = 0;
                    foreach (var item in barCodeDetails)
                    {
                        item.ArticleName = ArticleSelected.ArticleName;
                        item.ArticleCode = ArticleSelected.ArticleCode;
                        item.MeasureUnit = ArticleSelected.MeasureUnit;
                        item.ArticleState = ArticleSelected.State;
                        BarCodeDetails.Add(item);
                        sum += Convert.ToDouble(item.Weight);
                        this.TotalWeightByBarCode = sum.ToString();
                    }
                }
            }

            this.ThereAreDifferences = this.TotalWeightByBarCode != this.TotalWeightByBascule;

            this.weighingByArticle.DeliveryDetailId = this.ArticleSelected.DeliveryDetailId;
            this.weighingByArticle.CodeArticle = this.ArticleSelected.ArticleCode;
            this.weighingByArticle.DeliveryId = this.DeliveryId;
            this.UpdateContainersCommand();
            this.BasculeWeightChangedCommand();
        }

        public void ConfirmReceiveByDelivery()
        {
            ConfigureModalConfirmationReceiveDelivery(
                DictMessages.ConfirmarPesajePorCantidad,
                DictIcons.Backup,
                DictColors.Warning
            );
        }

        private void ConfigureModalConfirmationReceiveDelivery(string messageConfirmation, string iconName, string foreground)
        {
            this.messageConfirmation = messageConfirmation; //DictMessages
            this.iconName = iconName;//DictIcons
            this.foreground = foreground;//DictColors
            UCModalConfirmation = new UCModalConfirmation(this);
            this.confirmingReceiving = true;
            this.PrincipalScreen.ModalContainer.Content = UCModalConfirmation;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
        }

        private void ConfigureModalCustomMessage(string messageConfirmation, string iconName, string foreground, bool showSpinner)
        {
            this.messageConfirmation = messageConfirmation; //DictMessages
            this.iconName = iconName;//DictIcons
            this.foreground = foreground;//DictColors
            this.showSpinner = showSpinner;
            UCCustomMessages = new UCCustomMessages(this);
            this.PrincipalScreen.ModalContainer.Content = UCCustomMessages;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
        }

        public void BasculeWeightChangedCommand()
        {
            this.weighingByArticle.TotalArticleWeight = 0;
            this.weighingByArticle.Weight = 0;
            if (this.WeighingDetail.Count() != 0)
            {
                this.WeighingDetail[0].ArticleWeight =
                this.WeighingDetail[0].basculeWeight - this.weighingByArticle.ContainersTotalWeight;
                this.WeighingByArticle.TotalArticleWeight += this.WeighingDetail[0].ArticleWeight;
                this.WeighingByArticle.Weight += this.WeighingDetail[0].basculeWeight;
                double totalWeight = 0;
                if (this.WeighingDetail != null)
                {
                    foreach (var item in WeighingDetail)
                    {
                        totalWeight += item.ArticleWeight;
                    }
                }
                this.TotalWeightByBascule = totalWeight.ToString();
                if (this.ArticleBeingWeighing != null)
                {
                    //this.TotalWeightByBascule = this.ArticleBeingWeighing.ArticleWeight.ToString();
                    this.ThereAreDifferences = this.TotalWeightByBarCode != this.TotalWeightByBascule;
                }

            }
        }

        public void UpdateContainersCommand()
        {
            this.weighingByArticle.Containers = new List<BOContainers>(containers);
            this.weighingByArticle.CalculateContainersWeight();
            this.BasculeWeightChangedCommand();
            List<BOContainers> ContainersToInitialItem = new List<BOContainers>();
            foreach (var item in this.weighingByArticle.Containers)
            {
                if(item.ContainerQuantity > 0)
                {
                    ContainersToInitialItem.Add(item);
                }
            }
            this.WeighingDetail[0].Containers = ContainersToInitialItem;
            this.WeighingDetail[0].CalculateContainersWeight();
            this.ContainersTotalWeight = this.weighingByArticle.ContainersTotalWeight.ToString();
        }

        public void SaveWeighingConfirmation()
        {
            if (!this.ValidateSaveOrderGeneric())
            {
                return;
            }

            if (this.weighingByArticle.TotalArticleWeight <= 0)
            {
                this.notification.Show(DictMessages.Warning, DictMessages.ErrorPesoArticuloInvalido, NotificationType.Error);
                return;
            }

            if (this.weighingByArticle.Containers == null)
            {
                this.notification.Show(DictMessages.Warning, DictMessages.ErrorContenedoresNoAsignados, NotificationType.Error);
                return;
            }
            string ArticleWeighingId = this.weighingService.SetOrderEditRequest(this.weighingByArticle);
            this.ArticleSelected.ArticleWeighingId = ArticleWeighingId;
            this.getContainers = getContainersAsync();
            this.getArticlesToBeReceive = GetArticlesToBeReceiveAsync(this.deliveryId);
            ChargeArticle();


            this.notification.Show(DictMessages.Success, DictMessages.PesajeRegistradoConExito, NotificationType.Success);
        }

        //private void ConfigureModalConfirmation(string messageConfirmation, string iconName, string foreground)
        //{
        //    this.messageConfirmation = messageConfirmation; //DictMessages
        //    this.iconName = iconName;//DictIcons
        //    this.foreground = foreground;//DictColors
        //    UCModalConfirmation = new UCModalConfirmation(this);
        //    this.confirmingBascule = true;
        //    this.PrincipalScreen.ModalContainer.Content = UCModalConfirmation;
        //    this.PrincipalScreen.ModalPrincipal.IsOpen = true;
        //}

        private bool ValidateSaveOrderGeneric()
        {
            return true;
        }

        public ICommand OpenEvidenceFormCommand { get; }

        private void ConfigureModalEvidenceForm()
        {
            UCModalEvidenceForm = new UCModalEvidenceForm(PrincipalScreen, ArticleSelected, DeliveryHeader);
            this.PrincipalScreen.ModalContainer.Content = UCModalEvidenceForm;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
            this.PrincipalScreen.ModalPrincipal.CloseOnClickAway = false;
        }

        public async void ExecuteConfirmationYes()
        {
            this.PrincipalScreen.ModalContainer.Content = null;
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
            if (confirmingReceiving)
            {
                // Mesaje de enviando documento
                ConfigureModalCustomMessage(
                    DictMessages.MessageSpinner,
                    null,
                    DictColors.Info,
                    true
                );

                await this.PostConfirmDeliveryReceiveAsync(this.DeliveryId);
            }else if (confirmingReceivingByQuantityAndUnitMeasure)
            {
                // Mesaje de enviando documento
                ConfigureModalCustomMessage(
                    DictMessages.MessageSpinner,
                    null,
                    DictColors.Info,
                    true
                );

                await this.PostConfirmDeliveryDetailQuantityReceiveAsync().ConfigureAwait(false);
            }
        }

        public void ExecuteConfirmationNot()
        {
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }
        
        /// <summary>
        /// Método que obtiene los contenedores de forma asíncrona
        /// </summary>  
        public async Task GetSellersAsync()
        {
            List<BOSeller> bOSellers = await this.sellerService.GetSellers();

            this.Sellers = new ObservableCollection<BOSeller>(bOSellers);
        }
        /// <summary>
        /// Método que obtiene los contenedores de forma asíncrona
        /// </summary>  
        public async Task getContainersAsync()
        {
            List<BOContainers> bOContainers = await this.containerService.GetContainer();

            this.Containers = new ObservableCollection<BOContainers>(bOContainers);
            this.ContainersAtEight = new ObservableCollection<BOContainers>(bOContainers);
            this.ContainersAtFive = new ObservableCollection<BOContainers>(bOContainers);
        }

        /// <summary>
        /// Método que obtiene los pedidos de forma asíncrona
        /// </summary>  
        private async Task GetOrdersRequestAsync()
        {
            List<BOOrderRequestList> boRequests = await this.requestService.GetOrdersRequest();

            this.Requests = new ObservableCollection<BOOrderRequestList>(boRequests);
        }

        /// <summary>
        /// Método que obtiene las entregas de forma asíncrona
        /// </summary>  
        private async Task GetDeliveriesAsync(string OrderId)
        {
            List<BODelivery> bODeliveries = await this.deliveryService.GetDeliveries(OrderId);
            BODelivery BeforeItem = null;
            foreach (var item in bODeliveries)
            {
                if (item == bODeliveries.First())
                {
                    item.CanBeReceive = true;
                }
                else
                {
                    if (BeforeItem.IsFinalized)
                    {
                        item.CanBeReceive = true;
                    }
                }
                BeforeItem = item;
            }
            this.Deliveries = new ObservableCollection<BODelivery>(bODeliveries);
        }

        /// <summary>
        /// Método que obtiene las entregas de forma asíncrona
        /// </summary>  
        private async Task GetDeliveryReceiveHeaderAsync(string DeliveryId)
        {
            BODeliveryReceiveHeader bODeliveryHeader = await this.deliveryService.GetDeliveryReceiveHeader(DeliveryId);
            this.DeliveryHeader = bODeliveryHeader;
            this.EnableSave = !this.DeliveryHeader.IsFinalized;
            this.EnableSaveFalse = this.DeliveryHeader.IsFinalized;
        }

        /// <summary>
        /// Método que obtiene las entregas de forma asíncrona
        /// </summary>  
        private async Task GetArticlesToBeReceiveAsync(string DeliveryId)
        {
            BOArticleReceive bOArticleReceive = new BOArticleReceive();
            if (this.ArticleSelected != null)
            {
                bOArticleReceive = this.ArticleSelected;
            }
            List<BOArticleReceive> bOArticlesToBeReceive = await this.articleService.GetArticlesToBeReceive(DeliveryId);

            this.ArticlesToBeReceives = bOArticlesToBeReceive;
            this.ArticleSelected = this.ArticlesToBeReceives.Where(x => x.DeliveryDetailId == bOArticleReceive.DeliveryDetailId).FirstOrDefault();
        }

        private async Task PostConfirmDeliveryDetailQuantityReceiveAsync()
        {
            this.weighingByArticle.TotalArticleQuantity = this.ArticleSelected.QuantityReceive;
            string ArticleWeighingId = await this.weighingService.SetReceiveByQuantityRequest(this.weighingByArticle);
            if (ArticleWeighingId == "true")
            {
                this.notification.Show(DictMessages.Success, DictMessages.PesajeRegistradoConExito, NotificationType.Success);
            }
            else 
            { 
                this.notification.Show(DictMessages.Warning, DictMessages.ErrorCantidadOUnidadDeMedidaNoValidos, NotificationType.Error);
            }
        }

        private async Task PostConfirmDeliveryReceiveAsync(string DeliveryId)
        {
            BOReceiveFinalizedDocuments bOReceiveFinalizedDocuments = await this.deliveryService.ConfirmDeliveryReceive(DeliveryId);
            var message = "Se han generado los siguientes documentos: ";
            int i = 1;
            bOReceiveFinalizedDocuments.Documents.ForEach(item =>
            {
                if (bOReceiveFinalizedDocuments.Documents.First() == item)
                {
                    message += i.ToString()+". '"+item.DocumentName+"'";
                    i++;
                }
                else
                {
                    message += ", " + i.ToString() + ". '" + item.DocumentName + "'";
                    i++;
                }
            });
            if (message == "")
            {
                message = "No se han generado documentos";
            }
            this.reloadPage();

            ConfigureModalCustomMessage(
                message,
                DictIcons.AlertCircle,
                DictColors.Info,
                false
            );

            this.ArticuloDocumentos = bOReceiveFinalizedDocuments.Documents;
        }

        public void reloadPage()
        {
            this.clientName = "Punto de Venta San Antonio de Prado";
            this.BarCodeDetails = new ObservableCollection<BOBarCodeWeighing>();
            this.notification = new Notification();
            this.getRequest = GetOrdersRequestAsync();
            this.getContainers = getContainersAsync();
            this.ThereAreDifferences = false;
            this.getDeliveryReceiveHeader = GetDeliveryReceiveHeaderAsync(this.deliveryId);
            this.getArticlesToBeReceive = GetArticlesToBeReceiveAsync(this.deliveryId);
        }

        private void GetWeight(object sender, ObtenerPesoIPEventArgs e)
        {
            this.verification++;
            if (this.WeighingDetail != null)
            {
                if (WeighingDetail[0].BasculeWeight != e.Peso && e.Peso != 0)
                {
                    WeighingDetail[0].BasculeWeight = e.Peso;
                    this.BasculeWeightChangedCommand();
                }
            }
            if (e.Peso == 0)
            {
                this.verificationZeros++;
            }
            if (this.WeighingBascule != e.Peso.ToString() && e.Peso != 0)
            {
                this.WeighingBasculeState = "onchange";
                WeighingBascule = e.Peso.ToString();
                this.verification = 0;
                this.verificationZeros = 0;
            }
            if (this.verificationZeros > 10)
            {
                WeighingBascule = "0";
                this.WeighingBasculeState = "init";
            }
            if (verification > 10 && WeighingBascule != "0")
            {
                this.WeighingBasculeState = "stable";
                this.verificationZeros = 0;
            }

        }

    }
}
