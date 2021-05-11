using EVO_PV.Enums;
using EVO_PV.Utilities;
using EVO_PV.Models.BusinessObjects;
using EVO_WebApi_New.Models.SettingsApi;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Models.SettingsApi;

namespace EVO_PV.Services
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 23-Dic/2019
    /// Descripción      : Esta clase implementa el llamado a las apis de Configuración
    /// </summary>
    class ConfigService : Mapper
    {
        #region Atributos
        private AppConfiguration appConfiguration = null;
        #endregion

        #region Constructores

        public ConfigService()
        {
            appConfiguration = new AppConfiguration();
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Método que obtiene la versión de la web api EVO
        /// </summary>       
        /// <returns>string con la versión de la web api EVO</returns>
        public BOVersion GetVersion()
        {

            try
            {
                BOVersion bOVersion = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();

                    AppConfiguration appConfiguration = new AppConfiguration();

                    string domain = appConfiguration.AppSettings["API_EVO_PV"].ToString();

                    Uri url = new Uri(domain + $"config/obtenerversionactual");

                    //Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + $"config/obtenerversionactual");
                    client.UseDefaultCredentials = true;
                    
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = client.DownloadString(url.AbsoluteUri);
                    var response = JsonConvert.DeserializeObject<DTOVersionResponse>(HtmlResult);
                    bOVersion = this.mapper.Map<DTOVersionResponse, BOVersion>(response);
                }

                return bOVersion;
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método que obtiene el número máximo de registros por paginación. 
        /// </summary>       
        /// <returns>Entero</returns>
        public BOGeneralParameter GetMaximumPageSize()
        {
            try
            {
                BOGeneralParameter bOGeneralParameter = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();

                    AppConfiguration appConfiguration = new AppConfiguration();

                    string domain = appConfiguration.AppSettings["API_EVO_PV"].ToString();

                    Uri url = new Uri(domain + $"config/obtenerxnombre/{EnumConstanst.TAMANHO_PAGINACION_WEBAPI.ToString()}");

                    //Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + $"config/obtenerxnombre/{EnumConstanst.TAMANHO_PAGINACION_WEBAPI.ToString()}");
                    client.UseDefaultCredentials = true;                    
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = client.DownloadString(url.AbsoluteUri);
                    var response = JsonConvert.DeserializeObject<DTOParametroGeneralResponse>(HtmlResult);
                    bOGeneralParameter = this.mapper.Map<DTOParametroGeneralResponse, BOGeneralParameter>(response);
                }

                return bOGeneralParameter;
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<BOGeneralParameter> GetParameterByName(string key)
        {
            BOGeneralParameter generalParameter = null;

            try
            {
                using (WebClient client = new WebClient())
                {
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri($"{domain}parametrosgenerales/obtenerxnombre/{key}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    DTOParametroGeneralResponse response = JsonConvert.DeserializeObject<DTOParametroGeneralResponse>(HtmlResult);
                    generalParameter = this.mapper.Map<DTOParametroGeneralResponse, BOGeneralParameter>(response);

                    return generalParameter;
                }
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

    }
}
