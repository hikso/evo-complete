/*
 * API de Configuración General
 *
 * API de configuración general del sistema EVO
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com.co
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using EVO_WebApi.Attributes;
using EVO_WebApi.Models.ConfigApi;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EVO_WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]  
    public class ConfigApiController : ControllerBase
    {
        /// <summary>
        /// Retorna la versión actual del sistema EVO.
        /// </summary>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/config/obtenerversionactual")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerVersionActual")]
        [SwaggerResponse(statusCode: 200, type: typeof(VersionResponse), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerVersionActual()
        {
            string versionActual = GetType().Assembly.GetName().Version.ToString();

            VersionResponse versionResponse = new VersionResponse()
            {
                Version = versionActual
            };

            return new ObjectResult(versionResponse);
        }
    }
}