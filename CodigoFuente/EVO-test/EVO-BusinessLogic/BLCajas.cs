using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Newtonsoft.Json;
using NLog;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 20-May/2020
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de Cajas del punto de venta
    /// </summary>
    public class BLCajas
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos

        /// <summary>
        /// Obtiene la caja por código punto de venta y IP
        /// </summary>
        /// <param name="codigoPuntoVenta">Código del punto de venta</param>
        /// <param name="IP">IP de la caja</param>
        /// <response>BOCaja</response>
        public BOCaja ObtenerCaja(string codigoPuntoVenta, string IP)
        {
            logger.Info($"Entró al método ObtenerCaja en BLCajas con los parámetros codigoPuntoVenta = {codigoPuntoVenta},IP = {IP}");

            if (string.IsNullOrEmpty(codigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();
            BOBodega puntoVenta = null;

            try
            {
                puntoVenta = bLBodega.ObtenerBodegaPorCodigo(codigoPuntoVenta);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (string.IsNullOrEmpty(IP))
            {
                EVOException e = new EVOException(errores.errIPNoInformada);

                logger.Error(e);

                throw e;
            }

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            string expresion = string.Empty;

            try
            {
                expresion = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.EXPRESION_REGULAR_IP);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            Match match = Regex.Match(IP, expresion);

            if (!match.Success)
            {
                EVOException e = new EVOException(errores.errIPFormatoIncorrecto);

                logger.Error(e);

                throw e;
            }

            DACajas dACajas = new DACajas();

            BOCaja bOCaja = null;

            try
            {
                bOCaja = dACajas.ObtenerCaja(codigoPuntoVenta, IP);
            }
            catch (EVOException e)
            {
                throw e;
            }

            //if (bOCaja == null)
            //{
            //    EVOException e = new EVOException(errores.errCajaNoRegistrada);

            //    logger.Error(e);

            //    throw e;
            //}

            return bOCaja;

        }

        /// <summary>
        /// Obtiene estado del cuadre de caja
        /// </summary>
        /// <param name="nombreEstadoCuadreCaja">Apertura</param>       
        /// <response>BOCaja</response>
        public BOEstadoCuadreCaja ObtenerEstadoCuadreCaja(EstadosCuadreCajaEnum estadosCuadreCajaEnum)
        {
            logger.Info($"Entró al método ObtenerEstadoCuadreCaja en BLCajas con los parámetros estadosCuadreCajaEnum = {estadosCuadreCajaEnum}");

            DACajas dACajas = new DACajas();

            BOEstadoCuadreCaja bOEstadoCuadreCaja = null;

            try
            {
                bOEstadoCuadreCaja = dACajas.ObtenerEstadoCuadreCaja(estadosCuadreCajaEnum);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOEstadoCuadreCaja == null)
            {
                EVOException e = new EVOException(errores.errEstadoCuadreCajaNoInformado);

                logger.Error(e);

                throw e;
            }

            return bOEstadoCuadreCaja;

        }

        /// <summary>
        /// Obtiene el estado de la apertura de caja por punto de venta
        /// </summary>
        /// <param name="codigoPuntoVenta">Indica el código del punto de venta</param>
        /// <response>BOAperturaCajaResponse</response>
        public BOAperturaCajaResponse ObtenerAperturaCaja(string codigoPuntoVenta, string IP)
        {
            logger.Info($"Entró al método ObtenerAperturaCaja en BLCajas con los parámetros codigoPuntoVenta = {codigoPuntoVenta},IP = {IP}");

            if (string.IsNullOrEmpty(codigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();
            BOBodega puntoVenta = null;

            try
            {
                puntoVenta = bLBodega.ObtenerBodegaPorCodigo(codigoPuntoVenta);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (string.IsNullOrEmpty(IP))
            {
                EVOException e = new EVOException(errores.errIPNoInformada);

                logger.Error(e);

                throw e;
            }

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            string expresion = string.Empty;

            try
            {
                expresion = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.EXPRESION_REGULAR_IP);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            Match match = Regex.Match(IP, expresion);

            if (!match.Success)
            {
                EVOException e = new EVOException(errores.errIPFormatoIncorrecto);

                logger.Error(e);

                throw e;
            }

            DACajas dACajas = new DACajas();

            BOCaja bOCaja = null;

            try
            {
                bOCaja = dACajas.ObtenerCaja(codigoPuntoVenta, IP);
            }
            catch (EVOException e)
            {
                throw e;
            }

            if (bOCaja == null)
            {
                EVOException e = new EVOException(errores.errCajaNoRegistrada);

                logger.Error(e);

                throw e;
            }

            BOAperturaCajaResponse bOAperturaCajaResponse = new BOAperturaCajaResponse()
            {
                FechaApertura = DateTime.Now.ToString("dd/MM/yyy"),
                FechaCierre = DateTime.Now.ToString("dd/MM/yyy"),
                ValorAsignado = bOCaja.ValorAsignado
            };

            return bOAperturaCajaResponse;

        }

        public BOEstadoCajaResponse ObtenerEstadoCaja(string codigoPuntoVenta, string IP)
        {
            logger.Info($"Entró al método ObtenerEstadoCaja en BLCajas con los parámetros codigoPuntoVenta = {codigoPuntoVenta},IP = {IP}");

            if (string.IsNullOrEmpty(codigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();
            BOBodega puntoVenta = null;

            try
            {
                puntoVenta = bLBodega.ObtenerBodegaPorCodigo(codigoPuntoVenta);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (string.IsNullOrEmpty(IP))
            {
                EVOException e = new EVOException(errores.errIPNoInformada);

                logger.Error(e);

                throw e;
            }

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            string expresion = string.Empty;

            try
            {
                expresion = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.EXPRESION_REGULAR_IP);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            Match match = Regex.Match(IP, expresion);

            if (!match.Success)
            {
                EVOException e = new EVOException(errores.errIPFormatoIncorrecto);

                logger.Error(e);

                throw e;
            }

            DACajas dACajas = new DACajas();

            BOCaja bOCaja = null;

            try
            {
                bOCaja = dACajas.ObtenerCaja(codigoPuntoVenta, IP);
            }
            catch (EVOException e)
            {
                throw e;
            }

            if (bOCaja == null)
            {
                EVOException e = new EVOException(errores.errCajaNoRegistrada);

                logger.Error(e);

                throw e;
            }

            BOEstadoCuadreCaja bOEstadoCuadreCaja = null;

            try
            {
                bOEstadoCuadreCaja = ObtenerEstadoCuadreCaja(EstadosCuadreCajaEnum.Apertura);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            string fecha = DateTime.Today.AddDays(-1).ToString("dd/MM/yyyy");

            BOEstadoCajaResponse bOEstadoCajaResponse = new BOEstadoCajaResponse()
            {
                AperturaCajaActual = false,
                CierreCajaAnterior = false
            };

            if (bOCaja.CuadresCaja.Where(cc => cc.EstadoCuadreCajaId == bOEstadoCuadreCaja.EstadoCuadreCajaId && cc.FechaCuadre.ToString("dd/MM/yyyy") == fecha).Count() > 0)
            {
                try
                {
                    bOEstadoCuadreCaja = ObtenerEstadoCuadreCaja(EstadosCuadreCajaEnum.Cierre);
                }
                catch (EVOException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }

                if (bOCaja.CuadresCaja.Where(cc => cc.EstadoCuadreCajaId == bOEstadoCuadreCaja.EstadoCuadreCajaId && cc.FechaCuadre.ToString("dd/MM/yyyy") == fecha).Count() > 0)
                {
                    bOEstadoCajaResponse.CierreCajaAnterior = true;
                }
            }

            fecha = DateTime.Today.ToString("dd/MM/yyyy");

            try
            {
                bOEstadoCuadreCaja = ObtenerEstadoCuadreCaja(EstadosCuadreCajaEnum.Apertura);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOCaja.CuadresCaja.Where(cc => cc.EstadoCuadreCajaId == bOEstadoCuadreCaja.EstadoCuadreCajaId && cc.FechaCuadre.ToString("dd/MM/yyyy") == fecha).Count() > 0)
            {
                bOEstadoCajaResponse.AperturaCajaActual = true;
                bOEstadoCajaResponse.CuadreCajaId = bOCaja.CuadresCaja.FirstOrDefault(cc => cc.EstadoCuadreCajaId == bOEstadoCuadreCaja.EstadoCuadreCajaId && cc.FechaCuadre.ToString("dd/MM/yyyy") == fecha).CuadreCajaId;
            }

            return bOEstadoCajaResponse;
        }

        /// <summary>
        /// Obtiene una inconsistencia
        /// </summary>
        /// <param name="inconsistenciasEnum">Reponer faltante</param>       
        /// <response>BOInconsistencia</response>
        public BOInconsistencia ObtenerInconsistencia(InconsistenciasEnum inconsistenciasEnum)
        {
            logger.Info($"Entró al método ObtenerInconsistencia en BLCajas con los parámetros inconsistenciasEnum = {inconsistenciasEnum}");

            DACajas dACajas = new DACajas();

            BOInconsistencia bOInconsistencia = null;

            try
            {
                bOInconsistencia = dACajas.ObtenerInconsistencia(inconsistenciasEnum);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOInconsistencia == null)
            {
                EVOException e = new EVOException(errores.errInconsistenciaNoRegistrada);

                logger.Error(e);

                throw e;
            }

            return bOInconsistencia;

        }

        /// <summary>
        /// Registrar la apertura de caja
        /// </summary>
        /// <param name="body">Solicitud para el registro de la apertura de caja</param>
        /// <response>Bool</response>
        public string AsignarAperturaCaja(BOAperturaCajaRequest bOAperturaCajaRequest)
        {
            if (bOAperturaCajaRequest == null)
            {
                EVOException e = new EVOException(errores.errAperturaCajaRequestNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método AsignarAperturaCaja en BLCajas con los parámetros {JsonConvert.SerializeObject(bOAperturaCajaRequest)}");

            if (string.IsNullOrEmpty(bOAperturaCajaRequest.CodigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();
            BOBodega puntoVenta = null;

            try
            {
                puntoVenta = bLBodega.ObtenerBodegaPorCodigo(bOAperturaCajaRequest.CodigoPuntoVenta);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (string.IsNullOrEmpty(bOAperturaCajaRequest.IP))
            {
                EVOException e = new EVOException(errores.errIPNoInformada);

                logger.Error(e);

                throw e;
            }

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            string expresion = string.Empty;

            try
            {
                expresion = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.EXPRESION_REGULAR_IP);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            Match match = Regex.Match(bOAperturaCajaRequest.IP, expresion);

            if (!match.Success)
            {
                EVOException e = new EVOException(errores.errIPFormatoIncorrecto);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(bOAperturaCajaRequest.Usuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            int nBackSlash = bOAperturaCajaRequest.Usuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                bOAperturaCajaRequest.Usuario = bOAperturaCajaRequest.Usuario.Substring(nBackSlash + 1, bOAperturaCajaRequest.Usuario.Length - nBackSlash - 1);
            }

            BLUsuario bLUsuarios = new BLUsuario();

            Usuario usuario = null;

            try
            {
                usuario = bLUsuarios.ObtenerUsuarioPorUsuario(bOAperturaCajaRequest.Usuario);
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

            bOAperturaCajaRequest.UsuarioId = usuario.UsuarioId;

            if (bOAperturaCajaRequest.ValorApertura <= 0)
            {
                EVOException e = new EVOException(errores.errValorAperturaNoInformado);

                logger.Error(e);

                throw e;
            }

            BOCaja bOCaja = null;

            try
            {
                bOCaja = ObtenerCaja(bOAperturaCajaRequest.CodigoPuntoVenta, bOAperturaCajaRequest.IP);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            bOAperturaCajaRequest.CajaId = bOCaja.CajaId;
            bOAperturaCajaRequest.FechaCuadre = DateTime.Now;
            bOAperturaCajaRequest.ValorAsignado = bOCaja.ValorAsignado;

            bOAperturaCajaRequest.Consecutivo = bOCaja.CuadresCaja.Count == 0 ? 1 : bOCaja.CuadresCaja.Count + 1;

            BOEstadoCuadreCaja bOEstadoCuadreCaja = null;

            try
            {
                bOEstadoCuadreCaja = ObtenerEstadoCuadreCaja(EstadosCuadreCajaEnum.Apertura);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            bOAperturaCajaRequest.EstadoCuadreCajaId = bOEstadoCuadreCaja.EstadoCuadreCajaId;

            BOInconsistencia bOInconsistencia = null;

            if (bOAperturaCajaRequest.ValorApertura < bOAperturaCajaRequest.ValorAsignado)
            {
                bOAperturaCajaRequest.ValorFaltanteSobrante = bOAperturaCajaRequest.ValorAsignado - bOAperturaCajaRequest.ValorApertura;

                try
                {
                    bOInconsistencia = ObtenerInconsistencia(InconsistenciasEnum.Reponer_faltante);
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

            if (bOAperturaCajaRequest.ValorApertura > bOAperturaCajaRequest.ValorAsignado)
            {
                bOAperturaCajaRequest.ValorFaltanteSobrante = bOAperturaCajaRequest.ValorApertura - bOAperturaCajaRequest.ValorAsignado;

                try
                {
                    bOInconsistencia = ObtenerInconsistencia(InconsistenciasEnum.Consignar_sobrante);
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

            bOAperturaCajaRequest.InconsistenciaId = null;

            if (bOInconsistencia != null)
            {
                bOAperturaCajaRequest.InconsistenciaId = bOInconsistencia.InconsistenciaId;
            }

            DACajas dACajas = new DACajas();

            try
            {
                dACajas.AsignarAperturaCaja(bOAperturaCajaRequest);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOInconsistencia != null)
            {
                return string.Format(errores.errInconsistencia, bOInconsistencia.Nombre);
            }

            return string.Empty;

        }
        #endregion
    }
}
