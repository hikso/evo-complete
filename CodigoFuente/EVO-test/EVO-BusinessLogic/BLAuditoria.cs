using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga
    /// Fecha de Creación: 30-Jul/2019
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de la auditoria
    /// </summary>
    public class BLAuditoria
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Crea un registro de Auditoria
        /// </summary>
        /// <param name="boRegistroAuditoria">Registro de auditoria de tipo RegistroAuditoria</param>
        /// <returns>Verdadero si pudo realizar el registro</returns>
        public bool Registrar(RegistroAuditoria boRegistroAuditoria)
        {
            if (boRegistroAuditoria == null)
            {
                EVOException e = new EVOException(errores.errRegistroAuditoriaVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método Registrar con los parámetros: {0}",
                JsonConvert.SerializeObject(boRegistroAuditoria)));

            string usuario = boRegistroAuditoria.Usuario;

            if (string.IsNullOrEmpty(usuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            int nBackSlash = usuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                usuario = usuario.Substring(nBackSlash + 1, usuario.Length - nBackSlash - 1);
            }

            var blUsuario = new BLUsuario();

            //Se valida que el usuario suministrado cómo parámetro exista en el sistema
            var usuarioObtenido = blUsuario.ObtenerUsuarioPorUsuario(usuario);

            if (usuarioObtenido == null)
            {
                EVOException e = new EVOException(string.Format(errores.errUsuarioNoExiste,
                    usuario));

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(boRegistroAuditoria.IP))
            {
                EVOException e = new EVOException(errores.errIPNoInformada);

                logger.Error(e);

                throw e;
            }

            //Se valida que la IP sea válida
            string IPPattern = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";

            Match regIPMatch = Regex.Match(boRegistroAuditoria.IP, IPPattern);

            if (!regIPMatch.Success)
            {
                EVOException e = new EVOException(errores.errIPFormatoIncorrecto);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(boRegistroAuditoria.Accion))
            {
                EVOException e = new EVOException(errores.errAccionNoInformada);

                logger.Error(e);

                throw e;
            }

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            int caracterMaximo = 0;

            try
            {
                caracterMaximo = int.Parse(blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.MAXIMO_CARACTERES_ACCION_REGISTRO_AUDITORIA));
            }
            catch (EVOException e)
            {
                logger.Error(e);

                throw e;
            }

            if (boRegistroAuditoria.Accion.Length > caracterMaximo)
            {
                throw new EVOException(errores.errCaracteresExcedidos);
            }

            var daAuditoria = new DAAuditoria();

            //La fecha del registro se asigna automáticamente, en el momento en el que se realiza el registro
            boRegistroAuditoria.Fecha = DateTime.Now;
            boRegistroAuditoria.UsuarioId = usuarioObtenido.UsuarioId;

            daAuditoria.CrearRegistro(boRegistroAuditoria);

            return true;
        }

        /// <summary>
        /// Este método permite saber cuántos registros se generan a partir de la consulta
        /// </summary>
        /// <returns>Lista de Registros de Auditoria</returns>
        public int ObtenerConteoTodosRegistros()
        {
            logger.Info(string.Format("Entró al método ObtenerConteoTodosRegistros de BLAuditoria"));

            DAAuditoria daAuditoria = new DAAuditoria();

            int nRegistros = 0;

            try
            {
                object result = daAuditoria.ObtenerConteoTodosRegistros();

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
        /// Este método permite saber cuántos registros se generan a partir de los filtros generados para la consulta
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda a aplicar sobre las acciones de auditoria</param>
        /// <returns>Lista de Registros de Auditoria</returns>
        public int ObtenerConteoTodosRegistrosxFiltro(FiltroAuditoria filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerConteoTodosRegistrosxFiltro con los parámetros; {0}",
                JsonConvert.SerializeObject(filtro)));

            DAAuditoria daAuditoria = new DAAuditoria();

            if (string.IsNullOrWhiteSpace(filtro.Usuario) &&
                string.IsNullOrWhiteSpace(filtro.Accion) &&
                string.IsNullOrWhiteSpace(filtro.Parametros) &&
                string.IsNullOrWhiteSpace(filtro.Fecha) &&
                string.IsNullOrWhiteSpace(filtro.IP))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            int nRegistros = 0;

            try
            {
                object result = daAuditoria.ObtenerConteoTodosRegistrosxFiltro(filtro);

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
        /// Este método obtiene todos los registros de Auditoria
        /// </summary>
        /// <param name="desde">Indica el número de registro desde el cuál se desea cargar los registros de Auditoria</param>
        /// <param name="hasta">Indica el número de registro hasta el cuál se desea cargar los registros de Auditoria</param>
        /// <returns>Lista de Registros de Auditoria</returns>
        public List<RegistroAuditoria> ObtenerTodosRegistros(int desde, int hasta)
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

            logger.Info(string.Format("Entró al método ObtenerTodosRegistros con los parámetros: desde: {0}, hasta: {1}", desde, hasta));

            DAAuditoria daAuditoria = new DAAuditoria();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            //Se valida que no se estén pidiendo más registros que los que se encuentren actualmente configurados en la tabla de parámetros generales
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

            List<RegistroAuditoria> registrosAuditoria = null;

            try
            {
                registrosAuditoria = daAuditoria.ObtenerTodosRegistros(desde, hasta);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return registrosAuditoria;
        }

        /// <summary>
        /// Este método obtiene todos los registros de Auditoria aplicando un filtro de búsqueda sobre las acciones
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda a aplicar sobre las acciones de auditoria</param>
        /// <returns>Lista de Registros de Auditoria</returns>
        public List<RegistroAuditoria> ObtenerTodosRegistrosxFiltro(FiltroAuditoria filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosRegistrosxFiltro con los parámetros {0}",
                JsonConvert.SerializeObject(filtro)));

            if (filtro.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtro.Hasta < filtro.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            DAAuditoria daAuditoria = new DAAuditoria();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            //Se valida que no se estén pidiendo más registros que los que se encuentren actualmente configurados en la tabla de parámetros generales
            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((filtro.Hasta - filtro.Desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrWhiteSpace(filtro.Usuario) &&
                string.IsNullOrWhiteSpace(filtro.Accion) &&
                string.IsNullOrWhiteSpace(filtro.Parametros) &&
                string.IsNullOrWhiteSpace(filtro.Fecha) &&
                string.IsNullOrWhiteSpace(filtro.IP))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            if (filtro.Fecha != null) {
                string FechaPattern = @"^([0]?[0-9]|[1][0-2])[.\/-]([0]?[1-9]|[1|2][0-9]|[3][0|1])[.\/-]([0-9]{4}|[0-9]{2})$";
                Match regFechaMatch = Regex.Match(filtro.Fecha, FechaPattern);

                if (!regFechaMatch.Success)
                {
                    filtro.Fecha = filtro.Fecha.Replace("-", "/");
                }
            }

            List<RegistroAuditoria> registrosAuditoria = null;

            try
            {
                registrosAuditoria = daAuditoria.ObtenerTodosRegistrosxFiltro(filtro);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return registrosAuditoria;
        }

        /// <summary>
        /// Este método guarda la información de los logs del cliente Angular
        /// </summary>
        /// <param name="rutaArchivo">rutaArchivo es la ruta donde se va a guardar la informacioón</param>
        /// /// <param name="registro">registro contiene la información que se va a guardar</param>
        /// <returns>No retorna</returns>

        public void CrearLog(string rutaArchivo, RegistroLOG registro) {

            FileInfo fileInfo = new FileInfo(rutaArchivo);
            StreamWriter fichero = fileInfo.AppendText();

            fichero.WriteLine();
            fichero.WriteLine($"Fecha: {DateTime.Now}");
            fichero.WriteLine($"Mensaje: {registro.Message}");
            fichero.WriteLine($"Detalle: {registro.Additional[0]}");
            fichero.WriteLine($"Archivo donde ocurrió el error: {registro.FileName}");
            fichero.WriteLine($"Numero de línea donde ocurrió el evento: {registro.LineNumber}");
            fichero.Close();
        }
        #endregion
    }
}