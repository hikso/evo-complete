/*
 * API de Modulos
 *
 * API de administración de Módulos 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: krestrepo@porcicarnes.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using AutoMapper;
using EVO_BusinessLogic;
using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_WebApi.Attributes;
using EVO_WebApi.Models.ModulosApi;
using EVO_WebApi.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EVO_WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>    
    [ApiController]
    [Authorize]
    public class ModulosApiController : ControllerBase
    {
        #region Campos Privados
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private IMapper mapper;
        #endregion

        /// <summary>
        /// Obtiene un Módulo por Id
        /// </summary>
        /// <param name="id">Id del Módulo</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/modulos/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerModuloxId")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObtenerModuloResponse), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerModuloxId([FromRoute][Required]int id)
        {
            try
            {
                BLModulo BLModulos = new BLModulo();

                Modulo modulo = BLModulos.ObtenerModuloxId(id);

                ObtenerModuloResponse respuesta = null;

                try
                {
                    respuesta = this.mapper.Map<Modulo, ObtenerModuloResponse>(modulo);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);

                    throw ex;
                }

                return Ok(respuesta);
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
        /// Obtiene un Módulo por Nombre
        /// </summary>
        /// <param name="nombre">Nombre del Módulo</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/modulos/obtenerxnombre/{nombre}")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerModuloxNombre")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObtenerModuloResponse), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerModuloxNombre([FromRoute][Required]string nombre)
        {
            try
            {
                BLModulo BLModulos = new BLModulo();

                Modulo modulo = BLModulos.ObtenerModuloxNombre(nombre);

                ObtenerModuloResponse respuesta = null;

                try
                {
                    respuesta = this.mapper.Map<Modulo, ObtenerModuloResponse>(modulo);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);

                    throw ex;
                }

                return Ok(respuesta);
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
        /// Obtiene todos los Módulos
        /// </summary>
        /// <param name="desde">Indica el número de registro desde el cuál se deben obtener los registros</param>
        /// <param name="hasta">Indica el número de registro hasta el cuál se deben obtener los registros</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpGet]
        [Route("/api/modulos")]
        [ValidateModelState]
        [SwaggerOperation("ObtenerTodosModulos")]
        [SwaggerResponse(statusCode: 200, type: typeof(ObtenerTodosModulosResponse), description: "Operación realizada con éxito")]
        public virtual IActionResult ObtenerTodosModulos([FromQuery][Required()]int desde, [FromQuery][Required()]int hasta)
        {
            try
            {
                BLModulo blmodulos = new BLModulo();
                BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

                // Encabezado de la respuesta
                ObtenerTodosModulosResponse registrosModulosResponse = new ObtenerTodosModulosResponse();

                int numeroTotalRegistros = blmodulos.ObtenerNumeroTotalRegistros();
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
                catch (EVOException e)
                {
                    throw e;
                }
                catch
                {
                    EVOException e = new EVOException(string.Format(errores.errParametroNumeroEntero, pgTamanhoPaginacion));

                    logger.Error(e);

                    throw e;
                }

                registrosModulosResponse.NumeroTotalRegistros = numeroTotalRegistros;
                registrosModulosResponse.TamanhoPaginacion = tamanhoPaginacion;

                List<ObtenerTodosModulosResponseRegistros> listaRegistrosModulosResponse = new List<ObtenerTodosModulosResponseRegistros>();

                List<Modulo> listaModulos = new List<Modulo>();

                listaModulos = blmodulos.obtenerTodosModulos(desde, hasta);

                if (listaModulos != null)
                {
                    listaRegistrosModulosResponse = this.mapper.Map<List<Modulo>, List<ObtenerTodosModulosResponseRegistros>>(listaModulos);
                }

                registrosModulosResponse.Registros = listaRegistrosModulosResponse;

                return Ok(registrosModulosResponse);
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
        public ModulosApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        #endregion
    }
}