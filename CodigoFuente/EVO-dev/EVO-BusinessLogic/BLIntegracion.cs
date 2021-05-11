using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Microsoft.SqlServer.Management.Smo.Agent;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EVO_BusinessLogic
{
    public class BLIntegracion
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos privados

        /// <summary>
        /// Este método realiza todas las validaciones para realizar la integración (Valida que el job exista previamente)
        /// </summary>
        public void ValidarJob()
        {
            logger.Info(string.Format("Entró al método ValidarJob en BLIntegración sin parámetros"));

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string nombre = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.JOB_SAP_ARTICULOS);

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Exception e = new Exception(string.Format(errores.errParametroGeneralNoExisteBD, NombresParametrosGeneralesEnum.JOB_SAP_ARTICULOS.ToString()));

                logger.Error(e);

                throw e;
            }

            nombre = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.JOB_PASO_SAP_ARTICULOS);

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Exception e = new Exception(string.Format(errores.errParametroGeneralNoExisteBD, NombresParametrosGeneralesEnum.JOB_PASO_SAP_ARTICULOS));

                logger.Error(e);

                throw e;
            }

            nombre = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.JOB_PROGRAMACION_SAP_ARTICULOS);

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Exception e = new Exception(string.Format(errores.errParametroGeneralNoExisteBD, "JOB_PROGRAMACION_SAP_ARTICULOS"));

                logger.Error(e);

                throw e;
            }

            DAIntegracion dAIntegraciones = new DAIntegracion();

            nombre = "JOB_SAP_ARTICULOS";

            Job job = dAIntegraciones.ObtenerJobXNombre(nombre);

            if (job == null)
            {
                Exception e = new Exception(string.Format(errores.errJobNoExisteEnBD, nombre));

                logger.Error(e);

                throw e;
            }

            if (job.Name != nombre)
            {
                Exception e = new Exception(string.Format(errores.errJobNoExisteEnBD, nombre));

                logger.Error(e);

                throw e;
            }

            nombre = "JOB_PASO_SAP_ARTICULOS";

            if (!job.JobSteps.Contains(nombre))
            {
                Exception e = new Exception(string.Format(errores.errPasoNoExisteEnJob, nombre));

                logger.Error(e);

                throw e;
            }
            
            nombre = "JOB_PROGRAMACION_SAP_ARTICULOS";

            if (!job.JobSchedules.Contains(nombre))
            {
                Exception e = new Exception(string.Format(errores.errProgramacionNoExisteEnJob, nombre));

                logger.Error(e);

                throw e;
            }
        }
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Este método inicializa el job_sap_articulos
        /// </summary>
        /// <returns>Verdadero o falso si inicio el job sap artículos</returns>
        public bool IniciarSAPArticulos()
        {
            logger.Info(string.Format("Entró al método IniciarSAPArticulos sin parámetros"));

            ValidarJob();

            DAIntegracion dAIntegraciones = new DAIntegracion();

            dAIntegraciones.IniciarJobXNombre("JOB_SAP_ARTICULOS");

            return true;
        }

        /// <summary>
        /// Este método programa la ejecución de la integracion 
        /// </summary>
        /// <param name="programarEjecucionIntegracionSolicitud">Indica el programación de la integración</param>
        /// <returns>La programación de la integración</returns>
        public bool ProgramarSAPArticulos(ProgramarEjecucionIntegracionSolicitud programarEjecucionIntegracionSolicitud)
        {
            EVOException e;

            if (programarEjecucionIntegracionSolicitud == null)
            {
               e = new EVOException(errores.errProgramarSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ProgramarSAPArticulos con los parámetros : {JsonConvert.SerializeObject(programarEjecucionIntegracionSolicitud)}");

            ValidarJob();

            BLParametroGeneral bLParametrosGenerales = new BLParametroGeneral();          

            switch (programarEjecucionIntegracionSolicitud.TipoProgramacion)
            {
                case TiposProgramacionIntegracionEnum.Una_Vez_a_Día:

                    if (string.IsNullOrEmpty(programarEjecucionIntegracionSolicitud.HoraEjecucionIntegracion))
                    {
                        string horaEjecucion;

                        try
                        {
                            horaEjecucion = bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TIPO_PROGRAMACION_INTEGRACION_UNA_VEZ_DIA_FECHA_INICIO);
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex);

                            throw ex;
                        }

                        programarEjecucionIntegracionSolicitud.HoraEjecucionIntegracion = horaEjecucion;
                      
                    }

                    Tiempo tiempo;

                    try
                    {
                        tiempo = JsonConvert.DeserializeObject<Tiempo>(programarEjecucionIntegracionSolicitud.HoraEjecucionIntegracion);                        
                    }
                    catch
                    {
                        e = new EVOException(errores.errProgramarSolicitudDiaNoFormato);

                        logger.Error(e);

                        throw e;
                    }                    

                    programarEjecucionIntegracionSolicitud.Hora = int.Parse(tiempo.hour);
                    programarEjecucionIntegracionSolicitud.Minuto =int.Parse(tiempo.minute);

                    break;

                case TiposProgramacionIntegracionEnum.Frecuencia_al_Día:

                    if (programarEjecucionIntegracionSolicitud.Frecuencia<=0)
                    {
                        e = new EVOException(errores.errProgramarSolicitudFrecuenciaNoInformado);

                        logger.Error(e);

                        throw e;
                    }

                    if (programarEjecucionIntegracionSolicitud.Frecuencia >=1 && programarEjecucionIntegracionSolicitud.Frecuencia<=4)
                    {
                        e = new EVOException(errores.errProgramarSolicitudFrecuenciaMenorA5);

                        logger.Error(e);

                        throw e;
                    }

                    if (programarEjecucionIntegracionSolicitud.Frecuencia > 100)
                    {
                        e = new EVOException(errores.errProgramarSolicitudFrecuenciaMayorA100);

                        logger.Error(e);

                        throw e;
                    }

                    if (string.IsNullOrEmpty(programarEjecucionIntegracionSolicitud.HoraInicio))
                    {
                        string horaInicio;

                        try
                        {
                            horaInicio = bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TIPO_PROGRAMACION_INTEGRACION_FRECUENCIA_DIA_FECHA_INICIO);
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex);

                            throw ex;
                        }

                        programarEjecucionIntegracionSolicitud.HoraInicio = horaInicio;

                    }                  


                    if (string.IsNullOrEmpty(programarEjecucionIntegracionSolicitud.HoraFin))
                    {
                        string horaFin;

                        try
                        {
                            horaFin = bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TIPO_PROGRAMACION_INTEGRACION_FRECUENCIA_DIA_FECHA_FIN);
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex);

                            throw ex;
                        }

                        programarEjecucionIntegracionSolicitud.HoraFin = horaFin;

                    }                   

                    try
                    {
                        tiempo = JsonConvert.DeserializeObject<Tiempo>(programarEjecucionIntegracionSolicitud.HoraInicio);                       
                    }
                    catch
                    {
                        e = new EVOException(errores.errProgramarFechaInicioFrecuenciaDiaNoFormato);

                        logger.Error(e);

                        throw e;
                    }                   

                    programarEjecucionIntegracionSolicitud.FechaInicioHora = int.Parse(tiempo.hour);
                    programarEjecucionIntegracionSolicitud.Minuto = int.Parse(tiempo.minute);

                    DateTime Inicio = DateTime.Parse($"{programarEjecucionIntegracionSolicitud.FechaInicioHora}:{ programarEjecucionIntegracionSolicitud.Minuto}");

                    try
                    {
                        tiempo = JsonConvert.DeserializeObject<Tiempo>(programarEjecucionIntegracionSolicitud.HoraFin);                        
                    }
                    catch
                    {
                        e = new EVOException(errores.errProgramarFechaFinFrecuenciaDiaNoFormato);

                        logger.Error(e);

                        throw e;
                    }                 

                    programarEjecucionIntegracionSolicitud.FechaFinHora = int.Parse(tiempo.hour);
                    programarEjecucionIntegracionSolicitud.FechaFinMinuto = int.Parse(tiempo.minute);

                    DateTime Fin = DateTime.Parse($"{programarEjecucionIntegracionSolicitud.FechaFinHora}:{ programarEjecucionIntegracionSolicitud.FechaFinMinuto}");
                                     

                    if (Fin < Inicio)
                    {
                        e = new EVOException(errores.errHoraFinMayor);

                        logger.Error(e);

                        throw e;
                    }

                    break;

                default:

                    e = new EVOException(errores.errTipoProgramacionNoExiste);

                    logger.Error(e);

                    throw e;

            }            

            programarEjecucionIntegracionSolicitud.JobParametros = new JobParametros();

            programarEjecucionIntegracionSolicitud.JobParametros.NombreJob = "JOB_SAP_ARTICULOS";
            programarEjecucionIntegracionSolicitud.JobParametros.NombreProgramacionJob = "JOB_PROGRAMACION_SAP_ARTICULOS";

            DAIntegracion dAIntegraciones = new DAIntegracion();
            dAIntegraciones.ProgramarJobXNombre(programarEjecucionIntegracionSolicitud);

            return true;
        }

        /// <summary>
        /// Este método valida la respuesta de la integración 
        /// </summary>
        /// <returns>Retorna si la integración fue exitosa o hubo errores</returns>
        public EstadoEjecucionIntegracionRespuesta ObtenerEstadoEjecucionArticulos()
        {
            logger.Info($"Entró al método ObtenerEstadoEjecucionArticulos sin parámetros");

            ValidarJob();

            DAIntegracion dAIntegraciones = new DAIntegracion();

            JobParametros jobParametros = new JobParametros()
            {
                NombreJob = "JOB_SAP_ARTICULOS",
                NombreProgramacionJob = "JOB_PROGRAMACION_SAP_ARTICULOS"
            };

            EstadoEjecucionIntegracionRespuesta respuesta= dAIntegraciones.ObtenerEstadoIntegracion(jobParametros);
           

            return respuesta;

        }

        /// <summary>
        /// Este método habilita la ejecución de la integración 
        /// </summary>
        /// <param name="habilitarEjecucionIntegracionSolicitud">Indica si la habilitación de la integración</param>
        /// <returns>Retorna si la integracion se habilito correctamente o tuvo errores en la ejecución</returns>
        public bool HabilitarSAPArticulos(HabilitarEjecucionIntegracionSolicitud habilitarEjecucionIntegracionSolicitud)
        {

            if (habilitarEjecucionIntegracionSolicitud == null)
            {
                EVOException e = new EVOException(errores.errhabilitarEjecucionIntegracionSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método HabilitarSAPArticulos con los parámetros : {JsonConvert.SerializeObject(habilitarEjecucionIntegracionSolicitud)}");

            ValidarJob();

            DAIntegracion dAIntegraciones = new DAIntegracion();

            habilitarEjecucionIntegracionSolicitud.JobParametros = new JobParametros();

            habilitarEjecucionIntegracionSolicitud.JobParametros.NombreJob = "JOB_SAP_ARTICULOS";

            dAIntegraciones.HabilitarJob(habilitarEjecucionIntegracionSolicitud);

            return true;
        }

        /// <summary>
        /// Este método obtiene todos los registros en los de la integración
        /// </summary>
        /// <param name="desde">Indica el parametro desde se va obtener el log ejemplo: desde 1</param>
        /// <param name="hasta">Indica el parametro hasta se va obtener el log ejemplo: hasta 10</param>
        /// <returns>Lista de los logs de integración de los artículos</returns>
        public List<LogIntegracionRespuesta> ObtenerlogsEjecucionArticulos(int desde, int hasta)
        {
            if (desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (hasta < desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerlogsEjecucionArticulos de Bl Integraciones con los parámetros: desde: {0}, hasta: {1}", desde, hasta));

            DAIntegracion dAIntegraciones = new DAIntegracion();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            //Se valida que no se estén pidiendo más registros que los que se encuentren actualmente configurados en la tabla de parámetros generales
            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI.ToString()));

                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((hasta - desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            List<LogIntegracionRespuesta> logsIntegracionesRespuestas = null;

            ValidarJob();

            string nombreJob;

            try
            {
                nombreJob = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.JOB_SAP_ARTICULOS);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }          

            Job job = dAIntegraciones.ObtenerJobXNombre(nombreJob);           

            try
            {
                logsIntegracionesRespuestas = dAIntegraciones.ObtenerlogsEjecucion(desde, hasta, job.JobID.ToString());

                if (logsIntegracionesRespuestas == null)
                {
                    logsIntegracionesRespuestas = new List<LogIntegracionRespuesta>();
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return logsIntegracionesRespuestas;
        }

        /// <summary>
        /// Este método obtiene el registro de los Logs por el filtro
        /// </summary>
        /// <param name="filtroIntegracion">Indica el valor por el cual se va a filtrar</param>
        /// <returns>Lista de los logs de integración de los artículos por filtro</returns>
        public List<LogIntegracionRespuesta> ObtenerLogsEjecucionArticulosxFiltro(FiltroIntegracion filtroIntegracion)
        {
            if (filtroIntegracion == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }
       
            logger.Info(string.Format("Entró al método ObtenerLogsEjecucionArticulosxFiltro con los parámetros: {0}",
              JsonConvert.SerializeObject(filtroIntegracion)));

            if (filtroIntegracion.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtroIntegracion.Hasta < filtroIntegracion.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            DAIntegracion dAIntegraciones = new DAIntegracion();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            //Se valida que no se estén pidiendo más registros que los que se encuentren actualmente configurados en la tabla de parámetros generales
            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((filtroIntegracion.Hasta - filtroIntegracion.Desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            if (
                string.IsNullOrWhiteSpace(filtroIntegracion.FechaInicio) &&
                string.IsNullOrWhiteSpace(filtroIntegracion.FechaFin) &&
                string.IsNullOrWhiteSpace(filtroIntegracion.LogJob) &&
                string.IsNullOrWhiteSpace(filtroIntegracion.LogIntegracion) &&
                filtroIntegracion.Estado==null)
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            string FechaPattern = @"^([0]?[0-9]|[1][0-2])[.\/-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[.\/-]([0-9]{4}|[0-9]{2})$";

            if (!string.IsNullOrEmpty(filtroIntegracion.FechaInicio))
            {
                Match regFechaMatch = Regex.Match(filtroIntegracion.FechaInicio, FechaPattern);

                if (!regFechaMatch.Success)
                {
                    filtroIntegracion.FechaInicio = filtroIntegracion.FechaInicio.Replace("-", "/");
                }              

            }          

            List<LogIntegracionRespuesta> logIntegracionesRespuestas = null;           

            BLParametroGeneral bLParametrosGenerales = new BLParametroGeneral();

            string nombreJob = bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.JOB_SAP_ARTICULOS);

            Job job = dAIntegraciones.ObtenerJobXNombre(nombreJob);

            filtroIntegracion.jobId = job.JobID.ToString();

            try
            {
                logIntegracionesRespuestas = dAIntegraciones.ObtenerLogsEjecucionArticulosxFiltro(filtroIntegracion);

                if (logIntegracionesRespuestas == null)
                {
                    logIntegracionesRespuestas = new List<LogIntegracionRespuesta>();
                }

                logIntegracionesRespuestas.RemoveAll(x => !x.Estado.Equals(filtroIntegracion.Estado));

                if (!string.IsNullOrWhiteSpace(filtroIntegracion.FechaInicio))
                {
                    logIntegracionesRespuestas.RemoveAll(x => !x.FechaInicio.Contains(filtroIntegracion.FechaInicio));
                }

                if (!string.IsNullOrWhiteSpace(filtroIntegracion.FechaFin))
                {
                    logIntegracionesRespuestas.RemoveAll(x => !x.FechaFin.Contains(filtroIntegracion.FechaFin));
                }

                if (!string.IsNullOrWhiteSpace(filtroIntegracion.LogJob))
                {
                    logIntegracionesRespuestas.RemoveAll(x => !x.LogJob.Contains(filtroIntegracion.LogJob));
                }

                if (!string.IsNullOrWhiteSpace(filtroIntegracion.LogIntegracion))
                {                  
                    logIntegracionesRespuestas.RemoveAll(x => !x.LogIntegracion.Contains(filtroIntegracion.LogIntegracion));
                }               

            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return logIntegracionesRespuestas;
        }

        /// <summary>
        /// Este método obtiene el conteo de todos los registros de la integración
        /// </summary>
        /// <returns>El total de registros</returns>
        public int ObtenerConteoTodosRegistros()
        {
            logger.Info(string.Format("Entró al método ObtenerConteoTodosRegistros de BLIntegraciones"));

            DAIntegracion dAIntegraciones = new DAIntegracion();

            int nRegistros = 0;

            ValidarJob();

            BLParametroGeneral bLParametrosGenerales = new BLParametroGeneral();

            string nombreJob = bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.JOB_SAP_ARTICULOS);

            Job job = dAIntegraciones.ObtenerJobXNombre(nombreJob);

            try
            {
                object result = dAIntegraciones.ObtenerConteoTodosRegistros(job.JobID.ToString());

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;
        }

        #endregion
    }
}
