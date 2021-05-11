using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Models.DTOs.BusinessObjects;

using System.Configuration;
using System.Net;

using Newtonsoft.Json;
using EVO_PV.Utilities;
using EVO_PV.Models.ContenedoresApi;
namespace EVO_PV.Services
{
    public class ContainerService : Mapper
    {
        #region Atributos
        private AppConfiguration appConfiguration = null;
        #endregion

        #region Constructores

        public ContainerService()
        {
            appConfiguration = new AppConfiguration();
        }
        #endregion

        /// <summary>
        /// Obtiene las basculas de EVO
        /// </summary>       
        /// <returns>Bascules</returns>
        public async Task<List<BOContainers>> GetContainer()
        {
            try
            {
                List<BOContainers> containers = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri(domain + "tipocontenedores");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
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
        public List<BOContainers> GetContainersByArticle(string PesajeArticuloId)
        {
            try
            {
                List<BOContainers> containers = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri(domain + $"tipocontenedores/pesaje?pesajeId={PesajeArticuloId}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = client.DownloadString(url.AbsoluteUri);
                    List<PesajeContenedorResponse> response = JsonConvert.DeserializeObject<List<PesajeContenedorResponse>>(HtmlResult);
                    containers = this.mapper.Map<List<PesajeContenedorResponse>, List<BOContainers>>(response);
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
