
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Utilities;
using EVO_PV.Models.EntregasOrderApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PV.Services
{
    class RequestService : Mapper
    {
        #region Atributos
        private AppConfiguration appConfiguration = null;
        #endregion

        #region Constructores

        public RequestService()
        {
            appConfiguration = new AppConfiguration();
        }
        #endregion

        /// <summary>
        /// Obtiene el usuario de EVO
        /// </summary>       
        /// <returns>Usuario</returns>
        public async Task<List<BOOrderRequestList>> GetOrdersRequest()
        {
            try
            {
                List<BOOrderRequestList> requests = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri(domain + "pedidos/recepcion");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<EntregaOrderResponse> response = JsonConvert.DeserializeObject<List<EntregaOrderResponse>>(HtmlResult);
                    requests = this.mapper.Map<List<EntregaOrderResponse>, List<BOOrderRequestList>>(response);
                }

                return requests;
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
