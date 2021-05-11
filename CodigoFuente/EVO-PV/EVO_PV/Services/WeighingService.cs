using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using EVO_PV.Utilities;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Models.AlistamientosApi;
using EVO_PV.Models.PesajeApi;
using Newtonsoft.Json;
using EVO_PV.Models.ContenedoresApi;
using EVO_PV.Resources.Dictionaries;
using Notifications.Wpf;

namespace EVO_PV.Services
{
    public class WeighingService : Mapper
    {
        /// <summary>
        /// Actualizar pedido con Id
        /// </summary>
        /// <param name="bOOrderEditRequest"></param>
        /// <returns></returns>
        public string SetOrderEditRequest(BOWeighing bOOrderEditRequest)
        {

            try
            {
                Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "pesaje/recepcion");

                string response = "";

                using (var client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;
                    bOOrderEditRequest.Containers = bOOrderEditRequest.Containers.Where(c => c.ContainerQuantity > 0).ToList();
                    PesajeRequest pesajeBasculaRequest = this.mapper.Map<BOWeighing, PesajeRequest>(bOOrderEditRequest);
                    pesajeBasculaRequest.PesoArticulo = Math.Round(pesajeBasculaRequest.PesoArticulo, 3);
                    pesajeBasculaRequest.PesoBascula = Math.Round(pesajeBasculaRequest.PesoBascula, 3);
                    string json = JsonConvert.SerializeObject(pesajeBasculaRequest);

                    string stringResult = client.UploadString(url.AbsoluteUri, "POST", json);

                    response = JsonConvert.DeserializeObject<string>(stringResult);
                }

                return response;
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                return "false";
            }
        }

        public List<BOWeighingByArticle> GetWeighingByArticle(string PesajeArticuloId)
        {
            try
            {
                List<BOWeighingByArticle> weighingByArticle = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"pesaje/recepcion?pesajeArticuloId={PesajeArticuloId}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = client.DownloadString(url.AbsoluteUri);
                    List<PesajeResponse> response = JsonConvert.DeserializeObject<List<PesajeResponse>>(HtmlResult);
                    weighingByArticle = this.mapper.Map<List<PesajeResponse>, List<BOWeighingByArticle>>(response);
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

        public List<BOBarCodeWeighing> GetBarCodes(string ArticleWeighingId)
        {
            try
            {
                List<BOBarCodeWeighing> barCodeWeighing = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"tipocontenedores/codigobarras?pesajeId={ArticleWeighingId}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = client.DownloadString(url.AbsoluteUri);
                    List<CodigoBarrasResponse> response = JsonConvert.DeserializeObject<List<CodigoBarrasResponse>>(HtmlResult);
                    barCodeWeighing = this.mapper.Map<List<CodigoBarrasResponse>, List<BOBarCodeWeighing>>(response);
                }

                return barCodeWeighing;
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
        private Notification notification;

        public BOBarCodeWeighing ReadBarCode(string ArticleWeighingId, string BarCode)
        {
            BOBarCodeWeighing barCodeWeighing = null;
            try
            {
                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"tipocontenedores/codigobarras?pesajeId={ArticleWeighingId}&codigoBarras={BarCode}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = client.UploadString(url.AbsoluteUri, "POST");
                    CodigoBarrasResponse response = JsonConvert.DeserializeObject<CodigoBarrasResponse>(HtmlResult);
                    barCodeWeighing = this.mapper.Map<CodigoBarrasResponse, BOBarCodeWeighing>(response);
                }

                return barCodeWeighing;
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                return barCodeWeighing;
            }
        }
        /// <summary>
        /// Obtiene las basculas de EVO
        /// </summary>       
        /// <returns>Bascules</returns>
        public async Task<string> SetReceiveByQuantityRequest(BOWeighing bOWeighing)
        {

            try
            {
                Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "pesaje/recepcion/cantidadrecibida");
                CantidadRecibidaRequest cantidadRecibidaRequest = this.mapper.Map<BOWeighing, CantidadRecibidaRequest>(bOWeighing);

                using (WebClient client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;

                    string json = JsonConvert.SerializeObject(cantidadRecibidaRequest);

                    return await client.UploadStringTaskAsync(url, "POST", json);
                }
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                return "false";
            }
        }
        
    }
}
