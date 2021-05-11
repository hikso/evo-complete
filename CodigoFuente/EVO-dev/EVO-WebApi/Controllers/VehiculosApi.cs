/*
 * API de Vehiculos
 *
 * API de administración de Vehiculos 
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
using EVO_WebApi.Models.VehiculosApi;
using EVO_WebApi.Resources;
using IO.Swagger.Models.VehiculosApi;
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
    public class VehiculosApiController : ControllerBase
    {
        #region Campos Privados
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private IMapper mapper;
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Obtiene los tipos de vehiculos capaces de llevar la entrega
        /// </summary>
        /// <param name="cantidadEntrega">Indica el peso en kilogramos de la entrega</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/vehiculos/tiposvehiculo/filtrados/")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerTiposVehiculosFiltrados")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<TipoVehiculoResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerTiposVehiculosFiltrados([FromQuery][Required()]decimal cantidadEntrega)
        {
            logger.Info($"Entró al método ObtenerTiposVehiculosFiltrados en Api Vehiculos con el parámetro cantidadEntrega = {cantidadEntrega}");

            try
            {
                BLVehiculo bLVehiculos = new BLVehiculo();

                List<TipoVehiculoRespuesta> vehiculos = bLVehiculos.ObtenerTiposVehiculosFiltrados(cantidadEntrega);

                List<TipoVehiculoResponse> vehiculosResponse =
                    this.mapper.Map<List<TipoVehiculoRespuesta>, List<TipoVehiculoResponse>>(vehiculos);

                return Ok(vehiculosResponse);
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
        /// Actualizar el encabezado del viaja asociados en enrutamiento
        /// </summary>
        /// <param name="body">Solicitud de actualización de vehículo en enrutamiento</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpPut]
        [Route("/api/vehiculos/actualizar/vehiculo/enrutamiento")]
        [ValidateModelState]
        [SwaggerOperation("ActualizarVehiculoEnrutamiento")]
        public virtual IActionResult ActualizarVehiculoEnrutamiento([FromBody]ActualizaVehiculoEnrutamientoRequest body)
        {
            logger.Info($"Entró al método ActualizarVehiculoEnrutamiento en Api Vehiculos con los parámetros {JsonConvert.SerializeObject(body)}");
            try
            {
                ActualizarVehiculoEnrutamiento edicionVehiculoEnrutamiento = this.mapper.Map<ActualizaVehiculoEnrutamientoRequest, ActualizarVehiculoEnrutamiento>(body); ;
                BLVehiculo bLVehiculos = new BLVehiculo();
                if (HttpContext.User.Identity != null)
                {
                    edicionVehiculoEnrutamiento.Usuario = HttpContext.User.Identity.Name;
                }
                return Ok(bLVehiculos.ActualizarVehiculoEnrutamiento(edicionVehiculoEnrutamiento));
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
        /// Obtiene los muelles para asignar cargue de vehículo
        /// </summary>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/vehiculos/muelles")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerMuelles")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<MuelleResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerMuelles()
        {
            logger.Info($"Entró al método ObtenerMuelles en Api Vehiculos");
            try
            {
                BLVehiculo blVehiculos = new BLVehiculo();
                List<MuelleRespuesta> muelles = blVehiculos.ObtenerMuelles();
                List<MuelleResponse> muellesResponse = this.mapper.Map<List<MuelleRespuesta>, List<MuelleResponse>>(muelles);
                return Ok(muellesResponse);
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
        /// Obtiene todos los empleados tipo conductor o auxiliar
        /// </summary>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/vehiculos/conductoresyauxiliares")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerConductoresAuxiliares")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<EmpleadoResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerConductoresAuxiliares()
        {
            logger.Info($"Entró al método ObtenerConductoresAuxiliares en Api Vehiculos");

            try
            {
                BLVehiculo bLVehiculos = new BLVehiculo();

                List<Empleado> empleados = bLVehiculos.ObtenerConductoresAuxiliares();

                List<EmpleadoResponse> vehiculosResponse =
                    this.mapper.Map<List<Empleado>, List<EmpleadoResponse>>(empleados);

                return Ok(vehiculosResponse);
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
        /// Obtiene los tipos de vehiculos
        /// </summary>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/vehiculos/tipovehiculo")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerTipoVehiculo")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<TipoVehiculoResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerTipoVehiculo()
        {
            logger.Info($"Entró al método ObtenerTipoVehiculo en Api Vehiculos");

            try
            {
                BLVehiculo bLVehiculos = new BLVehiculo();

                List<TipoVehiculoRespuesta> vehiculos = bLVehiculos.ObtenerTipoVehiculo();

                List<TipoVehiculoResponse> vehiculosResponse =
                    this.mapper.Map<List<TipoVehiculoRespuesta>, List<TipoVehiculoResponse>>(vehiculos);

                return Ok(vehiculosResponse);
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
        /// Obtiene los vehiculos por un tipo
        /// </summary>
        /// <param name="id">Indica el id del tipo de vehiculo</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/vehiculos")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerVehiculosxTipo")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<VehiculoResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerVehiculosxTipo([FromQuery][Required()]int id)
        {
            logger.Info($"Entró al método ObtenerVehiculosxTipo en Api Vehiculos");

            try
            {
                BLVehiculo bLVehiculos = new BLVehiculo();

                List<VehiculoRespuesta> vehiculos = bLVehiculos.ObtenerVehiculosxTipo(id);

                List<VehiculoResponse> vehiculosResponse =
                    this.mapper.Map<List<VehiculoRespuesta>, List<VehiculoResponse>>(vehiculos);

                return Ok(vehiculosResponse);
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
        /// Obtiene el estado actual del vehiculo,conductor,auxiliar y muelle en enrutamiento
        /// </summary>
        /// <param name="vehiculoEntregaId">Indica el id del viaje</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/vehiculos/obtener/vehiculo/enrutamiento")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerVehiculoEnrutamiento")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<VehiculoEnrutamientoResponse>), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerVehiculoEnrutamiento([FromQuery][Required()]int vehiculoEntregaId)
        {
            logger.Info($"Entró al método ObtenerVehiculoEnrutamiento en Api Vehiculos");

            try
            {
                BLVehiculo bLVehiculos = new BLVehiculo();

                List<VehiculoEnrutamientoRespuesta> vehiculosEnrutamientoRespuesta =
                bLVehiculos.ObtenerVehiculoEnrutamiento(vehiculoEntregaId);

                List<VehiculoEnrutamientoResponse> vehiculosEnrutamientoResponse =
                    this.mapper.Map<List<VehiculoEnrutamientoRespuesta>, List<VehiculoEnrutamientoResponse>>(vehiculosEnrutamientoRespuesta);

                return Ok(vehiculosEnrutamientoRespuesta);
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

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        public VehiculosApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        #endregion
    }
}
