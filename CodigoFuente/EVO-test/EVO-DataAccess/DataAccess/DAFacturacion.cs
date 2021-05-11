using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 20-May/2020
    /// Descripción      : Se crea la clase de acceso a datos de Facturación
    /// </summary>
    public class DAFacturacion : DABase
    {
        #region Métodos
        /// <summary>
        /// Obtiene las formas de pago
        /// </summary>
        /// <response>List<FormaPagoBO></response>
        public List<FormaPagoBO> ObtenerFormasPago()
        {
            List<FormaPagoBO> otrasFormasPago = new List<FormaPagoBO>();
            List<EFFormaPago> eFOtrasFormasPago = null;

            using (Contexto contexto = new Contexto())
            {
                eFOtrasFormasPago = contexto.FormasPago
                    .Where(ofp => ofp.Activo)
                    .ToList();
            }

            if (eFOtrasFormasPago != null)
            {
                otrasFormasPago = mapper.Map<List<EFFormaPago>, List<FormaPagoBO>>(eFOtrasFormasPago);
            }

            return otrasFormasPago;
        }

        /// <summary>
        /// Obtiene los bancos
        /// </summary>
        /// <response>List<BancoBO></response>
        public List<BancoBO> ObtenerBancos()
        {
            List<BancoBO> bancos = new List<BancoBO>();
            List<EFBanco> eFBancos = null;

            using (Contexto contexto = new Contexto())
            {
                eFBancos = contexto.Bancos
                    .Where(ofp => ofp.Activo)
                    .ToList();
            }

            if (eFBancos != null)
            {
                bancos = mapper.Map<List<EFBanco>, List<BancoBO>>(eFBancos);
            }

            return bancos;
        }

        /// <summary>
        /// Obtiene los Impuestos
        /// </summary>
        /// <response>List<BOImpuesto></response>
        public List<BOImpuesto> ObtenerImpuestos()
        {
            List<BOImpuesto> impuestos = new List<BOImpuesto>();
            List<EFImpuesto> eFImpuestos = null;

            using (Contexto contexto = new Contexto())
            {
                eFImpuestos = contexto.Impuestos
                    .Where(i => i.Activo)
                    .ToList();
            }

            if (eFImpuestos != null)
            {
                impuestos = mapper.Map<List<EFImpuesto>, List<BOImpuesto>>(eFImpuestos);
            }

            return impuestos;
        }

        /// <summary>
        /// Obtiene los tipos de factura
        /// </summary>
        /// <response>List<BOTipoFactura></response>
        public List<BOTipoFactura> ObtenerTiposFactura()
        {
            List<BOTipoFactura> tiposFactura = new List<BOTipoFactura>();
            List<EFTipoFactura> eFTiposFactura = null;

            using (Contexto contexto = new Contexto())
            {
                eFTiposFactura = contexto.TiposFactura
                    .Where(i => i.Activo)
                    .ToList();
            }

            if (eFTiposFactura != null)
            {
                tiposFactura = mapper.Map<List<EFTipoFactura>, List<BOTipoFactura>>(eFTiposFactura);
            }

            return tiposFactura;
        }

        /// <summary>
        /// Obtiene las ultima de devuelta de una factura POS
        /// </summary>
        /// <param name="codigoPuntoVenta">Indica el código de punto de venta</param>
        /// <response>string</response>
        public string ObtenerUltimaDevuelta(string codigoPuntoVenta)
        {
            string ultimaDeveulta = null;
            EFFactura eFFactura = null;

            using (Contexto contexto=new Contexto())
            {
                eFFactura = contexto.Facturas.Include(i => i.CuadreCaja).OrderByDescending(o => o.FechaFactura)
                    .FirstOrDefault(f => f.CuadreCaja.Caja.CodigoPuntoVenta == codigoPuntoVenta);
            }

            if (eFFactura!=null)
            {
                ultimaDeveulta = eFFactura.Devuelta == null ? string.Empty : eFFactura.Devuelta.Value.ToString();
            }

            return ultimaDeveulta;
        }

        /// <summary>
        /// Registra una factura
        /// </summary>
        /// <param name="body">Objeto de solicitud para registrar la factura</param>
        /// <response>bool</response>
        public bool AsignarFactura(FacturaRequestBO facturaRequestBO)
        {
            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        EFFactura eFFactura = new EFFactura()
                        {
                            TipoFacturaId=facturaRequestBO.TipoFacturaId,
                            Identificacion = facturaRequestBO.IdentificacionCliente,
                            UsuarioId = facturaRequestBO.UsuarioId,
                            VendedorId = facturaRequestBO.VendedorId,
                            TipoBasculaId = facturaRequestBO.TipoBasculaId,
                            CuadreCajaId = facturaRequestBO.CuadreCajaId,
                            Consecutivo = (contexto.Facturas.Where(f => f.CuadreCaja.Caja.CodigoPuntoVenta == facturaRequestBO.CodigoPuntoVenta).Count() + 1).ToString(),
                            FechaFactura = facturaRequestBO.FechaFactura,
                            Observaciones = facturaRequestBO.Observaciones,
                            TotalSinDescuento = facturaRequestBO.TotalAntesDescuento,
                            TotalConDescuento = facturaRequestBO.TotalConDescuento,
                            CantidadBolsas = facturaRequestBO.CantidadBolsas,
                            ValorBolsa = facturaRequestBO.ValorBolsa==null?null: facturaRequestBO.ValorBolsa,
                            PorcentajeCobroBolsa = facturaRequestBO.PorcentajeCobroBolsa==null?null:facturaRequestBO.PorcentajeCobroBolsa,
                            ImpuestoBolsas = facturaRequestBO.ImpuestoBolsas==null?null:facturaRequestBO.ImpuestoBolsas,
                            TotalImpuestos = facturaRequestBO.ValorImpuestos,
                            TotalDocumento=facturaRequestBO.TotalDocumento,
                            Devuelta=facturaRequestBO.Devuelta==null?null : facturaRequestBO.Devuelta
                        };

                        contexto.Add(eFFactura);
                        contexto.SaveChanges();

                        List<EFDetalleFactura> efdetallesFactura = facturaRequestBO.Articulos.Select(a =>
                               new EFDetalleFactura()
                               {
                                   FacturaId = eFFactura.FacturaId,
                                   CodigoArticulo = a.CodigoArticulo,
                                   Cantidad = a.Cantidad,
                                   PrecioUnitario = a.ValorUnitario,
                                   PrecioUnitarioMasIVA = a.ValorUnitarioMasIVA,
                                   Total = a.Total,
                                   IVAId = a.IVAId,
                                   Eliminado = a.Eliminado,
                                   CodigoBodega = a.CodigoBodega,
                                   PorcentajeIVA = a.PorcentajeIVA
                               }).ToList();

                        contexto.AddRange(efdetallesFactura);

                        contexto.SaveChanges();

                        List<EFDetalleFacturaFormaPago> efFormasPagoFactura = facturaRequestBO.FormasPago.Select(f =>
                               new EFDetalleFacturaFormaPago()
                               {
                                  FacturaId= eFFactura.FacturaId,
                                  FormaPagoId =f.FormaPagoId,
                                  ValorPago=f.ValorPago,
                                  BancoId=f.BancoId==null?null:f.BancoId,
                                  ConsecutivoBono=f.ConsecutivoBono==null?null:f.ConsecutivoBono,
                                  EmpleadoBono=f.EmpleadoBono==null?null:f.EmpleadoBono
                               }).ToList();

                        contexto.AddRange(efFormasPagoFactura);

                        contexto.SaveChanges();

                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();

                        throw e;
                    }
                }
            }

            return true;
        }
        #endregion
    }
}
