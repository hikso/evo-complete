/*
 * API de Artículos
 *
 * API de administración de Articulos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using AutoMapper;
using EVO_BusinessLogic;
using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_WebApi.Attributes;
using EVO_WebApi.Models.ArticuloApi;
using EVO_WebApi.Models.ArticulosApi;
using EVO_WebApi.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EVO_WebApi.Controllers
{

    /// <summary>
    /// 
    /// </summary>    
    [ApiController]
    [Authorize]
    public class ArticulosApiController : ControllerBase
    {

        #region Campos Privados
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private IMapper mapper;
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Obtiene los artículos en el punto de venta filtrado por código y/o nombre
        /// </summary>
        /// <param name="body">Solicitud de filtro de artículos facturación. Se debe ingresar al menos uno de los criterios del filtro</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpPost]
        [Route("/api/articulos/facturacion/filtrar")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerArticulosFacturacionxFiltro")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ArticuloPuntoVentaResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerArticulosFacturacionxFiltro([FromBody] FiltrarArticulosFacturacionRequest body)
        {
            logger.Info($"Entró al método ObtenerArticulosFacturacionxFiltro en ArticulosApi - EVO-WebApi con los parámetros {JsonConvert.SerializeObject(body)}");

            try
            {
                BOFiltrarArticulosFacturacionRequest bOBody = this.mapper.Map<FiltrarArticulosFacturacionRequest, BOFiltrarArticulosFacturacionRequest>(body);

                BLArticulo bLArticulo = new BLArticulo();

                List<BOArticuloPuntoVentaResponse> boArticulosPuntoVentaResponse = bLArticulo.ObtenerArticulosFacturacionxFiltro(bOBody);

                List<ArticuloPuntoVentaResponse> articulosPuntoVentaResponse =

                this.mapper.Map<List<BOArticuloPuntoVentaResponse>, List<ArticuloPuntoVentaResponse>>(boArticulosPuntoVentaResponse);

                return Ok(boArticulosPuntoVentaResponse);
            }
            catch (EVOException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errores.errGeneral);
            }
        }

        /// <summary>
        /// Obtiene los artículos para el proceso de facturación
        /// </summary>
        /// <param name="codigoPuntoVenta">Indica el código del punto de venta</param>
        /// <param name="identificacionSocio">Indica la identificación del socio de negocio</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/articulos/facturacion")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerArticulosFacturacion")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ArticuloPuntoVentaResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerArticulosFacturacion([FromQuery][Required()] string codigoPuntoVenta, [FromQuery][Required()] string identificacionSocio)
        {
            logger.Info($"Entró al método ObtenerArticulosFacturacion en ArticulosApi - EVO-WebApi con el parámetro codigoCliente =  {codigoPuntoVenta} , identificacionSocio = {identificacionSocio}");

            try
            {
                BLArticulo bLArticulo = new BLArticulo();

                List<BOArticuloPuntoVentaResponse> boArticulosPuntoVentaResponse = bLArticulo.ObtenerArticulosFacturacion(codigoPuntoVenta, identificacionSocio);

                List<ArticuloPuntoVentaResponse> articulosPuntoVentaResponse =

                this.mapper.Map<List<BOArticuloPuntoVentaResponse>, List<ArticuloPuntoVentaResponse>>(boArticulosPuntoVentaResponse);

                return Ok(boArticulosPuntoVentaResponse);
            }
            catch (EVOException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errores.errGeneral);
            }
        }

        /// <summary>
        /// Obtiene los artículos en recepción;
        /// </summary>
        /// <param name="id">Indica el id de la entrega</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/articulos/recepcion")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerArticulosRecepcion")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ArticuloRecepcionResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerArticulosRecepcion([FromQuery][Required()] int id)
        {
            logger.Info($"Entró al método ObtenerArticulosRecepcion en Api Artículos con el parámetro id = {id}");

            try
            {
                BLArticulo bLArticulos = new BLArticulo();

                List<ArticuloRecepcionRespuesta> articulosRecepcionRespuesta = bLArticulos.ObtenerArticulosRecepcion(id);

                List<ArticuloRecepcionResponse> articulosRecepcionResponse =

                this.mapper.Map<List<ArticuloRecepcionRespuesta>, List<ArticuloRecepcionResponse>>(articulosRecepcionRespuesta);

                return Ok(articulosRecepcionResponse);
            }
            catch (EVOException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errores.errGeneral);
            }
        }

        /// <summary>
        /// Obtiene los artículos de una entrega en estado alistamiento
        /// </summary>
        /// <param name="id">Indica el id de la entrega</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/articulos/alistamiento")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerAritculosAlistamiento")]
        [SwaggerResponse(statusCode: 200, type: typeof(DetalleEntregaResponse), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerArticulosAlistamiento([FromQuery][Required] int id)
        {
            logger.Info($"Entró al método ObtenerAritculosAlistamiento en Api Artículos con el parámetro id = {id}");

            try
            {
                BLArticulo bLArticulos = new BLArticulo();

                DetalleEntregaRespuesta detalleEntregaRespuesta = bLArticulos.ObtenerAriticulosAlistamiento(id);

                DetalleEntregaResponse detalleEntregaResponse =

                this.mapper.Map<DetalleEntregaRespuesta, DetalleEntregaResponse>(detalleEntregaRespuesta);

                return Ok(detalleEntregaResponse);
            }
            catch (EVOException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errores.errGeneral);
            }
        }

        /// <summary>
        /// Obtiene todos los Articulos
        /// </summary>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/articulos")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerTodosArticulos")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ArticuloUnicoResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerTodosArticulos()
        {
            logger.Info("Entró al método ObtenerTodosArticulos en Api Artículos sin parámetros");

            try
            {
                BLArticulo bLArticulos = new BLArticulo();

                List<BOArticulo> articulos = bLArticulos.ObtenerTodosArticulos();

                List<ArticuloUnicoResponse> articulosResponse =

                this.mapper.Map<List<BOArticulo>, List<ArticuloUnicoResponse>>(articulos);

                return Ok(articulosResponse);
            }
            catch (EVOException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errores.errGeneral);
            }
        }


        /// <summary>
        /// Obtiene todos los artículos aplicando filtros de búsqueda
        /// </summary>
        /// <param name="body">Solicitud de filtro de Auditoria. Se debe ingresar al menos uno de los criterios del filtro</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpPost]
        [Route("/api/articulos/bodega/filtrar")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerTodosArticulosBodegaxFiltro")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObtenerTodosArticulosResponse), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerTodosArticulosBodegaxFiltro([FromBody] FiltrarArticuloRequest body)
        {
            try
            {
                BLArticulo bLArticulos = new BLArticulo();
                BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

                ObtenerTodosArticulosResponse obtenerTodosArticulosResponse = new ObtenerTodosArticulosResponse();

                string pgTamanhoPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_TABLA);

                if (string.IsNullOrWhiteSpace(pgTamanhoPaginacion))
                {
                    EVOException e = new EVOException(string.Format(errores.errParametroGeneral, pgTamanhoPaginacion));

                    logger.Error(e);

                    throw e;
                }

                int tamanhoPaginacion = 0;

                try
                {
                    tamanhoPaginacion = int.Parse(pgTamanhoPaginacion);
                }
                catch
                {
                    EVOException e = new EVOException(string.Format(errores.errParametroGeneral, pgTamanhoPaginacion));

                    logger.Error(e);

                    throw e;
                }

                obtenerTodosArticulosResponse.TamanhoPaginacion = tamanhoPaginacion;

                List<ObtenerTodosArticulosResponseRegistros> articulosBodegaResponse = new List<ObtenerTodosArticulosResponseRegistros>();

                FiltroArticulo filtroArticulo = this.mapper.Map<FiltrarArticuloRequest, FiltroArticulo>(body);

                List<ArticuloBodega> articulosBodega = bLArticulos.ObtenerTodosArticulosBodegaxFiltro(filtroArticulo);

                int numeroTotalRegistros = 0;

                if (articulosBodega != null)
                {
                    articulosBodegaResponse =
                        this.mapper.Map<List<ArticuloBodega>, List<ObtenerTodosArticulosResponseRegistros>>(articulosBodega);


                    numeroTotalRegistros = bLArticulos.ObtenerConteoTodosRegistrosxFiltro(filtroArticulo);
                }

                obtenerTodosArticulosResponse.NumeroTotalRegistros = numeroTotalRegistros;
                obtenerTodosArticulosResponse.Registros = articulosBodegaResponse;

                return Ok(obtenerTodosArticulosResponse);
            }
            catch (EVOException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errores.errGeneral);
            }
        }

        /// <summary>
        /// Obtiene todos los Articulos por bodega
        /// </summary>
        /// <param name="desde">Indica el número de registro desde el cuál se deben obtener los registros</param>
        /// <param name="hasta">Indica el número de registro hasta el cuál se deben obtener los registros</param>
        /// <param name="whsCodePuntoVenta">Indica el código de la bodega punto de venta</param>
        /// <param name="whsCodePlanta">Indica el código de la bodega punto de planta</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/articulos/bodega")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerTodosArticulosxBodega")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObtenerTodosArticulosResponse), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerTodosArticulosxBodega([FromQuery][Required()] int desde, [FromQuery][Required()] int hasta, [FromQuery][Required()] string whsCodePuntoVenta, [FromQuery][Required()] string whsCodePlanta)
        {
            logger.Info($"Entró al método ObtenerTodosArticulosxBodega en Api Artículos con los parámetros desde={desde}, hasta={hasta} ,whsCodePuntoVenta={whsCodePuntoVenta}, whsCodePlanta={whsCodePlanta}");

            try
            {
                BLArticulo bLArticulos = new BLArticulo();
                BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

                ObtenerTodosArticulosResponse obtenerTodosArticulosResponse = new ObtenerTodosArticulosResponse();

                string pgTamanhoPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_TABLA);

                if (string.IsNullOrWhiteSpace(pgTamanhoPaginacion))
                {
                    EVOException e = new EVOException(string.Format(errores.errParametroGeneral, pgTamanhoPaginacion));

                    logger.Error(e);

                    throw e;
                }

                int tamanhoPaginacion = 0;

                try
                {
                    tamanhoPaginacion = int.Parse(pgTamanhoPaginacion);
                }
                catch
                {
                    EVOException e = new EVOException(string.Format(errores.errParametroGeneral, pgTamanhoPaginacion));

                    logger.Error(e);

                    throw e;
                }

                List<ArticuloBodega> articulosBodega = bLArticulos.ObtenerTodosArticulosxBodega(desde, hasta, whsCodePuntoVenta, whsCodePlanta);

                int numeroTotalRegistros = bLArticulos.ObtenerConteoTodosRegistros(whsCodePuntoVenta, whsCodePlanta);

                obtenerTodosArticulosResponse.NumeroTotalRegistros = numeroTotalRegistros;
                obtenerTodosArticulosResponse.TamanhoPaginacion = tamanhoPaginacion;

                obtenerTodosArticulosResponse.Registros =
                    this.mapper.Map<List<ArticuloBodega>, List<ObtenerTodosArticulosResponseRegistros>>(articulosBodega);

                return Ok(obtenerTodosArticulosResponse);
            }
            catch (EVOException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errores.errGeneral);
            }
        }

        /// <summary>
        /// Obtiene los estados del artículo
        /// </summary>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/articulos/estado")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerTodosEstados")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<EstadoArticuloResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerTodosEstados()
        {
            logger.Info("Entró al método ObtenerTodosEstados en Api Artículos sin parámetros");

            try
            {
                BLArticulo bLArticulos = new BLArticulo();

                List<BOEstadoArticulo> estadosArticulo = bLArticulos.ObtenerTodosEstados();

                List<EstadoArticuloResponse> estadosArticulosResponse =

                this.mapper.Map<List<BOEstadoArticulo>, List<EstadoArticuloResponse>>(estadosArticulo);

                return Ok(estadosArticulosResponse);
            }
            catch (EVOException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errores.errGeneral);
            }
        }

        /// <summary>
        /// Busca un artículo de bodega
        /// </summary>
        /// <param name="body">Solicitud de búsqueda de un artículo de bodega</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpPost]
        [Route("/api/articulos/bodega/buscar")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerArticulosBodega")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ArticuloResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerArticulosBodega([FromBody] BuscarArticuloRequest body)
        {
            try
            {
                BLArticulo bLArticulos = new BLArticulo();

                BuscarArticuloBodegaSolicitud filtroArticulo = this.mapper.Map<BuscarArticuloRequest, BuscarArticuloBodegaSolicitud>(body);

                List<ArticuloBodega> articulosBodega = bLArticulos.ObtenerArticulosBodega(filtroArticulo);

                List<ArticuloResponse> articuloResponse = this.mapper.Map<List<ArticuloBodega>, List<ArticuloResponse>>(articulosBodega);

                return Ok(articuloResponse);
            }
            catch (EVOException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errores.errGeneral);
            }
        }

        /// <summary>
        /// Obtiene los Empaques
        /// </summary>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/articulos/empaques")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerEmpaques")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<EmpaqueResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerEmpaques()
        {
            logger.Info("Entró al método ObtenerEmpaques en EVO_WebApi - Api Artículos sin parámetros");

            try
            {
                BLArticulo bLArticulos = new BLArticulo();

                List<BOEmpaque> empaques = bLArticulos.ObtenerEmpaques();

                List<EmpaqueResponse> empaquesResponse =

                this.mapper.Map<List<BOEmpaque>, List<EmpaqueResponse>>(empaques);

                return Ok(empaquesResponse);
            }
            catch (EVOException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errores.errGeneral);
            }
        }
        #endregion

        #region Contructores
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        public ArticulosApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        #endregion
    }
}