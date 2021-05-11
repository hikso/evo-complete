using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Utils;
using EVO_PV_Proxy.Models.FacturacionApi;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Principal;
using System.Text;

namespace EVO_PV_Proxy
{
    public class FacturacionProxy : Automapper
    {
        public List<OtraFormaPagoBO> ObtenerOtrasFormasPago()
        {
            AppConfiguration appConfig = new AppConfiguration();

            Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "facturacion/otrasformaspago");          

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            List<OtraFormaPagoResponse> otrasFormasPagoResponse = null;
            List<OtraFormaPagoBO> otrasFormasPagoBO = new List<OtraFormaPagoBO>();

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
            {
                using (var client = new WebClient { UseDefaultCredentials = true })
                {                    
                    client.UseDefaultCredentials = true;
                    string HtmlResult = Encoding.UTF8.GetString(client.DownloadData(url.AbsoluteUri));
                    otrasFormasPagoResponse = JsonConvert.DeserializeObject<List<OtraFormaPagoResponse>>(HtmlResult);
                }
            });

            if (otrasFormasPagoResponse!=null)
            {
                otrasFormasPagoBO = iMapper.Map<List<OtraFormaPagoResponse>, List<OtraFormaPagoBO>>(otrasFormasPagoResponse);
            }

            return otrasFormasPagoBO;
        }
    }
}
