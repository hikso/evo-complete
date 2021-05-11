using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 4-Mar/2020
    /// Descripción      : Esta clase implementa los métodos de lógica de contenedores
    /// </summary>
    public class BLContenedor
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Obtiene todos los tipos de contenedores
        /// </summary>
        /// <response>List<TipoContenedorRespuesta></response>
        public List<BOTipoContenedorRespuesta> ObtenerTipoContenedores()
        {
            logger.Info($"Entró al método ObtenerTipoBasculas en blBasculas.");

            DAContenedor dAContenedores = new DAContenedor();

            List<BOTipoContenedorRespuesta> tipoContenedores = null;

            try
            {
                tipoContenedores = dAContenedores.ObtenerTipoContenedores();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return tipoContenedores;
        }

        /// <summary>
        /// Obtiene un objeto de negocio tipo de contenedor por el id
        /// </summary>
        /// <param name="tipoContenedorId">5</param>
        /// <returns>TipoContenedorRespuesta</returns>
        public BOTipoContenedorRespuesta ObtenerTipoContenedorxId(int tipoContenedorId)
        {
            if (tipoContenedorId <= 0)
            {
                EVOException e = new EVOException(errores.errContenedorIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerTipoContenedorxId con el parámetro: tipoContenedorId: {tipoContenedorId}");

            DAContenedor dAContenedores = new DAContenedor();

            BOTipoContenedorRespuesta tipoContenedor = null;

            try
            {
                tipoContenedor = dAContenedores.ObtenerTipoContenedorxId(tipoContenedorId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (tipoContenedor == null)
            {
                EVOException e = new EVOException(errores.errTipoContenedorNoExiste);

                logger.Error(e);

                throw e;
            }

            return tipoContenedor;
        }

        /// <summary>
        /// Registra el código de barras y obtiene los datos del código de barras
        /// </summary>
        /// <param name="pesajeId">Indica el id del pesaje</param>
        /// <param name="codigoBarras">Indica código de barras</param>
        /// <param name="usuario">Usuario del sistema</param>
        /// <response >BOCodigoBarras</response>
        public BOCodigoBarras AsignarCodigoBarras(int pesajeId, string codigoBarras, string usuario)
        {
            if (pesajeId <= 0)
            {
                EVOException e = new EVOException(errores.errPesajeIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(codigoBarras))
            {
                EVOException e = new EVOException(errores.errBarrasNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(usuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método AsignarCodigoBarras en BlContenedor con los parámetros pesajeId = {pesajeId} , codigoBarras = {codigoBarras}");

            BLPesaje bLPesaje = new BLPesaje();
            BOPesaje bOPesaje = null;

            try
            {
                bOPesaje = bLPesaje.ObtenerPesaje(pesajeId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BLClientesParametrizacion bLClientesParametrizacion = new BLClientesParametrizacion();
            BOParametrizacionResponse bOParametrizacionResponse = null;

            try
            {
                bOParametrizacionResponse = bLClientesParametrizacion.ObtenerPatrametrizacionesxCliente(bOPesaje.PesajeArticulo.DetalleEntrega.DetallePedido.Pedido.WhsCode);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOParametrizacionResponse.RecepcionPesajeCodigoBarras == null)
            {
                EVOException e = new EVOException(errores.errRecepcionPesajeCodigoBarrasNoInformado);

                logger.Error(e);

                throw e;
            }

            if (bOParametrizacionResponse.RecepcionPesajeCodigoBarras == false)
            {
                EVOException e = new EVOException(errores.errRecepcionPesajeCodigoBarrasNoPesaje);

                logger.Error(e);

                throw e;
            }

            if (bOParametrizacionResponse.RecepcionToleranciaSuperior == null || bOParametrizacionResponse.RecepcionToleranciaSuperior <= 0)
            {
                EVOException e = new EVOException(errores.errRecepcionToleranciaSuperiorNoInformado);

                logger.Error(e);

                throw e;
            }

            if (bOParametrizacionResponse.RecepcionToleranciaInferior == null || bOParametrizacionResponse.RecepcionToleranciaInferior <= 0)
            {
                EVOException e = new EVOException(errores.errRecepcionToleranciaSuperiorNoInformado);

                logger.Error(e);

                throw e;
            }

            BLArticulo bLArticulo = new BLArticulo();
            BOArticulo bOArticulo = null;

            try
            {
                bOArticulo = bLArticulo.ObtenerArticuloxCodigo(bOPesaje.PesajeArticulo.DetalleEntrega.DetallePedido.ItemCode);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOArticulo.SalUnitMsr == UnidadesMedidaEnum.UND.ToString())
            {
                EVOException e = new EVOException(errores.errMedidaUnidadNoPesable);

                logger.Error(e);

                throw e;
            }

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();
            int tamanio = 0;

            try
            {
                tamanio = int.Parse(bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANIO_CODIGO_BARRAS));
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (codigoBarras.Length != tamanio)
            {
                EVOException e = new EVOException(errores.errLogintudBarras);

                logger.Error(e);

                throw e;
            }

            int nBackSlash = usuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                usuario = usuario.Substring(nBackSlash + 1, usuario.Length - nBackSlash - 1);
            }

            BLUsuario bLUsuarios = new BLUsuario();

            Usuario boUsuario = null;

            try
            {
                boUsuario = bLUsuarios.ObtenerUsuarioPorUsuario(usuario);
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

            string expresion = string.Empty;

            try
            {
                expresion = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.EXPRESION_REGULAR_SOLO_NUMEROS);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            Match match = Regex.Match(codigoBarras, expresion);

            if (!match.Success)
            {
                EVOException e = new EVOException(errores.errBarrasSoloNumeros);

                logger.Error(e);

                throw e;
            }

            string codigoArticuloPesar = bOPesaje.PesajeArticulo.DetalleEntrega.DetallePedido.ItemCode;

            string codigoCliente = bOPesaje.PesajeArticulo.DetalleEntrega.DetallePedido.Pedido.SolicitudPara;

            BOCodigoBarras bOCodigoBarras = new BOCodigoBarras()
            {
                CodigoBarras = codigoBarras,
                Lote = int.Parse(codigoBarras.Substring(5, 5)).ToString()
            };

            string codigoArticuloBarras = $"{codigoCliente.Substring(codigoCliente.IndexOf("-") + 1)}-{int.Parse(codigoBarras.Substring(0, 5).ToString())}";

            if (codigoArticuloPesar != codigoArticuloBarras)
            {
                EVOException e = new EVOException(errores.errBarrasNoConcuerdaArticulo);

                logger.Error(e);

                throw e;
            }

            bOCodigoBarras.FechaVencimiento = $"{codigoBarras.Substring(11, 2)}/{codigoBarras.Substring(13, 2)}/{codigoBarras.Substring(15, 2)}";

            try
            {
                expresion = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.EXPRESION_REGULAR_FECHA_DDMMAA);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            match = Regex.Match(bOCodigoBarras.FechaVencimiento, expresion);

            if (!match.Success)
            {
                EVOException e = new EVOException(errores.errFechaFormatoDDMMYYY);

                logger.Error(e);

                throw e;
            }

            if (DateTime.Parse(bOCodigoBarras.FechaVencimiento) < DateTime.Now.Date)
            {
                EVOException e = new EVOException(errores.errFechaVencimientoMenor);

                logger.Error(e);

                throw e;
            }

            bOCodigoBarras.Unidades = int.Parse(codigoBarras.Substring(17, 5));

            if (bOCodigoBarras.Unidades <= 0)
            {
                EVOException e = new EVOException(errores.errUnidadesBarras);

                logger.Error(e);

                throw e;
            }

            string entero = codigoBarras.Substring(22, 13);
            string decimall = codigoBarras.Substring(35);

            bOCodigoBarras.Peso = decimal.Parse($"{entero}.{decimall}");

            if (bOCodigoBarras.Peso <= 0)
            {
                EVOException e = new EVOException(errores.errPesoBarras);

                logger.Error(e);

                throw e;
            }

            int estadoArticuloBarras = int.Parse(codigoBarras.Substring(10, 1));

            BOEstadoArticulo bOEstadoArticulo = null;

            int estadoArticulo = bOPesaje.PesajeArticulo.DetalleEntrega.DetallePedido.EstadoArticuloId;

            try
            {
                bOEstadoArticulo = bLArticulo.ObtenerEstadoArticuloxId(estadoArticuloBarras);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (estadoArticulo != estadoArticuloBarras)
            {
                EVOException e = new EVOException(errores.errEstadoArticuloCodigoBarras);

                logger.Error(e);

                throw e;
            }

            DAContenedor dAContenedor = new DAContenedor();

            try
            {
                dAContenedor.AsignarCodigoBarras(pesajeId, boUsuario.UsuarioId, bOCodigoBarras);
            }
            catch (Exception e)
            {
                throw e;
            }

            try
            {
                bOPesaje = bLPesaje.ObtenerPesaje(pesajeId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BOTipoContenedorRespuesta tipoBase = null;

            try
            {
                tipoBase = ObtenerTipoContenedorxNombre(TiposContenedorEnum.Base);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            bOPesaje.PesajeContenedor = bOPesaje.PesajeContenedor
               .Where(cp => cp.TipoContenedorId != tipoBase.TipoContenedorId)
               .ToList();

            List<BOCodigoBarrasResponse> codigosBarras = null;

            try
            {
                codigosBarras = ObtenerContenedoresCodigoBarras(pesajeId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (codigosBarras.Count >= bOPesaje.PesajeContenedor.Select(cp => cp.Cantidad).Sum())
            {
                bOCodigoBarras.InconsistenciaCodigoBarras = true;

                if (bOPesaje.PesoBasculaArticulos-bOParametrizacionResponse.RecepcionToleranciaInferior<0)
                {
                    EVOException e = new EVOException(errores.errPesajeToleranciaMenor);

                    logger.Error(e);

                    throw e;
                }
                
                if (bOPesaje.PesoCodigosBarras >= (bOPesaje.PesoBasculaArticulos - bOParametrizacionResponse.RecepcionToleranciaInferior) &&
                    bOPesaje.PesoCodigosBarras <= (bOPesaje.PesoBasculaArticulos + bOParametrizacionResponse.RecepcionToleranciaSuperior))
                {
                    bOCodigoBarras.InconsistenciaCodigoBarras = false;
                }

                try
                {
                    bLPesaje.ActualizarInconsistenciaCodigoBarras(bOPesaje.PesajeArticuloId, bOCodigoBarras.InconsistenciaCodigoBarras.Value);
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

            return bOCodigoBarras;

        }

        /// <summary>
        /// Obtiene todos los codigos de barras contenedores usados en el pesaje
        /// </summary>        
        /// <param name="pesajeId">Indica el id del pesaje</param>
        /// <response >List<BOCodigoBarrasResponse></response>
        public List<BOCodigoBarrasResponse> ObtenerContenedoresCodigoBarras(int pesajeId)
        {
            if (pesajeId <= 0)
            {
                EVOException e = new EVOException(errores.errPesajeIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerContenedoresCodigoBarras en BlContenedor con los parámetros pesajeId = {pesajeId}");

            BLPesaje bLPesaje = new BLPesaje();
            BOPesaje bOPesaje = null;

            try
            {
                bOPesaje = bLPesaje.ObtenerPesaje(pesajeId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            DAContenedor dAContenedor = new DAContenedor();

            List<BOCodigoBarrasResponse> bOCodigosBarrasResponses = null;

            try
            {
                bOCodigosBarrasResponses = dAContenedor.ObtenerContenedoresCodigoBarras(pesajeId);
            }
            catch (Exception e)
            {
                throw e;
            }

            return bOCodigosBarrasResponses;
        }

        /// <summary>
        /// Obtiene todos los contenedores usados en el pesaje
        /// </summary>
        /// <param name="pesajeId">Indica el id del pesaje</param>
        /// <response>List<BOPesajeContenedorResponse></response>
        public List<BOPesajeContenedorResponse> ObtenerContenedoresPesaje(int pesajeId)
        {
            if (pesajeId <= 0)
            {
                EVOException e = new EVOException(errores.errPesajeIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerContenedoresPesaje en BlContenedor con los parámetros pesajeId = {pesajeId}");

            BLPesaje bLPesaje = new BLPesaje();
            BOPesaje bOPesaje = null;

            try
            {
                bOPesaje = bLPesaje.ObtenerPesaje(pesajeId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            DAContenedor dAContenedor = new DAContenedor();

            List<BOPesajeContenedorResponse> bOPesajeContenedoresResponse = null;

            try
            {
                bOPesajeContenedoresResponse = dAContenedor.ObtenerContenedoresPesaje(pesajeId);
            }
            catch (Exception e)
            {
                throw e;
            }

            return bOPesajeContenedoresResponse;

        }

        /// <summary>
        /// Obtiene un objeto de negocio tipo de contenedor por el nombre
        /// </summary>
        /// <param name="tipoContenedorNombre">Nombre 1</param>
        /// <returns>TipoContenedorRespuesta</returns>
        public BOTipoContenedorRespuesta ObtenerTipoContenedorxNombre(TiposContenedorEnum tiposContenedorEnum)
        {
            logger.Info($"Entró al método ObtenerTipoContenedorxNombre con el parámetro: tipoContenedorNombre: {tiposContenedorEnum.ToString()}");

            DAContenedor dAContenedores = new DAContenedor();

            BOTipoContenedorRespuesta tipoContenedor = null;

            try
            {
                tipoContenedor = dAContenedores.ObtenerTipoContenedorxNombre(tiposContenedorEnum);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (tipoContenedor == null)
            {
                EVOException e = new EVOException(errores.errTipoContenedorNoExiste);

                logger.Error(e);

                throw e;
            }

            return tipoContenedor;
        }

    }
}
