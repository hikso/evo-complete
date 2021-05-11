using EVO_BusinessObjects;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace EVO_Services
{
    public class CorreoElectronicoService
    {
        #region Atributos
        private SmtpClient smtpClient = null;
        private MailMessage mailMessage = null;
        #endregion

        #region Contructores
        public CorreoElectronicoService(BOSmtpClient bOSmtpClient, BOMailMessage bOMailMessage)
        {
            smtpClient = new SmtpClient();
            smtpClient.Host = bOSmtpClient.Host;
            smtpClient.Port = bOSmtpClient.Port;
            smtpClient.EnableSsl = bOSmtpClient.EnableSsl;
            smtpClient.UseDefaultCredentials = bOSmtpClient.UseDefaultCredentials;
            smtpClient.Credentials = new NetworkCredential(bOSmtpClient.UserName,bOSmtpClient.PassWord);

            mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(bOSmtpClient.UserName);
            mailMessage.Subject = bOMailMessage.Subject;
            mailMessage.Body = bOMailMessage.Body;
            mailMessage.IsBodyHtml = bOMailMessage.IsBodyHtml;

            foreach (string correoDestinatario in bOMailMessage.CorreosDestinatarios)
            {
                mailMessage.To.Add(new MailAddress(correoDestinatario));
            }

        }
        #endregion

        #region Métodos
        public bool AdjuntarArchivos(List<string> rutasArchivos)
        {
            foreach (string rutaArchivo in rutasArchivos)
            {
                mailMessage.Attachments.Add(new Attachment(rutaArchivo, MediaTypeNames.Application.Octet));
            }

            return true;
        }

        public bool Enviar()
        {
            smtpClient.Send(mailMessage);
            mailMessage.Dispose();
            return true;         
        }
        #endregion

    }
}
