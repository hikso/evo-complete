/*
 * API de Bodegas
 *
 * API de administración de Bodegas 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jusuga@digitalcg.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using EVO_PV_BusinessLogic;
using EVO_PV_BusinessObjects;
using EVO_PV_WebApi.Models.BodegasApi;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace EVO_PV_WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary> 
   public class BodegasApiController : BaseController
    { 
        /// <summary>
        /// Obtiene las bodegas de tipo planta
        /// </summary>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("api/bodegas/planta")]
        [SwaggerOperation("ObtenerBodegasTipoPlanta")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<BodegaResponse>), description: "Operación realizada con éxito")]
        public async Task<List<BodegaResponse>> ObtenerBodegasTipoPlanta()
        {
            BodegaBL bodegaBL= new BodegaBL();

            var obtenerBodegas = await bodegaBL.ObtenerTodasPlantas();

            var bodegaResponses = this.mapper.Map<List<Bodega>, List<EVO_PV_WebApi.Models.BodegasApi.BodegaResponse>>(obtenerBodegas);

            return bodegaResponses;
        }

        /// <summary>
        /// Obtiene la bodega por código
        /// </summary>
        /// <param name="codigo">Indica el código de la bodega</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("api/bodegas/{codigo}")]       
        [SwaggerOperation("ObtenerBodegaxCodigo")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<BodegaResponse>), description: "Operación realizada con éxito")]
        public BodegaResponse ObtenerBodegaxCodigo(string codigo)
        {          
           BodegaBL bLBodegas = new BodegaBL();

           Bodega bodega = bLBodegas.ObtenerBodegaPorCodigo(codigo);

           BodegaResponse bodegaResponse = this.mapper.Map<Bodega,BodegaResponse>(bodega);

            return bodegaResponse;
        }
    }
}
