using EVO_PV;
using EVO_PV.Enum;
using EVO_PV.Enums;
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
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{

    public class VMNewOrders : NotifyPropertyChanged
    {
        #region Atributos privados
        private MainWindow PrincipalScreen;
        private BOOrderType orderTypeSelected;
        private int orderTypeSelectedId;
        private bool thereAreNotOrder;
        private ObservableCollection<BOOrderType> orderTypes { get; set; }
        private ObservableCollection<BORegisterorderlist> orderList { get; set; }
        private int maximumPageSize { get; set; }
        private string NamePV { get; set; }
        private BORegisterorderlist orderSelect { get; set; }
        public List<VMSubItem> subItems;
        private Notification notification;
        #endregion

        #region Atributos públicos        

        public int OrderTypeSelectedId
        {
            get { return orderTypeSelectedId; }
            set
            {
                orderTypeSelectedId = value;
                this.OrderTypeSelected = OrderTypes.Where(r => r.OrderTypeId == OrderTypeSelectedId).FirstOrDefault();
                this.OnPropertyChanged("OrderTypeSelectedId");
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

        public BOOrderType OrderTypeSelected
        {
            get { return orderTypeSelected; }
            set
            {
                orderTypeSelected = value;
                this.OnPropertyChanged("OrderTypeSelected");
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

        public BORegisterorderlist OrderSelect
        {
            get { return orderSelect; }
            set
            {

                orderSelect = value;

                this.OnPropertyChanged("OrderSelect");

            }
        }
        public ObservableCollection<BOOrderType> OrderTypes
        {
            get { return this.orderTypes; }
            set
            {
                this.orderTypes = value;
                this.OnPropertyChanged("OrderTypes");
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
                        if (item.State == EnumStatesOrder.Borrador.ToString())
                        {
                            item.BtnEye = true;
                            item.BtnDuplicate = false;
                            item.CodeOrder = string.Empty;
                        }
                    }
                }

                this.OnPropertyChanged("OrderList");
            }
        }
        #endregion

        #region Objetos de Servicios
        private OrderListService OrderListServices;
        #endregion

        #region Tareas
        /// <summary>
        /// Task para llamar en el constructor métodos asyncronos
        /// </summary>
        private Task GetOrderList;
        private Task GetOrderTypes;
        #endregion

        #region Comandos Eventos de botones 
        public ICommand CmdCreateNewOrder { get; } /// Botón Duplicar pedido
        public ICommand ViewEditOrderCommand { get; } /// Botón Editar pedido
        #endregion

        #region Constructores
        public VMNewOrders(MainWindow principalScreen)
        {
            this.PrincipalScreen = principalScreen;

            this.OrderListServices = new OrderListService();
            this.maximumPageSize = Convert.ToInt32(App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()]);
            this.NamePV = ConfigurationManager.AppSettings["CODIGO_PUNTO_VENTA"];

            this.GetOrderList = GetOrdersAync();
            this.GetOrderTypes = GetOrderTypesAsync();            
            this.CmdCreateNewOrder = new RelayCommand(CreateNewOrder);
            this.ViewEditOrderCommand = new RelayCommand(GetEditOrder);
            this.notification = new Notification();

        }

        #endregion

        #region Métodos Privados
        private void GetDetailOrder()
        {
            object obj = this.OrderSelect;
            this.PrincipalScreen.ContentPage.Content = new UCOrderListDetail(this.PrincipalScreen, this.OrderSelect.OrderId);
        }

        private void CreateNewOrder()
        {
            if (this.OrderTypeSelected == null)
            {
                this.notification.Show(DictMessages.Information, DictMessages.SeleccionarTipoSolicitud, NotificationType.Information);
                return;
            }
            this.PrincipalScreen.ContentPage.Content = new UCOrderRequest(this.PrincipalScreen, this.OrderTypeSelected);
        }

        private void GetEditOrder()
        {
            object obj = this.OrderSelect;
            this.PrincipalScreen.ContentPage.Content = new UCOrderListEdit(this.PrincipalScreen, this.OrderSelect.OrderId, EnumConstanst.Edit);
        }


        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetOrdersAync()
        {
            this.NamePV = ConfigurationManager.AppSettings["CODIGO_PUNTO_VENTA"];
            List<BORegisterorderlist> ORegisterorderlist = await this.OrderListServices.GetOrderListForDraft(NamePV);
            this.OrderList = new ObservableCollection<BORegisterorderlist>(ORegisterorderlist);
            this.ThereAreNotOrder = this.OrderList.Count() == 0;
        }

        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetOrderTypesAsync()
        {
            List<BOOrderType> ORegisterorderlist = await this.OrderListServices.GetOrderTypes();

            this.OrderTypes = new ObservableCollection<BOOrderType>(ORegisterorderlist);
        }
        
        public void reloadPage()
        {
            this.OrderListServices = new OrderListService();
            this.maximumPageSize = Convert.ToInt32(App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()]);
            this.NamePV = ConfigurationManager.AppSettings["CODIGO_PUNTO_VENTA"];

            this.GetOrderList = GetOrdersAync();
            this.GetOrderTypes = GetOrderTypesAsync();
            this.notification = new Notification();
        }


        #endregion


    }


}
