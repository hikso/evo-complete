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
    /// Autor            : Kevin Restrepo Giraldo
    /// Fecha de Creación: 12-Ago/2019
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de los Modulos
    /// </summary>
    public class BLModulo
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos públicos
        /// <summary>
        /// Este método obtiene los Modulos creados en el sistema
        /// </summary>
        /// <param name="desde">Indica el número de registro desde el cuál se deben cargar los registros</param>
        /// <param name="hasta">Indica el número de registro hasta el cuál se deben cargar los registros</param>
        /// <returns>Lista de modulos de tipo Modulo</returns>
        public List<Modulo> obtenerTodosModulos(int desde, int hasta)
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

            logger.Info(string.Format("Entró al método obtenerTodosModulos con los parámetros: Desde: {0}, Hasta: {1}",
               desde, hasta));

            DAModulo DAmodulos = new DAModulo();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            //Se valida que no se estén pidiendo más registros que los que se encuentren actualmente configurados en la tabla de parámetros generales
            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch
            {
                Exception e = new Exception(errores.errObtenerValorPorNombre);
                    
                logger.Error(e);

                throw e;
            }

          int maximoPaginacion = int.Parse(valorPaginacion);

            if ((hasta - desde) > maximoPaginacion)
            {
                string errorPaginacionExcedida = string.Format(errores.errPaginacionSuperada, maximoPaginacion);

                throw new Exception(errorPaginacionExcedida);
            }

            List<Modulo> listaModulos = new List<Modulo>();

            try
            {
                listaModulos = DAmodulos.obtenerTodosModulos(desde, hasta);

                DAFuncionalidad dataFuncionalidades = new DAFuncionalidad();

                foreach (Modulo m in listaModulos)
                {
                    m.Funcionalidades = dataFuncionalidades.ObtenerFuncionalidadxModuloId(m.ModuloId);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                throw ex;
            }

            return listaModulos;

        }

        /// <summary>
        /// Este método obtiene el número total de registros de la tabla de Modulos
        /// </summary>
        /// <returns>Número total de registros</returns>
        public int ObtenerNumeroTotalRegistros()
        {
            logger.Info("Entró al método ObtenerNumeroTotalRegistros de BLMódulos sin parámetros");

            var daRoles = new DARol();

            int numeroTotalRegistros = 0;

            try
            {
                numeroTotalRegistros = daRoles.ObtenerNumeroTotalRegistros();
            }
            catch
            {
                Exception e = new Exception(errores.errObtenerTotalRegistros);

                logger.Error(e);

                throw e;
            }

            return numeroTotalRegistros;
        }

        /// <summary>
        /// Este método obtiene una instancia de módulo por el nombre
        /// </summary>
        /// <param name="nombre">Indica el nombre de módulo</param>       
        /// <returns>Una instancia de módulo</returns>
        public Modulo ObtenerModuloxNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                EVOException e = new EVOException(errores.errNombreModuloVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerModuloxNombre con el parámetro nombre = {nombre}");

            var daModulos = new DAModulo();

            Modulo modulo = daModulos.ObtenerModuloxNombre(nombre);

            if (modulo == null)
            {
                EVOException e = new EVOException(errores.errModuloNoExiste);

                logger.Error(e);

                throw e;
            }

            return modulo;
        }

        /// <summary>
        /// Este método obtiene una instancia de módulo por el id
        /// </summary>
        /// <param name="Moduloid">Indica el id de módulo</param>       
        /// <returns>Una instancia de módulo</returns>
        public Modulo ObtenerModuloxId(int Moduloid)
        {
            if (Moduloid <= 0)
            {
                EVOException e = new EVOException(errores.errIdNegativo);

                logger.Error(e);

                throw e;
            }           

            logger.Info($"Entró al método ObtenerModuloxId con los parámetros: Moduloid : {Moduloid}");

            var daModulos = new DAModulo();

            Modulo moduloObtenido = daModulos.ObtenerModuloxId(Moduloid);

            if (moduloObtenido == null)
            {
                EVOException e = new EVOException(errores.errIdModuloNoExiste);

                logger.Error(e);

                throw e;
            }

            Modulo modulo = daModulos.ObtenerModuloxId(Moduloid);

            return modulo;
        }
        #endregion
    }
}
