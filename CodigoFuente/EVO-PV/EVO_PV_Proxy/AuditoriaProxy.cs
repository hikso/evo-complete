using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Utils;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Principal;
using System.Text;

namespace EVO_PV_Proxy
{
    /// <summary>
    /// Autor            : Kevin Restrepo
    /// Fecha de Creación: 24-Oct/2019
    /// Descrición       : Clase de Proxy de registros de auditoria
    /// </summary>
    public class AuditoriaProxy : Automapper
    {
        /// <summary>
        /// Este método permite llamar el servicio de registro de auditoria de EVO
        /// </summary>
        /// <param name="auditoria">Datos del registro de auditoria</param>
        /// <returns>Verdadero si el servicio se pudó llamar exitosamete, falso de lo contrario</returns>
        public bool CrearRegistroAuditoria(Auditoria auditoria)
        {
            AppConfiguration appConfig = new AppConfiguration();

            Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "auditoria");

            string data = JsonConvert.SerializeObject(auditoria);

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (var client = new WebClient { UseDefaultCredentials = true })
               {
                   client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
                   client.UploadData(url.AbsoluteUri, "POST", Encoding.UTF8.GetBytes(data));
               }
           });

            return true;

        }
    }
}