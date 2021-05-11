using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Utils;
using EVO_PV_Proxy.Models.MotivosApi;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Principal;
using System.Text;

namespace EVO_PV_Proxy
{
    public class MotivosProxy : Automapper
    {
        /// <summary>
        /// Obtiene todos los estados de un pedido
        /// </summary>
        /// <returns>Estado del pedido</returns>
        public List<MotivoRespuesta> ObtenerMotivos(int procesoId)
        {
            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            var HtmlResult = string.Empty;

            List<MotivoResponse> motivosResponse = null;
            List<MotivoRespuesta> motivosRespuesta = null;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
            {
                using (WebClient client = new WebClient())
                {
                    AppConfiguration appConfig = new AppConfiguration();

                    Uri url = new Uri(appConfig.AppSettings["API_EVO"] + $"motivos?procesoId={procesoId}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    HtmlResult = client.DownloadString(url.AbsoluteUri);
                    motivosResponse = JsonConvert.DeserializeObject<List<MotivoResponse>>(HtmlResult);
                }

            });

            if (motivosResponse!=null)
            {
                motivosRespuesta = this.iMapper.Map<List<MotivoResponse>, List<MotivoRespuesta>>(motivosResponse);
            }

            return motivosRespuesta;

        }
    }
}
