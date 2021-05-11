using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Models.OrderListApi;
using EVO_PV.Utilities;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PV.Services
{
    public class OrderListService : Mapper
    {
        #region Constructores

        public OrderListService()
        {

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
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + $"pedidos?desde={from}&hasta={to}&whsCode={whsCode.ToString()}");
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
        /// Obtiene el detalle de un pedido por id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Objeto de negocio Con el detalle del pedido</returns>
        public async Task<BOOrderListDetails> GetOrderListById(int id)
        {

            try
            {
                ConsultaPedidoResponse consultaPedidoResponse = null;
                BOOrderListDetails bOOrderListDetails = null;

                using (WebClient client = new WebClient())
                {                    
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + $"pedidos/consulta?id={id}");
                    client.UseDefaultCredentials = true;
                    
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    consultaPedidoResponse = JsonConvert.DeserializeObject<ConsultaPedidoResponse>(HtmlResult);
                    bOOrderListDetails = this.mapper.Map<ConsultaPedidoResponse, BOOrderListDetails>(consultaPedidoResponse);

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
        public async Task<BOOrderListPreview> GetOrderListDetailsById(int id)
        {
            try
            {
                ObtenerPedidoResponse obtenerPedidoResponse = null;
                BOOrderListPreview bOOrderListPreview = null;

                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + $"pedidos/obtener?id={id}");
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
        public bool SetOrderRequest(BOOrderRequest bOOrderRequest)
        {
            try
            {
                Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + "pedidos");

                bool response = false;

                using (var client = new WebClient())
                {
                    client.UseDefaultCredentials = true;                    

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;

                    PedidoRequest pedidoRequest = this.mapper.Map<BOOrderRequest, PedidoRequest>(bOOrderRequest);

                    string json = JsonConvert.SerializeObject(pedidoRequest);

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
        /// Actualizar pedido con Id
        /// </summary>
        /// <param name="bOOrderEditRequest"></param>
        /// <returns></returns>
        public bool SetOrderEditRequest(BOOrderEditRequest bOOrderEditRequest)
        {

            try
            {
                Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + "pedidos/actualizar");

                bool response = false;

                using (var client = new WebClient())
                {
                    client.UseDefaultCredentials = true;
                    

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;

                    PedidoIdRequest pedidoIdRequest = this.mapper.Map<BOOrderEditRequest, PedidoIdRequest>(bOOrderEditRequest);

                    string json = JsonConvert.SerializeObject(pedidoIdRequest);

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
        /// Retorna un booleano si existen 1 solicitud de pedido en estado "Borrador" de este cliente a esta planta 
        /// </summary>
        /// <param name="bOGetOrderErasedRequest">Contiene el código del punto de venta y la planta </param>
        /// <returns></returns>
        public bool GetStateErasedOrderRequestFactory(BOGetOrderErasedRequest bOGetOrderErasedRequest)
        {

            try
            {
                Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + "pedidos/borrador");

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
        public bool ExistRequestFactoryErased(string codePointSale)
        {

            try
            {
                bool response = false;

                using (WebClient client = new WebClient())
                {
                    client.UseDefaultCredentials = true;
                    
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + $"pedidos/solicitud/borradores?codigoPuntoVenta={codePointSale}");
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
