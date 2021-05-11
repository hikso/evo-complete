using EVO_PV_BusinessObjects;
using EVO_PV_Proxy;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PV_BusinessLogic
{
    public class BLParametroGeneral
    {

        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion
        /// <summary>
        /// Este método obtiene el valor de un parámetro general del sistema, dado su nombre
        /// </summary>
        /// <param name="nombre">Nombre del parámetro general</param>
        /// <returns>Valor solicitado</returns>
        public async Task<ParametroGeneral> ObtenerParametroGeneralXNombre(string  nombre)
        {

            logger.Info($"Entró al método ObtenerValorPorNombre con los parámetros: nombre : {nombre}");

            ParametrosGeneralProxy generalProxy = new ParametrosGeneralProxy();

            return await generalProxy.ObtenerParametroGeneralXNombre(nombre);         

      
        }
    }
}
