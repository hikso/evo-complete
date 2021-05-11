using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using NLog;
using System;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 22-May/2020
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de Procesos
    /// </summary>
    public class BLProcesos
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos
        /// <summary>
        /// Obtiene el proceso por nombre
        /// </summary>
        /// <param name="procesoEnum">Enumerador del proceso</param>       
        /// <response>ProcesoBO</response>
        public ProcesoBO ObtenerProcesoxNombre(ProcesosEnum procesoEnum)
        {
            logger.Info($"Entró al método ObtenerProcesoxNombre en BLProcesos - EVO_WebApi con el parámetro procesoEnum = {procesoEnum.ToString()}");

            DAProcesos dAProcesos = new DAProcesos();

            ProcesoBO procesoBO = null;

            try
            {
                procesoBO = dAProcesos.ObtenerProcesoxNombre(procesoEnum);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (procesoBO == null)
            {
                EVOException e = new EVOException(errores.errProcesoNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return procesoBO;

        }
        #endregion

    }
}
