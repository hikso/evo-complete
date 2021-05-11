using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga
    /// Fecha de Creación: 10-Feb/2020
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de las entregas
    /// </summary>
    ///  
    public class BLEntrega
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Este método obtiene el estado de la entrega por el nombre 
        /// </summary>
        /// <param name="estadosEntregaEnum">Indica el nombre del estado de la entrega</param>
        /// <returns>BOEstadoEntrega</returns>
        public BOEstadoEntrega ObtenerEstadoEntregaxNombre(EstadosEntregasEnum estadosEntregaEnum)
        {

            logger.Info($"Entró al método ObtenerEstadoEntregaxNombre con el parámetro estadosEntregaEnum = {estadosEntregaEnum}");

            DAEntrega dAEntregas = new DAEntrega();

            BOEstadoEntrega bOEstadoEntrega = null;

            try
            {
                bOEstadoEntrega = dAEntregas.ObtenerEstadoEntregaxNombre(estadosEntregaEnum);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (bOEstadoEntrega == null)
            {
                EVOException e = new EVOException(errores.errEstadoEntregaNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return bOEstadoEntrega;

        }

        public int ObtenerConteoTodosEntregasEnrutamiento()
        {
            logger.Info($"Entró al método ObtenerConteoTodosEntregasEnrutamiento");

            DAEntrega dAEntregas = new DAEntrega();

            int nRegistros = 0;

            try
            {
                object result = dAEntregas.ObtenerConteoTodosEntregasEnrutamiento();

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

        public BOEntrega ObtenerEntregaxEntregaId(int entregaId)
        {
            if (entregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerEntregaxEntregaId  en BLEntrega con el parámetro: entregaId: {entregaId}");

            DAEntrega dAEntregas = new DAEntrega();

            BOEntrega bOEntrega = null;

            try
            {
                bOEntrega = dAEntregas.ObtenerEntregaxEntregaId(entregaId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (bOEntrega == null)
            {
                EVOException e = new EVOException(errores.errEntregaNoExiste);

                logger.Error(e);

                throw e;
            }

            return bOEntrega;
        }

        public PesajeEntrega ObtenerPesajeEntrega(int entregaId, EstadosEntregasEnum estadosEntregasEnum)
        {
            logger.Info($"Entró al método ObtenerPesajeEntrega en BLEntregas con el parámetro entregaId = {entregaId}");

            if (entregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            DAEntrega dAEntrgas = new DAEntrega();

            return null;
        }

        public List<EntregaEnrutamientoRespuesta> ObtenerTodosEntregasEnrutamiento(int desde, int hasta)
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

            logger.Info(string.Format("Entró al método ObtenerTodosEntregasEnrutamiento con los parámetros: desde: {0}, hasta: {1}", desde, hasta));

            DAEntrega dAEntregas = new DAEntrega();

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI));

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

            List<EntregaEnrutamientoRespuesta> entregasRespuestas = null;

            try
            {
                entregasRespuestas = dAEntregas.ObtenerTodosEntregasEnrutamiento(desde, hasta);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return entregasRespuestas;
        }

        /// <summary>
        /// Obtiene las entregas por pedidoId
        /// </summary>
        /// <param name="pedidoId">Indica el id del pedido</param>
        /// <response>OList<EntregaRespuesta></response>
        public List<EntregaRespuesta> ObtenerEntregasxPedidoId(int pedidoId)
        {
            BLPedido bLPedidos = new BLPedido();

            ObtenerPedidoRespuesta obtenerPedidoRespuesta = null;

            try
            {
                obtenerPedidoRespuesta = bLPedidos.ObtenerPedidoxId(pedidoId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            logger.Info($"Entró al método ObtenerEntregasxPedidoId con el parámetro: pedidoId: {pedidoId}");

            DAEntrega dAEntregas = new DAEntrega();

            EntregaRespuesta entregas = null;

            try
            {
                entregas = ObtenerEntregasPedidoxId(pedidoId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            int numero = 0;

            List<EntregaRespuesta> entregasRespuesta = new List<EntregaRespuesta>();

            foreach (Entrega entrega in entregas.Entregas)
            {
                numero++;

                entregasRespuesta.Add(new EntregaRespuesta()
                {
                    EntregaId = entrega.EntregaId,
                    NumeroEntrega = $"{numero}/{entregas.Entregas.Count}",
                    FechaHoraEntrega = entrega.FechaHoraEntrega.ToString("dd//MM/yyyy HH:mm:ss"),
                    FinalizadoRecepcion = entrega.FinalizadoRecepcion
                }
                );
            }

            return entregasRespuesta;

        }

        /// <summary>
        /// Obtiene el objeto de negocio DetalleEntrega
        /// </summary>
        /// <param name="detalleEntregaId">3</param>
        /// <returns>DetalleEntrega</returns>
        public DetalleEntrega ObtenerDetalleEntregaxId(int detalleEntregaId)
        {
            if (detalleEntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errDetalleEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método GetDetalleEntregaxId con el parámetro: detalleEntregaId: {detalleEntregaId}");

            DAEntrega dAEntregas = new DAEntrega();

            DetalleEntrega detalleEntrega = null;

            try
            {
                detalleEntrega = dAEntregas.GetDetalleEntregaxId(detalleEntregaId);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            if (detalleEntrega == null)
            {
                EVOException e = new EVOException(errores.errDetalleEntregaRespuestaNoInformado);

                logger.Error(e);

                throw e;
            }

            return detalleEntrega;
        }

        public EntregaBO ObtenerEntregaxId(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerEntregaxId con el parámetro: id: {id}");

            DAEntrega dAEntregas = new DAEntrega();

            EntregaBO entrega;

            try
            {
                entrega = dAEntregas.ObtenerEntregaxId(id);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (entrega == null)
            {
                EVOException e = new EVOException(errores.errEntregaNoExiste);

                logger.Error(e);

                throw e;
            }

            return entrega;
        }

        /// <summary>
        /// Retorna una lista de entregas 
        /// </summary>
        /// <param name="id">Id del pedido</param>
        /// <returns>lista de entregas</returns>
        public EntregaRespuesta ObtenerEntregasPedidoxId(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerEntregasPedidoxId con el parámetro: id: {id}");

            DAPedido dAPedidos = new DAPedido();

            EntregaRespuesta entregas;

            try
            {
                entregas = dAPedidos.ObtenerEntregasPedidoxId(id);
            }
            catch (Exception e)
            {
                throw e;
            }

            return entregas;
        }

        /// <summary>
        /// edita un artículo asociado a una entrega en el módulo de distribución
        /// </summary>
        /// <param name="eliminarArticuloDistribucion">solicitud eliminarArticuloDistribucion</param>
        /// <response code="200">Booleano Operación realizada con éxito</response>
        public bool EliminarArticuloDistribucion(EliminarArticuloDistribucion eliminarArticuloDistribucion)
        {
            logger.Info($"Entró al método EliminarArticuloDistribucion en blEntregas con los parametros parámetros {JsonConvert.SerializeObject(eliminarArticuloDistribucion)}");

            if (eliminarArticuloDistribucion.MotivoId >= 0)
            {
                BLMotivo bLMotivos = new BLMotivo();
                MotivoRespuesta motivo = null;
                try
                {
                    motivo = bLMotivos.ObtenerMotivoxId(eliminarArticuloDistribucion.MotivoId);
                }
                catch (EVOException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            if (eliminarArticuloDistribucion.DetalleEntregaId == 0)
            {
                EVOException e = new EVOException(errores.errDetalleEntregaIdNula);
                logger.Error(e);
                throw e;
            }
            DAEntrega dAEntregas = new DAEntrega();
            try
            {
                dAEntregas.EliminarArticuloDistribucion(eliminarArticuloDistribucion);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }
            return true;


        }



        /// <summary>
        /// Este método retorna una lista de tipo ArticuloPendienteRespuesta que representa los artículos pendientes en una entrega
        /// </summary>       
        /// <param name="entregaId">2</param>
        /// <returns>List<ArticuloPendienteRespuesta></returns>
        public List<ArticuloPendienteRespuesta> ObtenerArticulosPendientes(int entregaId)
        {
            logger.Info($"Entró al método ObtenerArticulosPendientes en BLEntregas con el parámetro entregaId = {entregaId}");

            if (entregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            DAEntrega dAEntrgas = new DAEntrega();

            EntregaBO entregaActualizar = null;

            try
            {
                entregaActualizar = ObtenerEntregaxId(entregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            EntregaRespuesta entregaRespuesta = null;

            try
            {
                entregaRespuesta = ObtenerEntregasPedidoxId(entregaActualizar.PedidoId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            //
            entregaRespuesta.Entregas = entregaRespuesta.Entregas.Where(e => e.EntregaId != entregaId).ToList();

            entregaRespuesta.Articulos = entregaRespuesta.Articulos.Where(a => !entregaActualizar.Detalles.Where(f => double.Parse(f.CantidadEntrega) > 0).Select(c => c.Codigo).Contains(a.Codigo)).ToList();

            List<ArticuloPendienteRespuesta> articulosPendientes = new List<ArticuloPendienteRespuesta>();

            BLArticulo bLArticulos = new BLArticulo();

            foreach (EntregaArticulo articulo in entregaRespuesta.Articulos)
            {
                ArticuloPendienteRespuesta articuloPendiente = new ArticuloPendienteRespuesta()
                {
                    IdEstadoArticulo = articulo.IdEstadoArticulo == null ? null: articulo.IdEstadoArticulo,
                    Codigo = articulo.Codigo,
                    Nombre = articulo.Nombre,
                    CantidadAprobada = articulo.CantidadAprobada.ToString(),
                    CantidadPendiente = (articulo.CantidadAprobada - (entregaRespuesta.Entregas.Select(e => e.Detalles.Where(d => d.CodigoArticulo == articulo.Codigo).Select(c => c.Cantidad).Sum()).Sum())).ToString()
                };

                if (Convert.ToDecimal(articuloPendiente.CantidadPendiente) == 0)
                {
                    continue;
                }

                articulosPendientes.Add(articuloPendiente);

            }

            return articulosPendientes;

        }
    }
}
