using EVO_PB.Enums;
using EVO_PB.Utilities;
using EVO_PB.Models.BusinessObjects;
using EVO_WebApi_New.Models.SettingsApi;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EVO_PB.Models.BusinessObjects.Exceptions;

namespace EVO_PB.Services
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 23-Dic/2019
    /// Descripción      : Esta clase implementa el llamado a las apis de Configuración
    /// </summary>
    class ConfigService : Mapper
    {
        #region Constructores
        public ConfigService()
        {

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

                using (WebClient wc = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"config/obtenerversionactual");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = wc.DownloadString(url.AbsoluteUri);
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

                using (WebClient wc = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"parametrosgenerales/obtenerxnombre/{EnumConstanst.TAMANHO_PAGINACION_WEBAPI.ToString()}");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = wc.DownloadString(url.AbsoluteUri);
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
        #endregion

    }
}
