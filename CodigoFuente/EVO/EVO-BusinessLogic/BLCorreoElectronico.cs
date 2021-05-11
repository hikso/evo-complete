using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 27-Mar/2020
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio del correo electrónico
    /// </summary>
    public class BLCorreoElectronico
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private BOSmtpClient bOSmtpClient = null;
        private BOMailMessage bOMailMessage = null;
        #endregion

        #region Constructores
        public BLCorreoElectronico(List<string> correosDestinatarios)
        {
            logger.Info($"Entró al método contructor de BLCorreoElectronico con parámetro correosDestinatarios={correosDestinatarios}");

            bOSmtpClient = new BOSmtpClient();

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            try
            {
                bOSmtpClient.Host = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.SMTP_HOST);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            string Port = string.Empty;

            try
            {
                Port = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.SMTP_PORT);
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
                bOSmtpClient.Port = int.Parse(Port);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            string enableSSL = string.Empty;

            try
            {
                enableSSL = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.ENABLE_SSL);
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
                bOSmtpClient.EnableSsl = bool.Parse(enableSSL);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            string UseDefaultCredentials = string.Empty;

            try
            {
                UseDefaultCredentials = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.USE_DEFAULT_CREDENTIALS);
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
                bOSmtpClient.UseDefaultCredentials = bool.Parse(UseDefaultCredentials);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            try
            {
                bOSmtpClient.UserName = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.CORREO_TECNOLOGIA);
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
                bOSmtpClient.PassWord = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.CORREO_TECNOLOGIA_CONTRASENIA);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (correosDestinatarios == null)
            {
                EVOException e = new EVOException(errores.errCorreosElectronicosNoInformado);

                logger.Error(e);

                throw e;
            }

            if (correosDestinatarios.Count == 1)
            {
                EVOException e = new EVOException(errores.errCorreosElectronicosObligatorios);

                logger.Error(e);

                throw e;
            }

            MailAddress mailAddress = null;

            bOMailMessage = new BOMailMessage();

            bOMailMessage.CorreosDestinatarios = new List<string>();

            foreach (string correoDestinatario in correosDestinatarios)
            {
                if (string.IsNullOrEmpty(correoDestinatario))
                {
                    EVOException e = new EVOException(errores.errCorreoElectronicoNoInformado);

                    logger.Error(e);

                    throw e;
                }

                try
                {
                    mailAddress = new MailAddress(correoDestinatario);
                }
                catch (FormatException)
                {
                    EVOException e = new EVOException(errores.errCorreoElectronicoNoValido);

                    logger.Error(e);

                    throw e;
                }               

                bOMailMessage.CorreosDestinatarios.Add(correoDestinatario);

            }

        }
        #endregion

        #region Métodos

        public bool EnviarProduccion(string puntoVenta, string codigoPedido,List<string> articulosProducir)
        {
            logger.Info($"Entró al método EnviarProduccion de BLCorreoElectronico con los parámetros puntoVenta = {puntoVenta} , codigoPedido = {codigoPedido} , articulosProducir = {JsonConvert.SerializeObject(articulosProducir)}");

            if (string.IsNullOrEmpty(puntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(codigoPedido))
            {
                EVOException e = new EVOException(errores.errCodigoPedidoNoInformado);

                logger.Error(e);

                throw e;
            }

            if (articulosProducir == null)
            {
                EVOException e = new EVOException(errores.errArticulosProduccionNoInformados);

                logger.Error(e);

                throw e;
            }

            string articulosBody = "<br><br>"; 
            
            for (int i = 0; i < articulosProducir.Count; i++)
            {
                articulosBody += articulosProducir[i] + "<br>";
            }           

            bOMailMessage.IsBodyHtml = true;

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            string titulo = string.Empty;

            try
            {
                titulo = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.SUBJECT_PRODUCCION);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            bOMailMessage.Subject = string.Format(titulo, puntoVenta);

            string body = string.Empty;

            try
            {
                body = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.BODY_PRODUCCION);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            bOMailMessage.Body = string.Format(body, codigoPedido, articulosBody);

            CorreoElectronicoService correoElectronicoService = null;

            try
            {
                correoElectronicoService = new CorreoElectronicoService(bOSmtpClient, bOMailMessage);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }           

            try
            {
                correoElectronicoService.Enviar();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            return true;

        }

        public bool EnviarEvidencia(List<string> documentos,List<string> rutasArchivos, string puntoVenta, string usuario, int consecutivo,string observaciones)
        {
            logger.Info($"Entró al método EnviarRecepcion de BLCorreoElectronico con los parámetros rutasArchivos = {JsonConvert.SerializeObject(rutasArchivos)} , puntoVenta = {puntoVenta} , usuario = {usuario} , consecutivo = {consecutivo}");

            if (rutasArchivos == null)
            {
                EVOException e = new EVOException(errores.errArchivosRequestNoInformados);

                logger.Error(e);

                throw e;
            }

            if (documentos == null)
            {
                EVOException e = new EVOException(errores.errDocumentosNoInformados);

                logger.Error(e);

                throw e;
            }

            string documentosBody = "<br><br>";
            //if (documentos.Count==1)
            //{
            //    documentos.Clear();
            //}
            //else
            //{
                for (int i = 0; i < documentos.Count; i++)
                {
                  documentosBody += documentos[0] + "<br>";
                }
           // }

            bOMailMessage.IsBodyHtml = true;

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            string titulo = string.Empty;

            try
            {
                titulo = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.SUBJECT_RECEPCION);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            bOMailMessage.Subject = string.Format(titulo, puntoVenta);

            string body = string.Empty;

            try
            {
                body = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.BODY_RECEPCION);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            bOMailMessage.Body = string.Format(body, consecutivo, usuario,documentosBody, observaciones);

            CorreoElectronicoService correoElectronicoService = null;

            try
            {
                correoElectronicoService = new CorreoElectronicoService(bOSmtpClient,bOMailMessage);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            try
            {
                correoElectronicoService.AdjuntarArchivos(rutasArchivos);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            try
            {
                correoElectronicoService.Enviar();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            return true;

        }
        #endregion

    }
}
