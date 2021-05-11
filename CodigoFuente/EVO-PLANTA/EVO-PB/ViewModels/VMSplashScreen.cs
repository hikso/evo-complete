using EVO_PB.Enums;
using EVO_PB.Models.BusinessObjects;
using EVO_PB.Services;
using EVO_PB.Utilities;
using System.ComponentModel;
using System.Configuration;

namespace EVO_PB.ViewModels
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
            string codePontOfSale = ConfigurationManager.AppSettings[EnumConstanst.CODIGO_PLANTA.ToString()];
            bOWareHouse = this.wareHouseService.GetWareHouseByCode(codePontOfSale);
            App.Current.Properties.Add(EnumConstanst.WhsName.ToString(), bOWareHouse.WhsName);
            App.Current.Properties.Add(EnumConstanst.WhsCode.ToString(), bOWareHouse.WhsCode);
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

        #endregion
       

    }
}
