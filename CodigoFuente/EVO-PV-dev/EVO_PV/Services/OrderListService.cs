using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Models.DTOs.PedidosApi;
using EVO_PV.Models.OrderListApi;
using EVO_PV.Resources.Dictionaries;
using EVO_PV.Utilities;
using Newtonsoft.Json;
using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PV.Services
{
    public class OrderListService : Mapper
    {
        #region Atributos
        private AppConfiguration appConfiguration = null;
        private AuditService auditService;
        private Notification notification;
        #endregion

        #region Constructores

        public OrderListService()
        {
            appConfiguration = new AppConfiguration();
            this.notification = new Notification();

        }
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Obtiene los Pedidos de un punto de venta
        /// </summary>
        /// <param name="from">Desde</param>
        /// <param name="to">Hasta</param>
        /// <param name="whsCode">Código almacen</param>
        /// <returns>Objeto de negocio tipo paginación artículos</returns>
        public async Task<BOOrderList> GetOrderListByWhsCode(int from, int to, string whsCode)
        {

            try
            {
                ObtenerTodosPedidosResponse obtenerTodosPedidosResponse = null;
                BOOrderList bOOrderList = null;

                using (WebClient client = new WebClient())
                {
                    AppConfiguration appConfiguration = new AppConfiguration();

                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();

                    Uri url = new Uri(domain + $"pedidos?desde={from}&hasta={to}&whsCode={whsCode.ToString()}");
                    //Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"pedidos?desde={from}&hasta={to}&whsCode={whsCode.ToString()}");
                    client.UseDefaultCredentials = true;

                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    obtenerTodosPedidosResponse = JsonConvert.DeserializeObject<ObtenerTodosPedidosResponse>(HtmlResult);
                    bOOrderList = this.mapper.Map<ObtenerTodosPedidosResponse, BOOrderList>(obtenerTodosPedidosResponse);
                }

                return bOOrderList;
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
        /// Obtiene los Pedidos de un punto de venta
        /// </summary>
        /// <param name="from">Desde</param>
        /// <param name="to">Hasta</param>
        /// <param name="whsCode">Código almacen</param>
        /// <returns>Objeto de negocio tipo paginación artículos</returns>
        public async Task<List<BOStateArticle>> GetStates()
        {

            try
            {
                List<ObtenerEstadoPedidoResponse> obtenerEstadoPedidoResponse = null;
                List<BOStateArticle> bOStateArticle = null;

                using (WebClient client = new WebClient())
                {
                    AppConfiguration appConfiguration = new AppConfiguration();

                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();

                    Uri url = new Uri(domain + "pedidos/estados");

                    //Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "pedidos/estados");
                    client.UseDefaultCredentials = true;

                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    obtenerEstadoPedidoResponse = JsonConvert.DeserializeObject<List<ObtenerEstadoPedidoResponse>>(HtmlResult);
                    bOStateArticle = this.mapper.Map<List<ObtenerEstadoPedidoResponse>, List<BOStateArticle>>(obtenerEstadoPedidoResponse);
                }

                return bOStateArticle;
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
        /// Obtiene los Pedidos de un punto de venta en estado borrador
        /// </summary>
        /// <returns>Objeto de negocio tipo solicitudes</returns>
        public async Task<List<BORegisterorderlist>> GetOrderListForDraft(string whsCode)
        {

            try
            {
                List<ObtenerSolicitudPedidoBorradorResponse> obtenerSolicitudPedidoBorradorResponse = null;
                List<BORegisterorderlist> bORegisterorderlist = null;

                using (WebClient client = new WebClient())
                {
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri(domain + $"pedidos/estado/borrador?solicitudPara={whsCode.ToString()}");
                    client.UseDefaultCredentials = true;

                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    obtenerSolicitudPedidoBorradorResponse = JsonConvert.DeserializeObject<List<ObtenerSolicitudPedidoBorradorResponse>>(HtmlResult);
                    bORegisterorderlist = this.mapper.Map<List<ObtenerSolicitudPedidoBorradorResponse>, List<BORegisterorderlist>>(obtenerSolicitudPedidoBorradorResponse);
                }

                return bORegisterorderlist;
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
        /// Obtiene los tipos de pedidos
        /// </summary>
        /// <returns>Obtiene los tipos de pedidos</returns>
        public async Task<List<BOOrderType>> GetOrderTypes()
        {

            try
            {
                List<ObtenerTipoSolicitudPedidoResponse> oObtenerTipoSolicitudPedidoResponse = null;
                List<BOOrderType> bOOrderType = null;

                using (WebClient client = new WebClient())
                {
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri(domain + $"pedidos/tipos/solicitud");
                    client.UseDefaultCredentials = true;

                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    oObtenerTipoSolicitudPedidoResponse = JsonConvert.DeserializeObject<List<ObtenerTipoSolicitudPedidoResponse>>(HtmlResult);
                    bOOrderType = this.mapper.Map<List<ObtenerTipoSolicitudPedidoResponse>, List<BOOrderType>>(oObtenerTipoSolicitudPedidoResponse);
                }

                return bOOrderType;
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
        /// Obtiene el detalle de un pedido por id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Objeto de negocio Con el detalle del pedido</returns>
        public async Task<List<BOReason>> GetReasons()
        {

            try
            {
                List<MotivoResponse> motivoResponse = null;
                List<BOReason> bOReason = null;

                using (WebClient client = new WebClient())
                {
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri(domain + $"motivos?procesoId=5");
                    client.UseDefaultCredentials = true;

                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    motivoResponse = JsonConvert.DeserializeObject<List<MotivoResponse>>(HtmlResult);
                    bOReason = this.mapper.Map<List<MotivoResponse>, List<BOReason>>(motivoResponse);
                }

                return bOReason;
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
        /// Obtiene el detalle de un pedido por id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Objeto de negocio Con el detalle del pedido</returns>
        public async Task<BOOrderListDetails> GetOrderListById(int id)
        {

            try
            {
                PedidoConsultaResponse consultaPedidoResponse = null;
                BOOrderListDetails bOOrderListDetails = null;

                using (WebClient client = new WebClient())
                {
                    string domain = appConfiguration.AppSettings["API_EVO_PV"].ToString();
                    Uri url = new Uri(domain + $"pedidos/consulta/pedido?pedidoId={id}");
                    client.UseDefaultCredentials = true;
                    
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    consultaPedidoResponse = JsonConvert.DeserializeObject<PedidoConsultaResponse>(HtmlResult);
                    bOOrderListDetails = this.mapper.Map<PedidoConsultaResponse, BOOrderListDetails>(consultaPedidoResponse);

                }

                return bOOrderListDetails;
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
        /// Obtiene el detalle de un pedido por id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Objeto de negocio Con el detalle del pedido</returns>
        public bool CancelOrder(int id, int idReason)
        {

            try
            {
                string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                Uri url = new Uri(domain + "pedidos/pedido/cancelar");
                this.auditService = new AuditService();

                this.auditService.SetAudit(new BOAudit()
                {
                    Action = "Cancelación de orden",
                    Parameters = $" id = { id } , idReason = {idReason} "
                });

                bool response = false;

                using (var client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;

                    CancelarPedidoRequest cancelarPedidoRequest = new CancelarPedidoRequest();
                    cancelarPedidoRequest.MotivoId = idReason;
                    cancelarPedidoRequest.PedidoId = id;

                    string json = JsonConvert.SerializeObject(cancelarPedidoRequest);

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

        /// <summary>
        /// Obtiene el detalle de un pedido por id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Objeto de negocio Con el detalle del pedido</returns>
        public async Task<BOOrderListPreview> GetOrderListDetailsById(int id)
        {
            try
            {
                ObtenerPedidoResponse obtenerPedidoResponse = null;
                BOOrderListPreview bOOrderListPreview = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();
                    Uri url = new Uri(domain + $"pedidos/obtener?id={id}");
                    client.UseDefaultCredentials = true;
                    
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    obtenerPedidoResponse = JsonConvert.DeserializeObject<ObtenerPedidoResponse>(HtmlResult);
                    bOOrderListPreview = this.mapper.Map<ObtenerPedidoResponse, BOOrderListPreview>(obtenerPedidoResponse);
                }

                return bOOrderListPreview;
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
        /// Guarda el pedido creado en solicitud de pedido
        /// </summary>
        /// <param name="bOOrderRequest"></param>
        /// <returns></returns>
        public BOPedidoRespuesta SetOrderRequest(BOOrderRequest bOOrderRequest)
        {
            try
            {
                BOPedidoRespuesta bOStateArticle = new BOPedidoRespuesta();
                AppConfiguration appConfiguration = new AppConfiguration();

                string domain = appConfiguration.AppSettings["API_EVO_PV"].ToString();

                Uri url = new Uri(domain + "pedidos");

                //Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + "pedidos");

                string response = "false";

                this.auditService = new AuditService();

                this.auditService.SetAudit(new BOAudit()
                {
                    Action = "Se guarda el pedido creado en solicitud de pedido",
                    Parameters = $" Pedido = {JsonConvert.SerializeObject(bOOrderRequest)}"
                });

                using (var client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;

                    PedidoRequest pedidoRequest = this.mapper.Map<BOOrderRequest, PedidoRequest>(bOOrderRequest);

                    string json = JsonConvert.SerializeObject(pedidoRequest);

                    response = client.UploadString(url.AbsoluteUri, "POST", json);
                    PedidoRespuestaResponse obtenerEstadoPedidoResponse = JsonConvert.DeserializeObject<PedidoRespuestaResponse>(response);
                    bOStateArticle = this.mapper.Map<PedidoRespuestaResponse, BOPedidoRespuesta>(obtenerEstadoPedidoResponse);
                }

                return bOStateArticle;
            }            
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Actualizar pedido con Id
        /// </summary>
        /// <param name="bOOrderEditRequest"></param>
        /// <returns></returns>
        public string SetOrderEditRequestNotCraft(BOOrderEditRequest bOOrderEditRequest)
        {

            try
            {
                string domain = appConfiguration.AppSettings["API_EVO"].ToString();

                Uri url = new Uri(domain + "pedidos/pedido/editar");

                string response = "false";

                this.auditService = new AuditService();

                this.auditService.SetAudit(new BOAudit()
                {
                    Action = "Se edita el pedido",
                    Parameters = $"{JsonConvert.SerializeObject(bOOrderEditRequest)}"
                });

                using (var client = new WebClient())
                {
                    client.UseDefaultCredentials = true;


                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;

                    EditarPedidoRequest pedidoIdRequest = this.mapper.Map<BOOrderEditRequest, EditarPedidoRequest>(bOOrderEditRequest);

                    string json = JsonConvert.SerializeObject(pedidoIdRequest);

                    response = client.UploadString(url.AbsoluteUri, "POST", json);
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

        /// <summary>
        /// Actualizar pedido con Id
        /// </summary>
        /// <param name="bOOrderEditRequest"></param>
        /// <returns></returns>
        public BOPedidoRespuesta SetOrderEditRequest(BOOrderEditRequest bOOrderEditRequest)
        {

            try
            {
                BOPedidoRespuesta bOStateArticle = new BOPedidoRespuesta();
                AppConfiguration appConfiguration = new AppConfiguration();

                string domain = appConfiguration.AppSettings["API_EVO_PV"].ToString();

                Uri url = new Uri(domain + "pedidos/actualizar");

                //Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + "pedidos/actualizar");

                string response = "false";

                this.auditService = new AuditService();

                this.auditService.SetAudit(new BOAudit()
                {
                    Action = "Se edita el pedido",
                    Parameters = $"{JsonConvert.SerializeObject(bOOrderEditRequest)}"
                });
                using (var client = new WebClient())
                {
                    client.UseDefaultCredentials = true;
                    

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;

                    PedidoIdRequest pedidoIdRequest = this.mapper.Map<BOOrderEditRequest, PedidoIdRequest>(bOOrderEditRequest);

                    string json = JsonConvert.SerializeObject(pedidoIdRequest);

                    response = client.UploadString(url.AbsoluteUri, "POST", json);
                    PedidoRespuestaResponse obtenerEstadoPedidoResponse = JsonConvert.DeserializeObject<PedidoRespuestaResponse>(response);
                    bOStateArticle = this.mapper.Map<PedidoRespuestaResponse, BOPedidoRespuesta>(obtenerEstadoPedidoResponse);
                }

                return bOStateArticle;
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
        /// Retorna un booleano si existen 1 solicitud de pedido en estado "Borrador" de este cliente a esta planta 
        /// </summary>
        /// <param name="bOGetOrderErasedRequest">Contiene el código del punto de venta y la planta </param>
        /// <returns></returns>
        public bool GetStateErasedOrderRequestFactory(BOGetOrderErasedRequest bOGetOrderErasedRequest)
        {

            try
            {
                AppConfiguration appConfiguration = new AppConfiguration();

                string domain = appConfiguration.AppSettings["API_EVO_PV"].ToString();

                Uri url = new Uri(domain + "pedidos/borrador");

                //Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + "pedidos/borrador");

                bool response = false;

                using (var client = new WebClient())
                {
                    client.UseDefaultCredentials = true;                    

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;

                    ObtenerPedidoBorradorRequest obtenerPedidoBorradorRequest = this.mapper.Map<BOGetOrderErasedRequest, ObtenerPedidoBorradorRequest>(bOGetOrderErasedRequest);

                    string json = JsonConvert.SerializeObject(obtenerPedidoBorradorRequest);

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

        /// <summary>
        /// Este método retorna si existen solicitud de pedidos en estado "Borrador" en todas las plantas
        /// </summary>       
        /// <param name="codePointSale">PB-PRA</param>
        /// <returns>Booleano</returns>
        public bool ExistRequestFactoryErased(string codePointSale, string codePointSaleFor)
        {

            try
            {
                bool response = false;

                using (WebClient client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    AppConfiguration appConfiguration = new AppConfiguration();

                    string domain = appConfiguration.AppSettings["API_EVO"].ToString();

                    Uri url = new Uri(domain + $"pedidos/realizar?codigoBodegaDe={codePointSale}&prefijoBodega={codePointSaleFor}");
                    //Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"pedidos/realizar?codigoBodegaDe={codePointSale}&prefijoBodega={codePointSaleFor}");
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = client.DownloadString(url);
                    response = JsonConvert.DeserializeObject<bool>(HtmlResult);
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
        #endregion

    }
}
