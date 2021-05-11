using EVO_PV.Enums;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Services;
using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{

    public class VMOrderList : NotifyPropertyChanged
    {
        #region Atributos privados
        private MainWindow PrincipalScreen;
        private ObservableCollection<BORegisterorderlist> orderList { get; set; }
        private ObservableCollection<BORegisterorderlist> orderListBackup { get; set; }
        private ObservableCollection<BOStateArticle> states { get; set; }
        private ObservableCollection<BOWareHouse> factories { get; set; }
        private int maximumPageSize { get; set; }
        private string NamePV { get; set; }
        private string searchOrderByOrderId { get; set; }
        private string searchOrderByOrderDate { get; set; }
        private string searchOrderByOrderDateLimit { get; set; }
        private string searchOrderByState { get; set; }
        private string searchOrderByFactory { get; set; }
        private string packageIdSearch { get; set; }
        private string searchOrderByOrderDays { get; set; }
        private BORegisterorderlist orderSelect { get; set; }
        public List<VMSubItem> subItems;
        private bool thereAreNotOrder;
        private string widthForUserControl { get; set; }
        #endregion

        #region Atributos públicos        

        public string WidthForUserControl
        {
            get { return widthForUserControl; }

            set
            {
                this.widthForUserControl = value;
                this.OnPropertyChanged("WidthForUserControl");
            }
        }


        public bool ThereAreNotOrder
        {
            get { return thereAreNotOrder; }
            set
            {
                thereAreNotOrder = value;
                this.OnPropertyChanged("ThereAreNotOrder");
            }
        }

        public List<VMSubItem> SubItems
        {
            get { return subItems; }
            set
            {
                subItems = value;
                this.OnPropertyChanged("SubItems");
            }
        }

        public string SearchOrderByCodeOrder
        {
            get { return searchOrderByOrderId; }
            set
            {
                searchOrderByOrderId = value;
                this.OnPropertyChanged("SearchOrderByOrderId");
                this.SearchOrder();
            }
        }

        public string SearchOrderByOrderDate
        {
            get { return searchOrderByOrderDate; }
            set
            {
                if (value != null)
                {
                    searchOrderByOrderDate = value.Substring(0, 10);
                }
                else
                {
                    searchOrderByOrderDate = value;
                }
                this.OnPropertyChanged("SearchOrderByOrderDate");
                this.SearchOrder();
            }
        }

        public string SearchOrderByOrderDateLimit
        {
            get { return searchOrderByOrderDateLimit; }
            set
            {
                if (value != null)
                {
                    searchOrderByOrderDateLimit = value.Substring(0, 10);
                }
                else
                {
                    searchOrderByOrderDateLimit = value;
                }
                this.OnPropertyChanged("SearchOrderByOrderDateLimit");
                this.SearchOrder();
            }
        }

        public string SearchOrderByState
        {
            get { return searchOrderByState; }
            set
            {
                searchOrderByState = value;
                this.OnPropertyChanged("SearchOrderByState");
                this.SearchOrder();
            }
        }

        public string SearchOrderByFactory
        {
            get { return searchOrderByFactory; }
            set
            {
                searchOrderByFactory = value;
                this.OnPropertyChanged("SearchOrderByFactory");
                this.SearchOrder();
            }
        }

        public string PackageIdSearch
        {
            get { return packageIdSearch; }
            set
            {
                packageIdSearch = value;
                this.OnPropertyChanged("PackageIdSearch");
                this.SearchOrder();
            }
        }

        public string SearchOrderByOrderDays
        {
            get { return searchOrderByOrderDays; }
            set
            {
                searchOrderByOrderDays = value;
                this.OnPropertyChanged("SearchOrderByOrderDays");
                this.SearchOrder();
            }
        }

        public BORegisterorderlist OrderSelect
        {
            get { return orderSelect; }
            set
            {

                orderSelect = value;

                this.OnPropertyChanged("OrderSelect");

            }
        }

        public ObservableCollection<BORegisterorderlist> OrderList
        {
            get { return orderList; }

            set
            {
                this.orderList = value;

                if (this.orderList != null)
                {
                    foreach (var item in this.orderList)
                    {
                        item.BtnEye = true;
                        item.BtnDuplicate = item.CanDuply;
                        item.BtnEdit = item.CanEdit;
                        if (item.State == "Cancelado")
                        {
                            item.BtnDuplicate = false;
                        }
                    }
                }
                this.OnPropertyChanged("OrderList");
            }
        }

        public ObservableCollection<BORegisterorderlist> OrderListBackup
        {
            get { return orderList; }

            set
            {
                this.orderListBackup = value;

                if (this.orderListBackup != null)
                {
                    foreach (var item in this.orderListBackup)
                    {
                        item.BtnEye = true;
                        item.BtnDuplicate = item.CanDuply;
                        item.BtnEdit = item.CanEdit;
                        if (item.State == "Cancelado")
                        {
                            item.BtnDuplicate = false;
                        }
                    }
                }

                this.OnPropertyChanged("OrderListBackup");
            }
        }

        public ObservableCollection<BOStateArticle> States
        {
            get { return states; }

            set
            {
                this.states = value;
                this.OnPropertyChanged("States");
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
        #endregion

        #region Objetos de Servicios
        private OrderListService OrderListServices;
        private WareHouseService WareHouseService;
        private AuditService auditService;
        #endregion

        #region Tareas
        /// <summary>
        /// Task para llamar en el constructor métodos asyncronos
        /// </summary>
        private Task GetOrderList;
        private Task GetStates;
        private Task GetFactories;
        private Task GetAudit;

        #endregion

        #region Comandos Eventos de botones 
        public ICommand ViewDetailsCommand { get; } /// Botón Ver detalle pedido
        public ICommand ViewEditOrderCommand { get; } /// Botón Editar pedido
        public ICommand ViewDuplicateOrderCommand { get; } /// Botón Duplicar pedido
        #endregion

        #region Constructores
        public VMOrderList(MainWindow principalScreen)
        {
            this.PrincipalScreen = principalScreen;

            this.auditService = new AuditService();

            this.OrderListServices = new OrderListService();
            this.WareHouseService = new WareHouseService();
            this.maximumPageSize = Convert.ToInt32(App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()]);
            
            this.NamePV = ConfigurationManager.AppSettings["CODIGO_PUNTO_VENTA"];

            this.GetOrderList = GetOrdersAsync(1, this.maximumPageSize, this.NamePV);

           
            this.GetAudit = GetAuditAsync();
            this.GetStates = GetStatesAsync();
            this.GetFactories = GetFactoriesAsync();
            this.ViewEditOrderCommand = new RelayCommand(GetEditOrder);
            this.ViewDuplicateOrderCommand = new RelayCommand(GetDuplicateOrder);
            this.ViewDetailsCommand = new RelayCommand(GetDetailOrder);

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

        private void PrincipalScreen_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
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

        #region Métodos Privados
        private void GetDetailOrder()
        {
            object obj = this.OrderSelect;
            this.PrincipalScreen.ContentPage.Content = new UCOrderListDetail(this.PrincipalScreen, this.OrderSelect.OrderId);
        }

        private void GetEditOrder()
        {
            object obj = this.OrderSelect;
            this.PrincipalScreen.ContentPage.Content = new UCOrderListEdit(this.PrincipalScreen, this.OrderSelect.OrderId, EnumConstanst.Edit);
        }

        private void GetDuplicateOrder()
        {
            object obj = this.OrderSelect;
            this.PrincipalScreen.ContentPage.Content = new UCOrderListEdit(this.PrincipalScreen, this.OrderSelect.OrderId, EnumConstanst.Duplicate);
        }

        private void SearchOrder()
        {
            this.OrderList = this.orderListBackup;
            if (this.OrderList == null)
            {
                return;
            }
            this.OrderList = new ObservableCollection<BORegisterorderlist>(
                this.OrderList.Where(
                    order => order.CodeOrder.Contains(this.SearchOrderByCodeOrder == null || this.SearchOrderByCodeOrder == string.Empty ? order.CodeOrder : this.SearchOrderByCodeOrder)
                ).Where(
                    order => order.DateRequest.Contains(this.SearchOrderByOrderDate == null || this.SearchOrderByOrderDate == string.Empty ? order.DateRequest : this.SearchOrderByOrderDate)
                ).Where(
                    order => order.DateDelivery.Contains(this.SearchOrderByOrderDateLimit == null || this.SearchOrderByOrderDateLimit == string.Empty ? order.DateDelivery : this.SearchOrderByOrderDateLimit)
                ).Where(
                    order => order.State.Contains((this.SearchOrderByState == null || this.SearchOrderByState == "Sin filtro..." || this.SearchOrderByState == string.Empty) ? order.State : this.SearchOrderByState)
                ).Where(
                    order => order.Factory.Contains((this.SearchOrderByFactory == null || this.SearchOrderByFactory == "Sin filtro..." || this.SearchOrderByFactory == string.Empty) ? order.Factory : this.SearchOrderByFactory)
                ).Where(
                    order => order.DaysDelivery == (this.SearchOrderByOrderDays == null || this.SearchOrderByOrderDays == string.Empty ? order.DaysDelivery : this.SearchOrderByOrderDays)
                ).ToList()
            );
            this.ThereAreNotOrder = this.OrderList.Count() == 0;
        }

        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetOrdersAsync(int from, int to, string whsCode)
        {
            BOOrderList boOrderList = await this.OrderListServices.GetOrderListByWhsCode(from, to, whsCode);           

            this.OrderList = new ObservableCollection<BORegisterorderlist>(boOrderList.Registers);
            this.OrderListBackup = new ObservableCollection<BORegisterorderlist>(boOrderList.Registers);
            this.ThereAreNotOrder = this.OrderList.Count() == 0;
        }

        private async Task GetAuditAsync()
        {
            await this.auditService.SetAuditAsync(new BOAudit()
            {
                Action = "Obtener artículos",
                Parameters = $"maximumPageSize ={this.maximumPageSize} , NamePV = {this.NamePV}"
            });
        }

        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetStatesAsync()
        {
            List<BOStateArticle> bOStateArticles = await this.OrderListServices.GetStates();
            bOStateArticles.RemoveAll(r => r.Name == EnumStatesOrder.Borrador.ToString());
            BOStateArticle bOStateArticle = new BOStateArticle();
            bOStateArticle.Name = "Sin filtro...";
            bOStateArticle.StateArticleId = 0;
            bOStateArticles.Insert(0, bOStateArticle);
            this.States = new ObservableCollection<BOStateArticle>(bOStateArticles);
        }

        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetFactoriesAsync()
        {
            List<BOWareHouse> bOWareHouses = await this.WareHouseService.GetAllFactories();
            BOWareHouse bOWareHouse = new BOWareHouse();
            bOWareHouse.WhsName = "Sin filtro...";
            bOWareHouse.WhsCode = null;
            bOWareHouses.Insert(0, bOWareHouse);
            this.Factories = new ObservableCollection<BOWareHouse>(bOWareHouses);
        }

        public void reloadPage()
        {
            this.maximumPageSize = Convert.ToInt32(App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()]);
            this.NamePV = ConfigurationManager.AppSettings["CODIGO_PUNTO_VENTA"];
            this.GetOrderList = GetOrdersAsync(1, this.maximumPageSize, this.NamePV);
            this.WidthForUserControl = (this.PrincipalScreen.Width - 290).ToString();
        }


        #endregion


    }


}
