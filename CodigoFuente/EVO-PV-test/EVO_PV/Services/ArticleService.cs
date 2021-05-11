using EVO_PV.Models.ArticlesApi;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Utilities;
using EVO_PV.Models.DTOs.ArticlesApi;
using EVO_PV.Models.ArticulosApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;
using EVO_PV.Models.ArticuloApi;

namespace EVO_PV.Services
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 30-Dic/2019
    /// Descripción      : Esta clase implementa el llamado a las apis de los artículos
    /// </summary>
    class ArticleService : Mapper
    {
        #region Constructores

        public ArticleService()
        {

        }
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Obtiene los artículos por código de la bodega
        /// </summary>
        /// <param name="from">Desde</param>
        /// <param name="to">Hasta</param>
        /// <param name="whsCode">Código almacen</param>
        /// <returns>Objeto de negocio tipo paginación artículos</returns>
        public async Task<BOPaginationArticle> GetArticlesByWhsCodeSale(int from, int to, string whsCodeFactory, int typeOrderId)
        {           



            try
            {
                ObtenerTodosArticulosResponse obtenerTodosArticulosResponse = null;
                BOPaginationArticle bOPaginationArticles = new BOPaginationArticle() ;

                AppConfiguration appConfiguration = new AppConfiguration();

                string codigoPuntoVenta = appConfiguration.AppSettings["CODIGO_PUNTO_VENTA"].ToString();

                using (WebClient client = new WebClient())
                {
                    whsCodeFactory = string.Empty == whsCodeFactory || whsCodeFactory == null ? "COMPRAS" : whsCodeFactory;
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + $"articulos/bodega?desde={from}&hasta={to}&whsCodePuntoVenta={codigoPuntoVenta}&whsCodePlanta={whsCodeFactory}&tipoSolicitud={typeOrderId}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    obtenerTodosArticulosResponse = JsonConvert.DeserializeObject<ObtenerTodosArticulosResponse>(HtmlResult);

                    bOPaginationArticles = this.mapper.Map<ObtenerTodosArticulosResponse, BOPaginationArticle>(obtenerTodosArticulosResponse);
                }



                return bOPaginationArticles;
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
        /// Obtiene los estados de los artículos
        /// </summary>       
        /// <returns>Lista de objetos de negocio tipo BOStateArticle</returns>
        public async Task<List<BOActions>> GetActions()
        {

            try
            {
                List<AccionResponse> accionResponses = null;

                List<BOActions> bOActions = null;

                using (WebClient client = new WebClient())
                {
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "articulos/accion");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    accionResponses = JsonConvert.DeserializeObject<List<AccionResponse>>(HtmlResult);
                    bOActions = this.mapper.Map<List<AccionResponse>, List<BOActions>>(accionResponses);
                }

                return bOActions;
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
        /// Obtiene los estados de los artículos
        /// </summary>       
        /// <returns>Lista de objetos de negocio tipo BOStateArticle</returns>
        public async Task<List<BOPackage>> GetPackages()
        {

            try
            {
                List<EmpaqueResponse> empaqueResponse = null;

                List<BOPackage> bOPackage = null;

                using (WebClient client = new WebClient())
                {
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "articulos/empaques");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    empaqueResponse = JsonConvert.DeserializeObject<List<EmpaqueResponse>>(HtmlResult);
                    bOPackage = this.mapper.Map<List<EmpaqueResponse>, List<BOPackage>>(empaqueResponse);
                }

                return bOPackage;
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
        /// Obtiene los estados de los artículos
        /// </summary>       
        /// <returns>Lista de objetos de negocio tipo BOStateArticle</returns>
        public async Task<List<BOStateArticle>> GetStatesArticles()
        {

            try
            {
                List<EstadoArticuloResponse> estadosArticuloResponse = null;

                List<BOStateArticle> bOStatesArticle = null;

                using (WebClient client = new WebClient())
                {                   
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + "articulos/obtenerTodosEstados");
                    client.UseDefaultCredentials = true;                    
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url);
                    estadosArticuloResponse = JsonConvert.DeserializeObject<List<EstadoArticuloResponse>>(HtmlResult);
                    bOStatesArticle = this.mapper.Map<List<EstadoArticuloResponse>, List<BOStateArticle>>(estadosArticuloResponse);
                }

                return bOStatesArticle;
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
        public List<BOArticle> GetArticlesSearch(BOSearchArticleRequest bOSearchArticleRequest)
        {
            try
            {
                Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "articulos/bodega/buscar");

                BuscarArticuloRequest buscarArticuloRequest = this.mapper.Map<BOSearchArticleRequest, BuscarArticuloRequest>(bOSearchArticleRequest);

                List<ArticuloResponse> articulosResponse = null;

                List<BOArticle> bOArticles = null;

                using (WebClient client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;

                    string json = JsonConvert.SerializeObject(buscarArticuloRequest);

                    string stringResult = client.UploadString(url.AbsoluteUri, "POST", json);

                    articulosResponse = JsonConvert.DeserializeObject<List<ArticuloResponse>>(stringResult);
                }

                bOArticles = this.mapper.Map<List<ArticuloResponse>, List<BOArticle>>(articulosResponse);

                return bOArticles;
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
        public async Task<List<BOArticleReceive>> GetArticlesToBeReceive(string DeliveryId)
        {
            try
            {
                Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + $"articulos/recepcion?id={DeliveryId}");
                List<ArticuloRecepcionResponse> response = null;
                List<BOArticleReceive> bOArticles = null;

                using (WebClient client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;

                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    response = JsonConvert.DeserializeObject<List<ArticuloRecepcionResponse>>(HtmlResult);
                }

                bOArticles = this.mapper.Map<List<ArticuloRecepcionResponse>, List<BOArticleReceive>>(response);

                return bOArticles;
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
