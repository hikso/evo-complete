
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Utilities;
using EVO_PV.Models.EntregasApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EVO_PV.Models.DTOs.ArticlesApi;
using EVO_PV.Models.RecepcionApi;
using EVO_PV.Models.ArticlesApi;

namespace EVO_PV.Services
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

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"entregas/pedidoid?pedidoId={PedidoId}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
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
                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"articulos/alistamiento?id={DeliveryId}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
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

        /// <summary>
        /// Obtiener el encabezado 
        /// </summary>       
        /// <returns>Usuario</returns>
        public async Task<BODeliveryReceiveHeader> GetDeliveryReceiveHeader(string DeliveryId)
        {
            try
            {
                BODeliveryReceiveHeader deliveries = new BODeliveryReceiveHeader();

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"recepcion/encabezado?entregaId={DeliveryId}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    RecepcionEncabezadoResponse response = new RecepcionEncabezadoResponse();

                    response = JsonConvert.DeserializeObject<RecepcionEncabezadoResponse>(HtmlResult);
                    deliveries = this.mapper.Map<RecepcionEncabezadoResponse, BODeliveryReceiveHeader>(response);
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

        public async Task<BOReceiveFinalizedDocuments> ConfirmDeliveryReceive(string DeliveryId)
        {
            BOReceiveFinalizedDocuments bOReceiveFinalizedDocuments = null;
            try
            {
                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"recepcion/confirmar?entregaId={DeliveryId}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.UploadStringTaskAsync(url, "POST");

                    RecepcionResponse response = JsonConvert.DeserializeObject<RecepcionResponse>(HtmlResult);

                    bOReceiveFinalizedDocuments = this.mapper.Map<RecepcionResponse, BOReceiveFinalizedDocuments>(response);

                }
                return bOReceiveFinalizedDocuments;
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
