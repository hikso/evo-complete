using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 21-Sep/2019
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio del Artículo
    /// </summary>
    public class BLArticulo
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos Públicos    

        /// <summary>
        /// Obtiene artículo por código
        /// </summary>
        /// <param name="codigo">Indica el código del artículo</param>
        /// <returns>Articulo</returns>
        public BOArticulo ObtenerArticuloxCodigo(string codigo)
        {
            logger.Info($"Entró al método ObtenerArticuloxCodigo en BLArticulos con parámetro codigo = {codigo}");

            if (string.IsNullOrEmpty(codigo))
            {
                EVOException e = new EVOException(errores.errCodigoArticuloNoInformado);

                logger.Error(e);

                throw e;

            }

            DAArticulo dAArticulos = new DAArticulo();

            BOArticulo articulo = new BOArticulo();

            try
            {
                articulo = dAArticulos.obtenerArticuloxCodigo(codigo);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (articulo == null)
            {
                EVOException e = new EVOException(errores.errArticuloNoExiste);

                logger.Error(e);

                throw e;
            }

            return articulo;
        }

        /// <summary>
        /// Este método obtiene todos los artículos de las bodegas por el filtro
        /// </summary>
        /// <param name="filtro">Indica el valor del filtro realizado</param>
        /// <returns>Lista de todos los artículos realizado el filtro</returns>
        public List<ArticuloBodega> ObtenerTodosArticulosBodegaxFiltro(FiltroArticulo filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosArticulosxFiltro con los parámetros {0}",
                JsonConvert.SerializeObject(filtro)));

            if (string.IsNullOrEmpty(filtro.WhsCode))
            {
                EVOException e = new EVOException(errores.errSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            int nBackSlash = filtro.WhsCode.IndexOf(@"-");

            if (nBackSlash > 0)
            {
                filtro.WhsCode = filtro.WhsCode.Substring(nBackSlash + 1, filtro.WhsCode.Length - nBackSlash - 1);
            }
            else
            {
                EVOException e = new EVOException(errores.errCodigoArticuloFormatoIncorrecto);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrWhiteSpace(filtro.CodigoArticulo) &&
               string.IsNullOrWhiteSpace(filtro.NombreArticulo) &&
               string.IsNullOrWhiteSpace(filtro.Stock) &&
               string.IsNullOrWhiteSpace(filtro.Minimo) &&
               string.IsNullOrWhiteSpace(filtro.Maximo))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            List<ArticuloBodega> articulosBodega = new List<ArticuloBodega>();

            DAArticulo dAArticulos = new DAArticulo();

            try
            {
                articulosBodega = dAArticulos.ObtenerTodosArticulosxFiltro(filtro);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return articulosBodega;

        }        

        /// <summary>
        /// Obtiene todas las tranformaciones
        /// </summary>       
        /// <responses>List<BOTransformacion></response>
        public List<BOTransformacion> ObtenerTodasTransformaciones()
        {
            logger.Info("Entró al método ObtenerTodasTransformaciones en BLArticulo - EVO-WebApi");

            DAArticulo dAArticulo = new DAArticulo();

            List<BOTransformacion> bOTransformaciones = null;

            try
            {
                bOTransformaciones = dAArticulo.ObtenerTodasTransformaciones();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            return bOTransformaciones;
        }

        /// <summary>
        /// Obtiene los artículos en el punto de venta filtrado por código y/o nombre
        /// </summary>
        /// <param name="body">Solicitud de filtro de artículos facturación. Se debe ingresar al menos uno de los criterios del filtro</param>
        /// <response>List<BOArticuloPuntoVentaResponse></response>
        public List<BOArticuloPuntoVentaResponse> ObtenerArticulosFacturacionxFiltro(BOFiltrarArticulosFacturacionRequest bOBody)
        {
            if (bOBody == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerArticulosFacturacionxFiltro en BLArticulo - EVO-WebApi con los parámetros {JsonConvert.SerializeObject(bOBody)}");

            if (string.IsNullOrEmpty(bOBody.CodigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();

            BOBodega bOBodega = bLBodega.ObtenerBodegaPorCodigo(bOBody.CodigoPuntoVenta);

            if (string.IsNullOrEmpty(bOBody.IdentificacionSocio))
            {
                EVOException e = new EVOException(errores.errIdentificacionNoInformada);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(bOBody.CodigoArticulo) && string.IsNullOrEmpty(bOBody.NombreArticulo))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            List<BOArticuloPuntoVentaResponse> bOArticulosPuntoVentaResponse = 
                ObtenerArticulosFacturacion(bOBody.CodigoPuntoVenta, bOBody.IdentificacionSocio);

            if (!string.IsNullOrEmpty(bOBody.CodigoArticulo) && !string.IsNullOrEmpty(bOBody.NombreArticulo))
            {
                return bOArticulosPuntoVentaResponse
                    .Where(a => EF.Functions
                    .Like(a.CodigoArticulo, bOBody.CodigoArticulo + "%") && EF.Functions
                    .Like(a.NombreArticulo, bOBody.NombreArticulo + "%"))
                    .ToList();
            }

            if(!string.IsNullOrEmpty(bOBody.CodigoArticulo) && string.IsNullOrEmpty(bOBody.NombreArticulo))
            {
                return bOArticulosPuntoVentaResponse
                    .Where(a => EF.Functions
                    .Like(a.CodigoArticulo, bOBody.CodigoArticulo + "%"))
                    .ToList();
            }
            
                return bOArticulosPuntoVentaResponse
                    .Where(a => EF.Functions
                    .Like(a.NombreArticulo, bOBody.NombreArticulo + "%"))
                    .ToList();
        }

        /// <summary>
        /// Obtiene los artículos para el proceso de facturación
        /// </summary>
        /// <param name="codigoPuntoVenta">Indica el código del punto de venta</param>
        /// <param name="identificacionSocio">Indica la identificación del socio de negocio</param>
        /// <responses>List<BOArticuloPuntoVentaResponse></response>
        public List<BOArticuloPuntoVentaResponse> ObtenerArticulosFacturacion(string codigoPuntoVenta, string identificacionSocio)
        {
            logger.Info($"Entró al método ObtenerArticulosFacturacion en BLArticulo - EVO-WebApi con los parámetros codigoPuntoVenta = {codigoPuntoVenta} , identificacionSocio = {identificacionSocio}");

            if (string.IsNullOrEmpty(codigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();

            BOBodega bOBodega = bLBodega.ObtenerBodegaPorCodigo(codigoPuntoVenta);

            if (string.IsNullOrEmpty(identificacionSocio))
            {
                EVOException e = new EVOException(errores.errIdentificacionNoInformada);

                logger.Error(e);

                throw e;
            }

            BLSocioNegocio bLSocioNegocio = new BLSocioNegocio();

            BOSocioNegocio bOSocioNegocio = bLSocioNegocio.ObtenerSocioNegocio(identificacionSocio);
           
            List<BOArticulo> bOArticulos = ObtenerTodosArticulosxPuntoVenta(codigoPuntoVenta);                

            List<BOArticuloPuntoVentaResponse> bOArticulosPuntoVentaResponse = new List<BOArticuloPuntoVentaResponse>();

            foreach (BOArticulo bOArticulo in bOArticulos.Where(a =>
                        a.ItemCode.Substring(0, a.ItemCode.IndexOf("-")) == TiposPrefijoEnum.PT.ToString() ||
                        a.ItemCode.Substring(0, a.ItemCode.IndexOf("-")) == TiposPrefijoEnum.PTD.ToString()
                ).ToList())
            {

                BOArticuloPuntoVentaResponse bOArticuloPuntoVentaResponse = new BOArticuloPuntoVentaResponse()
                {
                    CodigoArticulo = bOArticulo.ItemCode,
                    NombreArticulo = bOArticulo.ItemName,
                    Lote = string.Empty,
                    PrecioUnitario = decimal.ToInt32(bOArticulo.Price.Value),
                    UnidadMedida = bOArticulo.SalUnitMsr
                };                

                ArticuloBodega articuloBodega = ObtenerArticuloxCodigoBodegaCodigoArticulo(codigoPuntoVenta,bOArticulo.ItemCode);

                bOArticuloPuntoVentaResponse.Stock = articuloBodega.Stock;

                if (bOArticulo.ImpuestosArticulos.Count() > 0)
                {
                    BOImpuestoArticulo BOImpuestoArticulo = bOArticulo.ImpuestosArticulos
                        .OrderByDescending(o => o.ImpuestoArticuloId)
                        .FirstOrDefault(i => i.Impuesto.Codigo == ImpuestosEnum.IVAGEXE.ToString() && i.Impuesto.Activo);

                    if (BOImpuestoArticulo != null)
                    {
                        bOArticuloPuntoVentaResponse.ValorIVA = BOImpuestoArticulo.Impuesto.Valor;
                        bOArticuloPuntoVentaResponse.CodigoIVA = BOImpuestoArticulo.Impuesto.Codigo;
                    }

                }

                if (bOArticulo.ImpuestosSociosArticulos.Count() > 0)
                {
                    BOImpuestoSocioArticulo bOImpuestoSocioArticulo = bOArticulo.ImpuestosSociosArticulos
                        .FirstOrDefault(i => i.Impuesto.Codigo == ImpuestosEnum.NI.ToString() && i.Impuesto.Activo
                        && i.Identificacion == identificacionSocio && i.CodigoArticulo == bOArticulo.ItemCode);

                    if (bOImpuestoSocioArticulo != null)
                    {
                        bOArticuloPuntoVentaResponse.ValorRetencion = bOImpuestoSocioArticulo.Impuesto.Valor;
                        bOArticuloPuntoVentaResponse.CodigoRetencion = bOImpuestoSocioArticulo.Impuesto.Codigo;
                    }

                }

                if (bOArticulo.ListasPrecios.Count() > 0)
                {
                    BOListaPrecio bOListaPrecioItem = bOArticulo.ListasPrecios
                        .FirstOrDefault(l =>
                        l.TipoListaPrecio.Nombre == TiposListaPrecioEnum.PorMayor.ToString() &&
                        l.Identificacion == identificacionSocio &&
                        l.CodigoArticulo == bOArticulo.ItemCode &&
                        (DateTime.Now >= l.FechaInicio && DateTime.Now <= l.FechaFin)
                        );

                    if (bOListaPrecioItem != null)
                    {
                        bOArticuloPuntoVentaResponse.PrecioUnitarioPorMayor = bOListaPrecioItem.PrecioUnitario;
                        bOArticuloPuntoVentaResponse.CantidadMinimaPrecioPorMayor = bOListaPrecioItem.CantidadMinima;
                    }

                }               

                bOArticulosPuntoVentaResponse.Add(bOArticuloPuntoVentaResponse);

            }

            List<BOTransformacion> bOTransformaciones = ObtenerTodasTransformaciones();

            foreach (string codigoArticuloTransformado in bOTransformaciones.Select(t=>t.CodigoArticuloTransformado).Distinct())
            {
                BOArticuloPuntoVentaResponse bOArticuloPuntoVentaResponse = new BOArticuloPuntoVentaResponse()
                {
                    CodigoArticulo = codigoArticuloTransformado,
                    NombreArticulo = bOTransformaciones
                    .FirstOrDefault(t=>t.CodigoArticuloTransformado== codigoArticuloTransformado).NombreArticuloTransformado,
                    Lote = string.Empty,
                    PrecioUnitario = bOTransformaciones
                    .Where(t=>t.CodigoArticuloTransformado == codigoArticuloTransformado)
                    .Select(t=>t.Articulo.Price.Value)
                    .Sum(),
                    UnidadMedida = string.Empty
                };

                bOArticuloPuntoVentaResponse.ArticulosTransformacionResponse = new List<BOArticuloTransformacionResponse>();

                ArticuloBodega articuloBodega = null;

                foreach (BOTransformacion bOTransformacion in bOTransformaciones.Where(t=>t.CodigoArticuloTransformado == codigoArticuloTransformado))
                {
                    try
                    {
                        articuloBodega = ObtenerArticuloxCodigoBodegaCodigoArticulo(codigoPuntoVenta, bOTransformacion.CodigoArticulo);
                    }
                    catch (EVOException e)
                    {
                        if (e.Message == errores.errArticuloBodegaNoRegistrado)
                        {
                            articuloBodega = null;
                        }                        
                    }

                    BOArticuloTransformacionResponse bOArticuloTransformacionResponse = new BOArticuloTransformacionResponse()
                    {
                         CodigoArticulo= bOTransformacion.CodigoArticulo,
                         NombreArticulo= bOTransformacion.Articulo.ItemName,
                         Stock= articuloBodega!=null?articuloBodega.Stock.Value:0,
                         CantidadMinima= bOTransformacion.CantidadMinima
                    };

                    bOArticuloPuntoVentaResponse.ArticulosTransformacionResponse.Add(bOArticuloTransformacionResponse);
                }


                bOArticulosPuntoVentaResponse.Add(bOArticuloPuntoVentaResponse);
            }

            return bOArticulosPuntoVentaResponse;

        }

        /// <summary>
        /// Obtiene los artículos en recepción
        /// </summary>
        /// <param name="entregaId">Indica el id de la entrega</param>
        /// <response>List<ArticuloRecepcionRespuesta></response>
        public List<ArticuloRecepcionRespuesta> ObtenerArticulosRecepcion(int entregaId)
        {
            if (entregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerArticulosRecepcion con el parámetro entregaId = {entregaId}");

            BLEntrega bLEntregas = new BLEntrega();

            BOEntrega bOEntrega = null;

            try
            {
                bOEntrega = bLEntregas.ObtenerEntregaxEntregaId(entregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            List<ArticuloRecepcionRespuesta> articulosRecepcionRespuesta = new List<ArticuloRecepcionRespuesta>();

            articulosRecepcionRespuesta.AddRange(
                   bOEntrega.Detalles.Select(d => new ArticuloRecepcionRespuesta()
                   {
                       DetalleEntregaId = d.DetalleEntregaId,
                       CodigoArticulo = d.DetallePedido.ItemCode,
                       EstadoArticulo = d.DetallePedido.EstadoArticulo.Nombre,
                       CantidadSolicitada = d.DetallePedido.Cantidad,
                       CantidadAprobada = d.DetallePedido.CantidadAprobada.Value,
                       CantidadEnviada = d.DetallePedido.CantidadAprobada.Value, //Por el momento será la aprobada mientras se define el nuevo proceso de la planta de beneficio
                       CantidadRecibida = 0
                   })
                );

            BLArticulo bLArticulos = new BLArticulo();
            BOArticulo boArticulo = null;

            foreach (ArticuloRecepcionRespuesta articuloRecepcionRespuesta in articulosRecepcionRespuesta)
            {
                try
                {
                    boArticulo = bLArticulos.ObtenerArticuloxCodigo(articuloRecepcionRespuesta.CodigoArticulo);
                }
                catch (EVOException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }

                articuloRecepcionRespuesta.NombreArticulo = boArticulo.ItemName;
                articuloRecepcionRespuesta.UnidadMedida = boArticulo.SalUnitMsr;
            }

            BOEstadoEntrega bOEstadoEntrega = null;

            try
            {
                bOEstadoEntrega = bLEntregas.ObtenerEstadoEntregaxNombre(EstadosEntregasEnum.En_Tránsito);
                //Al ser pesados en recepción están en estado "En Tránsito"
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BLPesaje bLPesaje = new BLPesaje();
            BOPesajeEntrega bOPesajeEntrega = null;

            try
            {
                bOPesajeEntrega = bLPesaje.ObtenerPesajeEntrega(entregaId, bOEstadoEntrega.EstadoEntregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOPesajeEntrega != null)
            {
                foreach (ArticuloRecepcionRespuesta articuloRecepcionRespuesta in articulosRecepcionRespuesta)
                {
                    BOPesajeArticulo bOPesajeArticulo =
                        bOPesajeEntrega.PesajesArticulo.FirstOrDefault(pa => pa.DetalleEntregaId == articuloRecepcionRespuesta.DetalleEntregaId);

                    if (bOPesajeArticulo != null)
                    {
                        articuloRecepcionRespuesta.CantidadRecibida = bOPesajeArticulo.Pesajes
                            .Count() > 0 ? bOPesajeArticulo.Pesajes
                            .Select(p => p.PesoBasculaArticulos)
                            .Sum() : bOPesajeEntrega.PesajesArticulo
                            .FirstOrDefault(pa => pa.DetalleEntregaId == articuloRecepcionRespuesta.DetalleEntregaId).CantidadRecibida.Value;

                        articuloRecepcionRespuesta.PesajeArticuloId = bOPesajeArticulo.PesajeArticuloId;

                    }
                }
            }

            return articulosRecepcionRespuesta;
        }

        /// <summary>
        /// Obtiene los artículos y encazado de una entrega en estado alistamiento
        /// </summary>
        /// <param name="id">Indica el id de la entrega</param>
        /// <response>DetalleEntregaRespuesta</response>
        public DetalleEntregaRespuesta ObtenerAriticulosAlistamiento(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerAritculosAlistamiento con el parámetro id = {id}");

            BLEntrega bLEntregas = new BLEntrega();

            EntregaBO entregaBO = null;

            try
            {
                entregaBO = bLEntregas.ObtenerEntregaxId(id);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            DAArticulo dAArticulos = new DAArticulo();

            DetalleEntregaRespuesta detalleEntregaRespuesta = null;

            try
            {
                detalleEntregaRespuesta = dAArticulos.ObtenerArticulosPesaje(id);
            }
            catch (Exception e)
            {
                throw e;
            }

            return detalleEntregaRespuesta;

        }

        /// <summary>
        /// Este método obtiene el estado del artículo por el id
        /// </summary>
        /// <param name="estadoArticuloId">Indica el id del estado</param>
        /// <returns>Instancia de tipo EstadoArticulo</returns>
        public BOEstadoArticulo ObtenerEstadoArticuloxId(int estadoArticuloId)
        {
            if (estadoArticuloId <= 0)
            {
                EVOException e = new EVOException(errores.errEstadoArticuloNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerEstadoArticuloxId con el parámetro estadoArticuloId = {estadoArticuloId}");

            DAArticulo dAArticulos = new DAArticulo();

            BOEstadoArticulo estadoArticulo = null;

            try
            {
                estadoArticulo = dAArticulos.ObtenerEstadoArticuloxId(estadoArticuloId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (estadoArticulo == null)
            {
                EVOException e = new EVOException(errores.errEstadoPedidoNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return estadoArticulo;

        }

        /// <summary>
        /// Este método obtiene el conteo de todos los registros del fittro
        /// </summary>
        /// <param name="filtro">Indica el valor del filtro realizado</param>
        /// <returns>Número de todos los registros realizado el filtro</returns>
        public int ObtenerConteoTodosRegistrosxFiltro(FiltroArticulo filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerConteoTodosRegistrosxFiltro con los parámetros; {0}",
                JsonConvert.SerializeObject(filtro)));

            if (string.IsNullOrEmpty(filtro.WhsCode))
            {
                EVOException e = new EVOException(errores.errSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            DAArticulo dAArticulos = new DAArticulo();

            if (string.IsNullOrWhiteSpace(filtro.CodigoArticulo) &&
                string.IsNullOrWhiteSpace(filtro.NombreArticulo) &&
                string.IsNullOrWhiteSpace(filtro.Stock) &&
                string.IsNullOrWhiteSpace(filtro.Minimo) &&
                string.IsNullOrWhiteSpace(filtro.Maximo))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            int nRegistros = 0;

            try
            {
                object result = dAArticulos.ObtenerConteoTodosRegistrosxFiltro(filtro);

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

        /// <summary>
        /// Este método obtiene todos los artículos por la bodega
        /// </summary>
        /// <param name="desde">Indica el valor del parametro desde ejemplo: desde 1</param>
        /// <param name="hasta">Indica el valor del parametro hasta ejemplo: hasta 10</param>
        /// <param name="whsCodePuntoVenta">Indica el código del punto de venta</param>
        /// <param name="whsCodePlanta">Indica el código de la planta</param>
        /// <returns>Todos los artículos por bodega</returns>
        public List<ArticuloBodega> ObtenerTodosArticulosxBodega(int desde, int hasta, string whsCodePuntoVenta, string whsCodePlanta)
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

            if (string.IsNullOrEmpty(whsCodePlanta))
            {
                EVOException e = new EVOException(errores.errSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(whsCodePuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosArticulosxBodega de BLArticulos con los parámetros: desde: {0}, hasta: {1} ,whsCodePuntoVenta: {2},whsCodePuntoVenta: {3}", desde, hasta, whsCodePuntoVenta, whsCodePlanta));

            DAArticulo dAArticulos = new DAArticulo();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception)
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI.ToString()));

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

            List<ArticuloBodega> articulosBodega = null;

            try
            {             
                    
                string prefijo = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PREFIJO_BODEGAS_PUNTO_VENTA);

                if (prefijo == whsCodePlanta.Split("-")[0])//Si es punto de venta se retornan todos los artículos pt-ptd
                {
                    articulosBodega = dAArticulos.ObtenerTodosArticulosxBodegaPlantas(whsCodePuntoVenta);
                }
                else
                {
                    articulosBodega = dAArticulos.ObtenerTodosArticulosxBodega(desde, hasta, whsCodePuntoVenta, whsCodePlanta);
                }                           

                foreach (ArticuloBodega articulo in articulosBodega)
                {
                    if (articulo.Maximo != null && articulo.Stock != null)
                    {
                        articulo.PedidoSugerido = articulo.Minimo - articulo.Stock;
                        articulo.PedidoSugerido = articulo.PedidoSugerido <= 0 ? 0 : articulo.PedidoSugerido;
                    }
                }

            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return articulosBodega;
        }

        /// <summary>
        /// Este método obtiene el conteo de todos los registros 
        /// </summary>
        /// <param name="whsCode">Indica el valor del código de la bodega</param>
        /// <returns>Número de todos los registros</returns>
        public int ObtenerConteoTodosRegistros(string whsCode,string whsCodePlanta)
        {

            if (string.IsNullOrEmpty(whsCode))
            {
                EVOException e = new EVOException(errores.errSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(whsCodePlanta))
            {
                EVOException e = new EVOException(errores.errSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerConteoTodosRegistros de BLArticulos con el parámetro whsCode = {whsCode}");

            DAArticulo dAArticulos = new DAArticulo();

            int nRegistros = 0;

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            try
            {
                string prefijo = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PREFIJO_BODEGAS_PUNTO_VENTA);

                if (prefijo == whsCodePlanta.Split("-")[0])//Si es punto de venta se retornan todos los artículos pt-ptd
                {
                    object result = dAArticulos.ObtenerConteoTodosRegistrosPlantas(whsCode);              

                    if (result != null)
                    {
                        nRegistros = int.Parse(result.ToString());
                    }
                }
                else
                {
                    object result = dAArticulos.ObtenerConteoTodosRegistros(whsCode, whsCodePlanta);

                    if (result != null)
                    {
                        nRegistros = int.Parse(result.ToString());
                    }
                }

               
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene todos los estados de los artículos
        /// </summary>
        /// <returns>Lista de todos los estados del artículo</returns>
        public List<BOEstadoArticulo> ObtenerTodosEstados()
        {
            logger.Info("Entró al método ObtenerTodosEstados en BLArticulo sin parámetros");

            DAArticulo dAArticulos = new DAArticulo();

            List<BOEstadoArticulo> estadosArticulo = new List<BOEstadoArticulo>();

            try
            {
                estadosArticulo = dAArticulos.ObtenerTodosEstados();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return estadosArticulo;
        }

        /// <summary>
        /// Este método obtiene todo los artículos
        /// </summary>
        /// <returns>Lista de todos los artículos</returns>
        public List<BOArticulo> ObtenerTodosArticulos()
        {
            logger.Info("Entró al método ObtenerTodosArticulos en BLArticulo sin parámetros");

            DAArticulo dAArticulos = new DAArticulo();

            List<BOArticulo> articulos = new List<BOArticulo>();

            try
            {
                articulos = dAArticulos.ObtenerTodosArticulos();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (articulos == null)
            {
                EVOException e = new EVOException(errores.errArticuloNoExiste);

                logger.Error(e);

                throw e;
            }

            return articulos;
        }

        /// <summary>
        /// Este método obtiene todo los artículos del punto de venta
        /// </summary>
        /// <param name="codigoPuntoVenta">Indica el valor del código del punto de venta</param>
        /// <returns>Lista de todos los artículos del punto de venta</returns>
        public List<BOArticulo> ObtenerTodosArticulosxPuntoVenta(string codigoPuntoVenta)
        {
            logger.Info($"Entró al método ObtenerTodosArticulosxPuntoVenta en BLArticulo con el parámetro codigoPuntoVenta = {codigoPuntoVenta}");

            if (string.IsNullOrEmpty(codigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();

            BOBodega bOBodega = bLBodega.ObtenerBodegaPorCodigo(codigoPuntoVenta);

            DAArticulo dAArticulos = new DAArticulo();

            List<BOArticulo> articulos = new List<BOArticulo>();

            try
            {
                articulos = dAArticulos.ObtenerTodosArticulosxPuntoVenta(codigoPuntoVenta);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }            

            return articulos;
        }

        /// <summary>
        /// Este método actualiza el artículo en la bodega
        /// </summary>
        /// <param name="articuloBodega">Objeto de negocio de tipo ArticuloBodega</param>      
        /// <returns>bool</returns>
        public bool ActualizarArticuloBodega(ArticuloBodega articuloBodega)
        {
            if (articuloBodega==null)
            {
                EVOException e = new EVOException(errores.errArticuloBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ActualizarArticuloBodega en BLArticulo con el parámetro articuloBodega = {JsonConvert.SerializeObject(articuloBodega)}");

            if (string.IsNullOrEmpty(articuloBodega.CodigoArticulo))
            {
                EVOException e = new EVOException(errores.errArticuloBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(articuloBodega.WhsCode))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            if (articuloBodega.Stock==null)
            {
                EVOException e = new EVOException(errores.errArticuloBodegaStockNoInformado);

                logger.Error(e);

                throw e;
            }


            DAArticulo dAArticulo = new DAArticulo();

            try
            {
                dAArticulo.ActualizarArticuloBodega(articuloBodega);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;
        }

        /// <summary>
        /// Este método obtiene los artículos por el código de la bodega y por el código del artículo
        /// </summary>
        /// <param name="codigoBodega">Indica el valor del parametro del código de la bodega</param>
        /// <param name="codigoArticulo">Indica el valor del parametro del artículo</param>
        /// <returns>El artículo por el código de la bodega y el código del artículo</returns>
        public ArticuloBodega ObtenerArticuloxCodigoBodegaCodigoArticulo(string codigoBodega, string codigoArticulo)
        {
            if (string.IsNullOrEmpty(codigoBodega))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(codigoArticulo))
            {
                EVOException e = new EVOException(errores.errCodigoArticuloNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerArticuloxCodigoBodegaCodigoArticulo con los parámetros codigoBodega = {codigoBodega} , codigoArticulo = {codigoArticulo}");

            DAArticulo dAArticulos = new DAArticulo();

            ArticuloBodega articuloBodega = null;

            try
            {
                articuloBodega = dAArticulos.ObtenerArticuloxCodigoBodegaCodigoArticulo(codigoBodega, codigoArticulo);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (articuloBodega == null)
            {
                EVOException e = new EVOException(errores.errArticuloBodegaNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return articuloBodega;

        }

        /// <summary>
        /// Este método obtiene los artículo por la bodega
        /// </summary>
        /// <param name="buscarArticulo">Indica el valor del parametro por el cual se va a realizar la busqueda</param>
        /// <returns>El artículo de la bodega</returns>
        public List<ArticuloBodega> ObtenerArticulosBodega(BuscarArticuloBodegaSolicitud buscarArticulo)
        {
            if (buscarArticulo == null)
            {
                EVOException e = new EVOException(errores.errBuscarArticuloNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosArticulosxFiltro con los parámetros; {0}",
                JsonConvert.SerializeObject(buscarArticulo)));

            if (string.IsNullOrEmpty(buscarArticulo.CodigoBodega))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            DAArticulo dAArticulos = new DAArticulo();
            List<ArticuloBodega> articuloBodega = null;

            try
            {
                articuloBodega = dAArticulos.ObtenerArticulosBodegaxCodigoNombreArticulo(buscarArticulo);
            }
            catch (EVOException e)
            {
                logger.Error(e);

                throw e;
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return articuloBodega;
        }


        /// <summary>
        /// Este método retorna los empaques
        /// </summary>       
        /// <returns>List<BOEmpaque></returns>
        public List<BOEmpaque> ObtenerEmpaques()
        {
            logger.Info("Entró al método ObtenerEmpaques en EVO_WebApi - BLArticulo sin parámetros");

            DAArticulo dAArticulos = new DAArticulo();

            List<BOEmpaque> empaques = null;

            try
            {
                empaques = dAArticulos.ObtenerEmpaques();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }           

            return empaques;
        }
        #endregion
    }
}