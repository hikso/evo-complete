﻿using EVO_BusinessLogic;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_Worker.Resources;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EVO_Worker.Workers
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 05-Ene/2021
    /// Descripción      : Esta clase invoca la lógica de negocio de los artículos y bodegas.
    /// </summary>
    public class WArticuloBodegaSAPEVO : BackgroundService
    {
        #region Atributos
        private readonly ILogger<WArticuloBodegaSAPEVO> _logger;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private BLParametroGeneral bLParametroGeneral = null;
        private BLArticulo bLArticulo = null;
        private string mensajeLog;
        #endregion

        #region Constructores       
        public WArticuloBodegaSAPEVO(ILogger<WArticuloBodegaSAPEVO> logger)
        {
            _logger = logger;

            bLParametroGeneral = new BLParametroGeneral();
            bLArticulo = new BLArticulo();

            mensajeLog = string.Empty;
        }
        #endregion

        #region Métodos

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            mensajeLog = $"WArticuloBodegaSAPEVO iniciando a las {DateTimeOffset.Now.DateTime}";

            logger.Info(mensajeLog);

            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            mensajeLog = $"WArticuloBodegaSAPEVO finalizando a las {DateTimeOffset.Now.DateTime}";

            logger.Info(mensajeLog);

            await base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                string valorParametro = string.Empty;

                try
                {
                    valorParametro = await bLParametroGeneral
                        .ObtenerValorPorNombreAsincrono(NombresParametrosGeneralesEnum.CONSULTAR_ARTICULOS_BODEGA_CADA_SEGUNDOS);
                }
                catch (EVOException)
                {
                    continue;
                }

                int segundos = 0;

                try
                {
                    segundos = int.Parse(valorParametro);
                }
                catch
                {
                    EVOException e = new EVOException(errores.errSegundosNoEntero);

                    logger.Error(e);

                    continue;
                }

                if (segundos < 0)
                {
                    EVOException e = new EVOException(errores.errSegundosNegativos);

                    logger.Error(e);

                    continue;
                }

                if (segundos == 0)
                {
                    EVOException e = new EVOException(errores.errSegundosCero);

                    logger.Error(e);

                    continue;
                }

                segundos *= 1000;

                mensajeLog = $"WArticuloBodegaSAPEVO corriendo a las : {DateTimeOffset.Now.DateTime} , cada {segundos / 1000} segundos";

                logger.Info(mensajeLog);

                await Task.Delay(segundos, stoppingToken);

                try
                {
                   await bLArticulo.AsignarIntegracionArticulosBodegaSAP();
                }
                catch (Exception)
                {
                    continue;
                }

            }
        }
        #endregion

    }
}
