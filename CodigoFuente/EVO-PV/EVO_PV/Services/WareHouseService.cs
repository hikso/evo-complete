using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Models.DTOs.WareHouseApi;
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
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 26-Dic/2019
    /// Descripción      : Esta clase implementa el llamado a las apis de las Bodegas
    /// </summary>
    public class WareHouseService : Mapper
    {
        #region Contructores
        public WareHouseService()
        {

        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Método que retorna las plantas
        /// </summary>
        /// <returns>Lista de plantas de tipo WareHouse</returns>
        public async Task<List<BOWareHouse>> GetFactories()
        {
          
            try
            {
                List<BOWareHouse> factories = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + "bodegas/planta");
                    client.UseDefaultCredentials = true;
                    
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<BodegaResponse> response = JsonConvert.DeserializeObject<List<BodegaResponse>>(HtmlResult);
                    factories = this.mapper.Map<List<BodegaResponse>, List<BOWareHouse>>(response);
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

        /// <summary>
        /// Método que retorna la bodega por el código
        /// </summary>
        /// <returns>Bodega de tipo WareHouse</returns>
        public BOWareHouse GetWareHouseByCode(string code)
        {

            try
            {
                BOWareHouse wareHouse = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + $"bodegas/{code}");
                    client.UseDefaultCredentials = true;
                    
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = client.DownloadString(url.AbsoluteUri);
                    BodegaResponse response = JsonConvert.DeserializeObject<BodegaResponse>(HtmlResult);
                    wareHouse = this.mapper.Map<BodegaResponse, BOWareHouse>(response);
                }

                return wareHouse;
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

        public async Task<List<BOWareHouse>> GetSalePoints()
        {

            try
            {
                List<BOWareHouse> factories = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "bodegas/puntoventa");
                    client.UseDefaultCredentials = true;

                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<BodegaResponse> response = JsonConvert.DeserializeObject<List<BodegaResponse>>(HtmlResult);
                    factories = this.mapper.Map<List<BodegaResponse>, List<BOWareHouse>>(response);
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
        #endregion
    }
}
