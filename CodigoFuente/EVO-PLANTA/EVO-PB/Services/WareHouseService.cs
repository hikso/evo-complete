using EVO_PB.Models.BusinessObjects;
using EVO_PB.Models.BusinessObjects.Exceptions;
using EVO_PB.Models.DTOs.WareHouseApi;
using EVO_PB.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PB.Services
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

                using (WebClient wc = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "bodegas/planta");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = await wc.DownloadStringTaskAsync(url.AbsoluteUri);
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

                using (WebClient wc = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"bodegas/{code}");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = wc.DownloadString(url.AbsoluteUri);
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

        /// <summary>
        /// Método que retorna la bodega por el código
        /// </summary>
        /// <returns>Bodega de tipo WareHouse</returns>
        public async Task<List<BOWareHouse>> GetWareHouseByDeliveryAndArticle(string delivery, string articleId)
        {
            try
            {
                List<BOWareHouse> wareHouses = null;

                using (WebClient wc = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"bodegas/filtrar?entregaId={delivery}&codigo={articleId}");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = await wc.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<BodegaResponse> response = JsonConvert.DeserializeObject<List<BodegaResponse>>(HtmlResult);
                    wareHouses = this.mapper.Map<List<BodegaResponse>, List<BOWareHouse>>(response);
                }

                return wareHouses;
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
