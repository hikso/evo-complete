using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVO_BusinessLogic
{
    public class BLBodega
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Devuelve la parametrización por el tipo de bodega
        /// </summary>
        /// <param name="codigoBodegaDe">Indica el código de donde se realizará el pedido</param>
        /// <param name="tipoBodega">Indica del tipo de bodega al cual se le hará el pedido</param>
        /// <response>BOTipoBodegaParametrizacion</response>
        public BOTipoBodegaParametrizacion ObtenerTipoBodegaParametrizacion(string codigoBodegaDe, string prefijoBodega)
        {
            logger.Info($"Entró al método ObtenerTipoBodegaParametrizacion en EVO-WebApi - BLBodega con los parámetros codigoBodegaDe = {codigoBodegaDe} , prefijoBodega={prefijoBodega}");

            if (string.IsNullOrEmpty(codigoBodegaDe))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(prefijoBodega))
            {
                EVOException e = new EVOException(errores.errPrefijoBodegasNoInformado);

                logger.Error(e);

                throw e;
            }           

            DABodega dABodega = new DABodega();

            BOTipoBodegaParametrizacion bOTipoBodegaParametrizacion = null;

            try
            {
                bOTipoBodegaParametrizacion = dABodega.ObtenerTipoBodegaParametrizacion(codigoBodegaDe, prefijoBodega);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return bOTipoBodegaParametrizacion;        


        }

        /// <summary>
        /// Obtiene las bodegas a las cuales se les pueden hacer solicitudes de pedido
        /// </summary>
        /// <response>List<BOBodega></response>
        public List<BOBodega> ObtenerBodegasSolicitud()
        {
            logger.Info($"Entró al método ObtenerBodegasSolicitud en EVO-WebApi - BodegasApi sin parámetros");

            List<BOObtenerTipoBodegaAResponse> tiposBogas= ObtenerTiposBodega();

            List<BOBodega> bodegas = new List<BOBodega>();

            foreach (BOObtenerTipoBodegaAResponse tiposBoga in tiposBogas)
            {
                foreach (BOObtenerTipoBodegaAResponseBodegas bodega in tiposBoga.Bodegas)
                {
                    bodegas.Add(new BOBodega()
                    {
                        WhsCode = bodega.Codigo,
                        WhsName = bodega.Nombre
                    });
                }
            }
            //Obtengo y agrego a las bodegas la bodega área de compras con parametro general
            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();
            string codigoAreaCompra = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.CODIGO_BODEGA_COMPRAS);
            bodegas.Add(ObtenerBodegaPorCodigo(codigoAreaCompra));

            return bodegas;

        }

        /// <summary>
        /// Obtienen las bodegas(Punto de Venta) por usuario
        /// </summary>
        /// <param name="usuarioId">Indica el id del usuario/param>
        /// <returns>Lista de tipo BOBodega/returns>
        public List<BOBodega> ObtenerBodegasPuntosVentaPorUsuarioId(int usuarioId)
        {
            if (usuarioId == 0)
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerBodegasPuntosVentaPorUsuario en EVO-WebApi - BLBodega con el parámetro: usuarioId : {usuarioId}");

            DABodega dABodegas = new DABodega();

            List<BOBodega> bodegas = null;

            try
            {
                bodegas = dABodegas.ObtenerBodegasPuntosVentaPorUsuario(usuarioId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return bodegas;

        }

        /// <summary>
        /// Este método obtiene la bodega por el código
        /// </summary>
        /// <param name="codigo">Indica el valor del código del parametro</param>
        /// <returns>Código de la bodega</returns>
        public BOBodega ObtenerBodegaPorCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                EVOException e = new EVOException(errores.errCodigoNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerBodegaPorCodigo con el parámetro: código : {codigo}");

            DABodega dABodegas = new DABodega();

            BOBodega bodega = null;

            try
            {
                bodega = dABodegas.ObtenerBodegaPorCodigo(codigo);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (bodega == null)
            {
                EVOException e = new EVOException(errores.errBodegaNoRegistrada);

                logger.Error(e);

                throw e;
            }

            BLClientesParametrizacion bLClientesParametrizacion = new BLClientesParametrizacion();
            BOParametrizacionResponse bOParametrizacionResponse = null;

            try
            {
                bOParametrizacionResponse = bLClientesParametrizacion.ObtenerPatrametrizacionesxCliente(codigo);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOParametrizacionResponse != null && bOParametrizacionResponse.FacturacionPorcentajeDescuento != null)
            {
                bodega.FacturacionPorcentajeDescuento = bOParametrizacionResponse.FacturacionPorcentajeDescuento;
            }

            return bodega;
        }

        /// <summary>
        /// Obtiene los tipos de bodegas a las cuales se les pueden hacer solicitudes de pedido
        /// </summary>
        /// <response>List<BOObtenerTipoBodegaAResponse></response>
        public List<BOObtenerTipoBodegaAResponse> ObtenerTiposBodega()
        {
            logger.Info($"Entró al método ObtenerTiposBodega en EVO-WebApi sin parámetros");

            List<BOObtenerTipoBodegaAResponse> tiposBodega = new List<BOObtenerTipoBodegaAResponse>();

            BOObtenerTipoBodegaAResponse tipoBodega = null;

            foreach (BOBodega bodega in ObtenerBodegasTipoPlanta())
            {
                tipoBodega = new BOObtenerTipoBodegaAResponse()
                {
                    PrefijoBodega=bodega.WhsCode.Split("-")[0],
                    TipoBodega = bodega.WhsName[0]+bodega.WhsName.Substring(1).ToLower(),
                    Bodegas = new List<BOObtenerTipoBodegaAResponseBodegas>()
                };
                tipoBodega.Bodegas.Add(new BOObtenerTipoBodegaAResponseBodegas()
                {
                    Codigo = bodega.WhsCode,
                    Nombre = bodega.WhsName
                });

                tiposBodega.Add(tipoBodega);
            }

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            string prefijoPuntoVenta = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PREFIJO_BODEGAS_PUNTO_VENTA);

            tipoBodega = new BOObtenerTipoBodegaAResponse()
            {
                PrefijoBodega = prefijoPuntoVenta,
                TipoBodega = "Puntos de venta",
                Bodegas = new List<BOObtenerTipoBodegaAResponseBodegas>()
            };

            foreach (BOBodega bodega in ObtenerBodegasTipoPuntoVenta())
            {
                tipoBodega.Bodegas.Add(new BOObtenerTipoBodegaAResponseBodegas()
                {
                    Codigo = bodega.WhsCode,
                    Nombre = bodega.WhsName
                });
            }          

            tiposBodega.Add(tipoBodega);

            return tiposBodega;

        }

        /// <summary>
        /// Este método obtiene bodegas por el tipo de punto de venta
        /// </summary>
        /// <returns>Lista de todas las bodegas</returns>
        public List<BOBodega> ObtenerBodegasTipoPuntoVenta()
        {
            logger.Info("Entró al método ObtenerBodegasTipoPuntoVenta en BLBodegas sin parámetros");

            DABodega dABodegas = new DABodega();

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string prefijo = string.Empty;

            try
            {
                prefijo = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PREFIJO_BODEGAS_PUNTO_VENTA);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            List<BOBodega> bodegas;

            try
            {
                bodegas = dABodegas.ObtenerBodegasxPrefijo(prefijo);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return bodegas;
        }

        /// <summary>
        /// Obtiene las bodegas filtradas por código artículo y id de entrega
        /// </summary>
        /// <param name="codigo">Indica el código del artículo</param>
        /// <param name="entregaId">Indica el id de la entrega</param>
        /// <response>List<Bodega></response>
        public List<BOBodega> ObtenerBodegasFiltrar(string codigo, int entregaId)
        {
            logger.Info($"Entró al método ObtenerBodegasFiltrar en  BlBodegas con los parámetros código = {codigo},entregaId = {entregaId}");

            if (string.IsNullOrEmpty(codigo))
            {
                EVOException e = new EVOException(errores.errCodigoNoInformado);

                logger.Error(e);

                throw e;
            }

            if (entregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BLEntrega bLEntregas = new BLEntrega();

            EntregaBO entregaBO = null;

            try
            {
                entregaBO = bLEntregas.ObtenerEntregaxId(entregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BLArticulo bLArticulos = new BLArticulo();

            if (bLArticulos.ObtenerTodosArticulos().Where(a => a.ItemCode == codigo).Count() == 0)
            {
                EVOException e = new EVOException(errores.errArticuloNoExisteEnBaseDeDatos);

                logger.Error(e);

                throw e;
            }

            DABodega dABodegas = new DABodega();

            List<BOBodega> bodegasPlanta = new List<BOBodega>();

            string prefijoBodega = entregaBO.WhsPlanta.Substring(0, entregaBO.WhsPlanta.IndexOf("-"));

            try
            {
                bodegasPlanta = dABodegas.ObtenerBodegasxFiltro(codigo, prefijoBodega);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return bodegasPlanta;
        }

        /// <summary>
        /// Este método obtiene las bodegas por el tipo de planta
        /// </summary>
        /// <returns>Lista de las bodegas</returns>
        public List<BOBodega> ObtenerBodegasTipoPlanta()
        {
            logger.Info("Entró al método ObtenerBodegasTipoPlanta en BLBodegas sin parámetros");

            DABodega dABodegas = new DABodega();

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string codigosPlanta = string.Empty;

            try
            {
                codigosPlanta = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.CODIGOS_BODEGAS_TIPO_PLANTA);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            List<BOBodega> bodegasPlanta = new List<BOBodega>();

            try
            {
                foreach (string codigo in codigosPlanta.Split(","))
                {
                    BOBodega bodega = dABodegas.ObtenerBodegaPorCodigo(codigo);

                    bodegasPlanta.Add(bodega);
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return bodegasPlanta;
        }

        #endregion
    }
}
