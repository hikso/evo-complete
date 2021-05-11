using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;

using System.Configuration;
using System.Net;

using Newtonsoft.Json;
using EVO_PV.Utilities;
using EVO_PV.Models.DTOs.BasculasApi;

namespace EVO_PV.Services
{
    public class BasculeService : Mapper
    {
        #region Atributos
        private AppConfiguration appConfiguration = null;
        #endregion

        #region Constructores

        public BasculeService()
        {
            appConfiguration = new AppConfiguration();
        }
        #endregion

        /// <summary>
        /// Obtiene las basculas de EVO
        /// </summary>       
        /// <returns>Bascules</returns>
        public async Task<List<BOBascules>> GetBascules()
        {
            try
            {
                List<BOBascules> bascules = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();

                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri(domain + "tipobasculas");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<TipoBasculaResponse> response = JsonConvert.DeserializeObject<List<TipoBasculaResponse>>(HtmlResult);
                    bascules = this.mapper.Map<List<TipoBasculaResponse>, List<BOBascules>>(response);
                }

                return bascules;
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
