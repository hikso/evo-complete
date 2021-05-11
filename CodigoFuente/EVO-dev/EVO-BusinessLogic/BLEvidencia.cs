using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 26-Mar/2020
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de Evidencia
    /// </summary>
    public class BLEvidencia
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos
        public bool EnviarEvidencia(BOEvidenciaRequest bOEvidenciaRequest)
        {
            if (bOEvidenciaRequest == null)
            {
                EVOException e = new EVOException(errores.errEvidenciaRequestNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método EnviarEvidencia en BLEvidencia con los parámetros = {JsonConvert.SerializeObject(bOEvidenciaRequest)}");

            if (string.IsNullOrEmpty(bOEvidenciaRequest.Usuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            int nBackSlash = bOEvidenciaRequest.Usuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                bOEvidenciaRequest.Usuario = bOEvidenciaRequest.Usuario.Substring(nBackSlash + 1, bOEvidenciaRequest.Usuario.Length - nBackSlash - 1);
            }

            BLUsuario bLUsuarios = new BLUsuario();

            Usuario boUsuario = null;

            try
            {
                boUsuario = bLUsuarios.ObtenerUsuarioPorUsuario(bOEvidenciaRequest.Usuario);
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

            bOEvidenciaRequest.UsuarioId = boUsuario.UsuarioId;

            if (string.IsNullOrEmpty(bOEvidenciaRequest.Observaciones))
            {
                EVOException e = new EVOException(errores.errObservacionesNoInformadas);

                logger.Error(e);

                throw e;
            }

            if (bOEvidenciaRequest.Detalles == null)
            {
                EVOException e = new EVOException(errores.errArchivosRequestNoInformados);

                logger.Error(e);

                throw e;
            }

            if (bOEvidenciaRequest.Detalles.Count == 0)
            {
                EVOException e = new EVOException(errores.errArchivosRequestNoInformados);

                logger.Error(e);

                throw e;
            }

            if (bOEvidenciaRequest.PesajeEntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errPesajeEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            foreach (BOArchivoRequest bOArchivoRequest in bOEvidenciaRequest.Detalles)
            {
                if (string.IsNullOrEmpty(bOArchivoRequest.Base64))
                {
                    EVOException e = new EVOException(errores.errBase64NoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (string.IsNullOrEmpty(bOArchivoRequest.ExtensionArchivo))
                {
                    EVOException e = new EVOException(errores.errExtensionArchivoNoInformado);

                    logger.Error(e);

                    throw e;
                }

                bool extensionNoValida = true;

                foreach (string extension in Enum.GetNames(typeof(TiposArchivoEnum)))
                {
                    if (bOArchivoRequest.ExtensionArchivo.ToUpper().Contains(extension.ToUpper()))
                    {
                        extensionNoValida = false;
                        break;
                    }
                }

                if (extensionNoValida)
                {
                    EVOException e = new EVOException(errores.errExtensionArchivoNoValida);

                    logger.Error(e);

                    throw e;
                }

                if (string.IsNullOrEmpty(bOArchivoRequest.NombreArchivo))
                {
                    EVOException e = new EVOException(errores.errNombreArchivoNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (bOArchivoRequest.NombreArchivo.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                {
                    EVOException e = new EVOException(errores.errNombreArchivoNoValido);

                    logger.Error(e);

                    throw e;
                }

            }

            foreach (BOArchivoRequest bOArchivoRequest in bOEvidenciaRequest.Detalles)
            {
                if (bOEvidenciaRequest.Detalles
                    .Where(d => d.Base64 == bOArchivoRequest.Base64
                    && d.NombreArchivo == bOArchivoRequest.NombreArchivo
                    && d.ExtensionArchivo == bOArchivoRequest.ExtensionArchivo
                    ).Count() >= 2)
                {
                    EVOException e = new EVOException(errores.errArchivosRepetidos);

                    logger.Error(e);

                    throw e;
                }
            }

            bOEvidenciaRequest.GUID = Guid.NewGuid().ToString();

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();
            string rutaDirectorioEvidencias = string.Empty;

            try
            {
                rutaDirectorioEvidencias = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.RUTA_EVIDENCIAS);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (!Directory.Exists(rutaDirectorioEvidencias))
            {
                try
                {
                    Directory.CreateDirectory(rutaDirectorioEvidencias);
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    throw;
                }
            }

            DirectoryInfo directoryInfo = null;

            try
            {
                directoryInfo = new DirectoryInfo(rutaDirectorioEvidencias);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            long bytesArchivosLimite = 0;

            foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.*"))
            {
                bytesArchivosLimite += fileInfo.Length;
            }

            string limiteBytesArchivos = string.Empty;

            try
            {
                limiteBytesArchivos = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.LIMITE_BYTES_ARCHIVOS_SERVIDOR);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            long bytesArchivosLimiteServidor = 0;

            try
            {
                bytesArchivosLimiteServidor = long.Parse(limiteBytesArchivos);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            if (bytesArchivosLimite > bytesArchivosLimiteServidor)
            {
                EVOException e = new EVOException(errores.errLimiteEspacioServidor);

                throw e;
            }

            string rutaDirectorioEvidencia = Path.Combine(rutaDirectorioEvidencias, bOEvidenciaRequest.GUID);

            try
            {
                Directory.CreateDirectory(rutaDirectorioEvidencia);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }

            BLPesaje bLPesaje = new BLPesaje();
            BOPesajeEntrega bOPesajeEntrega = null;

            try
            {
                bOPesajeEntrega = bLPesaje.ObtenerPesajeEntrega(bOEvidenciaRequest.PesajeEntregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }           

            if (bOPesajeEntrega.Consecutivo <= 0)
            {
                EVOException e = new EVOException(errores.errConsecutivoNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(bOPesajeEntrega.Entrega.Pedido.WhsCode))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();

            BOBodega bOBodega = null;

            try
            {
                bOBodega = bLBodega.ObtenerBodegaPorCodigo(bOPesajeEntrega.Entrega.Pedido.WhsCode);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (string.IsNullOrEmpty(bOBodega.WhsName))
            {
                EVOException e = new EVOException(errores.errNameClienteNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(bOBodega.Email))
            {
                EVOException e = new EVOException(errores.errCorreoElectronicoNoRegistrado);

                logger.Error(e);

                throw e;
            }

            MailAddress mailAddress = null;

            try
            {
                mailAddress = new MailAddress(bOBodega.Email);
            }
            catch (FormatException)
            {
                EVOException e = new EVOException(errores.errCorreoElectronicoNoValido);

                logger.Error(e);

                throw e;
            }

            List<string> correosDestinatarios = new List<string>();

            correosDestinatarios.Add(bOBodega.Email);

            string emailRecepcion = string.Empty;

            try
            {
                emailRecepcion = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.CORREO_RECEPCION);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            try
            {
                mailAddress = new MailAddress(emailRecepcion);
            }
            catch (Exception)
            {
                EVOException e = new EVOException(errores.errCorreoElectronicoNoValido);

                logger.Error(e);

                throw e;
            }

            correosDestinatarios.Add(emailRecepcion);

            List<string> rutasArchivosEvidencia = new List<string>();

            long bytesArchivosEvidencia = 0;

            foreach (BOArchivoRequest archivoRequest in bOEvidenciaRequest.Detalles)
            {
                string rutaArchivoEvidencia = Path.Combine(rutaDirectorioEvidencia, $"{archivoRequest.NombreArchivo}.{archivoRequest.ExtensionArchivo.ToLower()}");

                try
                {
                    File.WriteAllBytes(rutaArchivoEvidencia, Convert.FromBase64String(archivoRequest.Base64));
                }
                catch (Exception e)
                {
                    Directory.Delete(rutaDirectorioEvidencia, true);

                    logger.Error(e);
                    throw;
                }

                rutasArchivosEvidencia.Add(rutaArchivoEvidencia);

                FileStream fileStream = File.OpenRead(rutaArchivoEvidencia);

                bytesArchivosEvidencia += fileStream.Length;

            }

            limiteBytesArchivos = string.Empty;

            try
            {
                limiteBytesArchivos = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.LIMITE_BYTES_ARCHIVOS_EVIDENCIA);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            bytesArchivosLimite = 0;

            try
            {
                bytesArchivosLimite = long.Parse(limiteBytesArchivos);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            if (bytesArchivosEvidencia > bytesArchivosLimite)
            {
                EVOException e = new EVOException(errores.errTamanioArchivosGoogle);

                Directory.Delete(rutaDirectorioEvidencia, true);

                throw e;
            }

            BLCorreoElectronico bLCorreoElectronico = null;

            try
            {
                bLCorreoElectronico = new BLCorreoElectronico(correosDestinatarios);
            }
            catch (EVOException e)
            {
                Directory.Delete(rutaDirectorioEvidencia, true);
                throw e;
            }
            catch (Exception e)
            {
                Directory.Delete(rutaDirectorioEvidencia, true);
                throw e;
            }

            List<string> documentos = bOPesajeEntrega.PesajesArticulo
                .Select(pa => pa.Documento)
                .Select(d => d.Documento)
                .Distinct().ToList();

            documentos = documentos.Where(d => DocumentosEnum.Entrada_de_Mercancía.ToString().Replace("_", " ") != d).ToList();

            try
            {
                bLCorreoElectronico.EnviarEvidencia(documentos,rutasArchivosEvidencia, bOBodega.WhsName, bOEvidenciaRequest.Usuario, bOPesajeEntrega.Consecutivo, bOEvidenciaRequest.Observaciones);
            }
            catch (EVOException e)
            {
                Directory.Delete(rutaDirectorioEvidencia, true);
                throw e;
            }
            catch (Exception e)
            {
                Directory.Delete(rutaDirectorioEvidencia, true);
                throw e;
            }

            DAEvidencia dAEvidencia = new DAEvidencia();

            bOEvidenciaRequest.FechaEvidencia = DateTime.Now;

            try
            {
                dAEvidencia.AsignarEvidencia(bOEvidenciaRequest);
            }
            catch (Exception e)
            {
                Directory.Delete(rutaDirectorioEvidencia, true);

                throw e;
            }

            return true;

        }

        /// <summary>
        /// Obtiene las evidencias filtradas
        /// </summary>
        /// <param name="fechaInicio">Indica la fecha de inicio de la evidencia(dd/mm/aaa)</param>
        /// <param name="fechaFin">Indica la fecha de fin de la evidencia(dd/mm/aaa)</param>
        /// <param name="puntoVenta">Indica el nombre del punto de venta</param>
        /// <response>List<BOEvidenciaResponse></response>
        public List<BOEvidenciaResponse> ObtenerEvidenciasxFiltro(string fechaInicio, string fechaFin, string puntoVenta)
        {
            logger.Info($"Entró al método ObtenerEvidenciasxFiltro en EvidenciaApi con los parámetros fechaInicio = {fechaInicio} , fechaFin = {fechaFin} , puntoVenta = {puntoVenta}");

            if (string.IsNullOrWhiteSpace(fechaInicio) &&
                string.IsNullOrWhiteSpace(fechaFin) &&
                string.IsNullOrWhiteSpace(puntoVenta)
                )
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            string expresion = string.Empty;

            Match match = null;

            if (string.IsNullOrEmpty(fechaInicio))
            {
                fechaInicio = DateTime.MinValue.ToString("dd/MM/yyyy");
            }
            else
            {
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

                match = Regex.Match(fechaInicio, expresion);

                if (!match.Success)
                {
                    EVOException e = new EVOException(errores.errFechaFormatoDDMMYYY);

                    logger.Error(e);

                    throw e;
                }

            }             

            if (string.IsNullOrEmpty(fechaFin))
            {
                fechaFin = DateTime.MaxValue.ToString("dd/MM/yyyy");
            }
            else
            {
                match = Regex.Match(fechaFin, expresion);

                if (!match.Success)
                {
                    EVOException e = new EVOException(errores.errFechaFormatoDDMMYYY);

                    logger.Error(e);

                    throw e;
                }
            }

            if (Convert.ToDateTime(fechaInicio) > Convert.ToDateTime(fechaFin))
            {
                EVOException e = new EVOException(errores.errFechaHastaMenorDesde);

                logger.Error(e);

                throw e;
            }            

            DAEvidencia dAEvidencia = new DAEvidencia();

            List<BOEvidenciaResponse> bOEvidenciasResponse = null;

            try
            {
                bOEvidenciasResponse = dAEvidencia.ObtenerEvidenciasxFiltro(fechaInicio,fechaFin,puntoVenta);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }

            List<string> numerosPedidos = bOEvidenciasResponse.Select(e => e.NumeroPedido).Distinct().ToList();

            foreach (string numeroPedido in numerosPedidos)
            {
                int numeroEntrega = 1;

                foreach (BOEvidenciaResponse evidencia in bOEvidenciasResponse.Where(e => e.NumeroPedido == numeroPedido).OrderBy(o => o.FechaEntrega))
                {
                    evidencia.NumeroEntrega = numeroEntrega.ToString();
                    numeroEntrega++;
                }

            }

            return bOEvidenciasResponse.OrderByDescending(e => e.FechaEvidencia).ToList();

        }

        /// <summary>
        /// Obtiene el archivo en base64
        /// </summary>
        /// <param name="GUID">Indica el número unico retornado en el detalle de evidencia</param>
        /// <param name="nombreArchivo">Indica el nombre del archivo</param>
        /// <param name="extensionArchivo">Indica la extensión del archivo</param>
        /// <response>Base64</response>
        public string ObtenerArchivoEvidencia(string gUID, string nombreArchivo, string extensionArchivo)
        {
            logger.Info($"Entró al método ObtenerArchivoEvidencia en EvidenciaApi con los parámetros gUID = {gUID} , nombreArchivo = {nombreArchivo} , extensionArchivo = {extensionArchivo}");

            if (string.IsNullOrEmpty(gUID))
            {
                EVOException e = new EVOException(errores.errGUIDNoInformado);

                throw e;
            }

            if (string.IsNullOrEmpty(nombreArchivo))
            {
                EVOException e = new EVOException(errores.errNombreArchivoNoInformado);

                throw e;
            }

            if (string.IsNullOrEmpty(extensionArchivo))
            {
                EVOException e = new EVOException(errores.errExtensionArchivoNoInformado);

                throw e;
            }

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            string rutaDirectorioEvidencias = string.Empty;

            try
            {
                rutaDirectorioEvidencias = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.RUTA_EVIDENCIAS);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            rutaDirectorioEvidencias = Path.Combine(rutaDirectorioEvidencias, gUID);

            rutaDirectorioEvidencias = Path.Combine(rutaDirectorioEvidencias, $"{nombreArchivo}.{extensionArchivo}");

            byte[] archivoBytes = File.ReadAllBytes(rutaDirectorioEvidencias);

            if (archivoBytes == null)
            {
                Exception e = new Exception(errores.errArchivoNoEncontrado);

                throw e;
            }

            return Convert.ToBase64String(archivoBytes);

        }

        /// <summary>
        /// Obtiene del detalle de la evidencia
        /// </summary>
        /// <param name="evidenciaId">Indica de la evidencia</param>
        /// <response>BODetalleEvidenciaResponse</response>
        public BODetalleEvidenciaResponse ObtenerDetalleEvidencia(int evidenciaId, string numeroEntrega)
        {
            logger.Info($"Entró al método ObtenerDetalleEvidencia en BLEvidencia con el parámetro evidenciaId = {evidenciaId}");

            if (evidenciaId <= 0)
            {
                EVOException e = new EVOException(errores.errEvidenciaIdNoInformado);

                throw e;
            }

            if (string.IsNullOrEmpty(numeroEntrega))
            {
                EVOException e = new EVOException(errores.errNumeroEntregaNoInformado);

                throw e;
            }

            BOEvidencia bOEvidencia = null;

            try
            {
                bOEvidencia = ObtenerEvidencia(evidenciaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BLPesaje bLPesaje = new BLPesaje();
            BOPesajeEntrega bOPesajeEntrega = null;

            try
            {
                bOPesajeEntrega = bLPesaje.ObtenerPesajeEntrega(bOEvidencia.PesajeEntregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BLBodega bLBodega = new BLBodega();

            BOBodega bOBodega = null;

            try
            {
                bOBodega = bLBodega.ObtenerBodegaPorCodigo(bOPesajeEntrega.Entrega.Pedido.WhsCode);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();
            string correoDestino = string.Empty;

            try
            {
                correoDestino = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.CORREO_RECEPCION);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            MailAddress mailAddress;

            try
            {
                mailAddress = new MailAddress(correoDestino);
            }
            catch (Exception)
            {
                EVOException e = new EVOException(errores.errCorreoElectronicoNoValido);

                logger.Error(e);

                throw e;
            }

            BODetalleEvidenciaResponse bODetalleEvidenciaResponse = new BODetalleEvidenciaResponse()
            {
                PuntoVenta = bOBodega.WhsName,
                NumeroPedido = $"{bOBodega.WhsCode.Substring(bOBodega.WhsCode.IndexOf("-") + 1)}-{bOPesajeEntrega.Entrega.Pedido.NumeroPedido}",
                FechaEvidencia = bOEvidencia.FechaEvidencia.ToString("dd/MM/yyyy"),
                CorreoOrigen = bOBodega.Email,
                CorreoDestino = correoDestino,
                NumeroEntrega = numeroEntrega,
                Usuario = bOEvidencia.Usuario.Usuario,
                Observaciones = bOEvidencia.Observaciones,
                GUID = bOEvidencia.GUID,
                Archivos = new List<BOArchivoResponse>(),
                DocumentosArticulos = new List<BODocumentoArticuloResponse>()
            };

            BLArticulo bLArticulo = new BLArticulo();

            try
            {
                bODetalleEvidenciaResponse.DocumentosArticulos.AddRange(
                       bOPesajeEntrega.PesajesArticulo.Where(pa => pa.Documento != null).Select(pa => new BODocumentoArticuloResponse()
                       {
                           CodigoArticulo = pa.DetalleEntrega.DetallePedido.ItemCode,
                           NombreArticulo = bLArticulo.ObtenerArticuloxCodigo(pa.DetalleEntrega.DetallePedido.ItemCode).ItemName,
                           Documento = pa.Documento.Documento
                       }));

            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            bODetalleEvidenciaResponse.Archivos.AddRange(
                       bOEvidencia.DetallesEvidencia.Select(de => new BOArchivoResponse()
                       {
                           NombreArchivo = de.NombreArchivo,
                           ExtensionArchivo = de.ExtensionArchivo
                       }));

            return bODetalleEvidenciaResponse;

        }

        /// <summary>
        /// Obtiene la evidencia por evidenciaId
        /// </summary>
        /// <param name="evidenciaId">Indica de la evidencia</param>
        /// <response>BOEvidencia</response>
        public BOEvidencia ObtenerEvidencia(int evidenciaId)
        {
            logger.Info($"Entró al método ObtenerEvidencia en BLEvidencia con el parámetro evidenciaId = {evidenciaId}");

            if (evidenciaId <= 0)
            {
                EVOException e = new EVOException(errores.errEvidenciaIdNoInformado);

                throw e;
            }

            DAEvidencia dAEvidencia = new DAEvidencia();
            BOEvidencia bOEvidencia = null;

            try
            {
                bOEvidencia = dAEvidencia.ObtenerEvidencia(evidenciaId);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }

            if (bOEvidencia == null)
            {
                EVOException e = new EVOException(errores.errEvidenciaNoRegistrada);

                throw e;
            }

            return bOEvidencia;

        }
        /// <summary>
        /// Obtiene las evidencias
        /// </summary>
        /// <response>List<BOEvidenciaResponse></response>
        public List<BOEvidenciaResponse> ObtenerEvidencias()
        {
            logger.Info("Entró al método ObtenerEvidencias en BLEvidencia sin parámetros");

            DAEvidencia dAEvidencia = new DAEvidencia();

            List<BOEvidenciaResponse> bOEvidenciasResponse = null;

            try
            {
                bOEvidenciasResponse = dAEvidencia.ObtenerEvidencias();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }

            List<string> numerosPedidos = bOEvidenciasResponse.Select(e => e.NumeroPedido).Distinct().ToList();

            foreach (string numeroPedido in numerosPedidos)
            {
                int numeroEntrega = 1;

                foreach (BOEvidenciaResponse evidencia in bOEvidenciasResponse.Where(e => e.NumeroPedido == numeroPedido).OrderBy(o => o.FechaEntrega))
                {
                    evidencia.NumeroEntrega = numeroEntrega.ToString();
                    numeroEntrega++;
                }

            }

            return bOEvidenciasResponse.OrderByDescending(e => e.FechaEvidencia).ToList();
        }
        #endregion
    }
}
