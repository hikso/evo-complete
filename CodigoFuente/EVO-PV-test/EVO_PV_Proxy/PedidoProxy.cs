using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Utils;
using EVO_PV_Proxy.Models.PedidoApi;
using EVO_PV_Proxy.Models.PedidoAPI;
using EVO_PV_Proxy.Models.PedidosApi;
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
    public class PedidoProxy : Automapper
    {
        public string ObtenerNumeroPedido(NumeroPedido numeroPedidos)
        {
            AppConfiguration appConfig = new AppConfiguration();

            Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos/numeropedido");

            NumeroPedidoRequest numeroPedidoRequest = this.iMapper.Map<NumeroPedido, NumeroPedidoRequest>(numeroPedidos);

            string data = JsonConvert.SerializeObject(numeroPedidoRequest);

            string numeroPedido = string.Empty;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (var client = new WebClient { UseDefaultCredentials = true })
               {
                   client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                   client.Encoding = Encoding.UTF8;

                   string stringResult = client.UploadString(url.AbsoluteUri, "POST", data);

                   numeroPedido = JsonConvert.DeserializeObject<string>(stringResult);
               }
           });

            return numeroPedido;
        }

        public string ActualizarPedido(Pedido pedido)
        {
            AppConfiguration appConfig = new AppConfiguration();

            Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos/actualizar");

            PedidoRequest pedidoRequest = this.iMapper.Map<Pedido, PedidoRequest>(pedido);

            string data = JsonConvert.SerializeObject(pedidoRequest);

            string respuesta = string.Empty;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (var client = new WebClient { UseDefaultCredentials = true })
               {
                   client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                   client.Encoding = Encoding.UTF8;

                   respuesta = client.UploadString(url.AbsoluteUri, "POST", data);
               }
           });

            return respuesta;
        }

        /// <summary>
        /// Cancelar un pedido
        /// </summary>
        /// <param name="body">Solicitud de cancelación de pedido</param>
        /// <response>bool</response>
        public bool CancelarPedido(BOCancelarPedidoRequest cancelar)
        {
            CancelarPedidoRequest cancelarRequest = this.iMapper.Map<BOCancelarPedidoRequest, CancelarPedidoRequest>(cancelar);

            AppConfiguration appConfig = new AppConfiguration();

            Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos/pedido/cancelar");

            string data = JsonConvert.SerializeObject(cancelarRequest);

            bool respuesta = false;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
            {
                using (var client = new WebClient { UseDefaultCredentials = true })
                {
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    string stringResult = client.UploadString(url.AbsoluteUri, "POST", data);

                    respuesta = JsonConvert.DeserializeObject<bool>(stringResult);
                }
            });

            return respuesta;
        }


        /// <summary>
        /// Editar un pedido
        /// </summary>
        /// <param name="boPedido">Solicitud de edición de pedido</param>
        /// <response>Boolean</response>
        public bool EditarPedido(BOEditarPedidoRequest boPedido)
        {
            //Ejemplo
            EditarPedidoRequest pedidoRequest = this.iMapper.Map<BOEditarPedidoRequest, EditarPedidoRequest>(boPedido);

            AppConfiguration appConfig = new AppConfiguration();

            Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos/pedido/editar");

            string data = JsonConvert.SerializeObject(pedidoRequest);

            bool respuesta = false;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
            {
                using (var client = new WebClient { UseDefaultCredentials = true })
                {
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    string stringResult = client.UploadString(url.AbsoluteUri, "POST", data);

                    respuesta = JsonConvert.DeserializeObject<bool>(stringResult);
                }
            });

            return respuesta;
        }

        /// <summary>
        /// obtener una serie de un pedido
        /// </summary>
        /// <param name="codigoBodega">Solicitud de edición de pedido</param>
        /// <response>string</response>
        public BOSerieResponse ObtenerSerie(string codigoBodega)
        {
            SerieResponse serie = null;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
            {
                using (WebClient client = new WebClient())
                {
                    AppConfiguration appConfig = new AppConfiguration();

                    Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos/series");
                    client.QueryString.Add("codigoBodega", codigoBodega);
                    client.UseDefaultCredentials = true;
                    var HtmlResult = Encoding.UTF8.GetString(client.DownloadData(url.AbsoluteUri));
                    serie = JsonConvert.DeserializeObject<SerieResponse>(HtmlResult);
                }
            });

            return this.iMapper.Map<SerieResponse, BOSerieResponse>(serie);

                
        }

        /// <summary>
        /// Retorna el detalle del pedido
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <response>BOPedidoConsultaResponse</response>
        public BOPedidoConsultaResponse ObtenerConsultaPedido(int pedidoId)
        {
            PedidoConsultaResponse pedido = null;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
            {
                using (WebClient client = new WebClient())
                {
                    AppConfiguration appConfig = new AppConfiguration();

                    Uri url = new Uri(appConfig.AppSettings["API_EVO"] + $"pedidos/consulta/pedido?pedidoId={pedidoId}");
                    client.UseDefaultCredentials = true;
                    string HtmlResult = Encoding.UTF8.GetString(client.DownloadData(url.AbsoluteUri));
                    pedido = JsonConvert.DeserializeObject<PedidoConsultaResponse>(HtmlResult);
                }
            });

            return this.iMapper.Map<PedidoConsultaResponse,BOPedidoConsultaResponse>(pedido);
        }

        /// <summary>
        /// Estado del botón de solicitud de pedido 
        /// </summary>
        /// <param name="codigoCliente"></param>       
        /// <returns>Retorna un booleano que indica si se habilita o no el botón de la solicitud del pedido</returns>
        public bool HabilitarSolicitudPedido(string codigoCliente)
        {
            bool habilitar = false;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (WebClient client = new WebClient())
               {
                   AppConfiguration appConfig = new AppConfiguration();

                   Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos/solicitud/habilitar");
                   client.QueryString.Add("codigoCliente", codigoCliente);
                   client.UseDefaultCredentials = true;
                   var HtmlResult = Encoding.UTF8.GetString(client.DownloadData(url.AbsoluteUri));
                   habilitar = JsonConvert.DeserializeObject<bool>(HtmlResult);
               }
           });

            return habilitar;
        }

        /// <summary>
        /// Obtiene todos los pedidos en distribución
        /// </summary>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>    
        /// <returns>Obejto de tipo ObtenerTodosPedidosDistribucion</returns>
        public ObtenerTodosPedidosDistribucion ObtenerTodosPedidosADistribucion(int desde, int hasta)
        {
            ObtenerTodosPedidosDistribucionResponse result = new ObtenerTodosPedidosDistribucionResponse();

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (WebClient client = new WebClient())
               {
                   AppConfiguration appConfig = new AppConfiguration();

                   Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos/distribucion");
                   client.QueryString.Add("desde", desde.ToString());
                   client.QueryString.Add("hasta", hasta.ToString());
                   client.UseDefaultCredentials = true;
                   var HtmlResult = Encoding.UTF8.GetString(client.DownloadData(url.AbsoluteUri));
                   result = JsonConvert.DeserializeObject<ObtenerTodosPedidosDistribucionResponse>(HtmlResult);
               }
           });

            return this.iMapper.Map<ObtenerTodosPedidosDistribucionResponse, ObtenerTodosPedidosDistribucion>(result);
        }

        /// <summary>
        /// Obtiene todos los pedidos creados en el sistema
        /// </summary>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <param name="whscode"></param>
        /// <returns>Encabezado y detalle del pedido</returns>
        public ObtenerPedidos ObtenerTodosPedidos(int desde, int hasta, string whscode)
        {

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            ObtenerTodosPedidosResponse result = null;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (WebClient client = new WebClient())
               {
                   AppConfiguration appConfig = new AppConfiguration();

                   Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos");
                   client.QueryString.Add("desde", desde.ToString());
                   client.QueryString.Add("hasta", hasta.ToString());
                   client.QueryString.Add("whscode", whscode);
                   client.UseDefaultCredentials = true;
                   var HtmlResult = Encoding.UTF8.GetString(client.DownloadData(url.AbsoluteUri));
                   result = JsonConvert.DeserializeObject<ObtenerTodosPedidosResponse>(HtmlResult);
               }
           });

            return this.iMapper.Map<ObtenerTodosPedidosResponse, ObtenerPedidos>(result);

        }

        public Pedido ObtenerPedidoPorId(int id)
        {
            Models.PedidoApi.ObtenerPedidoResponse obtenerPedidoResponse = null;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (WebClient client = new WebClient())
               {
                   AppConfiguration appConfig = new AppConfiguration();

                   Uri url = new Uri(appConfig.AppSettings["API_EVO"] + $"pedidos/obtener?id={id}");
                   client.UseDefaultCredentials = true;
                   client.Encoding = Encoding.UTF8;
                   var HtmlResult = client.DownloadString(url.AbsoluteUri);
                   obtenerPedidoResponse =
                       JsonConvert.DeserializeObject<Models.PedidoApi.ObtenerPedidoResponse>(HtmlResult);
               }
           });

            Pedido pedido = this.iMapper.Map<Models.PedidoApi.ObtenerPedidoResponse, Pedido>(obtenerPedidoResponse);

            return pedido;

        }

        /// <summary>
        /// Obtiene todos los estados de un pedido
        /// </summary>
        /// <returns>Estado del pedido</returns>
        public List<EstadoPedido> ObtenerTodosEstadosPedido()
        {
            using (WebClient client = new WebClient())
            {
                AppConfiguration appConfig = new AppConfiguration();

                Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos/estados");
                client.UseDefaultCredentials = true;
                var HtmlResult = client.DownloadString(url.AbsoluteUri);
                return JsonConvert.DeserializeObject<List<EstadoPedido>>(HtmlResult);
            }
        }

        /// <summary>
        /// Obtiene la cantidad de pedidos x estado
        /// </summary>
        /// <returns>Numero total de pedidos por cada estado</returns>
        public List<EstadoPedido> ObtenerCantidadxEstadosPedido()
        {
            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            var HtmlResult = string.Empty;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (WebClient client = new WebClient())
               {
                   AppConfiguration appConfig = new AppConfiguration();

                   Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos/cantidadxestados");
                   client.UseDefaultCredentials = true;
                   client.Encoding = Encoding.UTF8;
                   HtmlResult = client.DownloadString(url.AbsoluteUri);
               }

           });

            return JsonConvert.DeserializeObject<List<EstadoPedido>>(HtmlResult);

        }

        public bool ObtenerPedidoBorradorRequest(ObtenerPedidoBorrador obtenerPedidoBorrador)
        {
            bool respuesta = false;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (WebClient client = new WebClient())
               {
                   AppConfiguration appConfig = new AppConfiguration();

                   Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos/borrador");

                   ObtenerPedidoBorradorRequest obtenerPedidoBorradorRequest = this.iMapper.Map<ObtenerPedidoBorrador, ObtenerPedidoBorradorRequest>(obtenerPedidoBorrador);

                   client.UseDefaultCredentials = true;

                   string data = JsonConvert.SerializeObject(obtenerPedidoBorradorRequest);

                   client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                   client.Encoding = Encoding.UTF8;

                   respuesta = client.UploadString(url.AbsoluteUri, "POST", data) == "true";
               }
           });

            return respuesta;

        }

        public string CrearPedido(Pedido pedido)
        {
            //Ejemplo
            PedidoRequest pedidoRequest = this.iMapper.Map<Pedido, PedidoRequest>(pedido);

            AppConfiguration appConfig = new AppConfiguration();

            Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos");

            string data = JsonConvert.SerializeObject(pedidoRequest);

            string respuesta = string.Empty;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (var client = new WebClient { UseDefaultCredentials = true })
               {
                   client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                   respuesta = client.UploadString(url.AbsoluteUri, "POST", data);
               }
           });

            return respuesta;

        }

        public async Task<ConsultaPedidoRespuesta> ObtenerConsultaPedidoId(int id)
        {
            ConsultaPedidoResponse consultaPedidoResponse = null;
            ConsultaPedidoRespuesta consultaPedidoRespuesta = null;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            await WindowsIdentity.RunImpersonated(currentUser.AccessToken, async () =>
            {
                using (WebClient client = new WebClient())
                {
                    AppConfiguration appConfig = new AppConfiguration();

                    Uri url = new Uri(appConfig.AppSettings["API_EVO"] + $"pedidos/consulta?id={id}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    consultaPedidoResponse = JsonConvert.DeserializeObject<ConsultaPedidoResponse>(HtmlResult);
                    consultaPedidoRespuesta = this.iMapper.Map<ConsultaPedidoResponse, ConsultaPedidoRespuesta>(consultaPedidoResponse);
                }
            });

            return consultaPedidoRespuesta;
        }

        /// <summary>
        /// Verifica que actualmente existan solicitudes en estado borrador en cada planta
        /// </summary>
        /// <param name="desde"></param>       
        /// <returns>Booleano/returns>
        public bool ExisteSolicitudPlantasBorrador(string codigoPuntoVenta)
        {
            bool respuesta = false;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (WebClient client = new WebClient())
               {
                   AppConfiguration appConfig = new AppConfiguration();

                   Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "pedidos/solicitud/borradores");
                   client.QueryString.Add("codigoPuntoVenta", codigoPuntoVenta);
                   client.UseDefaultCredentials = true;
                   var HtmlResult = Encoding.UTF8.GetString(client.DownloadData(url.AbsoluteUri));
                   respuesta = JsonConvert.DeserializeObject<bool>(HtmlResult);
               }
           });

            return respuesta;
        }
    }
}
