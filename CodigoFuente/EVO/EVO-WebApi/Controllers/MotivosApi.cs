/*
 * API de Motivos
 *
 * API de administración de Motivos 
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
using EVO_WebApi.Models.MotivosApi;
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
    public class MotivosApiController : ControllerBase
    {
        #region Campos Privados
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private IMapper mapper;
        #endregion

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        public MotivosApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Obtiene motivos de edición asociados a las entregas
        /// </summary>
        /// <param name="procesoId">Indica el id del proceso</param>       
        /// <response code="200">Operación realizada con éxito</response>
        ///TODO:Cambio en yaml del parámetro
        [HttpGet]
        [Route("/api/motivos")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerMotivos")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<MotivoResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerMotivos([FromQuery][Required()]int procesoId)
        {
            logger.Info($"Entró al método ObtenerMotivos en Api Motivos con el parámetro procesoId = {procesoId}");

            try
            {
                BLMotivo bLMotivos = new BLMotivo();

                List<MotivoRespuesta> motivos = bLMotivos.ObtenerMotivos(procesoId);

                List<MotivoResponse> motivosResponse =

                this.mapper.Map<List<MotivoRespuesta>, List<MotivoResponse>>(motivos);

                return Ok(motivosResponse);
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
    }
}