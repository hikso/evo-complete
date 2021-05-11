using EVO_PV_BusinessObjects;
using EVO_PV_Proxy;

namespace EVO_PV_BusinessLogic
{
    public class ConfigBL
    {
        /// <summary>
        /// Llama al proxy de configuración, método obtener version actual
        /// </summary>
        /// <returns></returns>
        public ObtenerVersion ObtenerVersionActual()
        {
            ConfigProxy configProxy = new ConfigProxy();

            return configProxy.ObtenerVersionActual();
        }

        /// <summary>
        /// Llama al proxy de configuración, método obtener el máximo tamaño de paginación
        /// </summary>
        /// <returns>ParametroGeneral</returns>
        public ParametroGeneral ObtenerParametroGeneralxNombre(string nombre)
        {
            ConfigProxy configProxy = new ConfigProxy();

            return configProxy.ObtenerParametroGeneralxNombre(nombre);
        }
    }
}