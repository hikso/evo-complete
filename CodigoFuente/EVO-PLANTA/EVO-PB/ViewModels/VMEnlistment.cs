using EVO_PB.Models.BusinessObjects;
using EVO_PB.Utilities;
using EVO_PV;
using EVO_PB.Enum;
using EVO_PB.Enums;
using EVO_PB.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Microsoft.VisualStudio.PlatformUI;
using GalaSoft.MvvmLight.Command;
using EVO_PB.Resources.Dictionaries;
using EVO_PB.Interfaces;
using EVO_PB.Views;
using Notifications.Wpf;

namespace EVO_PB.ViewModels
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 23-Feb/2020
    /// Descripción      : Esta clase implementa la lógica de negocio de "Alistamiento"
    /// </summary>
    public class VMEnlistment : NotifyPropertyChanged, IConfirmationModal
    {
        #region Atributos
        private string typeClient { get; set; }
        private string pedidoId { get; set; }
        private string deliveryId { get; set; }
        private string mainWindowWidth { get; set; }
        private string containersTotalWeight { get; set; }
        private string previousPedidoSelected { get; set; }
        private int maximumPageSize { get; set; }
        private EnumConstanst typeVM;

        private RequestService requestService;
        private BasculeService basculeService;
        private DeliveryService deliveryService;
        private ContainerService containerService;
        private WareHouseService wareHouseService;
        private WeighingService weighingService;

        UCModalConfirmation UCModalConfirmation;
        private MainWindow PrincipalScreen;
        private EnumNamesMethods enumNameMethodYes { get; set; }
        private EnumNamesMethods enumNameMethodNot { get; set; }

        private string messageConfirmation { get; set; }
        private string iconName { get; set; }
        private string foreground { get; set; }

        #endregion

        #region Propiedades     

        public string TypeClient
        {
            get { return typeClient; }
            set { typeClient = value; }
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

        public string MainWindowWidth
        {
            get { return mainWindowWidth; }
            set { mainWindowWidth = value; }
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

        public string FilterCodeArticle
        {
            get { return filterCodeArticle; }

            set
            {
                this.filterCodeArticle = value;
                this.OnPropertyChanged("FilterCodeArticle");
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

        public BOEnlistmentArticles EnlistmentArticleSelected
        {
            get { return enlistmentArticleSelected; }

            set
            {

                this.enlistmentArticleSelected = value;
                this.OnPropertyChanged("EnlistmentArticleSelected");
                this.getWareHouse = this.GetWareHouseAsync();

                this.weighingsByArticle = this.weighingService.GetWeighingByArticle(enlistmentArticleSelected.DeliveryDetailId);
                this.WeighingDetail = new ObservableCollection<BOWeighingDetail>();
                BOWeighingDetail bOWeighingDetail = new BOWeighingDetail();
                bOWeighingDetail.ArticleCode = enlistmentArticleSelected.ArticleCode;
                bOWeighingDetail.ArticleName = enlistmentArticleSelected.ArticleName;
                bOWeighingDetail.BasculeWeight = 0;
                bOWeighingDetail.ArticleWeight = 0;
                bOWeighingDetail.MeasureUnit = enlistmentArticleSelected.MeasureUnit;
                this.WeighingDetail.Add(bOWeighingDetail);

                foreach (var item in this.weighingsByArticle.BasculeWeighings)
                {
                    BOWeighingDetail bOWeighingDetailByArticle = new BOWeighingDetail();
                    bOWeighingDetailByArticle.ArticleCode = enlistmentArticleSelected.ArticleCode;
                    bOWeighingDetailByArticle.ArticleName = enlistmentArticleSelected.ArticleName;
                    bOWeighingDetailByArticle.BasculeWeight = (float)item.BasculeWeight;
                    bOWeighingDetailByArticle.ArticleWeight = (double)item.ArticleWeight;
                    bOWeighingDetailByArticle.MeasureUnit = enlistmentArticleSelected.MeasureUnit;
                    bOWeighingDetail.Containers = item.Containers;
                    this.WeighingDetail.Add(bOWeighingDetailByArticle);
                }

                this.weighingByArticle.DeliveryDetailId = this.enlistmentArticleSelected.DeliveryDetailId;
                this.weighingByArticle.CodeArticle = this.enlistmentArticleSelected.ArticleCode;
            }
        }

        public BOWeighingDetail ArticleBeingWeighing
        {
            get { return articleBeingWeighing; }
            set
            {
                this.articleBeingWeighing = value;
                this.OnPropertyChanged("ArticleBeingWeighing");
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

        public string WidhtForUserControl
        {
            get { return widhtForUserControl; }

            set
            {
                this.widhtForUserControl = value;
                this.OnPropertyChanged("WidhtForUserControl");
            }
        }

        public ObservableCollection<BOOrderRequest> Requests
        {
            get { return requests; }

            set
            {
                this.requests = value;
                this.OnPropertyChanged("Requests");
            }
        }

        public ObservableCollection<BOBascules> Bascules
        {
            get { return bascules; }

            set
            {
                this.bascules = value;
                this.OnPropertyChanged("Bascules");
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

        public BODelivery Delivery
        {
            get { return delivery; }

            set
            {
                this.delivery = value;
                this.OnPropertyChanged("Delivery");
            }
        }

        public string PedidoId
        {
            get
            {
                return this.pedidoId;
            }
            set
            {

                this.previousPedidoSelected = pedidoId;
                this.pedidoId = value;
                this.OnPropertyChanged("PedidoId");

                if (!string.IsNullOrWhiteSpace(this.pedidoId))
                {
                    this.getDeliveries = GetDeliveriesAsync(this.pedidoId);

                }

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
                this.weighingByArticle.Containers = new List<BOContainers>(containers);
            }
        }

        public ObservableCollection<BOWareHouse> WareHouses
        {
            get
            {
                return this.wareHouses;
            }
            set
            {
                this.wareHouses = value;
                this.OnPropertyChanged("WareHouses");
            }
        }

        public int TypeBasculeId
        {
            get
            {
                return this.typeBasculeId;
            }
            set
            {
                this.typeBasculeId = value;
                this.OnPropertyChanged("TypeBasculeId");
                this.weighingByArticle.TypeBasculeId = TypeBasculeId;
            }
        }

        public string WhsCode
        {
            get
            {
                return this.whsCode;
            }
            set
            {
                this.whsCode = value;
                this.OnPropertyChanged("WhsCode");
                this.weighingByArticle.WhsCode = WhsCode;
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

                this.previousPedidoSelected = deliveryId;
                this.deliveryId = value;
                this.OnPropertyChanged("DeliveryId");

                if (!string.IsNullOrWhiteSpace(this.deliveryId))
                {
                    this.getDelivery = GetDeliveryAsync(this.deliveryId);

                }

            }
        }
        public BOWeighingByArticle WeighingsByArticle
        {
            get
            {
                return this.weighingsByArticle;
            }
            set
            {
                this.weighingsByArticle = value;
                this.OnPropertyChanged("DeliveryId");
            }
        }
        

        #endregion

        #region Private Properties
        private ObservableCollection<BOOrderRequest> requests { get; set; }
        private ObservableCollection<BODelivery> deliveries { get; set; }
        private ObservableCollection<BOBascules> bascules { get; set; }
        private ObservableCollection<BOContainers> containers { get; set; }
        private ObservableCollection<BOWareHouse> wareHouses { get; set; }
        private string whsCode { get; set; }
        private int typeBasculeId { get; set; }
        private BODelivery delivery { get; set; }
        private BOWeighing weighingByArticle { get; set; }
        private ObservableCollection<BOWeighingDetail> weighingDetail { get; set; }
        private BOWeighingDetail articleBeingWeighing { get; set; }
        private string filterCodeArticle { get; set; }
        private string widhtForUserControl { get; set; }
        private BOEnlistmentArticles enlistmentArticleSelected { get; set; }
        private BOWeighingByArticle weighingsByArticle { get; set; }

        /// <summary>
        /// Notificación de mensajes
        /// </summary>
        private Notification notification;
        #endregion

        #region Tareas
        private Task getRequest;
        private Task getDeliveries;
        private Task getBascules;
        private Task getDelivery;
        private Task getContainers;
        private Task getWareHouse;
        #endregion

        #region Constructor
        public VMEnlistment(MainWindow mw)
        {
            this.PrincipalScreen = mw;
            mw.SizeChanged += new SizeChangedEventHandler(MainSizeChanged);
            TypeClient = "Punto de venta:";
            this.requestService = new RequestService();
            this.deliveryService = new DeliveryService();
            this.containerService = new ContainerService();
            this.basculeService = new BasculeService();
            this.weighingService = new WeighingService();
            this.wareHouseService = new WareHouseService();
            this.notification = new Notification();

            this.weighingByArticle = new BOWeighing();

            this.getRequest = GetOrdersRequestAsync();
            this.getBascules = GetBasculesAsync();
            this.getContainers = getContainersAsync();
            this.WidhtForUserControl = (mw.Width - 260).ToString();
            this.UpdateContainers = new RelayCommand(UpdateContainersCommand);
            this.BasculeWeightChanged = new RelayCommand(BasculeWeightChangedCommand);
            this.SaveWeighingConfirmationCommand = new RelayCommand(SaveWeighingConfirmation);
        }
        #endregion
        public ICommand SaveWeighingConfirmationCommand { get; }

        public void SaveWeighingConfirmation()
        {
            if (!this.ValidateSaveOrderGeneric())
            {
                return;
            }

            ConfigureModalConfirmation(
                DictMessages.ConfirmarPesajeBascula,
                DictIcons.Backup,
                DictColors.Warning
            );
        }
        private bool ValidateSaveOrderGeneric()
        {
            if (this.weighingByArticle.DeliveryDetailId == null)
            {
                this.notification.Show(DictMessages.Error, DictMessages.NoSeleccionadoDetalleArticulo, NotificationType.Error);
                return false;
            }

            if (this.weighingByArticle.TypeBasculeId == 0)
            {
                this.notification.Show(DictMessages.Error, DictMessages.NoSeleccionadoTipoBascula, NotificationType.Error);
                return false;
            }

            if (this.weighingByArticle.Weight <= 0)
            {
                this.notification.Show(DictMessages.Error, DictMessages.PesoBasculaNoValido, NotificationType.Error);
                return false;
            }

            if (this.weighingByArticle.TotalArticleWeight <= 0)
            {
                this.notification.Show(DictMessages.Error, DictMessages.PesoArticuloNoValido, NotificationType.Error);
                return false;
            }

            if (this.weighingByArticle.WhsCode == null)
            {
                this.notification.Show(DictMessages.Error, DictMessages.NoSeleccionadoBodega, NotificationType.Error);
                return false;
            }
            if (this.weighingByArticle.ContainersTotalWeight == 0)
            {
                this.notification.Show(DictMessages.Error, DictMessages.PesoContenedoresNoValido, NotificationType.Error);
                return false;
            }
            return true;
        }

        private void ConfigureModalConfirmation(string messageConfirmation, string iconName, string foreground)
        {
            this.messageConfirmation = messageConfirmation; //DictMessages
            this.iconName = iconName;//DictIcons
            this.foreground = foreground;//DictColors
            UCModalConfirmation = new UCModalConfirmation(this);
            this.PrincipalScreen.ModalContainer.Content = UCModalConfirmation;
            this.PrincipalScreen.ModalPrincipal.IsOpen = true;
        }
        public void ExecuteConfirmationYes()
        {
            this.weighingService.SetOrderEditRequest(this.weighingByArticle);
            this.PrincipalScreen.ModalPrincipal.IsOpen = false;
        }

        public void ExecuteConfirmationNot()
        {

        }
        public ICommand BasculeWeightChanged { get; }

        public void BasculeWeightChangedCommand()
        {
            this.weighingByArticle.TotalArticleWeight = 0;
            this.weighingByArticle.Weight = 0;

            this.WeighingDetail[0].ArticleWeight = 
                this.WeighingDetail[0].basculeWeight - this.weighingByArticle.ContainersTotalWeight;
            this.WeighingByArticle.TotalArticleWeight += this.WeighingDetail[0].ArticleWeight;
            this.WeighingByArticle.Weight += this.WeighingDetail[0].basculeWeight;
        }

        public ICommand UpdateContainers { get; }
        public void UpdateContainersCommand()
        {
            this.weighingByArticle.Containers = new List<BOContainers>(containers);
            this.weighingByArticle.CalculateContainersWeight();
            this.BasculeWeightChangedCommand();
            this.ContainersTotalWeight = this.weighingByArticle.ContainersTotalWeight.ToString();
        }

        /// <summary>
        /// Método que obtiene los pedidos de forma asíncrona
        /// </summary>  
        private async Task GetOrdersRequestAsync()
        {
            List<BOOrderRequest> boRequests = await this.requestService.GetOrdersRequest();

            this.Requests = new ObservableCollection<BOOrderRequest>(boRequests);
        }

        /// <summary>
        /// Método que obtiene los pedidos de forma asíncrona
        /// </summary>  
        private async Task GetWareHouseAsync()
        {
            List<BOWareHouse> boWarehouse = await this.wareHouseService.GetWareHouseByDeliveryAndArticle(this.DeliveryId, this.enlistmentArticleSelected.ArticleCode);
            this.WareHouses = new ObservableCollection<BOWareHouse>(boWarehouse);
        }

        /// <summary>
        /// Método que obtiene los artículos de forma asíncrona
        /// </summary>  
        private async Task GetDeliveriesAsync(string PedidoId)
        {
            List<BODelivery> bODeliveries = await this.deliveryService.GetDeliveries(PedidoId);

            this.Deliveries = new ObservableCollection<BODelivery>(bODeliveries);
        }

        /// <summary>
        /// Método que obtiene las básculas de forma asíncrona
        /// </summary>  
        private async Task GetBasculesAsync()
        {
            List<BOBascules> bOBascules = await this.basculeService.GetBascules();

            this.Bascules = new ObservableCollection<BOBascules>(bOBascules);
        }

        public async Task getContainersAsync()
        {            
            List<BOContainers> bOContainers = await this.containerService.GetContainer();

            this.Containers = new ObservableCollection<BOContainers>(bOContainers);
        }

        /// <summary>
        /// Método que obtiene los artículos de forma asíncrona
        /// </summary>  
        private async Task GetDeliveryAsync(string DeliveryId)
        {
            this.Delivery = await this.deliveryService.GetDelivery(DeliveryId);
        }

        public void MainSizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.WidhtForUserControl = (e.NewSize.Width - 260).ToString();
        }
    }
}
