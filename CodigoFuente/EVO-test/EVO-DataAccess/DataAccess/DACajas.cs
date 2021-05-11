using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 12-Abr/2020
    /// Descripción      : Se crea la clase de acceso a datos de Cajas
    /// </summary>
    public class DACajas : DABase
    {
        /// <summary>
        /// Obtiene la caja por código punto de venta y IP
        /// </summary>
        /// <param name="codigoPuntoVenta">Código del punto de venta</param>
        /// <param name="IP">IP de la caja</param>
        /// <response>BOCaja</response>
        public BOCaja ObtenerCaja(string codigoPuntoVenta, string iP)
        {
            BOCaja bOCaja = null;
            EFCaja eFCaja = null;

            using (Contexto contexto = new Contexto())
            {
                eFCaja = contexto.Cajas
                    .Include(i => i.CuadresCaja)
                    .FirstOrDefault(c => c.CodigoPuntoVenta == codigoPuntoVenta && c.Activo && c.IP == iP);
            }

            if (eFCaja != null)
            {
                bOCaja = this.mapper.Map<EFCaja, BOCaja>(eFCaja);
            }

            return bOCaja;

        }

        /// <summary>
        /// Obtiene estado del cuadre de caja
        /// </summary>
        /// <param name="nombreEstadoCuadreCaja">Apertura</param>       
        /// <response>BOCaja</response>
        public BOEstadoCuadreCaja ObtenerEstadoCuadreCaja(EstadosCuadreCajaEnum estadosCuadreCajaEnum)
        {
            BOEstadoCuadreCaja bOEstadoCuadreCaja = null;
            EFEstadoCuadreCaja eFEstadoCuadreCaja = null;

            using (Contexto contexto = new Contexto())
            {
                eFEstadoCuadreCaja = contexto.EstadosCuadreCaja.FirstOrDefault(ecc => ecc.Nombre == estadosCuadreCajaEnum.ToString() && ecc.Activo);
            }

            if (eFEstadoCuadreCaja != null)
            {
                bOEstadoCuadreCaja = this.mapper.Map<EFEstadoCuadreCaja, BOEstadoCuadreCaja>(eFEstadoCuadreCaja);
            }

            return bOEstadoCuadreCaja;
        }

        /// <summary>
        /// Obtiene una inconsistencia
        /// </summary>
        /// <param name="inconsistenciasEnum">Reponer faltante</param>       
        /// <response>BOInconsistencia</response>
        public BOInconsistencia ObtenerInconsistencia(InconsistenciasEnum inconsistenciasEnum)
        {
            BOInconsistencia bOInconsistencia = null;
            EFInconsistencia eFInconsistencia = null;

            using (Contexto contexto = new Contexto())
            {
                eFInconsistencia = contexto.Inconsistencias
                    .FirstOrDefault(ecc => ecc.Nombre == inconsistenciasEnum.ToString().Replace("_", " ") && ecc.Activo);
            }

            if (eFInconsistencia != null)
            {
                bOInconsistencia = this.mapper.Map<EFInconsistencia, BOInconsistencia>(eFInconsistencia);
            }

            return bOInconsistencia;
        }

        /// <summary>
        /// Registrar la apertura de caja
        /// </summary>
        /// <param name="body">Solicitud para el registro de la apertura de caja</param>
        /// <response>Bool</response>
        public bool AsignarAperturaCaja(BOAperturaCajaRequest bOAperturaCajaRequest)
        {
            //TODO: Verificar pq no mapea = EFCuadreCaja eFCuadreCaja = this.mapper.Map<BOAperturaCajaRequest, EFCuadreCaja>(bOAperturaCajaRequest);
            EFCuadreCaja eFCuadreCaja = new EFCuadreCaja()
            {
                CajaId = bOAperturaCajaRequest.CajaId,
                Consecutivo = bOAperturaCajaRequest.Consecutivo,
                EstadoCuadreCajaId = bOAperturaCajaRequest.EstadoCuadreCajaId,
                FechaCuadre = bOAperturaCajaRequest.FechaCuadre,
                UsuarioId = bOAperturaCajaRequest.UsuarioId,
                InconsistenciaId = bOAperturaCajaRequest.InconsistenciaId,
                ValorApertura = bOAperturaCajaRequest.ValorApertura,
                ValorAsignado = bOAperturaCajaRequest.ValorAsignado,
                ValorFaltanteSobrante = bOAperturaCajaRequest.ValorFaltanteSobrante
            };


            using (Contexto contexto = new Contexto())
            {
                contexto.CuadresCaja.Add(eFCuadreCaja);
                contexto.SaveChanges();
            }

            return true;
        }
    }
}
