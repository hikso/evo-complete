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
                    Uri url = new Uri($"{ConfigurationManager.AppSettings["API_EVO"]}vendedores/puntoventa?codigo=PV-PRA");
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
