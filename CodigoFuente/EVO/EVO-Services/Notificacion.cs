using EVO_BusinessObjects;
using EVO_PV_BusinessObjects.Enum;
using System;
using System.Net;
using System.Net.Mail;

namespace EVO_Services
{
    public class Notificacion
    {
        #region Propiedades
        private string correo { get; set; }
        private string contrasenia { get; set; }
        private string host { get; set; }
        private int port { get; set; }

        #endregion

        #region Contructores

        public Notificacion(string correo, string contrasenia, string host, int port)
        {
            this.correo = correo;
            this.contrasenia = contrasenia;
            this.host = host;
            this.port = port;
        }

        #endregion

        #region Metodos Públicos

        public bool Enviar(ConfiguracionNotificacion configuracion)
        {
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(configuracion.EmailDe));
            email.To.Add(new MailAddress(configuracion.EmailPara));
            email.From = new MailAddress(correo);

            if (configuracion.EstadoPedidoNuevo == EstadosPedidoEnum.Abierto.ToString())
            {
                email.Subject = $"Notificación creación solicitud de pedido - {configuracion.PuntoDeVenta}";

                email.Body =
               $@"
<p style='font-weight: 400;'><h1>Notificación Solicitud Creación de Pedidos</h1></p>
<p style='font-weight: 400;'>&nbsp;</p>
<p style='font-weight: 400;'><strong>Número Pedido:</strong>&nbsp;{configuracion.NumeroPedido}</p>
<p style='font-weight: 400;'><strong>Estado:</strong>&nbsp;{configuracion.EstadoPedidoNuevo}</p>
<p style='font-weight: 400;'><strong>Bodega:</strong>&nbsp;{configuracion.PuntoDeVenta}</p>
<p style='font-weight: 400;'><strong>Usuario:&nbsp;</strong>{configuracion.Nombre}</p>
<p style='font-weight: 400;'>&nbsp;</p>
<p style='font-weight: 400;'><h6>Este mensaje ha sido enviado automáticamente desde la aplicación EVO; por favor no responder.</h6></p>
<p style='font-weight: 400;'><h6>Si tiene alguna duda o inquietud, comunicarse al correo&nbsp;<a href='mailto:jefesistemas@porcicarnes.com'>jefesistemas@porcicarnes.com</a></h6></p>
<p style='font-weight: 400;'>&nbsp;</p>
<p style='text-align: left;'><img src='https://www.porcicarnes.com/wp-content/uploads/2018/12/logoantioque%C3%B1adeporcinos.png' alt='Porcicarnes' width='100' height='86' /><img src='https://www.porcicarnes.com/wp-content/uploads/2019/01/logo-header.png' alt='Porcicarnes' width='79' height='86' /></p>
"; 
            }
            else
            {
                email.Subject = $"Notificación cambio de estado solicitud de pedido - {configuracion.PuntoDeVenta}";

                email.Body =
               $@"
<p style='font-weight: 400;'><h1>Notificación Cambio de estado de solicitud de Pedidos</h1></p>
<p style='font-weight: 400;'>&nbsp;</p>
<p style='font-weight: 400;'><strong>Número Pedido:</strong>&nbsp;{configuracion.NumeroPedido}</p>
<p style='font-weight: 400;'><strong>Estado:</strong>&nbsp;{configuracion.EstadoPedidoNuevo}</p>
<p style='font-weight: 400;'><strong>Bodega:</strong>&nbsp;{configuracion.PuntoDeVenta}</p>
<p style='font-weight: 400;'><strong>Usuario:&nbsp;</strong>{configuracion.Nombre}</p>
<p style='font-weight: 400;'>&nbsp;</p>
<p style='font-weight: 400;'><h6>Este mensaje ha sido enviado automáticamente desde la aplicación EVO; por favor no responder.</h6></p>
<p style='font-weight: 400;'><h6>Si tiene alguna duda o inquietud, comunicarse al correo&nbsp;<a href='mailto:jefesistemas@porcicarnes.com'>jefesistemas@porcicarnes.com</a></h6></p>
<p style='font-weight: 400;'>&nbsp;</p>
<p style='text-align: left;'><img src='https://www.porcicarnes.com/wp-content/uploads/2018/12/logoantioque%C3%B1adeporcinos.png' alt='Porcicarnes' width='100' height='86' /><img src='https://www.porcicarnes.com/wp-content/uploads/2019/01/logo-header.png' alt='Porcicarnes' width='79' height='86' /></p>
";
            }

            email.IsBodyHtml = true;
            
            SmtpClient smtp = new SmtpClient();
            smtp.Host = host;
            smtp.Port = port;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(correo,contrasenia);

            try
            {               
                smtp.Send(email);
                email.Dispose();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }


        }
        #endregion
    }
}
