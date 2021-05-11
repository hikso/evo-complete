using EVO_PV.Enums;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Services;
using EVO_PV.Utilities;
using System.ComponentModel;
using System.Configuration;
using System.Threading.Tasks;

namespace EVO_PV.ViewModels
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 17-Ene/2019
    /// Descripción      : Esta clase implementa el View Model del formulario del splash screen
    /// </summary>
    public class VMSplashScreen : NotifyPropertyChanged
    {
        #region Servicios
        private ConfigService configService;
        private WareHouseService wareHouseService;
        private UserService userService;
        #endregion

        #region Atributos      
        private BOVersion bOVersion;
        private BOWareHouse bOWareHouse;
        private BOGeneralParameter bOGeneralParameter;
        private BOUser bOUser;
        public string version { get; set; }
        #endregion

        #region Propiedades

        public string Version
        {
            get { return version; }
            set
            {
                version = value;
                OnPropertyChanged("Version");
            }
        }

        #endregion

        #region Constructores
        public VMSplashScreen()
        {
            configService = new ConfigService();
            wareHouseService = new WareHouseService();
            userService = new UserService();

            this.GetUser();
            this.GetVersion();
            this.GetPointOfSale();
            this.GetMaximumPageSize();
            this.GetBagTax();
            this.GetDecimals();
            this.GetPurchaseOrderTypeId();
        }

        #endregion

        #region Métodos     

        /// <summary>
        /// Método que obtiene el usuario de forma síncrona y lo agrega globalmente
        /// </summary>
        /// <returns>BOVersionResponse</returns>
        private void GetUser()
        {
            bOUser = this.userService.GetUser();
            App.Current.Properties.Add("BOUser", bOUser);
        }

        /// <summary>
        /// Método que obtiene la versión de forma síncrona y lo agrega globalmente
        /// </summary>
        /// <returns>BOVersionResponse</returns>
        private void GetVersion()
        {
            bOVersion = this.configService.GetVersion();
            Version = "V " + bOVersion.version;
            App.Current.Properties.Add(EnumConstanst.Version.ToString(), bOVersion.version);
        }

        /// <summary>
        /// Método que obtiene el punto de venta por código de forma síncrona y lo agrega globalmente
        /// </summary>
        /// <returns>Objeto de negocio de tipo almacen</returns>
        private void GetPointOfSale()
        {
            AppConfiguration appConfiguration = new AppConfiguration();

            string codePontOfSale = appConfiguration.AppSettings[EnumConstanst.CODIGO_PUNTO_VENTA.ToString()];

            //string codePontOfSale = ConfigurationManager.AppSettings[EnumConstanst.CODIGO_PUNTO_VENTA.ToString()];
            bOWareHouse = this.wareHouseService.GetWareHouseByCode(codePontOfSale);
            App.Current.Properties.Add(EnumConstanst.WhsName.ToString(), bOWareHouse.WhsName);
            App.Current.Properties.Add(EnumConstanst.WhsCode.ToString(), bOWareHouse.WhsCode);
            bOWareHouse.InvoiceDiscountPercent = bOWareHouse.InvoiceDiscountPercent == null ? "0":bOWareHouse.InvoiceDiscountPercent;
            App.Current.Properties.Add(EnumConstanst.INVOICEDISCOUNTPERCENT.ToString(), bOWareHouse.InvoiceDiscountPercent);
        }

        /// <summary>
        /// Método que obtiene el máximo tamaño de paginación de forma síncrona y lo agrega globalmente
        /// </summary>
        /// <returns>Objeto de negocio de tipo almacen</returns>
        private void GetMaximumPageSize()
        {
            bOGeneralParameter = this.configService.GetMaximumPageSize();
            App.Current.Properties.Add(EnumConstanst.MaximumPageSize.ToString(), bOGeneralParameter.Valor);
        }

        /// <summary>
        /// Método que obtiene el máximo tamaño de paginación de forma síncrona y lo agrega globalmente
        /// </summary>
        /// <returns>Objeto de negocio de tipo almacen</returns>
        private async void GetBagTax()
        {
            BOGeneralParameter bOGeneralParameter = new BOGeneralParameter();

            bOGeneralParameter = await this.configService.GetParameterByName("VALOR_BOLSA");
            App.Current.Properties.Add(EnumConstanst.BAGVALUE.ToString(), bOGeneralParameter.Valor);
            
            bOGeneralParameter = await this.configService.GetParameterByName("PORCENTAJE_BOLSA");
            App.Current.Properties.Add(EnumConstanst.BagPlasticPercent.ToString(), bOGeneralParameter.Valor);
        }
        
        /// <summary>
        /// Método que obtiene los decimales que se usaran dentro de la aplicación
        /// </summary>
        /// <returns>Objeto     </returns>
        private async void GetDecimals()
        {
            BOGeneralParameter bOGeneralParameter = new BOGeneralParameter();

            bOGeneralParameter = await this.configService.GetParameterByName("FORMATO_DECIMAL");
            App.Current.Properties.Add(EnumConstanst.Decimals.ToString(), bOGeneralParameter.Valor);
        }
        
        
        /// <summary>
        /// Método que obtiene los decimales que se usaran dentro de la aplicación
        /// </summary>
        /// <returns>Objeto     </returns>
        private async void GetPurchaseOrderTypeId()
        {
            BOGeneralParameter bOGeneralParameter = new BOGeneralParameter();

            bOGeneralParameter = await this.configService.GetParameterByName("PURCHASE_ORDER_TYPE_ID");
            App.Current.Properties.Add(EnumConstanst.PurchaseOrderTypeId.ToString(), bOGeneralParameter.Valor);
        }
        #endregion


    }
}
