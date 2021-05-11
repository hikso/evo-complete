
using EFCoreExtensions.ExtensionMethods;
using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_DataAccess.Context;
using EVO_DataAccess.Utils;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 10-Sep/2019
    /// Descripción      : Acceso a datos de las integraciones
    /// </summary>
    public class DAIntegracion
    {
        #region Métodos Públicos
        /// <summary>
        /// Este método obtiene el nombre del job a ejecutar
        /// </summary>
        /// <param name="nombreJob">Indica el nombre del job</param>
        /// <returns>Nombre del job</returns>
        public Job ObtenerJobXNombre(string nombreJob)
        {
            Server server = InstanciarServidor();

            return server.JobServer.Jobs[nombreJob];
        }

        /// <summary>
        /// Este método inicia el job por el nombre 
        /// </summary>
        /// <param name="nombreJob">Indica el nombre del job</param>
        /// <returns>Verdadero o falso si pudo iniciar el job por el nombre encontrado</returns>
        public bool IniciarJobXNombre(string nombreJob)
        {
            Server server = InstanciarServidor();

            Job job = server.JobServer.Jobs[nombreJob];

            job.Start();

            do
            {
                Thread.Sleep(100);

                job.Refresh();
            } while (job.CurrentRunStatus == JobExecutionStatus.Idle);

            do
            {
                Thread.Sleep(100);

                job.Refresh();
            } while (job.CurrentRunStatus == JobExecutionStatus.Executing);

            return true;
        }

        /// <summary>
        /// Este método programa el job por cada nombre encontrado
        /// </summary>
        /// <param name="programarEjecucionIntegracionSolicitud">Indica el valor de la programación solicitada</param>
        /// <returns>Verdadero o falso si se pudo programar el job por el nombre</returns>
        public bool ProgramarJobXNombre(ProgramarEjecucionIntegracionSolicitud programarEjecucionIntegracionSolicitud)
        {
            Job job = ObtenerJobXNombre(programarEjecucionIntegracionSolicitud.JobParametros.NombreJob);

            JobSchedule programacion = job.JobSchedules[programarEjecucionIntegracionSolicitud.JobParametros.NombreProgramacionJob];

            int hora, minuto;

            switch (programarEjecucionIntegracionSolicitud.TipoProgramacion)
            {
                case TiposProgramacionIntegracionEnum.Una_Vez_a_Día:
                    programacion.FrequencyTypes = FrequencyTypes.Daily;
                    programacion.FrequencySubDayTypes = FrequencySubDayTypes.Once;

                    hora = programarEjecucionIntegracionSolicitud.Hora;
                    minuto = programarEjecucionIntegracionSolicitud.Minuto;

                    programacion.ActiveStartTimeOfDay = new TimeSpan(hora, minuto, 0);

                    break;
                case TiposProgramacionIntegracionEnum.Frecuencia_al_Día: 
                    programacion.FrequencyTypes = FrequencyTypes.Daily;
                    programacion.FrequencySubDayTypes = FrequencySubDayTypes.Minute;
                    programacion.FrequencySubDayInterval = programarEjecucionIntegracionSolicitud.Frecuencia;

                    hora = programarEjecucionIntegracionSolicitud.FechaInicioHora;
                    minuto = programarEjecucionIntegracionSolicitud.FechaIncioMinuto;

                    programacion.ActiveStartTimeOfDay = new TimeSpan(hora, minuto, 0);

                    hora = programarEjecucionIntegracionSolicitud.FechaFinHora;
                    minuto = programarEjecucionIntegracionSolicitud.FechaFinMinuto;

                    programacion.ActiveEndTimeOfDay = new TimeSpan(hora, minuto, 0);

                    break;
                default:
                    break;
            }

            programacion.Alter();

            return true;
        }

        /// <summary>
        /// Este método habilita el job de la integración 
        /// </summary>
        /// <param name="habilitarEjecucionIntegracionSolicitud">Indica si se habilito</param>
        /// <returns>Verdadero o falso si se habilito el job</returns>
        public bool HabilitarJob(HabilitarEjecucionIntegracionSolicitud habilitarEjecucionIntegracionSolicitud)
        {
            Job job = ObtenerJobXNombre(habilitarEjecucionIntegracionSolicitud.JobParametros.NombreJob);

            if (habilitarEjecucionIntegracionSolicitud.Habilitado)
            {
                job.IsEnabled = true;
            }
            else
            {
                job.IsEnabled = false;
            }

            job.Alter();

            return true;
        }

        /// <summary>
        /// Este método obtiene el estado de la integración 
        /// </summary>
        /// <param name="jobParametros">Indica los valores de los parametros enviados en el job</param>
        /// <returns>Instancia de tipo EstadoEjecucionIntegracionRespuesta</returns>
        public EstadoEjecucionIntegracionRespuesta ObtenerEstadoIntegracion(JobParametros jobParametros)
        {
            Job job = ObtenerJobXNombre(jobParametros.NombreJob);

            bool IntegracionHabilitada = job.IsEnabled;

            DateTime FechaDeshabilitado = job.DateLastModified;

            EstadoEjecucionIntegracionRespuesta estadoEjecucionIntegracionRespuesta =
                new EstadoEjecucionIntegracionRespuesta()
                {
                    IntegracionHabilitada = IntegracionHabilitada,
                    FechaDeshabilitado = FechaDeshabilitado
                };

            if (job.JobSchedules[jobParametros.NombreProgramacionJob].FrequencySubDayTypes == FrequencySubDayTypes.Once)
            {
                estadoEjecucionIntegracionRespuesta.TipoProgamacion = 0;

                DateTime fecha = DateTime.Today.Add(job.JobSchedules[jobParametros.NombreProgramacionJob].ActiveStartTimeOfDay);
                
                estadoEjecucionIntegracionRespuesta.HoraEjecucion = $"{fecha.Hour}:{fecha.Minute}";
            }

            if (job.JobSchedules[jobParametros.NombreProgramacionJob].FrequencySubDayTypes == FrequencySubDayTypes.Minute)
            {
                estadoEjecucionIntegracionRespuesta.TipoProgamacion = 1;

                DateTime fecha = DateTime.Today.Add(job.JobSchedules[jobParametros.NombreProgramacionJob].ActiveStartTimeOfDay);
                
                estadoEjecucionIntegracionRespuesta.HoraInicio = $"{fecha.Hour}:{fecha.Minute}";
                fecha = DateTime.Today.Add(job.JobSchedules[jobParametros.NombreProgramacionJob].ActiveEndTimeOfDay);
                estadoEjecucionIntegracionRespuesta.HoraFin = $"{fecha.Hour}:{fecha.Minute}";
                estadoEjecucionIntegracionRespuesta.frecuencia = job.JobSchedules[jobParametros.NombreProgramacionJob].FrequencySubDayInterval;
            }

            return estadoEjecucionIntegracionRespuesta;
        }

        /// <summary>
        /// Este método obtiene el log de la ejecución del job
        /// </summary>
        /// <param name="desde">Indica el valor desde el cual obtendra los valor ejemplo desde: 1</param>
        /// <param name="hasta">Indica el valor hasta el cual obtendra los valor ejemplo hasta: 10</param>
        /// <param name="jobId">Indica el valor del id del job</param>
        /// <returns>Lista de los logs de las integración</returns>
        public List<LogIntegracionRespuesta> ObtenerlogsEjecucion(int desde, int hasta, string jobId)
        {
            using (var contexto = new Contexto())
            {
                // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Desde",
                    Value = desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Hasta",
                    Value = hasta
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@jobId",
                    Value = jobId
                });

                List<LogIntegracionRespuesta> logsIntegracionesRespuestas = contexto.LoadSPCustomMapper<LogIntegracionRespuesta>("ObtenerTodosLogsIntegracion", dbParameters, MapeadorRegistrosLogIntegraciones);

                return logsIntegracionesRespuestas;
            }
        }

        /// <summary>
        /// Este método obtiene el conteo de todos los registros
        /// </summary>
        /// <param name="jobId">Indica el valor del id del job</param>
        /// <returns>Id del job</returns>
        public object ObtenerConteoTodosRegistros(string jobId)
        {
            List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

            dbParameters.Add(new EFCoreExtensionParameter()
            {
                ParameterName = "@jobId",
                Value = jobId
            });

            int nRegistros = 0;

            using (var contexto = new Contexto())
            {
                object result = contexto.LoadSPScalar("ObtenerTodosConteoLogsIntegracion", dbParameters);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiebe el log de la ejecución de los artículos filtrados
        /// </summary>
        /// <param name="filtro">Indica los valores por los cuales se realizo el filtro</param>
        /// <returns>Lista de el log de las integraciones realizado el filtro</returns>
        public List<LogIntegracionRespuesta> ObtenerLogsEjecucionArticulosxFiltro(FiltroIntegracion filtro)
        {
            using (var contexto = new Contexto())
            {
                // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@JobId",
                    Value = filtro.jobId
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@desde",
                    Value = filtro.Desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@hasta",
                    Value = filtro.Hasta
                });

                List<LogIntegracionRespuesta> logIntegracionRespuestas = contexto.LoadSPCustomMapper<LogIntegracionRespuesta>("ObtenerTodosLogsIntegracion", dbParameters, MapeadorRegistrosLogIntegraciones);

                return logIntegracionRespuestas;
            }
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Este método mapea un DbDataReader en una instancia de un LogIntegracionRespuesta
        /// </summary>
        /// <param name="reader">DbDataReader</param>
        /// <returns>Instancia de LogIntegracionRespuesta</returns>
        private LogIntegracionRespuesta MapeadorRegistrosLogIntegraciones(DbDataReader reader)
        {
            LogIntegracionRespuesta s = null;

            if (reader != null)
            {
                s = new LogIntegracionRespuesta()
                {
                    Estado = reader["Estado"].ToString() == "1",
                    LogJob = reader["LogJob"].ToString(),
                    FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString()).ToString(),
                    FechaFin = DateTime.Parse(reader["FechaFin"].ToString()).ToString(),
                    LogIntegracion = reader["LogIntegracion"].ToString()
                };
            }

            return s;
        }

        /// <summary>
        /// Este método permite obtener la instancia de un servidor
        /// </summary>
        /// <returns>Instancia de Servidor</returns>
        private Server InstanciarServidor()
        {
            AppConfiguration appConfig = new AppConfiguration();

            //Se obtiene la cadena de conexión del archivo appSettings.json del proyecto EVO-WebApi
            string connectionStringEVO = appConfig.ConnectionString["EVO"];

            SqlConnection sqlConnection = new SqlConnection(connectionStringEVO);
            ServerConnection serverConnection = new ServerConnection(sqlConnection);
            Server server = new Server(serverConnection);

            //TODO: Verficar como quitar el limite de registros de log desde C# Quitar la palomita en "Limit size of job history log" en propiedades / history del "SQL Server Agent" para quitar el limite de los registros de log de "msdb.dbo.sysjobhistory"

            return server;
        }
        #endregion
    }
}