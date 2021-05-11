
using EVO_PB.Models.BusinessObjects;
using EVO_PB.Models.BusinessObjects.Exceptions;
using EVO_PB.Utilities;
using EVO_WebApi_New.Models.EntregasOrderApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PB.Services
{
    class RequestService : Mapper
    {
        /// <summary>
        /// Obtiene el usuario de EVO
        /// </summary>       
        /// <returns>Usuario</returns>
        public async Task<List<BOOrderRequest>> GetOrdersRequest()
        {
            try
            {
                List<BOOrderRequest> factories = null;

                using (WebClient wc = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "pedidos/alistamiento");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = await wc.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<EntregaOrderResponse> response = JsonConvert.DeserializeObject<List<EntregaOrderResponse>>(HtmlResult);
                    factories = this.mapper.Map<List<EntregaOrderResponse>, List<BOOrderRequest>>(response);
                }

                return factories;
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
