using EVO_PV;
using EVO_PV.Enum;
using EVO_PV.Enums;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Services;
using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
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

    public class VMOrderList : NotifyPropertyChanged
    {
        #region Atributos privados
        private MainWindow PrincipalScreen;
        private ObservableCollection<BORegisterorderlist> orderList { get; set; }
        private int maximumPageSize { get; set; }
        private string NamePV { get; set; }
        private BORegisterorderlist orderSelect { get; set; }
        public List<VMSubItem> subItems;
        #endregion

        #region Atributos públicos        

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

            this.OrderListServices = new OrderListService();
            this.maximumPageSize = Convert.ToInt32(App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()]);
            this.NamePV = ConfigurationManager.AppSettings["CODIGO_PUNTO_VENTA"];

            this.GetOrderList = GetFactoriesAsync(1, this.maximumPageSize, this.NamePV);
            this.ViewEditOrderCommand = new RelayCommand(GetEditOrder);
            this.ViewDuplicateOrderCommand = new RelayCommand(GetDuplicateOrder);
            this.ViewDetailsCommand = new RelayCommand(GetDetailOrder);
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


        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetFactoriesAsync(int from, int to, string whsCode)
        {
            BOOrderList boOrderList = await this.OrderListServices.GetOrderListByWhsCode(from, to, whsCode);

            this.OrderList = new ObservableCollection<BORegisterorderlist>(boOrderList.Registers);
        }
        public void reloadPage()
        {
            this.maximumPageSize = Convert.ToInt32(App.Current.Properties[EnumConstanst.MaximumPageSize.ToString()]);
            this.NamePV = ConfigurationManager.AppSettings["CODIGO_PUNTO_VENTA"];
            this.GetOrderList = GetFactoriesAsync(1, this.maximumPageSize, this.NamePV);
        }


        #endregion


    }


}
