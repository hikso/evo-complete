
using EVO_PB.Models.BusinessObjects;
using EVO_PB.Models.BusinessObjects.Exceptions;
using EVO_PB.Utilities;
using EVO_WebApi_New.Models.EntregasApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EVO_PB.Models.DTOs.ArticulosApi;
namespace EVO_PB.Services
{
    class DeliveryService : Mapper
    {
        /// <summary>
        /// Obtiene el usuario de EVO
        /// </summary>       
        /// <returns>Usuario</returns>
        public async Task<List<BODelivery>> GetDeliveries(string PedidoId)
        {
            try
            {
                List<BODelivery> deliveries = null;

                using (WebClient wc = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"entregas/enrutamiento/pedidoid?pedidoId={PedidoId}");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = await wc.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<EntregaResponse> response = JsonConvert.DeserializeObject<List<EntregaResponse>>(HtmlResult);
                    deliveries = this.mapper.Map<List<EntregaResponse>, List<BODelivery>>(response);
                }

                return deliveries;
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
        /// Obtiene el usuario de EVO
        /// </summary>       
        /// <returns>Usuario</returns>
        public async Task<BODelivery> GetDelivery(string DeliveryId)
        {
            try
            {
                BODelivery deliveries = new BODelivery();
                deliveries.EnlistmentArticles = new List<BOEnlistmentArticles>();
                using (WebClient wc = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"articulos/alistamiento?id={DeliveryId}");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = await wc.DownloadStringTaskAsync(url.AbsoluteUri);
                    DetalleEntregaResponse response = new DetalleEntregaResponse();
                    response.ArticulosResponse = new List<ArticuloAlistamientoResponse>();
                    response = JsonConvert.DeserializeObject<DetalleEntregaResponse>(HtmlResult);
                    deliveries = this.mapper.Map<DetalleEntregaResponse, BODelivery>(response);
                    deliveries.Consecutive = (deliveries.Consecutive != null) ? deliveries.Consecutive : "Sin Generar";
                }

                return deliveries;
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
