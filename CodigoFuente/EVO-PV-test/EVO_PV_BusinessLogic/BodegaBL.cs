using EVO_PV_BusinessObjects;
using EVO_PV_Proxy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVO_PV_BusinessLogic
{
    public class BodegaBL
    {
        BodegaProxy bodegaProxy = new BodegaProxy();

        /// <summary>
        /// Llama al proxy de bodega, metodo obtener todas plantas
        /// </summary>
        /// <returns></returns>
        public async Task<List<Bodega>> ObtenerTodasPlantas()
        {
            return await bodegaProxy.ObtenerPlantas();
        }

        /// <summary>
        /// Llama al proxy de bodega, método obtener la planta por el código
        /// </summary>
        /// <returns>Objeto de negocio tipo bodega</returns>
        public Bodega ObtenerBodegaPorCodigo(string codigo)
        {
            return bodegaProxy.ObtenerBodegaPorCodigo(codigo);
        }
    }
}
