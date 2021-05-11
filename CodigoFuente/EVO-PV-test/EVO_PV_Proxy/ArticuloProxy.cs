using EVO_BusinessObjects;
using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Utils;
using EVO_PV_Proxy.Models.ArticuloApi;
using EVO_PV_Proxy.Models.ArticulosApi;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PV_Proxy
{
    public class ArticuloProxy : Automapper
    {
        /// <summary>
        /// Obtiene los empaques
        /// </summary>
        /// <returns>List<BOEmpaque></returns>
        public async Task<List<BOEmpaque>> ObtenerEmpaques()
        {
            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            var HtmlResult = string.Empty;
            List<EmpaqueResponse> empaqueResponse = null;
            List<BOEmpaque> empaques = null;

            await WindowsIdentity.RunImpersonated(currentUser.AccessToken, async () =>
            {
                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();

                    AppConfiguration appConfig = new AppConfiguration();

                    Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "articulos/empaques");

                    client.UseDefaultCredentials = true;

                    HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);                   
                    
                }
            });

            if (!string.IsNullOrEmpty(HtmlResult))
            {
                empaqueResponse= JsonConvert.DeserializeObject<List<EmpaqueResponse>>(HtmlResult);
                empaques = this.iMapper.Map<List<EmpaqueResponse>, List<BOEmpaque>>(empaqueResponse);
            }

            return empaques;

        }

        

        /// <summary>
        /// Obtiene las unidades de medida de un articulo
        /// </summary>
        /// <returns>Unidad de medida</returns>
        public async Task<List<UnidadMedida>> ObtenerTodasUnidadesMedida()
        {
            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            var HtmlResult = string.Empty;

            await WindowsIdentity.RunImpersonated(currentUser.AccessToken, async () =>
            {
                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();

                    AppConfiguration appConfig = new AppConfiguration();

                    Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "articulos/unidadmedida");

                    client.UseDefaultCredentials = true;

                    HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                }
            });

            return JsonConvert.DeserializeObject<List<UnidadMedida>>(HtmlResult);

        }

        /// <summary>
        /// Obtiene los estados de un articulos
        /// </summary>
        /// <returns>Estado de articulo</returns>
        public async Task<List<EstadoArticulo>> ObtenerTodosEstados()
        {
            try
            {
                IHttpContextAccessor ctx = new HttpContextAccessor();

                WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

                var HtmlResult = string.Empty;

                await WindowsIdentity.RunImpersonated(currentUser.AccessToken, async () =>
                {
                    using (WebClient client = new WebClient())
                    {
                        CredentialCache cc = new CredentialCache();

                        AppConfiguration appConfig = new AppConfiguration();

                        Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "articulos/estado");

                        client.UseDefaultCredentials = true;

                        HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    }
                });

                return JsonConvert.DeserializeObject<List<EstadoArticulo>>(HtmlResult);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Obtiene las acciones de artículo
        /// </summary>
        /// <returns>acciones de articulo</returns>
        public async Task<List<Accion>> ObtenerAcciones()
        {
            try
            {
                IHttpContextAccessor ctx = new HttpContextAccessor();

                WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

                var HtmlResult = string.Empty;

                await WindowsIdentity.RunImpersonated(currentUser.AccessToken, async () =>
                {
                    using (WebClient client = new WebClient())
                    {
                        CredentialCache cc = new CredentialCache();

                        AppConfiguration appConfig = new AppConfiguration();

                        Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "articulos/accion");

                        client.UseDefaultCredentials = true;

                        HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    }
                });

                return JsonConvert.DeserializeObject<List<Accion>>(HtmlResult);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Obtiene  todos los articulos de una bodega
        /// </summary>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <param name="codigoBodega"></param>
        /// <returns>Lista de articulos de la bodega solicitada</returns>
        public async Task<ObtenerArticulos> ObtenerTodosArticulosxBodega(int desde, int hasta, string whsCodePuntoVenta, string whsCodePlanta,string tipoSolicitud)
        {

            ObtenerTodosArticulosResponse result = new ObtenerTodosArticulosResponse();

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            await WindowsIdentity.RunImpersonated(currentUser.AccessToken, async () =>
            {
                using (WebClient client = new WebClient())
                {
                    AppConfiguration appConfig = new AppConfiguration();

                    Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "articulos/bodega");

                    client.UseDefaultCredentials = true;
                    client.QueryString.Add("desde", desde.ToString());
                    client.QueryString.Add("hasta", hasta.ToString());
                    client.QueryString.Add("whsCodePuntoVenta", whsCodePuntoVenta);
                    client.QueryString.Add("whsCodePlanta", whsCodePlanta);
                    client.QueryString.Add("tipoSolicitud", tipoSolicitud);

                    client.Encoding = Encoding.UTF8;

                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);

                    result = JsonConvert.DeserializeObject<ObtenerTodosArticulosResponse>(HtmlResult);
                }
            });


            return this.iMapper.Map<ObtenerTodosArticulosResponse, ObtenerArticulos>(result);
        }

        public ObtenerTodosArticulos ObtenerTodosArticulosFiltrar(FiltrarArticulo filtro)
        {
            AppConfiguration appConfig = new AppConfiguration();

            Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "articulos/bodega/filtrar");

            string data = JsonConvert.SerializeObject(filtro);

            ObtenerTodosArticulos response = new ObtenerTodosArticulos();

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (var client = new WebClient { UseDefaultCredentials = true })
               {
                   client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                   client.Encoding = Encoding.UTF8;

                   string stringResult = client.UploadString(url.AbsoluteUri, "POST", data);

                   response = JsonConvert.DeserializeObject<ObtenerTodosArticulos>(stringResult);
               }
           });

            return response;
        }

        /// <summary>
        /// Obtiene los articulos por bodega filtrando
        /// </summary>
        /// <param name="buscarArticuloSolicitud"></param>
        /// <returns>Lista de negocio de articulos de una bodega especifica</returns>
        public List<ArticuloBodega> ObtenerArticulosBodega(BuscarArticuloSolicitud buscarArticuloSolicitud)
        {
            AppConfiguration appConfig = new AppConfiguration();

            Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "articulos/bodega/buscar");

            BuscarArticuloRequest buscarArticuloRequest = this.iMapper.Map<BuscarArticuloSolicitud, BuscarArticuloRequest>(buscarArticuloSolicitud);

            List<ArticuloBodega> response = null;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (WebClient client = new WebClient { UseDefaultCredentials = true })
               {
                   client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                   client.Encoding = Encoding.UTF8;

                   string json = JsonConvert.SerializeObject(buscarArticuloRequest);

                   string stringResult = client.UploadString(url.AbsoluteUri, "POST", json);

                   response = JsonConvert.DeserializeObject<List<ArticuloBodega>>(stringResult);
               }
           });

            return response;
        }
    }
}


