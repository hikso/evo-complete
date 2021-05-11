using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 3-Mar/2020
    /// Descripción      : Implementa el acceso a datos de las básculas
    /// </summary>
    public class DABascula : DABase
    {
        /// <summary>
        /// Obtiene todas las básculas
        /// </summary>  
        /// <returns>List<TipoBascula></returns>
        public List<BOTipoBascula> ObtenerTipoBasculas()
        {
            List<BOTipoBascula> basculas = new List<BOTipoBascula>();

            List<EFTipoBascula> eFBasculas = null;

            using (Contexto contexto = new Contexto())
            {
                eFBasculas = contexto.TiposBascula.Where(tb => tb.Activo).ToList();
            }

            if (eFBasculas.Count >= 0)
            {
                basculas = this.mapper.Map<List<EFTipoBascula>,List<BOTipoBascula>> (eFBasculas);
            }

            return basculas;

        }

        /// <summary>
        /// Obtiene el objeto de negocio TipoBascula por Id
        /// </summary>
        /// <param name="tipoBasculaId"></param>
        /// <returns>TipoBascula</returns>
        public BOTipoBascula ObtenerTipoBasculaxId(int tipoBasculaId)
        {
            BOTipoBascula tipoBascula = null;
            EFTipoBascula eFTipoBascula = null;

            using (Contexto contexto = new Contexto())
            {
                eFTipoBascula = contexto.TiposBascula.FirstOrDefault(d => d.TipoBasculaId == tipoBasculaId);
            }

            if (eFTipoBascula != null)
            {
                tipoBascula = this.mapper.Map<EFTipoBascula, BOTipoBascula>(eFTipoBascula);
            }

            return tipoBascula;
        }


        /// <summary>
        /// Obtiene el objeto de negocio TipoBascula por nombre
        /// </summary>
        /// <param name="tipoBasculaEnum">Nombre la báscula</param>
        /// <returns>TipoBascula</returns>
        public BOTipoBascula ObtenerTipoBasculaxNombre(TiposBasculaEnum tipoBasculaEnum)
        {
            BOTipoBascula tipoBascula = null;
            EFTipoBascula eFTipoBascula = null;

            using (Contexto contexto = new Contexto())
            {
                eFTipoBascula = contexto.TiposBascula.FirstOrDefault(d => d.Nombre == tipoBasculaEnum.ToString());
            }

            if (eFTipoBascula != null)
            {
                tipoBascula = this.mapper.Map<EFTipoBascula, BOTipoBascula>(eFTipoBascula);
            }

            return tipoBascula;
        }
    }
}
