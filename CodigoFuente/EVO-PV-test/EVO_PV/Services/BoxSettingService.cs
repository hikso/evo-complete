
using EVO_PV.Enums;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Models.CajasApi;
using EVO_PV.Utilities;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PV.Services
{
    class BoxSettingService : Mapper
    {
        /// <summary>
        /// Obtiene el usuario de EVO
        /// </summary>       
        /// <returns>Usuario</returns>
        public async Task<BOBoxState> GetBoxState()
        {
            try
            {
                BOBoxState deliveries = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();

                    AppConfiguration appConfiguration = new AppConfiguration();

                    string codePontOfSale = appConfiguration.AppSettings["CODIGO_PUNTO_VENTA"].ToString();

                   // string codePontOfSale = ConfigurationManager.AppSettings[EnumConstanst.CODIGO_PUNTO_VENTA.ToString()];

                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"caja/estadocaja?codigoPuntoVenta={codePontOfSale}" );
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    EstadoCajaResponse response = JsonConvert.DeserializeObject<EstadoCajaResponse>(HtmlResult);
                    deliveries = this.mapper.Map<EstadoCajaResponse, BOBoxState>(response);
                }

                return deliveries;
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
        /// Obtiene el usuario de EVO
        /// </summary>       
        /// <returns>Usuario</returns>
        public async Task<BOBoxSetting> GetBoxSettingHeader()
        {
            try
            {
                BOBoxSetting deliveries = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();

                    AppConfiguration appConfiguration = new AppConfiguration();

                    string codePontOfSale = appConfiguration.AppSettings["CODIGO_PUNTO_VENTA"].ToString();

                   // string codePontOfSale = ConfigurationManager.AppSettings[EnumConstanst.CODIGO_PUNTO_VENTA.ToString()];

                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"caja/apertura?codigoPuntoVenta={codePontOfSale}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    AperturaCajaResponse response = JsonConvert.DeserializeObject<AperturaCajaResponse>(HtmlResult);
                    deliveries = this.mapper.Map<AperturaCajaResponse, BOBoxSetting>(response);
                    deliveries.CodePointOfStore = codePontOfSale;
                }

                return deliveries;
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
        public string SetBoxSetting(BOBoxSetting bOBoxSetting)
        {
            string response = null;
            try
            {
                Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "caja/apertura");

                using (var client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;
                    AperturaCajaRequest pesajeBasculaRequest = this.mapper.Map<BOBoxSetting, AperturaCajaRequest>(bOBoxSetting);

                    string json = JsonConvert.SerializeObject(pesajeBasculaRequest);

                    response = client.UploadString(url.AbsoluteUri, "POST", json);
                }
                return response;
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
        
    }
}
