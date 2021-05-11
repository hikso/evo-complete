using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Utilities;
using EVO_PV.Models.FacturacionApi;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVO_PV.Services
{
    /// <summary>
    /// Implementa el API de sociosnegocio
    /// </summary>
    public class CustomerService : Mapper
    {
        #region Atributos
        private AppConfiguration appConfiguration = null;
        #endregion

        #region Constructores

        public CustomerService()
        {
            appConfiguration = new AppConfiguration();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns>List<BOCustomer></returns>
        public async Task<List<BOCustomer>> GetCustomers()
        {
            List<BOCustomer> lstCustomers = null;

            using (WebClient client = new WebClient())
            {
                try
                {
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri($"{domain}sociosnegocio");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<SociosNegocioResponse> response = JsonConvert.DeserializeObject<List<SociosNegocioResponse>>(HtmlResult);
                    lstCustomers = this.mapper.Map<List<SociosNegocioResponse>, List<BOCustomer>>(response);
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

            return lstCustomers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>List<BOCustomer></returns>
        public async Task<List<BOCustomer>> GetCustomers(string identification, string name)
        {
            List<BOCustomer> lstCustomers = null;

            using (WebClient client = new WebClient())
            {
                try
                {
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri($"{domain}sociosnegocio/filtrar?identificacion={identification}&nombre={name}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<SociosNegocioResponse> socioNegocioResponse = JsonConvert.DeserializeObject<List<SociosNegocioResponse>>(HtmlResult);
                    lstCustomers = this.mapper.Map<List<SociosNegocioResponse>, List<BOCustomer>>(socioNegocioResponse);
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

            return lstCustomers;
        }
    }
}
