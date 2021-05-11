using EVO_BusinessObjects;
using EVO_PV_BusinessObjects;
using EVO_PV_Proxy;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVO_PV_BusinessLogic
{
    public class ArticuloBL
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        ArticuloProxy articuloProxy = null;

        #region Contructores
        public ArticuloBL()
        {
            articuloProxy = new ArticuloProxy();
        }
        #endregion



        /// <summary>
        /// Obtiene las acciones del artículo
        /// </summary>
        public async Task<List<Accion>> ObtenerAcciones()
        {
            return await articuloProxy.ObtenerAcciones();
        }

        /// <summary>
        /// Llama al proxy pedidos, metodo obtener todos los articulos
        /// </summary>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <param name="codigoBodega"></param>
        /// <returns></returns>
        public async Task<ObtenerArticulos> ObtenerTodosArticulosxBodega(int desde, int hasta, string whsCodePuntoVenta, string whsCodePlanta, string tipoSolicitud)
        {

            ObtenerArticulos obtenerArticulos= await articuloProxy.ObtenerTodosArticulosxBodega(desde, hasta, whsCodePuntoVenta, whsCodePlanta,tipoSolicitud);

            return obtenerArticulos;         
        }

       

        /// <summary>
        /// Llama al proxy pedidos, metodo obtener todos articulos por filtro
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ObtenerTodosArticulos ObtenerTodosArticulosFiltrar(FiltrarArticulo filtro)
        {
            return articuloProxy.ObtenerTodosArticulosFiltrar(filtro);
        }

        /// <summary>
        /// Obtiene los articulos por bodega filtrando
        /// </summary>
        /// <param name="body"></param>
        /// <returns>Lista de negocio de articulos de una bodega especifica</returns>
        public List<ArticuloBodega> ObtenerArticulosBodega(BuscarArticuloSolicitud body)
        {
            return articuloProxy.ObtenerArticulosBodega(body);
        }

        /// <summary>
        /// Llama al proxy pedidos, metodo obtener todos estados 
        /// </summary>
        /// <returns></returns>
        public async Task<List<EstadoArticulo>> ObtenerTodosEstados()
        {
            return await articuloProxy.ObtenerTodosEstados();
        }

        /// <summary>
        /// Llama al proxy pedidos, metodo obtener todos estados 
        /// </summary>
        /// <returns></returns>
        public async Task<List<UnidadMedida>> ObtenerTodosUnidadesMedida()
        {
            return await articuloProxy.ObtenerTodasUnidadesMedida();
        }

        /// <summary>
        /// Obtiene los empaques
        /// </summary>     
        /// <returns>List<BOEmpaque></returns>
        public async Task<List<BOEmpaque>> ObtenerEmpaques()
        {
            logger.Info("Entró al método ObtenerEmpaques en EVO_PV_WebApi - ArticuloBL sin parámetros");

            return await articuloProxy.ObtenerEmpaques();
        }
    }
}
