
using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Utils;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;

namespace EVO_PV_Proxy
{
    public class BodegaProxy : Automapper
    {
        /// <summary>
        /// Obtiene las plantas para realizar un pedido
        /// </summary>
        /// <returns>Planta de beneficio, Planta de derivados</returns>
        public async Task<List<Bodega>> ObtenerPlantas()
        {
            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            var HtmlResult = string.Empty;

            await WindowsIdentity.RunImpersonated(currentUser.AccessToken, async () =>
            {
                using (WebClient client = new WebClient())
                {
                    AppConfiguration appConfig = new AppConfiguration();

                    string URI = appConfig.AppSettings["API_EVO"] + "bodegas/planta";
                    CredentialCache cc = new CredentialCache();
                    client.UseDefaultCredentials = true;
                    HtmlResult = await client.DownloadStringTaskAsync(URI);
                }
            });

            return JsonConvert.DeserializeObject<List<Bodega>>(HtmlResult);

        }

        /// <summary>
        /// Obtiene el punto de venta por el código
        /// </summary>
        /// <returns>Objeto de negocio tipo bodega</returns>
        public Bodega ObtenerBodegaPorCodigo(string codigo)
        {
            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            var HtmlResult = string.Empty;

            WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
           {
               using (WebClient client = new WebClient())
               {
                   AppConfiguration appConfig = new AppConfiguration();

                   string URI = appConfig.AppSettings["API_EVO"] + $"bodegas/{codigo}";
                   CredentialCache cc = new CredentialCache();
                   client.UseDefaultCredentials = true;
                   HtmlResult = client.DownloadString(URI);
                  
               }
           });

            return JsonConvert.DeserializeObject<Bodega>(HtmlResult);

        }
    }
}
