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
    public class ContainerService : Mapper
    {
        /// <summary>
        /// Obtiene las basculas de EVO
        /// </summary>       
        /// <returns>Bascules</returns>
        public async Task<List<BOContainers>> GetContainer()
        {
            try
            {
                List<BOContainers> containers = null;

                using (WebClient wc = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "tipocontenedores");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = await wc.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<TipoContenedorResponse> response = JsonConvert.DeserializeObject<List<TipoContenedorResponse>>(HtmlResult);
                    containers = this.mapper.Map<List<TipoContenedorResponse>, List<BOContainers>>(response);
                }

                return containers;
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
