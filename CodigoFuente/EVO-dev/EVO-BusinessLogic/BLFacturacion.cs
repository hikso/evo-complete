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
    public class BLFacturacion
    {
        #region Campos Privados

        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Métodos
        /// <summary>
        /// Obtiene las formas de pago
        /// </summary>
        /// <response>List<FormaPagoBO></response>
        public List<FormaPagoBO> ObtenerFormasPago()
        {
            logger.Info($"Entró al método ObtenerFormasPago en BLFacturacion - EVO_WebApi");

            DAFacturacion dAFacturacion = new DAFacturacion();

            List<FormaPagoBO> otrasFormasPago = null;

            try
            {
                otrasFormasPago = dAFacturacion.
                    ObtenerFormasPago();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return otrasFormasPago;

        }
              

        /// <summary>
        /// Obtiene las ultima de devuelta de una factura POS
        /// </summary>
        /// <param name="codigoPuntoVenta">Indica el código de punto de venta</param>
        /// <response>string</response>
        public string ObtenerUltimaDevuelta(string codigoPuntoVenta)
        {
            logger.Info($"Entró al método ObtenerUltimaDevuelta en BLFacturacion - EVO_WebApi con el parámetro codigoPuntoVenta = {codigoPuntoVenta}");

            if (string.IsNullOrEmpty(codigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();

            BOBodega bodega = bLBodega.ObtenerBodegaPorCodigo(codigoPuntoVenta);

            DAFacturacion dAFacturacion = new DAFacturacion();

            string ultimaDevuelta = null;

            try
            {
                ultimaDevuelta = dAFacturacion.ObtenerUltimaDevuelta(codigoPuntoVenta);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return ultimaDevuelta;

        }

        /// <summary>
        /// Obtiene las bancos
        /// </summary>
        /// <response>List<BancoBO></response>
        public List<BancoBO> ObtenerBancos()
        {
            logger.Info($"Entró al método ObtenerBancos en BLFacturacion - EVO_WebApi");

            DAFacturacion dAFacturacion = new DAFacturacion();

            List<BancoBO> bancos = null;

            try
            {
                bancos = dAFacturacion.ObtenerBancos();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return bancos;

        }

        /// <summary>
        /// Registra una factura
        /// </summary>
        /// <param name="body">Objeto de solicitud para registrar la factura</param>
        /// <response>bool</response>
        public bool AsignarFacturaPOS(FacturaRequestBO facturaRequestBO)
        {
            if (facturaRequestBO == null)
            {
                EVOException e = new EVOException(errores.errFacturaNoInformada);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método AsignarFacturaPOS en BLFacturacion - EVO_WebApi con los parametros facturaRequestBO = {JsonConvert.SerializeObject(facturaRequestBO)}");

            BOTipoFactura tipoFactura = ObtenerTipoFacturaxNombre(TiposFacturaEnum.POS);

            facturaRequestBO.TipoFacturaId = tipoFactura.TipoFacturaId;

            if (string.IsNullOrEmpty(facturaRequestBO.UserName))
            {
                EVOException e = new EVOException(errores.errUsuarioNoDirectorio);

                logger.Error(e);

                throw e;
            }          

            int nBackSlash = facturaRequestBO.UserName.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                facturaRequestBO.UserName = facturaRequestBO.UserName.Substring(nBackSlash + 1, facturaRequestBO.UserName.Length - nBackSlash - 1);
            }

            var DaUsuario = new DAUsuario();

            Usuario obtenerUsuario;

            try
            {
                obtenerUsuario = DaUsuario.ObtenerUsuarioPorUsuario(facturaRequestBO.UserName);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (obtenerUsuario == null)
            {
                EVOException e = new EVOException(errores.errUsuarioNoEVO);

                logger.Error(e);

                throw e;
            }

            facturaRequestBO.UsuarioId = obtenerUsuario.UsuarioId;

            if (string.IsNullOrEmpty(facturaRequestBO.CodigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();

            BOBodega bOBodega = bLBodega.ObtenerBodegaPorCodigo(facturaRequestBO.CodigoPuntoVenta);

            BLCajas bLCajas = new BLCajas();

            BOEstadoCajaResponse estadoCaja = bLCajas.ObtenerEstadoCaja(facturaRequestBO.CodigoPuntoVenta, facturaRequestBO.IP);

            if (!estadoCaja.AperturaCajaActual)
            {
                EVOException e = new EVOException(errores.errAperturaCajaNoRegistrada);

                logger.Error(e);

                throw e;
            }

            facturaRequestBO.CuadreCajaId = estadoCaja.CuadreCajaId;

            if (string.IsNullOrEmpty(facturaRequestBO.IdentificacionCliente))
            {
                EVOException e = new EVOException(errores.errIdentificacionClienteNoInformada);

                logger.Error(e);

                throw e;
            }

            BLSocioNegocio bLSocioNegocio = new BLSocioNegocio();

            //Verificar si no es necesario el try catch acá
            BOSocioNegocio bOSocioNegocio = bLSocioNegocio.ObtenerSocioNegocio(facturaRequestBO.IdentificacionCliente);

            if (facturaRequestBO.VendedorId <= 0)
            {
                EVOException e = new EVOException(errores.errVendedorIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BLVendedores bLVendedores = new BLVendedores();

            BOVendedorResponse bOVendedor = bLVendedores.ObtenerVendedor(facturaRequestBO.VendedorId);

            if (facturaRequestBO.TipoBasculaId <= 0)
            {
                EVOException e = new EVOException(errores.errTipoBasculaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BlBascula blBascula = new BlBascula();

            BOTipoBascula bOTipoBascula = blBascula.ObtenerTipoBasculaxId(facturaRequestBO.TipoBasculaId);

            if (facturaRequestBO.Articulos == null || facturaRequestBO.Articulos.Count == 0)
            {
                EVOException e = new EVOException(errores.errArticulosFacturaNoInformados);

                logger.Error(e);

                throw e;
            }

            List<BOImpuesto> impuestos = ObtenerImpuestos();         

            foreach (ArticuloRequestBO articulo in facturaRequestBO.Articulos)
            {
                if (articulo.Cantidad <= 0)
                {
                    EVOException e = new EVOException(errores.errCantidadArticuloFacturaNoInformada);

                    logger.Error(e);

                    throw e;
                }

                if (articulo.ValorUnitario <= 0)
                {
                    EVOException e = new EVOException(errores.errValorUnitarioNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (articulo.ValorUnitarioMasIVA <= 0)
                {
                    EVOException e = new EVOException(errores.errValorUnitarioIVANoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (articulo.PorcentajeIVA <= 0)
                {
                    EVOException e = new EVOException(errores.errPorcentajeIVANoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (articulo.PorcentajeIVA > 100)
                {
                    EVOException e = new EVOException(errores.errPorcentajeIVASuperaLimite);

                    logger.Error(e);

                    throw e;
                }

                if (articulo.Total <= 0)
                {
                    EVOException e = new EVOException(errores.errValorTotalArticuloNoInformado);

                    logger.Error(e);

                    throw e;
                }               

                if (string.IsNullOrEmpty(articulo.CodigoArticulo))
                {
                    EVOException e = new EVOException(errores.codigoArticuloNoInformado);

                    logger.Error(e);

                    throw e;
                }

                BLArticulo bLArticulo = new BLArticulo();

                BOArticulo bOArticulo = bLArticulo.ObtenerArticuloxCodigo(articulo.CodigoArticulo);

                if (string.IsNullOrEmpty(articulo.CodigoBodega))
                {
                    EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                    logger.Error(e);

                    throw e;
                }

                bOBodega = bLBodega.ObtenerBodegaPorCodigo(articulo.CodigoBodega);

                ArticuloBodega articuloBodega = bLArticulo.ObtenerArticuloxCodigoBodegaCodigoArticulo(articulo.CodigoBodega, articulo.CodigoArticulo);

                if (articuloBodega.Stock < articulo.Cantidad)
                {
                    EVOException e = new EVOException(string.Format(errores.errStockInsuficiente, articulo.CodigoArticulo));

                    logger.Error(e);

                    throw e;
                }

                if (string.IsNullOrEmpty(articulo.CodigoIVA))
                {
                    EVOException e = new EVOException(errores.errCodigoIVANoInformado);

                    logger.Error(e);

                    throw e;
                }

                BOImpuesto bOImpuesto = impuestos.FirstOrDefault(i => i.Codigo == articulo.CodigoIVA);

                if (bOImpuesto == null)
                {
                    EVOException e = new EVOException(errores.errCodigoImpuestoNoRegistrado);

                    logger.Error(e);

                    throw e;
                }

                articulo.IVAId = bOImpuesto.ImpuestoId;

            }

            if (facturaRequestBO.TotalAntesDescuento <= 0)
            {
                EVOException e = new EVOException(errores.errTotalAntesDescuentoNoInformado);

                logger.Error(e);

                throw e;
            }           

            if (bOBodega.FacturacionPorcentajeDescuento == null)
            {
                facturaRequestBO.PorcentajeDescuento = 0;
                facturaRequestBO.TotalConDescuento = 0;
            }
            else
            {
                facturaRequestBO.PorcentajeDescuento = bOBodega.FacturacionPorcentajeDescuento;

                if (facturaRequestBO.PorcentajeDescuento.Value <= 0)
                {
                    EVOException e = new EVOException(errores.errPorcentajeDescuentoNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (facturaRequestBO.PorcentajeDescuento.Value > 100)
                {
                    EVOException e = new EVOException(errores.errPorcentajeDescuentoMayo100);

                    logger.Error(e);

                    throw e;
                }                

                if (facturaRequestBO.TotalConDescuento==null || facturaRequestBO.TotalConDescuento.Value <= 0)
                {
                    EVOException e = new EVOException(errores.errValorDescuentoNoInformado);

                    logger.Error(e);

                    throw e;
                }               

            }

            if (facturaRequestBO.CantidadBolsas <= 0)
            {
                facturaRequestBO.PorcentajeCobroBolsa = 0;
            }
            else
            {
                if (facturaRequestBO.PorcentajeCobroBolsa <= 0)
                {
                    EVOException e = new EVOException(errores.errImpuestoBolsasNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (facturaRequestBO.ValorBolsa <= 0)
                {
                    EVOException e = new EVOException(errores.errValorBolsaNoInformado);

                    logger.Error(e);

                    throw e;
                }

                //TODO: ¿Donde se obtiene el stock de las bolsas por punto?.
                //int stockBolsa = 0;

                //if (stockBolsa < facturaRequestBO.CantidadBolsas)
                //{
                //    EVOException e = new EVOException(errores.errStockBolsaInsuficiente);

                //    logger.Error(e);

                //    throw e;
                //}    

                if (facturaRequestBO.ImpuestoBolsas <= 0)
                {
                    EVOException e = new EVOException(errores.errImpuestoBolsas);

                    logger.Error(e);

                    throw e;
                }

            }

            if (facturaRequestBO.ValorImpuestos<=0)
            {
                EVOException e = new EVOException(errores.errImpuestoNoInformado);

                logger.Error(e);

                throw e;
            }          

            if (facturaRequestBO.TotalDocumento <= 0)
            {
                EVOException e = new EVOException(errores.errTotalNoInformado);

                logger.Error(e);

                throw e;
            }

            List<BancoBO> bancos = ObtenerBancos();

            if (facturaRequestBO.FormasPago==null || facturaRequestBO.FormasPago.Count()==0)
            {
                EVOException e = new EVOException(errores.errFormasPagoNoInformadas);

                logger.Error(e);

                throw e;
            }

            List<FormaPagoBO> formasPago = ObtenerFormasPago();

            int efectivo = 0;

            foreach (FormaPagoRequestBO formaPago in facturaRequestBO.FormasPago)
            {
                if (formaPago.BancoId<=0)
                {
                    EVOException e = new EVOException(errores.errBancoIdNoInfomado);

                    logger.Error(e);

                    throw e;
                }                

                if (bancos.FirstOrDefault(b=>b.BancoId==formaPago.BancoId)==null)
                {
                    EVOException e = new EVOException(errores.errBancoNoRegistrado);

                    logger.Error(e);

                    throw e;
                }

                if (formaPago.ValorPago<=0)
                {
                    EVOException e = new EVOException(errores.errValoPagoNoAsignado);

                    logger.Error(e);

                    throw e;
                }

                if (formaPago.FormaPagoId <= 0)
                {
                    EVOException e = new EVOException(errores.errFormaPagoIdNoInformado);

                    logger.Error(e);

                    throw e;
                }

                FormaPagoBO tipoFormaPago = formasPago.FirstOrDefault(fp => fp.Id == formaPago.FormaPagoId);

                if (formaPago.FormaPagoId <= 0)
                {
                    EVOException e = new EVOException(errores.errFormaPagoNoRegistrado);

                    logger.Error(e);

                    throw e;
                }

                if (tipoFormaPago.Nombre==FormasPagoEnum.Bono_Porcicarnes.ToString().Replace("_"," "))
                {
                    if (string.IsNullOrEmpty(formaPago.ConsecutivoBono))
                    {
                        EVOException e = new EVOException(errores.errConsecutivoBonoNoInformado);

                        logger.Error(e);

                        throw e;
                    }

                    if (string.IsNullOrEmpty(formaPago.EmpleadoBono))
                    {
                        EVOException e = new EVOException(errores.errEmpleadoNoInformado);

                        logger.Error(e);

                        throw e;
                    }                   

                }

                if (tipoFormaPago.Nombre == FormasPagoEnum.Efectivo.ToString().Replace("_", " "))
                {
                    efectivo++;
                }                    

            }

            if (efectivo >= 2)
            {
                EVOException e = new EVOException(errores.errFormapagoEfectivo);

                logger.Error(e);

                throw e;
            }

            facturaRequestBO.Devuelta = null;
            facturaRequestBO.FechaFactura = DateTime.Now;

            if (string.IsNullOrEmpty(facturaRequestBO.Observaciones))
            {
                facturaRequestBO.Observaciones = string.Empty;
            }

            if (efectivo==1)
            {
                facturaRequestBO.Devuelta = facturaRequestBO.TotalDocumento - 
                    facturaRequestBO.FormasPago.Select(fp => fp.ValorPago).Sum();
            }

            DAFacturacion dAFacturacion = new DAFacturacion();

            try
            {
                dAFacturacion.AsignarFactura(facturaRequestBO);
            }
            catch (Exception e)
            {
                throw e;
            }

            return true;
        }

        /// <summary>
        /// Obtiene los Impuestos
        /// </summary>
        /// <response>List<BOImpuesto></response>
        public List<BOImpuesto> ObtenerImpuestos()
        {
            logger.Info($"Entró al método ObtenerImpuestos en BLFacturacion - EVO_WebApi");

            List<BOImpuesto> bOImpuestos = null;

            DAFacturacion dAFacturacion = new DAFacturacion();

            try
            {
                bOImpuestos = dAFacturacion.ObtenerImpuestos();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return bOImpuestos;

        }

        /// <summary>
        /// Obtiene tipo de factura por nombre
        /// </summary>
        /// <param name="tiposFacturaEnum">TiposFacturaEnum</param>
        /// <response>BOTipoFactura</response>
        public BOTipoFactura ObtenerTipoFacturaxNombre(TiposFacturaEnum tiposFacturaEnum)
        {
            logger.Info($"Entró al método ObtenerTiposFacturaxNombre en BLFacturacion - EVO_WebApi con parametros tiposFacturaEnum = {tiposFacturaEnum.ToString()}");

            BOTipoFactura tipoFactura = null;

            DAFacturacion dAFacturacion = new DAFacturacion();

            try
            {
                tipoFactura = dAFacturacion.ObtenerTiposFactura().FirstOrDefault(tf=> tf.Nombre==TiposFacturaEnum.POS.ToString());
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (tipoFactura==null)
            {
                EVOException e = new EVOException(errores.errTipoFacturaNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return tipoFactura;

        }
        #endregion
    }
}
