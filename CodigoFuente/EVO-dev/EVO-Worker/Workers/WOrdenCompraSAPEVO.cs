using EVO_BusinessLogic;
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
    /// Fecha de Creación: 16-Oct/2020
    /// Descripción      : Esta clase invoca la lógica de negocio de las ordenes de compra.
    /// </summary>
    public class WOrdenCompraSAPEVO : BackgroundService
    {
        #region Atributos
        private readonly ILogger<WOrdenCompraSAPEVO> _logger;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private BLParametroGeneral bLParametroGeneral = null;
        private BLArticulo bLArticulo = null;

        private string mensajeLog;

        #endregion

        #region Constructores       
        public WOrdenCompraSAPEVO(ILogger<WOrdenCompraSAPEVO> logger)
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
            mensajeLog = $"WOrdenCompraSAPEVO iniciando a las {DateTimeOffset.Now.DateTime}";

            logger.Info(mensajeLog);

            await base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            mensajeLog = $"WOrdenCompraSAPEVO finalizando a las {DateTimeOffset.Now.DateTime}";

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
                        .ObtenerValorPorNombreAsincrono(NombresParametrosGeneralesEnum.CONSULTAR_ORDENES_COMPRA_CADA_SEGUNDOS);
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

                mensajeLog = $"WOrdenCompraSAPEVO corriendo a las : {DateTimeOffset.Now.DateTime} , cada {segundos / 1000} segundos";

                logger.Info(mensajeLog);

                await Task.Delay(segundos, stoppingToken);

                try
                {
                    await bLArticulo.ObtenerOrdenesCompraSAP();
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
