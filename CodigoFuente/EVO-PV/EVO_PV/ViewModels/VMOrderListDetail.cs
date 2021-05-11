
using EVO_PV;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Services;
using EVO_PV.Utilities;
using EVO_PV.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EVO_PV.ViewModels
{
    public class VMOrderListDetail : NotifyPropertyChanged
    {
        #region Atributos privados
        private MainWindow PrincipalScreen;
        private int ID;
        private BOOrderListDetails orderListDetails { get; set; }
        #endregion

        #region Atributos públicos
        public BOOrderListDetails OrderListDetails
        {
            get { return orderListDetails; }

            set
            {
                this.orderListDetails = value;
                this.OnPropertyChanged("OrderListDetails");
            }
        }
        #endregion

        #region Comandos Eventos de botones 
        public ICommand ViewDetails { get; } /// Botón
        #endregion

        #region Objetos de Servicios
        private OrderListService OrderListServices;
        #endregion

        #region Tareas
        /// <summary>
        /// Task para llamar en el constructor métodos asyncronos
        /// </summary>
        private Task GetOrderListDetails;
        #endregion

        #region Constructor
        public VMOrderListDetail(MainWindow principalScreen, int id)
        {
            this.PrincipalScreen = principalScreen;
            this.ViewDetails = new RelayCommand(ViewDetailShow);
            this.ID = id;
            this.OrderListServices = new OrderListService();
            this.GetOrderListDetails = GetOrderListAsync(this.ID);
        }

        #endregion


        #region Métodos Privados
        /// <summary>
        /// Método que obtiene las plantas de forma asíncrona
        /// </summary>  
        private async Task GetOrderListAsync(int id)
        {
            this.OrderListDetails = await this.OrderListServices.GetOrderListById(id);

        }
        
        private void ViewDetailShow()
        {
            this.PrincipalScreen.ContentPage.Content = new UCOrderList(this.PrincipalScreen);
        }

        #endregion

      
    }
}
