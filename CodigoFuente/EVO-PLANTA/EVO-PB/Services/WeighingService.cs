using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using EVO_PB.Utilities;
using EVO_PB.Models.BusinessObjects;
using EVO_PB.Models.BusinessObjects.Exceptions;
using EVO_PB.Models.AlistamientoApi;
using Newtonsoft.Json;

namespace EVO_PB.Services
{
    public class WeighingService : Mapper
    {
        /// <summary>
        /// Actualizar pedido con Id
        /// </summary>
        /// <param name="bOOrderEditRequest"></param>
        /// <returns></returns>
        public bool SetOrderEditRequest(BOWeighing bOOrderEditRequest)
        {

            try
            {
                Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "alistamiento/pesaje/bascula");

                bool response = false;

                using (var client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;
                    bOOrderEditRequest.Containers = bOOrderEditRequest.Containers.Where(c => c.ContainerQuantity > 0).ToList();
                    PesajeBasculaRequest pesajeBasculaRequest = this.mapper.Map<BOWeighing, PesajeBasculaRequest>(bOOrderEditRequest);

                    string json = JsonConvert.SerializeObject(pesajeBasculaRequest);

                    string stringResult = client.UploadString(url.AbsoluteUri, "POST", json);

                    response = JsonConvert.DeserializeObject<bool>(stringResult);
                }

                return response;
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

        public BOWeighingByArticle GetWeighingByArticle(string ArticleDetailId)
        {
            try
            {
                BOWeighingByArticle weighingByArticle = null;

                using (WebClient wc = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"alistamiento/articulo/pesajes?id={ArticleDetailId}");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = wc.DownloadString(url.AbsoluteUri);
                    PesajesArticuloResponse response = JsonConvert.DeserializeObject<PesajesArticuloResponse>(HtmlResult);
                    weighingByArticle = this.mapper.Map<PesajesArticuloResponse, BOWeighingByArticle>(response);
                }

                return weighingByArticle;
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
