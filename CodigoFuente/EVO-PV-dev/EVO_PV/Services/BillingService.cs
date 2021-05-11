using EVO_PV.Models.ArticulosApi;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Models.FacturacionApi;
using EVO_PV.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PV.Services
{
    public class BillingService : Mapper
    {
        #region Atributos
        private AppConfiguration appConfiguration = null;
        #endregion

        #region Constructores

        public BillingService()
        {
            appConfiguration = new AppConfiguration();
        }
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Obtiene una lista de articulos
        /// </summary>
        /// <returns>Objeto de negocio con la lista articulos</returns>
        public async Task<List<BOBillingArticle>> GetArticles(string codigoPuntoVenta, string customerCode)
        {
            List<BOBillingArticle> lst = null;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri($"{domain}articulos/facturacion?identificacionSocio={customerCode}&codigoPuntoVenta={codigoPuntoVenta}");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = await wc.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<ArticuloPuntoVentaResponse> response = JsonConvert.DeserializeObject<List<ArticuloPuntoVentaResponse>>(HtmlResult);
                    lst = this.mapper.Map<List<ArticuloPuntoVentaResponse>, List<BOBillingArticle>>(response);

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

        /// <summary>
        /// Obtiene una lista de articulos
        /// </summary>
        /// <returns>Objeto de negocio con la lista articulos</returns>
        public async Task<List<BOPayWays>> GetPaymentWays()
        {
            List<BOPayWays> lst = null;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri($"{domain}facturacion/formaspago");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = await wc.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<OtraFormaPagoResponse> response = JsonConvert.DeserializeObject<List<OtraFormaPagoResponse>>(HtmlResult);
                    lst = this.mapper.Map<List<OtraFormaPagoResponse>, List<BOPayWays>>(response);

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

        /// <summary>
        /// Obtiene los articulos por bodega filtrando
        /// </summary>
        /// <param name="buscarArticuloSolicitud"></param>
        /// <returns>Lista de negocio de articulos de una bodega especifica</returns>
        public string GenerateInvoice(BOGenerateInvoice bOGenerateInvoice)
        {
            try
            {
                string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                Uri url = new Uri(domain + "facturacion");

                FacturaRequest facturaRequest = this.mapper.Map<BOGenerateInvoice, FacturaRequest>(bOGenerateInvoice);
                string stringResult = "";

                using (WebClient client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;

                    string json = JsonConvert.SerializeObject(facturaRequest);

                    stringResult = client.UploadString(url.AbsoluteUri, "POST", json);

                }


                return stringResult;
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
        /// Obtiene una lista de articulos
        /// </summary>
        /// <returns>Objeto de negocio con la lista articulos</returns>
        public async Task<List<BOBank>> GetBanks()
        {
            List<BOBank> lst = null;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri($"{domain}facturacion/bancos");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = await wc.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<BancoResponse> response = JsonConvert.DeserializeObject<List<BancoResponse>>(HtmlResult);
                    lst = this.mapper.Map<List<BancoResponse>, List<BOBank>>(response);

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

        /// <summary>
        /// Obtiene un objeto de articulos
        /// </summary>
        /// <returns>Objeto de negocio articulos</returns>
        public async Task<BOBillingArticle> GetArticle(string customerCode, string code, string name)
        {
            BOBillingArticle article = null;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri($"{domain}articulo/puntoventa/filtrar?codigoCliente={customerCode}&codigo={code}&nombre={name}");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = await wc.DownloadStringTaskAsync(url.AbsoluteUri);
                    ArticuloPuntoVentaResponse response = JsonConvert.DeserializeObject<ArticuloPuntoVentaResponse>(HtmlResult);
                    article = this.mapper.Map<ArticuloPuntoVentaResponse, BOBillingArticle>(response);

                    return article;
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

