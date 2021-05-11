using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using NLog;
using System;
using System.Collections.Generic;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 18-Dic/2019
    /// Descripción      : Esta clase implementa los métodos de lógica de báscula
    /// </summary>
    public class BlBascula
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Obtiene una lista de básculas 
        /// </summary>  
        /// <returns>List<TipoBascula></returns>
        public List<BOTipoBascula> ObtenerTipoBasculas()
        {
            logger.Info($"Entró al método ObtenerTipoBasculas en blBasculas.");

            DABascula daBascula = new DABascula();

            List<BOTipoBascula> basculas = null;

            try
            {
                basculas = daBascula.ObtenerTipoBasculas();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
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
            if (tipoBasculaId <= 0)
            {
                EVOException e = new EVOException(errores.errTipoBasculaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerTipoBasculaxId con el parámetro: tipoBasculaId: {tipoBasculaId}");

            DABascula dABasculas = new DABascula();

            BOTipoBascula tipoBascula = null;

            try
            {
                tipoBascula = dABasculas.ObtenerTipoBasculaxId(tipoBasculaId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
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
            logger.Info($"Entró al método ObtenerTipoBasculaxNombre con el parámetro: tipoBasculaEnum: {tipoBasculaEnum.ToString()}");

            DABascula dABasculas = new DABascula();

            BOTipoBascula tipoBascula = null;

            try
            {
                tipoBascula = dABasculas.ObtenerTipoBasculaxNombre(tipoBasculaEnum);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return tipoBascula;
        }
    }
}
