using EVO_PV.Enums;
using EVO_PV.Models;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Models.CajasApi;
using EVO_PV.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PV.Services
{
    class SellerService : Mapper
    {
        #region Atributos
        private AppConfiguration appConfiguration = null;
        #endregion

        #region Constructores

        public SellerService()
        {
            appConfiguration = new AppConfiguration();
        }
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Obtiene una lista de articulos
        /// </summary>
        /// <returns>Objeto de negocio con la lista articulos</returns>
        public async Task<List<BOSeller>> GetSellers()
        {
            List<BOSeller> lst = null;

            try
            {
                using (WebClient client = new WebClient())
                {
                    AppConfiguration appConfiguration = new AppConfiguration();

                    string domain = appConfiguration.AppSettings["API_EVO_PV"].ToString();

                    Uri url = new Uri($"{domain}vendedores/puntoventa");

                    //Uri url = new Uri($"{ConfigurationManager.AppSettings["API_EVO_PV"]}vendedores/puntoventa");

                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<VendedorResponse> response = JsonConvert.DeserializeObject<List<VendedorResponse>>(HtmlResult);
                    lst = this.mapper.Map<List<VendedorResponse>, List<BOSeller>>(response);

                    return lst;
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
