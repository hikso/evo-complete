/*
 * API de Clientes Externos
 *
 * API de administración de Clientes Externos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using AutoMapper;
using EVO_BusinessLogic;
using EVO_BusinessObjects;
using EVO_BusinessObjects.Exceptions;
using EVO_WebApi.Attributes;
using EVO_WebApi.Models.ClientesExternosApi;
using EVO_WebApi.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace EVO_WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>    
    [ApiController]
    [Authorize]
    public class ClientesExternosApiController : ControllerBase
    {

        #region Campos Privados
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private IMapper mapper;
        #endregion

        /// <summary>
        /// Obtiene todos los clientes externos
        /// </summary>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/clientesexternos")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerTodosClientesExternos")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<ObtenerClienteExternoResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerTodosClientesExternos()
        {
            logger.Info($"Entró al método ObtenerTodosClientesExternos");

            try
            {
                BLClienteExterno bLClientesExternos = new BLClienteExterno();

                List<ClienteExterno> clientesExternos = bLClientesExternos.ObtenerTodosClientesExternos();

                List<ObtenerClienteExternoResponse> clientesExternosResponse =

                this.mapper.Map<List<ClienteExterno>, List<ObtenerClienteExternoResponse>>(clientesExternos);

                return Ok(clientesExternosResponse);
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

        #region Contructores
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        public ClientesExternosApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        #endregion
    }
}