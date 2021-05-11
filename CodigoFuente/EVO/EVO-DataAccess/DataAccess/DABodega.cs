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
    /// Autor            : Juan Camilo Usuga
    /// Fecha de Creación: 21-Sep/2019
    /// Descripción      : Esta clase implementa los métodos de acceso a datos de las bodegas
    /// </summary>
    public class DABodega : DABase
    {
        #region Métodos Públicos
        /// <summary>
        /// Este método obtiene una bodega por el código
        /// </summary>
        /// <param name="codigo">indica el valor de el código</param>
        /// <returns>Instancia de tipo Bodega</returns>
        public BOBodega ObtenerBodegaPorCodigo(string codigo)
        {
            EFBodega eFBodega = null;

            using (Contexto contexto = new Contexto())
            {
                eFBodega = contexto.Bodegas.FirstOrDefault(b => b.WhsCode == codigo);                                    
            }

            BOBodega bodega = null;

            if (eFBodega!=null)
            {
                bodega = this.mapper.Map<EFBodega, BOBodega>(eFBodega);
            }

            return bodega;
        }

        /// <summary>
        /// Obtienen las bodegas(Punto de Venta) por usuario
        /// </summary>
        /// <param name="usuarioId">Indica el id del usuario</param>
        /// <returns>Lista de tipo BOBodega/returns>
        public List<BOBodega> ObtenerBodegasPuntosVentaPorUsuario(int usuarioId)
        {
            List<EFBodega> eFBodegas = null;

            using (Contexto contexto = new Contexto())
            {
                eFBodegas = contexto.UsuariosBodega
                    .Include(i=>i.Bodega)
                    .Where(ub => ub.UsuarioId == usuarioId)
                    .Select(ub=>ub.Bodega).ToList();
            }

            List<BOBodega> bodegas = new List<BOBodega>();

            if (eFBodegas.Count() > 0)
            {
                bodegas = this.mapper.Map<List<EFBodega>, List<BOBodega>>(eFBodegas);
            }

            return bodegas;
        }

        /// <summary>
        /// Este método obtiene las bodega por el prefijo 
        /// </summary>
        /// <param name="prefijo">Indica el prefijo de la bodega example: PB-PT</param>
        /// <returns>Lista de Bodega</returns>
        public List<BOBodega> ObtenerBodegasxPrefijo(string prefijo)
        {
            List<EFBodega> eFBodegas = null;

            using (Contexto contexto = new Contexto())
            {             

                eFBodegas = contexto.Bodegas.Where(a=>a.WhsCode.Contains("-")).Where(b=>b.WhsCode.Substring(0,b.WhsCode.IndexOf("-"))== prefijo).ToList();
            }

            List<BOBodega> bodegas = new List<BOBodega>();

            if (eFBodegas.Count() > 0)
            {
                bodegas = this.mapper.Map<List<EFBodega>, List<BOBodega>>(eFBodegas);
            }

            return bodegas;
        }

        /// <summary>
        /// Este método obtiene las bodega por el prefijo 
        /// </summary>
        /// <param name="codigoArticulo">Indica el código del artículo : PT-1485</param>
        /// <param name="prefijoBodega">Indica el prefijo de la bodega : PB</param>
        /// <returns>List<Bodega></returns>
        public List<BOBodega> ObtenerBodegasxFiltro(string codigoArticulo,string prefijoBodega)
        {
            List<EFArticuloBodega> eFArticuloBodegas = null;
            List<EFBodega> eFBodegas = null;

            using (Contexto contexto = new Contexto())
            {
                eFArticuloBodegas = contexto.ArticulosXBodega.Where(ab => ab.ItemCode == codigoArticulo && ab.WhsCode.Substring(0,2) == prefijoBodega).ToList();
                eFBodegas = contexto.Bodegas.Where(b => eFArticuloBodegas.FirstOrDefault(ab => ab.WhsCode == b.WhsCode) != null).ToList();
            }

            List<BOBodega> bodegas = new List<BOBodega>();

            if (eFBodegas.Count() > 0)
            {
                bodegas = this.mapper.Map<List<EFBodega>,List<BOBodega>>(eFBodegas);
            }

            return bodegas;
        }
        #endregion
    }
}