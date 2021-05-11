using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

using EVO_PB.Models.BusinessObjects;
using EVO_PB.Models.BusinessObjects.Exceptions;

using System.Configuration;
using System.Net;

using Newtonsoft.Json;
using EVO_PB.Utilities;
using EVO_PB.Models.DTOs.BasculasApi;

namespace EVO_PB.Services
{
    public class BasculeService : Mapper
    {
        /// <summary>
        /// Obtiene las basculas de EVO
        /// </summary>       
        /// <returns>Bascules</returns>
        public async Task<List<BOBascules>> GetBascules()
        {
            try
            {
                List<BOBascules> bascules = null;

                using (WebClient wc = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "tipobasculas");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = await wc.DownloadStringTaskAsync(url.AbsoluteUri);
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
